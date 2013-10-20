using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.User.Center
{
    public partial class RegSaleMan : PageBase_MyUser
    {
        DAL.CA_CircleSaleMan circleSaleMan = new ADeeWu.HuoBi3J.DAL.CA_CircleSaleMan();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.CA_CircleSaleMan entApplication = circleSaleMan.GetEntity(new string[] { "UserID" }, this.LoginUser.UserID);
                if (entApplication != null)
                {
                    txtPhone.Text = entApplication.Phone;
                    txtQQ.Text = entApplication.QQ;
                    txtCompanyAddress.Text = entApplication.CompanyAddress;
                    txtCompanyName.Text = entApplication.CompanyName;
                    txtName.Text = entApplication.Name;
                    txtJob.Text = entApplication.Job;
                    litMemo.Text = entApplication.Memo;
                    hfPosition.Value = entApplication.PositionX + "|" + entApplication.PositionY;

                    this.labTips.Text = "提交申请需要重新审核！";
                    this.btnSubmit.OnClientClick = "return cofirm('确认要重新提交吗？修改信息后需要重新通过审核！')";
                    
                    this.phCheckState.Visible = true;
                    this.liteCheckState.Text = ADeeWu.HuoBi3J.Libary.WebUtility.Switch(
                        entApplication.CheckState.ToString(),
                        new string[][]{
                            new string[]{"0","待审核"},
                            new string[]{"1","已审核"},
                            new string[]{"2","无效"},
                            new string[]{"3","过期"}
                        }
                        );
                }
                else
                {
                    string s = "您还没有提交过开通报价比价服务的申请！";
                    this.labTips.Text = s;
                    this.phCheckState.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isAdd = false;
            Model.CA_CircleSaleMan entApplication = circleSaleMan.GetEntity(new string[] { "UserID" }, this.LoginUser.UserID);
            if (entApplication == null)
            {
                entApplication = new ADeeWu.HuoBi3J.Model.CA_CircleSaleMan();
                entApplication.CreateTime = DateTime.Now;
                entApplication.ModifyTime = DateTime.Now;
                isAdd = true;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                WebUtility.ShowMsg("联系人不能为空！");
                return;
            }

            if (string.IsNullOrWhiteSpace(hfPosition.Value))
            {
                WebUtility.ShowMsg("请在地图中选择准确位置！");
                return;
            }

            entApplication.CheckState = (int)UserSessionCheckState.NotAudit;
            entApplication.ModifyTime = DateTime.Now;
            entApplication.Phone = txtPhone.Text;
            entApplication.UserID = this.LoginUser.UserID;
            entApplication.Memo = txtMemo.Value;
            entApplication.QQ = txtQQ.Text;
            entApplication.CompanyAddress = txtCompanyAddress.Text;
            entApplication.CompanyName = txtCompanyName.Text;
            entApplication.Job = txtJob.Text;
            entApplication.Name = txtName.Text;
            var position = hfPosition.Value.Split(new char[] { '|' });
            entApplication.PositionX = position[0];
            entApplication.PositionY = position[1];

            if (isAdd)
            {
                var user = new DAL.Users().GetEntity(LoginUser.UserID);
                if (user.Money <= 50)
                {
                    WebUtility.ShowMsg(string.Format("你的余额为：{0}，申请即时报价业务员余额大于50元！", user.Money));
                    return;
                }

                if (circleSaleMan.Add(entApplication) > 0)
                {
                    WebUtility.ShowMsg(this, "提交申请成功！我们将尽快为您处理！");
                }
                else
                {
                    WebUtility.ShowMsg(this, "操作失败！请与我们联系！");
                }
            }
            else
            {
                if (circleSaleMan.Update(entApplication) > 0)
                {
                    WebUtility.ShowMsg(this, "提交申请成功！我们将尽快为您处理！");
                }
                else
                {
                    WebUtility.ShowMsg(this, "操作失败！请与我们联系！");
                }
            }
        }
    }
}