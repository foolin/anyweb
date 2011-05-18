using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;
using Studio.Web;

namespace AnyWell.AW_DL
{
	public partial class AW_Admin_dao
	{
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int funcLogin(string loginId, string password)
        {
            this.propWhere = "fdAdmiAccount='" + loginId + "' AND fdAdmiPwd='" + Studio.Security.Secure.Md5(password) + "'";
            List<AW_Admin_bean> beans = this.funcGetList();
            if (beans.Count == 0)
                return 0;

            AW_Admin_bean bean = beans[0];

            HttpCookie co = new HttpCookie("ADMINUSER");
            co["ID"] = HttpUtility.UrlEncode(bean.fdAdmiID.ToString());
            co["NAME"] = HttpUtility.UrlEncodeUnicode(bean.fdAdmiName);
            co["ACCOUNT"] = HttpUtility.UrlEncodeUnicode(bean.fdAdmiAccount);
            HttpContext.Current.Response.SetCookie(co);

            bean.fdAdmiLoginIP = HttpContext.Current.Request.UserHostAddress;
            bean.fdAdmiLoginAt = DateTime.Now;
            funcUpdate(bean);

            return bean.fdAdmiID;
        }

        /// <summary>
        /// 获取会话信息
        /// </summary>
        /// <returns></returns>
        public AW_Admin_bean funcGetAdminFromCookie()
        {
            HttpCookie co = HttpContext.Current.Request.Cookies["ADMINUSER"];
            if (co == null) 
                return null;
            if (co["ID"] == "" || !WebAgent.IsInt32(co["ID"]))
                return null;

            foreach (AW_Admin_bean admin in this.funcGetAdmins())
            {
                if (admin.fdAdmiID.ToString() == co["ID"])
                    return admin;
            }
            return null;
        }

        /// <summary>
        /// 获取所有管理员(缓存)
        /// </summary>
        /// <returns></returns>
        public List<AW_Admin_bean> funcGetAdmins()
        {
            List<AW_Admin_bean> admins = (List<AW_Admin_bean>)HttpRuntime.Cache["PageAdmins"];
            if (admins != null) return admins;
            admins = this.funcGetList();
            foreach (AW_Admin_bean admin in admins)
            {
                admin.funcSetPurviews();
            }
            HttpRuntime.Cache.Insert("PageAdmins", admins, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
            return admins;
        }

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<AW_Admin_bean> funcGetAdminList( string ids )
        {
            this.propSelect = "fdAdmiID,fdAdmiAccount";
            this.propWhere = string.Format( "fdAdmiID IN ({0})", ids );
            this.propOrder = "ORDER BY fdAdmiID ASC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取管理员列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Admin_bean> funcGetAdminList( int pageIndex, int pageSize, out int recordCount )
        {
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            List<AW_Admin_bean> list = this.funcGetList();
            recordCount = this.propCount;
            for( int i = 0; i < list.Count; i++ )
            {
                list[ i ].fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
            }
            return list;
        }

        /// <summary>
        /// 检查帐号是否存在
        /// </summary>
        /// <param name="account"></param>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public bool funcCheckAccountExists( string account, int adminId )
        {
            string sql = string.Format( "SELECT fdAdmiID FROM AW_Admin WHERE fdAdmiAccount='{0}'", account );
            if( adminId > 0 )
            {
                sql += " AND fdAdmiID<>" + adminId;
            }
            return this.funcGet( sql ).Tables[ 0 ].Rows.Count > 0;
        }

        /// <summary>
        /// 获取某个管理员信息
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public AW_Admin_bean funcGetAdminInfo(int adminId)
        {
            foreach (AW_Admin_bean admin in this.funcGetAdmins())
                if (admin.fdAdmiID == adminId)
                    return admin;
            return null;
        }

        /// <summary>
        /// 锁定用户
        /// </summary>
        /// <param name="ids"></param>
        public void funcLockAdmin( string ids )
        {
            string sql = string.Format( "UPDATE AW_Admin SET fdAdmiStatus=1 WHERE fdAdmiID IN ({0})", ids );
            this.funcExecute( sql );
        }

        /// <summary>
        /// 锁定用户
        /// </summary>
        /// <param name="ids"></param>
        public void funcUnlockAdmin( string ids )
        {
            string sql = string.Format( "UPDATE AW_Admin SET fdAdmiStatus=0 WHERE fdAdmiID IN ({0})", ids );
            this.funcExecute( sql );
        }

        public override int funcInsert(Bean_Base aBean)
        {
            int count = base.funcInsert(aBean);
            HttpRuntime.Cache.Remove("PageAdmins");
            return count;
        }

        public override int funcUpdate(Bean_Base aBean)
        {
            int count = base.funcUpdate(aBean);
            HttpRuntime.Cache.Remove("PageAdmins");
            return count;
        }

        public override int funcDelete(int id)
        {
            int count = base.funcDelete(id);
            HttpRuntime.Cache.Remove("PageAdmins");
            return count;
        }

        public override int funcDeletes( string aIDList )
        {
            int count = base.funcDeletes( aIDList );
            HttpRuntime.Cache.Remove( "PageAdmins" );
            return count;
        }

        /// <summary>
        /// 注销
        /// </summary>
        public void funcLogout()
        {
            HttpContext.Current.Response.Cookies["ADMINUSER"].Expires = DateTime.Now.AddMinutes(-1);
        }
	}
}
