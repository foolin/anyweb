using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Link_bean : Bean_Base
	{
		private int _fdLinkID = 0;
		 /// <summary>
		 /// 链接编号
		 /// </summary>
		public int fdLinkID
		{
			get{return _fdLinkID;}
			set{_fdLinkID = value;}
		}
		private string _fdLinkName = "";
		 /// <summary>
		 /// 链接名称 100 nvarchar
		 /// </summary>
		public string fdLinkName
		{
			get{return _fdLinkName;}
			set{_fdLinkName = value;}
		}
		private string _fdLinkUrl = "";
		 /// <summary>
		 /// 链接路径 100 varchar
		 /// </summary>
		public string fdLinkUrl
		{
			get{return _fdLinkUrl;}
			set{_fdLinkUrl = value;}
		}
		private string _fdLinkPicture = "";
		 /// <summary>
		 /// 链接图片 50 varchar
		 /// </summary>
		public string fdLinkPicture
		{
			get{return _fdLinkPicture;}
			set{_fdLinkPicture = value;}
		}
		private int _fdLinkSort = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdLinkSort
		{
			get{return _fdLinkSort;}
			set{_fdLinkSort = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Link_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Link_bean funcGetByID(string id)
        {
            AW_Link_bean bean = new AW_Link_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Link_bean funcGetByID(int id)
        {
            AW_Link_bean bean = new AW_Link_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Link_bean funcGetByID(string id, string columns)
        {
            AW_Link_bean bean = new AW_Link_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Link_bean funcGetByID(int id, string columns)
        {
            AW_Link_bean bean = new AW_Link_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
