using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin
{
    public class PageBase : System.Web.UI.Page
    {
        private UserSession _LoginUser = null;
        /// <summary>
        /// 登陆的用户
        /// </summary>
        public UserSession LoginUser
        {
            get { return _LoginUser; }
            set { _LoginUser = value; }
        }

        /// <summary>
        /// 数据列表分页大小
        /// </summary>
        public const int DataList_PageSize = 20;


        public virtual string PageID { get { return string.Empty; } }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            //测试用户
            //LoginUser = new UserSession(3, "admin");
            //UserSession.SaveSession(LoginUser);
            //return;

            this.LoginUser = UserSession.GetSession();
            if (this.LoginUser == null)
            {
                Response.Redirect("/Admin/login.aspx?url=" + Server.UrlEncode(Request.Url.ToString()));

                ADeeWu.HuoBi3J.Libary.WebUtility.ShowAndTopRedirect(this, "用户未登录或登录超时,请重新登陆!", "/Admin/login.aspx?url=" + Server.UrlEncode(Request.Url.ToString()));
            }
            else
            {
                //if (!CheckPermissions())
                //{
                //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("当前用户没有权限!");
                //}
            }
        }


        private bool CheckPermissions()
        {
            DataBase db = DataBase.Create();
            db.Parameters.Append("@PageCode", this.PageID);
            db.Parameters.Append("@AdminID", LoginUser.UserID);
            DataTable dtResolvePermission = db.RunProcDataTable("SP_System_ResolveUserUserPermissions");

            if (dtResolvePermission.Rows.Count == 0) return false;

            DataRow dr = dtResolvePermission.Rows[0];
            return ADeeWu.HuoBi3J.Libary.Utility.GetInt(dr["CheckState"], 2) == 0;
        }





    }
}
