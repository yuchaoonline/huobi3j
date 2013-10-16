using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp
{
    public partial class Service : Class.PageBase_MyCorp
    {

        public override string FunctionCode
        {
            get
            {
                return "Corp-Service";
            }
        }


        DAL.Corporations dalCorp = new ADeeWu.HuoBi3J.DAL.Corporations();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.Corporations entCorp = dalCorp.GetEntity(this.LoginUser.CorpID);
                if (entCorp != null)
                {
                    this.txtContent.Text = WebUtility.GetTextAreaContent(entCorp.Service);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string service = WebUtility.GetTextAreaContent(this.txtContent.Text).Trim();
            if (service.Length == 0)
            {
                WebUtility.ShowMsg(this, "请填写公司特色服务或经营范围！");
                return;
            }

            if (dalCorp.Update("Service", service, "ID=" + this.LoginUser.CorpID) > 0)
            {
                WebUtility.ShowMsg(this, "操作成功！");
            }
            else
            {
                WebUtility.ShowMsg(this, "操作失败，请与我们联系！");
            }
        }
    }
}
