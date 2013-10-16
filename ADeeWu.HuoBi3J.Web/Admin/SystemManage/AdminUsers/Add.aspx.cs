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

namespace ADeeWu.HuoBi3J.Web.Admin.SystemManage.AdminUsers
{
    public partial class Add : PageBase
    {

        public override string PageID
        {
            get
            {
                return "0101";
            }
        }

        ADeeWu.HuoBi3J.DAL.Admin_Roles dalRoles = new ADeeWu.HuoBi3J.DAL.Admin_Roles();
        ADeeWu.HuoBi3J.DAL.Admin_Pages  dalPages = new ADeeWu.HuoBi3J.DAL.Admin_Pages ();
        ADeeWu.HuoBi3J.DAL.Admin_UserInRoles dalUserInRoles = new ADeeWu.HuoBi3J.DAL.Admin_UserInRoles();
        ADeeWu.HuoBi3J.DAL.Admin_UserPermissions dalUserPermission = new ADeeWu.HuoBi3J.DAL.Admin_UserPermissions();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.checkBoxListRoles.DataSource = dalRoles.Select(-1, -1);
                this.checkBoxListRoles.DataTextField = "RoleName";
                this.checkBoxListRoles.DataValueField = "ID";
                this.checkBoxListRoles.DataBind();

                this.gvData.DataSource = dalPages.Select(-1, -1,"PageName");
                this.gvData.DataBind();
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            string loginName = this.txtLoginName.Text.Trim();
            string loginPwd = this.txtLoginPwd.Text.Trim();
            string loginPwd2 = this.txtLoginPwd2.Text.Trim();

            string name = this.txtName.Text.Trim();
            string notes = this.txtNotes.Text.Trim();

            if (loginName == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("用户帐号不能为空!");
                return;
            }

            if (loginPwd == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("登陆密码不能为空!");
                return;
            }

            if (loginPwd != loginPwd2)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("两次输入密码不一致!");
                return;
            }


            ADeeWu.HuoBi3J.DAL.Admin_Users dal = new ADeeWu.HuoBi3J.DAL.Admin_Users();
            if (dal.Exist("LoginName", loginName))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("帐号已存在!");
                return;
            }

            ADeeWu.HuoBi3J.Model.Admin_Users user = new ADeeWu.HuoBi3J.Model.Admin_Users();
            user.LoginName = loginName;
            user.Name = name;
            user.Notes = ADeeWu.HuoBi3J.Libary.WebUtility.GetTextAreaContent(notes);
            user.LoginPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(loginPwd, "md5");
            user.LastLogin = DateTime.Now;
            user.RegTime = DateTime.Now;
            user.LoginTimes = 0;
            if (dal.Add(user) <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "注册失败!");
                return;
            }


            //角色授权
            foreach (ListItem item in checkBoxListRoles.Items)
            {
                if (item.Selected)
                {
                    long roleID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(item.Value, 0);
                    if (roleID <= 0) continue;
                    ADeeWu.HuoBi3J.Model.Admin_UserInRoles entUserInRoles = new ADeeWu.HuoBi3J.Model.Admin_UserInRoles();
                    entUserInRoles.AdminID = user.ID;
                    entUserInRoles.RoleID = roleID;
                    dalUserInRoles.Add(entUserInRoles);
                }
            } 

            //特别权限授权
            long[] alowPageIDGroup = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLongGroups("alowPageID", 0);
            foreach (long pageID in alowPageIDGroup)//设置用户所拥有的权限
            {
                if (pageID > 0)
                {
                    ADeeWu.HuoBi3J.Model.Admin_UserPermissions entUserPermission = new ADeeWu.HuoBi3J.Model.Admin_UserPermissions();
                    entUserPermission.CheckState = 0;
                    entUserPermission.PageID = pageID;
                    entUserPermission.AdminID = user.ID;
                    dalUserPermission.Add(entUserPermission);
                }
            }

            long[] denyPageIDGroup = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLongGroups("denyPageID", 0);
            foreach (long pageID in denyPageIDGroup)//设置角色所拒绝的权限
            {
                if (pageID > 0)
                {
                    ADeeWu.HuoBi3J.Model.Admin_UserPermissions entUserPermission = new ADeeWu.HuoBi3J.Model.Admin_UserPermissions();
                    entUserPermission.CheckState = 1;
                    entUserPermission.PageID = pageID;
                    entUserPermission.AdminID = user.ID;
                    dalUserPermission.Add(entUserPermission);
                }
            }
            


            ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "注册成功!选择\"是\"继续操作!", "add.aspx", "list.aspx");
            
        }
    }
}
