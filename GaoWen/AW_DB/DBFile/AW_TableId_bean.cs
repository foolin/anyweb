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
	public partial class AW_TableId_bean : Bean_Base
	{
		private string _fdTableName = "";
		/// <summary>
		/// 表名 50 varchar
		/// </summary>
		public string fdTableName
		{
			get{return _fdTableName;}
			set{_fdTableName = value;}
		}

		private int _fdNextID = 0;
		/// <summary>
		/// 表主键值
		/// </summary>
		public int fdNextID
		{
			get{return _fdNextID;}
			set{_fdNextID = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_TableId_dao(); 
				}
				return _dao;
			}
        }

        public static AW_TableId_bean funcGetByID(string id)
        {
            AW_TableId_bean bean = new AW_TableId_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_TableId_bean funcGetByID(int id)
        {
            AW_TableId_bean bean = new AW_TableId_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_TableId_bean funcGetByID(string id, string columns)
        {
            AW_TableId_bean bean = new AW_TableId_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_TableId_bean funcGetByID(int id, string columns)
        {
            AW_TableId_bean bean = new AW_TableId_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
