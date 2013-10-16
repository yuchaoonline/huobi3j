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
using ADeeWu.HuoBi3J.Libary;
using System.IO;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Shop.ProductCategories
{
    public partial class Del : Class.PageBase_MyCorp_Shop 
    {

        DAL.Shop_ProductCategories dal = new ADeeWu.HuoBi3J.DAL.Shop_ProductCategories();
        DAL.Shop_PInCPCategories dalPInCPCate = new ADeeWu.HuoBi3J.DAL.Shop_PInCPCategories();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            string IDString = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request["id"]);

            if (IDString.IndexOf(",") > -1)
            {
                foreach (string s in IDString.Split(','))
                {
                    long id = ADeeWu.HuoBi3J.Libary.Utility.GetLong(s, 0);
                    if (id > 0)
                    {                        
                        //删除产品分类信息
                        dal.Delete("id=" + id + " and ShopID=" + this.LoginUser.ShopID);
                        
                        //删除所有商品与商品自定义分类的关系记录
                        dalPInCPCate.Delete(string.Format("ShopID={0} and CPCategoryID={1}", this.LoginUser.ShopID, id));
                    }
                }
            }
            else
            {
                long id = ADeeWu.HuoBi3J.Libary.Utility.GetLong(IDString, 0);
                if (id > 0)
                {
                    //删除产品分类信息
                    dal.Delete("id=" + id + " and ShopID=" + this.LoginUser.ShopID);

                    //删除所有商品与商品自定义分类的关系记录
                    dalPInCPCate.Delete(string.Format("ShopID={0} and CPCategoryID={1}", this.LoginUser.ShopID, id));
                }
            }
            WebUtility.ShowMsg(this, "操作成功!", ".");

        }
    }
}
