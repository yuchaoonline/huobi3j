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

            DataBase db = DataBase.Create();
            db.Parameters.Append("bid", BID);
            var businessCircles = db.Select("vw_businesscircle", "bid=@bid", "");
            if (businessCircles == null || businessCircles.Rows.Count <= 0) return;

            var businessCircle = businessCircles.Rows[0];
            litBName.Text = businessCircle["BName"].ToString();
            litLocation.Text = Helper.GetLocation(businessCircle["AreaID"], businessCircle["Area"], businessCircle["CityID"], businessCircle["City"], businessCircle["ProvinceID"], businessCircle["Province"], "-");

            db.EnableRecordCount = true;
            db.Parameters.Append("bid", BID);
            var keys = db.Select(pageSize, pageIndex, "vw_Keys", "kid", "bid=@bid", "kcreatetime desc");

            rpResult.DataSource = keys;
            rpResult.DataBind();

            this.Pager1.AppendUrlParam("bid", BID.ToString());
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;

            rpInfo.DataSource = new DAL.Center_Info().GetCenterInfo(BID, 1);
            rpInfo.DataBind();
        }

        public string IsAttention(object _kid)
        {
            if (!SaleManSession.IsSaleMan) return "false";
            var userkey = new DAL.UserKey().GetEntity(new string[] { "uid", "kid" }, new object[] { SaleManSession.SaleMan.UserID, _kid });
            if (userkey == null) return "false";
            return userkey.IsGoOn ? "true" : "false";
        }
    }
}