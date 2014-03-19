using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class SearchKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strKeyword = WebUtility.GetRequestStr("keyword", "");
                if (string.IsNullOrWhiteSpace("输入搜索关键字")) strKeyword = "";

                Search(strKeyword);
            }
        }

        private void Search(string KeyWord)
        {
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            DataBase db = DataBase.Create();

            var sql = string.Format(" Name like '%{0}%'", KeyWord);

            db.EnableRecordCount = true;
            var dt = db.Select(pageSize, pageIndex, "[key]", "kid", sql, "CreateTime desc");
            rpResult.DataSource = dt;
            rpResult.DataBind();

            this.Pager1.AppendUrlParam("keyword", KeyWord);
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }
    }
}