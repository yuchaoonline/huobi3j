using ADee.Project.LBS.BLL;
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
            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData()
        {
            var id = WebUtility.GetRequestInt("id", 0);
            if (id == 0) return;

            var product =new PoiBLL().Details<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>(id, ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID).poi;

            rpProduct.DataSource = new List<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi> { product };
            rpProduct.DataBind();

            AddClickCount(product.KID);
        }

        public string Decode(object obj)
        {
            if (obj == null) return "";
            if (string.IsNullOrWhiteSpace(obj.ToString())) return "";
            return HttpUtility.HtmlDecode(obj.ToString());
        }

        private void AddClickCount(int kid)
        {
            Details details = new Details();
            details.AddClickCount(kid);
        }

        protected void rpProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var rpOtherPrice = (Repeater)e.Item.FindControl("rpOtherPrice");
            var poi = (ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi)e.Item.DataItem;
            if (poi == null) return;

            rpOtherPrice.DataSource = new GeoSearchBLL().Local<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductContent>(ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID, "", "", 0, 10, "", "Price:1", string.Format("CreateUserID:[{0}]", poi.CreateUserID)).contents;
            rpOtherPrice.DataBind();
        }

        public string GetDecimal(object obj, int length)
        {
            return decimal.Round(Utility.GetDecimal(obj, 0), length).ToString();
        }
    }
}