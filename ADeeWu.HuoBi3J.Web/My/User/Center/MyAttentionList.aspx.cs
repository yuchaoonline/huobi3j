using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class MyKeyList : PageBase_CircleSaleMan
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData(this.LoginUser.UserID);
                CalCoin();
            }
        }

        private void CalCoin()
        {
            var coin = DataBase.Create().ExecuteScalar("select sum(coin) from Center_QR_Log where salemanuserid = " + SaleManSession.SaleMan.UserID);
            litCoin.Text = coin == null ? "0" : coin.ToString();
        }

        private void BandData(long uid)
        {
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            DataBase db = DataBase.Create();

            db.EnableRecordCount = true;
            db.Parameters.Append("UID", uid);
            var dt = db.Select(pageSize, pageIndex, "vw_UserKey", "UKID", "UID=@UID", "");
            rpQuestions.DataSource = dt;
            rpQuestions.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        public string IsGoOn(object _IsGoOn, object _kid)
        {
            var returnValue = "已取消关注";
            if (ADeeWu.HuoBi3J.Libary.Utility.GetBool(Eval("IsGoOn"), false))
            {
                returnValue = string.Format(" <a href='ChangeGoOn.aspx?kid={0}' title='取消关注' class='btn_blue'>取消关注</a>", _kid);
            }

            return returnValue;
        }
    }
}