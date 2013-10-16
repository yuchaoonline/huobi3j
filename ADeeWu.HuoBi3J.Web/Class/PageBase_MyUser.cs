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
    /// 个人用户后台页面基类
    /// </summary>
    public class PageBase_MyUser : PageBase
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            //this.LoginUser = new UserSession(16, "admin");
            //UserSession.SaveSession(this.LoginUser);
            
            if (this.LoginUser == null)
            {
                Response.Redirect("/login.aspx?timeout=true&url=" + Server.UrlEncode(Request.Url.ToString()));
            }

            //商家代表权限检测
            CorpAgentSession corpAgentSession = this.LoginUser as CorpAgentSession;
            if (corpAgentSession != null)
            {
                if (!corpAgentSession.CheckPermission(this.FunctionCode))
                {
                    Class.Tips tips = new ADeeWu.HuoBi3J.Web.Class.Tips("当前用户没有访问权限", "当前商家代表用户没有通过审核该功能的访问", "/My/Corp/", "点击这里进入用户中心");
                    Class.Tips.SetTips(tips);
                    Class.Tips.Show();
                }
            }
        }

        /// <summary>
        /// 获取当前实际业务相关的UserID
        /// </summary>
        /// <remarks>
        /// 主要针对CorpAgentSession而使用
        /// CorpAgentSession 是代表CorpSession 进行业务操作
        /// 而所有业务操作都只跟CorpSession相关
        /// 开发用户可以根据System_Function表 的IsCorpAgentFunc字段来判断当前业务操作是否使用该函数
        /// </remarks>
        /// <returns></returns>
        protected long GetRealBusinessUserID()
        {
            if (this.LoginUser == null) return 0;
            Class.CorpAgentSession corpAgentSession = this.LoginUser as Class.CorpAgentSession;
            long userID = corpAgentSession == null ? this.LoginUser.UserID : corpAgentSession.CorpUserID;
            return userID;
        }
    }
}
