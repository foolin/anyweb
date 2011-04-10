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
		private int _fdArtiColuID = 0;
		 /// <summary>
		 /// 栏目编号
		 /// </summary>
		public int fdArtiColuID
		{
			get{return _fdArtiColuID;}
			set{_fdArtiColuID = value;}
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
		private int _fdArtiType = 0;
		 /// <summary>
		 /// 文章类型(0HTML1文本2链接3文件)
		 /// </summary>
		public int fdArtiType
		{
			get{return _fdArtiType;}
			set{_fdArtiType = value;}
		}
		private string _fdArtiLink = "";
		 /// <summary>
		 /// 链接,用于链接/文件类型的文章 250 varchar
		 /// </summary>
		public string fdArtiLink
		{
			get{return _fdArtiLink;}
			set{_fdArtiLink = value;}
		}
		private string _fdArtiTitle = "";
		 /// <summary>
		 /// 文章标题 255 nvarchar
		 /// </summary>
		public string fdArtiTitle
		{
			get{return _fdArtiTitle;}
			set{_fdArtiTitle = value;}
		}
		private string _fdArtiSubTitle = "";
		 /// <summary>
		 /// 副标题 100 nvarchar
		 /// </summary>
		public string fdArtiSubTitle
		{
			get{return _fdArtiSubTitle;}
			set{_fdArtiSubTitle = value;}
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
		private string _fdArtiDescription = "";
		 /// <summary>
		 /// 文章摘要 2000 nvarchar
		 /// </summary>
		public string fdArtiDescription
		{
			get{return _fdArtiDescription;}
			set{_fdArtiDescription = value;}
		}
		private int _fdArtiClickCount = 0;
		 /// <summary>
		 /// 点击数
		 /// </summary>
		public int fdArtiClickCount
		{
			get{return _fdArtiClickCount;}
			set{_fdArtiClickCount = value;}
		}
		private int _fdArtiCommentCount = 0;
		 /// <summary>
		 /// 评论数
		 /// </summary>
		public int fdArtiCommentCount
		{
			get{return _fdArtiCommentCount;}
			set{_fdArtiCommentCount = value;}
		}
		private int _fdArtiIsAuthorship = 0;
		 /// <summary>
		 /// 是否原创(0原创1转载)
		 /// </summary>
		public int fdArtiIsAuthorship
		{
			get{return _fdArtiIsAuthorship;}
			set{_fdArtiIsAuthorship = value;}
		}
		private string _fdArtiFrom = "";
		 /// <summary>
		 /// 文章来源 50 nvarchar
		 /// </summary>
		public string fdArtiFrom
		{
			get{return _fdArtiFrom;}
			set{_fdArtiFrom = value;}
		}
		private string _fdArtiFromLink = "";
		 /// <summary>
		 /// 来源链接 127 varchar
		 /// </summary>
		public string fdArtiFromLink
		{
			get{return _fdArtiFromLink;}
			set{_fdArtiFromLink = value;}
		}
		private string _fdArtiFromAuthor = "";
		 /// <summary>
		 /// 作者 50 nvarchar
		 /// </summary>
		public string fdArtiFromAuthor
		{
			get{return _fdArtiFromAuthor;}
			set{_fdArtiFromAuthor = value;}
		}
		private int _fdArtiCanComment = 0;
		 /// <summary>
		 /// 可否评论(0是1否)
		 /// </summary>
		public int fdArtiCanComment
		{
			get{return _fdArtiCanComment;}
			set{_fdArtiCanComment = value;}
		}
		private int _fdArtiIsDel = 0;
		 /// <summary>
		 /// 是否删除(0否1是)
		 /// </summary>
		public int fdArtiIsDel
		{
			get{return _fdArtiIsDel;}
			set{_fdArtiIsDel = value;}
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
		private string _fdArtiImage = "";
		 /// <summary>
		 /// 文章图片 100 varchar
		 /// </summary>
		public string fdArtiImage
		{
			get{return _fdArtiImage;}
			set{_fdArtiImage = value;}
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
