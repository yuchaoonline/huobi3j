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

namespace ADeeWu.HuoBi3J.Web.Admin.WebIM.UINS
{
    public partial class Edit : PageBase
    {

        public override string PageID
        {
            get
            {
                return "018002";
            }
        }

        long UINID = 0;
        DAL.IM_UINS dal = new ADeeWu.HuoBi3J.DAL.IM_UINS();
        protected void Page_Load(object sender, EventArgs e)
        {
            UINID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (UINID < 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("错误参数传递!");
                return;
            }

            if (!IsPostBack)
            {

                ADeeWu.HuoBi3J.Model.IM_UINS ent = dal.GetEntity(UINID);
                if (ent == null)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("没有找到数据!");
                    return;
                }
                txtSequence.Text = ent.Sequence.ToString();
                txtUIN.Text = ent.UIN;
                lblIsUsed.Text = ent.HasUsed ? "已使用" : "未使用";
                lblCreateTime.Text = ent.CreateTime.ToString();
                cboReCommend.Checked = ent.IsRecommend;

            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            ADeeWu.HuoBi3J.Model.IM_UINS ent = dal.GetEntity(UINID);
            if (ent == null)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("没有找到数据!");
                return;
            }
            int sequence = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.txtSequence.Text, 0);
            ent.Sequence = sequence;
            ent.IsRecommend = cboReCommend.Checked;
            cboReCommend.Checked = ent.IsRecommend;
            int count= dal.Update(ent);
            if (count > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("修改成功!");
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("修改失败!");
            }
        }
    }
}
