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
    public class PageBase : System.Web.UI.Page
    {
        private UserSession _LoginUser = null;
        /// <summary>
        /// 登陆的用户
        /// </summary>
        public UserSession LoginUser
        {
            get { return _LoginUser; }
            set { _LoginUser = value; }
        }

        public bool IsAdmin
        {
            get
            {
                return HttpContext.Current.Session["IsAdmin"] == null ? false : true;
            }
        }

        /// <summary>
        /// 当前页面的功能模块代码
        /// </summary>
        public virtual string FunctionCode
        {
            get { return ""; }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            LoginUser = UserSession.GetSession();
        }


    }
}
