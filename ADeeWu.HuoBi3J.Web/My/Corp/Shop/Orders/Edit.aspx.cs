using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Text;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Orders
{
    public partial class Edit : ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp_Shop
    {
        
        DataBase db = DataBase.Create();
        DAL.Shop_Orders dalOrder = new ADeeWu.HuoBi3J.DAL.Shop_Orders();
        long orderid = 0;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            orderid = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("orderid", 0);

               if(!IsPostBack)
               {
                   bindData();
               }
        }


        void bindData()
        {
            DataTable dt = db.Select("select * from vw_Shop_Orders where  ID=" + orderid + " and SellerCorpID=" + this.LoginUser.CorpID);

            if (dt.Rows.Count == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "当前没有订单!");
                return;
            }

            DataRow dr = dt.Rows[0];

            this.lblOrderCode.Text = Utility.GetStr(dr["OrderCode"]);
            this.lblOrderTime.Text = dr["CreateTime"].ToString();
            this.lblBuyerUIN.Text = Utility.GetStr(dr["BuyerUIN"]);
            this.lblBuyerLoginName.Text = Utility.GetStr(dr["BuyerLoginName"]);
            this.lblSubTotal.Text = string.Format("{0:0.00}", dr["SubTotal"]);
            this.lblFreight.Text = string.Format("{0:0.00}", dr["Freight"]);
            this.lblTotal.Text = string.Format("{0:0.00}", (decimal)dr["SubTotal"] + (decimal)dr["Freight"]);

            if (Utility.GetBool(dr["HasPaid"], false))
            {
                this.liteHasPaid.Text = "消费者已付款";
            }
            else
            {
                this.liteHasPaid.Text = "否";
            }
            this.lblReceiver.Text = Utility.GetStr(dr["Receiver"]);



            this.liteOrderState.Text = WebUtility.Switch(dr["OrderState"].ToString(),
                new string[,]{
                           {"0","未处理"},
                           {"1","处理中"},
                           {"2","已发货,正在等待消费者确认收货"},
                           {"3","完成"}
                       }
                );

            int orderState = Utility.GetInt(dr["OrderState"], 0);
            setOrderkState(orderState);

            if (orderState == 3)
            {
                DateTime? deliveryTime = Utility.GetDateTime(dr["DeliveryTime"], null);
                this.txtDeliveryTime.Text = deliveryTime.HasValue ? deliveryTime.Value.ToShortDateString() : string.Empty;
            }

            this.lblDeilveryAddress.Text = string.Format("{0}{1}{2} {3}", dr["ProvinceName"], dr["CityName"], dr["AreaName"], dr["Address"]);

            this.lblZip.Text = Utility.GetStr(dr["ZipCode"]);
            this.lblNote.Text = Utility.GetStr(dr["Note"]);

            this.lblDeliveryType.Text = WebUtility.Switch(
            dr["DeliveryType"].ToString(),
            new string[,]{{"0"," 到代理店取货"},{"1","平邮"},{"2","快递"}, {"3","EMS"}
                    }
            );

            

            StringBuilder builderWhere = new StringBuilder();
            builderWhere.Append("OrderID=" + orderid + " and SellerCorpID=" + this.LoginUser.CorpID);
            this.gvData.DataSource = db.Select(-1, -1, "vw_Shop_OrderDetails", "ID", builderWhere.ToString(), "CreateTime DESC ");
            this.gvData.DataBind();
        }

     

     
        
        /// <summary>
        /// 设置订单状态
        /// </summary>
        /// <param name="state"></param>
        void setOrderkState(int state)
        {
            this.btnProcess.Visible = false;
            this.ph01.Visible = false;
            this.ph02.Visible = false;

            switch (state)
            {
                case 0:
                    this.btnProcess.Visible = true;
                    break;
                case 1:
                    this.ph01.Visible = true;
                    break;
                case 3:
                    this.ph02.Visible = true;
                    break;
               
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {

            //修改订单状态为 "处理中"
            if (
                dalOrder.Update("OrderState", 1, string.Format("ID={0} and SellerCorpID={1} and OrderState=0", orderid, this.LoginUser.CorpID)) > 0
                )
            {
                WebUtility.ShowMsg(this, "操作成功");
                
            }
            else
            {
                WebUtility.ShowMsg(this, "操作失败,请与我们联系!", "?orderid=" + orderid);
            }
            bindData();
        }

        protected void btnDelivery_Click(object sender, EventArgs e)
        {
            DateTime? deliveryTime = Utility.GetDateTime(this.txtDeliveryTime.Text, null);

            if (!deliveryTime.HasValue)
            {
                WebUtility.ShowMsg(this, "请填写正确的发货日期");
                return;
            }


            //修改订单状态为 "已发货"
            if (
                dalOrder.Update(new string[] { "OrderState", "DeliveryTime" }, new object[] { 2, deliveryTime.Value }, string.Format("ID={0} and SellerCorpID={1} and OrderState=1", orderid, this.LoginUser.CorpID)) > 0
                )
            {
                WebUtility.ShowMsg(this, "操作成功", "?orderid=" + orderid);
            }
            else
            {
                WebUtility.ShowMsg(this, "操作失败,请与我们联系!");
            }

            bindData();
        }
       
    }
}
