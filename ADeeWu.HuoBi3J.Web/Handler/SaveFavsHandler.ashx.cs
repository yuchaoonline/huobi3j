using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace ADeeWu.HuoBi3J.Web.Handler
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SaveFavsHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request.QueryString["favtype"];
            //data: "uid=<%=UserID %>&HomeID="+$("#hfHID").val()+"&favtype=<%=FavType%>&remark=
            //"+$("#txtRemark").val()+"&s="+new Date().getMilliseconds(),
            int falg = 1;
            if(type=="0")
            {
                falg = HouseFavSave(context);
            }else if(type=="1")
            {
                falg = JobFavSave(context);
            }else if(type=="2")
            {
                falg=SupplyDemandFavSave(context);

            }else if(type=="3")
            {
                falg = MarkerInfoFavSave(context);
            }
            context.Response.Write(falg);
        }
        int HouseFavSave(HttpContext context)
        {
            string hid = context.Request.QueryString["ObjectID"];
            string uid = context.Request.QueryString["UserID"];
            if(hid.Trim()==""||uid.Trim()=="")
            {
                return 0;
            }
            ADeeWu.HuoBi3J.DAL.House_SeekerFavs biz = new ADeeWu.HuoBi3J.DAL.House_SeekerFavs();
            if(biz.Exist(new string[]{"UserID","HouseID"},new string[]{uid,hid}))
            {
                return 2;
            }
            ADeeWu.HuoBi3J.Model.House_SeekerFavs entity = new ADeeWu.HuoBi3J.Model.House_SeekerFavs();
            entity.FavTime = DateTime.Now;
            entity.HouseID = long.Parse(hid);
            entity.Link = "";
            entity.Note = context.Request.QueryString["remark"];
            entity.UserID = long.Parse(uid);
            
            long id= biz.Add(entity);
            if (id > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        int JobFavSave(HttpContext context)
        {
            string jid = context.Request.QueryString["ObjectID"];
            string uid = context.Request.QueryString["UserID"];
            if (jid.Trim() == "" || uid.Trim() == "")
            {
                return 0;
            }
            ADeeWu.HuoBi3J.DAL.Job_SeekerFavs biz = new ADeeWu.HuoBi3J.DAL.Job_SeekerFavs();
            if (biz.Exist(new string[] { "UserID", "JobID" }, new string[] { uid, jid }))
            {
                return 2;
            }
            
            ADeeWu.HuoBi3J.Model.Job_SeekerFavs entity = new ADeeWu.HuoBi3J.Model.Job_SeekerFavs();
            entity.CreateTime = DateTime.Now;
            entity.JobID = long.Parse(jid);
            entity.Notes =context.Request.QueryString["remark"];
            entity.UserID = long.Parse(uid);
            long id= biz.Add(entity);
            return id > 0 ? 1 : 0;
            
        }
        int MarkerInfoFavSave(HttpContext context)
        {
            string jid = context.Request.QueryString["ObjectID"];
            string uid = context.Request.QueryString["UserID"];
            if (jid.Trim() == "" || uid.Trim() == "")
            {
                return 0;
            }
            ADeeWu.HuoBi3J.DAL.Market_SeekerFavs biz = new ADeeWu.HuoBi3J.DAL.Market_SeekerFavs();
            if (biz.Exist(new string[] { "UserID", "MarketInfoID" }, new string[] { uid, jid }))
            {
                return 2;
            }

            ADeeWu.HuoBi3J.Model.Market_SeekerFavs entity = new ADeeWu.HuoBi3J.Model.Market_SeekerFavs();
            entity.CreateTime = DateTime.Now;
            entity.MarketInfoID = long.Parse(jid);
            entity.Notes = context.Request.QueryString["remark"];
            entity.UserID = long.Parse(uid);
            long id = biz.Add(entity);
            return id > 0 ? 1 : 0;

        }
        int SupplyDemandFavSave(HttpContext context)
        {
            string jid = context.Request.QueryString["ObjectID"];
            string uid = context.Request.QueryString["UserID"];
            if (jid.Trim() == "" || uid.Trim() == "")
            {
                return 0;
            }
            ADeeWu.HuoBi3J.DAL.SD_SeekerFavs biz = new ADeeWu.HuoBi3J.DAL.SD_SeekerFavs();
            if (biz.Exist(new string[] { "UserID", "SupplyDemandID" }, new string[] { uid, jid }))
            {
                return 2;
            }

            ADeeWu.HuoBi3J.Model.SD_SeekerFavs entity = new ADeeWu.HuoBi3J.Model.SD_SeekerFavs();
            entity.CreateTime = DateTime.Now;
            entity.SupplyDemandID = long.Parse(jid);
            entity.Notes = context.Request.QueryString["remark"];
            entity.ModifyTime = DateTime.Now;
            entity.UserID = long.Parse(uid);
            long id = biz.Add(entity);
            return id > 0 ? 1 : 0;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
