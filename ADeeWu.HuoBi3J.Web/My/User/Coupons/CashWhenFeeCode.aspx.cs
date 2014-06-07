using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.Coupons
{
    public partial class CashWhenFeeCode : PageBase_MyUser
    {
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
                BandCount();
            }
        }

        private void BandData()
        {
            var pageIndex = WebUtility.GetRequestInt("page", 1);
            var pageSize = Utility.GetInt(Request["pagesize"], 10, 5, 40);

            db.EnableRecordCount = true;
            var ticketTable = db.Select(pageSize, pageIndex, "vw_Coupons_CashWhenFee_UserTicket", "id", "[SaleManUserID]=" + this.LoginUser.UserID, "");

            rpGet.DataSource = ticketTable;
            rpGet.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        private void BandCount()
        {
            var sql = "SELECT Count(*) AS TotalCount,SUM([Count]) AS TotalUseCount FROM dbo.Coupons_CashWhenFee_Code WHERE SaleManUserID = " + this.LoginUser.UserID;
            var result = db.Select(sql);
            if (result.Rows.Count > 0)
            {
                litCount.Text = result.Rows[0]["TotalCount"].GetStr();
                litUseCount.Text = result.Rows[0]["TotalUseCount"].GetStr();
            }
        }
    }
}