using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Text;

namespace ADeeWu.HuoBi3J.Web.Admin
{
    public class UserSession
    {
        private long _userID = 0;
        public long UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        
        private string _loginName = string.Empty;
        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }

        private IList<int> _roles = null;
        public IList<int> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }

        public string _rolesString = string.Empty;
        public string RolesString
        {
            get { 
                if(_rolesString==""){
                    StringBuilder builder = new StringBuilder();
                    foreach (int i in this.Roles)
                    {
                        builder.AppendFormat(",{0}", i);
                    }
                    if (builder.Length > 0)
                    {
                        _rolesString = builder.ToString().Substring(1);
                    }
                }
                return _rolesString;
            }

        }


        public UserSession(long userID, string loginName)
        {
            UserID = userID;
            _loginName = loginName;
        }
        public static void SaveSession(UserSession user)
        {
            HttpContext.Current.Session["AdminUserSession"] = user;
        }

        public static UserSession GetSession()
        {
            return HttpContext.Current.Session["AdminUserSession"] as UserSession;
        }
    }
}
