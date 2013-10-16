using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.Corp.GroupBuy
{
    public partial class Order : PageBase_MyCorp
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData()
        {
            var productid = WebUtility.GetRequestInt("productid", 0);
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            var db = DataBase.Create();
            db.EnableRecordCount = true;
            rpResult.DataSource = db.Select(pageSize, pageIndex, "vw_GroupBuy_order", "id", string.Format("OrderProductID = {0}", productid), "");
            rpResult.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        public string IsUse(object obj)
        {
            if (obj == null) return "未知";
            return Utility.GetBool(obj, false) ? "是" : "否";
        }
    }
}