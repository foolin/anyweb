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
		private int _fdExhiColuID = 0;
		 /// <summary>
		 /// 栏目编号
		 /// </summary>
		public int fdExhiColuID
		{
			get{return _fdExhiColuID;}
			set{_fdExhiColuID = value;}
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
		 /// 展商号
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
		private string _fdExhiContent = "";
		 /// <summary>
		 /// 简介
		 /// </summary>
		public string fdExhiContent
		{
			get{return _fdExhiContent;}
			set{_fdExhiContent = value;}
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
		private int _fdExhiIsDel = 0;
		 /// <summary>
		 /// 是否删除(0正常1删除)
		 /// </summary>
		public int fdExhiIsDel
		{
			get{return _fdExhiIsDel;}
			set{_fdExhiIsDel = value;}
		}
		private int _fdExhiStatus = 0;
		 /// <summary>
		 /// 展商状态(0新稿1已改2已发)
		 /// </summary>
		public int fdExhiStatus
		{
			get{return _fdExhiStatus;}
			set{_fdExhiStatus = value;}
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
