using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Navigation_bean : Bean_Base
	{
		private int _fdNaviID = 0;
		 /// <summary>
		 /// 导航栏编号
		 /// </summary>
		public int fdNaviID
		{
			get{return _fdNaviID;}
			set{_fdNaviID = value;}
		}
		private int _fdNaviItemID = 0;
		 /// <summary>
		 /// 关联编号
		 /// </summary>
		public int fdNaviItemID
		{
			get{return _fdNaviItemID;}
			set{_fdNaviItemID = value;}
		}
		private string _fdNaviTitle = "";
		 /// <summary>
		 /// 导航栏标题 200 nvarchar
		 /// </summary>
		public string fdNaviTitle
		{
			get{return _fdNaviTitle;}
			set{_fdNaviTitle = value;}
		}
		private string _fdNaviLink = "";
		 /// <summary>
		 /// 导航栏链接 200 varchar
		 /// </summary>
		public string fdNaviLink
		{
			get{return _fdNaviLink;}
			set{_fdNaviLink = value;}
		}
		private int _fdNaviType = 0;
		 /// <summary>
		 /// 类型(1文章栏目2招聘栏目3自定义链接)
		 /// </summary>
		public int fdNaviType
		{
			get{return _fdNaviType;}
			set{_fdNaviType = value;}
		}
		private int _fdNaviParentID = 0;
		 /// <summary>
		 /// 父级编号
		 /// </summary>
		public int fdNaviParentID
		{
			get{return _fdNaviParentID;}
			set{_fdNaviParentID = value;}
		}
		private int _fdNaviSort = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdNaviSort
		{
			get{return _fdNaviSort;}
			set{_fdNaviSort = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Navigation_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Navigation_bean funcGetByID(string id)
        {
            AW_Navigation_bean bean = new AW_Navigation_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Navigation_bean funcGetByID(int id)
        {
            AW_Navigation_bean bean = new AW_Navigation_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Navigation_bean funcGetByID(string id, string columns)
        {
            AW_Navigation_bean bean = new AW_Navigation_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Navigation_bean funcGetByID(int id, string columns)
        {
            AW_Navigation_bean bean = new AW_Navigation_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
