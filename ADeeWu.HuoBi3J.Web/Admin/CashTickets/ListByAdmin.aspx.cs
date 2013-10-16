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

namespace ADeeWu.HuoBi3J.Web.Admin.CashTickets
{
    public partial class ListByAdmin : PageBase
    {

        public override string PageID
        {
            get
            {
                return "003013";
            }
        }

        ADeeWu.HuoBi3J.DAL.Admin_Users dalAdmins = new ADeeWu.HuoBi3J.DAL.Admin_Users();
        DataBase db = DataBase.Create();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.adminid.DataSource = dalAdmins.Select(-1, -1);
                this.adminid.DataTextField = "loginName";
                this.adminid.DataValueField = "id";
                this.adminid.DataBind();
                this.adminid.Items.Insert(0, new ListItem("所有", "-1"));
            }
            
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);

            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestLong("page", 1, true);
          
            string corpName = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestStr("corp","",true).Trim();

            long adminUserID = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestLong("adminid", -1, true);
            
            int checkState = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestInt("state", -1, true);
           
            StringBuilder builderWhere = new StringBuilder();


            if (adminUserID > -1)
            {
                builderWhere.Append(" and AdminUserID=@AdminUserID");
                db.Parameters.Append("@AdminUserID", adminUserID);
                this.Pager1.AppendUrlParam("adminid", adminUserID.ToString());
            }


            if (corpName != "")
            {
                builderWhere.Append(" and CorpName like @CorpName");
                db.Parameters.Append("@CorpName", string.Format("%{0}%", corpName));
                this.Pager1.AppendUrlParam("corp", corpName);
            }

           

            if (checkState > -1)
            {
                builderWhere.Append(" and CheckState=@CheckState");
                db.Parameters.Append("@CheckState", checkState);
                this.Pager1.AppendUrlParam("state", checkState.ToString());
            }

            string where = " 1=1 " + (
                    (builderWhere.Length > 0) ? builderWhere.ToString().Substring(1) : string.Empty
            );

            this.adminid.Value = adminUserID.ToString();
            this.corp.Value = corpName;
            this.state.Value = checkState.ToString();

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CT_CashTickets", "id", where, "CreateTime desc");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
            db.EnableRecordCount = false;

            this.litNumOfCashTickets.Text = db.RecordCount.ToString();
        }
    }
}
