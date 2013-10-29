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
    public partial class PriceList4Key : PageBase_CircleSaleMan
    {
        DAL.Key_Product productDAL = new DAL.Key_Product();
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
            var id = WebUtility.GetRequestInt("id", 0);
            var kid = WebUtility.GetRequestStr("kid", "");
            if (productDAL.Delete(id) > 0)
            {
                WebUtility.ShowMsg(this, "删除成功！", "pricelist4key.aspx?kid=" + kid);
                return;
            }
            else
            {
                WebUtility.ShowMsg("删除失败，请重试！");
                return;
            }
        }

        private void BandData()
        {
            var kid = WebUtility.GetRequestStr("kid", "");
            var dt = productDAL.GetEntityList("", new string[] { "CreateUserID", "kid" }, new object[] { this.LoginUser.UserID, kid });
            rpQuestions.DataSource = dt;
            rpQuestions.DataBind();
        }

        public string GetMoney(object mon)
        {
            return Utility.GetDecimal(mon, 0).ToString("F2");
        }
    }
}