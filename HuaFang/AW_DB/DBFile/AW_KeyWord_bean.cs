using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;
using AnyWell.AW_DL;

namespace AnyWell.AW_DL
{
    public partial class AW_KeyWord_bean : Bean_Base
	{
		private int _fdKeyWID = 0;
		 /// <summary>
		 /// fdKeyWID
		 /// </summary>
		public int fdKeyWID
		{
			get{return _fdKeyWID;}
			set{_fdKeyWID = value;}
		}
		private string _fdKeyWName = "";
		 /// <summary>
		 /// 搜索的关键字 100 nvarchar
		 /// </summary>
		public string fdKeyWName
		{
			get{return _fdKeyWName;}
			set{_fdKeyWName = value;}
		}
		private int _fdKeyWClickCount = 0;
		 /// <summary>
		 /// 搜索次数
		 /// </summary>
		public int fdKeyWClickCount
		{
			get{return _fdKeyWClickCount;}
			set{_fdKeyWClickCount = value;}
		}
        private DateTime _fdKeyWCreateAt = DateTime.Parse("1900-01-01");
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime fdKeyWCreateAt
        {
            get { return _fdKeyWCreateAt; }
            set { _fdKeyWCreateAt = value; }
        }
        private DateTime _fdKeyWUpdateAt = DateTime.Parse("1900-01-01");
        /// <summary>
        /// 最后一次使用时间
        /// </summary>
        public DateTime fdKeyWUpdateAt
        {
            get { return _fdKeyWUpdateAt; }
            set { _fdKeyWUpdateAt = value; }
        }
		private int _fdKeyWIsShow = 1;
		 /// <summary>
		 /// 是否显示，0不在前台显示，1显示(默认值)。
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
            get { return _fdKeyWSort; }
            set { _fdKeyWSort = value; }
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
