using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.ProductCategories
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp_Shop
    {


        DAL.Shop_CPCategories dal = new ADeeWu.HuoBi3J.DAL.Shop_CPCategories();
        protected DataBase db = DataBase.Create();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//获取外部参数
            {
                bindData();
            }
           
        }

        void bindData()
        {
            
            this.gvData.DataSource = dal.Select("ShopID=" + this.LoginUser.ShopID, "Sequence");
            this.gvData.DataBind();
        }

        protected int countItems(long categoryID)
        {
            return Utility.GetInt(
                    db.ExecuteScalar(
                    "select count(*) from Shop_PInCPCategories where ShopID={0} and CPCategoryID={1}",
                    this.LoginUser.ShopID, categoryID)
                , 0);
        }

        
    }
}
