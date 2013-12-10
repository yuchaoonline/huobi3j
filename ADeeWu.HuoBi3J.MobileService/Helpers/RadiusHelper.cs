using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADeeWu.HuoBi3J.MobileService.Helpers
{
    /// <summary>
    /// 坐标计算
    /// </summary>
    public class RadiusHelper
    {
        /// <summary>
        /// 地球半径
        /// </summary>
        public static double EARTH_RADIUS = 6378.137;
        /// <summary>
        /// 每100米经度相差值
        /// </summary>
        public static double LNG_PER = 0.00100;
        /// <summary>
        /// 每100米纬度相差值
        /// </summary>
        public static double LAT_PER = 0.00111;

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static double rad(double d)
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
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
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
    }
}