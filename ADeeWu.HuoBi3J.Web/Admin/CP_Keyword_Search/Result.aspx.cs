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
    public partial class Result : PageBase
    {
        public override string PageID
        {
            get
            {
                return "012003";
            }
        }
        DAL.CP_Keyword_Result dal = new DAL.CP_Keyword_Result();
        DataBase db = DataBase.Create();
        public long id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", GlobalParameter.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            if (!IsPostBack)
            {
                id = WebUtility.GetRequestLong("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowAndGoBack(this, "参数错误！");
                    return;
                }

                DataTable dt = db.Select("select r.id,r.title,r.content,r.link,'count'=(select count(*) from cp_keyword_result_click c where c.keywordresultid = r.id) from cp_keyword_result r where keywordid = " + id);
                rpResultList.DataSource = dt;
                rpResultList.DataBind();

                this.Pager1.PageIndex = (int)pageIndex;
                this.Pager1.PageSize = (int)pageSize;
                this.Pager1.TotalRecords = dt.Rows.Count;
                this.Pager1.AppendUrlParam("id", id.ToString());
            }
        }
    }
}
