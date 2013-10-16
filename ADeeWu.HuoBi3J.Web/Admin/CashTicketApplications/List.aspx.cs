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
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.CashTicketApplications
{
    public partial class List : PageBase
    {
        ADeeWu.HuoBi3J.DAL.CT_CashTicketApplications dal = new ADeeWu.HuoBi3J.DAL.CT_CashTicketApplications();

        DataBase db = DataBase.Create();
        
        public override string PageID
        {
            get
            {
                return "004003";
            }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlInt("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["page"], Request.Form["page"], 1);

            string loginName = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("key", "", true);

           

            if (loginName != "")
            {
                db.EnableRecordCount = true;
                db.Parameters.Append("@LoginName", string.Format("%{0}%", loginName));
                this.gvData.DataSource = db.Select(pageSize, pageIndex,
                     "vw_CT_CashTicketApplications", "ID", "LoginName like @LoginName", "CheckState asc"
                );
                this.Pager1.AppendUrlParam("key", loginName);
                db.EnableRecordCount = false;
            }
            else
            {
                db.EnableRecordCount = true;
                this.gvData.DataSource = db.Select(pageSize, pageIndex,
                     "vw_CT_CashTicketApplications", "ID", "", "CheckState asc"
                );
                db.EnableRecordCount = false;
            }


            this.key.Value = loginName;

            this.gvData.DataBind();
            this.Pager1.PageSize =(int)pageSize;
            this.Pager1.PageIndex =(int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
            
            
        }

    }
}
