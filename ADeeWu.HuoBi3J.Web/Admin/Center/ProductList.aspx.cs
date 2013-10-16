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
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.Web.Class;
using System.IO;

namespace ADeeWu.HuoBi3J.Web.Admin.Center
{
    public partial class ProductList : PageBase
    {

        public override string PageID
        {
            get
            {
                return "009011";
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var method = WebUtility.GetRequestStr("method", "");
                if (method == "delete")
                    Delete();
                else
                    BandData();
            }
        }

        private void BandData()
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            var db = new DAL.Center_Products();
            db.EnableRecordCount = true;
            this.rpResultList.DataSource = db.Select(pageSize, pageIndex);
            this.rpResultList.DataBind();

            this.Pager1.PageSize = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageSize, 0);
            this.Pager1.PageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageIndex, 0);
            this.Pager1.TotalRecords = ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RecordCount, 0);
        }

        private void Delete()
        {
            var id = WebUtility.GetRequestInt("id", -1);
            if (id == -1)
            {
                WebUtility.ShowAndGoBack(this, "参数错误！");
                return;
            }

            var db = new DAL.Center_Products();
            var ent = db.GetEntity(id);
            if (db.Delete(id) > 0)
            {
                var root = Request.MapPath("/");
                try
                {
                    File.Delete(root + ent.Picture);
                }
                catch
                {

                }

                WebUtility.ShowMsg(this, "删除成功！", "ProductList.aspx");
                return;
            }
            else
            {
                WebUtility.ShowMsg(this, "删除失败，请重试！", "ProductList.aspx");
                return;
            }
        }

        /// <summary>
        /// 绑定显示的产品分类
        /// </summary>
        public string bindCategory(object _categoryId)
        {
            var ProductCategory = "";
            var categoryId = Utility.GetLong(_categoryId, -1);
            if (categoryId == -1) return ProductCategory;

            DAL.Shop_ProductCategories dalPCategories = new ADeeWu.HuoBi3J.DAL.Shop_ProductCategories();
            Model.Shop_ProductCategories entPCate = dalPCategories.GetEntity(categoryId);

            if (entPCate == null) return ProductCategory;
            if (entPCate.Depth <= 0)
            {
                ProductCategory = entPCate.Name;
                return ProductCategory;
            }

            StringBuilder whereBuilder = new StringBuilder();
            foreach (string s in entPCate.ParentPath.Split(','))
            {
                long parentId = Utility.GetLong(s, 0);
                if (parentId > 0)
                {
                    whereBuilder.Append(" or ID=" + parentId);
                }
            }
            if (whereBuilder.Length > 0)
            {
                DataTable dt = dalPCategories.Select(whereBuilder.ToString().Substring(4), "Depth asc");
                if (dt.Rows.Count == 0)
                {
                    ProductCategory = entPCate.Name;
                }
                else
                {
                    string[] categoryNames = new string[dt.Rows.Count + 1];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        categoryNames[i] = dt.Rows[i]["Name"].ToString();
                    }
                    categoryNames[categoryNames.Length - 1] = entPCate.Name;
                    ProductCategory = string.Join(" &gt; ", categoryNames);
                }
            }

            return ProductCategory;
        }
    }
}
