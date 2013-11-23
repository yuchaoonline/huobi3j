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
    public class ProductController : JsonController
    {
        DataBase db = DataBase.Create();
        /// <summary>
        /// 获取报价信息
        /// </summary>
        /// <param name="id">报价ID</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            if (id == 0) return Json(new JsonResponse { status = false, message = "参数有误！" });

            var products = db.Select("vw_key_product", "id = " + id, "price asc");
            return GetJson(products.ToJson(1));
        }

        /// <summary>
        /// 获取商家的报价信息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="top">前N条</param>
        /// <param name="city">所在城市，可以不填，默认佛山市</param>
        /// <param name="province">所在省份，可以不填，默认广东省</param>
        /// <returns></returns>
        public ActionResult GetProductOfSaleMan(int userid, int top, string city = "佛山市", string province = "广东省")
        {
            if (userid == 0) return Json(new JsonResponse { status = false, message = "参数有误！" });
            var sql = string.Format("select {3} * from vw_key_product where createuserid = {0} and pname='{1}' and cname='{2}' order by price asc", userid, province, city, top == 0 ? "" : "top " + top);
            var products = db.Select(sql);

            return GetJson(products.ToJson());
        }

        /// <summary>
        /// 搜索报价
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <param name="lat">所在位置LAT</param>
        /// <param name="lng">所在位置LNG</param>
        /// <param name="radius">半径范围</param>
        /// <param name="type">报价类型</param>
        /// <param name="price">报价价格</param>
        /// <param name="size">报价其他信息</param>
        /// <param name="sort">排序方式</param>
        /// <param name="city">所在城市</param>
        /// <param name="province">所在省份</param>
        /// <returns></returns>
        public ActionResult SearchProduct(string keyword, double lat, double lng, int radius, string type, string price, string size, string sort, string city = "佛山市", string province = "广东省")
        {
            var result = new DataTable();

            //计算矩形四个点
            var lat1 = lat + LAT_PER * radius / 100;
            var lat2 = lat - LAT_PER * radius / 100;
            var lng1 = lng + LNG_PER * radius / 100;
            var lng2 = lng - LNG_PER * radius / 100;

            var strWhere = string.Format("cname='{4}' and pname='{5}' and dbo.f_ntof(positionX) BETWEEN {0} and {1} and dbo.f_ntof(positionY) between {2} and {3}", lat1, lat2, lng1, lng2, city, province);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                strWhere += string.Format(" and kname like '%{0}%'", keyword);
            }
            var products = db.Select("vw_Key_Product", strWhere, "price asc");
            foreach (System.Data.DataRow product in products.Rows)
            {
                var tempLat = double.Parse(product["positionX"].ToString());
                var tempLng = double.Parse(product["positionY"].ToString());
                var distance = GetDistance(lat, lng, tempLat, tempLng);
                distance = Math.Abs(distance);
                if (radius >= distance)
                    result.Rows.Add(product);
            }

            return GetJson(result.ToJson());
        }

        /// <summary>
        /// 地球半径
        /// </summary>
        private const double EARTH_RADIUS = 6378.137;
        /// <summary>
        /// 每100米经度相差值
        /// </summary>
        private const double LNG_PER = 0.00100;
        /// <summary>
        /// 每100米纬度相差值
        /// </summary>
        private const double LAT_PER = 0.00111;
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        } 
        /// <summary>
        /// 获取两个坐标点之间的距离，单位m，小数点后2位
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lng1"></param>
        /// <param name="lat2"></param>
        /// <param name="lng2"></param>
        /// <returns></returns>
        private double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);
            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);

            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }
    }
}
