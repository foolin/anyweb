using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Company_bean : Bean_Base
	{
		private int _fdCompID = 0;
		 /// <summary>
		 /// 企业编号
		 /// </summary>
		public int fdCompID
		{
			get{return _fdCompID;}
			set{_fdCompID = value;}
		}
		private string _fdCompAccount = "";
		 /// <summary>
		 /// 企业帐号 50 varchar
		 /// </summary>
		public string fdCompAccount
		{
			get{return _fdCompAccount;}
			set{_fdCompAccount = value;}
		}
		private string _fdCompPwd = "";
		 /// <summary>
		 /// 企业密码 50 varchar
		 /// </summary>
		public string fdCompPwd
		{
			get{return _fdCompPwd;}
			set{_fdCompPwd = value;}
		}
		private string _fdCompName = "";
		 /// <summary>
		 /// 企业名 200 nvarchar
		 /// </summary>
		public string fdCompName
		{
			get{return _fdCompName;}
			set{_fdCompName = value;}
		}
		private int _fdCompCity = 0;
		 /// <summary>
		 /// 所在地
		 /// </summary>
		public int fdCompCity
		{
			get{return _fdCompCity;}
			set{_fdCompCity = value;}
		}
		private string _fdCompAddress = "";
		 /// <summary>
		 /// 公司地址 400 nvarchar
		 /// </summary>
		public string fdCompAddress
		{
			get{return _fdCompAddress;}
			set{_fdCompAddress = value;}
		}
		private string _fdCompEmail = "";
		 /// <summary>
		 /// 公司邮箱 50 varchar
		 /// </summary>
		public string fdCompEmail
		{
			get{return _fdCompEmail;}
			set{_fdCompEmail = value;}
		}
		private int _fdCompInduID = 0;
		 /// <summary>
		 /// 公司行业编号
		 /// </summary>
		public int fdCompInduID
		{
			get{return _fdCompInduID;}
			set{_fdCompInduID = value;}
		}
		private int _fdCompCateID = 0;
		 /// <summary>
		 /// 公司类型
		 /// </summary>
		public int fdCompCateID
		{
			get{return _fdCompCateID;}
			set{_fdCompCateID = value;}
		}
		private int _fdCompDimension = 0;
		 /// <summary>
		 /// 公司规模
		 /// </summary>
		public int fdCompDimension
		{
			get{return _fdCompDimension;}
			set{_fdCompDimension = value;}
		}
		private string _fdCompIntro = "";
		 /// <summary>
		 /// 公司简介
		 /// </summary>
		public string fdCompIntro
		{
			get{return _fdCompIntro;}
			set{_fdCompIntro = value;}
		}
		private string _fdCompContact = "";
		 /// <summary>
		 /// 联系人 100 nvarchar
		 /// </summary>
		public string fdCompContact
		{
			get{return _fdCompContact;}
			set{_fdCompContact = value;}
		}
		private string _fdCompPhone = "";
		 /// <summary>
		 /// 联系电话 50 varchar
		 /// </summary>
		public string fdCompPhone
		{
			get{return _fdCompPhone;}
			set{_fdCompPhone = value;}
		}
		private string _fdCompWebsite = "";
		 /// <summary>
		 /// 公司网站 200 varchar
		 /// </summary>
		public string fdCompWebsite
		{
			get{return _fdCompWebsite;}
			set{_fdCompWebsite = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Company_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Company_bean funcGetByID(string id)
        {
            AW_Company_bean bean = new AW_Company_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Company_bean funcGetByID(int id)
        {
            AW_Company_bean bean = new AW_Company_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Company_bean funcGetByID(string id, string columns)
        {
            AW_Company_bean bean = new AW_Company_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Company_bean funcGetByID(int id, string columns)
        {
            AW_Company_bean bean = new AW_Company_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
