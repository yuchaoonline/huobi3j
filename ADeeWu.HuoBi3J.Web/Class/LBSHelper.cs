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
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using ADee.Project.LBS.Entity;

namespace ADeeWu.HuoBi3J.Web.Class
{
    public class ProductPoi : Poi
    {
        public double Price { get; set; }
        public string Description { get; set; }
        public string BName { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string SalemanMemo { get; set; }
        public string QQ { get; set; }
        public string SelectType { get; set; }
        public string SelectPrice { get; set; }
        public string SelectSize { get; set; }
        public string KName { get; set; }
        public int KID { get; set; }
        public int AID { get; set; }
        public int CreateUserID { get; set; }
    }
    public class LBSHelper
    {
        public static string GeoProductTableID = "49566";
    }
}
