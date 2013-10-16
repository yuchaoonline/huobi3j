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

namespace ADeeWu.HuoBi3J.Web.Admin.Job_Categories
{
    public partial class List : PageBase
    {

        public override string PageID
        {
            get
            {
                return "016003";
            }
        }

        DataBase db = DataBase.Create();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            int pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", PageBase.DataList_PageSize);
            int pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("page", 1);


            string name = ADeeWu.HuoBi3J.Libary.Utility.GetStr(this.txtTitle.Text, Request.QueryString["name"], "", true);
            string parentPath = string.Empty;
            if (this.syncSelectorJobCategory.HasSelected)
            {
                for (int i = 0; i < this.syncSelectorJobCategory.Values.Length; i++)
                {
                    string value = this.syncSelectorJobCategory.Values[i];
                    if (value != this.syncSelectorJobCategory.DefaultValue)
                    {
                        parentPath += string.Format("{0},",value);
                    }
                }
            }
            else
            {
                parentPath = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request["parentPath"]);
            }

                

            int isHidden = ADeeWu.HuoBi3J.Libary.Utility.GetInt(ddlIsHidden.SelectedValue, Request.QueryString["ishidden"], -1);

            StringBuilder builderWhere = new StringBuilder();
            builderWhere.Append(" 1=1");
            if (isHidden > 0)
            {
                builderWhere.Append(" and IsHidden=@IsHidden");
                db.Parameters.Append("@IsHidden", isHidden);
                this.Pager1.AppendUrlParam("ishidden", isHidden.ToString());
                this.ddlIsHidden.SelectedValue = isHidden.ToString();
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
                this.syncSelectorJobCategory.Values = parentPath.Split(',');
            }


            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex,"vw_Job_Categories","ID",builderWhere.ToString(), " CreateTime asc");
            this.gvData.DataBind();
            
            this.Pager1.PageSize = pageSize;
            this.Pager1.PageIndex = pageIndex;
            this.Pager1.TotalRecords = Convert.ToInt32(db.RecordCount);
        }
    }
}
