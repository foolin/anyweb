using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_News_bean : Bean_Base
	{
		private int _fdNewsID = 0;
		/// <summary>
		/// 新闻编号
		/// </summary>
		public int fdNewsID
		{
			get{return _fdNewsID;}
			set{_fdNewsID = value;}
		}

		private int _fdNewsColumnID = 0;
		/// <summary>
		/// 所属栏目编号
		/// </summary>
		public int fdNewsColumnID
		{
			get{return _fdNewsColumnID;}
			set{_fdNewsColumnID = value;}
		}

		private string _fdNewsTitle = "";
		/// <summary>
		/// 新闻标题 200 nvarchar
		/// </summary>
		public string fdNewsTitle
		{
			get{return _fdNewsTitle;}
			set{_fdNewsTitle = value;}
		}

		private string _fdNewsContent = "";
		/// <summary>
		/// 新闻内容 16 ntext
		/// </summary>
		public string fdNewsContent
		{
			get{return _fdNewsContent;}
			set{_fdNewsContent = value;}
		}

		private DateTime _fdNewsCreateAt = DateTime.Now;
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime fdNewsCreateAt
		{
			get{return _fdNewsCreateAt;}
			set{_fdNewsCreateAt = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_News_dao(); 
				}
				return _dao;
			}
        }

        public static AW_News_bean funcGetByID(string id)
        {
            AW_News_bean bean = new AW_News_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_News_bean funcGetByID(int id)
        {
            AW_News_bean bean = new AW_News_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_News_bean funcGetByID(string id, string columns)
        {
            AW_News_bean bean = new AW_News_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_News_bean funcGetByID(int id, string columns)
        {
            AW_News_bean bean = new AW_News_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
