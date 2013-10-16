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
    public partial class View : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {
        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;

        long orderid = 0;

        protected DataRow drData = null;
        DAL.TradeSystem_Tasks dalTradeTask = new ADeeWu.HuoBi3J.DAL.TradeSystem_Tasks();
        DAL.Shop_Orders dalOrder = new ADeeWu.HuoBi3J.DAL.Shop_Orders();

        protected void Page_Load(object sender, EventArgs e)
        {

            pageSize = Utility.GetInt(Request["pagesize"], 20, 5, 20);
            pageIndex = WebUtility.GetRequestInt("page", 1);
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
                DataTable dt = db.Select("select * from vw_Shop_Orders where ID=" + orderid + " and BuyerUserID=" + LoginUser.UserID);

                if (dt.Rows.Count == 0)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "该记录已不存在！", ".");
                    return;
                }

                DataRow dr = dt.Rows[0];
                this.drData = dr;

                this.lblOrderCode.Text = dr["OrderCode"].ToString();
                this.lblOrderTime.Text = dr["CreateTime"].ToString();
                this.lblCorpName.Text = dr["CorpName"].ToString();
                this.lblReceiver.Text = dr["Receiver"].ToString();
                this.lblSubTotal.Text = string.Format("{0:0.00}", dr["SubTotal"]);
                this.lblFreight.Text = string.Format("{0:0.00}", dr["Freight"]);
                this.lblTotal.Text = string.Format("{0:0.00}", (decimal)dr["SubTotal"] + (decimal)dr["Freight"]);
                
                
         

                this.lblAddress.Text = string.Format("{0}{1}{2} {3}", dr["ProvinceName"], dr["CityName"], dr["AreaName"], dr["Address"]);
                this.lblZip.Text = dr["ZipCode"].ToString();
                this.lblNote.Text = dr["Note"].ToString();
                this.lblDeliveryType.Text = WebUtility.Switch(
                    dr["DeliveryType"].ToString(),
                    new string[,]{{"0"," 到代理店取货"},{"1","平邮"},{"2","快递"}, {"3","EMS"}
                    }
                    );
               
                StringBuilder builderWhere = new StringBuilder();

                builderWhere.AppendFormat("OrderID={0} and BuyerUserID={1}", orderid, this.LoginUser.UserID);

                this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_Shop_OrderDetails", "ID", builderWhere.ToString(), "CreateTime DESC ");
                this.gvData.DataBind();

               
            }
        }

        /// <summary>
        /// 消费者确认收货,完成本次购物流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConfirmReceiveGoods_Click(object sender, EventArgs e)
        {
            //获取定单信息
            Model.Shop_Orders entOrder = dalOrder.GetEntity(orderid);
            if( entOrder==null)
            {
                Response.Redirect(".");
            }

            if (entOrder.OrderState == 2)//商家已发货
            {

                  //获取交易计划任务
                Model.TradeSystem_Tasks entTask = dalTradeTask.GetEntity(new string[] { "TradeType", "OrderCode" }, 0, entOrder.OrderCode);
                if (entTask != null)//线上付款
                {

                    db.Parameters.Clear();
                    db.Parameters.Append("@TaskID", entTask.ID);
                    db.Parameters.Append("@ErrorMessage", "", ParameterDirection.Output).Size = 500;
                    int ret = Utility.GetInt(db.RunProc("SP_TradeSystem_RunTask"), 1);
                    if (ret == 0)
                    {
                        WebUtility.ShowMsg(this, "操作成功!");
                    }
                    else
                    {
                        WebUtility.ShowMsg(this, "操作失败,请与我们联系!");
                    }
                    bindData();
                }
                else//非线上付款
                {
                    if (dalOrder.Update("OrderState", 3, "ID=" + orderid) > 0)
                    {
                        WebUtility.ShowMsg(this, "操作成功!");
                    }
                    else
                    {
                        WebUtility.ShowMsg(this, "操作失败,请与我们联系!");
                    }
                    bindData();
                }


            }
            else
            {
                Response.Redirect(".");
            }

          
        }

      
    }
}
