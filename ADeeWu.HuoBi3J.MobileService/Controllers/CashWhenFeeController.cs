using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ADeeWu.HuoBi3J.Libary;
using System.Web;

namespace ADeeWu.HuoBi3J.MobileService.Controllers
{
    /// <summary>
    /// 现金抵扣
    /// </summary>
    public class CashWhenFeeController : ApiController
    {
        DataBase db = DataBase.Create();
        DAL.Key_CircleSaleMan salemanDAL = new DAL.Key_CircleSaleMan();
        DAL.Coupons_CashWhenFee feeDAL = new DAL.Coupons_CashWhenFee();
        DAL.Coupons_CashWhenFee_Code codeDAL = new DAL.Coupons_CashWhenFee_Code();
        DAL.Coupons_CashWhenFee_CodeLog codeLogDAL = new DAL.Coupons_CashWhenFee_CodeLog();
        DAL.Coupons_CashWhenFee_Condition conditionDAL = new DAL.Coupons_CashWhenFee_Condition();

        /// <summary>
        /// 商家现金抵扣券活动，扫描二维码后使用
        /// </summary>
        /// <param name="salemanuserid">商家ID</param>
        /// <returns>返回商家活动的信息，http404 商家未找到或商家未参加现金抵扣活动</returns>
        public SaleManCashWhenFee Get(int salemanuserid)
        {
            var cashWhenFees = feeDAL.GetEntityList("createdate desc", new string[] { "createuserid" }, new object[] { salemanuserid });
            if (cashWhenFees == null || !cashWhenFees.Any()) throw new HttpResponseException(HttpStatusCode.NotFound);
            var cashWhenFee = cashWhenFees.FirstOrDefault();

            var conditions = conditionDAL.GetEntityList("CreateTime desc", new string[] { "salemanuserid" }, new object[] { salemanuserid });
            if (!conditions.IsNotNullAndAny()) throw new HttpResponseException(HttpStatusCode.NotFound);
            var condition = conditions.FirstOrDefault();

            var saleman = salemanDAL.GetEntity("userid=" + cashWhenFee.CreateUserID);
            if (saleman == null) saleman = new Model.Key_CircleSaleMan();

            return new SaleManCashWhenFee
            {
                SaleManUserID = salemanuserid,
                EndDate = cashWhenFee.EndDate.Value,
                Fee = cashWhenFee.Fee.Value,
                Money = cashWhenFee.Money.Value,
                CompanyAddress = saleman.CompanyAddress,
                CompanyName = saleman.CompanyName,
                Phone = saleman.Phone,
                GetTicketMoney = condition.Money.Value,
                GetTicketMemo = condition.Memo,
            };
        }

        /// <summary>
        /// 我的现金抵扣券
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="salemanuserid">商家ID(商家ID=0时，不筛选商家)</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">页容量</param>
        /// <returns>返回我所有的现金抵扣券</returns>
        [HttpGet]
        public IEnumerable<MyTicketModel> MyTicket(int userid, int salemanuserid, int pageindex, int pagesize)
        {
            var strWhere = "count > 0  and count>usecount and userid=" + userid;
            if (salemanuserid > 0)
                strWhere += "and SaleManUserID = " + salemanuserid;
            var ticketTable = db.Select(pagesize, pageindex, "vw_Coupons_CashWhenFee_UserTicket", "id", strWhere, "");

            return GetMyTicket(ticketTable);
        }

