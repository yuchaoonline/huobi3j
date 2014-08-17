using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using System.Configuration;
using System.Text;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ADeeWu.HuoBi3J.Libary
{
    /// <summary>
    /// GloFnc 的摘要说明
    /// </summary>
    public static class UtilityExtention
    {
        /// <summary>
        /// 对象是否为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// 对象是否不为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotNull(this object obj)
        {
            return !obj.IsNull();
        }

        /// <summary>
        /// 验证是否日期型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDateTime(this object value)
        {
            var str = GetStr(value).Trim();
            if (string.IsNullOrEmpty(str)) return false;
            return Regex.IsMatch(str, Utility.DateTimeRegex2);
        }

        /// <summary>
        /// 检测是否数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(this object value)
        {
            var str = GetStr(value).Trim();
            if (string.IsNullOrEmpty(str)) return false;
            return Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$");
        }

        /// <summary>
        /// 检测是否整型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt(this object value)
        {
            var str = GetStr(value).Trim();
            if (string.IsNullOrEmpty(str)) return false;
            return Regex.IsMatch(str, @"^[+-]?\d*$");
        }

        /// <summary>
        /// 检测是否浮点型
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsFloat(this object value)
        {
            var str = GetStr(value).Trim();
            if (string.IsNullOrEmpty(str)) return false;
            return Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$");
        }

        /// <summary>
        /// 从对象中获取布尔值,对于字符1和0 分别返回值:真,假
        /// </summary>
        /// <param name="source">获取值的变量源</param>
        /// <returns></returns>
        public static bool GetBool(this object source)
        {
            return GetBool(source, false);
        }

        /// <summary>
        /// 从对象中获取布尔值,对于字符1和0 分别返回值:真,假
        /// </summary>
        /// <param name="source">获取值的变量源</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static bool GetBool(this object source, bool DefaultValue)
        {
            bool? value = source as bool?;
            if (value != null) return value.Value;
            bool value2 = false;
            string s = GetStr(source);
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
        /// <param name="source"></param>
        /// <returns></returns>
        public static int GetInt(this object source)
        {
            return GetInt(source, 0, 0, 0);
        }

        /// <summary>
        /// 从对象中获取(转换)为整型变量
        /// </summary>
        /// <param name="source">获取值的变量源</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static int GetInt(this object source, int DefaultValue)
        {
            return GetInt(source, DefaultValue, 0, 0);
        }

        /// <summary>
        /// 从对象中获取(转换)为整型变量
        /// </summary>
        /// <param name="defaultValue">默认值</param>
        /// <param name="minValue">最小值,当 source小于该参数值 或 source转换失败 返回defaultValue</param>
        /// <param name="maxValue">最大值,当 source大于该参数值 或 source转换失败 返回defaultValue</param>
        /// <returns></returns>
        public static int GetInt(this object source, int defaultValue, int minValue, int maxValue)
        {
            if (int.TryParse(GetStr(source), out defaultValue))
            {
                if (minValue != maxValue)
                {
                    if (defaultValue < minValue) return minValue;
                    if (defaultValue > maxValue) return maxValue;
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// 从对象中获取(转换)为长整型变量
        /// </summary>
        /// <param name="source">获取值的变量源</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static long GetLong(this object source, long DefaultValue)
        {
            return GetLong(source, DefaultValue, 0l, 0l);
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
        /// <returns></returns>
        public static decimal GetDecimal(this object source)
        {
            return GetDecimal(source, 0);
        }

        /// <summary>
        /// 从对象中获取(转换)为decimal变量
        /// </summary>
        /// <param name="source">获取值的变量源</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static decimal GetDecimal(this object source, decimal DefaultValue)
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
        public static decimal GetDecimal(this object source, decimal minValue, decimal maxValue)
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
        /// 从对象中获取(转换)为浮点型变量
        /// </summary>
        /// <param name="source">获取值的变量源</param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static float GetFloat(this object source, float DefaultValue)
        {
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
        public static float GetFloat(this object source, float minValue, float maxValue)
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
        public static object GetNum(this object source, object DefaultValue)
        {
            if (source == null) return DefaultValue;
            string src = source.ToString();
            if (IsNumeric(src)) return source;
            return DefaultValue;
        }

        /// <summary>
        /// GetStr
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetStr(this object source)
        {
            return GetStr(source, "");
        }

        /// <summary>
        /// GetStr
        /// </summary>
        /// <param name="source"></param>
        /// <param name="DefaultValue">默认值</param>
        /// <returns></returns>
        public static string GetStr(this object source, string DefaultValue)
        {
            if (source == null || string.IsNullOrEmpty(source.ToString()))
            {
                if (string.IsNullOrEmpty(DefaultValue))
                {
                    return string.Empty;
                }
                else
                {
                    return DefaultValue;
                }
            }
            else
            {
                return source.ToString();
            }
            //  return source.ToString();
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(this object source)
        {
            return GetDateTime(source, DateTime.MinValue);
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <param name="source"></param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime GetDateTime(this object source, DateTime defaultValue)
        {
            string s = GetStr(source, "");
            if (s.Length == 0) return defaultValue;
            DateTime ret2 = DateTime.Now;
            return DateTime.TryParse(s, out ret2) ? ret2 : defaultValue;
        }

        /// <summary>
        /// 截取字符内容
        /// </summary>
        /// <param name="content">过长的内容</param>
        /// <param name="maxLength">返回内容的长度</param>
        /// <param name="ellipsis">省略号</param>
        /// <returns></returns>
        public static string SubString(this object input, int maxLength, string ellipsis)
        {
            if (string.IsNullOrWhiteSpace(ellipsis))
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
        /// 获取文件后缀名称
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileExtension(this string fileName)
        {
            int index = fileName.LastIndexOf('.');
            if (index > 1)
            {
                return fileName.Substring(index);
            }
            return string.Empty;
        }

        /// <summary>
        /// 不是空且含有内容
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotNullAndAny<TSource>(this List<TSource> obj)
        {
            if (obj == null) return false;
            return obj.Any();
        }

        /// <summary>
        /// 不是空且含有内容
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotNullAndAny<TSource>(this IEnumerable<TSource> obj)
        {
            if (obj == null) return false;
            return obj.Any();
        }
    }
}






