using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.MobileService.Models;
using ADeeWu.HuoBi3J.SQL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ADeeWu.HuoBi3J.MobileService.Controllers
{
    public class UserController : JsonController
    {
        /// <summary>
        /// 用户登录，http://mobile.huobi3j.com/user/login
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码（不加密）</param>
        /// <returns></returns>
        public ActionResult Login(string username,string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return GetJson(new JsonResponse { status = false, message = "参数有误！" });
            }

            string pwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5");
            DAL.Users dal = new DAL.Users();
            Model.Users user = null;
            if (Regex.IsMatch(username, @"^\d+$"))//通讯号码
            {
                user = dal.GetEntity(new string[] { "CheckState", "UIN", "LoginPwd" }, 1, username, pwdMd5);
            }
            else if (Regex.IsMatch(username, Validator.EmailPattern))
            {
                user = dal.GetEntity(new string[] { "CheckState", "Email", "LoginPwd" }, 1, username, pwdMd5);
            }
            else if (Regex.IsMatch(username, @"\w+") /*&& Regex.IsMatch(loginKey, @"\d+")*/ )//自定义登陆帐号
            {
                user = dal.GetEntity(new string[] { "CheckState", "LoginName", "LoginPwd" }, 1, username, pwdMd5);
            }
            else
            {
                return null;
            }

            if (user == null)
            {
                return GetJson(new JsonResponse { status = false, message = "用户不存在！" });
            }

            return GetJson(new { status = true, data = user });
        }

        /// <summary>
        /// 注册用户，http://mobile.huobi3j.com/user/register
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码（不加密）</param>
        /// <returns></returns>
        public ActionResult Register(string username, string password)
        {
            ADeeWu.HuoBi3J.DAL.Users dal = new ADeeWu.HuoBi3J.DAL.Users();
            DataBase db = DataBase.Create();

            if (string.IsNullOrWhiteSpace(username))
            {
                return GetJson(new JsonResponse { status = false, message = "用户名不能为空！" });
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                return GetJson(new JsonResponse { status = false, message = "密码不能为空！" });
            }

            if (username.Length > 0)
            {
                if (!Regex.IsMatch(username, @"^[\d\w_]{6,12}$"))
                {
                    return GetJson(new JsonResponse { status = false, message = "登陆帐号输入不正确,应由大小写字母、数字或下划线组成，长度不能少于6个字符长度且不能大于12个字符" });
                }

                if (Regex.IsMatch(username, @"^\d+$"))
                {
                    return GetJson(new JsonResponse { status = false, message = "登陆帐号不能全为数字" });
                }

                if (ADeeWu.HuoBi3J.Libary.Validator.Validate(Validator.ValidationType.Email, username))
                {
                    return GetJson(new JsonResponse { status = false, message = "登陆帐号不能使用Email地址" });
                }

                //帐号验证由存储过程实现
                if (dal.Exist("LoginName", username))
                {
                    return GetJson(new JsonResponse { status = false, message = "该用户帐号已存在" });
                }
            }
            else
            {
                return GetJson(new JsonResponse { status = false, message = "用户帐号不能为空" });
            }

            if (password == "")
            {
                return GetJson(new JsonResponse { status = false, message = "请输入登陆密码" });
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
                return GetJson(new JsonResponse { status = true, message = "注册成功，请使用注册账号进行登录！" });
            }
            else
            {
                db.Logger.Log(string.Format(@"执行存储过程时发生错误 {0}\r\nURL:{1}\r\n错误信息:{2}", DateTime.Now, Request.Url.ToString(), db.Parameters["@ErrorMessage"].Value));
                return GetJson(new JsonResponse { status = false, message = "操作失败，请重试！" });
            }
        }
    }
}
