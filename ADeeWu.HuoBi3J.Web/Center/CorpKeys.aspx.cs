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
    public partial class CorpKeys : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var uid = WebUtility.GetRequestInt("uid", 0);
                var bid = WebUtility.GetRequestInt("bid", 0);
                if (uid > 0 && bid > 0)
                {
                    Search(uid, bid);
                }
            }
        }

        private void Search(int uid, int bid)
        {
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 10, 5, 40);

            var corp = new DAL.Corporations().GetEntity(new string[] { "userid" }, new object[] { uid });
            litCorpName.Text = corp.CorpName;

            var keys = new DAL.UserKey().GetEntityList("",new string[]{"uid"},new object[]{uid});
            if (keys == null) return;

            var db = DataBase.Create();
            db.Parameters.Append("bid", bid);
            db.EnableRecordCount = true;
            rpResult.DataSource = db.Select(pageSize, pageIndex, "vw_Keys", "kid", string.Format("kid in ({0}) and bid=@bid", string.Join(",", keys.Select(p => p.KID))), "");
            rpResult.DataBind();

            this.Pager1.AppendUrlParam("bid", bid.ToString());
            this.Pager1.AppendUrlParam("uid", uid.ToString());
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }
    }
}