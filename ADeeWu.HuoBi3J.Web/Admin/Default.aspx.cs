using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ADeeWu.HuoBi3J.Web.Admin
{
    public partial class Default : PageBase
    {

        public override string PageID
        {
            get
            {
                return "000000";
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            this.LoginUser = UserSession.GetSession();
            if (this.LoginUser == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected string defaultUrl = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            defaultUrl = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request.QueryString["url"], "default.html");
        }
    }

   
}
