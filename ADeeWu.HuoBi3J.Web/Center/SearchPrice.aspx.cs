using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class SearchPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strKeyword = WebUtility.GetRequestStr("keyword", "");
                if (string.IsNullOrWhiteSpace(strKeyword)) return;
                Search(strKeyword);
            }
        }

        private void Search(string Keyword)
        {
            if (!Utility.IsNumeric(Keyword))
            {
                WebUtility.ShowMsg("输入的文字应为价格！");
                return;
            }

            var price = Utility.GetDecimal(Keyword, 0);
            var db = DataBase.Create();
            db.Parameters.Append("price", price);
            rpResult.DataSource = db.Select("vw_Key_Product", "price=@price", "");
            rpResult.DataBind();
        }
    }
}