using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.Roles
{
    /// <summary>
    /// 角色添加并设置权限
    /// </summary>
    public partial class New : Class.PageBase_MyCorp
    {

        public override string FunctionCode
        {
            get
            {
                return "CorpAgentManage-Roles-New";
            }
        }

        DAL.CA_Roles dalRoels = new ADeeWu.HuoBi3J.DAL.CA_Roles();
        DAL.CA_RolePermissions dalRolePermission = new ADeeWu.HuoBi3J.DAL.CA_RolePermissions();
        DAL.System_Functions dalFunctions = new ADeeWu.HuoBi3J.DAL.System_Functions();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.gvData.DataSource = dalFunctions.Select(-1, -1, "IsCorpAgentFunc=1", "Name");
                this.gvData.DataBind();

            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string roleName = this.txtRoleName.Text.Trim();
            string description = this.txtDescription.Text.Trim();


            if (roleName == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("角色名称不能为空!");
                return;
            }

            if (dalRoels.Exist(new string[] { "RoleName", "ManagerCorpID" }, new object[] { roleName, this.LoginUser.CorpID }))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("角色已存在!");
                return;
            }

            Model.CA_Roles entRole = new ADeeWu.HuoBi3J.Model.CA_Roles();
            entRole.RoleName = roleName;
            entRole.Description = this.txtDescription.Text;
            entRole.ManagerCorpID = this.LoginUser.CorpID;

            if (dalRoels.Add(entRole) <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("添加失败!");
                return;
            }



            long[] alowFunctionIDGroup = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLongGroups("alowFunctionID", 0);
            foreach (long functionID in alowFunctionIDGroup)//设置角色所拥有的权限
            {
                if (functionID > 0)
                {
                    Model.CA_RolePermissions entRolePermission = new Model.CA_RolePermissions();
                    entRolePermission.FunctionID = functionID;
                    entRolePermission.RoleID = entRole.ID;
                    entRolePermission.AuthorizeState = 0;
                    entRolePermission.ManagerCorpID = this.LoginUser.CorpID;
                    dalRolePermission.Add(entRolePermission);
                }
            }

            long[] denyFunctionIDGroup = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLongGroups("denyFunctionID", 0);
            foreach (long functionID in denyFunctionIDGroup)//设置角色所拒绝的权限
            {
                if (functionID > 0 &&
                    !InGroup(functionID, alowFunctionIDGroup)//防止绕过脚本导致同一个功能既有允许也有拒绝的授权
                    )
                {
                    Model.CA_RolePermissions entRolePermission = new Model.CA_RolePermissions();
                    entRolePermission.FunctionID = functionID;
                    entRolePermission.RoleID = entRole.ID;
                    entRolePermission.AuthorizeState = 1;
                    entRolePermission.ManagerCorpID = this.LoginUser.CorpID;
                    dalRolePermission.Add(entRolePermission);
                }
            }


            ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "添加成功!选择\"是\"继续操作,选择否修改该记录!", "New.aspx", "edit.aspx?id" + entRole.ID);


        }

        bool InGroup(long id, long[] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                if (id == groups[i]) return true;
            }
            return false;
        }



    }
}
