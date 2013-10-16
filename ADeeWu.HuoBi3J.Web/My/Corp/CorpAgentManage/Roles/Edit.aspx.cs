using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.Roles
{
    public partial class Edit : Class.PageBase_MyCorp
    {

        public override string FunctionCode
        {
            get
            {
                return "CorpAgentManage-Roles-Edit";
            }
        }

        DAL.CA_Roles dalRoels = new ADeeWu.HuoBi3J.DAL.CA_Roles();
        DAL.CA_RolePermissions dalRolePermission = new ADeeWu.HuoBi3J.DAL.CA_RolePermissions();
        DataBase db = DataBase.Create();
        long id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = WebUtility.GetRequestLong("id", 0);
            if (!IsPostBack)
            {
                Model.CA_Roles ent = dalRoels.GetEntity(new string[] { "ID", "ManagerCorpID" }, id, this.LoginUser.CorpID);
                if (ent == null)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "记录不存在!", "Default.aspx");
                    return;
                }
                this.txtRoleName.Text = ent.RoleName;
                this.txtDescription.Text = ent.Description;
                

                this.gvData.DataSource = db.Select(
                   string.Format(@"select distinct RP.RoleID, F.*,RP.AuthorizeState from 
System_Functions as F left join (select * from CA_RolePermissions where RoleID = {0} and ManagerCorpID={1}) as RP 
on F.ID = RP.FunctionID 
where F.IsCorpAgentFunc=1
order by F.Name", id,this.LoginUser.CorpID)
                   );
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

           

            Model.CA_Roles entRole = dalRoels.GetEntity(id);
            
            entRole.Description = this.txtDescription.Text;
            entRole.ManagerCorpID = this.LoginUser.CorpID;

            if (entRole.RoleName != roleName)
            {

                if (dalRoels.Exist(new string[] { "RoleName", "ManagerCorpID" }, new object[] { roleName, this.LoginUser.CorpID }))
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("角色已存在!");
                    return;
                }
                else
                {
                    entRole.RoleName = roleName;
                }
            }

            if (dalRoels.Update(entRole) <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("修改失败!");
                return;
            }

            dalRolePermission.Delete("ManagerCorpID=" + this.LoginUser.CorpID + " and RoleID=" + id);//清除当前角色的权限
            


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

            ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "操作成功!选择\"是\"继续操作!", "Edit.aspx?id=" + id, ".");


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
