using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Aution
{
    public partial class DayCost : PageBase_MyCorp
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long id = WebUtility.GetRequestLong("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowAndGoBack(this, "参数有误！");
                    return;
                }
                Model.CP_Keyword_AD_Auction auction = new DAL.CP_Keyword_AD_Auction().GetEntity(id);
                if(auction==null||auction.ID==0){
                    WebUtility.ShowMsg("无此竞价信息！");
                    return;
                }
                txtTotalPriceDay.Text = auction.TotalPriceDay.ToString();
                lbTotalPrice.Text = auction.TotalPrice.ToString();
                hfID.Value = auction.ID.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long id = Utility.GetLong(hfID.Value, 0);
            if (id <= 0)
            {
                WebUtility.ShowMsg("数额要大于0！");
                return;
            }
            DAL.CP_Keyword_AD_Auction auctionDAL = new DAL.CP_Keyword_AD_Auction();
            Model.CP_Keyword_AD_Auction auction = auctionDAL.GetEntity(id);
            auction.TotalPriceDay = Utility.GetDecimal(txtTotalPriceDay.Text, 0);
            if (auctionDAL.Update(auction) > 0)
            {
                WebUtility.ShowMsg(this, "修改成功", "Manager.aspx?id=" + auction.Keyword_AD_ID);
                return;
            }
            else
            {
                WebUtility.ShowMsg(this, "修改失败！", "Manager.aspx?id=" + auction.Keyword_AD_ID);
                return;
            }
        }
    }
}