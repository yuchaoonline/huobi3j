﻿using ADeeWu.HuoBi3J.SQL;
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
        DAL.Coupons_Subject subjectDAL = new DAL.Coupons_Subject();

        /// <summary>
        /// 注册赠送
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public ActionResult RegisterTicket(int UserID)
        {
            try
            {
                GetTicket(BaseDataHelper.RegisterCouponsID, UserID);
            }
            catch (Exception ex)
            {
                return GetJson(new JsonResponse { status = false, message = ex.Message });
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

            var subject = subjectDAL.GetEntity(list.SubjectID.Value);
            if (subject == null) return GetJson(new JsonResponse { status = false, message = "活动不存在！" });

            if (listDAL.Update(new string[] { "IsUse", "usedate" }, new object[] { 1, DateTime.Now }, "id=" + id) < 0)
            {
                return GetJson(new JsonResponse { status = false, message = "使用失败，请重试！" });
            }

            if (list.IsMoney.HasValue && list.IsMoney.Value)
            {
                db.Parameters.Append("UserID", list.UserID);
                db.Parameters.Append("Money", list.Money);
                db.Parameters.Append("IsPayment", false);
                db.Parameters.Append("Notes", string.Format("参加{1}活动获得 {0} 元", list.Money, subject.Name));
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
                db.Parameters.Append("Notes", string.Format("参加{1}活动获得金币 {0} 个", list.Money, subject.Name));
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

        public ActionResult UserTicket(int UserID, int PageIndex = 1, int PageSize = 10)
        {
            return GetJson(db.Select(PageSize, PageIndex, "vw_Coupons_List", "id", "userid=" + UserID, "isuse desc, money desc, enddate desc").ToJson());
        }

        private void GetTicket(int SubjectID, int UserID)
        {
            var subject = new DAL.Coupons_Subject().GetEntity(SubjectID);
            if (subject == null) throw new Exception("活动不存在");
            if (!subject.Inactive.HasValue || subject.Inactive.Value) throw new Exception("活动已结束！");
            if (listDAL.Exist(new string[] { "subjectid", "userid" }, new object[] { SubjectID, UserID })) throw new Exception("已参加该活动");

            //var lists = listDAL.GetEntityList("ismoney desc, money desc", new string[] { "subjectid", "userid" }, new object[] { SubjectID,"is not null" });
            var lists = listDAL.Select(string.Format("subjectid={0} and userid is null", SubjectID), "ismoney desc, money desc");
            if (lists != null && lists.Rows.Count>0)
            {
                listDAL.Update("UserID", UserID, "id=" + lists.Rows[0]["ID"].ToString());
            }
            else
            {
                throw new Exception("优惠券已派送完！");
            }
        }
    }
}
