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
        /// 商家ID,如果该用户不是商家用户，则该ID为0
        /// </summary>
        public long CorpID = 0;

        /// <summary>
        /// 商家名称
        /// </summary>
        public string CorpName = string.Empty;

        /// <summary>
        /// 商家文件上传根目录
        /// </summary>
        public string CorpUploadFilePath = string.Empty;

        public CorpSession(long userID, string uin, string loginName, string email, long corpID, string corpName)
            : base(userID, uin, loginName, email, 1)
        {
            this.CorpName = corpName;
            this.CorpID = corpID;
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
