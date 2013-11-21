using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web
{
    public partial class MobileRegister : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebUtility.GetRequestStr("method", "") == "register")
            {
                Response.ContentType = "text/plain";
                Response.Write(Register());
                Response.End();
            }
        }

        private string Register()
        {
            ADeeWu.HuoBi3J.DAL.Users dal = new ADeeWu.HuoBi3J.DAL.Users();
            DataBase db = DataBase.Create();

            var username = WebUtility.GetRequestStr("username", "");
            var password = WebUtility.GetRequestStr("password", "");
            var validCode = WebUtility.GetRequestStr("ValidCode", "");

            if (string.IsNullOrWhiteSpace(username))
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "用户名不能为空！" });
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "密码不能为空！" });
            }

            if (username.Length > 0)
            {
                if (!Regex.IsMatch(username, @"^[\d\w_]{6,12}$"))
                {
                    return JsonConvert.SerializeObject(new { statue = false, msg = "登陆帐号输入不正确,应由大小写字母、数字或下划线组成，长度不能少于6个字符长度且不能大于12个字符" });
                }

                if (Regex.IsMatch(username, @"^\d+$"))
                {
                    return JsonConvert.SerializeObject(new { statue = false, msg = "登陆帐号不能全为数字" });
                }

                if (ADeeWu.HuoBi3J.Libary.Validator.Validate(Validator.ValidationType.Email, username))
                {
                    return JsonConvert.SerializeObject(new { statue = false, msg = "登陆帐号不能使用Email地址" });
                }

                //帐号验证由存储过程实现
                if (dal.Exist("LoginName", username))
                {
                    return JsonConvert.SerializeObject(new { statue = false, msg = "该用户帐号已存在" });
                }
            }
            else
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "用户帐号不能为空" });
            }

            if (password == "")
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "请输入登陆密码" });
            }

            string SessionCode = Session["CheckCode"] as string;
            if (SessionCode == null)
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "验证码丢失,请重新点击验证码图片!" });
            }

            if (validCode.ToLower() != SessionCode.ToLower())
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "验证码输入错误" });
            }

            string passwordByMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5");

            db.Parameters.Append("@LoginName", username);
            db.Parameters.Append("@LoginPwd", passwordByMD5);
            db.Parameters.Append("@AlipayAccount", "");
            db.Parameters.Append("@Name", "");
            db.Parameters.Append("@Tel", "");
            db.Parameters.Append("@Email", "");
            db.Parameters.Append("@LastLogin", DateTime.Now);
            db.Parameters.Append("@RegTime", DateTime.Now);
            db.Parameters.Append("@UIN", "");
            db.Parameters.Append("@AutoUIN", 1);
            db.Parameters.Append("@ReturnUIN", "", ParameterDirection.Output, DbType.String).Size = 20;
            db.Parameters.Append("@ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;

            db.AutoClearParameters = false;
            if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_User_Register"), -1) == 0)
            {
                Class.UserSession.Logout();
                //this.LoginUser = Class.UserSession.Login(db.Parameters["@ReturnUIN"].Value.ToString(), password, DateTime.Now);
                return JsonConvert.SerializeObject(new { statue = true, msg = "注册成功，请使用注册账号进行登录！" });
            }
            else
            {
                db.Logger.Log(string.Format(@"执行存储过程时发生错误 {0}\r\nURL:{1}\r\n错误信息:{2}", DateTime.Now, Request.Url.ToString(), db.Parameters["@ErrorMessage"].Value));
                return JsonConvert.SerializeObject(new { statue = true, msg = "操作失败，请重试！" });
            }
        }
    }
}