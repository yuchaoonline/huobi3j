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

namespace ADeeWu.HuoBi3J.Web.Admin.Jobs
{
    public partial class Edit :  PageBase
    {

        public override string PageID
        {
            get
            {
                return "014002";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
               if(!IsPostBack)
               {
                   ADeeWu.HuoBi3J.DAL.Jobs dal = new ADeeWu.HuoBi3J.DAL.Jobs();
                   long id = ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0);
                   ADeeWu.HuoBi3J.Model.Jobs entity= dal.GetEntity(id);
                   if (entity == null)
                   {
                       ADeeWu.HuoBi3J.Libary.WebUtility.ShowAndGoBack(this, "对不起，找不到您要编辑的职位信息！");
                   }
                   else
                   {
                       this.jobName.Value = entity.Title;
                       this.jobAddress.Value = entity.Address;
                       this.jobSex.Value = entity.Sex.ToString();
                       this.Education.Value = entity.Education.ToString();
                       this.jobExp.Value = entity.Exp.ToString();
                       this.jobSumny.Value = entity.Summary;
                       this.jobDesc.Value = entity.Content;
                       this.DateTimeSelector1.Text = entity.EndTime.ToString("yyyy/MM/dd");
                       this.syncSelectorLocation.Values = new string[] { entity.ProvinceID.ToString(), entity.CityID.ToString(), entity.AreaID.ToString() };
                       this.syncSelectorJobCategory.Values = new string[] { entity.CategoryID.ToString() };
                       this.workType.Value = entity.WorkType.ToString();
                       this.JobCount.Value = entity.JobCount.ToString();
                       this.LinkEmail.Value = entity.LinkEmail;
                       this.LinkName.Value = entity.LinkName;
                       this.LinkPhone.Value = entity.LinkPhone;
                       this.MonthlyPay.Value = entity.MonthlyPay.ToString("0.00");
                       this.txtAgeArea.Value = entity.AgeArea;
                       setCheckState(entity.CheckState);
                       ADeeWu.HuoBi3J.DAL.Corporations corp = new ADeeWu.HuoBi3J.DAL.Corporations();
                       ADeeWu.HuoBi3J.Model.Corporations corpentity= corp.GetEntity(entity.CorpID);
                       if(corpentity!=null)
                       {
                           lblCorpName.Text = corpentity.CorpName;
                       }

                   }
               }
        }
        int getCheckState()
        {
            if (cbochecktrue.Checked)
            {
                return 1;
            }
            else if (cbocheckfalse.Checked)
            {
                return 2;
            }
            else if (cboStateEnd.Checked)
            {
                return 3;
            }
            else
            {
                return -1;
            }
        }
        void setCheckState(int state)
        {
            if (state == 1)
            {
                cbochecktrue.Checked = true;
            }
            else if (state == 2)
            {
                cbocheckfalse.Checked = true;
            }
            else if (state == 3)
            {
                cboStateEnd.Checked = true;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string jobName = this.jobName.Value.Trim();
            string jobAddress = this.jobAddress.Value.Trim();
            int sex = int.Parse(this.jobSex.Value.Trim());
            int Education = int.Parse(this.Education.Value);
            int jobExp = int.Parse(this.jobExp.Value);
            string sumny = this.jobSumny.Value.Trim();
            string desc = this.jobDesc.Value;
            string endtime = this.DateTimeSelector1.Text;
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
            long categoryID = long.Parse(this.syncSelectorJobCategory.SelectedValue);

            string[] locationValues = this.syncSelectorLocation.Values;

            long provinceID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(locationValues[0], -1);
            long cityID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(locationValues[1], -1);
            long areaID = ADeeWu.HuoBi3J.Libary.Utility.GetLong(locationValues[2], -1);
            string jobCount = this.JobCount.Value.Trim();
            string jobMonney = this.MonthlyPay.Value.Trim();
            int jcount = 0;
            double jmoney = 0;
            if (provinceID == -1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择行业!");
                return;
            }
            if (categoryID == -1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择省份!");
                return;
            }
            if (cityID == -1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择城市!");
                return;
            }

            if (jobAddress == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写工作地址!");
                return;
            }
            if (areaID == -1)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请选择地区!");
                return;
            }
            if (sumny == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写职位简述!");
                return;
            }
            if (desc == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写职位详细说明!");
                return;
            }
            if (endtime == "")
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("请填写招聘职位过期时间!");
                return;
            }
            else
            {
                if (!int.TryParse(jobCount, out jcount))
                {
                    ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("招聘人数请填写整数!");
                    return;
                }
            }
            if (!double.TryParse(jobMonney, out jmoney))
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg("职位月薪必须为数字!");
                return;
            }
            ADeeWu.HuoBi3J.Model.Jobs job = biz.GetEntity(ADeeWu.HuoBi3J.Libary.WebUtility.GetRequestLong("id", 0));
            job.Address = jobAddress;
            job.Content = desc;
            job.Education = Education;
            job.EndTime = DateTime.Parse(endtime);
            //验证时间
            //todo:update

            job.Exp = jobExp;
            job.ModifyTime = DateTime.Now;
            job.Sex = sex;
            job.Summary = sumny;
            job.Title = jobName;
             
            job.AreaID = areaID;
            job.CategoryID = categoryID;
            job.CityID = cityID;
            job.ProvinceID = provinceID;
             
            job.RefreshTime = DateTime.Now;
            int state = getCheckState();
            job.CheckState = state != -1 ? state : job.CheckState;
            job.JobCount =jcount;
            job.MonthlyPay = jmoney;
            job.WorkType = Convert.ToInt32(workType.Value);
            job.LinkEmail = this.LinkEmail.Value;
            job.LinkName = this.LinkName.Value;
            job.LinkPhone = this.LinkPhone.Value;
            job.AgeArea = txtAgeArea.Value.Trim() == "" ? "没有年龄限制" : txtAgeArea.Value.Trim();
            long count = biz.Update(job);
            if (count > 0)
            {
                ADeeWu.HuoBi3J.Libary.WebUtility.ShowMsg(this, "职位信息保存成功!", "List.aspx");
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
