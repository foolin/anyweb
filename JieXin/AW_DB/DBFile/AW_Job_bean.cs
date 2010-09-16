﻿using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Job_bean : Bean_Base
	{
		private int _fdJobID = 0;
		 /// <summary>
		 /// 职能编号
		 /// </summary>
		public int fdJobID
		{
			get{return _fdJobID;}
			set{_fdJobID = value;}
		}
		private string _fdJobName = "";
		 /// <summary>
		 /// 职能名称 100 nvarchar
		 /// </summary>
		public string fdJobName
		{
			get{return _fdJobName;}
			set{_fdJobName = value;}
		}
		private int _fdJobParent = 0;
		 /// <summary>
		 /// 父级编号
		 /// </summary>
		public int fdJobParent
		{
			get{return _fdJobParent;}
			set{_fdJobParent = value;}
		}
		private int _fdJobOrder = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdJobOrder
		{
			get{return _fdJobOrder;}
			set{_fdJobOrder = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Job_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Job_bean funcGetByID(string id)
        {
            AW_Job_bean bean = new AW_Job_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Job_bean funcGetByID(int id)
        {
            AW_Job_bean bean = new AW_Job_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Job_bean funcGetByID(string id, string columns)
        {
            AW_Job_bean bean = new AW_Job_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Job_bean funcGetByID(int id, string columns)
        {
            AW_Job_bean bean = new AW_Job_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
