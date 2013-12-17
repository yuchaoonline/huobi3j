using ADeeWu.HuoBi3J.MobileService.Helpers;
using ADeeWu.HuoBi3J.MobileService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADeeWu.HuoBi3J.MobileService.Controllers
{
    public class SaleManController : JsonController
    {
        DAL.CA_CircleSaleMan salemanDAL = new DAL.CA_CircleSaleMan();

        /// <summary>
        /// 附近商家
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public ActionResult Index(double lat, double lng, int radius = 100)
        {
            if (radius > 1500) radius = 1500;

            var strWhere = string.Format("positionX < {0} and positionX > {1} and positionY < {2} and positionY > {3}", RadiusHelper.A(lat, radius), RadiusHelper.B(lat, radius), RadiusHelper.C(lng, radius), RadiusHelper.D(lng, radius));
            var salemanDT = salemanDAL.Select(strWhere, "");

            var salemans = new List<CircleSaleManRadius>();
            foreach (DataRow dr in salemanDT.Rows)
            {
                var tempLat = double.Parse(dr["positionX"].ToString());
                var tempLng = double.Parse(dr["positionY"].ToString());
                var distance = RadiusHelper.GetDistance(lat, lng, tempLat, tempLng);
                if (distance > radius) continue;

                var saleman = new CircleSaleManRadius
                {
                    ID = long.Parse(dr["ID"].ToString()),
                    Name = dr["Name"] as string,
                    UserID = dr["UserID"] as long?,
                    QQ = dr["QQ"] as string,
                    Phone = dr["Phone"] as string,
                    CompanyName = dr["CompanyName"] as string,
                    CompanyAddress = dr["CompanyAddress"] as string,
                    Job = dr["Job"] as string,
                    PositionX = dr["PositionX"] as double?,
                    PositionY = dr["PositionY"] as double?,
                    CheckState = dr["CheckState"] as int?,
                    ModifyTime = dr["ModifyTime"] as DateTime?,
                    CreateTime = dr["CreateTime"] as DateTime?,
                    Memo = dr["Memo"] as string,
                    Radius = distance,
                };
                salemans.Add(saleman);
            }

            return GetJson(salemans.OrderByDescending(p => p.Radius));
        }

        public class CircleSaleManRadius : Model.CA_CircleSaleMan
        {
            public double Radius { get; set; }
        }
    }
}
