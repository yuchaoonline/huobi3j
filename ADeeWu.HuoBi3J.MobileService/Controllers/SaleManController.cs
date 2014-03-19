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
    public class SaleManController : JsonController
    {
        DAL.Key_CircleSaleMan salemanDAL = new DAL.Key_CircleSaleMan();
        DAL.Key_QR_Log qrLogDAL = new DAL.Key_QR_Log();
        DAL.Users userDAL = new DAL.Users();
        DAL.User_CoinUseHistories dealHistoryDAL = new DAL.User_CoinUseHistories();

        int qrFee = 10;

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

        public ActionResult GetSaleManDetails(double lat, double lng, int userid)
        {
            if (userid <= 0) return GetJson(new JsonResponse{ status = false, message = "error"});

            var user = salemanDAL.GetEntity("userid=" + userid);
            if (user == null) return GetJson(new JsonResponse { status = false, message = "商家不存在!" });

            var distance = 0d;
            if (lat > 0 && lng > 0&&user.PositionY.HasValue&&user.PositionX.HasValue)
            {
                distance = RadiusHelper.GetDistance(lat, lng, user.PositionX.Value, user.PositionY.Value);
            }

            return GetJson(new CircleSaleManRadius
            {
                CheckState= user.CheckState,
                CompanyAddress = user.CompanyAddress,
                CompanyName = user.CompanyName,
                CreateTime = user.CreateTime,
                ID = user.ID,
                Job = user.Job,
                Memo = user.Memo,
                ModifyTime = user.ModifyTime,
                Name = user.Name,
                Phone = user.Phone,
                PositionX = user.PositionX,
                PositionY = user.PositionY,
                QQ = user.QQ,
                Radius = distance,
                UserID = user.UserID,
            });
        }

        /// <summary>
        /// 扫描商家二维码
        /// </summary>
        /// <param name="userid">扫描人ID</param>
        /// <param name="salemanuserid">商家ID</param>
        /// <returns></returns>
        public ActionResult ScanQR(int userid, int salemanuserid)
        {
            if (salemanuserid == 0 && userid == 0)
            {
                return GetJson(new JsonResponse { status = false, message = "参数错误！" });
            }

            if (qrLogDAL.Exist(new string[] { "userid", "salemanuserid" }, new object[] { userid, salemanuserid }))
            {
                return GetJson(new JsonResponse { status = false, message = "你已扫描过该商家！" });
            }

            var qrLog = new Model.Key_QR_Log
            {
                Coin = 10,
                CreateDate = DateTime.Now,
                SaleManUserID = salemanuserid,
                UserID = userid,
                Demo = ""
            };
            if (qrLogDAL.Add(qrLog) > 0)
            {
                var user = userDAL.GetEntity(userid);
                user.Coins += qrFee;
                userDAL.Update(user);

                var deal = new Model.User_CoinUseHistories
                {
                    InCoin = qrFee,
                    OutCoin = 0,
                    UserID = userid,
                    Notes = string.Format("获得扫描金币 {0} 个", qrFee),
                    CreateTime = DateTime.Now,
                    Remain = user.Coins
                };
                dealHistoryDAL.Add(deal);

                return GetJson(new JsonResponse { status = true, message = string.Format("扫描成功，已入账{0}金币", qrFee), data = qrFee.ToString() });
            }

            return GetJson(new JsonResponse { status = false, message = "扫描失败，请重试！" });
        }
        
        public class CircleSaleManRadius : Model.Key_CircleSaleMan
        {
            public double Radius { get; set; }
        }
    }
}
