using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace ADeeWu.HuoBi3J.Web
{
    public partial class Forget : ADeeWu.HuoBi3J.Web.Class.PageBase
    {
        ADeeWu.HuoBi3J.DAL.Users dal = new ADeeWu.HuoBi3J.DAL.Users();
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                this.revEmail.ValidationExpression = ADeeWu.HuoBi3J.Libary.Validator.EmailPattern;
                this.phInfoValidation.Visible = true;
                this.phChangePwd.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string loginName = this.txtLoginName.Text.Trim();
            string name = this.txtName.Text.Trim();
            string email = this.txtEmail.Text.Trim();
            string tel = this.txtTel.Text.Trim();       
           
            
            if (loginName == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("帐号不能为空!");
                return;
            }

            if (name == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写真实姓名!");
                return;
            }

            if (email == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入有效的Email地址!");
                return;
            }

            if (tel == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入联系电话!");
                return;
            }

            ADeeWu.HuoBi3J.SQL.ParameterCollection.MssqlParameters parameters = new ADeeWu.HuoBi3J.SQL.ParameterCollection.MssqlParameters();
            parameters.Append("@LoginName", loginName);
            parameters.Append("@Name", name);
            parameters.Append("@Email", email);
            parameters.Append("@Tel", tel);

            bool isExist = dal.Exist("LoginName=@LoginName and Name=@Name and Email=@Email and Tel=@Tel",parameters.ToArray());
            if (!isExist)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("用户资料不存在,请填写正确信息!");
                return;
            }

            this.phInfoValidation.Visible = false;
            this.phChangePwd.Visible = true;

        }

        //密码修改
        protected void btnSubmit2_Click(object sender, EventArgs e)
        {
          
            string pwd1 = this.txtNewPwd.Text.Trim();
            string pwd2 = this.txtNewPwd2.Text.Trim();

            if (pwd1.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写新密码!");
                return;
            }

            if (pwd2.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写确认密码!");
                return;
            }

            if (pwd1 != pwd2)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("两次密码输入不一致!");
                return;
            }


            string loginName = this.txtLoginName.Text.Trim();
            string name = this.txtName.Text.Trim();
            string email = this.txtEmail.Text.Trim();
            string tel = this.txtTel.Text.Trim();

            dal.Parameters.Clear();
            dal.Parameters.Append("@LoginName", loginName);
            dal.Parameters.Append("@Name", name);
            dal.Parameters.Append("@Email", email);
            dal.Parameters.Append("@Tel", tel);

            string pwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd1, "md5");
            dal.Update("LoginPwd", pwdMd5, "LoginName=@LoginName and Name=@Name and Email=@Email and Tel=@Tel");

            ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "新密码修改成功!请好好保管您的密码,以免丢失!", "/My/User/");

        }

        
    }
}
