using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADeeWu.HuoBi3J.Libary
{
    public class BaiduAPIHelper
    {
        public string ApplicationKey
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["BaiduApplicantionKey"].ToString();
            }
        }

        private HttpHelper HttpHelper = new HttpHelper();

        public string GetLocationPoint(string address, string city = "")
        {
            var url = string.Format("http://api.map.baidu.com/geocoder/v2/?address={0}&city={2}&output=json&ak={1}", HttpUtility.UrlEncode(address), ApplicationKey, HttpUtility.UrlEncode(city));
            var httpResult = HttpHelper.GetHtml(new HttpItem { URL = url, ResultType = ResultType.String });
            return httpResult.Html;//.Substring(27, httpResult.Html.Length - 28);
        }

        /// <summary>
        /// 通过IP获取地址
        /// </summary>
        /// <returns>city,province</returns>
        public Dictionary<string,string> GetLocationByIP()
        {
            var httpResult = HttpHelper.GetHtml(new HttpItem
            {
                URL = string.Format("http://api.map.baidu.com/location/ip?ak={0}",ApplicationKey),
                ResultType = ResultType.String,
            });

            JObject obj = JObject.Parse(httpResult.Html);
            var resultDic = new Dictionary<string, string>();
            resultDic.Add("city", obj["content"]["address_detail"]["city"].ToString());
            resultDic.Add("province", obj["content"]["address_detail"]["province"].ToString());
            return resultDic;
        }
    }
}