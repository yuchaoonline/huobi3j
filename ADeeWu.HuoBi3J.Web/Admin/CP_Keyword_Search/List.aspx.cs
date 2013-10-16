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
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Admin.CP_Keyword_Search
{

    /// <summary>
    /// 
    /// </summary>
    public partial class List : PageBase
    {
        public override string PageID
        {
            get
            {
                return "012003";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
                long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);
                string keyword = txtKeyword.Text;

                if (!IsPostBack)
                {
                    FillData((int)pageSize, (int)pageIndex, keyword);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            FillData((int)GlobalParameter.DataList_PageSize, 1, txtKeyword.Text);
        }

        private void FillData(int pageSize, int pageIndex, string keyword)
        {
            DAL.CP_Keyword_Search keywordDAL = new DAL.CP_Keyword_Search();
            keywordDAL.EnableRecordCount = true;
            if (string.IsNullOrEmpty(keyword))
                this.rpADList.DataSource = keywordDAL.Select(pageSize, pageIndex);
            else
                this.rpADList.DataSource = keywordDAL.Select(pageSize, pageIndex, string.Format("keyword like '%{0}%'", keyword), "");
            this.rpADList.DataBind();
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.TotalRecords = (int)keywordDAL.RecordCount;
            this.Pager1.AppendUrlParam("keyword", keyword);
        }
    }
}
