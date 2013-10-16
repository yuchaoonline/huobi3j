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

namespace ADeeWu.HuoBi3J.Web.Admin.Marketing
{
    public partial class Edit : PageBase
    {

        public override string PageID
        {
            get
            {
                return "015002";
            }
        }

        ADeeWu.HuoBi3J.DAL.Market_Infos dal = new ADeeWu.HuoBi3J.DAL.Market_Infos();
        ADeeWu.HuoBi3J.Model.Market_Infos entity;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                entity = dal.GetEntity(new string[] { "ID" }, new string[] { id });
                if (entity != null)
                {
                    this.txtContent.Value = entity.Content;
                    txtSummary.Text = entity.Summary;
                    txtTitle.Text = entity.Title;
                    lblVisteCount.Text = entity.VisitCount + "次";
                    cboIsHidden.Checked = entity.IsHidden;
                    cboIsRecommend.Checked = entity.IsRecommend;
                    setCheckState(entity.CheckState);
                    lblUpdateTime.Text = entity.ModifyTime.ToString("yyyy-MM-dd HH:mm:ss");
                    lblCreateTime.Text = entity.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    lblReTime.Text = entity.RefreshTime.ToString("yyyy-MM-dd HH:mm:ss");
                    ddlBusinessType.SelectedValue = entity.BusinessType.ToString();
                }


            }
        }
        int getCheckState()
        {
            if (cbochecktrue.Checked)
            {
                return 1;
            }
            else if (cbocheckfalse.Checked)
            {
                return 2;
            }
            else if (cboStateEnd.Checked)
            {
                return 3;
            }
            else
            {
                return -1;
            }
        }
        void setCheckState(int state)
        {
            if (state == 1)
            {
                cbochecktrue.Checked = true;
            }
            else if (state == 2)
            {
                cbocheckfalse.Checked = true;
            }
            else if (state == 3)
            {
                cboStateEnd.Checked = true;
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string summary = this.txtSummary.Text.Trim();
            string content = this.txtContent.Value.Trim();
            if (title == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写标题！");
                return;
            }
            if (summary == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写简述！");
                return;
            }
            if (content == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写详细内容！");
                return;
            }

            long count = 0;
            entity = dal.GetEntity(new string[] { "ID" }, new string[] {Request.QueryString["id"]});
             
            entity.Content = content;
             
            entity.ModifyTime = DateTime.Now;
            entity.RefreshTime = DateTime.Now;
            entity.Summary = summary;
            entity.Title = title;
            int state = getCheckState();
            entity.CheckState = state != -1 ? state : entity.CheckState;
            entity.IsRecommend = cboIsRecommend.Checked;
            entity.IsHidden = cboIsHidden.Checked;
            entity.ModifyTime = DateTime.Now;
            entity.RefreshTime = DateTime.Now;
            entity.BusinessType = Convert.ToInt32(ddlBusinessType.SelectedValue);
            count = dal.Update(entity);
           
            
            if (count > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "修改成功!继续修改请选择\"是\"", "#", "List.aspx");
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("保存失败！");

            }
        }
    }
}
