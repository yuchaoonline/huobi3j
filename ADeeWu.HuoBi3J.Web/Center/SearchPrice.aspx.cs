using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;
using ADeeWu.HuoBi3J.Web.Class;
using System.Linq;
using Newtonsoft.Json;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class SearchPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strKeyword = WebUtility.GetRequestStr("keyword", "");
                if (string.IsNullOrWhiteSpace(strKeyword))
                    Response.Redirect("SearchPrice.aspx?keyword=快餐", true);
            }
        }
    }
}