using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.SearchCorpAgents
{

    public partial class Partner : Class.PageBase_MyCorp
    {
        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = WebUtility.GetRequestInt("page", 1);
            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);

            db.EnableRecordCount = true;
            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CA_QuaAgentInCorps", "id", string.Format("CorpID={0}", this.LoginUser.CorpID), "");
            this.gvData.DataBind();

            this.Pager1.PageSize= (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;
        }
    }
}
