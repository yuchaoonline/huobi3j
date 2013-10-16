using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web
{
    /// <summary>
    /// 全局参数
    /// </summary>
    public static class GlobalParameter
    {
        
        ///// <summary>
        ///// 现金券状态值对应的显示文字,用于ADeeWu.HuoBi3J.Libary.WebUtility.Switch方法的参数传递
        ///// </summary>
        public static readonly object[] CashTicket_CheckState = new object[]
        {
            "未审核",//ID = 0
            "已审核",//ID = 1
            "已过期",//ID = 2
            "无效"//ID = 3
        };


        public static readonly string[][] switch_Sex = new string[3][]{
            new string[]{"0",""},
            new string[]{"1","男"},
            new string[]{"2","女"}
        };

        public static readonly string[][] switch_Education = new string[][]
        {
             new string[]{"0",""},
             new string[]{"1","高中以下"},
             new string[]{"2","高中以上"},
             new string[]{"3","大专以上"},
             new string[]{"4","大学以上"},
             new string[]{"5","本科以上"}
        };

        public static readonly string[][] switch_WorkExp = new string[][]
        {
             new string[]{"0","一年以上"},
             new string[]{"1","两年以上"},
             new string[]{"2","三年以上"},
             new string[]{"3","大专以上"},
             new string[]{"4","五年以上"}
        };

        /// <summary>
        /// 用户转帐至少金额
        /// </summary>
        public static decimal MinTransferMoney
        {
            get { return ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(HttpContext.Current.Application["MinTransferMoney"], 10); }
            set { HttpContext.Current.Application["MinTransferMoney"] = value; }
        }

        /// <summary>
        /// 金额转换货币汇率,即每1元可以兑换的货币数量
        /// </summary>
        public static int MoneyToCoinsRate
        {
            get { return ADeeWu.HuoBi3J.Libary.Utility.GetInt(HttpContext.Current.Application["MoneyToCoinsRate"], 10); }
            set { HttpContext.Current.Application["MoneyToCoinsRate"] = value; }
        }


        /// <summary>
        /// 获取指定用户WebIM在线状态图标地址
        /// </summary>
        /// <param name="uin"></param>
        /// <returns></returns>
        public static string GetWebIMStateURL(string uin)
        {
           // return string.Format("http://imservice/Handler/External/GetImg.ashx?uin={0}", uin);
            string webimStateURLFormat = System.Configuration.ConfigurationManager.AppSettings["WebIMStateURLFormat"];
            if (string.IsNullOrEmpty(webimStateURLFormat)) return string.Empty;
            return string.Format(webimStateURLFormat, uin);
        }


        public static long DataList_PageSize
        {
            get { return ADeeWu.HuoBi3J.Libary.Utility.GetInt(HttpContext.Current.Application["DataList_PageSize"], 20); }
            set { HttpContext.Current.Application["DataList_PageSize"] = value; }
        }
    }
}
