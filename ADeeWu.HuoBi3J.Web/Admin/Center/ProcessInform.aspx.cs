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
    public partial class ProcessInform : PageBase
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
                var id = WebUtility.GetRequestInt("id", -1);
                if (id == -1)
                {
                    WebUtility.ShowAndGoBack(this, "参数错误！");
                    return;
                }

                var informDAL = new DAL.Center_Inform();
                var inform = informDAL.GetEntity(id);
                if (inform == null)
                {
                    WebUtility.ShowAndGoBack(this, "举报不存在！");
                    return;
                }

                var isDelete = false;
                switch (inform.InformType)
                {
                    case 0:
                        {
                            var dal = new DAL.Key_BusinessCircle();
                            var business = dal.GetEntity(inform.ContentID.Value);
                            if (business == null) return;

                            business.BName = BaseDataHelper.GetInformContent;

                            dal.Update(business);
                            isDelete = true;
                        }break;
                    case 1:
                        {
                            var dal = new DAL.Key();
                            var key = dal.GetEntity(inform.ContentID.Value);
                            if (key == null) return;

                            key.Name = BaseDataHelper.GetInformContent;

                            dal.Update(key);
                            isDelete = true;
                        }break;
                    case 2:
                        {
                            var dal = new DAL.Question();
                            var question = dal.GetEntity(inform.ContentID.Value);
                            if (question == null) return;

                            question.Title = BaseDataHelper.GetInformContent;

                            dal.Update(question);
                            isDelete = true;
                        }break;
                    case 3:
                        {
                            var dal = new DAL.Answer();
                            var answer = dal.GetEntity(inform.ContentID.Value);
                            if (answer == null) return;

                            answer.Content = BaseDataHelper.GetInformContent;

                            dal.Update(answer);
                            isDelete = true;
                        }break;
                }

                if (isDelete)
                {
                    informDAL.Delete(inform.ID);
                    WebUtility.ShowMsg(this, "处理成功！","InformList.aspx");
                    return;
                }
                else
                {
                    WebUtility.ShowAndGoBack(this, "处理过程发生错误，请重试！");
                    return;
                }
            }
        }
    }
}
