using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.HireInfos
{
    
    public partial class Default : Class.PageBase_MyCorp
    {
        DAL.CA_HireInfos dal = new DAL.CA_HireInfos();
        long pageSize = 20;
        long pageIndex = 1;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = WebUtility.GetRequestInt("page", 1);
            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);

            dal.EnableRecordCount = true;
            this.gvData.DataSource = dal.Select(pageSize, pageIndex, "CorpID=" + this.LoginUser.CorpID, "");
            this.gvData.DataBind();

            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.TotalRecords = (int)dal.RecordCount;
        }
    }
}
