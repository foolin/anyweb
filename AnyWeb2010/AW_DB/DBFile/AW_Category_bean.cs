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
	public partial class AW_Category_bean : Bean_Base
	{
		private int _fdCateID = 0;
		/// <summary>
		/// 分类编号
		/// </summary>
		public int fdCateID
		{
			get{return _fdCateID;}
			set{_fdCateID = value;}
		}

		private string _fdCateName = "";
		/// <summary>
		/// 分类名称 200 nvarchar
		/// </summary>
		public string fdCateName
		{
			get{return _fdCateName;}
			set{_fdCateName = value;}
		}

		private DateTime _fdCateCreateAt = DateTime.Now;
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime fdCateCreateAt
		{
			get{return _fdCateCreateAt;}
			set{_fdCateCreateAt = value;}
		}

		private string _fdCatePath = "";
		/// <summary>
		/// 访问路径 50 varchar
		/// </summary>
		public string fdCatePath
		{
			get{return _fdCatePath;}
			set{_fdCatePath = value;}
		}

		private int _fdCateParent = 0;
		/// <summary>
		/// 父级编号
		/// </summary>
		public int fdCateParent
		{
			get{return _fdCateParent;}
			set{_fdCateParent = value;}
		}

		private int _fdCateIsShow = 0;
		/// <summary>
		/// 是否显示
		/// </summary>
		public int fdCateIsShow
		{
			get{return _fdCateIsShow;}
			set{_fdCateIsShow = value;}
		}

		private int _fdCateSort = 0;
		/// <summary>
		/// 排序
		/// </summary>
		public int fdCateSort
		{
			get{return _fdCateSort;}
			set{_fdCateSort = value;}
		}

		private string _fdCateIDPath = "";
		/// <summary>
		/// 树状全路径 50 varchar
		/// </summary>
		public string fdCateIDPath
		{
			get{return _fdCateIDPath;}
			set{_fdCateIDPath = value;}
		}

		private int _fdCateGoods = 0;
		/// <summary>
		/// 产品数量
		/// </summary>
		public int fdCateGoods
		{
			get{return _fdCateGoods;}
			set{_fdCateGoods = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Category_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Category_bean funcGetByID(string id)
        {
            AW_Category_bean bean = new AW_Category_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Category_bean funcGetByID(int id)
        {
            AW_Category_bean bean = new AW_Category_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Category_bean funcGetByID(string id, string columns)
        {
            AW_Category_bean bean = new AW_Category_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Category_bean funcGetByID(int id, string columns)
        {
            AW_Category_bean bean = new AW_Category_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
