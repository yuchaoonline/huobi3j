using System;
using System.Collections.Generic;
using System.Web;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.Class
{
    public class TaskHelper
    {
        /// <summary>
        /// 处理关键字在规定时间未刷新时丢失
        /// </summary>
        public static void DoCenterRefresh()
        {
            DAL.Center_Key_Manage manageDAL = new DAL.Center_Key_Manage();
            DAL.Center_Key_Refresh refreshDAL = new DAL.Center_Key_Refresh ();

            var manages = manageDAL.GetEntityList("", new string[] { }, new object[] { });

            foreach (var manage in manages)
            {
                var refreshs = refreshDAL.GetEntityList("LastTime desc", new string[] { "kid" }, new object[] { manage.KID });
                if (refreshs == null || refreshs.Length <= 0)
                {
                    //新关注，3天后未刷新的
                    if (DateTime.Now.Date > manage.CreatTime.Value.Date.AddDays(BaseDataHelper.GetLostKeyDay))
                    {
                        manageDAL.Delete(manage.ID);
                    }
                    continue;
                }
                
                //最近刷新时间已超过规定的刷新天数，丢失关键字
                if (refreshs[0].LastTime.Value.Date.AddDays(BaseDataHelper.GetLostKeyDay) < DateTime.Now.Date)
                {
                    //删除所有刷新记录
                    foreach (var refresh in refreshs)
                    {
                        refreshDAL.Delete(refresh.ID);
                    }

                    //删除关键字管理
                    manageDAL.Delete(manage.ID);
                }
            }
        }

        /// <summary>
        /// 处理发放兼职人员管理佣金
        /// </summary>
        public static void DoCenterPayForParttime()
        {
            DAL.Center_Key_Manage manageDAL = new DAL.Center_Key_Manage();
            DAL.Center_Key_Log logDAL = new DAL.Center_Key_Log();
            DAL.User_DealHistories dealDAL = new DAL.User_DealHistories();
            DAL.Key keyDAL = new DAL.Key ();
            DAL.UserKey userKeyDAL = new DAL.UserKey();
            DAL.Users userDAL = new DAL.Users();

            var manages = manageDAL.GetEntityList("", new string[] { }, new object[] { });

            foreach (var manage in manages)
            {
                //刚好够一个月发放
                if (DateTime.Now.Date == manage.CreatTime.Value.Date.AddMonths(1))
                {
                    var key = keyDAL.GetEntity(manage.KID.Value);
                    var userKeys = userKeyDAL.GetEntityList("", new string[] { "kid" }, new object[] { manage.KID });
                    if (userKeys == null || userKeys.Length <= 0) continue;

                    var benifit = manage.Price.Value * 0.2d * userKeys.Length;                 

                    var user = userDAL.GetEntity((long)manage.UID);
                    user.Money += Utility.GetDecimal(benifit, 0);
                    userDAL.Update(user);

                    var dealHistory = new Model.User_DealHistories
                    {
                        UserID = manage.UID,
                        CreateTime = DateTime.Now,
                        Notes = string.Format("{0}年{1}月管理关键字：{2} 获得费用为：{3}", DateTime.Now.Year, DateTime.Now.Month - 1, key.Name, benifit),
                        InMoney = Utility.GetDecimal(benifit, 0),
                        OutMoney = 0,
                        Balance = user.Money,
                    };
                    dealDAL.Add(dealHistory);

                    var log = new Model.Center_Key_Log
                    {
                        CreateTime = DateTime.Now,
                        KID = manage.KID,
                        UID = manage.UID,
                        Price = benifit,
                        Remark = string.Format("{0}年{1}月兼职获得费用为：{2}", DateTime.Now.Year, DateTime.Now.Month, benifit)
                    };
                    logDAL.Add(log);
                }
            }
        }

        /// <summary>
        /// 处理业务员关注到期情况
        /// </summary>
        public static void DoCenterAttentionKey()
        {
            var userKeyDAL =new DAL.UserKey();
            var userDAL = new DAL.Users();
            var dealHistoryDAL = new DAL.User_DealHistories();
            var keyDAL = new DAL.Key();

            var userKeys = userKeyDAL.GetEntityList("", new string[] { }, new object[] { });

            foreach (var userkey in userKeys)
            {
                if (userkey.CreateTime.Value.Date.AddMonths(1) <= DateTime.Now.Date)
                {
                    var user = userDAL.GetEntity(userkey.UID.Value);
                    var key = keyDAL.GetEntity(userkey.KID.Value);

                    //不续关注或不足金额支付月租
                    if (!userkey.IsGoOn || user.Money < BaseDataHelper.GetAttentionKeyFee)
                    {
                        userKeyDAL.Delete(userkey.UKID);
                        continue;
                    }

                    //够金额支付且续关注
                    if (userkey.IsGoOn && user.Money >= BaseDataHelper.GetAttentionKeyFee)
                    {
                        userkey.CreateTime = DateTime.Now;
                        userKeyDAL.Update(userkey);

                        user.Money -= BaseDataHelper.GetAttentionKeyFee;
                        userDAL.Update(user);

                        var deal = new Model.User_DealHistories
                        {
                            Balance = user.Money,
                            InMoney = 0,
                            OutMoney = BaseDataHelper.GetAttentionKeyFee,
                            UserID = user.ID,
                            Notes = string.Format("扣除关键字：{0} {1}年{2}月至{4}年{5}月关注费用：{3}", key.Name, DateTime.Now.Year, DateTime.Now.Month, BaseDataHelper.GetAttentionKeyFee, DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month),
                            CreateTime = DateTime.Now,
                        };
                        dealHistoryDAL.Add(deal);
                    }
                }
            }
        }
    }
}