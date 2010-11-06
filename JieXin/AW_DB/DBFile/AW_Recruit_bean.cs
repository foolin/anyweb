using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Recruit_bean : Bean_Base
	{
		private int _fdRecrID = 0;
		 /// <summary>
		 /// 招聘编号
		 /// </summary>
		public int fdRecrID
		{
			get{return _fdRecrID;}
			set{_fdRecrID = value;}
		}
		private string _fdRecrTitle = "";
		 /// <summary>
		 /// 标题 200 nvarchar
		 /// </summary>
		public string fdRecrTitle
		{
			get{return _fdRecrTitle;}
			set{_fdRecrTitle = value;}
		}
		private string _fdRecrCompany = "";
		 /// <summary>
		 /// 公司名称 200 nvarchar
		 /// </summary>
		public string fdRecrCompany
		{
			get{return _fdRecrCompany;}
			set{_fdRecrCompany = value;}
		}
		private string _fdRecrJob = "";
		 /// <summary>
		 /// 职位名 100 nvarchar
		 /// </summary>
		public string fdRecrJob
		{
			get{return _fdRecrJob;}
			set{_fdRecrJob = value;}
		}
		private int _fdRecrAreaID = 0;
		 /// <summary>
		 /// 地区编号
		 /// </summary>
		public int fdRecrAreaID
		{
			get{return _fdRecrAreaID;}
			set{_fdRecrAreaID = value;}
		}
        private string _fdRecrAreaName = "";
        /// <summary>
        /// 地区名
        /// </summary>
        public string fdRecrAreaName
        {
            get{ return _fdRecrAreaName;}
            set{_fdRecrAreaName = value;}
        }
		private string _fdRecrContent = "";
		 /// <summary>
		 /// 招聘内容
		 /// </summary>
		public string fdRecrContent
		{
			get{return _fdRecrContent;}
			set{_fdRecrContent = value;}
		}
		private int _fdRecrType = 0;
		 /// <summary>
		 /// 招聘类别
		 /// </summary>
		public int fdRecrType
		{
			get{return _fdRecrType;}
			set{_fdRecrType = value;}
		}
		private int _fdRecrSort = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdRecrSort
		{
			get{return _fdRecrSort;}
			set{_fdRecrSort = value;}
		}
		private DateTime _fdRecrCreateAt = DateTime.Now;
		 /// <summary>
		 /// 创建时间
		 /// </summary>
		public DateTime fdRecrCreateAt
		{
			get{return _fdRecrCreateAt;}
			set{_fdRecrCreateAt = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Recruit_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Recruit_bean funcGetByID(string id)
        {
            AW_Recruit_bean bean = new AW_Recruit_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Recruit_bean funcGetByID(int id)
        {
            AW_Recruit_bean bean = new AW_Recruit_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Recruit_bean funcGetByID(string id, string columns)
        {
            AW_Recruit_bean bean = new AW_Recruit_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Recruit_bean funcGetByID(int id, string columns)
        {
            AW_Recruit_bean bean = new AW_Recruit_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
