using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CashTickets
{
    public partial class ServiceApplication : Class.PageBase_MyCorp
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.LoginUser.IsCashTicketPartner)
            {
                Class.Tips tips = new ADeeWu.HuoBi3J.Web.Class.Tips("操作错误,您已开通现金返还服务!", "", "/My/Corp/CashTickets/", "请点击返回现金返还服务首页");
                Class.Tips.SetTips(tips);
                Class.Tips.Show();
            }
            else
            {
                if (!IsPostBack)
                {
                    DAL.Corporations dalCorp = new ADeeWu.HuoBi3J.DAL.Corporations();
                    Model.Corporations modCorp = dalCorp.GetEntity(this.LoginUser.CorpID);
                    this.liteCorpName.Text = modCorp.CorpName;
                    this.liteIndustry.Text = modCorp.Calling;
                    this.liteLocation.Text = string.Format("{0} {1} {2}", modCorp.Province, modCorp.City, modCorp.Area);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //int offerPercent = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtOfferPercent.Text, 0);
            //if (offerPercent <= 0)
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "请填写正确的返还百分比");
            //    return;
            //}

            DAL.CT_PartnerCorps dal = new ADeeWu.HuoBi3J.DAL.CT_PartnerCorps();
            Model.CT_PartnerCorps mod = dal.GetEntity(new string[] { "CorpID" }, this.LoginUser.CorpID);

            bool isExist = false;
            if (mod == null)
            {
                isExist = false;
                mod = new ADeeWu.HuoBi3J.Model.CT_PartnerCorps();

                mod.CorpID = this.LoginUser.CorpID;
                mod.OfferPercent = 0; //offerPercent;

                mod.Contract = ADeeWu.HuoBi3J.Libary.WebUtility.GetTextAreaContent(this.txtContract.Text.Trim());
                mod.CheckState = 0;
                mod.AdminUserID = 0;
                mod.CreateTime = DateTime.Now;
                mod.ModifyTime = DateTime.Now;
            }
            else
            {
                isExist = true;
            }

         

            long ret = isExist ? dal.Update(mod) : dal.Add(mod);
           
            if (ret > 0)
            {

                Class.Tips tips = new ADeeWu.HuoBi3J.Web.Class.Tips("操作成功,您已申请开通现金返还服务,我们将尽快为您处理!", "如若你得知已经通过审核,请重新登陆使用现金返还服务!", "/My/Corp/", "请点击返回用户中心");
                Class.Tips.SetTips(tips);
                Class.Tips.Show();
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "抱歉，操作失败！请与我们联系！");
            }
        }
    }
}
