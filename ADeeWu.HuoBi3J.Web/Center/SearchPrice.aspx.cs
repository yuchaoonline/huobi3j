﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;
using ADeeWu.HuoBi3J.Web.Class;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class SearchPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strKeyword = WebUtility.GetRequestStr("keyword", "");
                if (string.IsNullOrWhiteSpace(strKeyword)) return;
                Search(strKeyword);
            }
        }

        private void Search(string Keyword)
        {
            //if (!Utility.IsNumeric(Keyword))
            //{
            //    WebUtility.ShowMsg("输入的文字应为价格！");
            //    return;
            //}

            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            var db = DataBase.Create();
            db.EnableRecordCount = true;
            db.Parameters.Append("pname", AccountHelper.Province);
            db.Parameters.Append("cname", AccountHelper.City);
            rpResult.DataSource = db.Select(pageSize, pageIndex, "vw_Key_Product", "ID", string.Format("cname=@cname and pname=@pname and kname like '%{0}%'", Keyword), "");
            rpResult.DataBind();

            this.Pager1.AppendUrlParam("keyword", Keyword);
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }

        public string GetMoney(object mon)
        {
            return Utility.GetDecimal(mon, 0).ToString("F2");
        }
    }
}