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
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.Keyword
{
    public partial class EditResult : Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Keyword-EditResult";
            }
        }

        DAL.CP_Keyword_Result dal = new ADeeWu.HuoBi3J.DAL.CP_Keyword_Result();
        DataBase db = DataBase.Create();
        long id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (!IsPostBack)
            {
                Model.CP_Keyword_Result mod = dal.GetEntity(id);//(new string[] { "ID", "PromotionID" }, id, this.LoginUser.PromotionID);
                if (mod == null) Response.Redirect(".");

                txtContent.Text = mod.Content;
                txtLink.Text = mod.Link;
                txtTitle.Text = mod.Title;
                hfID.Value = mod.ID.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                WebUtility.ShowMsg("标题不能为空！");
                return;
            }

            if (txtTitle.Text.Length > 30)
            {
                WebUtility.ShowMsg("标题长度不能超过30！");
                return;
            }

            if (string.IsNullOrEmpty(txtContent.Text))
            {
                WebUtility.ShowMsg("描述不能为空！");
                return;
            }

            if (txtContent.Text.Length > 100)
            {
                WebUtility.ShowMsg("描述长度不能超过100！");
                return;
            }


            if (string.IsNullOrEmpty(txtLink.Text))
            {
                WebUtility.ShowMsg("链接不能为空！");
                return;
            }

            Model.CP_Keyword_Result mod = dal.GetEntity(Convert.ToInt32(hfID.Value));
            mod.Content = txtContent.Text;
            mod.Title = txtTitle.Text;
            mod.Link = txtLink.Text;
            if (dal.Update(mod) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "编辑成功");
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作失败!请与我们联系!");
            }

        }
    }
}