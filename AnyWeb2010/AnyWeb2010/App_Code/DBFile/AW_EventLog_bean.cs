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
	public partial class AW_EventLog_bean : Bean_Base
	{
		private int _fdEvenID = 0;
		/// <summary>
		/// 事件编号
		/// </summary>
		public int fdEvenID
		{
			get{return _fdEvenID;}
			set{_fdEvenID = value;}
		}

		private int _fdEvenAdmiID = 0;
		/// <summary>
		/// 管理员编号
		/// </summary>
		public int fdEvenAdmiID
		{
			get{return _fdEvenAdmiID;}
			set{_fdEvenAdmiID = value;}
		}

		private string _fdEvenName = "";
		/// <summary>
		/// 事件名称 100 nvarchar
		/// </summary>
		public string fdEvenName
		{
			get{return _fdEvenName;}
			set{_fdEvenName = value;}
		}

		private int _fdEventType = 0;
		/// <summary>
		/// 类型：1Insert 2Update 3Delete
		/// </summary>
		public int fdEventType
		{
			get{return _fdEventType;}
			set{_fdEventType = value;}
		}

		private string _fdEvenDescription = "";
		/// <summary>
		/// 事件描述 400 nvarchar
		/// </summary>
		public string fdEvenDescription
		{
			get{return _fdEvenDescription;}
			set{_fdEvenDescription = value;}
		}

		private DateTime _fdEvenCreateAt = DateTime.Now;
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime fdEvenCreateAt
		{
			get{return _fdEvenCreateAt;}
			set{_fdEvenCreateAt = value;}
		}

		private string _fdEvenIP = "";
		/// <summary>
		/// 操作IP 15 varchar
		/// </summary>
		public string fdEvenIP
		{
			get{return _fdEvenIP;}
			set{_fdEvenIP = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_EventLog_dao(); 
				}
				return _dao;
			}
        }

        public static AW_EventLog_bean funcGetByID(string id)
        {
            AW_EventLog_bean bean = new AW_EventLog_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_EventLog_bean funcGetByID(int id)
        {
            AW_EventLog_bean bean = new AW_EventLog_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_EventLog_bean funcGetByID(string id, string columns)
        {
            AW_EventLog_bean bean = new AW_EventLog_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_EventLog_bean funcGetByID(int id, string columns)
        {
            AW_EventLog_bean bean = new AW_EventLog_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
