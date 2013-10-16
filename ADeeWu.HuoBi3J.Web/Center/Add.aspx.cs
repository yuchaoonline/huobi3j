using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class Add : System.Web.UI.Page
    {
        public int UserID
        {
            get
            {
                UserSession session = UserSession.GetSession();
                if (session == null) return 0;
                return Utility.GetInt(session.UserID, 0);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
    }
}