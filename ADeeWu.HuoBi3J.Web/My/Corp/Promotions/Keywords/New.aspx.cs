using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords
{
    public partial class New : Class.PageBase_MyCorp_Promotions
    {

        public override string FunctionCode
        {
            get
            {
                return "Corp-Promotions-Keywords-New";
            }
        }

        DAL.CP_Keywords dal = new ADeeWu.HuoBi3J.DAL.CP_Keywords();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string keyword = this.txtKeyword.Text.Trim();
            int coins = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtCoins.Text, 0);
            if (keyword.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "请填写关键字!");
                return;
            }
            if (coins < 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "请填写正确的竞价货币数值!");
                return;
            }

            Model.CP_Keywords mod = new ADeeWu.HuoBi3J.Model.CP_Keywords();
            mod.Keyword = this.txtKeyword.Text.Trim();
            mod.Coins = coins;
            mod.PromotionID = this.LoginUser.PromotionID;
            mod.UserID = this.LoginUser.UserID;
            mod.CreateTime = DateTime.Now;
            mod.ModifyTime = DateTime.Now;
            mod.CheckState = 0;//默认需要通过审核
            mod.VisitCount = 0;
            if (dal.Add(mod) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "添加成功","Default.aspx");
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作失败!请与我们联系!");
            }

        }


    }
}