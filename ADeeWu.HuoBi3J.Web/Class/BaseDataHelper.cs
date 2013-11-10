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
using System.Collections.Generic;
using System.Linq;

namespace ADeeWu.HuoBi3J.Web.Class
{
    public class BaseDataHelper
    {
        /// <summary>
        /// 关注商圈关键字月租
        /// </summary>
        public static decimal GetAttentionKeyFee
        {
            get
            {
                return Utility.GetDecimal(GetValue(1), 10);
            }
        }

        /// <summary>
        /// 商圈扣月租日
        /// </summary>
        public static int GetCostFeeDay
        {
            get
            {
                return Utility.GetInt(GetValue(2), 1);
            }
        }
        
        /// <summary>
        /// 举报替换内容
        /// </summary>
        public static string GetInformContent
        {
            get
            {
                return Utility.GetStr(GetValue(3), "==该内容已被举报==");
            }
        }

        /// <summary>
        /// 获取货比三家未刷新而导致丢失关键字管理的天数
        /// </summary>
        public static long GetLostKeyDay
        {
            get
            {
                return Utility.GetLong(GetValue(4), 3);
            }
        }

        #region 操作方法
        private static object GetValue(int IDentity)
        {
            return BaseDatas.Any(p => p.IDentity == IDentity) ? BaseDatas.FirstOrDefault(p => p.IDentity == IDentity).Value : null;
        }

        public static Model.BaseData[] BaseDatas
        {
            get
            {
                return HttpContext.Current.Application["BaseDta"] == null ? new Model.BaseData[0] : HttpContext.Current.Application["BaseDta"] as Model.BaseData[];
            }
        }

        public static void RefreshData()
        {
            GlobalParameter.MinTransferMoney = ADeeWu.HuoBi3J.Libary.Utility.GetDecimal(System.Configuration.ConfigurationManager.AppSettings["mintransfermoney"], 10);

            var db = new DAL.BaseData();
            var datas =db.GetEntityList("", new string[0], null);
            HttpContext.Current.Application["BaseDta"] = datas;
        } 
        #endregion
    }
}
