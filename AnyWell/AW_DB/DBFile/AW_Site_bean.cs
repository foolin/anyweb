using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Site_bean : Bean_Base
	{
		private int _fdSiteID = 0;
		 /// <summary>
		 /// 站点编号
		 /// </summary>
		public int fdSiteID
		{
			get{return _fdSiteID;}
			set{_fdSiteID = value;}
		}
		private string _fdSiteName = "";
		 /// <summary>
		 /// 站点名称 100 nvarchar
		 /// </summary>
		public string fdSiteName
		{
			get{return _fdSiteName;}
			set{_fdSiteName = value;}
		}
		private string _fdSiteDesc = "";
		 /// <summary>
		 /// 站点描述 400 nvarchar
		 /// </summary>
		public string fdSiteDesc
		{
			get{return _fdSiteDesc;}
			set{_fdSiteDesc = value;}
		}
		private int _fdSiteSort = 0;
		 /// <summary>
		 /// 站点排序
		 /// </summary>
		public int fdSiteSort
		{
			get{return _fdSiteSort;}
			set{_fdSiteSort = value;}
		}
		private DateTime _fdSiteCreateAt = DateTime.Now;
		 /// <summary>
		 /// fdSiteCreateAt
		 /// </summary>
		public DateTime fdSiteCreateAt
		{
			get{return _fdSiteCreateAt;}
			set{_fdSiteCreateAt = value;}
		}
		private int _fdSiteIsDel = 0;
		 /// <summary>
		 /// 是否删除
		 /// </summary>
		public int fdSiteIsDel
		{
			get{return _fdSiteIsDel;}
			set{_fdSiteIsDel = value;}
		}
		private string _fdSiteUrl = "";
		 /// <summary>
		 /// 站点访问域名 100 nvarchar
		 /// </summary>
		public string fdSiteUrl
		{
			get{return _fdSiteUrl;}
			set{_fdSiteUrl = value;}
		}
		private string _fdSitePath = "";
		 /// <summary>
		 /// 站点目录 50 varchar
		 /// </summary>
		public string fdSitePath
		{
			get{return _fdSitePath;}
			set{_fdSitePath = value;}
		}
		private int _fdSiteIndexTemplateID = 0;
		 /// <summary>
		 /// 站点首页模板编号
		 /// </summary>
		public int fdSiteIndexTemplateID
		{
			get{return _fdSiteIndexTemplateID;}
			set{_fdSiteIndexTemplateID = value;}
		}
		private int _fdSiteContentTemplateID = 0;
		 /// <summary>
		 /// 站点内容页模板编号
		 /// </summary>
		public int fdSiteContentTemplateID
		{
			get{return _fdSiteContentTemplateID;}
			set{_fdSiteContentTemplateID = value;}
		}
		private int _fdSiteListTemplateID = 0;
		 /// <summary>
		 /// 站点列表模板编号
		 /// </summary>
		public int fdSiteListTemplateID
		{
			get{return _fdSiteListTemplateID;}
			set{_fdSiteListTemplateID = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Site_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Site_bean funcGetByID(string id)
        {
            AW_Site_bean bean = new AW_Site_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Site_bean funcGetByID(int id)
        {
            AW_Site_bean bean = new AW_Site_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Site_bean funcGetByID(string id, string columns)
        {
            AW_Site_bean bean = new AW_Site_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Site_bean funcGetByID(int id, string columns)
        {
            AW_Site_bean bean = new AW_Site_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
