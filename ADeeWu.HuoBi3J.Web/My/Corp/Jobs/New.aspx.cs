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
    public partial class New : Class.PageBase_MyCorp 
    {


        public override string FunctionCode
        {
            get
            {
                return "Corp-Jobs-New";
            }
        }

        DataBase db = DataBase.Create();

        protected void Page_Load(object sender, EventArgs e)
        {

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
            string jobCount=this.JobCount.Value.Trim();
            string jobMonney=this.MonthlyPay.Value.Trim();
            int jcount = 0;
            double jmoney = 0;
            ADeeWu.HuoBi3J.DAL.Jobs biz = new ADeeWu.HuoBi3J.DAL.Jobs();
            if (jobName == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写职位名称!");
                return;
            }
            //else if (biz.Exist(new string[] { "Title", "CorpID" },new string[]{jobName,this.LoginUser.CorpID.ToString()}))
            //{
            //    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("您输入的职位名称已经存在!");
            //    return;
            //}  

            ADeeWu.HuoBi3J.Model.Jobs job = new ADeeWu.HuoBi3J.Model.Jobs();
            long categoryID = Utility.GetLong(this.syncSelectorJobCategory.SelectedValue, 0);
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
            else {
                if (!int.TryParse(jobCount,out jcount))
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("招聘人数请填写整数!");
                    return;
                }
            }
            if (!double.TryParse(jobMonney,out jmoney))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("职位月薪必须为数字!");
                return;
            }
            

            
            //job.Address = jobAddress;
            job.Content = desc;
            job.Education = Education;
           
           

            job.Exp = jobExp;
            job.ModifyTime = DateTime.Now;
            job.Sex = sex;
            //job.Summary = sumny;
            job.Title = jobName;
            job.CheckState = 1;//默认通过审核
            
            job.CategoryID = categoryID;
            job.CallingID = callingID;

            job.ProvinceID = provinceID;
            job.AreaID = areaID;
            job.CityID = cityID;
            job.Province = Utility.GetStr(db.ExecuteScalar("select Name from Provinces where ID={0}", job.ProvinceID));
            job.City = Utility.GetStr(db.ExecuteScalar("select Name from Citys where ID={0}", job.CityID));
            job.Area = Utility.GetStr(db.ExecuteScalar("select Name from Areas where ID={0}", job.AreaID));

          
            job.CorpID = this.LoginUser.CorpID;
            job.JobCount = jcount;
            job.MonthlyPay = jmoney;// MonthlyPay.Value.Trim() != "" ? Convert.ToDouble(MonthlyPay.Value.Trim()) : 0;
            job.WorkType = Convert.ToInt32(workType.Value);
            job.LinkEmail = this.LinkEmail.Value;
            job.LinkName = this.LinkName.Value;
            job.LinkPhone = this.LinkPhone.Value;
            job.AgeArea = txtAgeArea.Value.Trim() == "" ? "不限" : txtAgeArea.Value.Trim();

            job.EndTime = endtime.Value;
            job.CreateTime = DateTime.Now;
            job.RefreshTime = DateTime.Now;
            long id= biz.Add(job);
            if (id > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this,"职位信息保存成功!","Default.aspx");
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
