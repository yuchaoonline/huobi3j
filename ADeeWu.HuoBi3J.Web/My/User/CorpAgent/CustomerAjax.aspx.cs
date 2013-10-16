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
    public partial class CustomerAjax : Class.PageBase_MyUser
    {

        DataBase db = DataBase.Create();
        protected bool getLv5Lv6 = false;

        public override void RenderControl(HtmlTextWriter writer)
        {
            Response.ClearContent();
            long agentUserId = Utility.GetLong(Request["AgentUserId"], 0);
            DAL.Users dalUser = new ADeeWu.HuoBi3J.DAL.Users();
            Model.Users entUser = dalUser.GetEntity(agentUserId);
            this.liteAgentName.Text = entUser.LoginName;


           
            this.rpData.DataSource = db.Select("vw_CA_QualifiedAgentBusiness", "AgentUserID=" + agentUserId, "");
            this.rpData.DataBind();

            this.phResponse.RenderControl(writer);

        }

        protected void rpData_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rp = e.Item.FindControl("rpSub") as Repeater;
            Literal liteCustomerUserId = e.Item.FindControl("liteCustomerUserID") as Literal;

            long agentUserId = Utility.GetLong(liteCustomerUserId.Text, 0);
            DataTable src = db.Select("vw_CA_QualifiedAgentBusiness", "AgentUserID=" + agentUserId, "");

            rp.DataSource = src;
            rp.DataBind();
          
            

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.getLv5Lv6 = Utility.GetBool(Request["getlv5lv6"], false);
        }

        protected string getClickFn(long agentUserId)
        {
            return getLv5Lv6 ? "" : string.Format("onclick='ShowLv5_Lv6({0});'", agentUserId);
        }

    }
}
