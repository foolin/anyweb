using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_User_bean : Bean_Base
	{
		private int _fdUserID = 0;
		 /// <summary>
		 /// 用户编号
		 /// </summary>
		public int fdUserID
		{
			get{return _fdUserID;}
			set{_fdUserID = value;}
		}
		private string _fdUserAccount = "";
		 /// <summary>
		 /// 用户帐号 50 varchar
		 /// </summary>
		public string fdUserAccount
		{
			get{return _fdUserAccount;}
			set{_fdUserAccount = value;}
		}
		private string _fdUserPwd = "";
		 /// <summary>
		 /// 用户密码 50 varchar
		 /// </summary>
		public string fdUserPwd
		{
			get{return _fdUserPwd;}
			set{_fdUserPwd = value;}
		}
		private string _fdUserEmail = "";
		 /// <summary>
		 /// 用户邮箱 100 varchar
		 /// </summary>
		public string fdUserEmail
		{
			get{return _fdUserEmail;}
			set{_fdUserEmail = value;}
		}
		private int _fdUserStatus = 0;
		 /// <summary>
		 /// 用户状态：0正常1冻结2删除
		 /// </summary>
		public int fdUserStatus
		{
			get{return _fdUserStatus;}
			set{_fdUserStatus = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_User_dao(); 
				}
				return _dao;
			}
        }

        public static AW_User_bean funcGetByID(string id)
        {
            AW_User_bean bean = new AW_User_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_User_bean funcGetByID(int id)
        {
            AW_User_bean bean = new AW_User_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_User_bean funcGetByID(string id, string columns)
        {
            AW_User_bean bean = new AW_User_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_User_bean funcGetByID(int id, string columns)
        {
            AW_User_bean bean = new AW_User_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
