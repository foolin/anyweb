using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Log_bean : Bean_Base
	{
		private int _fdLogID = 0;
		 /// <summary>
		 /// 日志编号
		 /// </summary>
		public int fdLogID
		{
			get{return _fdLogID;}
			set{_fdLogID = value;}
		}
		private string _fdLogName = "";
		 /// <summary>
		 /// 日志名称 100 nvarchar
		 /// </summary>
		public string fdLogName
		{
			get{return _fdLogName;}
			set{_fdLogName = value;}
		}
		private string _fdLogDesc = "";
		 /// <summary>
		 /// 日志描述 400 nvarchar
		 /// </summary>
		public string fdLogDesc
		{
			get{return _fdLogDesc;}
			set{_fdLogDesc = value;}
		}
		private string _fdLogAccount = "";
		 /// <summary>
		 /// 操作帐号 100 nvarchar
		 /// </summary>
		public string fdLogAccount
		{
			get{return _fdLogAccount;}
			set{_fdLogAccount = value;}
		}
		private int _fdLogType = 0;
		 /// <summary>
		 /// 日志类型（1Login2Insert3Update4Delete）
		 /// </summary>
		public int fdLogType
		{
			get{return _fdLogType;}
			set{_fdLogType = value;}
		}
		private string _fdLogIP = "";
		 /// <summary>
		 /// 操作IP 15 varchar
		 /// </summary>
		public string fdLogIP
		{
			get{return _fdLogIP;}
			set{_fdLogIP = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Log_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Log_bean funcGetByID(string id)
        {
            AW_Log_bean bean = new AW_Log_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Log_bean funcGetByID(int id)
        {
            AW_Log_bean bean = new AW_Log_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Log_bean funcGetByID(string id, string columns)
        {
            AW_Log_bean bean = new AW_Log_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Log_bean funcGetByID(int id, string columns)
        {
            AW_Log_bean bean = new AW_Log_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
