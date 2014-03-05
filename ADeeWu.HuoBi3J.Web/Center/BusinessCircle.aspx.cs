using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;
using ADeeWu.HuoBi3J.Web.Class;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class BusinessCircle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
            }
        }

        public bool IsDefaultBussinessCircle
        {
            get
            {
                return WebUtility.GetRequestInt("bid", -1) == bid;
            }
        }

        int bid = ADeeWu.HuoBi3J.Libary.Utility.GetInt(System.Configuration.ConfigurationManager.AppSettings["movebid"], 0);

        private void BandData()
        {
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);
            var BID = WebUtility.GetRequestInt("bid", -1);

            if (BID == -1)
            {
                WebUtility.ShowAndGoBack(this, "参数错误！");
                return;
            }

            var businessCircleDAL = new DAL.Key_BusinessCircle();
            var businessCircle = businessCircleDAL.GetEntity(BID);
            if (businessCircle == null) return;
            litBName.Text = businessCircle.BName;
            litBName2.Text = businessCircle.BName;

            var db = DataBase.Create();
            db.EnableRecordCount = true;
            db.Parameters.Append("bid", BID);
            var keys = db.Select(pageSize, pageIndex, "vw_Key_BusinessCircle", "kid", "bid=@bid", "kcreatetime desc");

            rpResult.DataSource = keys;
            rpResult.DataBind();

            this.Pager1.AppendUrlParam("bid", BID.ToString());
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        public string IsAttention(object _kid)
        {
            if (!SaleManSession.IsSaleMan) return "false";
            var userkey = new DAL.Key_User().GetEntity(new string[] { "uid", "kid" }, new object[] { SaleManSession.SaleMan.UserID, _kid });
            if (userkey == null) return "false";
            return userkey.IsGoOn ? "true" : "false";
        }
    }
}