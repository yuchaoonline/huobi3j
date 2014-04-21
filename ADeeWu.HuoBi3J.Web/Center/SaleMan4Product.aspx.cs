using ADee.Project.LBS.BLL;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.WebUI;
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
                rpResult.DataSource = db.Select("vw_Key_CircleSaleMan", "userid = " + userid, "");
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

            var pageIndex = WebUtility.GetRequestInt("page", 1);
            var pageSize = Utility.GetInt(Request["pagesize"], 20, 5, 40);
            var userid = WebUtility.GetRequestInt("userid", 0);

            var pois = new GeoSearchBLL().Local<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductContent>(
                ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID,
                "",
                AccountHelper.City,
                pageIndex - 1,
                pageSize,
                "",
                "Price:1",
                string.Format("CreateUserID:[{0}]", userid));
            rpOtherPrice.DataSource = pois.contents;
            rpOtherPrice.DataBind();

            var Pager1 = (Pager3)e.Item.FindControl("Pager1");
            if (Pager1 == null) return;
            Pager1.AppendUrlParam("userid", userid.ToString());
            Pager1.PageSize = (int)pageSize;
            Pager1.PageIndex = (int)pageIndex;
            Pager1.TotalRecords = (int)pois.total;
        }
    }
}