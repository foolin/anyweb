using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Company_Industry_bean : Bean_Base
	{
		private int _fdCoInCompID = 0;
		 /// <summary>
		 /// 公司编号
		 /// </summary>
		public int fdCoInCompID
		{
			get{return _fdCoInCompID;}
			set{_fdCoInCompID = value;}
		}
		private int _fdCoInInduID = 0;
		 /// <summary>
		 /// 行业编号
		 /// </summary>
		public int fdCoInInduID
		{
			get{return _fdCoInInduID;}
			set{_fdCoInInduID = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Company_Industry_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Company_Industry_bean funcGetByID(string id)
        {
            AW_Company_Industry_bean bean = new AW_Company_Industry_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Company_Industry_bean funcGetByID(int id)
        {
            AW_Company_Industry_bean bean = new AW_Company_Industry_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Company_Industry_bean funcGetByID(string id, string columns)
        {
            AW_Company_Industry_bean bean = new AW_Company_Industry_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Company_Industry_bean funcGetByID(int id, string columns)
        {
            AW_Company_Industry_bean bean = new AW_Company_Industry_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
