using ADeeWu.HuoBi3J.MobileService.Models;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADeeWu.HuoBi3J.MobileService.Controllers
{
    public class KeywordController : JsonController
    {
        DataBase db = DataBase.Create();

        /// <summary>
        /// 获取关键字的属性
        /// </summary>
        /// <param name="kid">kid</param>
        /// <returns></returns>
        public ActionResult GetKeywordAttribute(int kid)
        {
            var attributes = new DAL.Key_Attribute().GetEntityList("", new string[] { "kid" }, new object[] { kid });
            if (attributes != null)
            {
                return GetJson(new
                {
                    ktype = attributes.Where(p => p.DataType == "SelectType").Select(p => new { id = p.ID, name = p.DataValue }),
                    kprice = attributes.Where(p => p.DataType == "SelectPrice").Select(p => new { id = p.ID, name = p.DataValue }),
                    kother = attributes.Where(p => p.DataType == "SelectSize").Select(p => new { id = p.ID, name = p.DataValue }),
                });
            }

            return GetJson(new { ktype = "", kprice = "", kother = "" });
        }

        /// <summary>
        /// 获取商家的关键字
        /// </summary>
        /// <param name="userid">商家ID</param>
        /// <param name="pagesize">N条，默认10</param>
        /// <param name="pageindex">前N页，默认1，-1不分页</param>
        /// <returns></returns>
        public ActionResult GetKeywordOfSaleman(int userid, int pagesize = 10, int pageindex = 1)
        {
            var keys = new DataTable();
            if (pageindex != -1)
            {
                keys = db.Select(pagesize, pageindex, "vw_UserKey", "ukid", string.Format("uid={0}", userid), "");
            }
            else
            {
                keys = db.Select("vw_UserKey", string.Format("uid={0}", userid), "");
            }

            return GetJson(keys.ToJson());
        }
    }
}
