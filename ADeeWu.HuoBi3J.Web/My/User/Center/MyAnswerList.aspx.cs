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
    public partial class MyAnswerList : PageBase_MyUser
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
            var dt = db.Select(pageSize, pageIndex, "vw_AttentionQuestions", "ID", "UID=@UID", "");
            rpAnswers.DataSource = dt;
            rpAnswers.DataBind();

            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        public string GetReadStatue(object IsRead)
        {
            if (IsRead.ToString().ToLower() == "false") return "<em>未读</em>";
            return "<em>已读</em>";
        }

        public string GetReplyStatue(object IsReply)
        {
            if (IsReply.ToString().ToLower() == "false") return "<em>未回复</em>";
            return "<em>已回复</em>";
        }

        public string GetTitle(object title)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(title.ToString());
            return doc.DocumentNode.InnerText;
        }
    }
}