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
        /// 获取报价信息，http://mobile.huobi3j.com/product/details
        /// </summary>
        /// <param name="id">报价ID</param>
        /// <returns></returns>
        [OutputCache(Duration = 3600, VaryByParam = "id")]
        public ActionResult Details(int id)
        {
            if (id == 0) return Json(new JsonResponse { status = false, message = "参数有误！" });

            var products = db.Select("vw_key_product", "id = " + id, "price asc");
            return GetJson(products.ToJson(1));
        }

        /// <summary>
        /// 获取商家的报价信息，http://mobile.huobi3j.com/product/getproductofsaleman
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="top">前N条</param>
        /// <param name="city">所在城市，可以不填，默认佛山市</param>
        /// <param name="province">所在省份，可以不填，默认广东省</param>
        /// <returns></returns>
        [OutputCache(Duration = 3600, VaryByParam = "userid;top;city;province")]
        public ActionResult GetProductOfSaleMan(int userid, int top, string city = "佛山市", string province = "广东省")
        {
            if (userid == 0) return Json(new JsonResponse { status = false, message = "参数有误！" });
            var sql = string.Format("select {3} * from vw_key_product where createuserid = {0} and pname='{1}' and cname='{2}' order by price asc", userid, province, city, top == 0 ? "" : "top " + top);
            var products = db.Select(sql);

            return GetJson(products.ToJson());
        }

        /// <summary>
        /// 搜索报价，http://mobile.huobi3j.com/product/searchproduct
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
        [OutputCache(Duration = 3600, VaryByParam = "keyword;lat;lng;type;price;size;radius;sort;desc;city;province")]
        public ActionResult SearchProduct(string keyword,string productprice, double lat, double lng, string type, string price, string size, int radius = 100, string sort = "price", string desc = "asc", string city = "佛山市", string province = "广东省")
        {
            var result = new List<Product>();

            if (radius > 1500) radius = 1500;

            //计算矩形四个点
            var lat1 = lat + LAT_PER * radius / 100;
            var lat2 = lat - LAT_PER * radius / 100;
            var lng1 = lng + LNG_PER * radius / 100;
            var lng2 = lng - LNG_PER * radius / 100;

            var strWhere = string.Format("cname='{4}' and pname='{5}' and positionX < {0} and positionX > {1} and positionY < {2} and positionY > {3}", lat1, lat2, lng1, lng2, city, province);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                strWhere += string.Format(" and kname like '%{0}%'", keyword);
            }
            if (!string.IsNullOrWhiteSpace(type))
            {
                strWhere += string.Format(" and selecttype = {0}", type);
            }
            if (!string.IsNullOrWhiteSpace(price))
            {
                strWhere += string.Format(" and selectprice = {0}", price);
            }
            if (!string.IsNullOrWhiteSpace(size))
            {
                strWhere += string.Format(" and selectsize = {0}", size);
            }
            var sortdesc = sort + " " + desc;
            var products = db.Select("vw_Key_Product", strWhere, sort.ToLower() == "distance" ? "" : sortdesc);
            foreach (System.Data.DataRow product in products.Rows)
            {
                var tempLat = double.Parse(product["positionX"].ToString());
                var tempLng = double.Parse(product["positionY"].ToString());
                var distance = GetDistance(lat, lng, tempLat, tempLng);
                distance = Math.Abs(distance);
                if (radius >= distance)
                {
                    result.Add(new Product
                    {
                        ID = product["ID"].ToString(),
                        Price = product["Price"].ToString(),
                        SimpleDesc = product["SimpleDesc"].ToString(),
                        Description = product["Description"].ToString(),
                        KName = product["KName"].ToString(),
                        BID = product["BID"].ToString(),
                        KCreateTime = product["KCreateTime"].ToString(),
                        BName = product["BName"].ToString(),
                        BCreateTime = product["BCreateTime"].ToString(),
                        AID = product["AID"].ToString(),
                        AName = product["AName"].ToString(),
                        CID = product["CID"].ToString(),
                        CName = product["CName"].ToString(),
                        PID = product["PID"].ToString(),
                        PName = product["PName"].ToString(),
                        QuestionCount = product["QuestionCount"].ToString(),
                        AttentionCount = product["AttentionCount"].ToString(),
                        KID = product["KID"].ToString(),
                        CreateUserID = product["CreateUserID"].ToString(),
                        CompanyName = product["CompanyName"].ToString(),
                        CompanyAddress = product["CompanyAddress"].ToString(),
                        PositionX = product["PositionX"].ToString(),
                        PositionY = product["PositionY"].ToString(),
                        Phone = product["Phone"].ToString(),
                        Memo = product["Memo"].ToString(),
                        QQ = product["QQ"].ToString(),
                        ClickCount = product["ClickCount"].ToString(),
                        SelectType = product["SelectType"].ToString(),
                        SelectPrice = product["SelectPrice"].ToString(),
                        SelectSize = product["SelectSize"].ToString(),
                        Distance = distance.ToString()
                    });
                }
            }

            if ("distance" == sort.ToLower())
            {
                if ("desc" == desc)
                    result = result.OrderByDescending(p => p.Distance).ToList();
                else
                    result = result.OrderBy(p => p.Distance).ToList();
            }

            return GetJson(result);
        }

        #region 坐标计算
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
            s = Math.Round(s * 10000) / 10;
            return s;
        }
        #endregion

        public class Product
        {
            public string ID { get; set; }
            public string Price { get; set; }
            public string SimpleDesc { get; set; }
            public string Description { get; set; }
            public string KName { get; set; }
            public string BID { get; set; }
            public string KCreateTime { get; set; }
            public string BName { get; set; }
            public string BCreateTime { get; set; }
            public string AID { get; set; }
            public string AName { get; set; }
            public string CID { get; set; }
            public string CName { get; set; }
            public string PID { get; set; }
            public string PName { get; set; }
            public string QuestionCount { get; set; }
            public string AttentionCount { get; set; }
            public string KID { get; set; }
            public string CreateUserID { get; set; }
            public string CompanyName { get; set; }
            public string CompanyAddress { get; set; }
            public string PositionX { get; set; }
            public string PositionY { get; set; }
            public string Phone { get; set; }
            public string Memo { get; set; }
            public string QQ { get; set; }
            public string ClickCount { get; set; }
            public string SelectType { get; set; }
            public string SelectPrice { get; set; }
            public string SelectSize { get; set; }
            public string Distance { get; set; }
        }
    }
}
