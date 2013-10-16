using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ADeeWu.HuoBi3J.Web.Class
{
    /// <summary>
    /// 商家用户登陆保持的会话状态
    /// </summary>
    public class CorpSession : UserSession
    {
        /// <summary>
        /// 企业审核状态
        /// </summary>
        public UserSessionCheckState CorpCheckState = UserSessionCheckState.NotAudit;
        
        /// <summary>
        /// 现金券服务商家ID
        /// </summary>
        public long CashTicketCorpID = 0;

        /// <summary>
        /// 推广服务商家ID
        /// </summary>
        public long PromotionID = 0;
        
        /// <summary>
        /// 商家ID,如果该用户不是商家用户，则该ID为0
        /// </summary>
        public long CorpID = 0;

        /// <summary>
        /// 商家名称
        /// </summary>
        public string CorpName = string.Empty;

        /// <summary>
        /// 是否为现金券合作商家
        /// </summary>
        public bool IsCashTicketPartner = false;

        /// <summary>
        /// 是否为推广商家
        /// </summary>
        public bool IsPromotionCorp = false;

        /// <summary>
        /// 商家文件上传根目录
        /// </summary>
        public string CorpUploadFilePath = string.Empty;

        /// <summary>
        /// 是否商铺卖家
        /// </summary>
        public bool IsShopSeller = false;

        /// <summary>
        /// 商铺ID
        /// </summary>
        public long ShopID = 0;

        public CorpSession(long userID, string uin, string loginName, string email, long corpID, long cashTicketCorpID, long promotionCorpID, long shopID, bool isCashTicketPartner, bool isPromotionCorp, bool isShopSeller, string corpName)
            : base(userID, uin, loginName, email, 1)
        {
            this.CorpName = corpName;
            this.CorpID = corpID;
            this.CashTicketCorpID = cashTicketCorpID;
            this.PromotionID = promotionCorpID;
            this.ShopID = shopID;
            this.IsCashTicketPartner = isCashTicketPartner;
            this.IsPromotionCorp = isPromotionCorp;
            this.IsShopSeller = isShopSeller;
            this.UserType = 1;
            this.CorpUploadFilePath = "/uploadFiles/Corp/" + this.UIN + "/";
        }

        /// <summary>
        /// 商家个人用户ID,区别于当前UserID(商家代表个人用户UserID)
        /// </summary>
        public virtual long CorpUserID
        {
            get { return this.UserID; }
        }
    }
}
