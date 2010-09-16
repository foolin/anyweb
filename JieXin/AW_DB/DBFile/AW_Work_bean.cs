using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Work_bean : Bean_Base
	{
		private int _fdWorkID = 0;
		 /// <summary>
		 /// 工作经历编号
		 /// </summary>
		public int fdWorkID
		{
			get{return _fdWorkID;}
			set{_fdWorkID = value;}
		}
		private int _fdWorkResuID = 0;
		 /// <summary>
		 /// 简历编号
		 /// </summary>
		public int fdWorkResuID
		{
			get{return _fdWorkResuID;}
			set{_fdWorkResuID = value;}
		}
		private DateTime _fdWorkBegin = DateTime.Now;
		 /// <summary>
		 /// 开始时间
		 /// </summary>
		public DateTime fdWorkBegin
		{
			get{return _fdWorkBegin;}
			set{_fdWorkBegin = value;}
		}
		private DateTime _fdWorkEnd = DateTime.Now;
		 /// <summary>
		 /// 结束时间
		 /// </summary>
		public DateTime fdWorkEnd
		{
			get{return _fdWorkEnd;}
			set{_fdWorkEnd = value;}
		}
		private string _fdWorkName = "";
		 /// <summary>
		 /// 公司名称 100 nvarchar
		 /// </summary>
		public string fdWorkName
		{
			get{return _fdWorkName;}
			set{_fdWorkName = value;}
		}
		private int _fdWorkIndustryID = 0;
		 /// <summary>
		 /// 行业
		 /// </summary>
		public int fdWorkIndustryID
		{
			get{return _fdWorkIndustryID;}
			set{_fdWorkIndustryID = value;}
		}
		private int _fdWorkDimension = 0;
		 /// <summary>
		 /// 公司规模
		 /// </summary>
		public int fdWorkDimension
		{
			get{return _fdWorkDimension;}
			set{_fdWorkDimension = value;}
		}
		private int _fdWorkType = 0;
		 /// <summary>
		 /// 公司性质
		 /// </summary>
		public int fdWorkType
		{
			get{return _fdWorkType;}
			set{_fdWorkType = value;}
		}
		private string _fdWorkDepartment = "";
		 /// <summary>
		 /// 部门 100 nvarchar
		 /// </summary>
		public string fdWorkDepartment
		{
			get{return _fdWorkDepartment;}
			set{_fdWorkDepartment = value;}
		}
		private int _fdWorkJob = 0;
		 /// <summary>
		 /// 职位
		 /// </summary>
		public int fdWorkJob
		{
			get{return _fdWorkJob;}
			set{_fdWorkJob = value;}
		}
		private string _fdWorkIntro = "";
		 /// <summary>
		 /// 工作描述
		 /// </summary>
		public string fdWorkIntro
		{
			get{return _fdWorkIntro;}
			set{_fdWorkIntro = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Work_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Work_bean funcGetByID(string id)
        {
            AW_Work_bean bean = new AW_Work_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Work_bean funcGetByID(int id)
        {
            AW_Work_bean bean = new AW_Work_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Work_bean funcGetByID(string id, string columns)
        {
            AW_Work_bean bean = new AW_Work_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Work_bean funcGetByID(int id, string columns)
        {
            AW_Work_bean bean = new AW_Work_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
