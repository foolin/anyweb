using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_KeyWord_bean : Bean_Base
	{
		private int _fdKeyWID = 0;
		 /// <summary>
		 /// 关键词编号
		 /// </summary>
		public int fdKeyWID
		{
			get{return _fdKeyWID;}
			set{_fdKeyWID = value;}
		}
		private string _fdKeyWName = "";
		 /// <summary>
		 /// 关键词名称 100 nvarchar
		 /// </summary>
		public string fdKeyWName
		{
			get{return _fdKeyWName;}
			set{_fdKeyWName = value;}
		}
		private DateTime _fdKeyWCreateAt = DateTime.Now;
		 /// <summary>
		 /// 创建时间
		 /// </summary>
		public DateTime fdKeyWCreateAt
		{
			get{return _fdKeyWCreateAt;}
			set{_fdKeyWCreateAt = value;}
		}
		private int _fdKeyWIsShow = 0;
		 /// <summary>
		 /// 是否显示(1显示2不显示)
		 /// </summary>
		public int fdKeyWIsShow
		{
			get{return _fdKeyWIsShow;}
			set{_fdKeyWIsShow = value;}
		}
		private int _fdKeyWSort = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdKeyWSort
		{
			get{return _fdKeyWSort;}
			set{_fdKeyWSort = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_KeyWord_dao(); 
				}
				return _dao;
			}
        }

        public static AW_KeyWord_bean funcGetByID(string id)
        {
            AW_KeyWord_bean bean = new AW_KeyWord_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_KeyWord_bean funcGetByID(int id)
        {
            AW_KeyWord_bean bean = new AW_KeyWord_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_KeyWord_bean funcGetByID(string id, string columns)
        {
            AW_KeyWord_bean bean = new AW_KeyWord_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_KeyWord_bean funcGetByID(int id, string columns)
        {
            AW_KeyWord_bean bean = new AW_KeyWord_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
