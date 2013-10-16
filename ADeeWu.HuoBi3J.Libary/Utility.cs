using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Configuration;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;

namespace ADeeWu.HuoBi3J.Libary
{
    /// <summary>
    /// GloFnc 的摘要说明
    /// </summary>
    public static class Utility
    {


        #region 常规逻辑

        #region RegExpression 正则表达式验证

        /// <summary>
        /// 获取日期正则表式 格式 2003-02-29 23:59:59 ,2004-02-29 23:59:59,2004-04-30 0:59:59,2004-04-30 01:11:0,2004-04-30 0:0:0,2004-04-30 00:00:00
        /// </summary>
        public static string DateTimeRegex {
            get {
                return
                @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))";
            }
        }

        /// <summary>
        /// 获取日期正则表式2 格式[2004-2-29], [2004-02-29 10:29:39 pm], [2004/12/31] 
        /// </summary>
        public static string DateTimeRegex2 {
            get {
                return
                @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))(\s(((0?[1-9])|(1[0-2]))\:([0-5][0-9])((\s)|(\:([0-5][0-9])\s))([AM|PM|am|pm]{2,2})))?$";

            }
        }


        /// <summary>
        /// 获取用户名验证表达式 大小写英文，数字和下划线的组合
        /// </summary>
        /// <param name="minLen">最小长度</param>
        /// <param name="maxLen">最大长度 若无限制可设置为空</param>
        /// <param name="isFullMatch">全字匹配</param>
        /// <returns></returns>
        public static string GetUserRegex(int minLen, string maxLen, bool isFullMatch) {
            string reg = "[A-Za-z0-9_]{" + minLen.ToString() + "," + maxLen + "}";
            return isFullMatch ? "^" + reg + "$" : reg;
        }

       
        
        
        
        /// <summary>
        /// 获取用户名验证表达式 大小写英文，数字和下划线的组合
        /// </summary>
        /// <param name="minLen">最小长度</param>
        /// <param name="maxLen">最大长度 若无限制可设置为空</param>
        /// <param name="isFullMatch">全字匹配</param>
        /// <returns></returns>
        public static string GetPasswordRegex(int minLen, string maxLen, bool isFullMatch) {
            string reg = "[A-Za-z0-9]{" + minLen.ToString() + "," + maxLen + "}";
            return isFullMatch ? "^" + reg + "$" : reg;
        }




        /// <summary>
        /// 验证是否日期型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDateTime(string value) {
            if (string.IsNullOrEmpty(value.Trim())) return false;
            return Regex.IsMatch(value, DateTimeRegex2);
        }

        /// <summary>
        /// 验证是否日期型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDateTime(object value) {
            return IsDateTime(GetStr(value));
        }

        /// <summary>
        /// 检测是否数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(string value) {
            if (string.IsNullOrEmpty(value.Trim())) return false;
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }

        /// <summary>
        /// 检测是否数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(object value) {
            return IsNumeric(GetStr(value));
        }

        /// <summary>
        /// 检测是否整型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt(string value) {
            if (string.IsNullOrEmpty(value)) return false;
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }

        /// <summary>
        /// 检测是否整型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt(object value) {
            return IsInt(GetStr(value));
        }

        /// <summary>
        /// 检测是否浮点型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsFloat(string value) {
            if (string.IsNullOrEmpty(value)) return false;
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }

        /// <summary>
        /// 检测是否浮点型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsFloat(object value) {
            return IsFloat(GetStr(value));
        }

        #endregion




        /// <summary>
        /// 从对象中获取布尔值,对于字符1和0 分别返回值:真,假
        /// </summary>
        /// <param name="source">获取值的变量源</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static bool GetBool(object source, bool DefaultValue)
        {
            bool? value = source as bool?;
            if (value != null) return value.Value;
            bool value2 = false;
            string s=GetStr(source);
            if (bool.TryParse(s, out value2)) return value2;
            if (s == "1") return true;
            if (s == "0") return false;
            if (string.Compare(s, "true", true) == 0) return true;
            if (string.Compare(s, "false", true) == 0) return true;
            
            return DefaultValue;
        }

        

        /// <summary>
        /// 从对象中获取(转换)为整型变量
        /// </summary>
        /// <param name="source">获取值的变量源</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static int GetInt(object source, int DefaultValue) {
            int temp = 0;
            if (int.TryParse(GetStr(source), out temp)) return temp;
            return DefaultValue; 
        }

        /// <summary>
        /// 从对象中获取(转换)为整型变量
        /// </summary>
        /// <param name="defaultValue">默认值</param>
        /// <param name="minValue">最小值,当 source小于该参数值 或 source转换失败 返回defaultValue</param>
        /// <param name="maxValue">最大值,当 source大于该参数值 或 source转换失败 返回defaultValue</param>
        /// <returns></returns>
        public static int GetInt(object source, int defaultValue,int minValue, int maxValue)
        {
            int temp = 0;
            if (int.TryParse(GetStr(source), out temp))
            {
                if (temp < minValue) return minValue;
                if (temp > maxValue) return maxValue;
                return temp;
            }
            return defaultValue;
        }

        /// <summary>
        /// 从两数值来源( <paramref name="basicValue"/> 与 <paramref name="refreshValue"/>)获取最新有效的值
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="basicValue">基础值,当<paramref name="refreshValue"/> 无效时,该值会作为候选值</param>
        /// <param name="refreshValue">刷新的有效值,当该值无效时会用<paramref name="basicValue"/>代替</param>
        /// <param name="defaultValue">默认值,当<paramref name="basicValue"/>与<paramref name="refreshValue"/>同时无效时,会选取该参数作为默认返回值</param>
        /// <returns></returns>
        public static int GetInt(object basicValue, object refreshValue, int defaultValue)
        {
            if (IsNumeric(refreshValue))//有效的更新值
            {
                return GetInt(refreshValue, -1);
            }

            if (IsNumeric(basicValue))//基础值
            {
                return GetInt(basicValue, -1);
            }

            return defaultValue;
        }


        /// <summary>
        /// 从对象中获取(转换)为长整型变量
        /// </summary>
        /// <param name="source">获取值的变量源</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static long GetLong(object source, long DefaultValue) {
            long temp = 0;
            if (long.TryParse(GetStr(source), out temp)) return temp;
            return DefaultValue;  
        }
        

        /// <summary>
        /// 从对象中获取(转换)为长整型变量
        /// </summary>
        /// <param name="minValue">最小值(默认值),当 source小于该参数值 或 source转换失败 是 返回该参数的值</param>
        /// <param name="maxValue">最大值</param>
        /// <returns></returns>
        public static long GetLong(object source, long minValue, long maxValue)
        {
            long temp = 0;
            if (long.TryParse(GetStr(source), out temp))
            {
                if (temp < minValue) return minValue;
                if (temp > maxValue) return maxValue;
                return temp;
            }
            return minValue;
        }


        /// <summary>
        /// 从两数值来源( <paramref name="basicValue"/> 与 <paramref name="refreshValue"/>)获取最新有效的值
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="basicValue">基础值,当<paramref name="refreshValue"/> 无效时,该值会作为候选值</param>
        /// <param name="refreshValue">刷新的有效值,当该值无效时会用<paramref name="basicValue"/>代替</param>
        /// <param name="defaultValue">默认值,当<paramref name="basicValue"/>与<paramref name="refreshValue"/>同时无效时,会选取该参数作为默认返回值</param>
        /// <returns></returns>
        public static long GetLong(object basicValue, object refreshValue, long defaultValue)
        {
            if (IsNumeric(refreshValue))//有效的更新值
            {
                return GetLong(refreshValue, -1);
            }

            if (IsNumeric(basicValue))//基础值
            {
                return GetLong(basicValue, -1);
            }

            return defaultValue;
        }

        /// <summary>
        /// 从对象中获取(转换)为长整型变量
        /// </summary>
        /// <param name="defaultValue">默认值</param>
        /// <param name="minValue">最小值,当 source小于该参数值 或 source转换失败 返回defaultValue</param>
        /// <param name="maxValue">最大值,当 source大于该参数值 或 source转换失败 返回defaultValue</param>
        /// <returns></returns>
        public static long GetLong(object source, long defaultValue, long minValue, long maxValue)
        {
            long temp = 0;
            if (long.TryParse(GetStr(source), out temp))
            {
                if (temp < minValue) return minValue;
                if (temp > maxValue) return maxValue;
                return temp;
            }
            return defaultValue;
        }

        /// <summary>
        /// 从对象中获取(转换)为decimal变量
        /// </summary>
        /// <param name="source">获取值的变量源</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static decimal GetDecimal(object source, decimal DefaultValue)
        {
            decimal temp = 0;
            if (decimal.TryParse(GetStr(source), out temp)) return temp;
            return DefaultValue;        
        }

        /// <summary>
        /// 从对象中获取(转换)为decimal变量
        /// </summary>
        /// <param name="minValue">最小值(默认值),当 source小于该参数值 或 source转换失败 是 返回该参数的值</param>
        /// <param name="maxValue">最大值</param>
        /// <returns></returns>
        public static decimal GetDecimal(object source, decimal minValue, decimal maxValue)
        {
            decimal temp = 0;
            if (decimal.TryParse(GetStr(source), out temp))
            {
                if (temp < minValue) return minValue;
                if (temp > maxValue) return maxValue;
                return temp;
            }
            return minValue;
        }

        /// <summary>
        /// 从两数值来源( <paramref name="basicValue"/> 与 <paramref name="refreshValue"/>)获取最新有效的值
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="basicValue">基础值,当<paramref name="refreshValue"/> 无效时,该值会作为候选值</param>
        /// <param name="refreshValue">刷新的有效值,当该值无效时会用<paramref name="basicValue"/>代替</param>
        /// <param name="defaultValue">默认值,当<paramref name="basicValue"/>与<paramref name="refreshValue"/>同时无效时,会选取该参数作为默认返回值</param>
        /// <returns></returns>
        public static decimal GetDecimal(object basicValue, object refreshValue, decimal defaultValue)
        {
            if (IsNumeric(refreshValue))//有效的更新值
            {
                return GetDecimal(refreshValue, -1);
            }

            if (IsNumeric(basicValue))//基础值
            {
                return GetDecimal(basicValue, -1);
            }

            return defaultValue;
        }

        /// <summary>
        /// 从对象中获取(转换)为浮点型变量
        /// </summary>
        /// <param name="source">获取值的变量源</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static float GetFloat(object source, float DefaultValue) {
            float temp = 0;
            if (float.TryParse(GetStr(source), out temp)) return temp;
            return DefaultValue;    
        }

        /// <summary>
        /// 从对象中获取(转换)为浮点型变量
        /// </summary>
        /// <param name="minValue">最小值(默认值),当 source小于该参数值 或 source转换失败 是 返回该参数的值</param>
        /// <param name="maxValue">最大值</param>
        /// <returns></returns>
        public static float GetFloat(object source, float minValue,float maxValue)
        {
            float temp = 0;
            if (float.TryParse(GetStr(source), out temp))
            {
                if (temp < minValue) return minValue;
                if (temp > maxValue) return maxValue;
                return temp;
            }
            return minValue;
        }

        /// <summary>
        /// 从对象中获取(转换)为数值型变量
        /// </summary>
        /// <param name="source">获取值的变量源</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static object GetNum(object source, object DefaultValue) {
            if (source == null) return DefaultValue;
            string src = source.ToString();
            if (IsNumeric(src)) return source;
            return DefaultValue;
        }




        


        public static string GetStr(object source) {
            return GetStr(source, "");
        }


        public static string GetStr(bool checkEmpty, string defaultValue, params object[] values)
        {
            for (int i = values.Length - 1; i > 0; i--)
            {
                object o = values[i];
                if (checkEmpty)
                {
                    string value = GetStr(o, "").Trim();
                    if (value.Length > 0) return value;
                }
                else
                {
                    if (o != null)
                    {
                        return GetStr(0, "");
                    }
                }
            }

            return defaultValue;
        }


        public static string GetStr(object source, string DefaultValue) {
            if (source == null || string.IsNullOrEmpty(source.ToString())) {
                if (string.IsNullOrEmpty(DefaultValue)) {
                    return string.Empty;
                }
                else {
                    return DefaultValue;
                }
            }
            else {
                return source.ToString();
            }
            //  return source.ToString();
        }

        /// <summary>
        /// 从两数值来源( <paramref name="basicValue"/> 与 <paramref name="refreshValue"/>)获取最新有效的值
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="basicValue">基础值,当<paramref name="refreshValue"/> 无效时,该值会作为候选值</param>
        /// <param name="refreshValue">刷新的有效值,当该值无效时会用<paramref name="basicValue"/>代替</param>
        /// <param name="defaultValue">默认值,当<paramref name="basicValue"/>与<paramref name="refreshValue"/>同时无效时,会选取该参数作为默认返回值</param>
        /// <param name="checkEmpty">指示是否检测空字符串,该值为真时只要检测<paramref name="basicValue"/>,<paramref name="refreshValue"/></param>为空字符串则视为无效值
        /// <returns></returns>
        public static string GetStr(object basicValue, object refreshValue, string defaultValue,bool checkEmpty)
        {
            if (refreshValue!=null)//有效的更新值
            {
                string str = GetStr(refreshValue, "");
                if (!checkEmpty)
                {
                    return str;
                }
                else
                {
                    if (str.Length > 0) return str;
                }
            }

            if (basicValue != null)//基础值
            {
                string str = GetStr(basicValue, "");
                if (!checkEmpty)
                {
                    return str;
                }
                else
                {
                    if (str.Length > 0) return str;
                }
            }

            return defaultValue;
        }


        public static DateTime? GetDateTime(object source, DateTime? defaultValue)
        {
            DateTime? ret = source as DateTime?;
            if (ret.HasValue) return ret;
            string s = GetStr(source, "");
            if (s.Length == 0) return defaultValue;
            DateTime ret2 = DateTime.Now;
            return DateTime.TryParse(s, out ret2) ? ret2 : defaultValue;
        }

        public static DateTime? GetDateTime(object basicValue, object refreshValue, DateTime? defaultValue)
        {
            DateTime? ret1 = GetDateTime(refreshValue, null);
            if (ret1 != null) return ret1;
            DateTime? ret2 = GetDateTime(basicValue, null);
            return ret2 != null ? ret2 : defaultValue;
        }

       

        /// <summary>
        /// 截取字符内容
        /// </summary>
        /// <param name="content">过长的内容</param>
        /// <param name="maxLength">返回内容的长度</param>
        /// <param name="ellipsis">省略号</param>
        /// <returns></returns>
        public static string SubString(object input, int maxLength,string ellipsis)
        {
            if (ellipsis == null)
            {
                ellipsis = string.Empty;
            }

            string strInput = GetStr(input, "");

            if (strInput.Length > maxLength)
            {
                return strInput.Substring(0, maxLength - ellipsis.Length) + ellipsis;
            }
            return strInput;
        }

        /// <summary>
        /// 迭代数组里的每一个元素并且进行格式化,返回新的数组
        /// </summary>
        /// <param name="format">输出的格式,用{0}表示当前迭代的项</param>
        /// <param name="values">迭代的数组</param>
        /// <returns></returns>
        public static string[] EachFormat(string format,params object[] values)
        {
            if (values.Length == 0) return null;
            string[] newValues = new string[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                newValues[i] = string.Format(format, values[i]);
            }
            return newValues;
        }



        /// <summary>
        /// 将指定的字符串转换成Json格式的值
        /// e.g : 
        /// string value ==>  he say:"i'll go to shopping"
        /// string json = "json:'" + Uitlity.ToJsonValue(value)  +"'"
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJsonValue(string value)
        {
            return value.Replace(@"\", @"\\").Replace("'", "\\'").Replace("\"", "\\\"");
        }

       

        


        /// <summary>
        /// 获取文件后缀名称
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileExtension(string fileName) {
            int index = fileName.LastIndexOf('.');
            if (index > 1) {
                return fileName.Substring(index);
            }
            return string.Empty;
        }

        #endregion

        #region 中文货币数字转换

        public static char NumToChar(char Num) {
            switch (Num) {
                case '1': return '壹';
                case '2': return '贰';
                case '3': return '叁';
                case '4': return '肆';
                case '5': return '伍';
                case '6': return '陆';
                case '7': return '柒';
                case '8': return '捌';
                case '9': return '玖';
                case '0': return '零';
                default: return Num;
            }
        }

        public static char NumToChar(int Num) {
            switch (Num) {
                case 1: return '壹';
                case 2: return '贰';
                case 3: return '叁';
                case 4: return '肆';
                case 5: return '伍';
                case 6: return '陆';
                case 7: return '柒';
                case 8: return '捌';
                case 9: return '玖';
                case 0: return '零';
                default: return char.Parse("");
            }
        }

        public static string NumToStr(int Num) {
            switch (Num) {
                case 1: return "壹";
                case 2: return "贰";
                case 3: return "叁";
                case 4: return "肆";
                case 5: return "伍";
                case 6: return "陆";
                case 7: return "柒";
                case 8: return "捌";
                case 9: return "玖";
                case 0: return "零";
                default: return "";
            }
        }

        public static string NumToStr(char Num) {
            switch (Num) {
                case '1': return "壹";
                case '2': return "贰";
                case '3': return "叁";
                case '4': return "肆";
                case '5': return "伍";
                case '6': return "陆";
                case '7': return "柒";
                case '8': return "捌";
                case '9': return "玖";
                case '0': return "零";
                default: return Num.ToString();
            }
        }

        #endregion

        /// <summary>
        /// 数字转为中文星期几  Tips:格式化字符串:dddd 可表示星期几
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string DayOfWeek(int i) {
            switch (i) {
                case 1: return "星期一";
                case 2: return "星期二";
                case 3: return "星期三";
                case 4: return "星期四";
                case 5: return "星期五";
                case 6: return "星期六";
                case 7: return "星期日";
            }
            return string.Empty;
        }





       
    }
    
    

    //namespace GloSqlHelper
    //{
    //    public abstract class PagingMaker
    //    {
            
    //    }

    //    /// <summary>
    //    /// <para>排序分页类</para>
    //    /// 针对排序使用Not in 方式实现
    //    /// </summary>
    //    public class SortPaging : PagingMaker
    //    {

    //        public SortPaging() { }

    //        public SortPaging(string sourceName, string identity, string where, int pageSize, int pageIndex, string orderBy) {
    //            this.SourceName = sourceName;
    //            this.Identity = identity;
    //            this.Where = where;
    //            this.PageSize = pageSize;
    //            this.PageIndex = pageIndex;
    //            this.OrderBy = orderBy;
    //        }

    //        /// <summary>
    //        /// <para>构造SQL语句</para>
    //        /// <para>通过PagingSql属性获取分页语句</para>
    //        /// <para>通过CountSql属性获取统计记录语句</para>
    //        /// </summary>
    //        public override void GenerateSql() {
    //            this.Valid();
    //            string sql = string.Empty;
    //            string AscOrDesc = this.PagingByDesc ? "desc" : "asc";
    //            if (this.PageIndex < 1) {
    //                sql = string.Format("select * from {0} [$OuterWhere] order by {1} ", this.SourceName, AscOrDesc);
    //            }
    //            else if (this.PageIndex == 1) {
    //                sql = string.Format("select top {0} * from {1} [$OuterWhere] order by {2}", this.PageSize, this.SourceName, AscOrDesc);
    //            }
    //            else {

    //                /*主要语句
    //                 @"select top {0} * from {1} where {2} not in (
    //                    select top {3} {2} from {1} [$InnerWhere] order by {2} {4}[$OrderBy] 
    //                    ) [$OuterWhere] order by {2}{4}[$OrderBy]";
    //                */
    //                sql = @"select top {0} * from {1} where {2} not in ( select top {3} {2} from {1} [$InnerWhere] order by {2} {4} [$OrderBy] ) [$OuterWhere] order by {2} {4} [$OrderBy]";

    //                sql = string.Format(sql,
    //                    this.PageSize,
    //                    this.SourceName,
    //                    this.NotRepeatField,
    //                    (this.PageIndex - 1) * this.PageSize,
    //                    AscOrDesc
    //                    );
    //            }

    //            this._countSQL = string.Format("select * from {0} [$InnerWhere] ", this.SourceName);

    //            if (this.Where.Length > 0) {
    //                sql = sql.Replace(
    //                    "[$InnerWhere]",
    //                    string.Format("where {0}", this.Where)
    //                    );
    //                sql = sql.Replace(
    //                    "[$OuterWhere]",
    //                    string.Format("and {0}", this.Where)
    //                    );
    //                this._countSQL = this._countSQL.Replace(
    //                    "[$InnerWhere]",
    //                    string.Format("where {0}", this.Where)
    //                    );
    //            }
    //            else {
    //                sql = sql.Replace("[$InnerWhere]", "").Replace("[$OuterWhere]", "");
    //                this._countSQL = this._countSQL.Replace("[$InnerWhere]", "");
    //            }

    //            if (this.OrderBy.Length > 0) {
    //                sql = sql.Replace(
    //                    "[$OrderBy]",
    //                    string.Format(",{0}", this.OrderBy)
    //                    );
    //            }
    //            else {
    //                sql = sql.Replace("[$OrderBy]", "");
    //            }

    //            this._pagingSQL = sql;

    //        }

    //    }


    //}

}

    




