using ADeeWu.HuoBi3J.MobileService.Models;
using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADeeWu.HuoBi3J.MobileService.Controllers
{
    /// <summary>
    /// 热门关键字Controller
    /// </summary>
    public class HotKeywordController : System.Web.Http.ApiController
    {
        DAL.Key_HotKey hotkeyDAL = new DAL.Key_HotKey();
        DataBase db = DataBase.Create();

        /// <summary>
        /// 热点关键字
        /// </summary>
        /// <returns>返回热点关键字组</returns>
        public IEnumerable<HotKeyGroups> Get()
        {
            var hotkeys = hotkeyDAL.GetEntityList("", new string[] { }, new object[] { });
            return hotkeys.GroupBy(p => p.DataType).Select(p => new HotKeyGroups { name = p.Key, values = p.Select(v=>v.Name).ToList() });
        }
    }

    /// <summary>
    /// 热门组
    /// </summary>
    public class HotKeyGroups
    {
        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 名称列表
        /// </summary>
        public List<string> values { get; set; }
    }
}
