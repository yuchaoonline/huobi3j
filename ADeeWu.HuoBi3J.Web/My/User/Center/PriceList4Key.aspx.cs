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
    public partial class PriceList4Key : PageBase_CircleSaleMan
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
            }
        }

        private void Delete()
        {
            var id = WebUtility.GetRequestStr("id", "");
            var kid = WebUtility.GetRequestStr("kid", "");
            try
            {
                poiBLL.Delete(new List<string> { id }, ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID);
                WebUtility.ShowMsg(this, "删除成功！", "pricelist4key.aspx?kid=" + kid);
            }
            catch (Exception ex)
            {
                WebUtility.ShowMsg("删除失败，请重试！");
            }
        }

        private void BandData()
        {
            var kid = WebUtility.GetRequestStr("kid", "");
            var dic = new Dictionary<string, string>();
            dic.Add("KID", kid + "," + kid);
            dic.Add("CreateUserID", LoginUser.UserID + "," + LoginUser.UserID);
            var productResult = poiBLL.List<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>(ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID, dic);
            rpQuestions.DataSource = productResult.pois;
            rpQuestions.DataBind();
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
    }
}