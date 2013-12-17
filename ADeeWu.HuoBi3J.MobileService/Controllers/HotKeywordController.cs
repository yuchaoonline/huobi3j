using ADeeWu.HuoBi3J.MobileService.Models;
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

        [OutputCache(Duration=3600)]
        public ActionResult Index()
        {
            var hotkeys = hotkeyDAL.GetEntityList("", new string[] { "DataType" }, new object[] { "热点" });

            return GetJson(hotkeys.Select(p => new { name = p.Name }));
        }

    }
}
