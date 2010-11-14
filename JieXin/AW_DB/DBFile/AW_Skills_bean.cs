﻿using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Skills_bean : Bean_Base
	{
		private int _fdSkilID = 0;
		 /// <summary>
		 /// 技能编号
		 /// </summary>
		public int fdSkilID
		{
			get{return _fdSkilID;}
			set{_fdSkilID = value;}
		}
		private int _fdSkilResuID = 0;
		 /// <summary>
		 /// 简历编号
		 /// </summary>
		public int fdSkilResuID
		{
			get{return _fdSkilResuID;}
			set{_fdSkilResuID = value;}
		}
		private string _fdSkilName = "";
		 /// <summary>
		 /// 技能名称 100 nvarchar
		 /// </summary>
		public string fdSkilName
		{
			get{return _fdSkilName;}
			set{_fdSkilName = value;}
		}
		private int _fdSkilMonth = 0;
		 /// <summary>
		 /// 使用时间
		 /// </summary>
		public int fdSkilMonth
		{
			get{return _fdSkilMonth;}
			set{_fdSkilMonth = value;}
		}
		private int _fdSkilLevel = 0;
		 /// <summary>
		 /// 掌握程度
		 /// </summary>
		public int fdSkilLevel
		{
			get{return _fdSkilLevel;}
			set{_fdSkilLevel = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Skills_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Skills_bean funcGetByID(string id)
        {
            AW_Skills_bean bean = new AW_Skills_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Skills_bean funcGetByID(int id)
        {
            AW_Skills_bean bean = new AW_Skills_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Skills_bean funcGetByID(string id, string columns)
        {
            AW_Skills_bean bean = new AW_Skills_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Skills_bean funcGetByID(int id, string columns)
        {
            AW_Skills_bean bean = new AW_Skills_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
