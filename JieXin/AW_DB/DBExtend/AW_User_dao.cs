using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;
using Studio.Web;

namespace AnyWell.AW_DL
{
	public partial class AW_User_dao
	{
        /// <summary>
        /// 个人会员登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="save">自动登录</param>
        /// <returns></returns>
        public AW_User_bean funcLogin( string userName, string password, bool save )
        {
            this.propWhere = "fdUserAccount='" + userName + "' AND fdUserPwd='" + Studio.Security.Secure.Md5( password ) + "'";
            List<AW_User_bean> beans = this.funcGetList();
            if( beans.Count == 0 )
                return null;

            AW_User_bean bean = beans[ 0 ];

            if( bean.fdUserStatus != 0 )    //用户被冻结或删除时，不记录cookie
            {
                return bean;
            }

            HttpCookie co = new HttpCookie( "USER" );
            co[ "ID" ] = HttpUtility.UrlEncode( bean.fdUserID.ToString() );
            co[ "ACCOUNT" ] = HttpUtility.UrlEncodeUnicode( bean.fdUserAccount );
            if( save )
                co.Expires = DateTime.MaxValue;
            HttpContext.Current.Response.SetCookie( co );
            if( HttpRuntime.Cache[ "USER_" + bean.fdUserID ] == null )
            {
                HttpRuntime.Cache.Insert( "USER_" + bean.fdUserID, bean, null, DateTime.MaxValue, TimeSpan.FromMinutes( 5 ) );
            }
            return bean;
        }

        /// <summary>
        /// 获取个人会员信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public AW_User_bean funcGetUserInfo( int userID )
        {
            if( HttpRuntime.Cache[ "USER_" + userID ] != null )
            {
                return ( AW_User_bean ) HttpRuntime.Cache[ "USER_" + userID ];
            }
            AW_User_bean bean = AW_User_bean.funcGetByID( userID );
            if( bean == null )
                return null;
            HttpRuntime.Cache.Insert( "USER_" + bean.fdUserID, bean, null, DateTime.MaxValue, TimeSpan.FromMinutes( 5 ) );
            return bean;
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        public bool funcCheckAccount( string userAccount )
        {
            this.propSelect = "fdUserID";
            this.propWhere = "fdUserAccount=@fdUserAccount";
            this.funcAddParam( "@fdUserAccount", userAccount );
            DataSet ds = this.funcCommon();
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 检查邮箱是否存在
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public bool funcCheckEmail( string userEmail )
        {
            this.propSelect = "fdUserID";
            this.propWhere = "fdUserEmail=@fdUserEmail";
            this.funcAddParam( "@fdUserEmail", userEmail );
            DataSet ds = this.funcCommon();
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 获取会话信息
        /// </summary>
        /// <returns></returns>
        public AW_User_bean funcGetUserFromCookie()
        {
            HttpCookie co = HttpContext.Current.Request.Cookies["USER"];
            if (co == null)
                return null;
            if (co["ID"] == "" || !WebAgent.IsInt32(co["ID"]))
                return null;

            return this.funcGetUserInfo(int.Parse(co["ID"]));
        }
	}
}
