using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Awards_bean : Bean_Base
	{
		private int _fdAwarID = 0;
		 /// <summary>
		 /// 奖项编号
		 /// </summary>
		public int fdAwarID
		{
			get{return _fdAwarID;}
			set{_fdAwarID = value;}
		}
		private int _fdAwarResuID = 0;
		 /// <summary>
		 /// 简历编号
		 /// </summary>
		public int fdAwarResuID
		{
			get{return _fdAwarResuID;}
			set{_fdAwarResuID = value;}
		}
		private DateTime _fdAwarDate = DateTime.Now;
		 /// <summary>
		 /// 获得时间
		 /// </summary>
		public DateTime fdAwarDate
		{
			get{return _fdAwarDate;}
			set{_fdAwarDate = value;}
		}
		private string _fdAwarName = "";
		 /// <summary>
		 /// 名称 100 nvarchar
		 /// </summary>
		public string fdAwarName
		{
			get{return _fdAwarName;}
			set{_fdAwarName = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Awards_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Awards_bean funcGetByID(string id)
        {
            AW_Awards_bean bean = new AW_Awards_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Awards_bean funcGetByID(int id)
        {
            AW_Awards_bean bean = new AW_Awards_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Awards_bean funcGetByID(string id, string columns)
        {
            AW_Awards_bean bean = new AW_Awards_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Awards_bean funcGetByID(int id, string columns)
        {
            AW_Awards_bean bean = new AW_Awards_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
