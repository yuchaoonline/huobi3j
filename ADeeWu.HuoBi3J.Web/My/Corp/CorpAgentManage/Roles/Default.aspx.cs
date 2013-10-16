using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.Roles
{
   
    /// <summary>
    /// 角色列表页
    /// </summary>
    public partial class Default : Class.PageBase_MyCorp
    {
        public override string FunctionCode
        {
            get
            {
                return "CorpAgentManage-Roles-Default";
            }
        }


        DAL.CA_Roles dalRoles = new ADeeWu.HuoBi3J.DAL.CA_Roles();
        DataBase db = DataBase.Create();


        protected void Page_Load(object sender, EventArgs e)
        {
            long pageSize = Utility.GetLong(Request["pagesize"], GlobalParameter.DataList_PageSize, 50);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            if (!IsPostBack)
            {
                dalRoles.EnableRecordCount = true;
                this.gvData.DataSource = dalRoles.Select(pageSize, pageIndex, "ManagerCorpID=" + this.LoginUser.CorpID, "");
                this.gvData.DataBind();
                this.Pager1.PageSize = (int)pageSize;
                this.Pager1.PageIndex = (int)pageIndex;
                this.Pager1.TotalRecords = (int)dalRoles.RecordCount;
                dalRoles.EnableRecordCount = false;
            }
        }

        protected int NumOfUsersInRole(long roleID, long corpID)
        {
            return Utility.GetInt(db.ExecuteScalar("select count(id) from CorpAgents where AgentCorpID=" + corpID + " and RoleID=" + roleID), 0);
        }

       
    }
}
