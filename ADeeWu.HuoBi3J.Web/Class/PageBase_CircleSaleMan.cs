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
    /// 货比三家业务员
    /// </summary>
    public class PageBase_CircleSaleMan : PageBase
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);

            if (this.LoginUser == null)
            {
                Response.Redirect("/login.aspx?timeout=true&url=" + Server.UrlEncode(Request.Url.ToString()));
            }

            //商家代表权限检测
            if (!SaleManSession.IsSaleMan)
            {
                Class.Tips tips = new ADeeWu.HuoBi3J.Web.Class.Tips("当前用户没有访问权限", "当前用户不是货比三家业务员或者审核通过请重新登录", "/my/user/center/RegSaleMan.aspx", "点击注册");
                Class.Tips.SetTips(tips);
                Class.Tips.Show();
            }
        }
    }
}
