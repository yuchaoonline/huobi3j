using System;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.Center.KeyManage
{
    public partial class Refresh : Class.PageBase_MyUser
    {
        private static decimal brokerage = 1;

        public override string FunctionCode
        {
            get
            {
                return "My-User-Center-KeyManage-Refresh";
            }
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 参数处理

                long id = WebUtility.GetRequestLong("id", 0);
                if (id == 0)
                {
                    WebUtility.ShowAndGoBack(this, "参数有误！");
                    return;
                }
                DAL.Key keyDAL = new DAL.Key();
                Model.Key key = keyDAL.GetEntity(id);
                if (key == null || key.KID == 0)
                {
                    WebUtility.ShowAndGoBack(this, "无此关键字！");
                    return;
                }

                #endregion 参数处理

                #region 是否已刷新关键字

                DAL.Center_Key_Refresh refreshDAL = new DAL.Center_Key_Refresh();
                if (refreshDAL.Exist(string.Format("datediff(dy,lasttime,'{0}') = 0 and kid = {1} and uid = {2}", DateTime.Now, key.KID, LoginUser.UserID)))
                {
                    WebUtility.ShowAndGoBack(this, "勤劳的人，你今天已刷新过了！");
                    return;
                }

                #endregion 是否已刷新关键字

                #region 扣掉金币

                DAL.Users userDAL = new DAL.Users();
                Model.Users user = userDAL.GetEntity(LoginUser.UserID);
                if (user.Coins < brokerage)
                {
                    WebUtility.ShowAndGoBack(this, "金币不足" + brokerage + "，刷新失败！");
                    return;
                }
                user.Coins -= brokerage;
                if (userDAL.Update(user) <= 0)
                {
                    WebUtility.ShowAndGoBack(this, "扣除金币失败，请重试！");
                    return;
                }

                #endregion 扣掉金币

                #region 添加金币记录

                Model.User_CoinUseHistories history = new Model.User_CoinUseHistories
                {
                    CreateTime = DateTime.Now,
                    InCoin = 0,
                    OutCoin = brokerage,
                    Notes = string.Format("刷新货比三家关键字：{0}，扣除金币：{1}！", key.Name, brokerage),
                    Remain = user.Coins,
                    UserID = user.ID
                };
                if (new DAL.User_CoinUseHistories().Add(history) <= 0)
                {
                    WebUtility.ShowAndGoBack(this, "添加金币消费记录失败！");
                }

                #endregion 添加金币记录

                #region 刷新关键字

                Model.Center_Key_Refresh refresh = new Model.Center_Key_Refresh
                        {
                            KID = key.KID,
                            UID = LoginUser.UserID,
                            LastTime = DateTime.Now,
                        };
                if (refreshDAL.Add(refresh) > 0)
                {
                    WebUtility.ShowAndGoBack(this, "刷新成功！");
                    return;
                }
                else
                {
                    WebUtility.ShowAndGoBack(this, "刷新失败！");
                }

                #endregion 刷新关键字
            }
        }
    }
}