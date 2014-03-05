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
    public partial class Key : System.Web.UI.Page
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
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);
            var kid = WebUtility.GetRequestInt("kid", -1);

            if (kid == -1)
            {
                WebUtility.ShowAndGoBack(this, "参数错误！");
                return;
            }

            var db = DataBase.Create();
            db.Parameters.Append("kid", kid);
            var keys = db.Select("vw_keys", "kid=@kid", "");
            if (keys == null||keys.Rows.Count<=0) return;
            var key = keys.Rows[0];
            litKName.Text = key["KName"].ToString();
            litKName2.Text = key["KName"].ToString();

            db.EnableRecordCount = true;
            db.Parameters.Append("kid", kid);
            var circles = db.Select(pageSize, pageIndex, "vw_Key_BusinessCircle", "bid", "kid=@kid", "bcreatetime desc");

            rpResult.DataSource = circles;
            rpResult.DataBind();

            this.Pager1.AppendUrlParam("kid", kid.ToString());
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }
    }
}