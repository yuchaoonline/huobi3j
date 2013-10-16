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
    public partial class ServiceApplication : Class.PageBase_MyCorp
    {

        public override string FunctionCode
        {
            get
            {
                return "Corp-Promotions-ServiceApplication";
            }
        }

        ADeeWu.HuoBi3J.DAL.CP_Promotions dal = new ADeeWu.HuoBi3J.DAL.CP_Promotions();

        protected void Page_Load(object sender, EventArgs e)
        {
            ADeeWu.HuoBi3J.Model.CP_Promotions entity = dal.GetEntity(new string[] { "CorpID" }, new object[] { this.LoginUser.CorpID });
            if (entity != null)
            {
                this.txtTitle.Text = entity.Title;
                this.txtSummary.Text = ADeeWu.HuoBi3J.Libary.WebUtility.ToTextAreaContent(entity.Summary);
                this.txtUrl.Text = entity.Url;
                if (entity.CheckState == 1)
                {
                    this.liteTips.Text = "恭喜您已经通过审核！";
                }
                else
                {
                    this.liteTips.Text = "当前处于处理状态中,请耐心等候!";
                }
            }
            else
            {
                this.txtTitle.Text = this.LoginUser.CorpName;
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

            ADeeWu.HuoBi3J.Model.CP_Promotions entity = dal.GetEntity(this.LoginUser.CorpID);


          
            
            long ret = 0;
            if (entity == null)
            {
                entity = new ADeeWu.HuoBi3J.Model.CP_Promotions();
                entity.AdminUserID = 0;
                entity.CheckState = 0;
                entity.UserID = this.LoginUser.CorpUserID;
                entity.CorpID = this.LoginUser.CorpID;
                entity.Title = title;
                entity.Summary = ADeeWu.HuoBi3J.Libary.WebUtility.GetTextAreaContent(summary);
                entity.Url = url;
                entity.CreateTime = DateTime.Now;
                entity.ModifyTime = DateTime.Now;
                ret = dal.Add(entity);
            }
            else
            {
                entity.AdminUserID = 0;
                entity.CheckState = 0;
                entity.UserID = this.LoginUser.CorpUserID;
                entity.CorpID = this.LoginUser.CorpID;
                entity.Title = title;
                entity.Summary = ADeeWu.HuoBi3J.Libary.WebUtility.GetTextAreaContent(summary);
                entity.Url = url;
                entity.ModifyTime = DateTime.Now;
                ret = dal.Update(entity);
            }

            if (ret > 0)
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
