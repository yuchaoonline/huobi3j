using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.Users
{
    /// <summary>
    /// 商家代表列表页,需要显示用户角色
    /// </summary>
    public partial class Default : Class.PageBase_MyCorp
    {
        DataBase db = DataBase.Create();
        long pageSize = 20;
        long pageIndex = 1;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            pageIndex = WebUtility.GetRequestInt("page", 1);
            pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 20);

            this.gvData.DataSource = db.Select(pageSize, pageIndex, "vw_CorpAgents", "id", "AgentCorpID=" + this.LoginUser.CorpID, "");
            this.gvData.DataBind();
        }
    }
}
