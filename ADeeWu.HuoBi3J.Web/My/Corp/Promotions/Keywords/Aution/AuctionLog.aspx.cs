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
    public partial class AuctionLog : PageBase_MyCorp
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
                long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);
                long id = WebUtility.GetRequestLong("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowAndGoBack(this, "参数有误！");
                    return;
                }

                DataBase db = DataBase.Create();
                this.rpADList.DataSource = db.Select("select l.*,ad.name,s.keyword from dbo.CP_Keyword_AD_Auction_Log l left join dbo.CP_Keyword_AD_Auction au on l.Keyword_Auction_ID = au.id left join dbo.CP_Keyword_Search s on au.keywordid = s.id left join dbo.CP_Keyword_AD ad on ad.id = au.keyword_ad_id where l.Keyword_AD_ID = " + id);
                this.rpADList.DataBind();
            }
        }
    }
}