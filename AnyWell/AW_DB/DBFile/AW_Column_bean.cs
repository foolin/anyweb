using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Column_bean : Bean_Base
	{
		private int _fdColuID = 0;
		 /// <summary>
		 /// 栏目编号
		 /// </summary>
		public int fdColuID
		{
			get{return _fdColuID;}
			set{_fdColuID = value;}
		}
		private int _fdColuSiteID = 0;
		 /// <summary>
		 /// 站点编号
		 /// </summary>
		public int fdColuSiteID
		{
			get{return _fdColuSiteID;}
			set{_fdColuSiteID = value;}
		}
		private string _fdColuName = "";
		 /// <summary>
		 /// 栏目名称 100 nvarchar
		 /// </summary>
		public string fdColuName
		{
			get{return _fdColuName;}
			set{_fdColuName = value;}
		}
		private int _fdColuType = 0;
		 /// <summary>
        /// 栏目类型(0文章1商品2图片3单篇文章)
		 /// </summary>
		public int fdColuType
		{
			get{return _fdColuType;}
			set{_fdColuType = value;}
		}
		private int _fdColuParentID = 0;
		 /// <summary>
		 /// 父级编号
		 /// </summary>
		public int fdColuParentID
		{
			get{return _fdColuParentID;}
			set{_fdColuParentID = value;}
		}
		private string _fdColuDesc = "";
		 /// <summary>
		 /// 栏目描述 510 nvarchar
		 /// </summary>
		public string fdColuDesc
		{
			get{return _fdColuDesc;}
			set{_fdColuDesc = value;}
		}
		private string _fdColuIcon = "";
		 /// <summary>
		 /// 小图
		 /// </summary>
		public string fdColuIcon
		{
			get{return _fdColuIcon;}
			set{_fdColuIcon = value;}
		}
		private string _fdColuPict = "";
		 /// <summary>
		 /// 大图
		 /// </summary>
		public string fdColuPict
		{
			get{return _fdColuPict;}
			set{_fdColuPict = value;}
		}
		private int _fdColuSort = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdColuSort
		{
			get{return _fdColuSort;}
			set{_fdColuSort = value;}
		}
		private DateTime _fdColuCreateAt = DateTime.Now;
		 /// <summary>
		 /// 创建时间
		 /// </summary>
		public DateTime fdColuCreateAt
		{
			get{return _fdColuCreateAt;}
			set{_fdColuCreateAt = value;}
		}
		private int _fdColuIndexTemplateID = 0;
		 /// <summary>
		 /// 首页模版
		 /// </summary>
		public int fdColuIndexTemplateID
		{
			get{return _fdColuIndexTemplateID;}
			set{_fdColuIndexTemplateID = value;}
		}
		private int _fdColuContentTemplateID = 0;
		 /// <summary>
		 /// 内容页模版
		 /// </summary>
		public int fdColuContentTemplateID
		{
			get{return _fdColuContentTemplateID;}
			set{_fdColuContentTemplateID = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Column_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Column_bean funcGetByID(string id)
        {
            AW_Column_bean bean = new AW_Column_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Column_bean funcGetByID(int id)
        {
            AW_Column_bean bean = new AW_Column_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Column_bean funcGetByID(string id, string columns)
        {
            AW_Column_bean bean = new AW_Column_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Column_bean funcGetByID(int id, string columns)
        {
            AW_Column_bean bean = new AW_Column_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
