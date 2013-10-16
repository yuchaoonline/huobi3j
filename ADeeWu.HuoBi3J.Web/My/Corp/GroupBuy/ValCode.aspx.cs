using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.Corp.GroupBuy
{
    public partial class ValCode : PageBase_MyCorp
    {
        DAL.GroupBuy_Order orderDAL = new DAL.GroupBuy_Order();
        DAL.GroupBuy_Product productDAL = new DAL.GroupBuy_Product();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                WebUtility.ShowMsg("请输入消费码！");
                return;
            }

            var db = DataBase.Create();
            db.Parameters.Append("createuserid", LoginUser.UserID);
            db.Parameters.Append("code", txtCode.Text);
            var record = db.Select("select * from vw_GroupBuy_Order where code = @code and createuserid = @createuserid");

            if (record.Rows.Count <= 0)
            {
                WebUtility.ShowMsg("消费码无效！");
                return;
            }

            var row = record.Rows[0];
            litTitle.Text = string.Format("<a href='/groupbuy/details.aspx?productID={0}' title='{1}'>{1}</a>", row["orderproductid"], row["title"]);
            if (Utility.GetBool(row["isuse"], true))
            {
                litIsUse.Text = "已消费";
            }
            else
            {
                var passdate = Utility.GetDateTime(row["passdate"], DateTime.Now).Value;
                var saleday = Utility.GetInt(row["saleday"], 0);
                if (passdate.AddDays(saleday) <= DateTime.Now)
                {
                    litIsUse.Text = "活动已结束！";
                    return;
                }

                litIsUse.Text = "未消费";
                hfOrderID.Value = row["id"].ToString();
                btnYes.Visible = true;
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            var orderid = Utility.GetInt(hfOrderID.Value, 0);
            if (orderid <= 0)
            {
                WebUtility.ShowMsg("标记出错！");
                return;
            }

            var order = orderDAL.GetEntity(orderid);
            if (order == null)
            {
                WebUtility.ShowMsg("订单不存在！");
                return;
            }

            order.IsUse = true;
            if (orderDAL.Update(order) > 0)
            {
                var product = productDAL.GetEntity(order.OrderProductID.Value);
                product.SaleCount++;
                productDAL.Update(product);

                WebUtility.ShowMsg(this, "已标记消费！", "ValCode.aspx");
                return;
            }
            else
            {
                WebUtility.ShowMsg("标记失败，请重试！");
                return;
            }
        }
    }
}