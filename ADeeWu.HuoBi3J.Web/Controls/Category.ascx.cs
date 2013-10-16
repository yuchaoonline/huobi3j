using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using System.Data;

namespace ADeeWu.HuoBi3J.Web.Controls
{
    public partial class Category : System.Web.UI.UserControl
    {

        DAL.Shop_ProductCategories dalProductCates = new ADeeWu.HuoBi3J.DAL.Shop_ProductCategories();

        protected void Page_Load(object sender, EventArgs e)
        {
            //bindCategoryNav();
        }


        protected void bindCategoryNav()
        {
            this.rpCateNavData01.DataSource = this.dalProductCates.Select("ParentID=1", "Sequence asc");
            this.rpCateNavData01.DataBind();

            this.rpCateNavData02.DataSource = this.dalProductCates.Select("ParentID=2927", "Sequence asc");
            this.rpCateNavData02.DataBind();

            this.rpCateNavData03.DataSource = this.dalProductCates.Select("ParentID=5210", "Sequence asc");
            this.rpCateNavData03.DataBind();
        }

        protected void rpCateNavSub_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rpSub = e.Item.FindControl("rpSub") as Repeater;
            DataRowView dr = e.Item.DataItem as DataRowView;
            long id = Utility.GetLong(dr["ID"], 0);
            rpSub.DataSource = this.dalProductCates.Select("ParentID=" + id, "Sequence asc");
            rpSub.DataBind();
        }
    }
}