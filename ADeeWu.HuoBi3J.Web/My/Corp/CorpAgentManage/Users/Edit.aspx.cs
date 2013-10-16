using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.Users
{

    public partial class Edit : Class.PageBase_MyCorp
    {
        DataBase db = DataBase.Create();

      
        long corpAgentID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            corpAgentID = WebUtility.GetRequestLong("id", 0);

            if (!IsPostBack)
            {
                DataTable dt = db.Select(
                    string.Format("select * from vw_CorpAgents where AgentCorpID={0} and ID = {1}", this.LoginUser.CorpID, corpAgentID)
                );
                if (dt.Rows.Count == 0)
                {
                    WebUtility.ShowMsg(this, "该记录已不存在!", "Default.aspx");
                    return;
                }

                DataRow dr = dt.Rows[0];
                this.liteUIN.Text = dr["UIN"].ToString();
                string email = dr["Email"].ToString().Trim();
                string loginName = dr["LoginName"].ToString().Trim();
                this.syncSelectorLocation.Values = new string[]
                {
                    dr["ManageProvinceID"].ToString(),
                    dr["ManageCityID"].ToString(),
                    dr["ManageAreaID"].ToString()
                };
                
                //填写Email后 不能修改
                if (email.Length == 0)
                {
                    this.txtEmail.Visible = true;
                    this.liteEmail.Visible = false;
                }
                else
                {
                    this.liteEmail.Text = email;
                    this.liteEmail.Visible = true;
                    this.txtEmail.Visible = false;
                }

                //填写登陆帐号后不能修改
                if (loginName.Length == 0)
                {
                    this.txtLoginName.Visible = true;
                    this.liteLoginName.Visible = false;
                }
                else
                {
                    this.liteLoginName.Text = loginName;
                    this.liteLoginName.Visible = true;
                    this.txtLoginName.Visible = false;
                }

                this.txtName.Text = dr["Name"].ToString();
                this.txtTel.Text = dr["Tel"].ToString();

                this.ddlCheckState.SelectedValue = dr["CheckState"].ToString();

                DAL.CA_Roles dalRoles = new ADeeWu.HuoBi3J.DAL.CA_Roles();
                this.ddlRoles.DataSource = dalRoles.Select("ManagerCorpID=" + this.LoginUser.CorpID, "");
                this.ddlRoles.DataValueField = "id";
                this.ddlRoles.DataTextField = "RoleName";
                this.ddlRoles.DataBind();
                this.ddlRoles.Items.Insert(0, new ListItem("请选择", "0", true));
                this.ddlRoles.SelectedValue = dr["RoleID"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DAL.Users dalUser = new ADeeWu.HuoBi3J.DAL.Users();
            Model.Users entity = dalUser.GetEntity(new string[] { "UIN" }, this.liteUIN.Text);
            if (entity == null)
            {
                Response.Redirect(".");
                return;
            }

            string loginName = this.txtLoginName.Text.Trim();
            string email = this.txtEmail.Text.Trim();
            string userName = this.txtName.Text.Trim();
            string tel = this.txtTel.Text.Trim();
            long roleID = Utility.GetLong(this.ddlRoles.SelectedValue,0);
            string[] location = this.syncSelectorLocation.Values;

            long provinceID = Utility.GetLong(location[0],0);
            long cityID = Utility.GetLong(location[1],0);
            long areaID = Utility.GetLong(location[2],0);


            if (entity.LoginName.Length == 0 && loginName.Length > 0)//用户补填写登陆帐号
            {
                //检测登陆帐号是否已存在
                if (dalUser.Exist("LoginName", loginName))
                {
                    WebUtility.ShowMsg(this, string.Format("该登陆帐号:{0} 已存在!", loginName));
                    return;
                }
                else
                {
                    entity.LoginName = loginName;
                }
            }

            if (entity.Email.Length == 0 && email.Length > 0)//用户补填写Email
            {
                //检测Email是否已存在
                if (dalUser.Exist("Email", email))
                {
                    WebUtility.ShowMsg(this, string.Format("该邮箱:{0} 已被注册!", email));
                    return;
                }
                else
                {
                    entity.Email = email;
                }
            }

            if (this.chkChangePwd.Checked)//密码修改
            {
                string pwd = this.txtLoginPwd.Text.Trim();
                string pwd2 = this.txtLoginPwd2.Text.Trim();
                string script = @"
$(document).ready(function(){
  setChangePwd(true); 
});
                ";

                if (pwd.Length == 0)
                {
                    WebUtility.ShowMsg(this, "请输入新密码!");
                    WebUtility.RegisterScript(this, script);
                    return;
                }

                if (pwd2.Length == 0)
                {
                    WebUtility.ShowMsg(this, "请再输入密码确认");
                    WebUtility.RegisterScript(this, script);
                    return;
                }

                if (pwd != pwd2)
                {
                    WebUtility.ShowMsg(this, "两次密码输入不一致!");
                    WebUtility.RegisterScript(this, script);
                    return;
                }
                entity.LoginPwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "md5");
            }

            entity.Tel = tel;
            entity.Name = userName;
            entity.CheckState = Utility.GetInt(this.ddlCheckState.SelectedValue, 0);

            if (dalUser.Update(entity) > 0)
            {
                WebUtility.ShowMsg(this, "操作成功!");
                //更新当前商家代理所属角色
                DAL.CorpAgents dalCorpAgent = new DAL.CorpAgents();
                Model.CorpAgents entCorpAgent = dalCorpAgent.GetEntity(corpAgentID);
                if(entCorpAgent!=null){
                    entCorpAgent.RoleID = roleID;
                    entCorpAgent.ManageProvinceID = provinceID;
                    entCorpAgent.ManageCityID = cityID;
                    entCorpAgent.ManageAreaID = areaID;
                    entCorpAgent.CheckState = Utility.GetInt(this.ddlCheckState.SelectedValue, 0);
                    dalCorpAgent.Update(entCorpAgent);
                }
            }
            else
            {
                WebUtility.ShowMsg(this, "操作失败！请与工作人员联系！");
            }


        }
    }
}
