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

namespace ADeeWu.HuoBi3J.Web.Admin.CP_Keyword_AD
{

    /// <summary>
    /// 
    /// </summary>
    public partial class ADClickLog : PageBase
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
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);
            long id = WebUtility.GetRequestLong("id", 0);
            if (id == 0)
            {
                WebUtility.ShowAndGoBack(this, "参数有误！");
                return;                
            }
            if (!IsPostBack)
            {
                DAL.CP_Keyword_AD_Log logDAL = new DAL.CP_Keyword_AD_Log();
                logDAL.EnableRecordCount = true;

                this.rpADList.DataSource = logDAL.Select(pageSize, pageIndex, "adid=" + id, "");
                this.rpADList.DataBind();
                this.Pager1.PageSize = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageSize, 0);
                this.Pager1.PageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageIndex, 0);
                this.Pager1.TotalRecords = ADeeWu.HuoBi3J.Libary.Utility.GetInt(logDAL.RecordCount, 0);
            }
        }

        public string GetADName(object _id)
        {
            return WebUtility.GetRequestStr("name", "");
        }

        public string GetKeyword(object _id)
        {
            long id = Utility.GetLong(_id, 0);
            if (id == 0) return "";
            Model.CP_Keyword_Search search = new DAL.CP_Keyword_Search().GetEntity(id);
            if (search == null || search.ID == 0) return "";
            return search.Keyword;
        }
    }
}
