using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_User_bean : Bean_Base
	{
		private int _fdUserID = 0;
		 /// <summary>
		 /// 用户编号
		 /// </summary>
		public int fdUserID
		{
			get{return _fdUserID;}
			set{_fdUserID = value;}
		}
		private string _fdUserAccount = "";
		 /// <summary>
		 /// 用户帐号 50 varchar
		 /// </summary>
		public string fdUserAccount
		{
			get{return _fdUserAccount;}
			set{_fdUserAccount = value;}
		}

        private string _fdUserPwd = "";
        /// <summary>
        /// 用户密码 50 varchar
        /// </summary>
        public string fdUserPwd
        {
            get { return _fdUserPwd; }
            set { _fdUserPwd = value; }
        }

        private string _fdUserEmail = "";
        /// <summary>
        /// 用户邮箱 100 varchar
        /// </summary>
        public string fdUserEmail
        {
            get { return _fdUserEmail; }
            set { _fdUserEmail = value; }
        }

        private string _fdUserName = "";
        /// <summary>
        /// 用户姓名 50 nvarchar
        /// </summary>
        public string fdUserName
        {
            get { return _fdUserName; }
            set { _fdUserName = value; }
        }

        private int _fdUserSex = 1;
        /// <summary>
        /// 用户性别：0女1男
        /// </summary>
        public int fdUserSex
        {
            get { return _fdUserSex; }
            set { _fdUserSex = value; }
        }

        private DateTime _fdUserBirthday = DateTime.Now;
        /// <summary>
        /// 用户出生日期 datetime
        /// </summary>
        public DateTime fdUserBirthday
        {
            get { return _fdUserBirthday; }
            set { _fdUserBirthday = value; }
        }

        private int _fdUserExperience = 0;
        /// <summary>
        /// 用户工作年限：1"1年以下" 2"1-2年" 3"2-5年" 4"5-10年" 5"10年以上"
        /// </summary>
        public int fdUserExperience
        {
            get { return _fdUserExperience; }
            set { _fdUserExperience = value; }
        }

        private int _fdUserIdentificationID = 0;
        /// <summary>
        /// 用户证件类型：1身份证2军人证3香港身份证4其他 
        /// </summary>
        public int fdUserIdentificationID
        {
            get { return _fdUserIdentificationID; }
            set { _fdUserIdentificationID = value; }
        }

        private int _fdUserIdentificationNum = 0;
        /// <summary>
        /// 用户证件号
        /// </summary>
        public int fdUserIdentificationNum
        {
            get { return _fdUserIdentificationNum; }
            set { _fdUserIdentificationNum = value; }
        }

        private string _fdUserAddress = "";
        /// <summary>
        /// 用户居住地 50 nvarchar
        /// </summary>
        public string fdUserAddress
        {
            get { return _fdUserAddress; }
            set { _fdUserAddress = value; }
        }

        private int _fdUserCurrentSituation = 0;
        /// <summary>
        /// 用户求职状态：1目前正在找工作2半年内无换工作的计划3一年内无换工作的计划4观望有好的机会再考虑5暂时不想找工作
        /// </summary>
        public int fdUserCurrentSituation
        {
            get { return _fdUserCurrentSituation; }
            set { _fdUserCurrentSituation = value; }
        }

        private int _fdUserNation = 0;
        /// <summary>
        /// 用户民族：
        /// </summary>
        public int fdUserNation
        {
            get { return _fdUserNation; }
            set { _fdUserNation = value; }
        }

        private DateTime _fdUserGraDate = DateTime.Now;
        /// <summary>
        /// 用户毕业日期 datetime
        /// </summary>
        public DateTime fdUserGraDate
        {
            get { return _fdUserGraDate; }
            set { _fdUserGraDate = value; }
        }

        private int _fdUserPoliticalState = 0;
        /// <summary>
        /// 用户政治面貌：1群众2团员3党员
        /// </summary>
        public int fdUserPoliticalState
        {
            get { return _fdUserPoliticalState; }
            set { _fdUserPoliticalState = value; }
        }

        private int _fdUserDegree = 0;
        /// <summary>
        /// 用户教育程度：1初中,2高中,3中技,4中专,5大专,6本科,7MBA,8硕士,9博士,10其他
        /// </summary>
        public int fdUserDegree
        {
            get { return _fdUserDegree; }
            set { _fdUserDegree = value; }
        }

        private string _fdUserHouseAddress = "";
        /// <summary>
        /// 用户户口 50 nvarchar
        /// </summary>
        public string fdUserHouseAddress
        {
            get { return _fdUserHouseAddress; }
            set { _fdUserHouseAddress = value; }
        }

        private string _fdUserCountry = "";
        /// <summary>
        /// 用户国家地区 50 nvarchar
        /// </summary>
        public string fdUserCountry
        {
            get { return _fdUserCountry; }
            set { _fdUserCountry = value; }
        }

        private string _fdUserHeight = "";
        /// <summary>
        /// 用户身高 50 nvarchar
        /// </summary>
        public string fdUserHeight
        {
            get { return _fdUserHeight; }
            set { _fdUserHeight = value; }
        }

        private int _fdUserPostCode = 0;
        /// <summary>
        /// 用户邮编
        /// </summary>
        public int fdUserPostCode
        {
            get { return _fdUserPostCode; }
            set { _fdUserPostCode = value; }
        }

        private string _fdUserContactAddr = "";
        /// <summary>
        /// 用户通讯地址 400 nvarchar
        /// </summary>
        public string fdUserContactAddr
        {
            get { return _fdUserContactAddr; }
            set { _fdUserContactAddr = value; }
        }

        private int _fdUserMarry = 0;
        /// <summary>
        /// 用户婚姻状况：1未婚2已婚
        /// </summary>
        public int fdUserMarry
        {
            get { return _fdUserMarry; }
            set { _fdUserMarry = value; }
        }

        private string _fdUserWebsite = "";
        /// <summary>
        /// 用户个人主页 50 nvarchar
        /// </summary>
        public string fdUserWebsite
        {
            get { return _fdUserWebsite; }
            set { _fdUserWebsite = value; }
        }

		private int _fdUserStatus = 0;
		 /// <summary>
		 /// 用户状态：0正常1冻结2删除
		 /// </summary>
		public int fdUserStatus
		{
			get{return _fdUserStatus;}
			set{_fdUserStatus = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_User_dao(); 
				}
				return _dao;
			}
        }

        public static AW_User_bean funcGetByID(string id)
        {
            AW_User_bean bean = new AW_User_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_User_bean funcGetByID(int id)
        {
            AW_User_bean bean = new AW_User_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_User_bean funcGetByID(string id, string columns)
        {
            AW_User_bean bean = new AW_User_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_User_bean funcGetByID(int id, string columns)
        {
            AW_User_bean bean = new AW_User_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
