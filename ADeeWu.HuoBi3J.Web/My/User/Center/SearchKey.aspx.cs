using ADee.Project.LBS.BLL;
using ADee.Project.LBS.Common;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class SearchKey : PageBase_CircleSaleMan
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var keyword = WebUtility.GetRequestStr("keyword", "");
                var id = WebUtility.GetRequestInt("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowAndGoBack(this, "参数有误！");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    BandData(keyword,id);
                }

                BandKey(id);
            }
        }

        private void BandKey(int id)
        {
            var productPoi = new PoiBLL().Details<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>(id, ConfigHelper.GeoProductTableID);
            if (productPoi == null||productPoi.status!=0) return;

            var viewprice = new DAL.Key_ViewPrice().GetEntity("kid=" + productPoi.poi.KID);

            rpKey.DataSource = new List<object> { new { KName = productPoi.poi.KName, SelectType = productPoi.poi.SelectType, SelectPrice = productPoi.poi.SelectPrice, SelectSize = productPoi.poi.SelectSize, Count = viewprice.Count, Price = viewprice.Price } };
            rpKey.DataBind();
        }

        private void BandData(string keyword, int id)
        {
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            DataBase db = DataBase.Create();

            db.EnableRecordCount = true;
            var keys = db.Select("[key]", "name like '%" + keyword + "%'", "");

            rpResult.DataSource = keys;
            rpResult.DataBind();

            this.Pager1.AppendUrlParam("keyword", keyword);
            this.Pager1.AppendUrlParam("id", id.ToString());
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("searchkey.aspx?id={0}&keyword={1}", Request["id"], txtKeyword.Text), true);
        }
    }
}