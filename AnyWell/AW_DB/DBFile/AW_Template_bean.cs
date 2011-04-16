﻿using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Template_bean : Bean_Base
	{
		private int _fdTempID = 0;
		 /// <summary>
		 /// 模板编号
		 /// </summary>
		public int fdTempID
		{
			get{return _fdTempID;}
			set{_fdTempID = value;}
		}
		private int _fdTempSiteID = 0;
		 /// <summary>
		 /// 站点编号
		 /// </summary>
		public int fdTempSiteID
		{
			get{return _fdTempSiteID;}
			set{_fdTempSiteID = value;}
		}
		private string _fdTempName = "";
		 /// <summary>
		 /// 模板名称 100 nvarchar
		 /// </summary>
		public string fdTempName
		{
			get{return _fdTempName;}
			set{_fdTempName = value;}
		}
		private int _fdTempType = 0;
		 /// <summary>
        /// 模板类型：4首页,1栏目,2内容,3嵌套
		 /// </summary>
		public int fdTempType
		{
			get{return _fdTempType;}
			set{_fdTempType = value;}
		}
		private DateTime _fdTempCreateAt = DateTime.Now;
		 /// <summary>
		 /// 创建时间
		 /// </summary>
		public DateTime fdTempCreateAt
		{
			get{return _fdTempCreateAt;}
			set{_fdTempCreateAt = value;}
		}
		private string _fdTempContent = "";
		 /// <summary>
		 /// 模板内容
		 /// </summary>
		public string fdTempContent
		{
			get{return _fdTempContent;}
			set{_fdTempContent = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Template_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Template_bean funcGetByID(string id)
        {
            AW_Template_bean bean = new AW_Template_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Template_bean funcGetByID(int id)
        {
            AW_Template_bean bean = new AW_Template_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Template_bean funcGetByID(string id, string columns)
        {
            AW_Template_bean bean = new AW_Template_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Template_bean funcGetByID(int id, string columns)
        {
            AW_Template_bean bean = new AW_Template_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
