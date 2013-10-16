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

namespace ADeeWu.HuoBi3J.Web.Admin.CP_Promotions
{
    public partial class Edit : PageBase
    {


        public override string PageID
        {
            get
            {
                return "010002";
            }
        }

        ADeeWu.HuoBi3J.DAL.Admin_Users dalAdminUser = new ADeeWu.HuoBi3J.DAL.Admin_Users();
        ADeeWu.HuoBi3J.DAL.Corporations dalCorp = new ADeeWu.HuoBi3J.DAL.Corporations();
        ADeeWu.HuoBi3J.DAL.CP_Promotions dalPromotion = new ADeeWu.HuoBi3J.DAL.CP_Promotions();

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

                ADeeWu.HuoBi3J.Model.CP_Promotions entity = dalPromotion.GetEntity(id);
                if (entity == null)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "没有找到相关记录", "list.aspx");
                    return;
                }

                this.txtTitle.Text = entity.Title;
                this.txtSummary.Text = ADeeWu.HuoBi3J.Libary.WebUtility.ToTextAreaContent(entity.Summary);
                this.txtURL.Text = entity.Url;
                this.litCrateTime.Text = entity.CreateTime.ToString();
                this.litModifyTime.Text = entity.ModifyTime.ToString();
                this.ddlCheckState.SelectedValue = entity.CheckState.ToString();

                this.ddlAminiUser.DataSource= dalAdminUser.Select(-1, -1);
                this.ddlAminiUser.DataValueField = "ID";
                this.ddlAminiUser.DataTextField = "Name";
                this.ddlAminiUser.DataBind();
                this.ddlAminiUser.Items.Insert(0, new ListItem("请选择", "0"));
                this.ddlAminiUser.SelectedValue = entity.AdminUserID.ToString();

                ADeeWu.HuoBi3J.Model.Corporations corp = dalCorp.GetEntity(entity.CorpID);
                if (corp != null)
                {
                    this.liteCorpCalling.Text = corp.Calling;
                    this.liteCorpName.Text = corp.CorpName;
                }
                


               
            }

        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string title = this.txtTitle.Text.Trim();
            string summary = this.txtSummary.Text.Trim();
            string url = this.txtURL.Text.Trim();
            if (title.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "公司名称不能为空！");
                return;
            }

            if (summary.Length == 0 || summary.Length > 100)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "公司简介不能为空，或超出100个字符的长度！");
                return;
            }
            if (url.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "公司官方网站地址不能为空！");
                return;
            }


            ADeeWu.HuoBi3J.Model.CP_Promotions entity = dalPromotion.GetEntity(id);
            if (entity == null) return;
            entity.AdminUserID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(this.ddlAminiUser.SelectedValue, 0);
            entity.CheckState = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.ddlCheckState.SelectedValue, 0);
            entity.Title = title;
            entity.Summary = ADeeWu.HuoBi3J.Libary.WebUtility.GetTextAreaContent(summary);
            entity.Url = url;


            if (dalPromotion.Update(entity) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功!", "Edit.aspx?id=" + id);
            }
        }

    }
}
