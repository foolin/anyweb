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
			get{return _fdUserPwd;}
			set{_fdUserPwd = value;}
		}
		private string _fdUserEmail = "";
		 /// <summary>
		 /// 用户邮箱 100 varchar
		 /// </summary>
		public string fdUserEmail
		{
			get{return _fdUserEmail;}
			set{_fdUserEmail = value;}
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
		private string _fdUserPhoto = "";
		 /// <summary>
		 /// 形象照片 100 varchar
		 /// </summary>
		public string fdUserPhoto
		{
			get{return _fdUserPhoto;}
			set{_fdUserPhoto = value;}
		}
		private int _fdUserPhotoIsShow = 0;
		 /// <summary>
		 /// 是否在简历中显示形象照片(0:不显示1显示)
		 /// </summary>
		public int fdUserPhotoIsShow
		{
			get{return _fdUserPhotoIsShow;}
			set{_fdUserPhotoIsShow = value;}
		}
		private string _fdUserName = "";
		 /// <summary>
		 /// 姓名 60 nvarchar
		 /// </summary>
		public string fdUserName
		{
			get{return _fdUserName;}
			set{_fdUserName = value;}
		}
		private int _fdUserSex = 0;
		 /// <summary>
		 /// 性别(0男1女)
		 /// </summary>
		public int fdUserSex
		{
			get{return _fdUserSex;}
			set{_fdUserSex = value;}
		}
		private DateTime _fdUserBirthday = DateTime.Now;
		 /// <summary>
		 /// 出生日期
		 /// </summary>
		public DateTime fdUserBirthday
		{
			get{return _fdUserBirthday;}
			set{_fdUserBirthday = value;}
		}
		private int _fdUserExperience = 0;
		 /// <summary>
		 /// 工作年限（1:1年以下 2:1-2年3:2-5年 4:5-10年5:10年以上)
		 /// </summary>
		public int fdUserExperience
		{
			get{return _fdUserExperience;}
			set{_fdUserExperience = value;}
		}
		private int _fdUserIdentificationID = 0;
		 /// <summary>
		 /// 证件类型(1身份证2军人证3香港身份证4其他)
		 /// </summary>
		public int fdUserIdentificationID
		{
			get{return _fdUserIdentificationID;}
			set{_fdUserIdentificationID = value;}
		}
		private string _fdUserIdentificationNum = "";
		 /// <summary>
		 /// 证件号码 20 varchar
		 /// </summary>
		public string fdUserIdentificationNum
		{
			get{return _fdUserIdentificationNum;}
			set{_fdUserIdentificationNum = value;}
		}
		private int _fdUserAddressID = 0;
		 /// <summary>
		 /// 居住地编号
		 /// </summary>
		public int fdUserAddressID
		{
			get{return _fdUserAddressID;}
			set{_fdUserAddressID = value;}
		}
		private string _fdUserAddress = "";
		 /// <summary>
		 /// 居住地 20 nvarchar
		 /// </summary>
		public string fdUserAddress
		{
			get{return _fdUserAddress;}
			set{_fdUserAddress = value;}
		}
		private int _fdUserCurrentSituation = 0;
		 /// <summary>
		 /// 求职状态(1目前正在找工作2半年内无换工作的计划3一年内无换工作的计划4观望有好的机会再考虑5暂时不想找工作)
		 /// </summary>
		public int fdUserCurrentSituation
		{
			get{return _fdUserCurrentSituation;}
			set{_fdUserCurrentSituation = value;}
		}
		private int _fdUserNation = 0;
		 /// <summary>
		 /// 民 族
		 /// </summary>
		public int fdUserNation
		{
			get{return _fdUserNation;}
			set{_fdUserNation = value;}
		}
		private DateTime _fdUserGraDate = DateTime.Now;
		 /// <summary>
		 /// 毕业时间
		 /// </summary>
		public DateTime fdUserGraDate
		{
			get{return _fdUserGraDate;}
			set{_fdUserGraDate = value;}
		}
		private int _fdUserPoliticalState = 0;
		 /// <summary>
		 /// 政治面貌(1群众2团员3党员)
		 /// </summary>
		public int fdUserPoliticalState
		{
			get{return _fdUserPoliticalState;}
			set{_fdUserPoliticalState = value;}
		}
		private int _fdUserDegree = 0;
		 /// <summary>
		 /// 教育程度(1初中2高中3中技4中专5大专6本科7MBA8硕士9博士10其他)
		 /// </summary>
		public int fdUserDegree
		{
			get{return _fdUserDegree;}
			set{_fdUserDegree = value;}
		}
		private int _fdUserHouseAddressID = 0;
		 /// <summary>
		 /// 户口编号
		 /// </summary>
		public int fdUserHouseAddressID
		{
			get{return _fdUserHouseAddressID;}
			set{_fdUserHouseAddressID = value;}
		}
		private string _fdUserHouseAddress = "";
		 /// <summary>
		 /// 户 口 20 nvarchar
		 /// </summary>
		public string fdUserHouseAddress
		{
			get{return _fdUserHouseAddress;}
			set{_fdUserHouseAddress = value;}
		}
		private int _fdUserCountryID = 0;
		 /// <summary>
		 /// 国家地区
		 /// </summary>
		public int fdUserCountryID
		{
			get{return _fdUserCountryID;}
			set{_fdUserCountryID = value;}
		}
		private int _fdUserHeight = 0;
		 /// <summary>
		 /// 身 高
		 /// </summary>
		public int fdUserHeight
		{
			get{return _fdUserHeight;}
			set{_fdUserHeight = value;}
		}
		private string _fdUserPostCode = "";
		 /// <summary>
		 /// 邮 编 6 char
		 /// </summary>
		public string fdUserPostCode
		{
			get{return _fdUserPostCode;}
			set{_fdUserPostCode = value;}
		}
		private string _fdUserContactAddr = "";
		 /// <summary>
		 /// 联系地址 100 nvarchar
		 /// </summary>
		public string fdUserContactAddr
		{
			get{return _fdUserContactAddr;}
			set{_fdUserContactAddr = value;}
		}
		private int _fdUserMarry = 0;
		 /// <summary>
		 /// 婚姻状况(1未婚2已婚)
		 /// </summary>
		public int fdUserMarry
		{
			get{return _fdUserMarry;}
			set{_fdUserMarry = value;}
		}
		private string _fdUserWebsite = "";
		 /// <summary>
		 /// 个人主页 200 varchar
		 /// </summary>
		public string fdUserWebsite
		{
			get{return _fdUserWebsite;}
			set{_fdUserWebsite = value;}
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
