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
using ADeeWu.HuoBi3J.Web.Class;

namespace ADeeWu.HuoBi3J.Web.My.User.SupplyDemand
{
    public partial class Edit : PageBase_MyUser
    {
        long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
        protected ADeeWu.HuoBi3J.DAL.SD_SupplyDemands dal = new ADeeWu.HuoBi3J.DAL.SD_SupplyDemands();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ADeeWu.HuoBi3J.Model.SD_SupplyDemands entity= dal.GetEntity(id);
                if (entity != null)
                {
                    txtContent.Value = entity.Content;
                    txtEndTime.Text = entity.EndTime.ToString("yyyy/MM/dd");
                    txtTitle.Text = entity.Title;
                    txtSummary.Text = entity.Summary;
                    litCreateTime.Text = entity.CreateTime.ToString("yyyy/MM/dd HH:mm");
                    litRefreshTime.Text = entity.RefreshTime.ToString("yyyy/MM/dd HH:mm");
                    litModifyTime.Text = entity.ModifyTime.ToString("yyyy/MM/dd HH:mm");
                    litVisitCount.Text = entity.VisitCount + "次";

                }
                else
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowAndGoBack(this, "没有找到您要修改的信息！");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string summary = this.txtSummary.Text.Trim();
            string content = this.txtContent.Value.Trim();
            DateTime endTime = DateTime.Now;

            if (title == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写标题！");
                return;
            }
            else if (title.Length > 15)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("标题不能多于15个字！");
                return;
            }
            if (!DateTime.TryParse(txtEndTime.Text, out endTime))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择信息过期时间！");
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

            ADeeWu.HuoBi3J.Model.SD_SupplyDemands entity = dal.GetEntity(id);
            entity.Title = title;
            entity.Summary = summary;
            entity.Content = content;
            entity.EndTime = endTime;
            //entity.IsHidden = false;
            //entity.IsRecommend = false;
            entity.ModifyTime = DateTime.Now;
            entity.RefreshTime = DateTime.Now;
            entity.Status = 0;

 
            long count = dal.Update(entity);
            if (count > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "修改成功！", "Default.aspx");
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "修改失败！", "Default.aspx");
                return;
            }
        }
    }
}
