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

namespace ADeeWu.HuoBi3J.Web.My.Corp.Shop.Products
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp_Shop
    {
        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;

        protected string name = string.Empty;
        protected long categoryID = -1;


        DAL.Shop_CPCategories dalPCategory = new ADeeWu.HuoBi3J.DAL.Shop_CPCategories();

        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetInt(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);

            if (!IsPostBack)//获取外部参数
            {
                name = WebUtility.GetRequestStr("name", "");
                categoryID = WebUtility.GetRequestLong("cid", -1);
                bindCategory();
                bindData();
            }
        }



        void bindCategory()
        {
            DataTable dtCateogry01 = dalPCategory.Select(string.Format("ShopID={0} and Depth=0", this.LoginUser.ShopID), "Sequence");
            DataTable dtCategory02 = dalPCategory.Select(string.Format("ShopID={0} and Depth=1", this.LoginUser.ShopID), "Sequence");
            DataSet ds = new DataSet();
            ds.Tables.Add(dtCateogry01);
            ds.Tables.Add(dtCategory02);
            DataRelation relation = new DataRelation("relation", dtCateogry01.Columns["ID"], dtCategory02.Columns["ParentID"], false);
            ds.Relations.Add(relation);

            this.ddlCPCategory.Items.Add(new ListItem("全部", "-1"));
            foreach (DataRow drMaster in dtCateogry01.Rows)
            {
                ListItem item = new ListItem(drMaster["Name"].ToString(), drMaster["ID"].ToString());
                this.ddlCPCategory.Items.Add(item);

                foreach (DataRow drSub in drMaster.GetChildRows("relation"))
                {
                    ListItem item02 = new ListItem("┠" + drSub["Name"].ToString(), drSub["ID"].ToString());
                    this.ddlCPCategory.Items.Add(item02);
                }
            }
            this.ddlCPCategory.SelectedValue = this.categoryID.ToString();
        }
        
        void bindData()
        {
            StringBuilder whereBulder = new StringBuilder();
            //builderWhere.Append("IsHidden=0 and CheckState=1");

            whereBulder.Append(" CorpID=@CorpID");
            db.Parameters.Append("@CorpID",LoginUser.CorpID );

            if (name != "")
            {
                whereBulder.Append(" and Name like @name");
                db.Parameters.Append("@name", string.Format("%{0}%", name));
                this.Pager1.AppendUrlParam("name", name);
                this.txtName.Text = name;
            }
            else
            {
                if (this.categoryID > 0)
                {
                    whereBulder.Append(" and exists(select id from Shop_PInCPCategories where CPCategoryID=@CategoryID and vw_Shop_Product_Details.ID=ProductID) ");
                    db.Parameters.Append("@CategoryID", categoryID);
                    this.Pager1.AppendUrlParam("cid", this.categoryID.ToString());
                    this.ddlCPCategory.SelectedValue = this.categoryID.ToString();
                }
            }

            

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Shop_Product_Details", "ID", whereBulder.ToString(), "Sequence DESC ");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;
            name = Utility.GetStr(this.txtName.Text, "");
            categoryID = Utility.GetLong(this.ddlCPCategory.SelectedValue, -1);
            bindData();
        }

        
    }
}
