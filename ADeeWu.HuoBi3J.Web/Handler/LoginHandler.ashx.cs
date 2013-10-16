using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace ADeeWu.HuoBi3J.Web.Handler
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class LoginHandler : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            if (this.LoginUser == null)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("请登陆帐号!");
                return;
            }
        }
    }
}
