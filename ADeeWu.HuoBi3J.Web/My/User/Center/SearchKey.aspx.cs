using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class SearchKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var keyword = WebUtility.GetRequestStr("keyword", "");
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    BandData(keyword);
                }
            }
        }

        private void BandData(string keyword)
        {
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            DataBase db = DataBase.Create();

            db.EnableRecordCount = true;
            var keys = db.Select("vw_keys", "kname like '%" + keyword + "%'", "");

            rpResult.DataSource = keys;
            rpResult.DataBind();

            this.Pager1.AppendUrlParam("keyword", keyword);
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("searchkey.aspx?keyword=" + txtKeyword.Text, true);
        }
    }
}