using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Product_bean : Bean_Base
	{
		private int _fdProdID = 0;
		 /// <summary>
		 /// 产品编号
		 /// </summary>
		public int fdProdID
		{
			get{return _fdProdID;}
			set{_fdProdID = value;}
		}
		private int _fdProdColuID = 0;
		 /// <summary>
		 /// 栏目编号
		 /// </summary>
		public int fdProdColuID
		{
			get{return _fdProdColuID;}
			set{_fdProdColuID = value;}
		}
		private int _fdProdType = 0;
		 /// <summary>
		 /// 产品类型(0普通1引用)
		 /// </summary>
		public int fdProdType
		{
			get{return _fdProdType;}
			set{_fdProdType = value;}
		}
		private string _fdProdName = "";
		 /// <summary>
		 /// 产品名称 100 nvarchar
		 /// </summary>
		public string fdProdName
		{
			get{return _fdProdName;}
			set{_fdProdName = value;}
		}
		private string _fdProdCode = "";
		 /// <summary>
		 /// 产品型号 50 nvarchar
		 /// </summary>
		public string fdProdCode
		{
			get{return _fdProdCode;}
			set{_fdProdCode = value;}
		}
		private string _fdProdImage = "";
		 /// <summary>
		 /// 产品图片 200 nvarchar
		 /// </summary>
		public string fdProdImage
		{
			get{return _fdProdImage;}
			set{_fdProdImage = value;}
		}
		private string _fdProdDescription = "";
		 /// <summary>
		 /// 产品描述 2000 nvarchar
		 /// </summary>
		public string fdProdDescription
		{
			get{return _fdProdDescription;}
			set{_fdProdDescription = value;}
		}
		private string _fdProdContent = "";
		 /// <summary>
		 /// 产品内容
		 /// </summary>
		public string fdProdContent
		{
			get{return _fdProdContent;}
			set{_fdProdContent = value;}
		}
		private int _fdProdClickCount = 0;
		 /// <summary>
		 /// 点击数
		 /// </summary>
		public int fdProdClickCount
		{
			get{return _fdProdClickCount;}
			set{_fdProdClickCount = value;}
		}
		private int _fdProdCommentCount = 0;
		 /// <summary>
		 /// 评论数
		 /// </summary>
		public int fdProdCommentCount
		{
			get{return _fdProdCommentCount;}
			set{_fdProdCommentCount = value;}
		}
		private int _fdProdIsDel = 0;
		 /// <summary>
		 /// 是否删除(0否1是)
		 /// </summary>
		public int fdProdIsDel
		{
			get{return _fdProdIsDel;}
			set{_fdProdIsDel = value;}
		}
		private DateTime _fdProdCreateAt = DateTime.Now;
		 /// <summary>
		 /// 创建时间
		 /// </summary>
		public DateTime fdProdCreateAt
		{
			get{return _fdProdCreateAt;}
			set{_fdProdCreateAt = value;}
		}
		private int _fdProdCanComment = 0;
		 /// <summary>
		 /// 可否评论(0是1否)
		 /// </summary>
		public int fdProdCanComment
		{
			get{return _fdProdCanComment;}
			set{_fdProdCanComment = value;}
		}
		private int _fdProdSort = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdProdSort
		{
			get{return _fdProdSort;}
			set{_fdProdSort = value;}
		}
		private int _fdProdSourceID = 0;
		 /// <summary>
		 /// 源产品编号(用于引用产品)
		 /// </summary>
		public int fdProdSourceID
		{
			get{return _fdProdSourceID;}
			set{_fdProdSourceID = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Product_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Product_bean funcGetByID(string id)
        {
            AW_Product_bean bean = new AW_Product_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Product_bean funcGetByID(int id)
        {
            AW_Product_bean bean = new AW_Product_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Product_bean funcGetByID(string id, string columns)
        {
            AW_Product_bean bean = new AW_Product_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Product_bean funcGetByID(int id, string columns)
        {
            AW_Product_bean bean = new AW_Product_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
