using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADeeWu.HuoBi3J.SQL;
using ADeeWu.HuoBi3J.Libary;
using System.Data;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.SearchCorpAgents
{
    
    public partial class View : Class.PageBase_MyCorp
    {
        DataBase db = DataBase.Create();
        DAL.CA_QuaAgentInCorps dalUserInCorp = new DAL.CA_QuaAgentInCorps();
        long id = WebUtility.GetRequestLong("id", 0);

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                DataTable dt = db.Select("select * from vw_CA_QualifiedAgents where ID={0} and IsHidden=0 and CheckState=1", id);

                if (dt.Rows.Count == 0)
                {
                    WebUtility.ShowMsg(this, "该记录已不存在！");
                    return;
                }

                DataRow dr = dt.Rows[0];
                this.hfUserID.Value = dr["UserID"].ToString();
                this.liteRealName.Text = dr["RealName"].ToString();
                this.liteSex.Text = dr["Sex"].ToString();
                this.liteBirthday.Text = Utility.GetDateTime(dr["BirthDay"], DateTime.MinValue).Value.ToString("yyyy年MM月dd日");
                this.liteLocation.Text = string.Format("{0} {1} {2}", dr["ProvinceName"], dr["CityName"], dr["AreaName"]);
                this.liteAddress.Text = dr["Address"].ToString();
                this.liteZipCode.Text = dr["ZipCode"].ToString();
                this.liteEducation.Text = WebUtility.Switch(dr["Education"].ToString(), GlobalParameter.switch_Education);
                this.liteWorkExp.Text = WebUtility.Switch(dr["WorkExp"].ToString(), GlobalParameter.switch_WorkExp);
                this.liteSchool.Text = dr["School"].ToString();
                this.liteSpeciality.Text = dr["Speciality"].ToString();
                this.liteSkill.Text = dr["Skill"].ToString();
                this.liteNote.Text = dr["Note"].ToString();
                this.liteCreateTime.Text = dr["CreateTime"].ToString();

                //更新点击次数
                db.ExecuteSql("update vw_CA_QualifiedAgents set VisitCount=VisitCount+1 where id=" + id);

                //判断商家与商家代表关系是否已存在
                if (dalUserInCorp.Exist(" CorpID=" + this.LoginUser.CorpID + " and UserID=" + dr["UserID"].ToString()))
                {
                    this.ph01.Visible = false;
                    this.ph02.Visible = true;
                }
                else
                {
                    this.ph01.Visible = true;
                    this.ph02.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long userID = Utility.GetLong(this.hfUserID.Value, 0);
            if (userID > 0)
            {
                if (!dalUserInCorp.Exist(" CorpID=" + this.LoginUser.CorpID + " and UserID=" + userID.ToString()))
                {
                    Model.CA_QuaAgentInCorps ent = new Model.CA_QuaAgentInCorps();
                    ent.CorpID = this.LoginUser.CorpID;
                    ent.UserID = userID;
                    ent.CreateTime = DateTime.Now;
                    ent.ModifyTime = DateTime.Now;
                    ent.CheckState = 0;
                    if (dalUserInCorp.Add(ent) > 0)
                    {
                        WebUtility.ShowMsg(this, "操作成功！");
                    }
                    else
                    {
                        WebUtility.ShowMsg(this, "操作失败，请与我们联系！");
                        return;
                    }
                }
            }
        }
    }
}
