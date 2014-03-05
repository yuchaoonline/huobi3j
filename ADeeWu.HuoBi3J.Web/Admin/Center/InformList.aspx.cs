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
    public partial class InformList : PageBase
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
            long pageSize = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("pagesize", PageBase.DataList_PageSize);
            long pageIndex = ADeeWu.HuoBi3J.Libary.WebUtility.GetUrlLong("page", 1);

            if (!IsPostBack)
            {
                var db = new DAL.Center_Inform();
                db.EnableRecordCount = true;
                this.rpResultList.DataSource = db.Select(pageSize, pageIndex, "createtime desc");
                this.rpResultList.DataBind();

                this.Pager1.PageSize = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageSize, 0);
                this.Pager1.PageIndex = ADeeWu.HuoBi3J.Libary.Utility.GetInt(pageIndex, 0);
                this.Pager1.TotalRecords = ADeeWu.HuoBi3J.Libary.Utility.GetInt(db.RecordCount, 0);
            }
        }

        public string GetContent(object _contentid,object _informtype)
        {
            var contentid = Utility.GetInt(_contentid, -1);
            var informtype = Utility.GetInt(_informtype, -1);

            if (contentid == -1 || informtype == -1) return "";

            switch (informtype)
            {
                case 0:
                    {
                        var business = new DAL.Key_BusinessCircle().GetEntity(contentid);
                        if (business == null) return "";

                        //return Helper.GetBusinessCircle(business.BID, business.BName);
                        return business.BName;
                    }
                case 1:
                    {
                        var key = new DAL.Key().GetEntity(contentid);
                        if (key == null) return "";
                        //return Helper.GetKey(key.KID, key.Name);
                        return key.Name;
                    } 
                case 2:
                    {
                        var question = new DAL.Question().GetEntity(contentid);
                        if (question == null) return "";
                        //return Helper.GetQuestion(question.QID, question.Title);
                        return question.Title;
                    } 
                case 3:
                    {
                        var answer = new DAL.Answer().GetEntity(contentid);
                        if (answer == null) return "";
                        //return Helper.GetQuestion(answer.QID, answer.Content);
                        return answer.Content;
                    } 
            }
            return "";
        }

    }
}
