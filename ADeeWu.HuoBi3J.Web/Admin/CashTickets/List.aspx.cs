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
    public partial class List : PageBase
    {

        public override string PageID
        {
            get
            {
                return "003003";
            }
        }


        DataBase db = DataBase.Create();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["page"], Request.Form["page"], 1);
            string corpName = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request.QueryString["corp"], Request.Form["corp"], "", true);
            string serialNum = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request.QueryString["serialNum"], Request.Form["serialNum"], "", true);

            this.ddlCorp.DataSource = db.Select("vw_CT_PartnerCorps", "CheckState=1", "CreateTime desc");
            this.ddlCorp.DataTextField = "CorpName";
            this.ddlCorp.DataValueField = "CorpID";
            this.ddlCorp.DataBind();

            int state = ADeeWu.HuoBi3J.Libary.Utility.GetInt(Request.QueryString["state"], Request.Form["state"], -1);
           
            StringBuilder builderWhere = new StringBuilder();
            
            if (corpName != "")
            {
                builderWhere.Append(" and CorpName like @CorpName");
                db.Parameters.Append("@CorpName", string.Format("%{0}%", corpName));
                this.Pager1.AppendUrlParam("corp", corpName);
            }
            if (serialNum != "")
            {
                builderWhere.Append(" and SerialNum like @SerialNum");
                db.Parameters.Append("@SerialNum", string.Format("%{0}%", serialNum));
                this.Pager1.AppendUrlParam("SerialNum", serialNum);
            }


            if (state > -1)
            {
                builderWhere.Append(" and CheckState=@CheckState");
                db.Parameters.Append("@CheckState", state);
                this.Pager1.AppendUrlParam("state", state.ToString());
            }

            string where = " 1=1 " + (
                    (builderWhere.Length > 0) ? builderWhere.ToString().Substring(1) : string.Empty
            );

            this.corp.Value = corpName;
            this.serialNum.Value = serialNum;
            this.state.Value = state.ToString();

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CT_CashTickets", "id", where, "CreateTime desc");
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
            db.EnableRecordCount = false;
            
        }
    }
}
