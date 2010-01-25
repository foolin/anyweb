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
	public partial class AW_FlaAW_bean : Bean_Base
	{
		private int _fdFlasID = 0;
		/// <summary>
		/// 幻灯编号
		/// </summary>
		public int fdFlasID
		{
			get{return _fdFlasID;}
			set{_fdFlasID = value;}
		}

		private string _fdFlasName = "";
		/// <summary>
		/// 名称 200 nvarchar
		/// </summary>
		public string fdFlasName
		{
			get{return _fdFlasName;}
			set{_fdFlasName = value;}
		}

		private string _fdFlasUrl = "";
		/// <summary>
		/// 链接地址 200 varchar
		/// </summary>
		public string fdFlasUrl
		{
			get{return _fdFlasUrl;}
			set{_fdFlasUrl = value;}
		}

		private string _fdFlasPicture = "";
		/// <summary>
		/// 图片 100 varchar
		/// </summary>
		public string fdFlasPicture
		{
			get{return _fdFlasPicture;}
			set{_fdFlasPicture = value;}
		}

		private int _fdFlasSort = 0;
		/// <summary>
		/// 排序
		/// </summary>
		public int fdFlasSort
		{
			get{return _fdFlasSort;}
			set{_fdFlasSort = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_FlaAW_dao(); 
				}
				return _dao;
			}
        }

        public static AW_FlaAW_bean funcGetByID(string id)
        {
            AW_FlaAW_bean bean = new AW_FlaAW_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_FlaAW_bean funcGetByID(int id)
        {
            AW_FlaAW_bean bean = new AW_FlaAW_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_FlaAW_bean funcGetByID(string id, string columns)
        {
            AW_FlaAW_bean bean = new AW_FlaAW_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_FlaAW_bean funcGetByID(int id, string columns)
        {
            AW_FlaAW_bean bean = new AW_FlaAW_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
