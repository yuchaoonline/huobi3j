using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.TradeOrders
{
    public partial class PayNow : System.Web.UI.Page
    {

        DAL.TradeSystem_AlipayTrades dal = new ADeeWu.HuoBi3J.DAL.TradeSystem_AlipayTrades();
        protected void Page_Load(object sender, EventArgs e)
        {
            string orderCode = WebUtility.GetRequestStr("order", "");
            if (orderCode.Length == 0) Response.Redirect(".");

            Model.TradeSystem_AlipayTrades ent = dal.GetEntity(new string[] { "OrderCode", "OrderState" }, orderCode, 0);
            if (ent != null)
            {
                Class.Alipay.AliPay alipay = new ADeeWu.HuoBi3J.Web.Class.Alipay.AliPay();

                string baseUrl = "http://" + Request.Url.Host;
                string url = alipay.CreatDirectPayUrl(ent.OrderCode,
                    "在线充值",
                    ent.Notes,
                    ent.TotalFee.ToString(),
                    baseUrl + "/Alipay/Alipay_Return.aspx",
                    baseUrl + "/Alipay/Alipay_Notify.aspx"
                  );

                Response.Redirect(url);
            }
            else
            {
                Response.Redirect(".");
            }
        }
    }
}
