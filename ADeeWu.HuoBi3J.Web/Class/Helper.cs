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
    public class Helper
    {
        public static string GetLocation(object aid, object aName, object cid, object cName, object pid, object pName, string split)
        {
            return string.Format("<a href='/Center/Location.aspx?pid={3}' title='{0}'>{0}</a>{6}<a href='/Center/Location.aspx?cid={4}' title='{1}'>{1}</a>{6}<a href='/Center/Location.aspx?aid={5}' title='{2}'>{2}</a>", pName, cName, aName, pid, cid, aid, split);
        }
        public static string GetLocation(object cid, object cName, object pid, object pName, string split)
        {
            return string.Format("<a href='/Center/Location.aspx?pid={2}' title='{0}'>{0}</a>{4}<a href='/Center/Location.aspx?cid={3}' title='{1}'>{1}</a>", pName, cName, pid, cid, split);
        }
        public static string GetLocation(object pid, object pName)
        {
            return string.Format("<a href='/Center/Location.aspx?pid={1}' title='{0}'>{0}</a>", pName, pid);
        }

        public static string GetBusinessCircle(object bid, object bName)
        {
            return string.Format("<a href='/center/businesscircle.aspx?bid={0}' title='{1}'>{1}</a>", bid, bName);
        }

        public static string GetKey(object kid, object kName)
        {
            return string.Format("<a class='orange' href='/center/QuestionList.aspx?kid={0}' title='{1}'>{1}</a>", kid, kName);
        }

        public static string GetQuestion(object qid, object qName)
        {
            return string.Format("<a href='/center/Question.aspx?qid={0}' title='{1}'>{1}</a>", qid, qName);
        }
    }
}
