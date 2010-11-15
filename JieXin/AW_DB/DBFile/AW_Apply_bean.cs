using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Apply_bean : Bean_Base
	{
		private int _fdApplID = 0;
		 /// <summary>
		 /// 职位申请编号
		 /// </summary>
		public int fdApplID
		{
			get{return _fdApplID;}
			set{_fdApplID = value;}
		}
		private int _fdApplUserID = 0;
		 /// <summary>
		 /// 用户编号
		 /// </summary>
		public int fdApplUserID
		{
			get{return _fdApplUserID;}
			set{_fdApplUserID = value;}
		}
		private int _fdApplResuID = 0;
		 /// <summary>
		 /// 简历编号
		 /// </summary>
		public int fdApplResuID
		{
			get{return _fdApplResuID;}
			set{_fdApplResuID = value;}
		}
		private int _fdApplRecrID = 0;
		 /// <summary>
		 /// 职位编号
		 /// </summary>
		public int fdApplRecrID
		{
			get{return _fdApplRecrID;}
			set{_fdApplRecrID = value;}
		}
        private DateTime _fdApplCreateAt = DateTime.Now;
        /// <summary>
        /// 投递时间
        /// </summary>
        public DateTime fdApplCreateAt
        {
            get{return _fdApplCreateAt;}
            set{_fdApplCreateAt = value;}
        }


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Apply_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Apply_bean funcGetByID(string id)
        {
            AW_Apply_bean bean = new AW_Apply_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Apply_bean funcGetByID(int id)
        {
            AW_Apply_bean bean = new AW_Apply_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Apply_bean funcGetByID(string id, string columns)
        {
            AW_Apply_bean bean = new AW_Apply_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Apply_bean funcGetByID(int id, string columns)
        {
            AW_Apply_bean bean = new AW_Apply_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
