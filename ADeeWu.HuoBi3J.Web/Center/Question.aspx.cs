using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Web.Class;
using System.Text;
using System.Data;

namespace ADeeWu.HuoBi3J.Web.Center
{
    public partial class Question : System.Web.UI.Page
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

        public static int qid = -1;
        public static int KID = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                qid = WebUtility.GetRequestInt("qid", -1);
                if (qid == -1)
                {
                    WebUtility.ShowAndGoBack(this, "参数有误！");
                    return;
                }
                Search();
            }
        }

        private void Search()
        {
            if (UserSession.GetSession() == null)
            {
                WebUtility.ShowAndTopRedirect(this, "请登录！", "/login.aspx?url=" + Request.RawUrl);
                return;
            }

            var pageIndex = WebUtility.GetRequestLong("page", 1);
            var pageSize = Utility.GetLong(Request["pagesize"], 20, 5, 40);

            DataBase db = DataBase.Create();

            db.Parameters.Append("qid", qid);
            var questions = db.Select("vw_Questions", "qid=@qid", "");
            rpQuestions.DataSource = questions;
            rpQuestions.DataBind();

            if (questions == null || questions.Rows.Count <= 0)
            {
                WebUtility.ShowAndGoBack(this, "提问不存在 ，可能已经删除了！");
                return;
            }

            var question = questions.Rows[0];
            var questionuid = Utility.GetInt(question["uid"], -1);
            KID = Utility.GetInt(question["kid"], -1);

            //是业务员但没有关注，无权查看
            var userkeyDAL = new DAL.Key_User();
            if (SaleManSession.IsSaleMan)
            {
                if (!userkeyDAL.Exist(new string[] { "uid", "kid" }, new object[] { UserSession.GetSession().UserID, KID }))
                {
                    WebUtility.ShowAndGoBack(this, "你还没有关注该提问的关键字，无权查看！");
                    return;
                }
            }
            else
            {
                //不是提问人无权查看
                if (questionuid != UserSession.GetSession().UserID)
                {
                    WebUtility.ShowAndGoBack(this, "你不是提问人，无权查看！");
                    return;
                }
            }

            //更新提问人为已读状态
            if (questionuid == UserID)
            {
                var sql2 = "update attentionquestion set isread = 1,isreply = 1 where uid=@uid and qid=@qid";
                db.Parameters.Append("uid", questionuid);
                db.Parameters.Append("qid", qid);
                db.ExecuteSql(sql2);
            }

            //查看人为业务员时
            if (SaleManSession.IsSaleMan)
            {
                var sql3 = "update attentionquestion set isread = 1 where uid=@uid and qid=@qid";
                db.Parameters.Append("uid", SaleManSession.SaleMan.UserID);
                db.Parameters.Append("qid", qid);
                db.ExecuteSql(sql3);
            }

            db.EnableRecordCount = true;
            db.Parameters.Append("qid", qid);
            var strWhere = "qid=@qid";
            if (SaleManSession.IsSaleMan)
            {
                db.Parameters.Append("uid", UserSession.GetSession().UserID);
                strWhere += " and uid=@uid";
            }

            var answers = db.Select(pageSize, pageIndex, "vw_Answers", "id", strWhere, "createtime desc");

            if (answers != null && answers.Rows.Count >= 0)
            {
                if (answers.Rows.Count >= 1)
                {
                    postdiv.Visible = false;
                }

                rpAnswers.DataSource = answers;
                rpAnswers.DataBind();

                this.Pager1.AppendUrlParam("qid", qid.ToString());
                this.Pager1.PageSize = (int)pageSize;
                this.Pager1.PageIndex = (int)pageIndex;
                this.Pager1.TotalRecords = (int)db.RecordCount;
            }

            var productDataDAL = new DAL.Center_Product_Data();
            var productData = productDataDAL.GetEntity(string.Format("DataID={0} and typeid=1", question["qid"]));
            if (productData != null)
            {
                var product = new DAL.Center_Products().GetEntity(productData.ProductID.Value);
                if (product != null)
                {
                    rpProduct.DataSource = new List<Model.Center_Products> { product };
                    rpProduct.DataBind();
                }
            }
        }

        /// <summary>
        /// 绑定显示的产品分类
        /// </summary>
        public string bindCategory(object _categoryId)
        {
            var ProductCategory = "";
            var categoryId = Utility.GetLong(_categoryId, -1);
            if (categoryId == -1) return ProductCategory;

            DAL.Shop_ProductCategories dalPCategories = new ADeeWu.HuoBi3J.DAL.Shop_ProductCategories();
            Model.Shop_ProductCategories entPCate = dalPCategories.GetEntity(categoryId);

            if (entPCate == null) return ProductCategory;
            if (entPCate.Depth <= 0)
            {
                ProductCategory = entPCate.Name;
                return ProductCategory;
            }

            StringBuilder whereBuilder = new StringBuilder();
            foreach (string s in entPCate.ParentPath.Split(','))
            {
                long parentId = Utility.GetLong(s, 0);
                if (parentId > 0)
                {
                    whereBuilder.Append(" or ID=" + parentId);
                }
            }
            if (whereBuilder.Length > 0)
            {
                DataTable dt = dalPCategories.Select(whereBuilder.ToString().Substring(4), "Depth asc");
                if (dt.Rows.Count == 0)
                {
                    ProductCategory = entPCate.Name;
                }
                else
                {
                    string[] categoryNames = new string[dt.Rows.Count + 1];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        categoryNames[i] = dt.Rows[i]["Name"].ToString();
                    }
                    categoryNames[categoryNames.Length - 1] = entPCate.Name;
                    ProductCategory = string.Join(" &gt; ", categoryNames);
                }
            }

            return ProductCategory;
        }

        public string GetTitle(object title)
        {
            return title.ToString();
        }
    }
}