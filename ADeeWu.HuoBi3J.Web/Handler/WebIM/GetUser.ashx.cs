using System;
using System.Collections.Generic;
using System.Web;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Handler.WebIM
{
    /// <summary>
    /// 获取当前登陆用户信息(暂时代替单点登陆验证)
    /// </summary>
    /// <remarks>
    /// 当以匿名身份与指定用户进行webim 聊天时
    /// 需要获取当前用户信息来判断是否具有使用匿名聊天的功能
    /// </remarks>
    public class GetUser : BaseHandler
    {

        
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            if (this.LoginUser == null)//当前用户没有登陆到网站
            {
                context.Response.Write("null");
            }
            else
            {

                
                DAL.IM_Users dal = new ADeeWu.HuoBi3J.DAL.IM_Users();
                Model.IM_Users entUser = dal.GetEntity(new string[] { "UserID" }, this.LoginUser.UserID);
                if (entUser != null)
                {
                    context.Response.Write(
                        string.Format("[uin:'{0}',type:{1},id:{2},nickName:'{3}']",
                        this.LoginUser.UIN, this.LoginUser.UserType, this.LoginUser.UserID, entUser.NickName)
                        .Replace("[", "{").Replace("]", "}")
                        );
                    //输出json:{ uin,type,id,nickName }
                }
                else
                {
                    context.Response.Write("null");
                }
            }
        }
    }
}
