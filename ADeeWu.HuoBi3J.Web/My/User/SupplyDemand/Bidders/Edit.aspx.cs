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

namespace ADeeWu.HuoBi3J.Web.My.User.SupplyDemand.Bidders
{
    public partial class Edit : PageBase_MyUser
    {
        long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
        ADeeWu.HuoBi3J.DAL.SD_Bidders sdbdal = new ADeeWu.HuoBi3J.DAL.SD_Bidders();
        protected ADeeWu.HuoBi3J.DAL.SD_SupplyDemands dal = new ADeeWu.HuoBi3J.DAL.SD_SupplyDemands();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ADeeWu.HuoBi3J.Model.SD_Bidders sdbentity = sdbdal.GetEntity(id);
               

                if (sdbentity != null)
                {
                    txtBidders.Text = sdbentity.Content;
                    hfsdbid.Value = sdbentity.ID.ToString();
                    ADeeWu.HuoBi3J.Model.SD_SupplyDemands entity = dal.GetEntity(sdbentity.SupplyDemandID);
                    if (entity != null)
                    {
                        litcontent.Text = entity.Content;
                        litendtime.Text = entity.EndTime.ToString("yyyy/MM/dd");
                        littitle.Text = entity.Title;
                        litCreateTime.Text = entity.CreateTime.ToString("yyyy/MM/dd HH:mm");
                        litModifyTime.Text = entity.ModifyTime.ToString("yyyy/MM/dd HH:mm");
                    }
                    else
                    {
                        ADeeWu.HuoBi3J.Libary.WebUtility.ShowAndGoBack(this, "没有找到您要修改的信息！");
                    }
                }
                else
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowAndGoBack(this, "没有找到您要修改的信息！");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            string content = this.txtBidders.Text.Trim();
            if (content == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写投标内容！");
                return;
            }

            ADeeWu.HuoBi3J.Model.SD_Bidders entity = sdbdal.GetEntity(long.Parse(hfsdbid.Value));
            entity.ModifyTime = DateTime.Now;
            entity.Content = content;
            long count = sdbdal.Update(entity);
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
