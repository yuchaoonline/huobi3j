using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using ADeeWu.HuoBi3J.SQL;
using System.Data;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Promotions.Keywords
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Keywords : ADeeWu.HuoBi3J.Web.Handler.LoginHandler
    {

        DataBase db = DataBase.Create();
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            string keyword = HttpUtility.UrlDecode(ADeeWu.HuoBi3J.Libary.Utility.GetStr(context.Request["k"], ""));
            if (keyword.Length == 0) return;
            db.Parameters.Append("@keyword", keyword);
            DataTable dt= db.Select("select top 1 Coins from CP_Keywords where Keyword=@keyword order by coins desc");
            context.Response.ContentType = "text/plain";
            if (dt.Rows.Count > 0)
            {
                context.Response.Write(string.Format("该关键字最高竟价货币数量为: {0} 个",
                    ADeeWu.HuoBi3J.Libary.Utility.GetInt(dt.Rows[0]["Coins"], 0)
                    )
                    );
            }
            else
            {
                context.Response.Write("恭喜您,这个关键字还没有人使用,该关键字当前最高竟价货币数量为0");
            }
        }

    }
}
