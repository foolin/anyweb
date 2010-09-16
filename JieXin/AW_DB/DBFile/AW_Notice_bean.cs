using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Notice_bean : Bean_Base
	{
		private int _fdNotiID = 0;
		 /// <summary>
		 /// 公告编号
		 /// </summary>
		public int fdNotiID
		{
			get{return _fdNotiID;}
			set{_fdNotiID = value;}
		}
		private string _fdNotiTitle = "";
		 /// <summary>
		 /// 公告标题 100 nvarchar
		 /// </summary>
		public string fdNotiTitle
		{
			get{return _fdNotiTitle;}
			set{_fdNotiTitle = value;}
		}
		private string _fdNotiContent = "";
		 /// <summary>
		 /// 公告内容
		 /// </summary>
		public string fdNotiContent
		{
			get{return _fdNotiContent;}
			set{_fdNotiContent = value;}
		}
		private int _fdNotiOrder = 0;
		 /// <summary>
		 /// 公告排序
		 /// </summary>
		public int fdNotiOrder
		{
			get{return _fdNotiOrder;}
			set{_fdNotiOrder = value;}
		}
		private DateTime _fdNotiCreateAt = DateTime.Now;
		 /// <summary>
		 /// 创建时间
		 /// </summary>
		public DateTime fdNotiCreateAt
		{
			get{return _fdNotiCreateAt;}
			set{_fdNotiCreateAt = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Notice_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Notice_bean funcGetByID(string id)
        {
            AW_Notice_bean bean = new AW_Notice_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Notice_bean funcGetByID(int id)
        {
            AW_Notice_bean bean = new AW_Notice_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Notice_bean funcGetByID(string id, string columns)
        {
            AW_Notice_bean bean = new AW_Notice_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Notice_bean funcGetByID(int id, string columns)
        {
            AW_Notice_bean bean = new AW_Notice_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
