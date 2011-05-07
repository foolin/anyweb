using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_SingleArticle_bean : Bean_Base
	{
		private int _fdSingID = 0;
		 /// <summary>
		 /// 单篇文档编号
		 /// </summary>
		public int fdSingID
		{
			get{return _fdSingID;}
			set{_fdSingID = value;}
		}
		private int _fdSingColuID = 0;
		 /// <summary>
		 /// 栏目编号
		 /// </summary>
		public int fdSingColuID
		{
			get{return _fdSingColuID;}
			set{_fdSingColuID = value;}
		}
		private string _fdSingTitle = "";
		 /// <summary>
		 /// 单篇文档标题 255 nvarchar
		 /// </summary>
		public string fdSingTitle
		{
			get{return _fdSingTitle;}
			set{_fdSingTitle = value;}
		}
		private string _fdSingContent = "";
		 /// <summary>
		 /// 单篇文档内容
		 /// </summary>
		public string fdSingContent
		{
			get{return _fdSingContent;}
			set{_fdSingContent = value;}
		}
		private int _fdSingClickCount = 0;
		 /// <summary>
		 /// 点击数
		 /// </summary>
		public int fdSingClickCount
		{
			get{return _fdSingClickCount;}
			set{_fdSingClickCount = value;}
		}
		private int _fdSingCommentCount = 0;
		 /// <summary>
		 /// 评论数
		 /// </summary>
		public int fdSingCommentCount
		{
			get{return _fdSingCommentCount;}
			set{_fdSingCommentCount = value;}
		}
        private int _fdSingCanComment = 0;
        /// <summary>
        /// 可否评论(0是1否)
        /// </summary>
        public int fdSingCanComment
        {
            get{ return _fdSingCanComment;}
            set{_fdSingCanComment = value;}
        }


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_SingleArticle_dao(); 
				}
				return _dao;
			}
        }

        public static AW_SingleArticle_bean funcGetByID(string id)
        {
            AW_SingleArticle_bean bean = new AW_SingleArticle_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_SingleArticle_bean funcGetByID(int id)
        {
            AW_SingleArticle_bean bean = new AW_SingleArticle_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_SingleArticle_bean funcGetByID(string id, string columns)
        {
            AW_SingleArticle_bean bean = new AW_SingleArticle_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_SingleArticle_bean funcGetByID(int id, string columns)
        {
            AW_SingleArticle_bean bean = new AW_SingleArticle_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
