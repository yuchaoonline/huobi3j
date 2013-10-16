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
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ADeeWu.HuoBi3J.Web.Admin.Users
{
    public partial class List : PageBase
    {
        ADeeWu.HuoBi3J.DAL.Users dal = new ADeeWu.HuoBi3J.DAL.Users();


        public override string PageID
        {
            get
            {
                return "001003";
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", PageBase.DataList_PageSize);
            int pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestInt("page", 1, true);

            string uin = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("uin", "", true);
            string name = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("name", "", true);
            string loginName = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("loginname", "", true);
            
            StringBuilder whereBuilder = new StringBuilder();

            if (uin.Length > 0)
            {
                whereBuilder.Append(" and UIN like @UIN");
                dal.Parameters.Append(
                    "@UIN",
                    string.Format("%{0}%", uin)
                    );
                this.Pager1.AppendUrlParam("uin", uin);
            }

            if(name.Length>0){
                whereBuilder.Append(" and Name like @Name");
                dal.Parameters.Append(
                    "@Name",
                    string.Format("%{0}%",name)
                    );
                this.Pager1.AppendUrlParam("name",name);
            }

             if(loginName.Length>0){
                whereBuilder.Append(" and loginName like @loginName");
                dal.Parameters.Append(
                    "@loginName",
                    string.Format("%{0}%",loginName)
                    );
                this.Pager1.AppendUrlParam("loginName",loginName);
            }

             string where = whereBuilder.Length > 0 ? whereBuilder.ToString().Substring(4) : string.Empty;
             dal.EnableRecordCount = true;
             this.gvData.DataSource = dal.Select(pageSize, pageIndex, where, "");
             this.gvData.DataBind();
             this.Pager1.PageSize = pageSize;
             this.Pager1.PageIndex = pageIndex;
             this.Pager1.TotalRecords = (int)dal.RecordCount;
            
        }
    }
}
