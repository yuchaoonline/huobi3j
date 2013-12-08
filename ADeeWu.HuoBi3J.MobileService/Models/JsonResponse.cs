using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADeeWu.HuoBi3J.MobileService.Models
{
    public class JsonResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string data { get; set; }
    }

    /// <summary>
    /// 拓展JSON
    /// </summary>
    public static class DataTableToJson
    {
        /// <summary>
        /// JSON化DataTable
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="top">前N条</param>
        /// <returns></returns>
        public static List<object> ToJson(this DataTable dt, int top = -1)
        {
            var datas = new List<object>();

            int index = 1;
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> result = new Dictionary<string, object>();

                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName, HttpUtility.HtmlEncode(dr[dc]));
                }
                datas.Add(result);
                index++;

                if (top > 0 && index >= top) break;
            }

            return datas;
        }
    }

    public class JsonController : Controller
    {
        public JsonResult GetJson(object data)
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}