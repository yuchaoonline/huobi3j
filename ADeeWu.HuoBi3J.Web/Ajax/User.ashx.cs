using System;
using System.Collections.Generic;
using System.Web;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.Web.Class;
using System.Web.SessionState;
using ADeeWu.HuoBi3J.SQL;
using Newtonsoft.Json;

namespace ADeeWu.HuoBi3J.Web.Ajax
{
    /// <summary>
    /// User 的摘要说明
    /// </summary>
    public class User : IHttpHandler, IRequiresSessionState, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var method = WebUtility.GetRequestStr("method", "");
            var result = "";
            switch (method.ToLower())
            {
                case "islogin": { result = IsLogin(); }; break;
                case "issaleman": { result = IsSaleMan(); }; break;
                case "getsaleman": { result = GetSaleMan(); }; break;
                default: { result = "something is error!"; }; break;
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

        private string IsLogin()
        {
            var uid = UserSession.GetSession() == null ? 0 : UserSession.GetSession().UserID;
            if (uid <= 0) return JsonConvert.SerializeObject(new { Statue = false });

            return JsonConvert.SerializeObject(new { Statue = true });
        }

        #region SaleMan
        private string IsSaleMan()
        {
            return JsonConvert.SerializeObject(new { statue = SaleManSession.IsSaleMan });
        }

        private string GetSaleMan()
        {
            var uid = WebUtility.GetRequestInt("uid", -1);
            if (uid == -1) return JsonConvert.SerializeObject(new { Statue = false });

            var db = DataBase.Create();
            db.Parameters.Append("uid", uid);
            var salemans = db.Select("vw_circlesaleman", "userid=@uid", "");
            if (salemans == null || salemans.Rows.Count <= 0) return JsonConvert.SerializeObject(new { Statue = false, msg = "无此即时业务员" });

            var saleman = salemans.Rows[0];

            return JsonConvert.SerializeObject(new
            {
                statue = true,
                id = uid,
                name = Utility.GetStr(saleman["name"], ""),
                loginname = Utility.GetStr(saleman["loginname"], ""),
                qq = Utility.GetStr(saleman["qq"], ""),
                phone = Utility.GetStr(saleman["phone"], ""),
                companyname = Utility.GetStr(saleman["companyname"], ""),
                companyaddress = Utility.GetStr(saleman["companyaddress"], ""),
                checkstate = Utility.GetInt(saleman["checkstate"], -1),
                cretatime = Utility.GetStr(saleman["createtime"], ""),
                memo = Utility.GetStr(saleman["memo"], ""),
                job = Utility.GetStr(saleman["job"], ""),
                positionx = Utility.GetStr(saleman["positionx"], ""),
                positiony = Utility.GetStr(saleman["positiony"], "")
            });
        } 
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}