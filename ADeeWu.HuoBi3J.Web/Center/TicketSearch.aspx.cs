using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class TicketSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var keyword = WebUtility.GetRequestStr("keyword", string.Empty);
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    Search(keyword);
                }
                else
                {
                    HotKeys();
                }
            }
        }

        private void HotKeys()
        {
            var hotKeys = new DAL.TicketHotKey().GetEntityList("", new string[] { }, new string[] { });
            rpHotKeys.DataSource = hotKeys;
            rpHotKeys.DataBind();
        }

        private void Search(string keyword)
        {
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 10, 5, 40);
            var db = DataBase.Create();
            rpResult.DataSource = db.Select(pageSize, pageIndex, "vw_CorporationHaveTickets", "id", string.Format("corpname like '%{0}%'", keyword), "");
            rpResult.DataBind();

            this.Pager1.AppendUrlParam("keyword", keyword);
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }
    }
}