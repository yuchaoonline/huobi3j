using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.GroupBuy
{
    public partial class Details : System.Web.UI.Page
    {
        DataBase db = DataBase.Create();
        DAL.GroupBuy_Order orderDAL = new DAL.GroupBuy_Order();
        DAL.GroupBuy_Product productDAL = new DAL.GroupBuy_Product();
        DAL.Corporations corDAL = new DAL.Corporations();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData()
        {
            var id = WebUtility.GetRequestInt("productID",0);
            if(id==0)return;

            SetExpire(id);

            var product = db.Select("vw_groupbuy_product", "id = " + id, "");
             rpResult.DataSource = product;
             rpResult.DataBind();
        }

        private void SetExpire(int id)
        {
            var product = productDAL.GetEntity(id);
            if (product != null)
            {
                if (product.IsPass.HasValue && product.IsPass.Value && product.PassDate.HasValue && product.SaleDay.HasValue && product.PassDate.Value.AddDays(product.SaleDay.Value) < DateTime.Now)
                {
                    product.IsExpire = true;
                    productDAL.Update(product);
                }
            }
        }

        public string GetSaleOff(object marketprice, object price)
        {
            var mp = Utility.GetDecimal(marketprice, 0);
            var p = Utility.GetDecimal(price, 0);
            if (mp != p)
                return (p/mp*10).ToString("#.#") + "折";
            return "";
        }

        public string GetOverDay(object passdate, object saleday)
        {
            var pd = Utility.GetDateTime(passdate, DateTime.Now).Value;
            var sd = Utility.GetInt(saleday, 0);
            var lastday = sd - (DateTime.Now - pd).Days;
            return lastday > 0 ? lastday.ToString() : "0";
        }

        public string GetDecimal(object obj, int length)
        {
            return decimal.Round(ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(obj, 0), length).ToString();
        }

        protected void rpResult_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "order":
                    {
                        if(LoginUserID==0){
                            WebUtility.ShowMsg("请登录后再操作！");
                            return;
                        }
                        var pid = Utility.GetInt(e.CommandArgument, 0);
                        if (pid == 0)
                        {
                            WebUtility.ShowMsg("参数有误，请刷新页面！");
                            return;
                        }
                        OrderProduct(pid, (int)LoginUserID);
                    };break;
            }
        }

        private void OrderProduct(int pid, int userid)
        {
            if (orderDAL.Exist(new string[] { "OrderUserID", "OrderProductID" }, new string[] { userid.ToString(), pid.ToString() }))
            {
                WebUtility.RegisterScript(this, "ShowSuccess();");
                //WebUtility.ShowMsg("订购成功。到商家消费前，只需要用手机出示个人后台含有消费密码的订购信息界面或者界面截图，就可以先消费再付款！");
                return;
            }

            var product = productDAL.GetEntity(pid);
            if (!product.IsPass.HasValue||!product.IsPass.Value)
            {
                WebUtility.ShowMsg("活动未通过审核！");
                return;
            }
            if (!product.IsExpire.HasValue || product.IsExpire.Value)
            {
                WebUtility.ShowMsg("活动已过期！");
                return;
            }

            var cor = corDAL.GetEntity(new string[] { "userid" }, new object[] { product.CreateUserID });
            if (cor == null)
            {
                WebUtility.ShowMsg("预订出错，请重试！");
                return;
            }

            if (product.OrderCount >= product.Summary.Value)
            {
                WebUtility.ShowMsg("已预订满！");
                return;
            }

            var order = new Model.GroupBuy_Order
            {
                Title = product.Title,
                InformTel = cor.Tel,
                IsUse = false,
                OrderDate = DateTime.Now,
                OrderProductID = product.ID,
                OrderUserID = userid,
                Price = product.Price,
                SellerName = cor.CorpName,
                SellerTel = cor.Tel,
                Code = GenCode(orderDAL)
            };

            if (orderDAL.Add(order) > 0)
            {
                product.OrderCount++;
                productDAL.Update(product);

                WebUtility.RegisterScript(this,"ShowSuccess();");//.ShowMsg(this, "订购成功。到商家消费前，只需要用手机出示个人后台含有消费密码的订购信息界面或者界面截图，就可以先消费再付款！", Request.RawUrl);
                return;
            }
            else
            {
                WebUtility.ShowMsg("预订失败，请重试！");
                return;
            }
        }

        private string GenCode(DAL.GroupBuy_Order orderDAL)
        {
            var r = new Random(this.GetHashCode());
            var code = r.Next(0, 999999);
            while (orderDAL.Exist("code", code))
            {
                code = r.Next(0, 999999);
            }
            return code.ToString("D6"); ;
        }

        private long LoginUserID
        {
            get{
                var session = UserSession.GetSession();
                if (session == null) return 0;
                return session.UserID;
            }
        }

        protected void rpResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var btnOrder = e.Item.FindControl("btnOrder") as LinkButton;
            var btnOrder2 = e.Item.FindControl("btnOrder2") as LinkButton;
            var btnOver = e.Item.FindControl("btnOver") as LinkButton;
            var btnOver2 = e.Item.FindControl("btnOver2") as LinkButton;
            var btnBuyLink = e.Item.FindControl("btnBuyLink") as LinkButton;
            var btnBuyLink2 = e.Item.FindControl("btnBuyLink2") as LinkButton;

            var rowView = e.Item.DataItem as DataRowView;
            var row = rowView.Row;
            var buylink = Utility.GetStr(row["buylink"], "");
            var summary = Utility.GetInt(row["summary"], 0);
            var ordercount = Utility.GetInt(row["ordercount"], 0);

            if (string.IsNullOrWhiteSpace(buylink) || buylink == "#")
            {
                if (ordercount >= summary)
                {
                    btnOver.Visible = true;
                    btnOver2.Visible = true;
                }
                else
                {
                    btnOrder.Visible = true;
                    btnOrder2.Visible = true;
                }
            }
            else
            {
                btnBuyLink.Visible = true;
                btnBuyLink2.Visible = true;
            }
        }
    }
}