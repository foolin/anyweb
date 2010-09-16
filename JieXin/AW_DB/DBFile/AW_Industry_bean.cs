using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Industry_bean : Bean_Base
	{
		private int _fdInduID = 0;
		 /// <summary>
		 /// 行业编号
		 /// </summary>
		public int fdInduID
		{
			get{return _fdInduID;}
			set{_fdInduID = value;}
		}
		private string _fdInduName = "";
		 /// <summary>
		 /// 行业名称 100 nvarchar
		 /// </summary>
		public string fdInduName
		{
			get{return _fdInduName;}
			set{_fdInduName = value;}
		}
		private int _fdInduParent = 0;
		 /// <summary>
		 /// 父级编号
		 /// </summary>
		public int fdInduParent
		{
			get{return _fdInduParent;}
			set{_fdInduParent = value;}
		}
		private int _fdInduOrder = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdInduOrder
		{
			get{return _fdInduOrder;}
			set{_fdInduOrder = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Industry_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Industry_bean funcGetByID(string id)
        {
            AW_Industry_bean bean = new AW_Industry_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Industry_bean funcGetByID(int id)
        {
            AW_Industry_bean bean = new AW_Industry_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Industry_bean funcGetByID(string id, string columns)
        {
            AW_Industry_bean bean = new AW_Industry_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Industry_bean funcGetByID(int id, string columns)
        {
            AW_Industry_bean bean = new AW_Industry_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
