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
                return System.Configuration.ConfigurationManager.AppSettings["ak"].ToString();
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
        public Dictionary<string, string> GetLocationByIP(string ip = "")
        {
            if (ip == "::1") ip = "";

            var httpResult = HttpHelper.GetHtml(new HttpItem
            {
                URL = string.Format("http://api.map.baidu.com/location/ip?ak={0}&ip={1}", ApplicationKey, ip),
                ResultType = ResultType.String,
            });

            var resultDic = new Dictionary<string, string>();
            try
            {
                JObject obj = JObject.Parse(httpResult.Html);
                resultDic.Add("city", obj["content"]["address_detail"]["city"].ToString());
                resultDic.Add("province", obj["content"]["address_detail"]["province"].ToString());
            }
            catch (Exception ex)
            {
                resultDic.Add("city", "佛山市");
                resultDic.Add("province", "广东省");
            }
            return resultDic;
        }
    }
}