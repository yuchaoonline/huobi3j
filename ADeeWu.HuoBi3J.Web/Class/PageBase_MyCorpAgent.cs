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
    /// 商家用户后台页面基类
    /// </summary>
    public class PageBase_MyCorpAgent : PageBase
    {
        private CorpSession loginUser = null;
        public new CorpSession LoginUser
        {
            get { return loginUser; }
            set { loginUser = value; }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            //未登陆
            UserSession session = UserSession.GetSession();
            if (session == null)
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
            else
            {
                Class.Tips tips = new ADeeWu.HuoBi3J.Web.Class.Tips("当前用户还没有申请成为商家代表!", "如果您已提交申请成为商家代表，但是还没有通过审核，请耐心等待处理或者直接与我们联系。", "/My/User/CorpAgent/?url=" + Server.UrlEncode(Request.Url.ToString()), "点击这里申请商家代表");
                Class.Tips.SetTips(tips);
                Class.Tips.Show();
            }
        }
        
    }
}
