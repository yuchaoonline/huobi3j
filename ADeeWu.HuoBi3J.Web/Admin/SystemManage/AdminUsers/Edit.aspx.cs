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

namespace ADeeWu.HuoBi3J.Web.Admin.SystemManage.AdminUsers
{
    public partial class Edit : PageBase
    {

        public override string PageID
        {
            get
            {
                return "0102";
            }
        }

        long userID = 0;

        ADeeWu.HuoBi3J.DAL.Admin_Users dalAdmin = new ADeeWu.HuoBi3J.DAL.Admin_Users();
        ADeeWu.HuoBi3J.DAL.Admin_Roles dalRoles = new ADeeWu.HuoBi3J.DAL.Admin_Roles();
        ADeeWu.HuoBi3J.DAL.Admin_UserInRoles dalUserInRoles = new ADeeWu.HuoBi3J.DAL.Admin_UserInRoles();
        ADeeWu.HuoBi3J.DAL.Admin_UserPermissions dalUserPermissions = new ADeeWu.HuoBi3J.DAL.Admin_UserPermissions();
        DataBase db = DataBase.Create();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            userID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (userID < 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("错误参数传递!");
                return;
            }

            if (!IsPostBack)
            {

                ADeeWu.HuoBi3J.Model.Admin_Users ent = dalAdmin.GetEntity(userID);
                if (ent != null)
                {
                    this.txtLoginName.Text = ent.LoginName;
                    this.txtName.Text = ent.Name;
                    this.txtNotes.Text = ADeeWu.HuoBi3J.Libary.WebUtility.ToTextAreaContent(ent.Notes);

                    this.checkBoxListRoles.DataSource = dalRoles.Select(-1, -1);
                    this.checkBoxListRoles.DataTextField = "RoleName";
                    this.checkBoxListRoles.DataValueField = "ID";
                    this.checkBoxListRoles.DataBind();

                    DataTable dtUserInRoles = dalUserInRoles.Select(-1, -1, "AdminID = " + userID, "");
                    foreach (DataRow dr in dtUserInRoles.Rows)
                    {
                        string roleID = dr["RoleID"].ToString();
                        foreach (ListItem item in this.checkBoxListRoles.Items)
                        {
                            if (item.Value==roleID)
                            {
                                item.Selected = true;
                            }
                        }
                    }

                    this.gvData.DataSource = db.Select(string.Format(@"
                    select P.*,isNull(U.CheckState,'2') as CheckState
from Admin_Pages as P left join 
(select * from Admin_UserPermissions where AdminID = {0}) as U
on P.ID = U.PageID order by P.PageName" ,userID)
                        );
                    this.gvData.DataBind();
                    
                }
            }


        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {

            string loginPwd = this.txtLoginPwd.Text.Trim();
            string name = this.txtName.Text.Trim();
            string notes = this.txtNotes.Text.Trim();

            ADeeWu.HuoBi3J.Model.Admin_Users user = dalAdmin.GetEntity(userID);
            if (user == null)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this,"当前记录已被删除!", "list.aspx");
                return;
            }

            if (loginPwd != "") //密码修改
            {
                user.LoginPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(loginPwd, "md5");
            }

            user.Name = name;
            user.Notes = notes;

            if (dalAdmin.Update(user) <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "修改失败!");
                return;
            }
          
            //删除用户所有角色
            dalUserInRoles.Delete("AdminID", userID);

            //授权新的角色
            foreach (ListItem item in this.checkBoxListRoles.Items)
            {
                if (item.Selected)
                {
                    ADeeWu.HuoBi3J.Model.Admin_UserInRoles entUserInRole = new ADeeWu.HuoBi3J.Model.Admin_UserInRoles();
                    entUserInRole.AdminID = userID;
                    entUserInRole.RoleID = ADeeWu.HuoBi3J.Libary.Utility.GetInt(item.Value, 0);
                    dalUserInRoles.Add(entUserInRole);
                }
            }

            //删除用户所有权限
            dalUserPermissions.Delete("AdminID", userID);

            //授权新的权限

            long[] alowPageID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLongGroups("alowPageID", 2);
            foreach (long pageID in alowPageID)
            {
                ADeeWu.HuoBi3J.Model.Admin_UserPermissions entUserPermission = new ADeeWu.HuoBi3J.Model.Admin_UserPermissions();
                entUserPermission.AdminID = userID;
                entUserPermission.PageID = pageID;
                entUserPermission.CheckState = 0;
                dalUserPermissions.Add(entUserPermission);
            }

            long[] denyPageID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLongGroups("denyPageID", 2);
            foreach (long pageID in denyPageID)
            {
                ADeeWu.HuoBi3J.Model.Admin_UserPermissions entUserPermission = new ADeeWu.HuoBi3J.Model.Admin_UserPermissions();
                entUserPermission.AdminID = userID;
                entUserPermission.PageID = pageID;
                entUserPermission.CheckState = 1;
                dalUserPermissions.Add(entUserPermission);
            }

            ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "修改成功!选择\"是\"继续操作!", "Edit.aspx?id=" + userID, "list.aspx");
        }
    }
}
