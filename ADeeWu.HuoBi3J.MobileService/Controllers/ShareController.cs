using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ADeeWu.HuoBi3J.Libary;
using Newtonsoft.Json;
using ADeeWu.HuoBi3J.MobileService.Helpers;

namespace ADeeWu.HuoBi3J.MobileService.Controllers
{
    /// <summary>
    /// 分享现金抵扣券
    /// 有两种分享方式：分享给朋友使用，分享给朋友提高券值
    /// </summary>
    public class ShareController : ApiController
    {
        DataBase db = DataBase.Create();
        DAL.Coupons_CashWhenFee_Code codeDAL = new DAL.Coupons_CashWhenFee_Code ();
        DAL.Coupons_CashWhenFee_ShareFriend shareFriendDAL = new DAL.Coupons_CashWhenFee_ShareFriend();
        DAL.Coupons_CashWhenFee_ShareFriendLevel shareFriendLevelDAL = new DAL.Coupons_CashWhenFee_ShareFriendLevel();
        /// <summary>
        /// 我分享的抵扣券，包括分享给朋友使用的抵扣券、分享给朋友的提高券，使用ShareType区分
        /// </summary>
        /// <param name="userid">我的UserID</param>
        /// <returns>IsVaild确定抵扣券是否过期；通过ShareType确定进入不同的页面，ShareType: 1.分享券，2.提高券</returns>
        public IEnumerable<ShareTicket> GetMyShare(int userid)
        {
            var sql = string.Format(@"SELECT  code.*,share.ShareType, share.DateTime AS ShareTime FROM    dbo.Coupons_CashWhenFee_ShareFriend share , dbo.Coupons_CashWhenFee_Code code WHERE share.CodeID = code.ID AND code.UserID = {0}", userid);

            return GetShareTickets(db.Select(sql));
        }

        /// <summary>
        /// 朋友分享给我的券
        /// </summary>
        /// <param name="userid">我的UserID</param>
        /// <returns>分享券可以通过userid确定分享用户，提高券只统计次数，并取最大money为最后抵扣券金额；OriginalMoney抵扣券原始金额</returns>
        [Route("api/Share/Friend/{userid}")]
        public IEnumerable<ObtainShareTicket> GetFriendShare(int userid)
        {
            var sql = string.Format("SELECT  code.*, l.UserID AS MyUserID, l.DateTime AS ObtainTicketTime FROM dbo.Coupons_CashWhenFee_ShareFriendLog l ,dbo.Coupons_CashWhenFee_Code code WHERE   l.CodeID = code.ID AND l.UserID = {0}", userid);

            return GetObtainShareTickets(db.Select(sql));
        }

        /// <summary>
        /// 提高抵扣券的提高等级及当前所在位置
        /// </summary>
        /// <param name="codeid">券ID</param>
        /// <returns>http404：抵扣券不存在或不是提高券；http204：抵扣券没有设置等级</returns>
        [Route("api/Share/Friend/Level/{codeid}")]
        public CodeLevel GetFriendShareLevel(int codeid)
        {
            var shareFriend = shareFriendDAL.GetEntity(new string[] { "codeid", "sharetype" }, new object[] { codeid, 2 });
            if (shareFriend.IsNull()) throw new HttpResponseException(HttpStatusCode.NotFound);

            var code = codeDAL.GetEntity(shareFriend.CodeID.Value);
            if (code.IsNull()) throw new HttpResponseException(HttpStatusCode.NotFound);

            var levels = shareFriendLevelDAL.GetEntityList("money desc", new string[] { "userid" }, new object[] { code.SaleManUserID });
            if (levels.IsNull()) throw new HttpResponseException(HttpStatusCode.NoContent);

            return new CodeLevel { CurrentMoney = code.Money.Value, Levels = levels.ToList() };
        }

        /// <summary>
        /// 分享抵扣券
        /// </summary>
        /// <param name="userid">分享人</param>
        /// <param name="codeid">抵扣券ID</param>
        /// <param name="sharetype">分享类型</param>
        /// <returns>http400：抵扣券不是userid的；http409：抵扣券已分享；http403：分享失败；http200：分享成功，并返回分享链接</returns>
        public string Share(int userid, int codeid, int sharetype)
        {
            var code = codeDAL.GetEntity(new string[]{"id","userid"},new object[]{codeid,userid});
            if(code.IsNull()) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var shareFriend = shareFriendDAL.GetEntity(new string[] { "codeid" }, new object[] { codeid });
            if (shareFriend.IsNotNull()) throw new HttpResponseException(HttpStatusCode.Conflict);

            shareFriend = new Model.Coupons_CashWhenFee_ShareFriend
            {
                CodeID = codeid,
                DateTime = DateTime.Now,
                ShareType = sharetype
            };
            var shareFriendID = shareFriendDAL.Add(shareFriend);
            if (shareFriendID <= 0) throw new HttpResponseException(HttpStatusCode.Forbidden);

            return JsonConvert.SerializeObject(new { url = string.Format("{0}/share/{1}", BaseDataHelper.WebSite, code.ID) });
        }

