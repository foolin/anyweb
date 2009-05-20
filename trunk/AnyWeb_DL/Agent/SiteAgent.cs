using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using System.Collections;
using System.Web;

namespace AnyWeb.AnyWeb_DL
{
    public class SiteAgent : DbAgent
    {
        public SiteAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="UserAcc"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int Login(string UserAcc, string Password)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteProcedure("Login",
                    this.NewParam("@UserAcc", UserAcc),
                    this.NewParam("@UserPass", Password));
            }
        }

        /// <summary>
        /// 获取站点信息
        /// </summary>
        /// <returns></returns>
        public Site GetSiteInfo()
        {
            Site site = (Site)HttpRuntime.Cache["SITE"];
            if (site != null)
            {
                return site;
            }

            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetSiteInfo");
            }
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            //站点信息
            site = new Site(ds.Tables[0].Rows[0]);

            //用户集合
            site.UserList = new ArrayList();            
            foreach (DataRow row in ds.Tables[1].Rows)
            {
                User u = new User(row);
                site.UserList.Add(u);
            }

            //导航栏
            site.NavigationList = new ArrayList();
            foreach (DataRow row in ds.Tables[2].Rows)
            {
                Navigation na = new Navigation(row);
                site.NavigationList.Add(na);
            }

            HttpRuntime.Cache.Insert("SITE", site, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));
            
            return site;
        }
    }
}
