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

namespace ADeeWu.HuoBi3J.Web.Admin.CashTickets
{
    public partial class Edit : PageBase
    {

        public override string PageID
        {
            get
            {
                return "003002";
            }
        }
        
        long id = 0;

        ADeeWu.HuoBi3J.DAL.CT_CashTickets dal = new ADeeWu.HuoBi3J.DAL.CT_CashTickets();

        protected void Page_Load(object sender, EventArgs e)
        {
            id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            if (id < 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("错误参数传递!");
                return;
            }

            if (!IsPostBack)
            {
                
                ADeeWu.HuoBi3J.Model.CT_CashTickets ent = dal.GetEntity(id);
                if (ent != null)
                {
                    this.litSerialNum.Text = ent.SerialNum;
                    this.litValidCode.Text = ent.ValidCode;
                    this.litCreateTime.Text = ent.CreateTime.ToString();
                    this.litModifyTime.Text = ent.ModifyTime.ToString();
                    this.ddlCheckState.SelectedValue = ent.CheckState.ToString();
                    litMoney.Text = ent.Money.ToString();

                    ADeeWu.HuoBi3J.Model.Corporations entCorp = new ADeeWu.HuoBi3J.DAL.Corporations().GetEntity(ent.CorpID);
                    if (entCorp != null)
                    {
                        this.litCorpName.Text = entCorp.CorpName;
                    }
                }
                
            }
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {

            if (dal.Update("CheckState", ADeeWu.HuoBi3J.Libary.Utility.GetInt(this.ddlCheckState.SelectedValue, 0),"ID=" + id) > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowPageSelector(this, "修改成功!选择\"是\"继续操作!", "#", "list.aspx");
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "修改失败!");
            }
            
        }
    }
}
