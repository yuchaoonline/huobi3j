using ADeeWu.HuoBi3J.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Controls
{
    public partial class ucHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected string GetKeyword()
        {
            var keyword = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestStr("keyword", "");
            return string.IsNullOrWhiteSpace(keyword) ? "快餐" : keyword;
        }
    }
}