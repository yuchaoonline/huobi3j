using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Class
{
    /// <summary>
    /// 商家代表用户登陆保持的会话状态
    /// </summary>
    public class QualifiedAgentSession
    {
        public static Model.CA_QualifiedAgents QualifiedAgent
        {
            get
            {
                if (HttpContext.Current.Session["QualifiedAgent"] == null)
                    return null;

                return HttpContext.Current.Session["QualifiedAgent"] as Model.CA_QualifiedAgents;
            }
        }

        public static bool IsQualifiedAgent
        {
            get
            {
                return CheckState == UserSessionCheckState.Audited;
            }
        }

        public static UserSessionCheckState CheckState
        {
            get
            {
                if (QualifiedAgent == null) return UserSessionCheckState.Unavailable;
                return (UserSessionCheckState)QualifiedAgent.CheckState;
            }
        }

        public static void SaveQualifiedAgent(long UserID)
        {
            DAL.CA_QualifiedAgents dal = new DAL.CA_QualifiedAgents();
            dal.Parameters.Append("@UserID", UserID);
            var ent = dal.GetEntity("UserID=@UserID");

            if (ent != null)
                HttpContext.Current.Session["QualifiedAgent"] = ent;
        }
    }
}
