using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.MobileService.Controllers
{
    /// <summary>
    /// 现金抵扣
    /// </summary>
    public class CashWhenFeeController : ApiController
    {
        DataBase db = DataBase.Create();        

        /// <summary>
        /// 我的现金抵扣券(按商家)
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns>返回各个商家拥有的券数</returns>
        [HttpGet]
        public IEnumerable<TicketCountOfSalemanModel> MyTicketOfSaleman(int userid)
        {
            var ticketTable = db.Select("vw_Coupons_CashWhenFee_UserTicket", "userid=" + userid, "");

            return GetMyTicket(ticketTable).GroupBy(p => p.SaleMan).Select(p => new TicketCountOfSalemanModel { SaleMan = p.Key, Count = p.Count() });
        }

        /// <summary>
        /// 我的现金抵扣券
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">页容量</param>
        /// <returns>返回我所有的现金抵扣券</returns>
        [HttpGet]
        public IEnumerable<MyTicketModel> MyTicket(int userid, int pageindex, int pagesize)
        {
            var ticketTable = db.Select(pagesize, pageindex, "vw_Coupons_CashWhenFee_UserTicket", "id", "userid=" + userid, "");

            return GetMyTicket(ticketTable);
        }

        /// <summary>
        /// 使用现金抵扣券
        /// </summary>
        /// <param name="IDs">凑单的现金抵扣券ID</param>
        /// <returns>返回券使用后的消费密码, 当http404:上传的ID都没能使用</returns>
        public string UseTicket(List<int> IDs)
        {
            var successIDs = new List<int>();
            DAL.Coupons_List listDAL = new DAL.Coupons_List();
            DAL.Coupons_CashWhenFee_Code codeDAL = new DAL.Coupons_CashWhenFee_Code();
            foreach (var listID in IDs)
            {
                if (listDAL.Update(new string[] { "IsUse", "usedate" }, new object[] { 1, DateTime.Now }, "id=" + listID) <= 0) continue;

                successIDs.Add(listID);
            }

            if (!successIDs.Any()) throw new HttpResponseException(HttpStatusCode.NotFound);

            var code = GeneralCode();
            foreach (var id in successIDs)
            {
                codeDAL.Add(new Model.Coupons_CashWhenFee_Code
                {
                    Coupons_ListID = id,
                    Code = code,
                });
            }

            return code;
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
                    IsUse = row["IsUse"].GetBool(),
                    Money = row["Money"].GetDecimal(),
                    SaleManUserID = row["SaleManUserID"].GetInt(),
                    SaleMan = row["SaleMan"].GetStr(),
                    StartDate = row["StartDate"].GetDateTime(),
                    Code = row["Password"].GetStr(),
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
            var codeDAL = new DAL.Coupons_CashWhenFee_Code();
            var code = "";
            while (true)
            {
                code = r.Next(10000000, 99999999).ToString();
                if (!codeDAL.Exist("code", code)) break;
            }

            return code;
        }

        /// <summary>
        /// 各个商家的票券数
        /// </summary>
        public class TicketCountOfSalemanModel
        {
            /// <summary>
            /// 商家名称
            /// </summary>
            public string SaleMan { get; set; }
            /// <summary>
            /// 券数
            /// </summary>
            public int Count { get; set; }
        }

        /// <summary>
        /// 现金抵扣券
        /// </summary>
        public class MyTicketModel
        {
            /// <summary>
            /// ID
            /// </summary>
            public int ID { get; set; }
            /// <summary>
            /// 商家ID
            /// </summary>
            public int SaleManUserID { get; set; }
            /// <summary>
            /// 商家
            /// </summary>
            public string SaleMan { get; set; }
            /// <summary>
            /// 是否已使用
            /// </summary>
            public bool IsUse { get; set; }
            /// <summary>
            /// 消费满多少
            /// </summary>
            public decimal Fee { get; set; }
            /// <summary>
            /// 抵扣现金
            /// </summary>
            public decimal Money { get; set; }
            /// <summary>
            /// 开始时间
            /// </summary>
            public DateTime StartDate { get; set; }
            /// <summary>
            /// 结束时间
            /// </summary>
            public DateTime EndDate { get; set; }
            /// <summary>
            /// 消费券密码
            /// </summary>
            public string Code { get; set; }
        }
    }
}
