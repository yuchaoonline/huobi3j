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

namespace ADeeWu.HuoBi3J.Web.Admin.CorpAgent.UserInCorps
{

    
    public partial class List : PageBase
    {


        public override string PageID
        {
            get
            {
                return "025003";
            }
        }

        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;
        string corpAgentRealName = string.Empty;
        string corpName = string.Empty;
        int checkState = -1;
        
        protected void Page_Load(object sender, EventArgs e)
        {            
            long pageSize = WebUtility.GetRequestLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = WebUtility.GetRequestLong("page", 1);

            if (!IsPostBack)
            {
                corpAgentRealName = WebUtility.GetRequestStr("corpAgentLoginName", "");
                corpName = WebUtility.GetRequestStr("corpName", "");
                checkState = WebUtility.GetRequestInt("checkState", -1);
                BindData();
            }           
        }

        void BindData()
        {
            StringBuilder builderWhere = new StringBuilder();

            if (corpAgentRealName.Length > 0)
            {
                builderWhere.Append(" and CorpAgentLoginName like @CorpAgentLoginName");
                db.Parameters.Append("@CorpAgentLoginName", string.Format("%{0}%", corpAgentRealName));
                this.Pager1.AppendUrlParam("corpAgentLoginName", corpAgentRealName);
                this.txtCorpAgentRealName.Text = corpAgentRealName;
            }

            if (corpName.Length > 0)
            {
                builderWhere.Append(" and CorpName like @CorpName");
                db.Parameters.Append("@CorpName", string.Format("%{0}%", corpName));
                this.Pager1.AppendUrlParam("corpName", corpName);
                this.txtCorpName.Text = corpName;
            }


            if (checkState > -1)
            {
                builderWhere.Append(" and CheckState=@CheckState");
                db.Parameters.Append("@CheckState", checkState);
                this.Pager1.AppendUrlParam("checkState", checkState.ToString());
            }
            
            string where = "" + (
                   (builderWhere.Length > 0) ? builderWhere.ToString().Substring(4) : string.Empty
           );


            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Admin_CA_QuaAgentInCorps", "id", where, "CreateTime desc");
            this.gvData.DataBind();
            this.Pager1.PageSize = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageSize, 0);
            this.Pager1.PageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageIndex, 0);
            this.Pager1.TotalRecords = ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RecordCount, 0);
            db.EnableRecordCount = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            this.pageIndex = 1;
            corpAgentRealName = Utility.GetStr(Request.QueryString["corpAgentLoginName"], this.txtCorpAgentRealName.Text, "", true);
            corpName = Utility.GetStr(Request.QueryString["corpName"], this.txtCorpName.Text, "", true);
            checkState = Utility.GetInt(Request.QueryString["checkState"], this.ddlCheckState.SelectedValue, -1);
            BindData();
        }
    }
}
