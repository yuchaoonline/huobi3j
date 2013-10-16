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

namespace ADeeWu.HuoBi3J.Web.My.User
{
    public partial class Password : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Password";
            }
        }

        ADeeWu.HuoBi3J.DAL.Users dalUser = new ADeeWu.HuoBi3J.DAL.Users();
        
        protected void Page_Load(object sender, System.EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string pwd = this.txtPwdNative.Text.Trim();
            string newPwd = this.txtNewPwd.Text.Trim();
            string newPwd2 = this.txtNewPwd2.Text.Trim();

            if (pwd.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入原密码!");
                return;
            }

            if (newPwd.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入新密码!");
                return;
            }

            if (newPwd2.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请输入新密码确认!");
                return;
            }

            if (newPwd != newPwd2)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("两次新密码输入不一致!");
                return;
            }

            string pwdMd5 =System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "md5");
            string newPwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newPwd, "md5");

            dalUser.Parameters.Append("@LoginPwd", pwdMd5);
            if (!dalUser.Exist("LoginPwd=@LoginPwd and ID=" + base.LoginUser.UserID))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("密码不正确!");
                return;
            }

            int ret = dalUser.Update(
                "LoginPwd",
               newPwdMd5,
                "ID = " + base.LoginUser.UserID
                );

            if (ret > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("密码修改成功!");
                return;
            }

        }
    }
}
