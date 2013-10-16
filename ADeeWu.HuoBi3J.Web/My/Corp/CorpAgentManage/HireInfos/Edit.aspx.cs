using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.HireInfos
{

    public partial class Edit : Class.PageBase_MyCorp
    {

        DAL.CA_HireInfos dal = new ADeeWu.HuoBi3J.DAL.CA_HireInfos();
        long id = WebUtility.GetRequestLong("id", 0);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.CA_HireInfos ent = dal.GetEntity(new string[] { "ID", "CorpID" }, id, this.LoginUser.CorpID);
                if (ent == null)
                {
                    WebUtility.ShowMsg(this, "该记录已不存在！");
                    return;
                }

                this.txtTitle.Text = ent.Title;
                this.txtContent.Text = WebUtility.ToTextAreaContent(ent.Content);
                this.liteCreateTime.Text = ent.CreateTime.ToString();
                this.liteModifyTime.Text = ent.ModifyTime.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string title = this.txtTitle.Text.Trim();
            string content = WebUtility.GetTextAreaContent(this.txtContent.Text);

            if (title.Length == 0)
            {
                WebUtility.ShowMsg(this, "请输入标题！");
                return;
            }

            if (content.Length == 0)
            {
                WebUtility.ShowMsg(this, "请输入内容！");
                return;
            }

            Model.CA_HireInfos ent = dal.GetEntity(new string[] { "ID", "CorpID" }, id, this.LoginUser.CorpID);
            ent.Title = title;
            ent.Content = content;
            ent.ModifyTime = DateTime.Now;
            ent.CorpID = this.LoginUser.CorpID;
            //ent.CheckState = 1;

            if (dal.Update(ent) > 0)
            {
                WebUtility.ShowMsg(this, "操作成功！");
                return;
            }
            else
            {
                WebUtility.ShowMsg(this, "操作失败！请与我们联系！");
                return;
            }
        }
    }

}