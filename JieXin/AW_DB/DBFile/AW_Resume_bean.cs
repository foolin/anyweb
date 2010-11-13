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
		 /// 简历名称 30 nvarchar
		 /// </summary>
		public string fdResuName
		{
			get{return _fdResuName;}
			set{_fdResuName = value;}
		}
        private string _fdResuUserName = "";
        /// <summary>
        /// 姓名
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
        /// 照片
        /// </summary>
        public string fdResuPhoto
        {
            get{return _fdResuPhoto;}
            set{ _fdResuPhoto = value;}
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
            set{ _fdResuTOEFL = value;}
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
            get{ return _fdResuIELTS;}
            set{_fdResuIELTS = value;}
        }
        private DateTime _fdResuCreateAt = DateTime.Now;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime fdResuCreateAt
        {
            get{return _fdResuCreateAt;}
            set{ _fdResuCreateAt = value;}
        }
        private DateTime _fdResuUpdateAt = DateTime.Now;
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime fdResuUpdateAt
        {
            get{ return _fdResuUpdateAt; }
            set{_fdResuUpdateAt = value;}
        }
        private int _fdResuViewCount = 0;
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int fdResuViewCount
        {
            get{ return _fdResuViewCount;}
            set{ _fdResuViewCount = value;}
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
