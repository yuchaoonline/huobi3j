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
using System.Text;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Admin.Center
{
    public partial class SaleMan : PageBase
    {

        public override string PageID
        {
            get
            {
                return "009011";
            }
        }

        DataBase db = DataBase.Create();
        ADeeWu.HuoBi3J.DAL.Users dalUsers = new ADeeWu.HuoBi3J.DAL.Users();


        protected void Page_Load(object sender, EventArgs e)
        {
            DataBase db = DataBase.Create();

            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            string loginName = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request.QueryString["loginname"], Request.Form["loginname"], "", true);
            int stateValue = ADeeWu.HuoBi3J.Libary.Utility.GetInt(Request.QueryString["state"], Request.Form["state"], -1);

            StringBuilder builderWhere = new StringBuilder();

            if (string.IsNullOrEmpty(loginName))
            {
                builderWhere.Append(" and LoginName like @LoginName");
                db.Parameters.Append("@LoginName", string.Format("%{0}%", loginName));
                this.Pager1.AppendUrlParam("LoginName", loginName);
                this.LoginName.Value = loginName;
            }

            if (stateValue >= 0)
            {
                builderWhere.Append(" and CheckState=@CheckState");
                db.Parameters.Append("@CheckState", stateValue);
                this.Pager1.AppendUrlParam("state", stateValue.ToString());
                this.state.Value = stateValue.ToString();
            }

            string where = "" + (
                   (builderWhere.Length > 0) ? builderWhere.ToString().Substring(4) : string.Empty
           );

            this.state.Value = stateValue.ToString();
            this.LoginName.Value = loginName;

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Key_CircleSaleMan", "id", where, "ModifyTime desc");
            this.gvData.DataBind();
            this.Pager1.PageSize = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageSize, 0);
            this.Pager1.PageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageIndex, 0);
            this.Pager1.TotalRecords = ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RecordCount, 0);
            db.EnableRecordCount = false;
        }

    }
}
