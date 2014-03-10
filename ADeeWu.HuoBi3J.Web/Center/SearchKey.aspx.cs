using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class SearchKey : System.Web.UI.Page
    {
        private int movebid = Utility.GetInt(System.Configuration.ConfigurationManager.AppSettings["movebid"], 0);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strKeyword = WebUtility.GetRequestStr("keyword", "");
                var m = WebUtility.GetRequestStr("m", "");
                if (string.IsNullOrWhiteSpace("输入搜索关键字")) strKeyword = "";

                if (m == "add")
                    AddKey(strKeyword);
                else
                    Search(strKeyword);
            }
        }

        private void AddKey(string strKeyword)
        {
            var key = new Model.Key
            {
                CreateTime = DateTime.Now,
                IsDefault = false,
                Name = strKeyword,
                KID=0,
            };
            var keyDAL = new DAL.Key();
            if (keyDAL.Exist("Name", key.Name))
            {
                WebUtility.ShowAndGoBack(this, "关键字已存在！");
                return;
            }

            if (keyDAL.Add(key) > 0)
                WebUtility.ShowMsg(this, "感谢你添加关键字！", "/");
            else
                WebUtility.ShowMsg("添加失败！");
        }

        private void ShowQuestionIndex()
        {
            var indexs = new DAL.Center_QuestionIndex().GetEntityList("", new string[] { }, new object[] { });
            var indexIDs = new List<long>();
            foreach (var item in indexs)
            {
                indexIDs.Add(item.QID.Value);
            }
            if (indexIDs.Count == 0) return;

            var db = DataBase.Create();
            db.EnableRecordCount = true;
            rpQuestionIndex.DataSource = db.Select("vw_Questions", string.Format("qid in ({0})", string.Join(",", indexIDs)), "createtime desc");
            rpQuestionIndex.DataBind();

            noresult.Visible = false;
        }

        private void Search(string KeyWord)
        {
            if (string.IsNullOrWhiteSpace(KeyWord))
            {
                ShowQuestionIndex();
                return;
            }

            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            DataBase db = DataBase.Create();

            var sql = string.Format(" KName like '%{0}%'", KeyWord);

            db.EnableRecordCount = true;
            var dt = db.Select(pageSize, pageIndex, "vw_Keys", "kid", sql, "QuestionCount desc");
            rpResult.DataSource = dt;
            rpResult.DataBind();

            this.Pager1.AppendUrlParam("keyword", KeyWord);
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;

            if (dt != null && dt.Rows.Count > 0)
            {
                noresult.Visible = false;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(KeyWord))
                    noresult.Visible = true;
            }
        }

        public string GetTitle(object title)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(title.ToString());
            return doc.DocumentNode.InnerText;
        }
    }
}