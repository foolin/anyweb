using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Member_bean : Bean_Base
	{
		private int _fdMembID = 0;
		/// <summary>
		/// 会员编号
		/// </summary>
		public int fdMembID
		{
			get{return _fdMembID;}
			set{_fdMembID = value;}
		}

		private string _fdMembPwd = "";
		/// <summary>
		/// 密码（MD5加密） 50 varchar
		/// </summary>
		public string fdMembPwd
		{
			get{return _fdMembPwd;}
			set{_fdMembPwd = value;}
		}

		private string _fdMembName = "";
		/// <summary>
		/// 昵称 40 nvarchar
		/// </summary>
		public string fdMembName
		{
			get{return _fdMembName;}
			set{_fdMembName = value;}
		}

		private DateTime _fdMembRegAt = DateTime.Now;
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime fdMembRegAt
		{
			get{return _fdMembRegAt;}
			set{_fdMembRegAt = value;}
		}

		private int _fdMembStatus = 0;
		/// <summary>
		/// 状态 1正常 2锁定
		/// </summary>
		public int fdMembStatus
		{
			get{return _fdMembStatus;}
			set{_fdMembStatus = value;}
		}

		private string _fdMembTrueName = "";
		/// <summary>
		/// 真实姓名 100 nvarchar
		/// </summary>
		public string fdMembTrueName
		{
			get{return _fdMembTrueName;}
			set{_fdMembTrueName = value;}
		}

		private int _fdMembSex = 0;
		/// <summary>
		/// 性别 0未知1男2女
		/// </summary>
		public int fdMembSex
		{
			get{return _fdMembSex;}
			set{_fdMembSex = value;}
		}

		private string _fdMembAvator = "";
		/// <summary>
		/// 头像 100 varchar
		/// </summary>
		public string fdMembAvator
		{
			get{return _fdMembAvator;}
			set{_fdMembAvator = value;}
		}

		private string _fdMembAddress = "";
		/// <summary>
		/// 地址 200 nvarchar
		/// </summary>
		public string fdMembAddress
		{
			get{return _fdMembAddress;}
			set{_fdMembAddress = value;}
		}

		private string _fdMembPostcode = "";
		/// <summary>
		/// 邮政编码 10 varchar
		/// </summary>
		public string fdMembPostcode
		{
			get{return _fdMembPostcode;}
			set{_fdMembPostcode = value;}
		}

		private string _fdMembMobile = "";
		/// <summary>
		/// 手机 20 varchar
		/// </summary>
		public string fdMembMobile
		{
			get{return _fdMembMobile;}
			set{_fdMembMobile = value;}
		}

		private string _fdMembPhone = "";
		/// <summary>
		/// 电话 60 nvarchar
		/// </summary>
		public string fdMembPhone
		{
			get{return _fdMembPhone;}
			set{_fdMembPhone = value;}
		}

		private string _fdMembEmail = "";
		/// <summary>
		/// 邮件 50 varchar
		/// </summary>
		public string fdMembEmail
		{
			get{return _fdMembEmail;}
			set{_fdMembEmail = value;}
		}

		private string _fdMembQQ = "";
		/// <summary>
		/// QQ号码 10 varchar
		/// </summary>
		public string fdMembQQ
		{
			get{return _fdMembQQ;}
			set{_fdMembQQ = value;}
		}

		private string _fdMembMSN = "";
		/// <summary>
		/// MSN号码 50 varchar
		/// </summary>
		public string fdMembMSN
		{
			get{return _fdMembMSN;}
			set{_fdMembMSN = value;}
		}

		private string _fdMembOtherContact = "";
		/// <summary>
		/// 其他联系方式 200 varchar
		/// </summary>
		public string fdMembOtherContact
		{
			get{return _fdMembOtherContact;}
			set{_fdMembOtherContact = value;}
		}

		private int _fdMembPoint = 0;
		/// <summary>
		/// 积分
		/// </summary>
		public int fdMembPoint
		{
			get{return _fdMembPoint;}
			set{_fdMembPoint = value;}
		}

		private int _fdMembProvinceID = 0;
		/// <summary>
		/// 省份
		/// </summary>
		public int fdMembProvinceID
		{
			get{return _fdMembProvinceID;}
			set{_fdMembProvinceID = value;}
		}

		private int _fdMembCityID = 0;
		/// <summary>
		/// 城市
		/// </summary>
		public int fdMembCityID
		{
			get{return _fdMembCityID;}
			set{_fdMembCityID = value;}
        }

        private int _fdMembAreaID = 0;
        /// <summary>
        /// 区域，例如天河区
        /// </summary>
        public int fdMembAreaID
        {
            get { return _fdMembAreaID; }
            set { _fdMembAreaID = value; }
        }

        private string _fdMembBirthday = "";//(1900)-(1))-(1
		/// <summary>
		/// 生日 10 varchar
		/// </summary>
		public string fdMembBirthday
		{
			get{return _fdMembBirthday;}
			set{_fdMembBirthday = value;}
		}

		private DateTime _fdMembLoginAt = DateTime.Now;
		/// <summary>
		/// 登录时间
		/// </summary>
		public DateTime fdMembLoginAt
		{
			get{return _fdMembLoginAt;}
			set{_fdMembLoginAt = value;}
		}

		private string _fdMembLoginIP = "127.0.0.1";
		/// <summary>
		/// 登录IP 15 varchar
		/// </summary>
		public string fdMembLoginIP
		{
			get{return _fdMembLoginIP;}
			set{_fdMembLoginIP = value;}
		}

		private DateTime _fdMembUpdateAt = DateTime.Now;
		/// <summary>
		/// 更新时间
		/// </summary>
		public DateTime fdMembUpdateAt
		{
			get{return _fdMembUpdateAt;}
			set{_fdMembUpdateAt = value;}
		}

		private string _fdMembPwdQuestion = "";
		/// <summary>
		/// 忘记密码问题 100 nvarchar
		/// </summary>
		public string fdMembPwdQuestion
		{
			get{return _fdMembPwdQuestion;}
			set{_fdMembPwdQuestion = value;}
		}

		private string _fdMembPwdAnswer = "";
		/// <summary>
		/// 忘记密码答案 100 nvarchar
		/// </summary>
		public string fdMembPwdAnswer
		{
			get{return _fdMembPwdAnswer;}
			set{_fdMembPwdAnswer = value;}
		}

        private int _fdMembRegType = 1;
        /// <summary>
        /// 注册类型:1邮件 2手机
        /// </summary>
        public int fdMembRegType
        {
            get { return _fdMembRegType; }
            set { _fdMembRegType = value; }
        }



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Member_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Member_bean funcGetByID(string id)
        {
            AW_Member_bean bean = new AW_Member_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Member_bean funcGetByID(int id)
        {
            AW_Member_bean bean = new AW_Member_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Member_bean funcGetByID(string id, string columns)
        {
            AW_Member_bean bean = new AW_Member_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Member_bean funcGetByID(int id, string columns)
        {
            AW_Member_bean bean = new AW_Member_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
