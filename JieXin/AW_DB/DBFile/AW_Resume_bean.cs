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
		 /// 简历编号
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
		 /// 简历名称 60 nvarchar
		 /// </summary>
		public string fdResuName
		{
			get{return _fdResuName;}
			set{_fdResuName = value;}
		}
		private string _fdResuUserName = "";
		 /// <summary>
		 /// 姓名 60 nvarchar
		 /// </summary>
		public string fdResuUserName
		{
			get{return _fdResuUserName;}
			set{_fdResuUserName = value;}
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
		private DateTime _fdResuBirthday = DateTime.Parse("1900-01-01");
		 /// <summary>
		 /// 出生日期
		 /// </summary>
		public DateTime fdResuBirthday
		{
			get{return _fdResuBirthday;}
			set{_fdResuBirthday = value;}
		}
		private int _fdResuExperience = 0;
		 /// <summary>
		 /// 工作年限（1:1年以下 2:1-2年3:2-5年 4:5-10年5:10年以上)
		 /// </summary>
		public int fdResuExperience
		{
			get{return _fdResuExperience;}
			set{_fdResuExperience = value;}
		}
		private int _fdResuIdentificationID = 0;
		 /// <summary>
		 /// 证件类型(1身份证2军人证3香港身份证4其他)
		 /// </summary>
		public int fdResuIdentificationID
		{
			get{return _fdResuIdentificationID;}
			set{_fdResuIdentificationID = value;}
		}
		private string _fdResuIdentificationNum = "";
		 /// <summary>
		 /// 证件号码 20 varchar
		 /// </summary>
		public string fdResuIdentificationNum
		{
			get{return _fdResuIdentificationNum;}
			set{_fdResuIdentificationNum = value;}
		}
		private int _fdResuAddressID = 0;
		 /// <summary>
		 /// 居住地编号
		 /// </summary>
		public int fdResuAddressID
		{
			get{return _fdResuAddressID;}
			set{_fdResuAddressID = value;}
		}
		private string _fdResuAddress = "";
		 /// <summary>
		 /// 现居地 20 nvarchar
		 /// </summary>
		public string fdResuAddress
		{
			get{return _fdResuAddress;}
			set{_fdResuAddress = value;}
		}
		private string _fdResuEmail = "";
		 /// <summary>
		 /// 邮箱地址 100 varchar
		 /// </summary>
		public string fdResuEmail
		{
			get{return _fdResuEmail;}
			set{_fdResuEmail = value;}
		}
		private int _fdResuSalary = 0;
		 /// <summary>
		 /// 年薪(1:2万以下2:2-3万3:3-4万4:4-5万5:5-6万6:6-8万7:8-10万8:10-15万9:15-30万10:30-50万11:50-100万12:100万以上)
		 /// </summary>
		public int fdResuSalary
		{
			get{return _fdResuSalary;}
			set{_fdResuSalary = value;}
		}
		private int _fdResuCurrType = 0;
		 /// <summary>
		 /// 币种(1:人民币2:港币3:美元4日元5欧元6其它)
		 /// </summary>
		public int fdResuCurrType
		{
			get{return _fdResuCurrType;}
			set{_fdResuCurrType = value;}
		}
		private int _fdResuCurrentSituation = 0;
		 /// <summary>
		 /// 求职状态(1目前正在找工作2半年内无换工作的计划3一年内无换工作的计划4观望有好的机会再考虑5暂时不想找工作)
		 /// </summary>
		public int fdResuCurrentSituation
		{
			get{return _fdResuCurrentSituation;}
			set{_fdResuCurrentSituation = value;}
		}
		private string _fdResuMobilePhone = "";
		 /// <summary>
		 /// 手机号码 17 varchar
		 /// </summary>
		public string fdResuMobilePhone
		{
			get{return _fdResuMobilePhone;}
			set{_fdResuMobilePhone = value;}
		}
		private string _fdResuCompPhone = "";
		 /// <summary>
		 /// 公司电话 31 varchar
		 /// </summary>
		public string fdResuCompPhone
		{
			get{return _fdResuCompPhone;}
			set{_fdResuCompPhone = value;}
		}
		private string _fdResuFamiPhone = "";
		 /// <summary>
		 /// 家庭电话 21 varchar
		 /// </summary>
		public string fdResuFamiPhone
		{
			get{return _fdResuFamiPhone;}
			set{_fdResuFamiPhone = value;}
		}
		private int _fdResuHouseAddressID = 0;
		 /// <summary>
		 /// 户口编号
		 /// </summary>
		public int fdResuHouseAddressID
		{
			get{return _fdResuHouseAddressID;}
			set{_fdResuHouseAddressID = value;}
		}
		private string _fdResuHouseAddress = "";
		 /// <summary>
		 /// 户口所在地 20 nvarchar
		 /// </summary>
		public string fdResuHouseAddress
		{
			get{return _fdResuHouseAddress;}
			set{_fdResuHouseAddress = value;}
		}
		private int _fdResuCountry = 0;
		 /// <summary>
		 /// 国藉
		 /// </summary>
		public int fdResuCountry
		{
			get{return _fdResuCountry;}
			set{_fdResuCountry = value;}
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
		private string _fdResuPostCode = "";
		 /// <summary>
		 /// 邮编 6 varchar
		 /// </summary>
		public string fdResuPostCode
		{
			get{return _fdResuPostCode;}
			set{_fdResuPostCode = value;}
		}
		private string _fdResuContactAddr = "";
		 /// <summary>
		 /// 地址 100 nvarchar
		 /// </summary>
		public string fdResuContactAddr
		{
			get{return _fdResuContactAddr;}
			set{_fdResuContactAddr = value;}
		}
		private int _fdResuMarry = 0;
		 /// <summary>
		 /// 婚姻状况(1未婚2已婚)
		 /// </summary>
		public int fdResuMarry
		{
			get{return _fdResuMarry;}
			set{_fdResuMarry = value;}
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
		private string _fdResuPhoto = "";
		 /// <summary>
		 /// 照片 100 varchar
		 /// </summary>
		public string fdResuPhoto
		{
			get{return _fdResuPhoto;}
			set{_fdResuPhoto = value;}
		}
		private int _fdResuObjeType = 0;
		 /// <summary>
		 /// 工作类型
		 /// </summary>
		public int fdResuObjeType
		{
			get{return _fdResuObjeType;}
			set{_fdResuObjeType = value;}
		}
		private int _fdResuObjeAreaID1 = 0;
		 /// <summary>
		 /// 地点编号
		 /// </summary>
		public int fdResuObjeAreaID1
		{
			get{return _fdResuObjeAreaID1;}
			set{_fdResuObjeAreaID1 = value;}
		}
		private string _fdResuObjeArea1 = "";
		 /// <summary>
		 /// 地点 20 nvarchar
		 /// </summary>
		public string fdResuObjeArea1
		{
			get{return _fdResuObjeArea1;}
			set{_fdResuObjeArea1 = value;}
		}
		private int _fdResuObjeAreaID2 = 0;
		 /// <summary>
		 /// 地点编号
		 /// </summary>
		public int fdResuObjeAreaID2
		{
			get{return _fdResuObjeAreaID2;}
			set{_fdResuObjeAreaID2 = value;}
		}
		private string _fdResuObjeArea2 = "";
		 /// <summary>
		 /// 地点 20 nvarchar
		 /// </summary>
		public string fdResuObjeArea2
		{
			get{return _fdResuObjeArea2;}
			set{_fdResuObjeArea2 = value;}
		}
		private int _fdResuObjeAreaID3 = 0;
		 /// <summary>
		 /// 地点编号
		 /// </summary>
		public int fdResuObjeAreaID3
		{
			get{return _fdResuObjeAreaID3;}
			set{_fdResuObjeAreaID3 = value;}
		}
		private string _fdResuObjeArea3 = "";
		 /// <summary>
		 /// 地点 20 nvarchar
		 /// </summary>
		public string fdResuObjeArea3
		{
			get{return _fdResuObjeArea3;}
			set{_fdResuObjeArea3 = value;}
		}
		private int _fdResuObjeAreaID4 = 0;
		 /// <summary>
		 /// 地点编号
		 /// </summary>
		public int fdResuObjeAreaID4
		{
			get{return _fdResuObjeAreaID4;}
			set{_fdResuObjeAreaID4 = value;}
		}
		private string _fdResuObjeArea4 = "";
		 /// <summary>
		 /// 地点 20 nvarchar
		 /// </summary>
		public string fdResuObjeArea4
		{
			get{return _fdResuObjeArea4;}
			set{_fdResuObjeArea4 = value;}
		}
		private int _fdResuObjeAreaID5 = 0;
		 /// <summary>
		 /// 地点编号
		 /// </summary>
		public int fdResuObjeAreaID5
		{
			get{return _fdResuObjeAreaID5;}
			set{_fdResuObjeAreaID5 = value;}
		}
		private string _fdResuObjeArea5 = "";
		 /// <summary>
		 /// 地点 20 nvarchar
		 /// </summary>
		public string fdResuObjeArea5
		{
			get{return _fdResuObjeArea5;}
			set{_fdResuObjeArea5 = value;}
		}
		private int _fdResuObjeIndustryID1 = 0;
		 /// <summary>
		 /// 行业编号
		 /// </summary>
		public int fdResuObjeIndustryID1
		{
			get{return _fdResuObjeIndustryID1;}
			set{_fdResuObjeIndustryID1 = value;}
		}
		private string _fdResuObjeIndustry1 = "";
		 /// <summary>
		 /// 行业 40 nvarchar
		 /// </summary>
		public string fdResuObjeIndustry1
		{
			get{return _fdResuObjeIndustry1;}
			set{_fdResuObjeIndustry1 = value;}
		}
		private int _fdResuObjeIndustryID2 = 0;
		 /// <summary>
		 /// 行业编号
		 /// </summary>
		public int fdResuObjeIndustryID2
		{
			get{return _fdResuObjeIndustryID2;}
			set{_fdResuObjeIndustryID2 = value;}
		}
		private string _fdResuObjeIndustry2 = "";
		 /// <summary>
		 /// 行业 40 nvarchar
		 /// </summary>
		public string fdResuObjeIndustry2
		{
			get{return _fdResuObjeIndustry2;}
			set{_fdResuObjeIndustry2 = value;}
		}
		private int _fdResuObjeIndustryID3 = 0;
		 /// <summary>
		 /// 行业编号
		 /// </summary>
		public int fdResuObjeIndustryID3
		{
			get{return _fdResuObjeIndustryID3;}
			set{_fdResuObjeIndustryID3 = value;}
		}
		private string _fdResuObjeIndustry3 = "";
		 /// <summary>
		 /// 行业 40 nvarchar
		 /// </summary>
		public string fdResuObjeIndustry3
		{
			get{return _fdResuObjeIndustry3;}
			set{_fdResuObjeIndustry3 = value;}
		}
		private int _fdResuObjeIndustryID4 = 0;
		 /// <summary>
		 /// 行业编号
		 /// </summary>
		public int fdResuObjeIndustryID4
		{
			get{return _fdResuObjeIndustryID4;}
			set{_fdResuObjeIndustryID4 = value;}
		}
		private string _fdResuObjeIndustry4 = "";
		 /// <summary>
		 /// 行业 40 nvarchar
		 /// </summary>
		public string fdResuObjeIndustry4
		{
			get{return _fdResuObjeIndustry4;}
			set{_fdResuObjeIndustry4 = value;}
		}
		private int _fdResuObjeIndustryID5 = 0;
		 /// <summary>
		 /// 行业编号
		 /// </summary>
		public int fdResuObjeIndustryID5
		{
			get{return _fdResuObjeIndustryID5;}
			set{_fdResuObjeIndustryID5 = value;}
		}
		private string _fdResuObjeIndustry5 = "";
		 /// <summary>
		 /// 行业 40 nvarchar
		 /// </summary>
		public string fdResuObjeIndustry5
		{
			get{return _fdResuObjeIndustry5;}
			set{_fdResuObjeIndustry5 = value;}
		}
		private int _fdResuObjeFuncTypeID1 = 0;
		 /// <summary>
		 /// 职能编号
		 /// </summary>
		public int fdResuObjeFuncTypeID1
		{
			get{return _fdResuObjeFuncTypeID1;}
			set{_fdResuObjeFuncTypeID1 = value;}
		}
		private string _fdResuObjeFuncType1 = "";
		 /// <summary>
		 /// 职能 40 nvarchar
		 /// </summary>
		public string fdResuObjeFuncType1
		{
			get{return _fdResuObjeFuncType1;}
			set{_fdResuObjeFuncType1 = value;}
		}
		private int _fdResuObjeFuncTypeID2 = 0;
		 /// <summary>
		 /// 职能编号
		 /// </summary>
		public int fdResuObjeFuncTypeID2
		{
			get{return _fdResuObjeFuncTypeID2;}
			set{_fdResuObjeFuncTypeID2 = value;}
		}
		private string _fdResuObjeFuncType2 = "";
		 /// <summary>
		 /// 职能 40 nvarchar
		 /// </summary>
		public string fdResuObjeFuncType2
		{
			get{return _fdResuObjeFuncType2;}
			set{_fdResuObjeFuncType2 = value;}
		}
		private int _fdResuObjeFuncTypeID3 = 0;
		 /// <summary>
		 /// 职能编号
		 /// </summary>
		public int fdResuObjeFuncTypeID3
		{
			get{return _fdResuObjeFuncTypeID3;}
			set{_fdResuObjeFuncTypeID3 = value;}
		}
		private string _fdResuObjeFuncType3 = "";
		 /// <summary>
		 /// 职能 40 nvarchar
		 /// </summary>
		public string fdResuObjeFuncType3
		{
			get{return _fdResuObjeFuncType3;}
			set{_fdResuObjeFuncType3 = value;}
		}
		private int _fdResuObjeFuncTypeID4 = 0;
		 /// <summary>
		 /// 职能编号
		 /// </summary>
		public int fdResuObjeFuncTypeID4
		{
			get{return _fdResuObjeFuncTypeID4;}
			set{_fdResuObjeFuncTypeID4 = value;}
		}
		private string _fdResuObjeFuncType4 = "";
		 /// <summary>
		 /// 职能 40 nvarchar
		 /// </summary>
		public string fdResuObjeFuncType4
		{
			get{return _fdResuObjeFuncType4;}
			set{_fdResuObjeFuncType4 = value;}
		}
		private int _fdResuObjeFuncTypeID5 = 0;
		 /// <summary>
		 /// 职能编号
		 /// </summary>
		public int fdResuObjeFuncTypeID5
		{
			get{return _fdResuObjeFuncTypeID5;}
			set{_fdResuObjeFuncTypeID5 = value;}
		}
		private string _fdResuObjeFuncType5 = "";
		 /// <summary>
		 /// 职能 40 nvarchar
		 /// </summary>
		public string fdResuObjeFuncType5
		{
			get{return _fdResuObjeFuncType5;}
			set{_fdResuObjeFuncType5 = value;}
		}
		private int _fdResuObjeSalery = 0;
		 /// <summary>
		 /// 期望薪水
		 /// </summary>
		public int fdResuObjeSalery
		{
			get{return _fdResuObjeSalery;}
			set{_fdResuObjeSalery = value;}
		}
		private int _fdResuObjeEntryTime = 0;
		 /// <summary>
		 /// 到岗时间
		 /// </summary>
		public int fdResuObjeEntryTime
		{
			get{return _fdResuObjeEntryTime;}
			set{_fdResuObjeEntryTime = value;}
		}
		private string _fdResuObjeDepartment = "";
		 /// <summary>
		 /// 部门 40 nvarchar
		 /// </summary>
		public string fdResuObjeDepartment
		{
			get{return _fdResuObjeDepartment;}
			set{_fdResuObjeDepartment = value;}
		}
		private int _fdResuObjeCompType = 0;
		 /// <summary>
		 /// 公司性质
		 /// </summary>
		public int fdResuObjeCompType
		{
			get{return _fdResuObjeCompType;}
			set{_fdResuObjeCompType = value;}
		}
		private string _fdResuObjeIntro = "";
		 /// <summary>
		 /// 自我介绍 1000 nvarchar
		 /// </summary>
		public string fdResuObjeIntro
		{
			get{return _fdResuObjeIntro;}
			set{_fdResuObjeIntro = value;}
		}
		private int _fdResuEnLevel = 0;
		 /// <summary>
		 /// 英语等级
		 /// </summary>
		public int fdResuEnLevel
		{
			get{return _fdResuEnLevel;}
			set{_fdResuEnLevel = value;}
		}
		private int _fdResuTOEFL = 0;
		 /// <summary>
		 /// TOEFL
		 /// </summary>
		public int fdResuTOEFL
		{
			get{return _fdResuTOEFL;}
			set{_fdResuTOEFL = value;}
		}
		private int _fdResuGRE = 0;
		 /// <summary>
		 /// GRE
		 /// </summary>
		public int fdResuGRE
		{
			get{return _fdResuGRE;}
			set{_fdResuGRE = value;}
		}
		private int _fdResuJpLevel = 0;
		 /// <summary>
		 /// 日语等级
		 /// </summary>
		public int fdResuJpLevel
		{
			get{return _fdResuJpLevel;}
			set{_fdResuJpLevel = value;}
		}
		private int _fdResuGMAT = 0;
		 /// <summary>
		 /// GMAT
		 /// </summary>
		public int fdResuGMAT
		{
			get{return _fdResuGMAT;}
			set{_fdResuGMAT = value;}
		}
		private int _fdResuIELTS = 0;
		 /// <summary>
		 /// IELTS
		 /// </summary>
		public int fdResuIELTS
		{
			get{return _fdResuIELTS;}
			set{_fdResuIELTS = value;}
		}
        private int _fdResuDegree = 0;
        /// <summary>
        /// 最高学历
        /// </summary>
        public int fdResuDegree
        {
            get{return _fdResuDegree;}
            set{ _fdResuDegree = value;}
        }
		private int _fdResuViewCount = 0;
		 /// <summary>
		 /// 浏览次数
		 /// </summary>
		public int fdResuViewCount
		{
			get{return _fdResuViewCount;}
			set{_fdResuViewCount = value;}
		}
		private DateTime _fdResuCreateAt = DateTime.Now;
		 /// <summary>
		 /// 创建时间
		 /// </summary>
		public DateTime fdResuCreateAt
		{
			get{return _fdResuCreateAt;}
			set{_fdResuCreateAt = value;}
		}
		private DateTime _fdResuUpdateAt = DateTime.Now;
		 /// <summary>
		 /// 更新时间
		 /// </summary>
		public DateTime fdResuUpdateAt
		{
			get{return _fdResuUpdateAt;}
			set{_fdResuUpdateAt = value;}
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
