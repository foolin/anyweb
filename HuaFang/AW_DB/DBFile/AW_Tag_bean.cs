using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Tag_bean : Bean_Base
	{
		private int _fdTagID = 0;
		 /// <summary>
		 /// 标签编号
		 /// </summary>
		public int fdTagID
		{
			get{return _fdTagID;}
			set{_fdTagID = value;}
		}
		private string _fdTagName = "";
		 /// <summary>
		 /// 标签名称 100 nvarchar
		 /// </summary>
		public string fdTagName
		{
			get{return _fdTagName;}
			set{_fdTagName = value;}
		}
        private int _fdTagSort = 0;
        /// <summary>
        /// 排序
        /// </summary>
        public int fdTagSort
        {
            get{return _fdTagSort;}
            set{ _fdTagSort = value;}
        }


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Tag_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Tag_bean funcGetByID(string id)
        {
            AW_Tag_bean bean = new AW_Tag_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Tag_bean funcGetByID(int id)
        {
            AW_Tag_bean bean = new AW_Tag_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Tag_bean funcGetByID(string id, string columns)
        {
            AW_Tag_bean bean = new AW_Tag_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Tag_bean funcGetByID(int id, string columns)
        {
            AW_Tag_bean bean = new AW_Tag_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
