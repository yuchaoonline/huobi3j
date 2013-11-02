using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class SaleMan4Product : System.Web.UI.Page
    {
        DataBase db = DataBase.Create();
        long pageIndex = 0;
        long pageSize = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = WebUtility.GetRequestLong("page", 1);
            pageSize = Utility.GetLong(Request["pagesize"], 10, 5, 40);

            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData()
        {
            var userid = WebUtility.GetRequestInt("userid", 0);
            if (userid > 0)
            {
                rpResult.DataSource = db.Select("vw_CircleSaleMan", "userid = " + userid, "");
                rpResult.DataBind();
            }
        }

        public string GetDecimal(object obj, int length)
        {
            return decimal.Round(Utility.GetDecimal(obj, 0), length).ToString();
        }

        protected void rpResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var rpOtherPrice = (Repeater)e.Item.FindControl("rpOtherPrice");
            var datarowview = (DataRowView)e.Item.DataItem;
            var userid = Utility.GetInt(datarowview["userid"], 0);

            rpOtherPrice.DataSource = db.Select("vw_key_product", string.Format("createuserid = {0} and pname='{1}' and cname='{2}'", userid, AccountHelper.Province, AccountHelper.City), "price asc");
            rpOtherPrice.DataBind();
        }
    }
}