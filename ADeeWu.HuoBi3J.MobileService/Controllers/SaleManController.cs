using ADeeWu.HuoBi3J.MobileService.Helpers;
using ADeeWu.HuoBi3J.MobileService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADeeWu.HuoBi3J.MobileService.Controllers
{
    public class SaleManController : JsonController
    {
        DAL.CA_CircleSaleMan salemanDAL = new DAL.CA_CircleSaleMan();

        public ActionResult Index(double lat, double lng, int radius = 100)
        {
            if (radius > 1500) radius = 1500;

            //计算矩形四个点
            var lat1 = lat + RadiusHelper.LAT_PER * radius / 100;
            var lat2 = lat - RadiusHelper.LAT_PER * radius / 100;
            var lng1 = lng + RadiusHelper.LNG_PER * radius / 100;
            var lng2 = lng - RadiusHelper.LNG_PER * radius / 100;

            var strWhere = string.Format("positionX < {0} and positionX > {1} and positionY < {2} and positionY > {3}", lat1, lat2, lng1, lng2);
            var salemanDT = salemanDAL.Select(strWhere, "");

            return GetJson(salemanDT.ToJson());
        }
    }
}
