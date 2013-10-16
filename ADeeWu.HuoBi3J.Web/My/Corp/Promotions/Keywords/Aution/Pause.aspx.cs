using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords.Aution
{
    public partial class Pause : PageBase_MyCorp
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
                DAL.CP_Keyword_AD_Auction auctionDAL = new DAL.CP_Keyword_AD_Auction();
                Model.CP_Keyword_AD_Auction auction = auctionDAL.GetEntity(id);
                if (auction == null || auction.ID == 0)
                {
                    WebUtility.ShowMsg("无此竞价信息！");
                    return;
                }
                string msg = auction.IsPause.Value ? "开启成功！" : "屏蔽成功！";
                auction.IsPause = !auction.IsPause;
                if (auctionDAL.Update(auction) <= 0) msg = "操作失败！";
                WebUtility.ShowAndTopRedirect(this, msg, "Manager.aspx?id=" + auction.Keyword_AD_ID);
                return;
            }
        }
    }
}