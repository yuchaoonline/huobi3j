using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;
using System.Data;

namespace ADeeWu.HuoBi3J.Web.My.User.CorpAgent
{

    public partial class ViewHireInfo : Class.PageBase_MyUser
    {
        DataBase db = DataBase.Create();
        
        protected long id = WebUtility.GetRequestLong("id", 0);
        protected DataRow drData = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                DataTable dt = db.Select("select * from vw_CA_HireInfos where CheckState=1 and ID=" + id);

                if (dt.Rows.Count == 0)
                {
                    WebUtility.ShowMsg(this, "该记录已不存在！","SearchHireInfo.aspx");
                    return;
                }

                this.drData = dt.Rows[0];

                //更新点击次数
                db.ExecuteSql("update CA_HireInfos set VisitCount=VisitCount+1 where ID=" + id);
            }
        }

     
    }
}
