using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Aution
{
    public partial class Aution : PageBase_MyCorp
    {
        DAL.CP_Keyword_AD adDAL = new DAL.CP_Keyword_AD();
        DAL.CP_Keyword_AD_Auction auctionDAL = new DAL.CP_Keyword_AD_Auction();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
                long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);
                long keywordID = WebUtility.GetUrlLong("id", 0);

                adDAL.Parameters.Append("UserID", LoginUser.UserID);
                ddlADList.DataSource = adDAL.Select("UserID=@UserID and IsPass = 1", "");
                ddlADList.DataTextField = "Name";
                ddlADList.DataValueField = "ID";
                ddlADList.DataBind();

                auctionDAL.EnableRecordCount = true;
                rpADList.DataSource = auctionDAL.Select(pageSize, pageIndex, "KeywordID=" + keywordID, "");
                rpADList.DataBind();

                this.Pager1.PageIndex = (int)pageIndex;
                this.Pager1.PageSize = (int)pageSize;
                this.Pager1.TotalRecords = (int)auctionDAL.RecordCount;
                this.Pager1.AppendUrlParam("id", keywordID.ToString());
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long keywordID = WebUtility.GetUrlLong("id", 0);
            if (!Utility.IsFloat(txtClickPrice.Text))
            {
                WebUtility.ShowMsg("单击价格为空或格式有误！");
                return;
            }
            if (!Utility.IsFloat(txtTotalPrice.Text))
            {
                WebUtility.ShowMsg("总金额为空或格式有误！");
                return;
            }
            if (!Utility.IsFloat(txtCostPriceDay.Text))
            {
                WebUtility.ShowMsg("每日消费金额为空或格式有误！");
                return;
            }

            bool result = false;
            decimal difference = 0;

            DAL.CP_Keyword_AD_Auction auctionDAL = new DAL.CP_Keyword_AD_Auction();
            auctionDAL.Parameters.Append("Keyword_AD_ID", Utility.GetLong(ddlADList.SelectedValue, 0));
            auctionDAL.Parameters.Append("KeywordID", keywordID);
            auctionDAL.Parameters.Append("UserID", LoginUser.UserID);
            Model.CP_Keyword_AD_Auction auction = auctionDAL.GetEntity("Keyword_AD_ID=@Keyword_AD_ID and KeywordID = @KeywordID and UserID = @UserID");
            if (auction != null && auction.ID > 0)
            {
                #region 修改竞价
                auction.ClickPrice = Utility.GetDecimal(txtClickPrice.Text, 0);
                difference = Utility.GetDecimal(txtTotalPrice.Text, 0) - (decimal)auction.TotalPrice;
                auction.TotalPriceDay = Utility.GetDecimal(txtCostPriceDay.Text, 0);
                auction.IsPause = false;
                if (difference < 0)
                {
                    WebUtility.ShowMsg("竞价金额必须大于上次竞价余额,竞价余额为：" + auction.TotalPrice);
                    return;
                }
                if (Subtract(difference))
                {
                    auction.TotalPrice = Utility.GetDecimal(txtTotalPrice.Text, 0);
                    result = auctionDAL.Update(auction) > 0 ? true : false;
                }
                #endregion
            }
            else
            {
                #region 新建竞价
                auction = new Model.CP_Keyword_AD_Auction
                        {
                            Keyword_AD_ID = Utility.GetLong(ddlADList.SelectedValue, 0),
                            TotalPrice = Utility.GetDecimal(txtTotalPrice.Text, 0),
                            KeywordID = keywordID,
                            UserID = LoginUser.UserID,
                            ClickPrice = Utility.GetDecimal(txtClickPrice.Text, 0),
                            TotalPriceDay = Utility.GetDecimal(txtCostPriceDay.Text, 0),
                            IsPause = false,
                        };
                difference = (decimal)auction.TotalPrice;
                if (Subtract(difference))
                    result = auctionDAL.Add(auction) > 0 ? true : false;
                #endregion
            }
            #region 提示
            if (result)
            {
                #region 添加竞价记录
                DAL.CP_Keyword_AD_Auction_Log logDAL = new DAL.CP_Keyword_AD_Auction_Log();
                Model.CP_Keyword_AD_Auction_Log log = new Model.CP_Keyword_AD_Auction_Log
                {
                    ClickPrice = auction.ClickPrice,
                    CostMoney = difference,
                    Keyword_AD_ID = auction.Keyword_AD_ID,
                    Keyword_Auction_ID = auction.ID,
                    CreateTime = DateTime.Now
                };
                logDAL.Add(log);
                #endregion

                WebUtility.ShowAndTopRedirect(this, ("竞价成功！扣除现金：" + difference), Request.RawUrl);
                return;
            }
            else
            {
                WebUtility.ShowMsg(this, "竞价失败！");
                return;
            }
            #endregion
        }

        /// <summary>
        /// 扣除现金
        /// </summary>
        /// <param name="money">现金</param>
        /// <returns></returns>
        public bool Subtract(decimal money)
        {
            #region 扣除现金
            DAL.Users userDAL = new DAL.Users();
            Model.Users user = userDAL.GetEntity(LoginUser.UserID);
            if (user == null || user.ID == 0)
            {
                WebUtility.ShowMsg("未知错误，请重登录！");
                return false;
            }
            if (user.Money < money)
            {
                WebUtility.ShowMsg("账户余额不足，请充值！");
                return false;
            }
            user.Money -= money;
            if (userDAL.Update(user) < 0)
            {
                WebUtility.ShowMsg("扣除失败，请重试！");
                return false;
            }
            #region 添加记录
            DAL.User_DealHistories historyDAL = new DAL.User_DealHistories();
            Model.User_DealHistories history = new Model.User_DealHistories
            {
                Balance = user.Money,
                CreateTime = DateTime.Now,
                InMoney = 0,
                OutMoney = money,
                Notes = string.Format("参与关键字竞价费用"),
                UserID = LoginUser.UserID,
            };
            historyDAL.Add(history);
            #endregion
            return true;
            #endregion
        }

        int index = 0;
        public string GetIndex()
        {
            index++;
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);
            return ((pageIndex - 1) * pageSize + index).ToString();
        }

        public string IsOwnAuction(object UserID)
        {
            if (UserID == null) return "";
            if (LoginUser.UserID == Utility.GetLong(UserID, 0)) return "class='red'";
            return "";
        }

        public string GetADName(object adID)
        {
            if (adID == null) return "";
            long id = Utility.GetLong(adID, 0);
            if (id == 0) return "";
            Model.CP_Keyword_AD ad = adDAL.GetEntity(id);
            return ad.Name;
        }
    }
}