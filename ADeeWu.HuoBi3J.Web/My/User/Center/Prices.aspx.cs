using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADee.Project.LBS.BLL;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class Prices : PageBase_CircleSaleMan
    {
        DAL.Common_Count_Click CountDAL = new DAL.Common_Count_Click();
        PoiBLL poiBLL = new PoiBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var method = WebUtility.GetRequestStr("method", "");
                if (method == "delete")
                {
                    Delete();
                }
                BandData();
                CalCoin();
                CalQRCount();
            }
        }

        private void Delete()
        {
            var id = WebUtility.GetRequestStr("id", "");
            try
            {
                poiBLL.Delete(new List<string> { id }, ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID);
                WebUtility.ShowMsg(this, "删除成功！", "prices.aspx");
            }
            catch
            {
                WebUtility.ShowMsg("删除失败，请重试！");
            }
        }

        private void BandData()
        {
            var pageIndex = WebUtility.GetRequestInt("page", 1);
            var pageSize = Utility.GetInt(Request["pagesize"], 10, 5, 40);

            var dic = new Dictionary<string, string>();
            dic.Add("CreateUserID", string.Format("{0},{0}", LoginUser.UserID));
            var productResult = poiBLL.List<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>(ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID, dic, "", "", "", pageIndex - 1, pageSize);
            rpQuestions.DataSource = productResult.pois;
            rpQuestions.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)productResult.total;
        }

        public string GetMoney(object mon)
        {
            return Utility.GetDecimal(mon, 0).ToString("F2");
        }

        public string GetCount(object id)
        {
            var counts = CountDAL.GetEntityList("", new string[] { "DataType", "DataID" }, new object[] { "center_product", id });
            if (counts != null) return counts.Length.ToString();

            return "0";
        }

        private void CalCoin()
        {
            var coin = DataBase.Create().ExecuteScalar("select sum(coin) from Key_QR_Log where salemanuserid = " + SaleManSession.SaleMan.UserID);
            litCoin.Text = coin == null ? "0" : coin.ToString();
        }

        private void CalQRCount()
        {
            var count = DataBase.Create().ExecuteScalar("select count(*) from Key_QR_Log where userid = -1 and salemanuserid = " + SaleManSession.SaleMan.UserID);
            litQRCount.Text = count == null ? "0" : count.ToString();
        }
    }
}