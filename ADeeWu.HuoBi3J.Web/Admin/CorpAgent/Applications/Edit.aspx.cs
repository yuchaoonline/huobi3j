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

namespace ADeeWu.HuoBi3J.Web.Admin.CorpAgent.Applications
{
    public partial class Edit : PageBase
    {


        public override string PageID
        {
            get
            {
                return "024003";
            }
        }

        DAL.CA_QualifiedAgents dal = new DAL.CA_QualifiedAgents();

        protected long id = 0;
        protected long userID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
            userID = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("userID", 0);

            if (!IsPostBack)
            {

                Model.CA_QualifiedAgents entApplication = null;
                if (id > 0)
                {
                    entApplication = dal.GetEntity(id);
                }
                else if(userID>0)
                {
                    entApplication = dal.GetEntity(new string[] { "UserID" }, userID);
                }

                if (entApplication == null)
                {
                    WebUtility.ShowMsg(this, "没有找到相关记录", "list.aspx");
                    return;
                }

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

                this.liteCreateTime.Text = entApplication.CreateTime.ToString();
                this.liteModifyTime.Text = entApplication.ModifyTime.ToString();

                this.ddlCheckState.SelectedValue = entApplication.CheckState.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Model.CA_QualifiedAgents entApplication = dal.GetEntity(id);
            if (entApplication == null)
            {
                WebUtility.ShowMsg(this, "该记录已不存在！", "List.aspx");
                return;
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


            entApplication.CheckState = Utility.GetInt(this.ddlCheckState.SelectedValue, 0);


            if (dal.Update(entApplication) > 0)
            {
                WebUtility.ShowMsg(this, "操作成功！");
            }
            else
            {
                WebUtility.ShowMsg(this, "操作失败！请与我们联系！");
            }
            
        }

    }
}
