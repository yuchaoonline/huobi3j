using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;
using Newtonsoft.Json;

namespace ADeeWu.HuoBi3J.Web
{
    public partial class MobileLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                if (WebUtility.GetRequestStr("method", "") == "login")
                {
                    Response.ContentType = "text/plain";
                    Response.Write(Login());
                    Response.End();
                }
            }
        }

        private string Login()
        {
            var username = WebUtility.GetRequestStr("username", "");
            var password = WebUtility.GetRequestStr("password", "");
            if (string.IsNullOrWhiteSpace(username))
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "用户名不能为空！" });
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "密码不能为空！" });
            }

            Class.UserSession loginSession = Class.UserSession.Login(username, password, DateTime.Now);
            if (loginSession == null)
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "用户名或密码错误！" });
            }

            return JsonConvert.SerializeObject(new { statue = true });
        }
    }
}
