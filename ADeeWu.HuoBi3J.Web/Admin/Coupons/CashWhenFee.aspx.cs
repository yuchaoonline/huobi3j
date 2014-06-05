using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Admin.Coupons
{
    public partial class CashWhenFee : System.Web.UI.Page
    {
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData()
        {
            var pageIndex = WebUtility.GetRequestInt("page", 1);
            var pageSize = Utility.GetInt(Request["pagesize"], 10, 5, 40);

            db.EnableRecordCount = true;
            var ticketTable = db.Select(pageSize, pageIndex, "vw_Coupons_CashWhenFee_UserTicket", "id", "", "");

            rpResult.DataSource = ticketTable;
            rpResult.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }
    }
}