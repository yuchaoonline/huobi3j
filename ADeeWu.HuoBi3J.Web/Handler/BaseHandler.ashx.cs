using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;

namespace ADeeWu.HuoBi3J.Web.Handler
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public abstract class BaseHandler : IHttpHandler, IRequiresSessionState
    {

        public Class.UserSession LoginUser = null;

        public virtual void ProcessRequest(HttpContext context)
        {
            this.LoginUser = Class.UserSession.GetSession(context);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
