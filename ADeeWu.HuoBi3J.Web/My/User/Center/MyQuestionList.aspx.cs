using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class MyQuestionList : PageBase_MyUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Search(base.LoginUser.UserID);
            }
        }

        private void Search(long uid)
        {
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            DataBase db = DataBase.Create();

            db.EnableRecordCount = true;
            db.Parameters.Append("UID", uid);
            var dt = db.Select(pageSize, pageIndex, "vw_Questions", "QID", "UID=@UID", "");
            rpQuestions.DataSource = dt;
            rpQuestions.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        DAL.AttentionQuestion aqDAL = new DAL.AttentionQuestion();
        public string IsRead(object _qid)
        {
            var returnValue = "无新回复";
            if (aqDAL.Exist(string.Format("uid={0} and qid={1} and isread=0", LoginUser.UserID, _qid)))
            {
                returnValue = string.Format("<a style='color: red;' href='/center/question.aspx?qid={0}'>有新回复</a>", _qid);
            }
            return returnValue;
        }

        public string GetTitle(object title)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(title.ToString());
            return doc.DocumentNode.InnerText;
        }
    }
}