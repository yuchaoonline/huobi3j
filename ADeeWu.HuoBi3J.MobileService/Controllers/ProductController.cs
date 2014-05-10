using ADee.Project.LBS.BLL;
using ADee.Project.LBS.Common;
using ADee.Project.LBS.Entity;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.MobileService.Helpers;
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
        DAL.Common_Count_Click commonCountDAL = new DAL.Common_Count_Click();

        /// <summary>
        /// 获取报价信息，http://mobile.huobi3j.com/product/details
        /// </summary>
        /// <param name="id">报价ID</param>
        /// <returns></returns>
        //[OutputCache(Duration = 3600, VaryByParam = "id")]
        public ActionResult Details(int id)
        {
            if (id == 0) return Json(new JsonResponse { status = false, message = "参数有误！" });

            var poiBLL = new PoiBLL();
            var poi =  poiBLL.Details<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>(id, ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID);

            AddClickCount(id);

            return GetJson(poi);
        }

        /// <summary>
        /// 获取商家的报价信息，http://mobile.huobi3j.com/product/getproductofsaleman
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="pageindex">页码</param>
        /// <param name="pagesize">页容量</param>
        /// <returns></returns>
        //[OutputCache(Duration = 3600, VaryByParam = "userid;pageindex;pagesize")]
        public ActionResult GetProductOfSaleMan(int userid, int pageindex = 0, int pagesize = 10, string sort = "Price", string desc = "asc")
        {
            if (userid == 0) return Json(new JsonResponse { status = false, message = "参数有误！" });

            var sortby = "";
            if (!string.IsNullOrWhiteSpace(sort))
            {
                sortby = sort + ":1";
                if (desc == "desc")
                {
                    sortby = sort + ":0";
                }
            }

            var pois = new GeoSearchBLL().Local<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductContent>(
                ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID,
                "",
                "",
                pageindex,
                pagesize,
                "",
                sortby,
                string.Format("CreateUserID:[{0}]", userid)).contents;

            return GetJson(pois);
        }
        
        /// <summary>
        /// 搜索报价，http://mobile.huobi3j.com/product/searchproduct
        /// </summary>
        /// <param name="kid">关键字ID</param>
        /// <param name="lat">所在位置LAT</param>
        /// <param name="lng">所在位置LNG</param>
        /// <param name="typeid">报价类型ID</param>
        /// <param name="priceid">报价范围ID</param>
        /// <param name="sizeid">报价其他信息ID</param>
        /// <param name="radius">半径，默认1000</param>
        /// <param name="sort">排序方式，默认Price</param>
        /// <param name="desc">升降序，默认asc，可选desc</param>
        /// <param name="pageindex">页码，默认1</param>
        /// <param name="pagesize">页容量，默认10</param>
        /// <returns></returns>
        //[OutputCache(Duration = 3600, VaryByParam = "keyword;lat;lng;type;price;size;radius;sort;desc;pageindex,pagesize")]
        public ActionResult SearchProduct(int? kid, double lat, double lng, string typeid, string priceid, string sizeid, int radius = 1000, string sort = "Price", string desc = "asc", int pageindex = 1, int pagesize = 10)
        {
            var filter = "";
            if (kid.HasValue && kid.Value > 0)
            {
                filter += string.Format("|KID:[{0}]", kid);
            }
            if (!string.IsNullOrWhiteSpace(typeid))
            {
                filter += string.Format("|SelectTypeID:[{0}]", typeid);
            }
            if (!string.IsNullOrWhiteSpace(priceid))
            {
                filter += string.Format("|SelectPriceID:[{0}]", priceid);
            }
            if (!string.IsNullOrWhiteSpace(sizeid))
            {
                filter += string.Format("|SelectSizeID:[{0}]", sizeid);
            }
            if (filter.StartsWith("|")) filter = filter.Substring(1);

            var sortby = "";
            if (!string.IsNullOrWhiteSpace(sort))
            {
                sortby = sort + ":1";
                if (desc == "desc")
                {
                    sortby = sort + ":0";
                }
            }

            var geoSearchBLL = new GeoSearchBLL();

            var productGeoSearchResult = geoSearchBLL.NearBy<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductContent>(ADee.Project.LBS.Common.ConfigHelper.GeoProductTableID, "", lat, lng, radius, pageindex - 1, pagesize, "", sortby, filter);

            return GetJson(productGeoSearchResult);
        }

        /// <summary>
        /// 添加查看次数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AddClickCount(int id = 0)
        {
            try
            {
                if (id == 0) return GetJson(new JsonResponse { status = false, message = "参数有误！" });

                var product = new PoiBLL().Details<ADeeWu.HuoBi3J.Libary.LBSHelper.ProductPoi>(id, ConfigHelper.GeoProductTableID);
                if (product.poi == null) return GetJson(new JsonResponse { status = false, message = "报价不存在！" });

                var clickID = new DAL.Common_Count_Click().Add(new Model.Common_Count_Click
                {
                    CreateDate = System.DateTime.Now,
                    DataID = id,
                    DataType = "center_product",
                    IP = Request.UserHostAddress,
                });
                if (clickID <= 0) return GetJson(new JsonResponse { status = false, message = "统计出错！" });               

                var keyPrice = new DAL.Key_ViewPrice().GetEntity("kid=" + product.poi.KID);
                if (keyPrice != null)
                {
                    var countClickDAL = new DAL.Common_Count_Click();
                    var productCount = Utility.GetInt(DataBase.Create().ExecuteScalar(string.Format("select count(*) from common_count_click c where c.dataid={0} and datatype='center_product' and datediff(DD,c.createdate,getdate())=0", id)), 0);

                    if (keyPrice.Count >= productCount)
                    {
                        new DAL.Key_ViewPrice_Log().Add(new Model.Key_ViewPrice_Log
                        {
                            CountClickID = clickID,
                            Price = keyPrice.Price,
                        });

                        //扣费
                    }
                }


            }
            catch
            {

            }

            return GetJson(new JsonResponse { status = true });
        }

        /// <summary>
        /// 获取查看次数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetViewCount(int id)
        {
            var count = commonCountDAL.GetEntityList("", new string[] { "dataid", "datatype" }, new object[] { id, "center_product" }).Count();

            return GetJson(new { Count = count });
        }
    }
}
