using System;
using System.Collections.Generic;
using System.Web;
using ADeeWu.HuoBi3J.Libary;
using ADeeWu.HuoBi3J.SQL;
using System.Data;
using System.Web.SessionState;
using ADeeWu.HuoBi3J.Web.Class;
using ADeeWu.HuoBi3J.DAL;
using System.IO;
using Newtonsoft.Json;

namespace ADeeWu.HuoBi3J.Web.Ajax
{
    /// <summary>
    /// Center 的摘要说明
    /// </summary>
    public class Center : IHttpHandler, IRequiresSessionState, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var method = WebUtility.GetRequestStr("method", "");
            var result = "";
            try
            {
                switch (method.ToLower())
                {
                    case "getcountofanswerquestionincenter": { result = GetCountOfAnswerQuestionInCenter(); }; break;
                    case "getanswerbyqid": { result = GetAnswerByQID(); }; break;
                    case "addquestion": { result = AddQuestion(); }; break;
                    case "addanswer": { result = AddAnswer(); }; break;
                    case "addkey": { result = AddKey(); }; break;
                    case "addbusinesscircle": { result = AddBusinessCircle(); }; break;
                    case "addinform": { result = AddInform(); }; break;
                    case "getattention": { result = GetAttention(); }; break;
                    case "getattentioncount": { result = GetAttentionCount(); }; break;
                    case "getkeymanagebykid": { result = GetKeyManageByKID(); }; break;
                    case "ismykey": { result = IsMyKey(); }; break;
                    case "getproductlist": { result = GetProductList(); }; break;
                    case "hasticket": { result = HasTicket(); }; break;
                    case "getbusinesscirclecount": { result = GetBusinessCircleCount(); }; break;
                    case "getlocationpoint": { result = GetLocationPoint(); }; break;
                    case "getcity": { result = GetCity(); }; break;
                    case "addfav": { result = AddFav(); }; break;
                    default: { result = "something is error!"; }; break;
                }
            }
            catch (Exception e)
            {
                result = JsonConvert.SerializeObject(new { statue = false, msg = e.Message });
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

        private string AddFav()
        {
            var uid = UserSession.GetSession() == null ? 0 : UserSession.GetSession().UserID;
            if (uid <= 0) return JsonConvert.SerializeObject(new { statue = false, msg = "请登录再收藏！" });

            var userid = WebUtility.GetRequestInt("userid", 0);
            var fav = new Model.Common_Favourite
            {
                CreateDate = DateTime.Now,
                DataID = userid,
                DataType = "center_saleman",
                Memo = "",
                UserID = (int)uid,
            };
            if (new DAL.Common_Favourite().Add(fav) > 0)
            {
                return JsonConvert.SerializeObject(new { statue = true });
            }

            return JsonConvert.SerializeObject(new { statue = false, msg = "收藏失败，请重试！" });
        }

        private string GetCity()
        {
            var citys = new List<object>();
            DataBase db = DataBase.Create();
            var dtCitys = db.Select("select * from citys where id in( select cityid from vw_businesscircle group by cityid)");
            foreach (DataRow city in dtCitys.Rows)
            {
                citys.Add(new { cname = city["name"], cid = city["id"], pid = city["pid"] });
            }

            return JsonConvert.SerializeObject(citys);
        }

        private string GetLocationPoint()
        {
            var address = WebUtility.GetRequestStr("address","");

            if (string.IsNullOrWhiteSpace(address))
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "参数有误" });
            }

            return new BaiduAPIHelper().GetLocationPoint(address, AccountHelper.City);
        }

        private string GetAttention()
        {
            var kid = WebUtility.GetRequestInt("kid", -1);
            if (kid == -1) return "";

            DataBase db = DataBase.Create();
            db.Parameters.Append("kid", kid);
            var userkeys = db.Select("vw_UserKey", "kid=@kid", "");
            if (userkeys == null || userkeys.Rows.Count <= 0) return JsonConvert.SerializeObject(new { statue = false });;

            var userkeyList = new List<object>();
            foreach (DataRow userkey in userkeys.Rows)
            {
                userkeyList.Add(new { UID = userkey["uid"], UName = string.IsNullOrEmpty(userkey["uname"].ToString()) ? "木有名字" : userkey["uname"] });
            }

            return JsonConvert.SerializeObject(userkeyList);
        }

        private string GetAttentionCount()
        {
            var uid = UserSession.GetSession() == null ? 0 : UserSession.GetSession().UserID;
            if (uid <= 0) return JsonConvert.SerializeObject(new { statue = false });

            var AttentionQuestions = new DAL.AttentionQuestion().GetEntityList("createtime desc", new string[] { "uid", "isread" }, new object[] { uid, 0 });
            if (AttentionQuestions.Length <= 0) return JsonConvert.SerializeObject(new { statue = false });

            return JsonConvert.SerializeObject(new { statue = true, count = AttentionQuestions.Length, qid = AttentionQuestions[0].QID, issaleman = SaleManSession.IsSaleMan });
        }

        private string AddQuestion()
        {
            if (SaleManSession.IsSaleMan) return JsonConvert.SerializeObject(new { statue = false, msg = "你是业务员，无法添加提问！" });

            var kid = WebUtility.GetRequestInt("kid", -1);
            var content = WebUtility.GetRequestStr("content", "");
            var uid = WebUtility.GetRequestInt("uid", -1);

            if (kid == -1 || uid == -1) return "";

            var db = DataBase.Create();
            db.Parameters.Append("kid", kid);
            var businesses = db.Select("vw_Keys", "kid=@kid", "");
            if (businesses == null) return JsonConvert.SerializeObject(new { statue = false });
            var business = businesses.Rows[0];

            #region 添加提问
            DAL.Question questionDAL = new DAL.Question();
            var question = new Model.Question
            {
                CreateTime = DateTime.Now,
                Title = content,
                UID = uid,
                KID = kid,
                BID = Utility.GetLong(business["BID"], -1),
                AID = Utility.GetLong(business["AID"], -1),
                PID = Utility.GetLong(business["PID"], -1),
                CID = Utility.GetLong(business["CID"], -1),
            };
            var qid = questionDAL.Add(question);
            if (qid <= 0)
            {
                return JsonConvert.SerializeObject(new { statue = false });
            } 
            #endregion

            #region 添加关注人提醒
            var attentionQuestionDAL = new DAL.AttentionQuestion();
            var userKeys = new DAL.UserKey().GetEntityList("", new string[] { "kid" }, new object[] { kid });
            if (userKeys == null) return JsonConvert.SerializeObject(new { statue = false });

            foreach (var userkey in userKeys)
            {
                var attentionQuestion = new Model.AttentionQuestion
                {
                    IsRead = false,
                    IsReply = false,
                    QID = qid,
                    UID = userkey.UID,
                    CreateTime = DateTime.Now,
                };
                attentionQuestionDAL.Add(attentionQuestion);
            }
            #endregion

            #region 添加商品关联
            var productid = WebUtility.GetRequestInt("productID", -1);
            var typeid = WebUtility.GetRequestInt("typeid", -1);
            var productData = new Model.Center_Product_Data
            {
                DataID = (int)question.QID,
                ProductID = productid,
                TypeID = typeid,
            };
            new DAL.Center_Product_Data().Add(productData);
            #endregion

            return JsonConvert.SerializeObject(new { statue = true });
        }

        private string AddKey()
        {
            var bid = WebUtility.GetRequestInt("bid", -1);
            var name = WebUtility.GetRequestStr("name", "");

            if (bid == -1) return "";

            DAL.Key keyDAL = new DAL.Key();

            if (keyDAL.Exist(string.Format("name='{0}' and bid={1}", name, bid)))
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "关键字已存在！" });
            }

            var key = new Model.Key
            {
                CreateTime = DateTime.Now,
                BID = bid,
                Name = name,
            };
            var keyid = keyDAL.Add(key);
            if (keyid > 0)
            {
                if (SaleManSession.IsSaleMan)
                {
                    new DAL.Center_Info().Add(new Model.Center_Info
                    {
                        DataID = (int)keyid,
                        InfoType = 2,
                        UserID = (int)SaleManSession.SaleMan.UserID,
                    });
                }

                return JsonConvert.SerializeObject(new { statue = true });
            }
            else
            {
                return JsonConvert.SerializeObject(new { statue = false });
            }
        }

        private string AddAnswer()
        {
            var qid = WebUtility.GetRequestInt("qid", -1);
            var content = WebUtility.GetRequestStr("content", "");
            var uid = WebUtility.GetRequestInt("uid", -1);

            if (qid == -1 || uid == -1) return "";

            var question = new DAL.Question().GetEntity(qid);
            if (question == null) return JsonConvert.SerializeObject(new { statue = false });

            #region 添加回复
            DAL.Answer answerDAL = new DAL.Answer();
            var answer = new Model.Answer
            {
                CreateTime = DateTime.Now,
                Content = content,
                UID = uid,
                QID = qid,
            };
            var aid = answerDAL.Add(answer);
            if (aid <= 0)
            {
                return JsonConvert.SerializeObject(new { statue = false });
            }
            #endregion

            #region 标记为已回
            var db = DataBase.Create();
            var sql = "update attentionquestion set isreply = 1 where uid=@uid and qid=@qid";
            db.Parameters.Append("uid", uid);
            db.Parameters.Append("qid", qid);
            db.ExecuteSql(sql);
            #endregion

            #region 添加一条未读提醒给提问人
            var attentionQuestionDAL = new DAL.AttentionQuestion();
            if (!attentionQuestionDAL.Exist(new string[] { "uid", "qid" }, new object[] { question.UID, qid }))
            {
                var attentionQuestion = new Model.AttentionQuestion
                {
                    IsReply = false,
                    IsRead = false,
                    QID = qid,
                    UID = question.UID,
                    CreateTime = DateTime.Now,
                };
                attentionQuestionDAL.Add(attentionQuestion);
            }
            else
            {
                var sql2 = "update attentionquestion set isread = 0 where uid=@uid and qid=@qid";
                db.Parameters.Append("uid", question.UID);
                db.Parameters.Append("qid", qid);
                db.ExecuteSql(sql2);
            }
            #endregion

            return JsonConvert.SerializeObject(new { statue = true });
        }

        private string AddBusinessCircle()
        {
            var aid = WebUtility.GetRequestInt("aid", -1);
            var name = WebUtility.GetRequestStr("name", "");

            if (aid == -1) return "";

            DAL.BusinessCircle businessCircleDAL = new DAL.BusinessCircle();

            if (businessCircleDAL.Exist(string.Format("bname='{0}' and aid={1}", name, aid)))
            {
                return JsonConvert.SerializeObject(new { statue = false, msg = "商圈已存在！" });
            }

            var key = new Model.BusinessCircle
            {
                CreateTime = DateTime.Now,
                AID = aid,
                BName = name,
            };
            var bid = businessCircleDAL.Add(key);
            if ( bid > 0)
            {
                if (SaleManSession.IsSaleMan)
                {
                    new DAL.Center_Info().Add(new Model.Center_Info
                    {
                        DataID = (int)bid,
                        InfoType = 1,
                        UserID = (int)SaleManSession.SaleMan.UserID,
                    });
                }

                return JsonConvert.SerializeObject(new { statue = true ,bid = bid});
            }
            else
            {
                return JsonConvert.SerializeObject(new { statue = false });
            }
        }

        private string GetBusinessCircleCount()
        {
            var count = 0;
            var db = DataBase.Create();
            var uid = WebUtility.GetRequestInt("uid",0);
            if (uid <= 0) return JsonConvert.SerializeObject(new { count = count });

            count = Utility.GetInt(db.ExecuteScalar("select count(uid) from vw_userkey where uid = {0}", uid), 0);

            return JsonConvert.SerializeObject(new { count = count });
        }

        private string AddInform()
        {
            var id = WebUtility.GetRequestInt("id", -1);
            var typeid = WebUtility.GetRequestStr("typeid","");

            if (id == -1) return JsonConvert.SerializeObject(new { statue = false, msg = "id不存在" });
            if (string.IsNullOrEmpty(typeid)) return JsonConvert.SerializeObject(new { statue = false, msg = "typeid不存在" });

            if (Enum.IsDefined(typeof(InFormType), typeid)) return JsonConvert.SerializeObject(new { statue = false, msg = "typeid错误!" });

            DAL.Center_Inform informCircleDAL = new DAL.Center_Inform();

            if (informCircleDAL.Exist(new string[] { "contentid", "informtype" }, new object[] { id, typeid })) return JsonConvert.SerializeObject(new { statue = false, msg = "该内容已被举报，请耐心等待处理！" });

            var inform = new Model.Center_Inform
            {
                CreateTime = DateTime.Now,
                ContentID = id,
                InformType = Utility.GetInt(typeid, -1),
            };
            if (informCircleDAL.Add(inform) > 0)
            {
                return JsonConvert.SerializeObject(new { statue = true });
            }
            else
            {
                return JsonConvert.SerializeObject(new { statue = false });
            }
        }

        private string GetCountOfAnswerQuestionInCenter()
        {
            var kid = WebUtility.GetRequestStr("kid", "");

            if (!Utility.IsNumeric(kid))
            {
                var nullObject = new { questionCount = "0", answerCount = "0" };
                return JsonConvert.SerializeObject(nullObject);
            }

            DAL.Question questionDAL = new DAL.Question();
            DAL.Answer answerDAL = new DAL.Answer();
            var questions = questionDAL.GetEntityList("", new string[] { "KID" }, new object[] { kid });
            var answerCount = 0;
            foreach (var question in questions)
            {
                var answers = answerDAL.GetEntityList("", new string[] { "QID" }, new object[] { question.QID });
                answerCount += answers.Length;
            }

            var jsonObject = new { questionCount = questions.Length.ToString(), answerCount = answerCount.ToString() };
            return JsonConvert.SerializeObject(jsonObject);
        }

        private string GetAnswerByQID()
        {
            var qid = WebUtility.GetRequestInt("qid", -1);
            if (qid == -1)
            {
                return "";
            }

            DataBase db = DataBase.Create();

            db.Parameters.Append("qid", qid);
            var dt = db.Select("vw_Answers", "qid = @qid", "createtime");

            var answers = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                answers.Add(new { content = Utility.GetStr(row["Content"], "N/A"), username = Utility.GetStr(row["LoginName"], "N/A"), CreateTime = Utility.GetStr(row["CreateTime"], "N/A") });
            }

            return JsonConvert.SerializeObject(answers);
        }

        private string GetKeyManageByKID()
        {
            var kid = WebUtility.GetRequestInt("kid", -1);
            if (kid == -1) return JsonConvert.SerializeObject(new { statue = false });

            var db = DataBase.Create();
            var manages = db.Select("vw_Center_Key_Manage", "kid=" + kid, "");
            if (manages == null || manages.Rows.Count <= 0) return JsonConvert.SerializeObject(new { statue = false });

            var manage = manages.Rows[0];
            return JsonConvert.SerializeObject(new
            {
                statue = true,
                kid = kid,
                kname = Utility.GetStr(manage["kname"], ""),
                uid = Utility.GetInt(manage["uid"], -1),
                loginname = Utility.GetStr(manage["loginname"], ""),
                createtime = Utility.GetDateTime(manage["creattime"], DateTime.Now),
                price = Utility.GetLong(manage["price"], 0)
            });
        }

        private string IsMyKey()
        {
            var kid = WebUtility.GetRequestInt("kid", -1);
            var uid = WebUtility.GetRequestInt("uid", -1);

            if (kid == -1) return JsonConvert.SerializeObject(new { statue = false, msg = "参数错误！" });

            if (new DAL.Center_Key_Manage().Exist(new string[] { "kid", "uid" }, new object[] { kid, uid }))
                return JsonConvert.SerializeObject(new { statue = true });
            else
                return JsonConvert.SerializeObject(new { statue = false });
        }

        private string GetProductList()
        {
            var cateid = WebUtility.GetRequestInt("cateid", -1);
            var name = WebUtility.GetRequestStr("name", "");

            if (cateid == -1) return JsonConvert.SerializeObject(new { statue = false, msg = "参数错误！" });

            var db = new DAL.Center_Products();
            var sql = "";
            if (string.IsNullOrWhiteSpace(name))
            {
                sql = string.Format("CategoryID={0}", cateid, name);
            }else{
                sql = string.Format("CategoryID={0} and name like '%{1}%'", cateid, name);
            }
            var dt = db.Select(sql, "");
            if (dt == null || dt.Rows.Count <= 0) return JsonConvert.SerializeObject(new { statue = true, msg = "无相关产品" });

            var products = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                products.Add(new
                {
                    productid = Utility.GetInt(row["id"],-1),
                    categoryid = Utility.GetInt(row["categoryid"],-1),
                    name = Utility.GetStr(row["name"], "N/A"),
                    content = Utility.GetStr(row["content"], "N/A"),
                    picture = Utility.GetStr(row["picture"], "N/A"),
                    createtime = Utility.GetStr(row["createtime"], "N/A")
                });
            }

            return JsonConvert.SerializeObject(new { statue = true, products = products });
        }

        private string HasTicket()
        {
            var uid = WebUtility.GetRequestInt("uid", -1);
            var db = DataBase.Create();

            var result = db.ExecuteScalar(string.Format("select count(*) from ct_cashtickets where corpid = (select id from corporations where userid = {0}) and checkstate = 0", uid));
            if (Utility.GetInt(result, 0) > 0)
                return JsonConvert.SerializeObject(new { statue = true });
            return JsonConvert.SerializeObject(new { statue = false });
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