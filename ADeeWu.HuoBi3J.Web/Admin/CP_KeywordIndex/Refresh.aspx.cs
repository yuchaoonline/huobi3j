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
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.CP_KeywordIndex
{
    public partial class Refresh : PageBase
    {


        public override string PageID
        {
            get
            {
                return "012011";
            }
        }


        DataBase db = DataBase.Create();
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {

            if (this.chkIsRefreshAll.Checked) //更新所有关键字缓存索引区
            {
                DataTable dt = db.Select(@"select * from CP_Keywords where id in 
( select max(id) from CP_Keywords group by keyword )
");
                foreach (DataRow row in dt.Rows)
                {
                    string keyword = row["Keyword"].ToString();
                    if (keyword.Length == 0) continue;
                    RefreshKeywordIndex(keyword);
                }
            }
            else//单个关键字更新
            {
                string keyword = this.txtKeyword.Text.Trim();
                if (keyword.Length == 0)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "请填写关键字");
                    return;
                }
                RefreshKeywordIndex(keyword);
            }

            ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功！");
        }

        void RefreshKeywordIndex(string keyword)
        {
            db.Parameters.Clear();
            db.Parameters.Append("@Keyword",keyword).Size=10;
            db.RunProc("SP_CP_UpdateKeywordIndex");
        }

    }
}
