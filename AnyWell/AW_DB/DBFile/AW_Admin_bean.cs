using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Admin_bean : Bean_Base
	{
		private int _fdAdmiID = 0;
		 /// <summary>
		 /// 管理员编号
		 /// </summary>
		public int fdAdmiID
		{
			get{return _fdAdmiID;}
			set{_fdAdmiID = value;}
		}
		private string _fdAdmiAccount = "";
		 /// <summary>
		 /// 管理员帐号 50 nvarchar
		 /// </summary>
		public string fdAdmiAccount
		{
			get{return _fdAdmiAccount;}
			set{_fdAdmiAccount = value;}
		}
		private string _fdAdmiPwd = "";
		 /// <summary>
		 /// 管理员密码 25 varchar
		 /// </summary>
		public string fdAdmiPwd
		{
			get{return _fdAdmiPwd;}
			set{_fdAdmiPwd = value;}
		}
		private string _fdAdmiName = "";
		 /// <summary>
		 /// 管理员名称 50 nvarchar
		 /// </summary>
		public string fdAdmiName
		{
			get{return _fdAdmiName;}
			set{_fdAdmiName = value;}
		}
		private string _fdAdmiEmail = "";
		 /// <summary>
		 /// 邮箱 50 varchar
		 /// </summary>
		public string fdAdmiEmail
		{
			get{return _fdAdmiEmail;}
			set{_fdAdmiEmail = value;}
		}
		private string _fdAdmiQQ = "";
		 /// <summary>
		 /// QQ 7 varchar
		 /// </summary>
		public string fdAdmiQQ
		{
			get{return _fdAdmiQQ;}
			set{_fdAdmiQQ = value;}
		}
		private string _fdAdmiMSN = "";
		 /// <summary>
		 /// MSN 50 varchar
		 /// </summary>
		public string fdAdmiMSN
		{
			get{return _fdAdmiMSN;}
			set{_fdAdmiMSN = value;}
		}
		private DateTime _fdAdmiLoginAt = DateTime.Now;
		 /// <summary>
		 /// 登录时间
		 /// </summary>
		public DateTime fdAdmiLoginAt
		{
			get{return _fdAdmiLoginAt;}
			set{_fdAdmiLoginAt = value;}
		}
		private string _fdAdmiLoginIP = "";
		 /// <summary>
		 /// 登录IP 7 varchar
		 /// </summary>
		public string fdAdmiLoginIP
		{
			get{return _fdAdmiLoginIP;}
			set{_fdAdmiLoginIP = value;}
		}
		private DateTime _fdAdmiCreateAt = DateTime.Now;
		 /// <summary>
		 /// 创建时间
		 /// </summary>
		public DateTime fdAdmiCreateAt
		{
			get{return _fdAdmiCreateAt;}
			set{_fdAdmiCreateAt = value;}
		}
        private int _fdAdmiStatus = 0;
        /// <summary>
        /// 用户状态(0正常1锁定)
        /// </summary>
        public int fdAdmiStatus
        {
            get{return _fdAdmiStatus;}
            set{_fdAdmiStatus = value;}
        }
		private int _fdAdmiLevel = 0;
		 /// <summary>
		 /// 用户级别：1超管 2普通用户
		 /// </summary>
		public int fdAdmiLevel
		{
			get{return _fdAdmiLevel;}
			set{_fdAdmiLevel = value;}
		}
		private string _fdAdmiPurview = "";
		 /// <summary>
		 /// 用户权限 500 varchar
		 /// </summary>
		public string fdAdmiPurview
		{
			get{return _fdAdmiPurview;}
			set{_fdAdmiPurview = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Admin_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Admin_bean funcGetByID(string id)
        {
            AW_Admin_bean bean = new AW_Admin_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Admin_bean funcGetByID(int id)
        {
            AW_Admin_bean bean = new AW_Admin_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Admin_bean funcGetByID(string id, string columns)
        {
            AW_Admin_bean bean = new AW_Admin_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Admin_bean funcGetByID(int id, string columns)
        {
            AW_Admin_bean bean = new AW_Admin_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
