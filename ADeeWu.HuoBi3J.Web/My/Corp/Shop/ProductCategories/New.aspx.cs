﻿using System;
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
    public partial class New : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp_Shop
    {
        DataBase db = DataBase.Create();
        DAL.Shop_CPCategories dal = new ADeeWu.HuoBi3J.DAL.Shop_CPCategories();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//获取外部参数
            {
                bindData();
            }
           
        }

        void bindData()
        {
            DataTable dtCategory01=  dal.Select("Depth=0 and ShopID=" + this.LoginUser.ShopID, "Sequence");
            foreach (DataRow row in dtCategory01.Rows)
            {
                this.ddlCategory.Items.Add(new ListItem(row["Name"].ToString(), row["ID"].ToString()));
                long categoryID = Utility.GetLong(row["id"], 0);
                //DataTable dtCategory02 = dal.Select("Depth=1 and ShopID=" + this.LoginUser.ShopID + " and ParentID=" + categoryID, "Sequence");
                //foreach (DataRow row2 in dtCategory02.Rows)
                //{
                //    this.ddlCategory.Items.Add(new ListItem(row2["Name"].ToString(), row2["ID"].ToString()));
                //}
            }
            this.ddlCategory.Items.Insert(0, new ListItem("顶级分类", "0"));

            this.txtSequence.Text = (Utility.GetLong(db.ExecuteScalar("select count(id) from Shop_CPCategories where ShopID=" + this.LoginUser.ShopID), 0) + 1).ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = this.txtName.Text.Trim();
            int sequence = Utility.GetInt(this.txtSequence.Text, 0);
            long parentID = Utility.GetLong(ddlCategory.SelectedValue, 0);

            if (name.Length == 0)
            {
                WebUtility.ShowMsg(this, "请填写分类名称！");
                return;
            }

       

            Model.Shop_CPCategories ent = new ADeeWu.HuoBi3J.Model.Shop_CPCategories();
            ent.ShopID = this.LoginUser.ShopID;
            ent.Name = name;
            ent.Sequence = sequence;
            ent.ParentID = parentID;

            if (parentID > 0)
            {
                ent.Depth = 1;
            }
            else
            {
                ent.Depth = 0;
            }

            if (dal.Add(ent) > 0)
            {
                WebUtility.ShowMsg(this, "操作成功！", ".");
            }
            else
            {
                WebUtility.ShowMsg(this, "操作失败，请稍后再试！或与我们联系！");
            }
        }

      
        
    }
}
