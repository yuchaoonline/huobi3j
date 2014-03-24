using ADeeWu.HuoBi3J.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADeeWu.HuoBi3J.MobileService.Models;
using ADeeWu.HuoBi3J.MobileService.Helpers;
using System.Data;

namespace ADeeWu.HuoBi3J.MobileService.Controllers
{
    public class CouponsController : JsonController
    {
        DataBase db = DataBase.Create();
        DAL.Coupons_List listDAL = new DAL.Coupons_List();

        /// <summary>
        /// 注册赠送
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ActionResult RegisterTicket(int UserID)
        {
            var subject = new DAL.Coupons_Subject().GetEntity(BaseDataHelper.RegisterCouponsID);
            if (subject == null) return GetJson(new JsonResponse { status = false, message = "活动不存在" });

            var lists = listDAL.GetEntityList("money desc", new string[] { "subjectid", "isuse" }, new object[] { BaseDataHelper.RegisterCouponsID, 0 });
            try
            {
                if (lists != null && lists.Any())
                {
                    listDAL.Update("UserID", UserID, "id=" + lists.FirstOrDefault().ID);
                }
                else
                {
                    var list = new Model.Coupons_List
                    {
                        EndDate = subject.EndDate,
                        IsMoney = subject.IsMoney,
                        IsUse = false,
                        Money = subject.Money,
                        StartDate = subject.StartDate,
                        SubjectID = subject.ID,
                        Password = GeneralCode(),
                        Memo = "",
                    };

                    listDAL.Add(list);
                }
            }
            catch
            {
                return GetJson(new JsonResponse { status = false, message = "获取失败，请重试！" });
            }

            return GetJson(new JsonResponse { status = true });
        }

        public ActionResult Details(int id)
        {
            db.Parameters.Append("id", id);
            return GetJson(db.Select("vw_coupons_list", "id=@id", "").ToJson());
        }

        public ActionResult Use(int id)
        {
            var list = listDAL.GetEntity(id);
            if (list == null) return GetJson(new JsonResponse { status = false, message = "消费券不存在" });
            if (list.IsUse.HasValue && list.IsUse.Value) return GetJson(new JsonResponse { status = false, message = "消费券已使用" });
            if (!list.UserID.HasValue) return GetJson(new JsonResponse { status = false, message = "消费券未派送！" });

            if (listDAL.Update("IsUse", 1, "id=" + id) < 0)
            {
                return GetJson(new JsonResponse { status = false, message = "使用失败，请重试！" });
            }

            if (list.IsMoney.HasValue&&list.IsMoney.Value)
            {
                db.Parameters.Append("UserID", list.UserID);
                db.Parameters.Append("Money", list.Money);
                db.Parameters.Append("IsPayment", false);
                db.Parameters.Append("Notes", string.Format("注册赠送 {0} 元", list.Money));
                db.Parameters.Append("ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;
                db.AutoClearParameters = false;
                if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_User_DoDeal"), -1) != 0)
                {
                    return GetJson(new JsonResponse { status = false, message = db.Parameters["ErrorMessage"].Value.ToString() });
                }
                db.Parameters.Clear();
                db.AutoClearParameters = true;
            }
            else
            {
                db.Parameters.Append("UserID", list.UserID);
                db.Parameters.Append("Coins", list.Money);
                db.Parameters.Append("IsUseCoin", false);
                db.Parameters.Append("Notes", string.Format("注册赠送金币 {0} 个", list.Money));
                db.Parameters.Append("ErrorMessage", "", ParameterDirection.Output, DbType.String).Size = 1000;
                db.AutoClearParameters = false;
                if (ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RunProc("SP_User_DoCoinsTrans"), -1) != 0)
                {
                    return GetJson(new JsonResponse { status = false, message = db.Parameters["ErrorMessage"].Value.ToString() });
                }
                db.Parameters.Clear();
                db.AutoClearParameters = true;
            }
            return GetJson(new JsonResponse { status = true });
        }

        private string GeneralCode()
        {
            return Guid.NewGuid().ToString();
            //throw new Exception("生成码未完成！");
            //return "123456";
        }
    }
}
