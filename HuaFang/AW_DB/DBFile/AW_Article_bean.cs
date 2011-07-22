using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Article_bean : Bean_Base
	{
		private int _fdArtiID = 0;
		 /// <summary>
		 /// 文章编号
		 /// </summary>
		public int fdArtiID
		{
			get{return _fdArtiID;}
			set{_fdArtiID = value;}
		}
		private int _fdArtiColumnID = 0;
		 /// <summary>
		 /// 所属栏目编号
		 /// </summary>
		public int fdArtiColumnID
		{
			get{return _fdArtiColumnID;}
			set{_fdArtiColumnID = value;}
		}
		private int _fdArtiType = 0;
		 /// <summary>
		 /// 文章类型(0普通文章1图片文章2专题文章)
		 /// </summary>
		public int fdArtiType
		{
			get{return _fdArtiType;}
			set{_fdArtiType = value;}
		}
		private string _fdArtiTitle = "";
		 /// <summary>
		 /// 文章标题 100 nvarchar
		 /// </summary>
		public string fdArtiTitle
		{
			get{return _fdArtiTitle;}
			set{_fdArtiTitle = value;}
		}
		private string _fdArtiPic = "";
		 /// <summary>
		 /// 文章图片 100 nvarchar
		 /// </summary>
		public string fdArtiPic
		{
			get{return _fdArtiPic;}
			set{_fdArtiPic = value;}
		}
		private string _fdArtiContent = "";
		 /// <summary>
		 /// 文章内容
		 /// </summary>
		public string fdArtiContent
		{
			get{return _fdArtiContent;}
			set{_fdArtiContent = value;}
		}
		private string _fdArtiDesc = "";
		 /// <summary>
		 /// 文章摘要 1000 nvarchar
		 /// </summary>
		public string fdArtiDesc
		{
			get{return _fdArtiDesc;}
			set{_fdArtiDesc = value;}
		}
		private int _fdArtiPicDesc = 0;
		 /// <summary>
		 /// 使用文章描述(0:否1:是)
		 /// </summary>
		public int fdArtiPicDesc
		{
			get{return _fdArtiPicDesc;}
			set{_fdArtiPicDesc = value;}
		}
		private int _fdArtiCategory = 0;
		 /// <summary>
		 /// 产品类别(1男装2高级成衣3高级定制)
		 /// </summary>
		public int fdArtiCategory
		{
			get{return _fdArtiCategory;}
			set{_fdArtiCategory = value;}
		}
		private int _fdArtiCity = 0;
		 /// <summary>
		 /// 城市(1巴黎2米兰3伦敦4纽约)
		 /// </summary>
		public int fdArtiCity
		{
			get{return _fdArtiCity;}
			set{_fdArtiCity = value;}
		}
		private int _fdArtiRecommend = 0;
		 /// <summary>
		 /// 是否推荐(0否1是)
		 /// </summary>
		public int fdArtiRecommend
		{
			get{return _fdArtiRecommend;}
			set{_fdArtiRecommend = value;}
		}
		private string _fdArtiFlashPath = "";
		 /// <summary>
		 /// 视频 50 varchar
		 /// </summary>
		public string fdArtiFlashPath
		{
			get{return _fdArtiFlashPath;}
			set{_fdArtiFlashPath = value;}
		}
		private string _fdArtiFlashDesc = "";
		 /// <summary>
		 /// 视频描述 400 nvarchar
		 /// </summary>
		public string fdArtiFlashDesc
		{
			get{return _fdArtiFlashDesc;}
			set{_fdArtiFlashDesc = value;}
		}
		private DateTime _fdArtiCreateAt = DateTime.Now;
		 /// <summary>
		 /// 创建时间
		 /// </summary>
		public DateTime fdArtiCreateAt
		{
			get{return _fdArtiCreateAt;}
			set{_fdArtiCreateAt = value;}
		}
		private int _fdArtiSort = 0;
		 /// <summary>
		 /// 文章排序
		 /// </summary>
		public int fdArtiSort
		{
			get{return _fdArtiSort;}
			set{_fdArtiSort = value;}
		}
		private int _fdArtiClick = 0;
		 /// <summary>
		 /// 文章点击数
		 /// </summary>
		public int fdArtiClick
		{
			get{return _fdArtiClick;}
			set{_fdArtiClick = value;}
		}
        private string _fdArtiFrom = "";
        /// <summary>
        /// 来源
        /// </summary>
        public string fdArtiFrom
        {
            get{return _fdArtiFrom;}
            set{_fdArtiFrom = value;}
        }
        private string _fdArtiAuthor = "";
        /// <summary>
        /// 作者
        /// </summary>
        public string fdArtiAuthor
        {
            get{return _fdArtiAuthor;}
            set{_fdArtiAuthor = value;}
        }


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Article_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Article_bean funcGetByID(string id)
        {
            AW_Article_bean bean = new AW_Article_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Article_bean funcGetByID(int id)
        {
            AW_Article_bean bean = new AW_Article_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Article_bean funcGetByID(string id, string columns)
        {
            AW_Article_bean bean = new AW_Article_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Article_bean funcGetByID(int id, string columns)
        {
            AW_Article_bean bean = new AW_Article_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
