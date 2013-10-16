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
    public partial class Loginout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ADeeWu.HuoBi3J.Web.Admin.UserSession.SaveSession(null);
            HttpContext.Current.Session.Remove("IsAdmin");
            ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("注销成功!");
        }
    }
}
