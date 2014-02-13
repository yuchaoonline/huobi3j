using ADeeWu.HuoBi3J.MobileService.Models;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADeeWu.HuoBi3J.MobileService.Controllers
{
    public class HotKeywordController : JsonController
    {
        DAL.Key_HotKey hotkeyDAL = new DAL.Key_HotKey();
        DataBase db = DataBase.Create();

        [OutputCache(Duration=3600)]
        public ActionResult Index()
        {
            //var hotkeys = hotkeyDAL.GetEntityList("", new string[] { "DataType" }, new object[] { "热点" });
            //var result = hotkeys.Select(p => new { name = p.Name });

            var hotkeys = hotkeyDAL.GetEntityList("", new string[] { }, new object[] { });
            var result = hotkeys.GroupBy(p => p.DataType).Select(p => new { name = p.Key, values = p.Select(v => new { value = v.Name }) });

            return GetJson(result);
        }

        private int GetExt(int id)
        {
            var kidTB = db.Select("select kid from Center_HotKey_Ext where dataid = " + id);
            if (kidTB != null && kidTB.Rows.Count > 0)
                return (int)kidTB.Rows[0][0];

            return 0;
        }

        public ActionResult Index2()
        {
            var hotkeys = hotkeyDAL.GetEntityList("", new string[] { }, new object[] { });
            var result = hotkeys.GroupBy(p => p.DataType).Select(p => new { name = p.Key, values = p.Select(v => new { value = v.Name, kid = GetExt(v.ID) }) });

            return GetJson(result);
        }
    }
}
