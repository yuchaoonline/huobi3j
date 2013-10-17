using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Class
{

    /// <summary>
    /// 用户审核状态
    /// </summary>
    public enum UserSessionCheckState
    {
        /// <summary>
        /// 未通过审核
        /// </summary>
        NotAudit = 0,
        /// <summary>
        /// 已通过审核
        /// </summary>
        Audited = 1,
        /// <summary>
        /// 已过期
        /// </summary>
        HasExpired = 2,
        /// <summary>
        /// 无效,不可用
        /// </summary>
        Unavailable = 3

    }

    [Serializable()]
    /// <summary>
    /// 用户登陆保持的会话状态
    /// </summary>
    public class UserSession
    {
        /// <summary>
        /// 用户类型, 0:普通个人用户,1:商家用户,2:商家代表
        /// </summary>
        public int UserType = 0;
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID = 0;

        /// <summary>
        /// 通讯号码
        /// </summary>
        public string UIN = string.Empty;
        /// <summary>
        /// 登陆帐号(可为空)
        /// </summary>
        public string LoginName = string.Empty;
        /// <summary>
        /// Email(可为空)
        /// </summary>
        public string Email = string.Empty;

        public UserSessionCheckState UserCheckState = UserSessionCheckState.NotAudit;

        public UserSession(long userID, string uin)
            : this(userID, uin, string.Empty, string.Empty, 0)
        {
        }

        public UserSession(long userID, string uin, string loginName, string email, int userType)
        {
            this.UserID = userID;
            this.LoginName = loginName;
            this.Email = email;
            this.UIN = uin;
            this.UserType = userType;
        }


        public static void SaveSession(UserSession session)
        {
            SaveSession(HttpContext.Current, session, DateTime.Now);
        }

        public static void SaveSession(UserSession session, DateTime expire)
        {
            SaveSession(HttpContext.Current, session, expire);
        }


        public static void SaveSession(HttpContext context, UserSession session, DateTime expire)
        {
            HttpContext.Current.Session["UserSession"] = session;
            //cookie 实现
        }

        public static UserSession GetSession()
        {
            return GetSession(HttpContext.Current);
        }

        public static UserSession GetSession(HttpContext context)
        {
            //context.Session["UserSession"] = BuildSession(new ADeeWu.HuoBi3J.DAL.Users().GetEntity(62));
            return context.Session["UserSession"] as UserSession;
        }


        /// <summary>
        /// 根据指定的用户数据建立对应的会话
        /// </summary>
        /// <returns></returns>
        public static UserSession BuildSession(Model.Users user)
        {
            if (user == null)
            {
                return null;
            }

            UserSession loginSession = null;
            DataBase db = DataBase.Create();

            if (user.UserType == 1)
            {
                #region 1
                db.Parameters.Append("@UserID", user.ID);
                DataTable dtCorp = db.Select(@"select c.ID as CorpID , c.CorpName , c.CheckState from [Corporations] as c where c.UserID=@UserID");

                if (dtCorp.Rows.Count > 0)
                {
                    long corpID = Utility.GetLong(dtCorp.Rows[0]["CorpID"], 0);
                    int corpCheckState = Utility.GetInt(dtCorp.Rows[0]["CheckState"], 0);
                    string corpName = Utility.GetStr(dtCorp.Rows[0]["CorpName"], "");


                    Class.CorpSession corpSession = new Class.CorpSession(user.ID, user.UIN, user.LoginName, user.Email, corpID, corpName);
                    corpSession.CorpCheckState = (UserSessionCheckState)corpCheckState;//企业用户审核状态

                    loginSession = corpSession;
                }
                else//商家注册未通过审核
                {
                    loginSession = new Class.UserSession(user.ID, user.UIN, user.LoginName, user.Email, user.UserType);
                }
                loginSession.UserCheckState = (UserSessionCheckState)user.CheckState;//个人用户审核状态 
                #endregion
            }
            else
            {
                loginSession = new UserSession(user.ID, user.UIN, user.LoginName, user.Email, 0);
                loginSession.UserCheckState = (UserSessionCheckState)user.CheckState;
            }

            SaleManSession.SaveCircleSaleMan(user.ID);
            //QualifiedAgentSession.SaveQualifiedAgent(user.ID);

            return loginSession;
        }

        public static UserSession Logout()
        {
            return Logout(HttpContext.Current);
        }

        public static UserSession Logout(HttpContext context)
        {
            UserSession session = GetSession(context);
            return session;
        }


        /// <summary>
        /// 登陆到会话(包括相关的事务),并且返回对应用户类型的会话
        /// 返回: 成功--登陆会话,失败--Null
        /// </summary>
        /// <remarks>
        /// 成功登陆将会记录本次登陆的数据：登陆时间，登陆次数，登陆IP
        /// </remarks>
        /// <param name="loginKey">登陆键,可以表示为登陆帐号,通讯号码或Email其中之一</param>
        /// <param name="originPwd">用户输入的原始密码,未经加密</param>
        /// <param name="expire">有效期</param>
        /// <returns></returns>
        public static UserSession Login(string loginKey, string originPwd, DateTime expire)
        {
            string pwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(originPwd, "md5");
            loginKey = loginKey.Trim();
            DAL.Users dal = new DAL.Users();
            Model.Users user = null;
            if (Regex.IsMatch(loginKey, @"^\d+$"))//通讯号码
            {
                user = dal.GetEntity(new string[] { "CheckState", "UIN", "LoginPwd" }, 1, loginKey, pwdMd5);
            }
            else if (Regex.IsMatch(loginKey, Validator.EmailPattern))
            {
                user = dal.GetEntity(new string[] { "CheckState", "Email", "LoginPwd" }, 1, loginKey, pwdMd5);
            }
            else if (Regex.IsMatch(loginKey, @"\w+") /*&& Regex.IsMatch(loginKey, @"\d+")*/ )//自定义登陆帐号
            {
                user = dal.GetEntity(new string[] { "CheckState", "LoginName", "LoginPwd" }, 1, loginKey, pwdMd5);
            }
            else
            {
                return null;
            }

            if (user == null)//登陆失败
            {
                return null;
            }

            UserSession loginSession = BuildSession(user);

            if (user != null)
            {
                user.LoginTimes++;
                user.LastLogin = DateTime.Now;
                user.LastLoginIP = HttpContext.Current.Request.UserHostAddress;
                dal.Update(user);

                UserSession.SaveSession(loginSession, expire);
                return loginSession;
            }
            else
            {
                return null;
            }

        }

    }
}