        /// <summary>
        /// 使用现金抵扣券
        /// </summary>
        /// <param name="userid">使用者ID</param>
        /// <param name="ids">使用的券ID，例如：1,2,3</param>
        /// <param name="counts">相对应券的使用数量，例如：1,2,3</param>
        /// <returns>返回券使用后的消费密码；http400：参数不正确，ids与counts个数没有一一对应或者是有些券不是该用户的；http404：上传的ID都没能使用；http500：其中一项抵扣券的使用数量超过所拥有的券数</returns>
        public HttpResponseMessage UseTicket(int userid, string ids,string counts)
        {
            var IDs = ids.Split(',').Select(p => p.GetInt()).ToList();
            var Counts = counts.Split(',').Select(p => p.GetInt()).ToList();

            if (!IDs.IsNotNullAndAny() || !Counts.IsNotNullAndAny() || IDs.Count != Counts.Count)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var codeDT = db.Select("vw_Coupons_CashWhenFee_UserTicket", string.Format("id in (0,{0}) and userid = {1}", string.Join(",", IDs), userid), "id");
            var codes = GetMyTicket(codeDT).ToList();

            if (codes.Count() != IDs.Count)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].LeftCount > 0 && codes[i].LeftCount > Counts[i])
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            var ticketCode = GeneralCode();
            for (int i = 0; i < codes.Count(); i++)
            {
                var code = codes[i];
                codeDAL.Update(new string[] { "usecount" }, new object[] { code.UseCount + Counts[i] }, "id=" + code.ID);

                codeLogDAL.Add(new Model.Coupons_CashWhenFee_CodeLog
                {
                    CodeID = code.ID,
                    CreateTime = DateTime.Now,
                    UseCount = Counts[i],
                    UserCode = ticketCode,
                });
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// 领取商家优惠券
        /// </summary>
        /// <param name="userid">领取人ID</param>
        /// <param name="salemanuserid">商家ID</param>
        /// <param name="count">张数</param>
        /// <returns>http200 领取成功；http204领取券数小于0；http404 商家未找到或商家未参加现金抵扣活动</returns>
        public HttpResponseMessage ObtainTicket(int userid, int salemanuserid, int count)
        {
            if (count <= 0) throw new HttpResponseException(HttpStatusCode.NoContent);

            var cashWhenFees = feeDAL.GetEntityList("createdate desc", new string[] { "createuserid" }, new object[] { salemanuserid });
            if (cashWhenFees == null || !cashWhenFees.Any()) throw new HttpResponseException(HttpStatusCode.NotFound);
            var cashWhenFee = cashWhenFees.FirstOrDefault();

            codeDAL.Add(new Model.Coupons_CashWhenFee_Code
            {
                Count = count,
                CreateTime = DateTime.Now,
                EndDate = cashWhenFee.EndDate,
                Fee = cashWhenFee.Fee,
                Money = cashWhenFee.Money,
                SaleManUserID = cashWhenFee.CreateUserID,
                StartDate = cashWhenFee.StartDate,
                UseCount = 0,
                UserID = userid,
            });

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        /// <summary>
        /// convert dt to list
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private IEnumerable<MyTicketModel> GetMyTicket(DataTable dt)
        {
            var tickets = new List<MyTicketModel>();
            if (dt == null || dt.Rows.Count <= 0) return tickets;

            foreach (DataRow row in dt.Rows)
            {
                tickets.Add(new MyTicketModel
                {
                    ID = row["ID"].GetInt(),
                    Fee = row["Fee"].GetDecimal(),
                    EndDate = row["EndDate"].GetDateTime(),
                    Money = row["Money"].GetDecimal(),
                    SaleManUserID = row["SaleManUserID"].GetInt(),
                    SaleMan = row["CompanyName"].GetStr(),
                    StartDate = row["StartDate"].GetDateTime(),
                    UserID = row["UserID"].GetInt(),
                    Count = row["Count"].GetInt(),
                    UseCount = row["UseCount"].GetInt(),
                    LeftCount = row["Count"].GetInt() - row["UseCount"].GetInt(),
                    CreateTime = row["CreateTime"].GetDateTime(),
                });
            }

            return tickets;
        }

        /// <summary>
        /// 生成密码
        /// </summary>
        /// <returns></returns>
        private string GeneralCode()
        {
            var codes = new List<string>();

            var r = new Random(DateTime.Now.Millisecond);
            var codeLogDAL = new DAL.Coupons_CashWhenFee_CodeLog();
            var code = "";
            while (true)
            {
                code = r.Next(10000000, 99999999).ToString();
                if (!codeLogDAL.Exist("UserCode", code)) break;
            }

            return code;
        }

        /// <summary>
        /// 现金抵扣券
        /// </summary>
        public class MyTicketModel : Model.Coupons_CashWhenFee_Code
        {
            /// <summary>
            /// 商家
            /// </summary>
            public string SaleMan { get; set; }
            /// <summary>
            /// 剩下券数
            /// </summary>
            public int LeftCount { get; set; }
        }

        /// <summary>
        /// 商家活动信息
        /// </summary>
        public class SaleManCashWhenFee
        {
            /// <summary>
            /// 商家ID
            /// </summary>
            public int SaleManUserID { get; set; }
            /// <summary>
            /// 商家名称
            /// </summary>
            public string CompanyName { get; set; }
            /// <summary>
            /// 商家地址
            /// </summary>
            public string CompanyAddress { get; set; }
            /// <summary>
            /// 联系方式
            /// </summary>
            public string Phone { get; set; }
            /// <summary>
            /// 消费金额
            /// </summary>
            public decimal Fee { get; set; }
            /// <summary>
            /// 抵扣金额
            /// </summary>
            public decimal Money { get; set; }
            /// <summary>
            /// 到期时间
            /// </summary>
            public DateTime EndDate { get; set; }
            /// <summary>
            /// 消费多少钱能获取现金抵扣券
            /// </summary>
            public decimal GetTicketMoney { get; set; }
            /// <summary>
            /// 现金抵扣券发放备注
            /// </summary>
            public string GetTicketMemo { get; set; }
        }
    }
}
