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
    /// 商家用户后台- 商铺管理 - 页面基类
    /// </summary>
    public class PageBase_MyCorp_Shop : PageBase_MyCorp
    {
       
        protected override void OnPreInit(EventArgs e)
        {            
            base.OnPreInit(e);
            if (!this.LoginUser.IsShopSeller)
            {
                Class.Tips tips = new Tips("您还没有申请开通营销商铺","开通商铺寻找更多的商机,开阔你的销售市场！","/My/Corp/Shop/","请点击申请开通");
                Class.Tips.SetTips(tips);
                Class.Tips.Show();
            }
        }
    }
}
