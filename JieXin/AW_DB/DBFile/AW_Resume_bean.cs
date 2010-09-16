using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Resume_bean : Bean_Base
	{
		private int _fdResuID = 0;
		 /// <summary>
		 /// 用户信息编号
		 /// </summary>
		public int fdResuID
		{
			get{return _fdResuID;}
			set{_fdResuID = value;}
		}
		private int _fdResuUserID = 0;
		 /// <summary>
		 /// 用户编号
		 /// </summary>
		public int fdResuUserID
		{
			get{return _fdResuUserID;}
			set{_fdResuUserID = value;}
		}
		private string _fdResuName = "";
		 /// <summary>
		 /// 姓名 100 nvarchar
		 /// </summary>
		public string fdResuName
		{
			get{return _fdResuName;}
			set{_fdResuName = value;}
		}
		private int _fdResuSex = 0;
		 /// <summary>
		 /// 性别
		 /// </summary>
		public int fdResuSex
		{
			get{return _fdResuSex;}
			set{_fdResuSex = value;}
		}
		private int _fdResuMarry = 0;
		 /// <summary>
		 /// 婚姻状况
		 /// </summary>
		public int fdResuMarry
		{
			get{return _fdResuMarry;}
			set{_fdResuMarry = value;}
		}
		private DateTime _fdResuBirthday = DateTime.Now;
		 /// <summary>
		 /// 出生日期
		 /// </summary>
		public DateTime fdResuBirthday
		{
			get{return _fdResuBirthday;}
			set{_fdResuBirthday = value;}
		}
		private int _fdResuHeight = 0;
		 /// <summary>
		 /// 身高
		 /// </summary>
		public int fdResuHeight
		{
			get{return _fdResuHeight;}
			set{_fdResuHeight = value;}
		}
		private string _fdResuCountry = "";
		 /// <summary>
		 /// 国藉 50 varchar
		 /// </summary>
		public string fdResuCountry
		{
			get{return _fdResuCountry;}
			set{_fdResuCountry = value;}
		}
		private int _fdResuNation = 0;
		 /// <summary>
		 /// 民族
		 /// </summary>
		public int fdResuNation
		{
			get{return _fdResuNation;}
			set{_fdResuNation = value;}
		}
		private string _fdResuAddress = "";
		 /// <summary>
		 /// 现居地 400 nvarchar
		 /// </summary>
		public string fdResuAddress
		{
			get{return _fdResuAddress;}
			set{_fdResuAddress = value;}
		}
		private string _fdResuHouseAddress = "";
		 /// <summary>
		 /// 户口所在地 400 nvarchar
		 /// </summary>
		public string fdResuHouseAddress
		{
			get{return _fdResuHouseAddress;}
			set{_fdResuHouseAddress = value;}
		}
		private int _fdResuIdentificationID = 0;
		 /// <summary>
		 /// 证件类型
		 /// </summary>
		public int fdResuIdentificationID
		{
			get{return _fdResuIdentificationID;}
			set{_fdResuIdentificationID = value;}
		}
		private string _fdResuIdentificationNum = "";
		 /// <summary>
		 /// 证件号码 50 varchar
		 /// </summary>
		public string fdResuIdentificationNum
		{
			get{return _fdResuIdentificationNum;}
			set{_fdResuIdentificationNum = value;}
		}
		private int _fdResuPoliticalState = 0;
		 /// <summary>
		 /// 政治面貌
		 /// </summary>
		public int fdResuPoliticalState
		{
			get{return _fdResuPoliticalState;}
			set{_fdResuPoliticalState = value;}
		}
		private string _fdResuEmail = "";
		 /// <summary>
		 /// 邮箱地址 50 varchar
		 /// </summary>
		public string fdResuEmail
		{
			get{return _fdResuEmail;}
			set{_fdResuEmail = value;}
		}
		private int _fdResuContact1 = 0;
		 /// <summary>
		 /// 联系方式1
		 /// </summary>
		public int fdResuContact1
		{
			get{return _fdResuContact1;}
			set{_fdResuContact1 = value;}
		}
		private string _fdResuContactPhone1 = "";
		 /// <summary>
		 /// 联系电话1 50 varchar
		 /// </summary>
		public string fdResuContactPhone1
		{
			get{return _fdResuContactPhone1;}
			set{_fdResuContactPhone1 = value;}
		}
		private int _fdResuContact2 = 0;
		 /// <summary>
		 /// 联系方式2
		 /// </summary>
		public int fdResuContact2
		{
			get{return _fdResuContact2;}
			set{_fdResuContact2 = value;}
		}
		private string _fdResuContactPhone2 = "";
		 /// <summary>
		 /// 联系电话2 50 varchar
		 /// </summary>
		public string fdResuContactPhone2
		{
			get{return _fdResuContactPhone2;}
			set{_fdResuContactPhone2 = value;}
		}
		private int _fdResuContact3 = 0;
		 /// <summary>
		 /// 联系方式3
		 /// </summary>
		public int fdResuContact3
		{
			get{return _fdResuContact3;}
			set{_fdResuContact3 = value;}
		}
		private string _fdResuContactPhone3 = "";
		 /// <summary>
		 /// 联系电话3 50 varchar
		 /// </summary>
		public string fdResuContactPhone3
		{
			get{return _fdResuContactPhone3;}
			set{_fdResuContactPhone3 = value;}
		}
		private string _fdResuPostCode = "";
		 /// <summary>
		 /// 邮编 6 varchar
		 /// </summary>
		public string fdResuPostCode
		{
			get{return _fdResuPostCode;}
			set{_fdResuPostCode = value;}
		}
		private string _fdResuContactAddress = "";
		 /// <summary>
		 /// 通讯地址 400 nvarchar
		 /// </summary>
		public string fdResuContactAddress
		{
			get{return _fdResuContactAddress;}
			set{_fdResuContactAddress = value;}
		}
		private string _fdResuWebsite = "";
		 /// <summary>
		 /// 个人主页 200 varchar
		 /// </summary>
		public string fdResuWebsite
		{
			get{return _fdResuWebsite;}
			set{_fdResuWebsite = value;}
		}
		private int _fdResuWorkType = 0;
		 /// <summary>
		 /// 工作类型
		 /// </summary>
		public int fdResuWorkType
		{
			get{return _fdResuWorkType;}
			set{_fdResuWorkType = value;}
		}
		private string _fdResuArea = "";
		 /// <summary>
		 /// 工作地点 50 varchar
		 /// </summary>
		public string fdResuArea
		{
			get{return _fdResuArea;}
			set{_fdResuArea = value;}
		}
		private string _fdResuIndustry = "";
		 /// <summary>
		 /// 工作行业 50 varchar
		 /// </summary>
		public string fdResuIndustry
		{
			get{return _fdResuIndustry;}
			set{_fdResuIndustry = value;}
		}
		private string _fdResuJob = "";
		 /// <summary>
		 /// 职能 50 varchar
		 /// </summary>
		public string fdResuJob
		{
			get{return _fdResuJob;}
			set{_fdResuJob = value;}
		}
		private int _fdResuSalary = 0;
		 /// <summary>
		 /// 期望薪水
		 /// </summary>
		public int fdResuSalary
		{
			get{return _fdResuSalary;}
			set{_fdResuSalary = value;}
		}
		private int _fdResuArriveAt = 0;
		 /// <summary>
		 /// 到岗时间
		 /// </summary>
		public int fdResuArriveAt
		{
			get{return _fdResuArriveAt;}
			set{_fdResuArriveAt = value;}
		}
		private string _fdResuIntro = "";
		 /// <summary>
		 /// 自我评价 1000 nvarchar
		 /// </summary>
		public string fdResuIntro
		{
			get{return _fdResuIntro;}
			set{_fdResuIntro = value;}
		}
		private int _fdResuType = 0;
		 /// <summary>
		 /// 简历类型(0:标准简历1:应届生简历)
		 /// </summary>
		public int fdResuType
		{
			get{return _fdResuType;}
			set{_fdResuType = value;}
		}
		private int _fdResuStatus = 0;
		 /// <summary>
		 /// 状态(0:正常1:新建未保存)
		 /// </summary>
		public int fdResuStatus
		{
			get{return _fdResuStatus;}
			set{_fdResuStatus = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Resume_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Resume_bean funcGetByID(string id)
        {
            AW_Resume_bean bean = new AW_Resume_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Resume_bean funcGetByID(int id)
        {
            AW_Resume_bean bean = new AW_Resume_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Resume_bean funcGetByID(string id, string columns)
        {
            AW_Resume_bean bean = new AW_Resume_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Resume_bean funcGetByID(int id, string columns)
        {
            AW_Resume_bean bean = new AW_Resume_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
