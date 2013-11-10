using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class GetCoin : PageBase
    {
        DataBase db = DataBase.Create();
        DAL.Users userDAL = new DAL.Users();
        DAL.Center_QR_Log qrLogDAL = new DAL.Center_QR_Log();
        DAL.User_CoinUseHistories dealHistoryDAL = new DAL.User_CoinUseHistories();
        int qrFee = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SaleManInfo();
                SaleManProduct();

                if (WebUtility.GetRequestStr("confirm", "")=="yes")
                {
                    CalCoin();
                }
            }
        }

        private void SaleManInfo()
        {
            var userid = WebUtility.GetRequestInt("salemanuserid", 0);
            if (userid > 0)
            {
                rpSaleManInfo.DataSource = db.Select("vw_CircleSaleMan", "userid = " + userid, "");
                rpSaleManInfo.DataBind();
            }
        }

        private void SaleManProduct()
        {
            var userid = WebUtility.GetRequestInt("salemanuserid", 0);

            rpProduct.DataSource = db.Select(10, 1, "vw_key_product", "id", string.Format("createuserid = {0} and pname='{1}' and cname='{2}'", userid, AccountHelper.Province, AccountHelper.City), "price asc");
            rpProduct.DataBind();
        }

        private void CalCoin()
        {
            if (LoginUser == null)
            {
                WebUtility.ShowMsg(this, "请登录", "mobilelogin.aspx?url=" + Request.RawUrl);
                return;
            }
            else
            {
                var salemanUserID = WebUtility.GetRequestInt("salemanuserid", 0);
                if (salemanUserID == 0)
                {
                    WebUtility.ShowMsg("参数有误，请重新扫描！");
                    return;
                }

                if (qrLogDAL.Exist(new string[] { "userid", "salemanuserid" }, new object[] { LoginUser.UserID, salemanUserID }))
                {
                    WebUtility.ShowMsg(this, "别太贪心，该商家你已经扫描了", "SaleMan4Product.aspx?userid=" + salemanUserID);
                    return;
                }

                var qrLog = new Model.Center_QR_Log
                {
                    Coin = 10,
                    CreateDate = DateTime.Now,
                    SaleManUserID = salemanUserID,
                    UserID = (int)LoginUser.UserID,
                    Demo = ""
                };
                if (qrLogDAL.Add(qrLog) > 0)
                {
                    var user = userDAL.GetEntity(LoginUser.UserID);
                    user.Coins += qrFee;
                    userDAL.Update(user);

                    var deal = new Model.User_CoinUseHistories
                    {
                        InCoin = qrFee,
                        OutCoin = 0,
                        UserID = LoginUser.UserID,
                        Notes = string.Format("获得扫描金币 {0} 个", qrFee),
                        CreateTime = DateTime.Now,
                        Remain = user.Coins
                    };
                    dealHistoryDAL.Add(deal);

                    WebUtility.ShowMsg(this, "扫描成功，金币已入账！", "SaleMan4Product.aspx?userid=" + salemanUserID);
                }
            }
        }

        public string GetDecimal(object obj, int length)
        {
            return decimal.Round(Utility.GetDecimal(obj, 0), length).ToString();
        }
    }
}