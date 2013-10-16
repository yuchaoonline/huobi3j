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
    /// 商家用户后台- 商家推广 - 页面基类
    /// </summary>
    public class PageBase_MyCorp_Promotions : PageBase_MyCorp
    {
       
        protected override void OnPreInit(EventArgs e)
        {            
            base.OnPreInit(e);
            if (!this.LoginUser.IsPromotionCorp)
            {
                Class.Tips tips = new Tips("您还没有申请开通商家推广服务","开通商家推广服务,能使更多的人找到您的信息","/My/Corp/Promotions/ServiceApplication.aspx","请点击申请开通");
                Class.Tips.SetTips(tips);
                Class.Tips.Show();
            }
        }
    }
}
