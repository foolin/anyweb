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

        /// <summary>
        /// 注销
        /// </summary>
        public void funcLogout()
        {
            HttpContext.Current.Response.Cookies["ADMINUSER"].Expires = DateTime.Now.AddMinutes(-1);
        }
	}
}
