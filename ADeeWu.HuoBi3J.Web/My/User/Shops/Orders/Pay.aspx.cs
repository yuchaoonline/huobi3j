using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.Shops.Orders
{
    public partial class Pay : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {
     
        long orderid = 0;
        DataBase db = DataBase.Create();
        DAL.Shop_Orders dalOrder = new ADeeWu.HuoBi3J.DAL.Shop_Orders();
        DAL.TradeSystem_Tasks dalTradeSysTask = new ADeeWu.HuoBi3J.DAL.TradeSystem_Tasks();

        protected void Page_Load(object sender, EventArgs e)
        {
            orderid = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (!IsPostBack)//获取外部参数
            {
                bindData();
            }
        }

        void bindData()
        {
            if (orderid > 0)
            {
                Model.Shop_Orders entOrder = dalOrder.GetEntity(orderid);
                if (entOrder == null)
                {
                    Class.Tips.SetTips("订单不存在!", "无法找到相关订单资料", "/My/User/Shops/Orders/", "请返回查看订单列表");
                    Class.Tips.Show();
                    return;
                }

                if (entOrder.OrderState == 3)
                {
                    Class.Tips.SetTips("操作失败!", "该定单已处于完成状态,不需要付款", "/My/User/Shops/Orders/", "请返回查看订单列表");
                    Class.Tips.Show();
                    return;
                }

                this.lblOrderCode.Text = entOrder.OrderCode;
                this.lblTotal.Text = string.Format("{0:0.00}", (decimal)entOrder.SubTotal + (decimal)entOrder.Freight);
                decimal balance = Utility.GetDecimal(db.ExecuteScalar("select Money from Users where ID={0}", this.LoginUser.UserID), 0);
                this.lblSpare.Text = string.Format("{0:0.00}", balance);
                
            }
            else
            {
                Response.Redirect(".");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Model.Shop_Orders entOrder = dalOrder.GetEntity(orderid);
            if (entOrder == null)
            {
                Class.Tips.SetTips("订单不存在!", "无法找到相关订单资料", "/My/User/Shops/Orders/", "返回购物订单列表");
                Class.Tips.Show();
                return;
            }

            if (entOrder.OrderState == 3)
            {
                Class.Tips.SetTips("操作失败!", "该定单已处于完成状态,不能执行付款操作", "/My/User/Shops/Orders/", "返回购物订单列表");
                Class.Tips.Show();
                return;
            }

            if (entOrder.HasPaid)
            {
                Class.Tips.SetTips("操作失败!", "该定单已付款,不能执行付款操作", "/My/User/Shops/Orders/", "返回购物订单列表");
                Class.Tips.Show();
                return;
            }

            db.Parameters.Clear();
            db.Parameters.Append("@ShopOrderCode", entOrder.OrderCode);
            db.Parameters.Append("@TotalFee", entOrder.SubTotal + entOrder.Freight);
            db.Parameters.Append("@FromUserID", entOrder.BuyerUserID);
            db.Parameters.Append("@ToUserID", entOrder.SellerUserID);
            db.Parameters.Append("@Notes", 
                string.Format("购物订单付款--订单号:{0},共计:{1}元(包含运费:{2}元) ", entOrder.OrderCode, entOrder.SubTotal + entOrder.Freight, entOrder.Freight)
            );
            db.Parameters.Append("@ErrorMessage", "", ParameterDirection.Output).Size = 100;
            db.Parameters.Append("@ReturnValue", -1).Direction = ParameterDirection.ReturnValue;


            db.AutoClearParameters = false;
            object o = db.RunProc("SP_TradeSystem_ShopOrderPayment");
            int ret = Utility.GetInt(db.Parameters["@ReturnValue"].Value, 1);
            db.AutoClearParameters=true;

            if (ret == 0)
            {
                Class.Tips.SetTips("购物订单付款成功", string.Format("您的购物订单:{0}已成功付款,请耐心等待商家发货!", entOrder.OrderCode), "/My/User/Shops/Orders/", "返回购物订单列表");
                Class.Tips.Show();
            }
            else
            {
                Class.Tips.SetTips("购物订单付款失败", db.Parameters["@ErrorMessage"].Value.ToString(), "/My/User/Shops/Orders/", "返回购物订单列表");
                Class.Tips.Show();
            }
        }

      
    }
}
