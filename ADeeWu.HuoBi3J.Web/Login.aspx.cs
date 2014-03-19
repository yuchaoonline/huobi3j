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
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string validateCode = Session["CheckCode"] as string;
            if (validateCode == null)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("验证码丢失,请重新点击验证码图片!");
                return;
            }

            if (txtValidCode.Text.ToLower() != validateCode.ToLower())
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("验证码输入错误!");
                return;
            }

            string loginKey = this.txtLoginName.Text.Trim();
            if (loginKey.Length == 0)
            {
                WebUtility.ShowMsg(this, "请输入登陆通讯号码、帐号或Email");
                return;
            }

            string pwd = this.txtLoginPwd.Text.Trim();
            if (pwd.Length == 0)
            {
                WebUtility.ShowMsg(this, "请输入登陆密码!");
                return;
            }


            Class.UserSession loginSession = Class.UserSession.Login(loginKey, pwd, DateTime.Now);
            if (loginSession == null)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "用户名或密码错误!", "Login.aspx");
                return;
            }

            Response.Redirect(Request.QueryString["url"] ?? "/My/User/");
        }
    }
}
