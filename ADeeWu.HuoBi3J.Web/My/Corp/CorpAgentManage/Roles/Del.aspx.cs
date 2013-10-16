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
using System.IO;
using ADeeWu.HuoBi3J.SQL;

namespace ADeeWu.HuoBi3J.Web.My.Corp.CorpAgentManage.Roles
{
    public partial class Del : Class.PageBase_MyCorp
    {

        DAL.CA_Roles dalRoles = new ADeeWu.HuoBi3J.DAL.CA_Roles();
        DAL.CorpAgents dalCorpAgents = new ADeeWu.HuoBi3J.DAL.CorpAgents();
        DAL.CA_RolePermissions dalRolePermissions = new ADeeWu.HuoBi3J.DAL.CA_RolePermissions();

        protected void Page_Load(object sender, EventArgs e)
        {
            string IDString = ADeeWu.HuoBi3J.Libary.Utility.GetStr(Request["id"]);

            if (IDString.IndexOf(",") > -1)
            {
                foreach (string s in IDString.Split(','))
                {
                    long id = ADeeWu.HuoBi3J.Libary.Utility.GetLong(s, 0);
                    if (id > 0)
                    {
                        Delete(id);
                    }
                }
            }
            else
            {
                long id = ADeeWu.HuoBi3J.Libary.Utility.GetLong(IDString, 0);
                if (id > 0)
                {
                    Delete(id);
                }
            }
            WebUtility.ShowMsg(this, "操作成功!", ".");

        }

        private void Delete(long roleId)
        {
            if (dalRoles.Delete("id=" + roleId + " and ManagerCorpID=" + this.LoginUser.CorpID) > 0) //删除角色数据
            {

                //将该角色所有权限数据清空
                dalRolePermissions.Delete(string.Format("RoleID={0} and ManagerCorpID={1}", roleId, this.LoginUser.CorpID));

                //将属于 "删除角色" 的用户的角色设置为 "空"
                dalCorpAgents.Update("RoleID", 0, "RoleID=" + roleId + " and AgentCorpID=" + this.LoginUser.CorpID);


            }
        }
    }
}
