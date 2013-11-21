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
    public partial class M_Details : System.Web.UI.Page
    {
        DataBase db = DataBase.Create();
        protected void Page_Load(object sender, EventArgs e)
        {
            BandData();
        }

        private void BandData()
        {
            var id = WebUtility.GetRequestInt("id", 0);
            if (id == 0) return;

            var product = db.Select("vw_key_product", "id = " + id, "price asc");
            rpProduct.DataSource = product;
            rpProduct.DataBind();
        }

        protected void rpProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var rpOtherPrice = (Repeater)e.Item.FindControl("rpOtherPrice");
            var datarowview = (DataRowView)e.Item.DataItem;
            var userid = Utility.GetInt(datarowview["createuserid"], 0);

            rpOtherPrice.DataSource = db.Select(string.Format("select top 10 * from vw_key_product where createuserid = {0} and pname='{1}' and cname='{2}' order by price asc", userid, AccountHelper.Province, AccountHelper.City));
            rpOtherPrice.DataBind();
        }

        public string GetDecimal(object obj, int length)
        {
            return decimal.Round(Utility.GetDecimal(obj, 0), length).ToString();
        }
    }
}