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
using System.Data.SqlClient;
using System.Text;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Admin.Callings
{
    public partial class List : PageBase
    {

        public override string PageID
        {
            get
            {
                return "026003";
            }
        }

        DataBase db = DataBase.Create();
        protected int isHidden = -1;
        protected string name = string.Empty;
        protected string parentPath = string.Empty;
        protected int pageSize = 20;
        protected int pageIndex = 1;
        protected int isRecommend = -1;

        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", PageBase.DataList_PageSize);
            pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("page", 1);

            if (!IsPostBack)
            {
                this.name = WebUtility.GetRequestStr("name", "");
                this.isHidden = WebUtility.GetRequestInt("ishidden", -1);
                this.isRecommend = WebUtility.GetRequestInt("isrecommend", -1);

                if (this.syncSelectorCalling.HasSelected)
                {
                    for (int i = 0; i < this.syncSelectorCalling.Values.Length; i++)
                    {
                        string value = this.syncSelectorCalling.Values[i];
                        if (value != this.syncSelectorCalling.DefaultValue)
                        {
                            parentPath += string.Format("{0},", value);
                        }
                    }
                }
                else
                {
                    parentPath = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request["parentPath"]);
                }

                
                bindData();
            }

            
        }


        void bindData()
        {
            StringBuilder builderWhere = new StringBuilder();
            builderWhere.Append(" 1=1");
            if (isHidden > -1)
            {
                builderWhere.Append(" and IsHidden=@IsHidden");
                db.Parameters.Append("@IsHidden", isHidden);
                this.Pager1.AppendUrlParam("ishidden", isHidden.ToString());
                this.ddlIsHidden.SelectedValue = isHidden.ToString();
            }

            if (isRecommend > -1)
            {
                builderWhere.Append(" and IsRecommend=@IsRecommend");
                db.Parameters.Append("@IsRecommend", isRecommend);
                this.Pager1.AppendUrlParam("isrecommend", isRecommend.ToString());
                this.ddlIsRecommend.SelectedValue = isRecommend.ToString();
            }

            if (name != "")
            {
                builderWhere.Append(" and Name like @Name");
                db.Parameters.Append("@Name", string.Format("%{0}%", name));
                this.Pager1.AppendUrlParam("Name", name);
                this.txtTitle.Text = name;
            }

            if (parentPath != "")
            {
                if (!parentPath.EndsWith(","))
                {
                    parentPath += ",";
                }
                builderWhere.Append(" and ParentPath like @ParentPath");
                db.Parameters.Append("@ParentPath", string.Format("0,{0}%", parentPath));//e.g : 0,1,%
                this.Pager1.AppendUrlParam("parentPath", parentPath);
                this.syncSelectorCalling.Values = parentPath.Split(',');
            }


            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Callings", "ID", builderWhere.ToString(), " CreateTime asc");
            this.gvData.DataBind();

            this.Pager1.PageSize = pageSize;
            this.Pager1.PageIndex = pageIndex;
            this.Pager1.TotalRecords = Convert.ToInt32(db.RecordCount);
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pageIndex = 1;


            parentPath = string.Empty;
            for (int i = 0; i < this.syncSelectorCalling.Values.Length; i++)
            {
                string value = this.syncSelectorCalling.Values[i];
                if (value != this.syncSelectorCalling.DefaultValue)
                {
                    parentPath += string.Format("{0},", value);
                }
            }
           

            name = Utility.GetStr(Request["name"], this.txtTitle.Text, "", true);
            isHidden = Utility.GetInt(Request["ishidden"], this.ddlIsHidden.SelectedValue, -1);
            isRecommend = Utility.GetInt(Request["isrecommend"], this.ddlIsRecommend.SelectedValue, -1);
            bindData();
        }
    }
}
