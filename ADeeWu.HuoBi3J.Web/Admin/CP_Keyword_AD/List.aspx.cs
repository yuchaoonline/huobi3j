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
            DAL.CP_Keyword_AD adDAL = new DAL.CP_Keyword_AD();
            adDAL.EnableRecordCount = true;
            
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            this.rpADList.DataSource = adDAL.Select(pageSize, pageIndex, "IsPass asc");
            this.rpADList.DataBind();
            this.Pager1.PageSize = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageSize, 0);
            this.Pager1.PageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageIndex, 0);
            this.Pager1.TotalRecords = ADeeWu.HuoBi3J.Libary.Utility.GetInt(adDAL.RecordCount, 0);
        }

        public string GetUserName(object userID)
        {
            long userid = Utility.GetLong(userID,0);
            if(userid==0)return string.Empty;
            Model.Users user = new DAL.Users().GetEntity(userid);
            if (user == null || user.ID == 0) return string.Empty;
            return user.LoginName;
        }
    }
}
