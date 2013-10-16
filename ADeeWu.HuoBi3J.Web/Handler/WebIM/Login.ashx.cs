using System;
using System.Collections.Generic;
using System.Web;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Handler.WebIM
{
    
    public class Login : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            string uin = Utility.GetStr(context.Request["uin"], "");
            string pwd = Utility.GetStr(context.Request["pwd"], "");

            if (uin.Length == 0 || pwd.Length == 0)
            {
                context.Response.Write("{success:false,id:0,uin:'',type:-1,nickName:null}");
                return;
            }


            Class.UserSession session = Class.UserSession.Login(uin, pwd, DateTime.Now.AddDays(7));
            if (session == null)
            {
                context.Response.Write("{success:false,id:0,uin:'',type:-1,nickName:null}");
            }
            else
            {
                DAL.IM_Users dalIMUser = new ADeeWu.HuoBi3J.DAL.IM_Users();
                Model.IM_Users entIMUser = dalIMUser.GetEntity(new string[] { "UserID" }, session.UserID);
                if (entIMUser != null)
                {
                    context.Response.Write("{" + string.Format("success:true,id:{0},uin:'{1}',type:{2},nickName:'{3}'", session.UserID, session.UIN, session.UserType, entIMUser.NickName) + "}");
                }
                else
                {
                    context.Response.Write("{success:false,id:0,uin:'',type:-1,nickName:null}");
                }
            }
        }
    }
}
