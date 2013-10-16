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

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions
{
    public partial class Edit : Class.PageBase_MyCorp_Promotions
    {

        public override string FunctionCode
        {
            get
            {
                return "Corp-Promotions-Edit";
            }
        }
        
        ADeeWu.HuoBi3J.DAL.CP_Promotions dal = new ADeeWu.HuoBi3J.DAL.CP_Promotions();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ADeeWu.HuoBi3J.Model.CP_Promotions entity = dal.GetEntity(this.LoginUser.PromotionID);
                if (entity != null)
                {
                    this.txtTitle.Text = entity.Title;
                    this.txtSummary.Text = ADeeWu.HuoBi3J.Libary.WebUtility.ToTextAreaContent(entity.Summary);
                    this.txtUrl.Text = entity.Url;
                }
                else
                {
                    Response.Redirect("ServiceApplication.aspx");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = this.txtTitle.Text.Trim();
            string summary = this.txtSummary.Text.Trim();
            string url = this.txtUrl.Text.Trim();
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

            ADeeWu.HuoBi3J.Model.CP_Promotions entity = dal.GetEntity(this.LoginUser.PromotionID);
            if (entity == null)
            {
                Response.Redirect("ServiceApplication.aspx");
                return;
            }
            

            entity.CheckState = 0;
            entity.Title = title;
            entity.Summary = ADeeWu.HuoBi3J.Libary.WebUtility.GetTextAreaContent(summary);
            entity.Url = url;

            entity.ModifyTime = DateTime.Now;
            if (dal.Update(entity) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功！我们将会尽快为您处理，请耐心等候！");
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作失败！请与我们联系！");
                return;
            }
        }
    }
}
