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
using System.Collections.Generic;
using System.Text;

namespace ADeeWu.HuoBi3J.Web.Admin.CT_PartnerCorps
{
    public partial class Edit : PageBase
    {


        public override string PageID
        {
            get
            {
                return "008002";
            }
        }

        ADeeWu.HuoBi3J.DAL.Admin_Users dalAdminUser = new ADeeWu.HuoBi3J.DAL.Admin_Users();
        ADeeWu.HuoBi3J.DAL.Corporations dalCorp = new ADeeWu.HuoBi3J.DAL.Corporations();
        ADeeWu.HuoBi3J.DAL.CT_PartnerCorps dalParnterCorp = new ADeeWu.HuoBi3J.DAL.CT_PartnerCorps();

        protected long id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (id <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "错误参数传递", "list.aspx");
                return;
            }
            
            if (!IsPostBack)
            {

                ADeeWu.HuoBi3J.Model.CT_PartnerCorps partnerCorp = dalParnterCorp.GetEntity(id);
                if (partnerCorp == null)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "没有找到相关记录", "list.aspx");
                    return;
                }

                ADeeWu.HuoBi3J.Model.Corporations corp = dalCorp.GetEntity(partnerCorp.CorpID);
                if (corp == null)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "该商家用户记录已不存在!", "list.aspx");
                    return;
                }

                this.liteCorpName.Text = corp.CorpName;
                this.liteCorpCalling.Text = corp.Calling;


                ADeeWu.HuoBi3J.Model.Admin_Users entAdminUser = dalAdminUser.GetEntity(corp.AdminUserID);
                if (entAdminUser != null)
                {
                    this.litAdminUser.Text = entAdminUser.LoginName;
                }

                this.txtOfferPercent.Text = partnerCorp.OfferPercent.ToString();
                this.litCrateTime.Text = partnerCorp.CreateTime.ToString();
                this.litModifyTime.Text = partnerCorp.ModifyTime.ToString();
                this.ddlCheckState.SelectedValue = partnerCorp.CheckState.ToString();
            }

        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            int offerPercent = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtOfferPercent.Text, -1);

            if (offerPercent < 0 || offerPercent > 100)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写正确商家所提供的提成百分比!");
                return;
            }

            ADeeWu.HuoBi3J.Model.CT_PartnerCorps modPartnerCorp = dalParnterCorp.GetEntity(id);
            modPartnerCorp.AdminUserID = base.LoginUser.UserID;
            modPartnerCorp.CheckState = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.ddlCheckState.SelectedValue, 0);
            modPartnerCorp.ModifyTime = DateTime.Now;
            modPartnerCorp.OfferPercent = offerPercent;


            if (dalParnterCorp.Update(modPartnerCorp) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功!", "Edit.aspx?id=" + id);
            }
        }

    }
}
