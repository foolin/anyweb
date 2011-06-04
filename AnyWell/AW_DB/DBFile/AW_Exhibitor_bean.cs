using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Exhibitor_bean : Bean_Base
	{
		private int _fdExhiID = 0;
		 /// <summary>
		 /// 展商编号
		 /// </summary>
		public int fdExhiID
		{
			get{return _fdExhiID;}
			set{_fdExhiID = value;}
		}
		private int _fdExhiSiteID = 0;
		 /// <summary>
		 /// 站点编号
		 /// </summary>
		public int fdExhiSiteID
		{
			get{return _fdExhiSiteID;}
			set{_fdExhiSiteID = value;}
		}
		private string _fdExhiName = "";
		 /// <summary>
		 /// 展商名称 50 nvarchar
		 /// </summary>
		public string fdExhiName
		{
			get{return _fdExhiName;}
			set{_fdExhiName = value;}
		}
		private string _fdExhiEnName = "";
		 /// <summary>
		 /// 展商英文名称 50 varchar
		 /// </summary>
		public string fdExhiEnName
		{
			get{return _fdExhiEnName;}
			set{_fdExhiEnName = value;}
		}
		private string _fdExhiNumber = "";
		 /// <summary>
		 /// 展商号 25 varchar
		 /// </summary>
		public string fdExhiNumber
		{
			get{return _fdExhiNumber;}
			set{_fdExhiNumber = value;}
		}
		private int _fdExhiType = 0;
		 /// <summary>
		 /// 展商类型
		 /// </summary>
		public int fdExhiType
		{
			get{return _fdExhiType;}
			set{_fdExhiType = value;}
		}
		private string _fdExhiUrl = "";
		 /// <summary>
		 /// 网址 100 varchar
		 /// </summary>
		public string fdExhiUrl
		{
			get{return _fdExhiUrl;}
			set{_fdExhiUrl = value;}
		}
		private string _fdExhiDesc = "";
		 /// <summary>
		 /// 简介 50 nvarchar
		 /// </summary>
		public string fdExhiDesc
		{
			get{return _fdExhiDesc;}
			set{_fdExhiDesc = value;}
		}
		private DateTime _fdExhiCreateAt = DateTime.Now;
		 /// <summary>
		 /// 创建时间
		 /// </summary>
		public DateTime fdExhiCreateAt
		{
			get{return _fdExhiCreateAt;}
			set{_fdExhiCreateAt = value;}
		}
		private int _fdExhiSort = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdExhiSort
		{
			get{return _fdExhiSort;}
			set{_fdExhiSort = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Exhibitor_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Exhibitor_bean funcGetByID(string id)
        {
            AW_Exhibitor_bean bean = new AW_Exhibitor_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Exhibitor_bean funcGetByID(int id)
        {
            AW_Exhibitor_bean bean = new AW_Exhibitor_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Exhibitor_bean funcGetByID(string id, string columns)
        {
            AW_Exhibitor_bean bean = new AW_Exhibitor_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Exhibitor_bean funcGetByID(int id, string columns)
        {
            AW_Exhibitor_bean bean = new AW_Exhibitor_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
