using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ADeeWu.HuoBi3J.Web.Class
{
    /// <summary>
    /// 个人用户后台页面基类
    /// </summary>
    public class PageBase_MyUser : PageBase
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            
            if (this.LoginUser == null)
            {
                Response.Redirect("/login.aspx?timeout=true&url=" + Server.UrlEncode(Request.Url.ToString()));
            }
        }

        /// <summary>
        /// 获取当前实际业务相关的UserID
        /// </summary>
        /// <returns></returns>
        protected long GetRealBusinessUserID()
        {
            if (this.LoginUser == null) return 0;
            return this.LoginUser.UserID;
        }
    }
}
