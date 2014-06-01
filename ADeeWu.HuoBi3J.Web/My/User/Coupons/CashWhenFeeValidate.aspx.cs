using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.Coupons
{
    public partial class CashWhenFeeValidate : System.Web.UI.Page
    {
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var code = WebUtility.GetRequestStr("code", "");
                if (!string.IsNullOrWhiteSpace(code)) BandData(code);
            }
        }

        private void BandData(string code)
        {
            var list = db.Select("vw_Coupons_CashWhenFee_UserTicket", string.Format("code= '{0}'", code), "money desc");
            if (list == null || list.Rows.Count <= 0) return;

            rpResult.DataSource = list;
            rpResult.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("CashWhenFeeValidate.aspx?code=" + HttpUtility.UrlEncode(txtCode.Text), true);
        }
    }
}