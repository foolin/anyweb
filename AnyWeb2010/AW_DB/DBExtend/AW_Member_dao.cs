using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Member_dao
	{
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="type">帐号类型：1手机2邮箱</param>
        /// <param name="account">手机号码或邮箱帐号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public AW_Member_bean funcLogin(int type, string account, string password)
        {
            this.propWhere = "fdMembPwd='" + Studio.Security.Secure.Md5(password) + "'";
            if (type == 1)
                this.propWhere += " AND fdMembMobile='" + account.Replace("'", "''") + "'";
            else
                this.propWhere += " AND fdMembEmail='" + account.Replace("'", "''") + "'";
            List<AW_Member_bean> list = this.funcGetList();
            AW_Member_bean member = null;
            if (list.Count > 0)  member = list[0];
            if (member != null)
            {
                member.fdMembLoginIP = HttpContext.Current.Request.UserHostAddress;
                member.fdMembLoginAt = DateTime.Now;
                funcUpdate(member);
                if (member.fdMembStatus == 1)
                {
                    funcAddCookie(member);
                }
            }
            return member;
        }

        public void funcAddCookie(AW_Member_bean member)
        {
            HttpCookie co = new HttpCookie("MEMBERUSER");

            co["ID"] = member.fdMembID.ToString();
            co["RD"] = member.fdMembPwd;
            co["NAME"] = HttpUtility.UrlEncodeUnicode(member.fdMembName);
            co["EMAIL"] = HttpUtility.UrlEncodeUnicode(member.fdMembEmail);
            co["TRUENAME"] = HttpUtility.UrlEncodeUnicode(member.fdMembTrueName);
            co["AVATOR"] = HttpUtility.UrlEncodeUnicode(member.fdMembAvator);
            co["ADDRESS"] = HttpUtility.UrlEncodeUnicode(member.fdMembAddress);
            co["POSTCODE"] = member.fdMembPostcode;
            co["MOBILE"] = member.fdMembMobile;
            co["PHONE"] = member.fdMembPhone;
            co["PROVINCEID"] = member.fdMembProvinceID.ToString();
            co["CITYID"] = member.fdMembCityID.ToString();

            co["POINT"] = member.fdMembPoint.ToString();

            //co.Expires = DateTime.Now.AddHours(2);

            HttpContext.Current.Response.Cookies.Add(co);
        }

        public AW_Member_bean funcGetMemberFromCookie()
        {
            HttpCookie co = HttpContext.Current.Request.Cookies["MEMBERUSER"];
            if (co == null)
                return null;
            if (co["ID"] == "" || !Studio.Web.WebAgent.IsInt32(co["ID"]))
                return null;

            AW_Member_bean bean = new AW_Member_bean();
            bean.fdMembID = int.Parse(co["ID"]);
            bean.fdMembPwd = co["RD"];
            bean.fdMembName = HttpUtility.UrlDecode(co["NAME"]);
            bean.fdMembEmail = HttpUtility.UrlDecode(co["EMAIL"]);
            bean.fdMembTrueName = HttpUtility.UrlDecode(co["TRUENAME"]);
            bean.fdMembAvator = HttpUtility.UrlDecode(co["AVATOR"]);
            bean.fdMembAddress = HttpUtility.UrlDecode(co["ADDRESS"]);

            bean.fdMembPostcode = co["POSTCODE"];
            bean.fdMembMobile = co["MOBILE"];
            bean.fdMembPhone = co["PHONE"];
            bean.fdMembProvinceID = int.Parse(co["PROVINCEID"]);
            bean.fdMembCityID = int.Parse(co["CITYID"]);

            bean.fdMembPoint = int.Parse(co["POINT"]);

            return bean;
        }

        public void funcLogout()
        {
            HttpCookie co = HttpContext.Current.Request.Cookies["MEMBERUSER"];
            if (co != null)
            {
                co.Expires = DateTime.Now.AddMinutes(-1);
                HttpContext.Current.Response.SetCookie(co);
            }
        }

        public List<AW_Member_bean> funcMemberSearch(string email, DateTime from,DateTime to, string status, int pageSize, int pageIndex)
        {
            this.propOrder = "ORDER BY fdMembRegAt DESC";
            this.propWhere = " 1=1";
            if (!String.IsNullOrEmpty(email))
            {
                this.propWhere += String.Format(" AND fdMembEmail like '%{0}%' ", email.Replace(" ", "%"));
            }
            if (from!=DateTime.MinValue)
            {
                this.propWhere += String.Format(" AND fdMembRegAt >= '{0}'",from);
            }
            if (to!=DateTime.MinValue)
            {
                this.propWhere += String.Format(" AND fdMembRegAt <= '{0}'", to);
            }
            if (!String.IsNullOrEmpty(status) && Studio.Web.WebAgent.IsInt32(status))
            {
                this.propWhere += " AND fdMembStatus = " + status;
            }
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;
            DataSet ds = base.funcCommon();
            List<AW_Member_bean> list = new List<AW_Member_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Member_bean bean = new AW_Member_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }

        public int funcLock(int memberId, int status)
        { 
            using (IDbExecutor db = this.NewExecutor())
            {
                string sql = String.Format("UPDATE AW_Member SET fdMembStatus = {1} WHERE fdMembID = {0}", memberId, status);
                return db.ExecuteNonQuery(sql);
            }

        }

        public int funcChangePwd(int memberId, string password)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                string sql = String.Format("UPDATE AW_Member SET fdMembPwd = '{1}' WHERE fdMembID = {0}", memberId, password);
                return db.ExecuteNonQuery(sql);
            }
        }

        public bool funcEmailExists(string email)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                string sql = String.Format("SELECT COUNT(*) FROM AW_Member WHERE fdMembEmail = '{0}'", email);
                return (int)db.ExecuteScalar(sql) > 0;
            }
        }

        public bool funcMobileExists(string mobile)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                string sql = String.Format("SELECT COUNT(*) FROM AW_Member WHERE fdMembMobile = '{0}'", mobile);
                return (int)db.ExecuteScalar(sql) > 0;
            }
        }

        public AW_Member_bean funcGetMember(string email, string question, string answer)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                string sql = String.Format("SELECT fdMembID FROM AW_Member WHERE fdMembEmail = '{0}' AND fdMembPwdQuestion = '{1}' AND fdMembPwdAnswer = '{2}'", email, question, answer);
                object o = db.ExecuteScalar(sql);
                if ( o!=null )
                {
                    AW_Member_bean member = new AW_Member_bean();
                    member.fdMembID = (int)o;
                    return member;
                }
                return null;
            }
        }

        /// <summary>
        /// 根据email获取会员
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public AW_Member_bean funcGetMember(string email)
        {
            AW_Member_bean member = new AW_Member_bean();
            using (AW_Member_dao dao = new AW_Member_dao())
            {
                dao.propWhere = "fdMembEmail = '" + email + "'";
                DataSet ds = dao.funcCommon();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    member.funcFromDataRow(ds.Tables[0].Rows[0]);
                }
                else
                {
                    member = null;
                }
            }
            return member;
        }
	}
}