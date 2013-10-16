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
    /// 商家代表用户登陆保持的会话状态
    /// </summary>
    public class CorpAgentSession : CorpSession
    {

        public long CorpAgentID = 0;
        /// <summary>
        /// 商家代表的审核状态
        /// </summary>
        public UserSessionCheckState CorpAgentState = UserSessionCheckState.NotAudit;

       
        private long _corpUserID = 0;
        public override long CorpUserID
        {
            get { return this._corpUserID; }
        }

        public string[][] Functions = new string[0][];

        public bool CheckPermission(string functionCode)
        {
            for (int i = 0; i < this.Functions.Length; i++)
            {
                if (string.Compare(this.Functions[i][0], functionCode, true) == 0)
                {
                    return this.Functions[i][1] == "0";
                }
            }
            return false;//当前页面没有设置权限,则返回false ,禁止使用
        }

        public CorpAgentSession(long corpAgentID, long userID, long corpUserID, string uin, string loginName, string email, long corpID, long cashTicketCorpID, long promotionCorpID, long shopID, bool isCashTicketPartner, bool isPromotionCorp, bool isShopSeller, string corpName)
            : base(userID, uin, loginName, email, corpID, cashTicketCorpID, promotionCorpID, shopID, isCashTicketPartner, isPromotionCorp, isShopSeller, corpName)
        {
            this._corpUserID = corpUserID;
            this.CorpAgentID = corpAgentID;
            this.UserType = 2;
        }

    }
}
