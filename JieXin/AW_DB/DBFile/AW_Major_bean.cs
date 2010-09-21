using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Major_bean : Bean_Base
	{
		private int _fdMajoID = 0;
		 /// <summary>
		 /// 专业编号
		 /// </summary>
		public int fdMajoID
		{
			get{return _fdMajoID;}
			set{_fdMajoID = value;}
		}
		private string _fdMajoName = "";
		 /// <summary>
		 /// 专业名称 100 nvarchar
		 /// </summary>
		public string fdMajoName
		{
			get{return _fdMajoName;}
			set{_fdMajoName = value;}
		}
		private int _fdMajoParent = 0;
		 /// <summary>
		 /// 父级编号
		 /// </summary>
		public int fdMajoParent
		{
			get{return _fdMajoParent;}
			set{_fdMajoParent = value;}
		}
		private int _fdMajoOrder = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdMajoOrder
		{
			get{return _fdMajoOrder;}
			set{_fdMajoOrder = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Major_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Major_bean funcGetByID(string id)
        {
            AW_Major_bean bean = new AW_Major_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Major_bean funcGetByID(int id)
        {
            AW_Major_bean bean = new AW_Major_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Major_bean funcGetByID(string id, string columns)
        {
            AW_Major_bean bean = new AW_Major_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Major_bean funcGetByID(int id, string columns)
        {
            AW_Major_bean bean = new AW_Major_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
