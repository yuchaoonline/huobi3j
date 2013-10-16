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
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.Admin.CorpAgent.UserInCorps
{
    public partial class Edit : PageBase
    {


        public override string PageID
        {
            get
            {
                return "025003";
            }
        }

        DataBase db = DataBase.Create();
        DAL.CA_QuaAgentInCorps dal = new DAL.CA_QuaAgentInCorps();

        protected long id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (id <= 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "错误参数传递", "list.aspx");
                return;
            }
            
            if (!IsPostBack)
            {

                DataTable dt = db.Select("select * from vw_Admin_CA_QuaAgentInCorps where id=" + id);

                if (dt.Rows.Count == 0)
                {
                    WebUtility.ShowMsg(this, "没有找到相关记录", "list.aspx");
                    return;
                }

                DataRow dr = dt.Rows[0];
                this.liteCorpAgentName.Text = dr["CorpAgentLoginName"].ToString();
                this.liteCorpAgentUIN.Text = dr["CorpAgentUIN"].ToString();
                this.liteCorpName.Text = dr["CorpName"].ToString();
                this.liteCorpUIN.Text = dr["CorpUIN"].ToString();

                this.liteCreateTime.Text = dr["CreateTime"].ToString();
                this.liteModifyTime.Text = dr["ModifyTime"].ToString();

                this.ddlCheckState.SelectedValue = dr["CheckState"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Model.CA_QuaAgentInCorps ent = dal.GetEntity(id);
            if (ent == null)
            {
                WebUtility.ShowMsg(this, "该记录已不存在！", "List.aspx");
                return;
            }

            ent.CheckState = Utility.GetInt(this.ddlCheckState.SelectedValue, 0);
            ent.ModifyTime = DateTime.Now;


            if (dal.Update(ent) > 0)
            {
                WebUtility.ShowMsg(this, "操作成功！");
            }
            else
            {
                WebUtility.ShowMsg(this, "操作失败！请与我们联系！");
            }
            
        }

    }
}
