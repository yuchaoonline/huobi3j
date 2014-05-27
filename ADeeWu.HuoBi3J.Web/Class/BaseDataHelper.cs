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
        /// 注册赠送券ID
        /// </summary>
        public static int RegisterCouponsID
        {
            get
            {
                return Utility.GetInt(GetValue(1), 10);
            }
        }

        /// <summary>
        /// 接口站点
        /// </summary>
        public static string MobileServiceSite
        {
            get
            {
                return GetValue(2).GetStr("http://mobile2.huobi3j.com");
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
            var datas = db.GetEntityList("", new string[] { }, new object[] { });
            HttpContext.Current.Application["BaseDta"] = datas;
        } 
        #endregion
    }
}
