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
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;

namespace ADeeWu.HuoBi3J.Web.My.User.CorpAgent
{
    public partial class Default : ADeeWu.HuoBi3J.Web.Class.PageBase_MyUser
    {

        public override string FunctionCode
        {
            get
            {
                return "My-User-CorpAgent-Default";
            }
        }





        DAL.CA_QualifiedAgents dalApplication = new ADeeWu.HuoBi3J.DAL.CA_QualifiedAgents();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Model.CA_QualifiedAgents entApplication = dalApplication.GetEntity(new string[] { "UserID" }, this.LoginUser.UserID);
                if (entApplication != null)
                {
                    this.txtAddress.Text = entApplication.Address;
                    this.txtBirthday.Text = entApplication.Birthday.ToString("yyyy-MM-dd");
                    this.txtNote.Text = WebUtility.ToTextAreaContent(entApplication.Note);
                    this.txtRealName.Text = entApplication.RealName;
                    this.txtSchool.Text = entApplication.School;
                    this.txtSkill.Text = entApplication.Skill;
                    this.txtSpeciality.Text = WebUtility.ToTextAreaContent(entApplication.Speciality);
                    this.txtZipCode.Text = entApplication.ZipCode;
                    this.syncSelectorEducation.SelectedValue = entApplication.Education.ToString();
                    this.syncSelectorLocation.Values = new string[]{
                        entApplication.ProvinceID.ToString(),
                        entApplication.CityID.ToString(),
                        entApplication.AreaID.ToString()
                    };
                    this.ddlSex.SelectedValue = entApplication.Sex;
                    this.syncSelectorWorkExp.SelectedValue = entApplication.WorkExp.ToString();
                    this.labTips.Text = "提交申请需要重新审核！";
                    this.btnSubmit.OnClientClick = "return cofirm('确认要重新提交吗？修改信息后需要重新通过审核！')";

                    if (entApplication.CheckState == 1)//通过审核
                    {
                        this.phIsHidden.Visible = true;
                        this.txtPromotionLink.Text = "http://" + Request.Url.Host + "/Register.aspx?agent=" + Server.UrlEncode(this.LoginUser.UIN);
                    }

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
                    string s = "您还没有提交过营销专员的申请!通过简单的表格填写就可以申请成为营销专员！";
                    this.labTips.Text = s;
                    this.phIsHidden.Visible = false;
                    this.phCheckState.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool isAdd = false;
            Model.CA_QualifiedAgents entApplication = dalApplication.GetEntity(new string[] { "UserID" }, this.LoginUser.UserID);
            if (entApplication == null)
            {
                entApplication = new ADeeWu.HuoBi3J.Model.CA_QualifiedAgents();
                entApplication.CreateTime = DateTime.Now;
                isAdd = true;
            }
            else
            {
                isAdd = false;
            }


            string realName = this.txtRealName.Text.Trim();
            string sex = this.ddlSex.SelectedValue;
            DateTime? birthday = Utility.GetDateTime(this.txtBirthday.Text, null);

            string[] location = this.syncSelectorLocation.Values;
            long provinceID = Utility.GetLong(location[0], 0);
            long cityID = Utility.GetLong(location[1], 0);
            long areaID = Utility.GetLong(location[2], 0);
            string address = this.txtAddress.Text.Trim();
            string zipCode = this.txtZipCode.Text.Trim();

            int education = Utility.GetInt(this.syncSelectorEducation.SelectedValue, 0);
            int workExp = Utility.GetInt(this.syncSelectorEducation.SelectedValue, 0);
            string school = this.txtSchool.Text.Trim();
            string speciality = this.txtSpeciality.Text.Trim();
            string skill = WebUtility.GetTextAreaContent(this.txtSkill.Text);
            string note = WebUtility.GetTextAreaContent(this.txtNote.Text);

            if (realName.Length == 0)
            {
                WebUtility.ShowMsg(this, "请填写您的真实姓名！");
                return;
            }

            if (!birthday.HasValue)
            {
                WebUtility.ShowMsg(this, "请填写出生日期！");
                return;
            }

            if (provinceID == 0 && cityID == 0 && areaID == 0)
            {
                WebUtility.ShowMsg(this, "请选择您所在的地区！");
                return;
            }

            if (address.Length == 0)
            {
                WebUtility.ShowMsg(this, "请填写您所在地的地址！");
                return;
            }

            if (education == 0)
            {
                WebUtility.ShowMsg(this, "请填写您的学历！");
                return;
            }

            if (workExp == 0)
            {
                WebUtility.ShowMsg(this, "请填写您的工作经验！");
                return;
            }

            entApplication.RealName = realName;
            entApplication.Sex = sex;
            entApplication.ProvinceID = provinceID;
            entApplication.CityID = cityID;
            entApplication.AreaID = areaID;
            entApplication.Address = address;
            entApplication.ZipCode = zipCode;
            entApplication.Birthday = birthday.Value;

            entApplication.School = school;
            entApplication.Education = education;
            entApplication.Skill = skill;
            entApplication.Speciality = speciality;
            entApplication.WorkExp = workExp;
            entApplication.Note = note;
            entApplication.UserID = this.GetRealBusinessUserID();


            entApplication.CheckState = 0;//修改后需要重新审核
            entApplication.ModifyTime = DateTime.Now;
            

            if (isAdd)
            {
                if (dalApplication.Add(entApplication) > 0)
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
                if (dalApplication.Update(entApplication) > 0)
                {
                    WebUtility.ShowMsg(this, "提交申请成功！我们将尽快为您处理！");
                }
                else
                {
                    WebUtility.ShowMsg(this, "操作失败！请与我们联系！");
                }
            }
        }

        protected void chkSetHidden_CheckedChanged(object sender, EventArgs e)
        {
            dalApplication.Update("IsHidden", this.chkSetHidden.Checked, "UserID=" + this.LoginUser.UserID);
        }

      

    }
}
