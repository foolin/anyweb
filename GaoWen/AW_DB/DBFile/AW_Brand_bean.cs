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
	public partial class AW_Brand_bean : Bean_Base
	{
		private int _fdBranID = 0;
		/// <summary>
		/// 品牌编号
		/// </summary>
		public int fdBranID
		{
			get{return _fdBranID;}
			set{_fdBranID = value;}
		}

		private string _fdBranName = "";
		/// <summary>
		/// 品牌名称 200 nvarchar
		/// </summary>
		public string fdBranName
		{
			get{return _fdBranName;}
			set{_fdBranName = value;}
		}

		private string _fdBranPath = "";
		/// <summary>
		/// 访问路径 50 varchar
		/// </summary>
		public string fdBranPath
		{
			get{return _fdBranPath;}
			set{_fdBranPath = value;}
		}

		private string _fdBranIntro = "";
		/// <summary>
		/// 介绍 2000 varchar
		/// </summary>
		public string fdBranIntro
		{
			get{return _fdBranIntro;}
			set{_fdBranIntro = value;}
		}

		private string _fdBranPicture = "";
		/// <summary>
		/// 品牌图片 100 varchar
		/// </summary>
		public string fdBranPicture
		{
			get{return _fdBranPicture;}
			set{_fdBranPicture = value;}
		}

		private int _fdBranParentID = 0;
		/// <summary>
		/// 父级编号
		/// </summary>
		public int fdBranParentID
		{
			get{return _fdBranParentID;}
			set{_fdBranParentID = value;}
		}

		private int _fdBranSort = 0;
		/// <summary>
		/// 品牌排序
		/// </summary>
		public int fdBranSort
		{
			get{return _fdBranSort;}
			set{_fdBranSort = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Brand_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Brand_bean funcGetByID(string id)
        {
            AW_Brand_bean bean = new AW_Brand_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Brand_bean funcGetByID(int id)
        {
            AW_Brand_bean bean = new AW_Brand_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Brand_bean funcGetByID(string id, string columns)
        {
            AW_Brand_bean bean = new AW_Brand_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Brand_bean funcGetByID(int id, string columns)
        {
            AW_Brand_bean bean = new AW_Brand_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
