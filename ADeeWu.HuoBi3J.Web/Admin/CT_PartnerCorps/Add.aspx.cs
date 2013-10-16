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
    public partial class Add : PageBase
    {


        public override string PageID
        {
            get
            {
                return "008001";
            }
        }

        ADeeWu.HuoBi3J.DAL.Admin_Users dalAdminUser = new ADeeWu.HuoBi3J.DAL.Admin_Users();
        ADeeWu.HuoBi3J.DAL.Corporations dalCorp = new ADeeWu.HuoBi3J.DAL.Corporations();
        ADeeWu.HuoBi3J.DAL.CT_PartnerCorps dalParnterCorp = new ADeeWu.HuoBi3J.DAL.CT_PartnerCorps();

        protected long corpID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            corpID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("corpid",0);

            if (!IsPostBack)
            {

                this.ddlCorp.DataSource = dalCorp.Select(-1, -1);
                this.ddlCorp.DataBind();
                if (corpID > 0)
                {
                    if (dalParnterCorp.Exist("id", corpID))
                    {
                        Response.Redirect("Edit.aspx?id=" + corpID);
                        return;
                    }
                    this.ddlCorp.SelectedValue = corpID.ToString();
                }

                ADeeWu.HuoBi3J.Model.Corporations corp = dalCorp.GetEntity(corpID);
                this.liteCorpCalling.Text = corp.Calling;

                ADeeWu.HuoBi3J.Model.Admin_Users entAdminUser = dalAdminUser.GetEntity(corp.AdminUserID);
                if (entAdminUser != null)
                {
                    this.litAdminUser.Text = entAdminUser.LoginName;
                }
                this.litCrateTime.Text = corp.CreateTime.ToString();
                this.litModifyTime.Text = corp.ModifyTime.ToString();
            }
            
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
           
            corpID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(this.ddlCorp.SelectedValue, 0);

            if (corpID <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "请选择开通现金返还服务的商家");
                return;
            }

          

            int offerPercent = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtOfferPercent.Text, -1);
            
            if (offerPercent < 0 || offerPercent > 100)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写正确商家所提供的提成百分比!");
                return;
            }

            ADeeWu.HuoBi3J.Model.CT_PartnerCorps modPartnerCorp = new ADeeWu.HuoBi3J.Model.CT_PartnerCorps();
            modPartnerCorp.CorpID = corpID;
            modPartnerCorp.AdminUserID = base.LoginUser.UserID;

            
            modPartnerCorp.CheckState = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.ddlCheckState.SelectedValue, 0);


            modPartnerCorp.CreateTime = DateTime.Now;
            modPartnerCorp.ModifyTime = DateTime.Now;
            modPartnerCorp.OfferPercent = offerPercent;

            long newid = dalParnterCorp.Add(modPartnerCorp);
            if (newid > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功!", "Edit.aspx?id=" + newid);
            }
        }

    }
}
