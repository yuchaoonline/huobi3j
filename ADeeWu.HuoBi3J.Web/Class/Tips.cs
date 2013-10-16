using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace ADeeWu.HuoBi3J.Web.Class
{
    /// <summary>
    /// 贴士元数据类
    /// </summary>
    /// <remarks>
    /// 用于页面之间(/Tips.aspx与其他页面)参数(内容比较长的参数)传递
    /// </remarks>
    public class Tips
    {
        private string topic = string.Empty;
        private string summary = string.Empty;
        private string url = string.Empty;
        private string urlText = string.Empty;

        /// <summary>
        /// 主题
        /// </summary>
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        /// <summary>
        /// 简述
        /// </summary>
        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        /// <summary>
        /// 相关链接
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        /// <summary>
        /// 链接文本
        /// </summary>
        public string UrlText
        {
            get { return urlText; }
            set { urlText = value; }
        }

        public Tips(string topic, string summary, string url, string urlText)
        {
            this.topic = topic;
            this.summary = summary;
            this.url = url;
            this.urlText = urlText;
        }


        public static Tips GetTips()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Tips"];
            if (cookie == null) return null;
            string topic = HttpUtility.UrlDecode(cookie["Topic"] ?? string.Empty);
            string summary = HttpUtility.UrlDecode(cookie["Summary"] ?? string.Empty);
            string url = HttpUtility.UrlDecode(cookie["Url"] ?? string.Empty);
            string urlText = HttpUtility.UrlDecode(cookie["UrlText"] ?? string.Empty);

            return new Tips(topic, summary, url, urlText);
        }

        public static void SetTips(Tips tips)
        {
            HttpCookie cookie = new HttpCookie("Tips");
            cookie["Topic"] = HttpUtility.UrlEncode(tips.Topic);
            cookie["Summary"] = HttpUtility.UrlEncode(tips.Summary);
            cookie["Url"] = HttpUtility.UrlEncode(tips.Url);
            cookie["UrlText"] = HttpUtility.UrlEncode(tips.UrlText);
            //cookie.Expires = DateTime.Now.AddSeconds(10);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void SetTips(string topic, string summary, string url, string urlText)
        {
            SetTips(new Tips(topic, summary, url, urlText));
        }

        public static void ClearTips()
        {
            HttpCookie cookie = HttpContext.Current.Response.Cookies["Tips"];
            if (cookie == null) return;
            //cookie.Expires = DateTime.Now.AddSeconds(-1);
            HttpContext.Current.Response.Cookies.Remove("Tips");
        }
        
        /// <summary>
        /// 显示贴士,重定向到/Tips.aspx页面
        /// </summary>
        public static void Show()
        {
            HttpContext.Current.Response.Redirect("/Tips.aspx");
        }

        /// <summary>
        /// 显示贴士,重定向到指定页面
        /// </summary>
        public static void Show(string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }
        
    }
}
