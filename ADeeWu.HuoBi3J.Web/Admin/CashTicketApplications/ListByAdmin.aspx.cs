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
using System.Text;
using System.Collections.Generic;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.CashTicketApplications
{


    public partial class ListByAdmin : PageBase
    {
        
        public override string PageID
        {
            get
            {
                return "004013";
            }
        }

        ADeeWu.HuoBi3J.DAL.CT_CashTicketApplications dalApplications = new ADeeWu.HuoBi3J.DAL.CT_CashTicketApplications();
        ADeeWu.HuoBi3J.DAL.Admin_Users dalAdmins = new ADeeWu.HuoBi3J.DAL.Admin_Users();
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.adminid.DataSource = dalAdmins.Select("", "");
                this.adminid.DataValueField = "ID";
                this.adminid.DataTextField = "LoginName";
                this.adminid.DataBind();
                this.adminid.Items.Insert(0, new ListItem("所有", "-1"));

                //this.txtStartDate.MinYear = DateTime.Now.Year;
                //this.txtStartDate.MaxYear = DateTime.Now.Year;
            }

            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.UpdateRequestInt("pagesize", PageBase.DataList_PageSize,true);
            long pageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["page"], Request.Form["page"], 1);

            long adminUserID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(Request.QueryString["adminid"], Request.Form["adminid"], 0);

            string corpName = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request.QueryString["corpName"], Request.Form["corpName"], "", true);

            int checkState = ADeeWu.HuoBi3J.Libary.Utility.GetInt(Request.QueryString["state"], Request.Form["state"], -1);
      

            StringBuilder whereBuilder = new StringBuilder();

            if (adminUserID > 0)
            {
                whereBuilder.AppendFormat(" and AdminUserID={0}", adminUserID);
                this.Pager1.AppendUrlParam("adminid", adminUserID.ToString());
                this.adminid.Value = adminUserID.ToString();
            }
            
            if (corpName != "")
            {

                whereBuilder.Append(" and RealCorpName like @RealCorpName");
                db.Parameters.Append("@RealCorpName", string.Format("%{0}%", corpName));
                this.Pager1.AppendUrlParam("corpName", corpName);
                this.corpName.Value = corpName;
            }


            DateTime dateTime;
            
            string startDate = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestStr("sd", "");
            if (IsPostBack)
            {
                startDate = this.txtStartDate.Text.Trim();
            }
            
            if( DateTime.TryParse(startDate, out dateTime))
            {
                whereBuilder.AppendFormat(" and CreateTime >= @CreateTime1");
                db.Parameters.Append("@CreateTime1", string.Format("{0:yyyy-MM-dd} 00:00:00", dateTime.ToShortDateString()));
                this.Pager1.AppendUrlParam("sd", startDate);
            }



            string endDate = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestStr("ed", "");
            if (IsPostBack)
            {
                endDate = this.txtEndDate.Text.Trim();
            }

            if (DateTime.TryParse(endDate, out dateTime))
            {
                whereBuilder.AppendFormat(" and CreateTime <= @CreateTime2");
                db.Parameters.Append("@CreateTime2", string.Format("{0:yyyy-MM-dd} 23:59:59", dateTime.ToShortDateString()));
                this.Pager1.AppendUrlParam("ed", endDate);
            }

            if (checkState >= 0)
            {
                whereBuilder.AppendFormat(" and CheckState={0}", checkState);
                this.Pager1.AppendUrlParam("state", checkState.ToString());
                this.state.Value = checkState.ToString();
            }
            
        
            string where = whereBuilder.Length > 0 ? whereBuilder.ToString().Substring(4) : string.Empty;

            db.EnableRecordCount = true;
            DataTable dataSource = db.Select(pageSize, pageIndex, "vw_CT_CashTicketApplications3", "id", where, "CheckState asc,CreateTime desc");
            db.EnableRecordCount = false;
            //业务统计
            dataSource.Columns.Add(new DataColumn("TotalCommission", typeof(decimal), "SUM(Commission)"));
            dataSource.Columns.Add(new DataColumn("TotalReturnMoney", typeof(decimal), "SUM(ReturnMoney)"));
            dataSource.Columns.Add(new DataColumn("TotalCostMoney", typeof(decimal), "SUM(CostMoney)"));

            this.gvData.DataSource = dataSource;
            this.gvData.DataBind();
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;

            this.litTotalRecord.Text = db.RecordCount.ToString();

            //显示统计结果
            if (dataSource.Rows.Count > 0)
            {
                DataRow dr = dataSource.Rows[0];
                this.litTotalCommission.Text = dr["TotalCommission"].ToString();
                this.litTotalCostMoney.Text = dr["TotalCostMoney"].ToString();
                this.litTotalReturnMoney.Text = dr["TotalReturnMoney"].ToString();
            }
            else
            {
                this.litTotalCommission.Text = string.Empty;
                this.litTotalCostMoney.Text = string.Empty;
                this.litTotalReturnMoney.Text = string.Empty;
            }

         
        }

    }
}
