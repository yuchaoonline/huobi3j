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
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.Web.Class;

namespace ADeeWu.HuoBi3J.Web.Admin.Center
{
    public partial class QuestionIndexList : PageBase
    {

        public override string PageID
        {
            get
            {
                return "009011";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var qid = WebUtility.GetRequestInt("qid", -1);
                var method = WebUtility.GetRequestStr("method", null);
                if (!string.IsNullOrWhiteSpace(method))
                {
                    RemoveRecord(qid);
                }
                else
                {
                    if (qid == -1)
                        BandData();
                    else
                        AddRecord(qid);
                }
            }
        }


        public void BandData()
        {
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            var indexs = new DAL.Center_QuestionIndex().GetEntityList("", new string[] { }, new object[] { });
            var indexIDs = new List<long>();
            foreach (var item in indexs)
            {
                indexIDs.Add(item.QID.Value);
            }
            if (indexIDs.Count == 0) return;

            var db = DataBase.Create();
            db.EnableRecordCount = true;
            this.rpResultList.DataSource = db.Select(pageSize, pageIndex, "vw_Questions", "qid", string.Format("qid in ({0})", string.Join(",", indexIDs)), "createtime desc");
            this.rpResultList.DataBind();

            this.Pager1.PageSize = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageSize, 0);
            this.Pager1.PageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageIndex, 0);
            this.Pager1.TotalRecords = ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RecordCount, 0);
        }

        public void AddRecord(int qid)
        {
            var db = new DAL.Center_QuestionIndex();
            var id = db.Add(new Model.Center_QuestionIndex
            {
                QID= qid,
                CreateTime = DateTime.Now,
            });
            if (id > 0)
            {
                WebUtility.ShowAndGoBack(this, "设置成功！");
                return;
            }
            else
            {
                WebUtility.ShowAndGoBack(this, "设置失败！");
                return;
            }
        }

        public void RemoveRecord(int qid)
        {
            var db = new DAL.Center_QuestionIndex();
            var index = db.GetEntity("qid=" + qid);
            if (index == null)
            {
                WebUtility.ShowAndGoBack(this, "移除失败！");
                return;
            }
            var id = db.Delete(index.ID);
            if (id > 0)
            {
                WebUtility.ShowMsg(this, "移除成功！", "QuestionIndexList.aspx");
                return;
            }
            else
            {
                WebUtility.ShowAndGoBack(this, "移除失败！");
                return;
            }
        }
    }
}
