using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.Keyword
{
    public partial class Refresh : Class.PageBase_MyUser
    {
        private static decimal brokerage = 1;
        public override string FunctionCode
        {
            get
            {
                return "My-User-Keyword-Refresh";
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
                DAL.CP_Keyword_Search searchDAL = new DAL.CP_Keyword_Search();
                Model.CP_Keyword_Search keyword = searchDAL.GetEntity(id);
                if (keyword == null || keyword.ID == 0)
                {
                    WebUtility.ShowAndGoBack(this, "无此关键字！");
                    return;
                }
                #endregion

                #region 是否已刷新关键字
                DAL.CP_Keyword_Refresh refreshDAL = new DAL.CP_Keyword_Refresh();
                if (refreshDAL.Exist(string.Format("datediff(dy,lasttime,'{0}') = 0 and keywordid = {1}", DateTime.Now, keyword.ID)))
                {
                    WebUtility.ShowAndGoBack(this,"勤劳的人，你今天已刷新过了！");
                    return;
                }
                #endregion

                #region 扣掉虚拟币
                DAL.Users userDAL = new DAL.Users();
                Model.Users user = userDAL.GetEntity(LoginUser.UserID);
                if (user.Coins < brokerage)
                {
                    WebUtility.ShowAndGoBack(this, "虚拟币不足" + brokerage + "，刷新失败！");
                    return;
                }
                user.Coins -= brokerage;
                if (userDAL.Update(user) <= 0)
                {
                    WebUtility.ShowAndGoBack(this, "扣除虚拟币失败，请重试！");
                    return;
                }
                #endregion

                #region 添加虚拟币记录
                Model.User_CoinUseHistories history = new Model.User_CoinUseHistories
                {
                    CreateTime = DateTime.Now,
                    InCoin = 0,
                    OutCoin = brokerage,
                    Notes = string.Format("刷新关键字：{0}，扣除虚拟币：{1}！", keyword.Keyword, brokerage),
                    Remain = user.Coins,
                    UserID = user.ID
                };
                if (new DAL.User_CoinUseHistories().Add(history) <= 0)
                {
                    WebUtility.ShowAndGoBack(this, "添加虚拟币消费记录失败！");
                }
                #endregion

                #region 刷新关键字
                Model.CP_Keyword_Refresh refresh = new Model.CP_Keyword_Refresh
                        {
                            KeywordID = keyword.ID,
                            LastTime = DateTime.Now,
                        };
                if (refreshDAL.Add(refresh) > 0)
                {
                    keyword.IsHidden = false;
                    searchDAL.Update(keyword);
                    WebUtility.ShowAndGoBack(this, "刷新成功！");
                    return;
                }
                else
                {
                    WebUtility.ShowAndGoBack(this, "刷新失败！");
                }
                #endregion
            }
        }
    }
}