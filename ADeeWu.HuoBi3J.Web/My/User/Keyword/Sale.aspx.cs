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
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.Keyword
{
    public partial class Sale : Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Keyword-Sale";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long id = WebUtility.GetRequestLong("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowAndGoBack(this, "参数错误！");
                    return;
                }
                Model.CP_Keyword_Search keyword = new DAL.CP_Keyword_Search().GetEntity(id);
                if (keyword == null || keyword.ID == 0)
                {
                    WebUtility.ShowAndGoBack(this, "不存在此关键字！");
                    return;
                }
                hfKeywordID.Value = keyword.ID.ToString();
                lbKeyword.Text = keyword.Keyword;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                WebUtility.ShowMsg("请输入转让人的用户名！");
                return;
            }
            DAL.CP_Keyword_Search keywordDAL = new DAL.CP_Keyword_Search();
            WebUtility.ShowMsg(keywordDAL.SaleKeyword(Utility.GetLong(hfKeywordID.Value, 0), txtUserName.Text));
            return;
        }
    }
}