using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_SiteInfo_bean : Bean_Base
	{
		private int _fdSiInID = 0;
		 /// <summary>
		 /// 编号
		 /// </summary>
		public int fdSiInID
		{
			get{return _fdSiInID;}
			set{_fdSiInID = value;}
		}
		private string _fdSiInTitle = "";
		 /// <summary>
		 /// 标题 200 nvarchar
		 /// </summary>
		public string fdSiInTitle
		{
			get{return _fdSiInTitle;}
			set{_fdSiInTitle = value;}
		}
		private string _fdSiInContent = "";
		 /// <summary>
		 /// 内容
		 /// </summary>
		public string fdSiInContent
		{
			get{return _fdSiInContent;}
			set{_fdSiInContent = value;}
		}
		private int _fdSiInSort = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdSiInSort
		{
			get{return _fdSiInSort;}
			set{_fdSiInSort = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_SiteInfo_dao(); 
				}
				return _dao;
			}
        }

        public static AW_SiteInfo_bean funcGetByID(string id)
        {
            AW_SiteInfo_bean bean = new AW_SiteInfo_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_SiteInfo_bean funcGetByID(int id)
        {
            AW_SiteInfo_bean bean = new AW_SiteInfo_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_SiteInfo_bean funcGetByID(string id, string columns)
        {
            AW_SiteInfo_bean bean = new AW_SiteInfo_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_SiteInfo_bean funcGetByID(int id, string columns)
        {
            AW_SiteInfo_bean bean = new AW_SiteInfo_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
