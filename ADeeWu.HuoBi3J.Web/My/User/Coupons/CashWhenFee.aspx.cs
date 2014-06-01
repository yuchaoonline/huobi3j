﻿using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.Web.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADeeWu.HuoBi3J.Web.My.User.Coupons
{
    public partial class CashWhenFee : PageBase_MyUser
    {
        DAL.Coupons_Subject subjectDAL = new DAL.Coupons_Subject();
        DAL.Coupons_CashWhenFee cashWhenFeeDAL = new DAL.Coupons_CashWhenFee();
        DAL.Coupons_CashWhenFee_Condition conditionDAL = new DAL.Coupons_CashWhenFee_Condition();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BandData();
            }
        }

        private void BandData()
        {
            var subject = subjectDAL.GetEntity(new string[] { "CreateUserID", "SubjectType" }, new object[] { this.LoginUser.UserID, "CashWhenFee" });
            if (subject == null) return;
            hfSubjectID.Value = subject.ID.ToString();

            var casewhenfees = cashWhenFeeDAL.GetEntityList("CreateDate desc", new string[] { "CouponsSubjectID" }, new object[] { subject.ID });
            if(casewhenfees==null || !casewhenfees.Any()) return;

            var casewhenfee = casewhenfees.FirstOrDefault();
            txtMoney.Text = casewhenfee.Money.Value.ToString("0.00");
            txtFee.Text = casewhenfee.Fee.Value.ToString("0.00");
            dtStartDate.Text = subject.StartDate.Value.ToString("yyyy/MM/dd");
            dtEndDate.Text = subject.EndDate.Value.ToString("yyyy/MM/dd");

            var condition = conditionDAL.GetEntity("[SalemanUserID] = " + this.LoginUser.UserID);
            if (condition != null)
            {
                txtConditionMoney.Text = condition.Money.Value.ToString("0.00");
                txtMemo.Text = condition.Memo;

                btnShow.Text = condition.IsShow.Value ? "隐藏" : "显示";
            }

            rpLog.DataSource = cashWhenFeeDAL.Select("CouponsSubjectID=" + subject.ID, "createdate desc");
            rpLog.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var money = Utility.GetDecimal(txtMoney.Text, 0);
            var fee = Utility.GetDecimal(txtFee.Text, 0);
            var startDate = Utility.GetDateTime(dtStartDate.Text, DateTime.MinValue);
            var endDate = Utility.GetDateTime(dtEndDate.Text, DateTime.MinValue);
            var subjectID = Utility.GetInt(hfSubjectID.Value, 0);

            if (fee == 0)
            {
                WebUtility.ShowMsg("消费金额应该大于0");
                return;
            }
            if (money == 0)
            {
                WebUtility.ShowMsg("消费金额应该大于0");
                return;
            }

            if (subjectID <= 0)
            {
                subjectID = AddSubject(string.Format("{0}商家的现金抵扣活动",this.LoginUser.LoginName),startDate.Value,endDate.Value);
            }
            else
            {
                var subject = subjectDAL.GetEntity(subjectID);
                subject.StartDate = startDate;
                subject.EndDate = endDate;
                subjectDAL.Update(subject);
            }
            var cashWhenFee = new Model.Coupons_CashWhenFee
            {
                CouponsSubjectID = subjectID,
                CreateDate = DateTime.Now,
                EndDate = endDate,
                StartDate = startDate,
                Money = money,
                Fee=fee
            };
            if (cashWhenFeeDAL.Add(cashWhenFee) > 0)
            {
                WebUtility.ShowMsg(this,"处理成功！","CashWhenFee.aspx");
                return;
            }

            WebUtility.ShowMsg("处理失败，请重试！");
        }

        private int AddSubject(string name,DateTime startDate,DateTime endDate)
        {
            var subject = new Model.Coupons_Subject
            {
                Inactive = false,
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                CreateUserID  = (int)this.LoginUser.UserID,
                SubjectType = "CashWhenFee",
            };

            return subjectDAL.Add(subject);
        }

        public string GetQRURL(int count)
        {
            return "/QR.aspx?s=" + HttpUtility.UrlEncode("/coupons/cashwhenfeegeneralticket.aspx?salemanuserid=" + this.LoginUser.UserID + "&count="+count);
        }

        protected void btnCondition_Click(object sender, EventArgs e)
        {
            var money = txtConditionMoney.Text.GetDecimal(0);
            var memo = txtMemo.Text;

            if (money == 0)
            {
                WebUtility.ShowMsg("获取现金抵扣券的消费金额应该大于0！");
                return;
            }

            var condition = conditionDAL.GetEntity("[SalemanUserID] = " + this.LoginUser.UserID);
            if (condition == null){
                condition = new Model.Coupons_CashWhenFee_Condition
                {
                    SalemanUserID =(int) this.LoginUser.UserID,
                    Money = money,
                    Memo = memo,
                    IsShow = true,
                };

                conditionDAL.Add(condition);
                WebUtility.ShowMsg("修改成功！");
                return;
            }

            condition.Memo = memo;
            condition.Money = money;
            conditionDAL.Update(condition);
            WebUtility.ShowMsg("修改成功！");
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            var condition = conditionDAL.GetEntity("[SalemanUserID] = " + this.LoginUser.UserID);
            if (condition == null)
            {
                WebUtility.ShowMsg("还没有设置获赠条件，请先设置！");
                return;
            }

            condition.IsShow = !condition.IsShow.Value;
            conditionDAL.Update(condition);

            WebUtility.ShowMsg(this, "设置成功！", "CashWhenFee.aspx");
        }
    }
}