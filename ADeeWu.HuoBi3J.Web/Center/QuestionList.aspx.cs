using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class QuestionList : System.Web.UI.Page
    {
        public int UserID
        {
            get
            {
                UserSession session = UserSession.GetSession();
                if (session == null) return 0;
                return Utility.GetInt(session.UserID, 0);
            }
        }

        public bool? IsDefaultKey { get; set; }

        public static int kid = -1;
        public static int bid =Utility.GetInt(System.Configuration.ConfigurationManager.AppSettings["movebid"],0);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                kid = WebUtility.GetRequestInt("kid", -1);
                if (kid == -1)
                {
                    WebUtility.ShowAndGoBack(this, "参数有误！");
                    return;
                }
                var key = new DAL.Key().GetEntity(kid);
                if (key.BID == bid) IsDefaultKey = true;
                Search();
            }
        }

        private void Search()
        {
            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 10, 5, 40);

            DataBase db = DataBase.Create();

            db.Parameters.Append("kid", kid);
            var keys = db.Select("vw_Keys", "kid=@kid", "");
            rpKey.DataSource = keys;
            rpKey.DataBind();

            db.EnableRecordCount = true;
            var dt = db.Select(pageSize, pageIndex, "vw_Questions", "QID", string.Format("KID like '%{0}%'", kid), "");
            rpQuestions.DataSource = dt;
            rpQuestions.DataBind();

            this.Pager1.AppendUrlParam("kid", kid.ToString());
            this.Pager1.PageSize = (int)pageSize;
            this.Pager1.PageIndex = (int)pageIndex;
            this.Pager1.TotalRecords = (int)db.RecordCount;


            rpInfo.DataSource = new DAL.Center_Info().GetCenterInfo(kid, 2);
            rpInfo.DataBind();
        }

        protected void btnManage_Click(object sender, EventArgs e)
        {
            if (UserSession.GetSession() == null || UserSession.GetSession().UserID <= 0)
            {
                WebUtility.ShowMsg(this, "请登录后再进行操作！", "/login.aspx?url" + Request.RawUrl);
                return;
            }

            if (SaleManSession.IsSaleMan)
            {
                WebUtility.ShowMsg("你是即时业务员，不能管理关键字！");
                return;
            }
            //if (!QualifiedAgentSession.IsQualifiedAgent)
            //{
            //    WebUtility.ShowMsg("你未申请成为网络营销人员，请先申请成为网络营销人员！");
            //    return;
            //}

            DAL.Center_Key_Manage manageDAL = new DAL.Center_Key_Manage();

            if (manageDAL.Exist(new string[] { "kid" }, new object[] { kid }))
            {
                WebUtility.ShowMsg("你来晚了，该关键字已被人申请管理！");
                return;
            }

            var manage = new Model.Center_Key_Manage
            {
                CreatTime = DateTime.Now,
                KID = kid,
                UID = UserID,
                Price = Utility.GetLong(BaseDataHelper.GetAttentionKeyFee, 0),
                IsGoOn = true,
            };
            if (manageDAL.Add(manage) > 0)
            {
                WebUtility.ShowAndTopRedirect(this, "申请成功！", Request.RawUrl);
                return;
            }
            else
            {
                WebUtility.ShowMsg(this, "申请失败，请重试！");
                return;
            }
        }

        public string GetTitle(object title)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(title.ToString());
            return doc.DocumentNode.InnerText;
        }
    }
}