        /// <summary>
        /// 抵扣券的分享链接
        /// </summary>
        /// <param name="codeid">抵扣券ID</param>
        /// <returns>返回抵扣券分享链接</returns>
        [Route("api/Share/Link/{codeid}")]
        public string GetShareLink(int codeid)
        {
            var sql = string.Format("SELECT Count(*) FROM dbo.Coupons_CashWhenFee_Code code, dbo.Coupons_CashWhenFee_ShareFriend s WHERE code.ID = s.CodeID AND code.ID = {0}", codeid);
            if (db.ExecuteScalar(sql).GetInt(-1) == -1)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return JsonConvert.SerializeObject(new { url = string.Format("{0}/share/{1}", BaseDataHelper.WebSite.TrimEnd('/'), codeid) });
        }

        /// <summary>
        /// dt转sharetickets
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<ShareTicket> GetShareTickets(DataTable dt)
        {
            var shareEntitys = new List<ShareTicket>();

            if (dt == null || dt.Rows.Count <= 0) return shareEntitys;

            foreach (DataRow row in dt.Rows)
            {
                shareEntitys.Add(new ShareTicket
                {
                    Count = row["Count"].GetInt(),
                    CreateTime = row["CreateTime"].GetDateTime(),
                    EndDate = row["EndDate"].GetDateTime(),
                    Fee = row["Fee"].GetDecimal(),
                    ID = row["ID"].GetInt(),
                    Money = row["Money"].GetDecimal(),
                    OriginalMoney = row["OriginalMoney"].GetDecimal(),
                    SaleManUserID = row["SaleManUserID"].GetInt(),
                    ShareTime = row["ShareTime"].GetDateTime(),
                    StartDate = row["StartDate"].GetDateTime(),
                    ShareType = row["ShareType"].GetInt(),
                    UseCount = row["UseCount"].GetInt(),
                    UserID = row["UserID"].GetInt(),
                });
            }

            return shareEntitys;
        }

        /// <summary>
        /// dt转obtainsharetickets
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<ObtainShareTicket> GetObtainShareTickets(DataTable dt)
        {
            var shareEntitys = new List<ObtainShareTicket>();

            if (dt == null || dt.Rows.Count <= 0) return shareEntitys;

            foreach (DataRow row in dt.Rows)
            {
                shareEntitys.Add(new ObtainShareTicket
                {
                    Count = row["Count"].GetInt(),
                    CreateTime = row["CreateTime"].GetDateTime(),
                    EndDate = row["EndDate"].GetDateTime(),
                    Fee = row["Fee"].GetDecimal(),
                    ID = row["ID"].GetInt(),
                    Money = row["Money"].GetDecimal(),
                    OriginalMoney = row["OriginalMoney"].GetDecimal(),
                    SaleManUserID = row["SaleManUserID"].GetInt(),
                    StartDate = row["StartDate"].GetDateTime(),
                    UseCount = row["UserCount"].GetInt(),
                    UserID = row["UserID"].GetInt(),
                    MyUserID = row["MyUserID"].GetInt(),
                    ObtainTicketTime = row["ObtainTicketTime"].GetDateTime(),
                });
            }

            return shareEntitys;
        }

        /// <summary>
        /// 分享抵扣券实体
        /// </summary>
        public class ShareTicket : Model.Coupons_CashWhenFee_Code
        {
            /// <summary>
            /// 分享时间
            /// </summary>
            public DateTime ShareTime { get; set; }

            /// <summary>
            /// 分享类型
            /// </summary>
            public int ShareType { get; set; }

            /// <summary>
            /// 是否无效
            /// </summary>
            public bool IsVaild
            {
                get
                {
                    return this.StartDate.HasValue && this.EndDate.HasValue && this.StartDate <= DateTime.Now && this.EndDate >= DateTime.Now;
                }
            }
        }

        /// <summary>
        /// 获得分享抵扣券实体
        /// </summary>
        public class ObtainShareTicket : Model.Coupons_CashWhenFee_Code
        {
            /// <summary>
            /// 我的UserID
            /// </summary>
            public int MyUserID { get; set; }

            /// <summary>
            /// 获得抵扣券时间
            /// </summary>
            public DateTime ObtainTicketTime { get; set; }

            /// <summary>
            /// 是否无效
            /// </summary>
            public bool IsVaild
            {
                get
                {
                    return this.StartDate.HasValue && this.EndDate.HasValue && this.StartDate <= DateTime.Now && this.EndDate >= DateTime.Now;
                }
            }
        }

        public class CodeLevel
        {
            /// <summary>
            /// 当前抵扣金额
            /// </summary>
            public decimal CurrentMoney { get; set; }
            /// <summary>
            /// 提升等级
            /// </summary>
            public List<Model.Coupons_CashWhenFee_ShareFriendLevel> Levels { get; set; }
        }
    }
}
