using ADee.Project.LBS.BLL;
using ADee.Project.LBS.Entity;
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
    public partial class Details : System.Web.UI.Page
    {
        DataBase db = DataBase.Create();
        DAL.Corporations corDAL = new DAL.Corporations();
        PoiBLL poiBLL = new PoiBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
                AddClickCount();
            }
        }

        private void BandData()
        {
            var id = WebUtility.GetRequestInt("id", 0);
            if (id == 0) return;

            var product = poiBLL.Details<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>(id, ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID).poi;

            rpResult.DataSource = new List<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi> { product };
            rpResult.DataBind();
        }

        private void AddClickCount()
        {
            try
            {
                var id = WebUtility.GetRequestInt("id", 0);
                if (id == 0) return;

                new DAL.Common_Count_Click().Add(new Model.Common_Count_Click
                {
                    CreateDate = DateTime.Now,
                    DataID = id,
                    DataType = "center_product",
                    IP = Request.UserHostAddress,
                });
            }
            catch
            {

            }
        }

        public string GetDecimal(object obj, int length)
        {
            return decimal.Round(Utility.GetDecimal(obj, 0), length).ToString();
        }

        public string Decode(object obj)
        {
            if (obj == null) return "";
            if (string.IsNullOrWhiteSpace(obj.ToString())) return "";
            return HttpUtility.HtmlDecode(obj.ToString());
        }

        protected void rpResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var rpOtherPrice = (Repeater)e.Item.FindControl("rpOtherPrice");
            var poi = (ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi)e.Item.DataItem;
            if (poi == null) return;

            rpOtherPrice.DataSource = new GeoSearchBLL().Local<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductContent>(
                ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID, 
                "", 
                AccountHelper.City, 
                0, 
                20, 
                "", 
                "Price:1", 
                string.Format("CreateUserID:[{0}]", poi.CreateUserID)).contents;
            rpOtherPrice.DataBind();
        }
    }
}