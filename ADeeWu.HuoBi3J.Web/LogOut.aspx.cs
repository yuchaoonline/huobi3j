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
using System.Data.SqlClient;

namespace ADeeWu.HuoBi3J.Web
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            ADeeWu.HuoBi3J.Web.Class.UserSession.SaveSession(null);
            Session.Abandon();
            ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "注销成功!欢迎您再次回来!", "/");
            
        }
    }
}



