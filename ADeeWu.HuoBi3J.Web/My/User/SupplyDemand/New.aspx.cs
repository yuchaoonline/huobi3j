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
    public partial class New : PageBase_MyUser
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
     
      

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string summary = this.txtSummary.Text.Trim();
            string content = this.txtContent.Value.Trim();
            DateTime endTime=DateTime.Now;
            
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
            if(!DateTime.TryParse(txtEndTime.Text,out endTime))
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
          
            ADeeWu.HuoBi3J.Model.SD_SupplyDemands entity = new ADeeWu.HuoBi3J.Model.SD_SupplyDemands();
            entity.Title = title;
            entity.Summary = summary;
            entity.CheckState = 0;
            entity.Content = content;
            entity.CreateTime = DateTime.Now;
            entity.EndTime =endTime;
            entity.IsHidden =false;
            entity.IsRecommend =false;
            entity.ModifyTime = DateTime.Now;
            entity.RefreshTime = DateTime.Now;
            entity.Status = 0;
            entity.UserID = this.LoginUser.UserID;
            entity.VisitCount = 0;
            
            ADeeWu.HuoBi3J.DAL.SD_SupplyDemands dal = new ADeeWu.HuoBi3J.DAL.SD_SupplyDemands();
            long id= dal.Add(entity);
            if (id > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "发布成功！", "Default.aspx");
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "发布失败！", "Default.aspx");
                return;
            }


        }
    }
}
