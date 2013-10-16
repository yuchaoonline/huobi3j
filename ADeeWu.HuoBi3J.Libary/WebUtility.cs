using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace ADeeWu.HuoBi3J.Libary
{
    /// <summary>
    /// 显示消息提示对话框。
    /// </summary>
    public class WebUtility
    {

        #region JS 脚本
        private static string NewScriptName()
        {
            return string.Format("script_" + Guid.NewGuid().ToString());
        }

        /// <summary>
        /// 生成JS脚本
        /// </summary>
        /// <param name="js"></param>
        /// <returns></returns>
        public static string CreateJs(string js)
        {
            return string.Format("<script text='text/javascript'>{0}</script>", js);
        }

        /// <summary>
        /// 显示消息提示对话框并且自动返回上一页
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowAndGoBack(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), NewScriptName(), GetAlertScript(msg) + "history.back();", true);
        }

        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowMsg(string msg)
        {
            Page page = HttpContext.Current.Handler as Page;
            page.ClientScript.RegisterStartupScript(page.GetType(), NewScriptName(), GetAlertScript(msg), true);
        }

        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowMsg(System.Web.UI.Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), NewScriptName(), GetAlertScript(msg), true);
        }

        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">转跳URL</param>
        public static void ShowMsg(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.Append(GetAlertScript(msg));
            Builder.AppendFormat("location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), NewScriptName(), Builder.ToString());
        }


        public static void ShowChooseDialog(string msg, string scriptToYes, string scriptToNo)
        {
            msg = HttpUtility.UrlEncodeUnicode(msg).Replace("'", "\\'").Replace("\"", "\\\"");
            StringBuilder script = new StringBuilder();
            script.Append("function ScriptToYes(){");
            script.Append(scriptToYes);
            script.Append("}\r\n");

            script.Append("function ScriptToNo(){");
            script.Append(scriptToNo);
            script.Append("}\r\n");

            script.AppendFormat("confirm('unescape({0})')?ScriptToYes():ScriptToNo();\r\n", msg);
            RegisterScript(script.ToString());
        }


        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void RegisterConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        {
            //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }



        /// <summary>
        /// 显示页面选择提示框
        /// </summary>
        /// <param name="page">Page</param>
        /// <param name="msg">询问消息</param>
        /// <param name="urlForYes">选择"是"转跳的URL</param>
        /// <param name="urlForNo">选择"否"转跳的URL</param>
        public static void ShowPageSelector(System.Web.UI.Page page, string msg, string urlForYes, string urlForNo)
        {
            msg = HttpUtility.UrlEncodeUnicode(msg).Replace("'", "\\'").Replace("\"", "\\\"");
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("confirm(unescape('{0}'))?window.location.href='{1}':window.location.href='{2}';", msg, urlForYes, urlForNo);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), NewScriptName(), Builder.ToString());

        }




        /// <summary>
        /// 即时显示消息提示对话框，Top窗体并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndTopRedirect(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append(GetAlertScript(msg));
            Builder.AppendFormat("top.location.href='{0}'", url);
            RegisterScript(page, Builder.ToString());
        }



        /// <summary>
        /// 注册自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void RegisterScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), NewScriptName(), "<script language='javascript'>" + script + "</script>");
        }

        /// <summary>
        /// 注册自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void RegisterScript(string script)
        {
            System.Web.UI.Page currentPage = (System.Web.UI.Page)HttpContext.Current.Handler;
            RegisterScript(currentPage, script);
        }


        public static string GetAlertScript(string msg)
        {
            //参考UrlEncodeUnicode方法或javascript encodeURL 方法的编码方式
            msg = HttpUtility.UrlEncodeUnicode(msg).Replace("'", "\\'").Replace("\"", "\\\"").Replace("+", " ");
            return string.Format("alert(unescape('{0}'));", msg);
        }


        /// <summary>
        /// <para>将指定的原始值转换成javascript 可识别的格式代码值</para>
        /// e.g: var jsValue = '[asp.net 服务端变量 ]';
        /// </summary>
        /// <remarks>
        /// 常用于 在javascript 里动态输出javascript变量时的转换
        /// 如:
        /// <![CDATA[
        ///  var jsValue = '<%= [Asp.net 服务端变量] %>';
        /// ]]>
        /// </remarks>
        /// <param name="originValue">原始值</param>
        /// <returns></returns>
        public static string ConvertToScriptValue(string originValue)
        {
            return HttpUtility.UrlEncode(originValue).Replace("'", "\\'")//将单引号变成 javascript 里的转换字符  \' 斜杠与单引号
                .Replace("+", " "); //将经过编码后的空格恢复原来的状态
        }


        /// <summary>
        /// 打开新窗口
        /// </summary>
        /// <param name="url"></param>
        public static void NewWindow(System.Web.UI.Page page, string url)
        {
            string js = "window.open('" + url + "','_blank');";
            RegisterScript(page, js);

        }


        #endregion

        #region 常规逻辑

        /// <summary>
        /// Asp.net 绑定置换函数
        /// </summary>
        /// <param name="currentValue">当前需要转换的值</param>
        /// <param name="keyValues">二维数组的数组,用于指示对应关键值所返回的字符串,二维数组下标0标识键值,下标为1表示返回的字符串</param>
        /// <example>
        /// #Switch(
        ///       Eval("CheckState").ToString(),
        ///        new string[][]{
        ///            new string[]{"0","待审核"},
        ///            new string[]{"1","已审核"},
        ///            new string[]{"2","无效"},
        ///             new string[]{"3","过期"}
        ///        }               
        /// )
        /// </example>
        /// <returns></returns>
        public static string Switch(string currentValue, IEnumerable<string[]> keyValues)
        {
            return Switch(currentValue, string.Empty, keyValues);
        }

        /// <summary>
        /// Asp.net 绑定置换函数
        /// </summary>
        /// <param name="currentValue">当前需要转换的值</param>
        /// <param name="defaultValue">默认值,当在keyValues数组里找不到后返回的值</param>
        /// <param name="keyValues">二维数组的数组,用于指示对应关键值所返回的字符串,二维数组下标0标识键值,下标为1表示返回的字符串</param>
        /// <example>
        /// #Switch(
        ///       Eval("CheckState").ToString(),
        ///        new string[][]{
        ///            new string[]{"0","待审核"},
        ///            new string[]{"1","已审核"},
        ///            new string[]{"2","无效"},
        ///             new string[]{"3","过期"}
        ///        }               
        /// )
        /// </example>
        /// <returns></returns>
        public static string Switch(string currentValue, string defaultValue, IEnumerable<string[]> keyValues)
        {
            foreach (string[] item in keyValues)
            {
                if (item[0] == currentValue)
                    return item[1];
            }

            return defaultValue;
        }

        /// <summary>
        /// Asp.net 绑定置换函数
        /// </summary>
        /// <param name="currentValue"></param>
        /// <param name="defaultValue"></param>
        /// <param name="keyValues">二维数组的数组,用于指示对应关键值所返回的字符串,二维数组下标0标识键值,下标为1表示返回的字符串</param>
        /// <example>
        /// #Switch(
        ///       Eval("CheckState").ToString(),
        ///        new string[,]{
        ///            {"0","待审核"},
        ///            {"1","已审核"},
        ///            {"2","无效"},
        ///            {"3","过期"}
        ///        }               
        /// )
        /// </example>
        /// <returns></returns>
        public static string Switch(string currentValue, string[,] keyValues)
        {
            if (keyValues.Length < 2) return string.Empty;
            if ((keyValues.Length % 2) != 0) return string.Empty;

            int end = (int)(keyValues.Length / 2);

            for (int i = 0; i < end; i++)
            {
                if (currentValue == keyValues[i, 0])
                    return keyValues[i, 1];
            }
            return string.Empty;
        }


        /// <summary>
        /// 去除HTML标记
        /// </summary>
        /// <param name="NoHTML">包括HTML的源码 </param>
        /// <returns>已经去除后的文字</returns>
        public static string ClearHTML(string Htmlstring)
        {

            //删除脚本

            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);

            //删除HTML

            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }

        /// <summary>
        /// 获取无HTML代码内容
        /// </summary>
        /// <param name="content">过长的内容</param>
        /// <param name="maxlength">返回内容的长度</param>
        /// <param name="endOfHTML">当内容超出长度时,返回内容的后缀HTML代码</param>
        public static string ClearHTML(object input, int maxLength, string endOfHTML)
        {
            string content = Utility.GetStr(input);
            if (content == string.Empty) return content;

            content = ClearHTML(content);
            if (content.Length > maxLength)
            {
                content = content.Substring(0, maxLength) + endOfHTML;
            }
            return content;
        }

        /// <summary>
        /// 获取无HTML代码内容
        /// </summary>
        /// <param name="content">过长的内容</param>
        /// <param name="maxlength">返回内容的长度</param>
        public static string ClearHTML(object input, int maxLength)
        {
            return ClearHTML(input, maxLength, "...");
        }

        /// <summary>
        /// 从TextArea里获取内容并且格式化成正常显示的格式
        /// </summary>
        /// <param name="textAreaContent"></param>
        /// <returns></returns>
        public static string GetTextAreaContent(string textAreaContent)
        {
            return textAreaContent.Replace(" ", "&nbsp;").Replace("\r\n", "<br />");
        }

        /// <summary>
        /// 将显示的内容格式化用于TextArea里显示的内容
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string ToTextAreaContent(string content)
        {
            return content.Replace("<br>", "\r\n").Replace("<br />", "\r\n").Replace("&nbsp;", " ");
        }



        public static string GetUrlStr(string paramName, string defaultValue)
        {
            return Utility.GetStr(HttpContext.Current.Request.QueryString[paramName]);
        }

        public static string GetFormStr(string paramName, string defaultValue)
        {
            return Utility.GetStr(HttpContext.Current.Request.Form[paramName]);
        }

        public static string GetRequestStr(string paramName, string defaultValue)
        {
            return Utility.GetStr(HttpContext.Current.Request[paramName]);
        }

        /// <summary>
        /// 获取地址参数整型变量
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static int GetUrlInt(string paramName, int DefaultValue)
        {
            return Utility.GetInt(HttpContext.Current.Request.QueryString[paramName], DefaultValue);
        }

        /// <summary>
        /// 获取地址参数长整型变量
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static long GetUrlLong(string paramName, long DefaultValue)
        {
            return Utility.GetLong(HttpContext.Current.Request.QueryString[paramName], DefaultValue);
        }

        /// <summary>
        /// 获取地址参数浮点型变量
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static float GetUrlFloat(string paramName, float DefaultValue)
        {
            return Utility.GetFloat(HttpContext.Current.Request.QueryString[paramName], DefaultValue);
        }

        /// <summary>
        /// 获取表单参数浮点型变量
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static float GetFormFloat(string paramName, float DefaultValue)
        {
            return Utility.GetFloat(HttpContext.Current.Request.Form[paramName], DefaultValue);
        }

        /// <summary>
        /// 获取表单参数整型变量
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static int GetFormInt(string paramName, int DefaultValue)
        {
            return Utility.GetInt(HttpContext.Current.Request.Form[paramName], DefaultValue);
        }

        /// <summary>
        /// 获取表单参数整型变量
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static long GetFormLong(string paramName, long DefaultValue)
        {
            return Utility.GetLong(HttpContext.Current.Request.Form[paramName], DefaultValue);
        }
        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentIP()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }
        /// <summary>
        /// 获取外部参数整型变量
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static int GetRequestInt(string paramName, int DefaultValue)
        {
            return Utility.GetInt(HttpContext.Current.Request.Params[paramName], DefaultValue);
        }

        /// <summary>
        /// 获取外部参数整型变量
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static long GetRequestLong(string paramName, long DefaultValue)
        {
            return Utility.GetLong(HttpContext.Current.Request.Params[paramName], DefaultValue);
        }

        /// <summary>
        /// 获取请求参数浮点型变量
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static float GetRequestFloat(string paramName, float DefaultValue)
        {
            return Utility.GetFloat(HttpContext.Current.Request[paramName], DefaultValue);
        }

        /// <summary>
        /// 获取外部参数数值变量
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static object GetRequestNum(string paramName, int DefaultValue)
        {
            return Utility.GetNum(HttpContext.Current.Request.Params[paramName], DefaultValue);
        }





        /// <summary>
        /// 获取请求长整型参数数组
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="defaultValueInGroups">在数组里的默认值</param>
        /// <returns>成功返回长度大于0的数组,失败返回长度等于0的数组</returns>
        public static long[] GetRequestLongGroups(string paramName, long defaultValueInGroups)
        {
            string strParam = Utility.GetStr(HttpContext.Current.Request[paramName], "").Trim();
            if (strParam == "") return new long[] { };

            List<long> ret = new List<long>();
            if (strParam.LastIndexOf(",") > 0)
            {
                foreach (string s in strParam.Split(','))
                {
                    ret.Add(Utility.GetLong(s, defaultValueInGroups));
                }
            }
            else
            {
                ret.Add(Utility.GetLong(strParam, defaultValueInGroups));
            }

            return ret.ToArray();
        }


        /// <summary>
        /// 获取请求整型参数数组
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="defaultValueInGroups">在数组里的默认值</param>
        /// <returns>成功返回长度大于0的数组,失败返回长度等于0的数组</returns>
        public static int[] GetRequestIntGroups(string paramName, int defaultValueInGroups)
        {
            string strParam = Utility.GetStr(HttpContext.Current.Request[paramName], "").Trim();
            if (strParam == "") return new int[] { };

            List<int> ret = new List<int>();
            if (strParam.LastIndexOf(",") > 0)
            {
                foreach (string s in strParam.Split(','))
                {
                    ret.Add(Utility.GetInt(s, defaultValueInGroups));
                }
            }
            else
            {
                ret.Add(Utility.GetInt(strParam, defaultValueInGroups));
            }

            return ret.ToArray();
        }


        /// <summary>
        /// 根据请求方式顺序,更新获取请求整型参数(用于获取同一个关键值有多种请求方式的值)
        /// </summary>
        /// <param name="paramName">Query与Form的参数名称</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="queryFirst">True:先检测Request.Query里的参数,后用Request.Form有效值覆盖 False:与True相反</param>
        /// <returns></returns>
        public static int UpdateRequestInt(string paramName, int defaultValue, bool queryFirst)
        {
            if (queryFirst)
            {
                int ret = GetUrlInt(paramName, defaultValue);
                if (HttpContext.Current.Request.Form[paramName] != null)
                {
                    ret = GetFormInt(paramName, defaultValue);
                }
                return ret;
            }
            else
            {
                int ret = GetFormInt(paramName, defaultValue);
                if (HttpContext.Current.Request.QueryString[paramName] != null)
                {
                    ret = GetUrlInt(paramName, defaultValue);
                }
                return ret;
            }
        }

        /// <summary>
        /// 根据请求方式顺序,更新获取请求长整型参数(用于获取同一个关键值有多种请求方式的值)
        /// </summary>
        /// <param name="paramName">Query与Form的参数名称</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="queryFirst">True:先检测Request.Query里的参数,后用Request.Form有效值覆盖 False:与True相反</param>
        /// <returns></returns>
        public static long UpdateRequestLong(string paramName, long defaultValue, bool queryFirst)
        {
            if (queryFirst)
            {
                long ret = GetUrlLong(paramName, defaultValue);
                if (HttpContext.Current.Request.Form[paramName] != null)
                {
                    ret = GetFormLong(paramName, defaultValue);
                }
                return ret;
            }
            else
            {
                long ret = GetFormLong(paramName, defaultValue);
                if (HttpContext.Current.Request.QueryString[paramName] != null)
                {
                    ret = GetUrlLong(paramName, defaultValue);
                }
                return ret;
            }

        }


        /// <summary>
        /// 根据请求方式顺序,更新获取请求的字符串(用于获取同一个关键值有多种请求方式的值)
        /// </summary>
        /// <param name="paramName">Query与Form的参数名称</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="queryFirst">True:先检测Request.Query里的参数,后用Request.Form有效值覆盖 False:与True相反</param>
        /// <returns></returns>
        public static string UpdateRequestStr(string paramName, string defaultValue, bool queryFirst)
        {
            if (queryFirst)
            {
                string ret = GetUrlStr(paramName, defaultValue);
                if (HttpContext.Current.Request.Form[paramName] != null)
                {
                    ret = GetFormStr(paramName, defaultValue);
                }
                return ret;
            }
            else
            {
                string ret = GetFormStr(paramName, defaultValue);
                if (HttpContext.Current.Request.QueryString[paramName] != null)
                {
                    ret = GetUrlStr(paramName, defaultValue);
                }
                return ret;
            }
        }

        /// <summary>
        /// 设置当前输出内容立即过期
        /// </summary>
        /// <param name="page"></param>
        public static void SetResponseExpired(Page page)
        {
            SetResponseExpired(page.Response);
        }

        /// <summary>
        /// 设置当前输出内容立即过期
        /// </summary>
        /// <param name="response"></param>
        public static void SetResponseExpired(HttpResponse response)
        {
            response.Buffer = false;
            response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            response.Expires = -1;
            response.CacheControl = "no-cache";
        }
        /// <summary>
        /// 格式化url
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FormatURL(object value)
        {
            if (!value.ToString().StartsWith("http://"))
                return "http://" + value;
            return value.ToString();
        }
        #endregion



    }
}
