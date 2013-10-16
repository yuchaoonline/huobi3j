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
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.Keyword
{
    public partial class Manager : Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Keyword-Manager";
            }
        }

        DAL.CP_Keyword_Result dal = new DAL.CP_Keyword_Result();
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            if (!IsPostBack)
            {
                long id = WebUtility.GetRequestLong("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowAndGoBack(this, "参数错误！");
                    return;
                }
                hfKeywordID.Value = id.ToString();

                DataTable dt = db.Select("select r.id,r.title,r.content,r.link,'count'=(select count(*) from cp_keyword_result_click c where c.keywordresultid = r.id) from cp_keyword_result r where keywordid = " + id);
                rpResultList.DataSource = dt;
                rpResultList.DataBind();

                this.Pager1.PageIndex = (int)pageIndex;
                this.Pager1.PageSize = (int)pageSize;
                this.Pager1.TotalRecords = dt.Rows.Count;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfKeywordID.Value))
            {
                WebUtility.ShowMsg("参数错误，请刷新重试！");
                return;
            }

            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                WebUtility.ShowMsg("标题不能为空！");
                return;
            }

            if (txtTitle.Text.Length >30)
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

            Model.CP_Keyword_Result result = new Model.CP_Keyword_Result
            {
                Content = txtContent.Text,
                KeywordID = Utility.GetLong(hfKeywordID.Value, 0),
                Link = txtLink.Text,
                Title = txtTitle.Text
            };
            if (dal.Add(result) > 0)
            {
                WebUtility.ShowAndTopRedirect(this, ("添加成功！"), Request.RawUrl);
                return;
            }
            else
            {
                WebUtility.ShowMsg("添加失败！");
                return;
            }
        }
    }
}