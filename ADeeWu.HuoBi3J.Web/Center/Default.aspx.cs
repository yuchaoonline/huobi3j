﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class Default : System.Web.UI.Page
    {
        private int movebid = Utility.GetInt(System.Configuration.ConfigurationManager.AppSettings["movebid"], 0);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strKeyword = WebUtility.GetRequestStr("keyword", "");
                if (string.IsNullOrWhiteSpace("输入搜索关键字")) strKeyword = "";
                Search(strKeyword);
            }
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
            var pid = WebUtility.GetRequestInt("province", -1);
            var cid = WebUtility.GetRequestInt("city", -1);
            var aid = WebUtility.GetRequestInt("area", -1);
            syncSelectorLocation.Values = new string[] { pid.ToString(), cid.ToString(), aid.ToString() };

            if (string.IsNullOrWhiteSpace(KeyWord) && pid == -1 && cid == -1 && aid == -1)
            {
                ShowQuestionIndex();
                return;
            }

            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            DataBase db = DataBase.Create();

            var sql = "1=1 and bid != " + movebid;
            if (!string.IsNullOrEmpty(KeyWord)) sql += string.Format(" and (KName like '%{0}%' or BName like '%{0}%')", KeyWord);
            if (aid != -1)
            {
                sql += " and aid=" + aid;
                this.Pager1.AppendUrlParam("area", aid.ToString());
            }
            if (cid != -1)
            {
                sql += " and cid=" + cid;
                this.Pager1.AppendUrlParam("city", cid.ToString());
            }
            if (pid != -1)
            {
                sql += " and pid=" + pid;
                this.Pager1.AppendUrlParam("province", pid.ToString());
            }

            db.EnableRecordCount = true;
            var dt = db.Select(pageSize, pageIndex, "vw_Keys", "kid", sql, "QuestionCount desc,BCreateTime");
            rpResult.DataSource = dt;
            rpResult.DataBind();

            this.Pager1.AppendUrlParam("keyword", KeyWord);
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;

            var sql2 = string.Format("(KName like '%{0}%' or BName like '%{0}%') and bid={1}", KeyWord, Utility.GetInt(System.Configuration.ConfigurationManager.AppSettings["movebid"], 0));
            var defaultData = db.Select(20, 1, "vw_Keys", "kid", sql2, "QuestionCount desc,BCreateTime");
            rpDefaultCenter.DataSource = defaultData;
            rpDefaultCenter.DataBind();

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