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
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp.Jobs
{
    public partial class Edit :ADeeWu.HuoBi3J.Web.Class.PageBase_MyCorp
    {

        public override string FunctionCode
        {
            get
            {
                return "Corp-Jobs-Edit";
            }
        }

        long id = 0;
        ADeeWu.HuoBi3J.DAL.Jobs dal = new ADeeWu.HuoBi3J.DAL.Jobs();
        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {

            id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);

            if (!IsPostBack)
            {


                ADeeWu.HuoBi3J.Model.Jobs entity = dal.GetEntity(new string[] { "ID", "CorpID" }, id, this.LoginUser.CorpID);
                if (entity == null)
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowAndGoBack(this, "对不起，找不到您要编辑的职位信息！");
                }
                else
                {
                    this.jobName.Value = entity.Title;
                    //this.jobAddress.Value = entity.Address;
                    this.jobSex.Value = entity.Sex.ToString();
                    this.ddlEducation.SelectedValue = entity.Education.ToString();
                    this.ddlExp.SelectedValue = entity.Exp.ToString();
                    //this.jobSumny.Value = entity.Summary;
                    this.jobDesc.Value = WebUtility.ToTextAreaContent(entity.Content);
                    this.DateTimeSelector1.Text = entity.EndTime.ToString("yyyy/MM/dd");
                    this.syncSelectorLocation.Values = new string[] { entity.ProvinceID.ToString(), entity.CityID.ToString(), entity.AreaID.ToString() };
                    this.syncSelectorJobCategory.SelectedValue = entity.CategoryID.ToString();
                    this.syncSelectorCalling.SelectedValue = entity.CallingID.ToString();
                    this.workType.Value = entity.WorkType.ToString();
                    this.JobCount.Value = entity.JobCount.ToString();
                    this.LinkEmail.Value = entity.LinkEmail;
                    this.LinkName.Value = entity.LinkName;
                    this.LinkPhone.Value = entity.LinkPhone;
                    this.MonthlyPay.Value = entity.MonthlyPay.ToString("0.00");
                    this.txtAgeArea.Value = entity.AgeArea;

                }
            }
              
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string jobName = this.jobName.Value.Trim();
            //string jobAddress = this.jobAddress.Value.Trim();
            int sex = int.Parse(this.jobSex.Value.Trim());
            int Education = Utility.GetInt(this.ddlEducation.SelectedValue, 0);
            int jobExp = Utility.GetInt(this.ddlExp.SelectedValue, 0);
            //string sumny = this.jobSumny.Value.Trim();
            string desc = WebUtility.GetTextAreaContent(this.jobDesc.Value);
            DateTime? endtime = Utility.GetDateTime(this.DateTimeSelector1.Text, null);
            string jobCount = this.JobCount.Value.Trim();
            string jobMonney = this.MonthlyPay.Value.Trim();
            ADeeWu.HuoBi3J.DAL.Jobs biz = new ADeeWu.HuoBi3J.DAL.Jobs();
            if (jobName == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写职位名称!");
                return;
            }
            //else if (biz.Exist(new string[] { "Title", "CorpID" }, new string[] { jobName, this.LoginUser.CorpID.ToString() }))
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("您输入的职位名称已经存在!");
            //    return;
            //}
            long categoryID = Utility.GetLong( this.syncSelectorJobCategory.SelectedValue,0);
            long callingID = Utility.GetLong(this.syncSelectorCalling.SelectedValue, 0);



            string[] locationValues = this.syncSelectorLocation.Values;

            long provinceID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(locationValues[0], -1);
            long cityID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(locationValues[1], -1);
            long areaID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(locationValues[2], -1);

            if (categoryID == -1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择职位分类!");
                return;
            }

            if (callingID == -1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择行业分类!");
                return;
            }

            if (provinceID == -1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择行业!");
                return;
            }
          
            if (cityID == -1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择城市!");
                return;
            }

            if (areaID == -1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择地区!");
                return;
            }

            //if (jobAddress == "")
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写工作地址!");
            //    return;
            //}

           
            //if (sumny == "")
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写职位简述!");
            //    return;
            //}
            if (desc == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写职位详细说明!");
                return;
            }
            if (!endtime.HasValue)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写招聘职位过期时间!");
                return;
            }
            if (jobCount == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写招聘人数!");
                return;
            }
            ADeeWu.HuoBi3J.Model.Jobs job = dal.GetEntity(new string[] { "ID", "CorpID" }, id, this.LoginUser.CorpID);
            //job.Address = jobAddress;
            job.Content = desc;
            job.Education = Education;
          
            job.Exp = jobExp;
           
            job.Sex = sex;
            //job.Summary = sumny;
            job.Title = jobName;
            job.CategoryID = categoryID;
            job.CallingID = callingID;

            job.ProvinceID = provinceID;
            job.AreaID = areaID;
            job.CityID = cityID;
            job.Province = Utility.GetStr(db.ExecuteScalar("select Name from Provinces where ID={0}", job.ProvinceID));
            job.City = Utility.GetStr(db.ExecuteScalar("select Name from Citys where ID={0}", job.CityID));
            job.Area = Utility.GetStr(db.ExecuteScalar("select Name from Areas where ID={0}", job.AreaID));
             
           

            job.JobCount = Convert.ToInt32(jobCount);
            job.MonthlyPay = MonthlyPay.Value.Trim() != "" ? Convert.ToDouble(MonthlyPay.Value.Trim()) : 0;
            job.WorkType = Convert.ToInt32(workType.Value);
            job.LinkEmail = this.LinkEmail.Value;
            job.LinkName = this.LinkName.Value;
            job.LinkPhone = this.LinkPhone.Value;
            job.AgeArea = txtAgeArea.Value.Trim() == "" ? "不限" : txtAgeArea.Value.Trim();


            job.EndTime = endtime.Value;
            job.ModifyTime = DateTime.Now;
            job.RefreshTime = DateTime.Now;
            
            long count = biz.Update(job);
            if (count > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "职位信息保存成功!", "Default.aspx");
                return;
            }
            else
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("职位信息保存失败!");
                return;
            }
        }
    }
}
