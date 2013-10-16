using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Web.Class;

namespace ADeeWu.HuoBi3J.Web
{
    public partial class Refresh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TaskHelper.DoCenterRefresh();
                TaskHelper.DoCenterAttentionKey();
                TaskHelper.DoCenterPayForParttime();

                File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory + "/log/refresh.txt", new string[] { DateTime.Now.ToString() });
            }
        }
    }
}