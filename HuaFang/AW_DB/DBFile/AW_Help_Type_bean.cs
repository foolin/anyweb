using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Help_Type_bean : Bean_Base
	{
		private int _fdTypeID = 0;
		/// <summary>
		/// 帮助类别
		/// </summary>
		public int fdTypeID
		{
			get{return _fdTypeID;}
			set{_fdTypeID = value;}
		}

		private string _fdTypeName = "";
		/// <summary>
		/// 类别名称 200 nvarchar
		/// </summary>
		public string fdTypeName
		{
			get{return _fdTypeName;}
			set{_fdTypeName = value;}
		}

		private int _fdTypeSort = 0;
		/// <summary>
		/// 排序
		/// </summary>
		public int fdTypeSort
		{
			get{return _fdTypeSort;}
			set{_fdTypeSort = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Help_Type_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Help_Type_bean funcGetByID(string id)
        {
            AW_Help_Type_bean bean = new AW_Help_Type_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Help_Type_bean funcGetByID(int id)
        {
            AW_Help_Type_bean bean = new AW_Help_Type_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Help_Type_bean funcGetByID(string id, string columns)
        {
            AW_Help_Type_bean bean = new AW_Help_Type_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Help_Type_bean funcGetByID(int id, string columns)
        {
            AW_Help_Type_bean bean = new AW_Help_Type_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
