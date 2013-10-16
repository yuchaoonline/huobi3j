using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web
{
    public partial class MMyUser : System.Web.UI.MasterPage
    {
        public UserSession LoginUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            LoginUser = UserSession.GetSession();
        }
    }
}