using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ADeeWu.HuoBi3J.Libary
{
    public class Validator
    {

        public enum ValidationType
        {
            Email = 0
        }
                                                
        private static string _emailPattern = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public static string EmailPattern
        {
            get { return _emailPattern; }
        }

        private static string _numericeWithoutSymbolPattern = @"^(?:\d+\.\d+)|(?:\d+)$";
        /// <summary>
        /// 不带正负符号数值的验证,包括整数,浮点
        /// </summary>
        public static string NumericeWithoutSymbolPattern
        {
            get {
                return _numericeWithoutSymbolPattern;
            }
        }

        private static string _intgerWithoutSymbolPattern = @"^\d+$";
        /// <summary>
        /// 不带正负符号整型的验证
        /// </summary>
        public static string IntegerWithoutSymbolPattern
        {
            get {
                return _intgerWithoutSymbolPattern;
            }
        }
        
        public static bool Validate(ValidationType type,string input)
        {
            string regex = string.Empty;
            switch (type)
            {
                case ValidationType.Email:
                    regex = EmailPattern;
                    break;
                default:
                    throw new Exception("没有找到验证类型!");
            }

            return Regex.IsMatch(input, regex);
        }
    }
}
