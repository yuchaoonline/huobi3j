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
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.SystemManage.AdminRoles
{
    public partial class Edit : PageBase
    {

        public override string PageID
        {
            get
            {
                return "0202";
            }
        }

        long roleID = 0;

        ADeeWu.HuoBi3J.DAL.Admin_Pages  dalPages = new ADeeWu.HuoBi3J.DAL.Admin_Pages ();
        ADeeWu.HuoBi3J.DAL.Admin_Roles dalRoels = new ADeeWu.HuoBi3J.DAL.Admin_Roles();
        ADeeWu.HuoBi3J.DAL.Admin_RolePermissions dalRolePermissions = new ADeeWu.HuoBi3J.DAL.Admin_RolePermissions();
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {
            roleID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);

            if (!IsPostBack)
            {
                this.gvData.DataSource = db.Select(
                    string.Format("select P.*,isNull(R.CheckState,'2') as CheckState from Admin_Pages as P left join (select * from Admin_RolePermissions where RoleID = {0}) as R on P.ID = R.PageID order by P.PageName", roleID)
                    );
                this.gvData.DataBind();
                    
                ADeeWu.HuoBi3J.Model.Admin_Roles entRoles = dalRoels.GetEntity(roleID);
                if(entRoles==null){
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("没有找到记录!");
                        return;
                }
                this.txtRoleName.Text = entRoles.RoleName;
                this.txtDescription.Text = entRoles.Description;
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string roleName = this.txtRoleName.Text.Trim();
            string description = this.txtDescription.Text.Trim();

            ADeeWu.HuoBi3J.Model.Admin_Roles ent = dalRoels.GetEntity(roleID);

            if (roleName == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("角色名称不能为空!");
                return;
            }
            if (ent.RoleName != roleName)
            {
                if (dalRoels.Exist("RoleName", roleName))
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("角色已存在!");
                    return;
                }
            }

            ent.Description = description;
            ent.RoleName = roleName;

            if (dalRoels.Update(ent) <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("修改失败!");
                return;
            }

            dalRolePermissions.Delete("RoleID", ent.ID);//清除角色所有权限

            long[] alowPageIDGroup = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLongGroups("alowPageID", 0);
            foreach (long pageID in alowPageIDGroup)//设置角色所拥有的权限
            {
                if (pageID > 0)
                {
                    ADeeWu.HuoBi3J.Model.Admin_RolePermissions entRolePermission = new ADeeWu.HuoBi3J.Model.Admin_RolePermissions();
                    entRolePermission.CheckState = 0;
                    entRolePermission.PageID = pageID;
                    entRolePermission.RoleID = ent.ID;
                    dalRolePermissions.Add(entRolePermission);
                }
            }

            long[] denyPageIDGroup = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLongGroups("denyPageID", 0);
            foreach (long pageID in denyPageIDGroup)//设置角色所拒绝的权限
            {
                if (pageID > 0)
                {
                    ADeeWu.HuoBi3J.Model.Admin_RolePermissions entRolePermission = new ADeeWu.HuoBi3J.Model.Admin_RolePermissions();
                    entRolePermission.CheckState = 1;
                    entRolePermission.PageID = pageID;
                    entRolePermission.RoleID = ent.ID;
                    dalRolePermissions.Add(entRolePermission);
                }
            }

            ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "修改成功!选择\"是\"继续操作,否则转跳到列表页", "Edit.aspx?id=" + ent.ID, "List.aspx");


        }
    }
}
