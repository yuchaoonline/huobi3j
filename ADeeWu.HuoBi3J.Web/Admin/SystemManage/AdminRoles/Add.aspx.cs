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

namespace ADeeWu.HuoBi3J.Web.Admin.SystemManage.AdminRoles
{
    public partial class Add : PageBase
    {

        public override string PageID
        {
            get
            {
                return "0201";
            }
        }
        
        ADeeWu.HuoBi3J.DAL.Admin_Pages  dalPages = new ADeeWu.HuoBi3J.DAL.Admin_Pages ();
        ADeeWu.HuoBi3J.DAL.Admin_Roles dalRoels = new ADeeWu.HuoBi3J.DAL.Admin_Roles();
        ADeeWu.HuoBi3J.DAL.Admin_RolePermissions dalRolePermissions = new ADeeWu.HuoBi3J.DAL.Admin_RolePermissions();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                this.gvData.DataSource = dalPages.Select(-1, -1,"PageName");
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

            if (dalRoels.Exist("RoleName", roleName))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("角色已存在!");
                return;
            }

            ADeeWu.HuoBi3J.Model.Admin_Roles ent = new ADeeWu.HuoBi3J.Model.Admin_Roles();
            ent.RoleName = roleName;
            ent.Description = this.txtDescription.Text;

            if (dalRoels.Add(ent) <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("添加失败!");
                return;
            }

            
            
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

            ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "添加成功!选择\"是\"继续操作,选择否修改该记录!", "add.aspx", "edit.aspx?id" + ent.ID);


        }
    }
}
