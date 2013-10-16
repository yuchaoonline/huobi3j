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

namespace ADeeWu.HuoBi3J.Web.My.User.Keyword
{
    public partial class Edit : Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Keyword-Edit";
            }
        }

        DAL.CP_Keyword_Search dal = new ADeeWu.HuoBi3J.DAL.CP_Keyword_Search();
        DataBase db = DataBase.Create();
        long id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (!IsPostBack)
            {
                Model.CP_Keyword_Search mod = dal.GetEntity(id);
                txtKeyword.Text = mod.Keyword;
                if (mod == null) Response.Redirect(".");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string keyword = this.txtKeyword.Text.Trim();
            if (keyword.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "请填写关键字!");
                return;
            }

            Model.CP_Keyword_Search mod = dal.GetEntity(id);
            mod.Keyword = keyword;
            if (dal.Update(mod) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowAndGoBack(this, "修改成功");
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作失败!请与我们联系!");
            }

        }
    }
}