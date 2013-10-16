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
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.Model;

namespace ADeeWu.HuoBi3J.Web.My.User.Keyword
{
    public partial class New : Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-Keyword-New";
            }
        }

        DAL.CP_Keyword_Search dal = new ADeeWu.HuoBi3J.DAL.CP_Keyword_Search();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string keyword = this.txtKeyword.Text.Trim();
            if (keyword.Length == 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "请填写关键字!");
                return;
            }
            if (keyword.Length > 10)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "关键字长度超过十位!");
                return;
            }

            #region 限制5个关键字
            DataBase db = DataBase.Create();

            if (Utility.GetInt(db.ExecuteScalar("select count(*) from CP_Keyword_Search where userid=" + LoginUser.UserID), 0) > 5)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "每个用户只能拥有5个关键字！");
                return;
            }
            #endregion

            bool IsOuttime = false;

            #region 关键字是否被申请
            Model.CP_Keyword_Search search = dal.GetEntity(string.Format("keyword = '{0}'", keyword));
            if (search != null)
            {
                DAL.CP_Keyword_Refresh refreshDAL = new DAL.CP_Keyword_Refresh();
                DataTable dtRefresh = refreshDAL.Select(-1, -1, "keywordid=" + search.ID, "lasttime desc");
                if (dtRefresh.Rows.Count > 0)
                {
                    //3天
                    if (Utility.GetDateTime(dtRefresh.Rows[0]["lasttime"], DateTime.MinValue).Value.Day + 3 < DateTime.Now.Day)
                    {
                        IsOuttime = true;
                    }
                    //一个月6次
                    if (dtRefresh.Rows.Count + 6 <= DateTime.Now.Day && search.CreateTime.Value.Year != DateTime.Now.Year && search.CreateTime.Value.Month != DateTime.Now.Month)
                    {
                        IsOuttime = true;
                    }
                }
                else
                {
                    if (DateTime.Now.Day > 3)
                        IsOuttime = true;
                }

                if (!IsOuttime)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "该关键字已被申请，请更换其他关键字！");
                    return;
                }
            }
            #endregion

            if (search != null && IsOuttime)
            {

                #region 过期的关键字过户到新申请的人
                string msg = dal.SaleKeyword(search.ID, LoginUser.LoginName);
                if (msg == "转让成功！")
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "申请成功", "Default.aspx");
                    return;
                }
                else
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作失败!请与我们联系!");
                    return;
                }
                #endregion

            }
            else
            {

                #region 添加关键字
                Model.CP_Keyword_Search mod = new ADeeWu.HuoBi3J.Model.CP_Keyword_Search();
                mod.Keyword = this.txtKeyword.Text.Trim();
                mod.UserID = this.LoginUser.UserID;
                mod.CreateTime = DateTime.Now;
                mod.IsHidden = false;
                if (dal.Add(mod) > 0)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "申请成功", "Default.aspx");
                    return;
                }
                else
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作失败!请与我们联系!");
                    return;
                }
                #endregion

            }
        }


    }
}