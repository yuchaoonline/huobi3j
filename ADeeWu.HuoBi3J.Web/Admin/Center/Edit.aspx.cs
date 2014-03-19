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

namespace ADeeWu.HuoBi3J.Web.Admin.Center
{
    public partial class Edit : PageBase
    {
        public override string PageID
        {
            get
            {
                return "010002";
            }
        }

        ADeeWu.HuoBi3J.DAL.Users userDAL = new ADeeWu.HuoBi3J.DAL.Users();
        ADeeWu.HuoBi3J.DAL.Key_CircleSaleMan circleSaleManDAL = new ADeeWu.HuoBi3J.DAL.Key_CircleSaleMan();

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
                ADeeWu.HuoBi3J.Model.Key_CircleSaleMan entity = circleSaleManDAL.GetEntity(id);
                if (entity == null)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "没有找到相关记录", "list.aspx");
                    return;
                }

                var user = userDAL.GetEntity(entity.UserID.Value);

                this.liteLoginName.Text = user.LoginName;
                this.litPhone.Text = entity.Phone.ToString();
                this.litMemo.Text = entity.Memo.ToString();
                this.litCrateTime.Text = entity.CreateTime.ToString();
                this.litModifyTime.Text = entity.ModifyTime.ToString();
                this.ddlCheckState.SelectedValue = entity.CheckState.ToString();
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            ADeeWu.HuoBi3J.Model.Key_CircleSaleMan entity = circleSaleManDAL.GetEntity(id);
            if (entity == null) return;
            entity.CheckState = ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.ddlCheckState.SelectedValue, 0);
            entity.ModifyTime = DateTime.Now;

            if (circleSaleManDAL.Update(entity) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "操作成功!", "Edit.aspx?id=" + id);
            }
        }

    }
}
