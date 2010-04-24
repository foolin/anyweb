using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Relation_bean : Bean_Base
	{
		private int _fdRelaID = 0;
		 /// <summary>
		 /// 关联编号
		 /// </summary>
		public int fdRelaID
		{
			get{return _fdRelaID;}
			set{_fdRelaID = value;}
		}
		private int _fdRelaColuID = 0;
		 /// <summary>
		 /// 栏目编号
		 /// </summary>
		public int fdRelaColuID
		{
			get{return _fdRelaColuID;}
			set{_fdRelaColuID = value;}
		}
		private string _fdRelaTitle = "";
		 /// <summary>
		 /// 标题 400 nvarchar
		 /// </summary>
		public string fdRelaTitle
		{
			get{return _fdRelaTitle;}
			set{_fdRelaTitle = value;}
		}
		private string _fdRelaLink = "";
		 /// <summary>
		 /// 链接地址 400 varchar
		 /// </summary>
		public string fdRelaLink
		{
			get{return _fdRelaLink;}
			set{_fdRelaLink = value;}
		}
		private int _fdRelaSort = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdRelaSort
		{
			get{return _fdRelaSort;}
			set{_fdRelaSort = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Relation_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Relation_bean funcGetByID(string id)
        {
            AW_Relation_bean bean = new AW_Relation_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Relation_bean funcGetByID(int id)
        {
            AW_Relation_bean bean = new AW_Relation_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Relation_bean funcGetByID(string id, string columns)
        {
            AW_Relation_bean bean = new AW_Relation_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Relation_bean funcGetByID(int id, string columns)
        {
            AW_Relation_bean bean = new AW_Relation_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
