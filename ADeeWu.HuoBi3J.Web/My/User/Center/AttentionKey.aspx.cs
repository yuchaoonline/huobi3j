using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;
using ADeeWu.HuoBi3J.Web.Class;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class AttentionKey : Class.PageBase_CircleSaleMan
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!SaleManSession.IsSaleMan)
                {
                    WebUtility.ShowAndGoBack(this, "你未通过即时业务员审核或者你不是即时业务员！");
                    return;
                }

                var kid = WebUtility.GetRequestInt("kid", -1);
                if (kid == -1)
                {
                    WebUtility.ShowAndGoBack(this, "参数错误！");
                    return;
                }

                BandData();
            }
        }

        public void BandData()
        {
            var kid = WebUtility.GetRequestInt("kid", -1);

            var userkey = new DAL.Key_User().GetEntity(new string[] { "uid", "kid" }, new object[] { LoginUser.UserID, kid });
            
            if (userkey != null)
            {
                if (!userkey.IsGoOn)
                {
                    WebUtility.ShowAndGoBack(this, string.Format("你已取消关注该关键字，但服务期未到期，请于{0}后再关注！", userkey.CreateTime.Value.AddMonths(1)));
                    return;
                }

                WebUtility.ShowAndGoBack(this, "你已关注该关键字，无需重复关注！");
                return;
            }

            var db = DataBase.Create();
            db.Parameters.Append("kid", kid);
            var keys = db.Select("vw_Keys", "kid=@kid", "");
            if (keys == null) return;

            var key = keys.Rows[0];
            litPrice.Text = BaseDataHelper.GetAttentionKeyFee.ToString("F2");
            
            rpKey.DataSource = keys;
            rpKey.DataBind();


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var keyDAL = new DAL.Key();
            var userDAL = new DAL.Users();
            var dealHistoryDAL = new DAL.User_DealHistories();

            var kid = WebUtility.GetRequestInt("kid", -1);

            var user = userDAL.GetEntity(SaleManSession.SaleMan.UserID.Value);
            if (user.Money < BaseDataHelper.GetAttentionKeyFee)
            {
                WebUtility.ShowMsg("余额不足！");
                return;
            }

            Model.Key_User userKey = new Model.Key_User
            {
                CreateTime = DateTime.Now,
                KID = kid,
                UID = user.ID,
                IsGoOn = true,
            };

            var userKeyDAL = new DAL.Key_User();
            if (userKeyDAL.Add(userKey) > 0)
            {                
                user.Money -= BaseDataHelper.GetAttentionKeyFee;
                userDAL.Update(user);

                var key = keyDAL.GetEntity(userKey.KID.Value);
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

                WebUtility.ShowAndTopRedirect(this, "关注成功！", "MyAttentionList.aspx");
                return;
            }
            else
            {
                WebUtility.ShowAndGoBack(this, "关注失败，请重试！");
                return;
            }
        }
    }
}