using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.SQL;
using System.Data;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.HireInfos
{
   
    public partial class New : Class.PageBase_MyCorp
    {

        DAL.CA_HireInfos dal = new ADeeWu.HuoBi3J.DAL.CA_HireInfos();

        protected void Page_Load(object sender, EventArgs e)
        {

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

            Model.CA_HireInfos ent = new Model.CA_HireInfos();
            ent.Title = title;
            ent.Content = content;
            ent.CreateTime = DateTime.Now;
            ent.ModifyTime = DateTime.Now;
            ent.CorpID = this.LoginUser.CorpID;
            ent.CheckState = 1;

            if (dal.Add(ent) > 0)
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
