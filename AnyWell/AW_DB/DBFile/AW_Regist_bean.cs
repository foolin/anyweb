using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Regist_bean : Bean_Base
	{
		private int _fdRegiID = 0;
		 /// <summary>
		 /// 编号
		 /// </summary>
		public int fdRegiID
		{
			get{return _fdRegiID;}
			set{_fdRegiID = value;}
		}
		private int _fdRegiSiteID = 0;
		 /// <summary>
		 /// 站点编号
		 /// </summary>
		public int fdRegiSiteID
		{
			get{return _fdRegiSiteID;}
			set{_fdRegiSiteID = value;}
		}
		private int _fdRegiAppellation = 0;
		 /// <summary>
		 /// 称谓
		 /// </summary>
		public int fdRegiAppellation
		{
			get{return _fdRegiAppellation;}
			set{_fdRegiAppellation = value;}
		}
		private string _fdRegiSurname = "";
		 /// <summary>
		 /// 姓 10 nvarchar
		 /// </summary>
		public string fdRegiSurname
		{
			get{return _fdRegiSurname;}
			set{_fdRegiSurname = value;}
		}
		private string _fdRegiName = "";
		 /// <summary>
		 /// 名 10 nvarchar
		 /// </summary>
		public string fdRegiName
		{
			get{return _fdRegiName;}
			set{_fdRegiName = value;}
		}
		private string _fdRegiPosition = "";
		 /// <summary>
		 /// 职务 20 nvarchar
		 /// </summary>
		public string fdRegiPosition
		{
			get{return _fdRegiPosition;}
			set{_fdRegiPosition = value;}
		}
		private int _fdRegiPositionType = 0;
		 /// <summary>
		 /// 职务类型
		 /// </summary>
		public int fdRegiPositionType
		{
			get{return _fdRegiPositionType;}
			set{_fdRegiPositionType = value;}
		}
		private string _fdRegiCompany = "";
		 /// <summary>
		 /// 公司名称 30 nvarchar
		 /// </summary>
		public string fdRegiCompany
		{
			get{return _fdRegiCompany;}
			set{_fdRegiCompany = value;}
		}
		private string _fdRegiAddress = "";
		 /// <summary>
		 /// 通讯地址 50 nvarchar
		 /// </summary>
		public string fdRegiAddress
		{
			get{return _fdRegiAddress;}
			set{_fdRegiAddress = value;}
		}
		private int _fdRegiCountry = 0;
		 /// <summary>
		 /// 国家
		 /// </summary>
		public int fdRegiCountry
		{
			get{return _fdRegiCountry;}
			set{_fdRegiCountry = value;}
		}
		private string _fdRegiPost = "";
		 /// <summary>
		 /// 邮编 10 varchar
		 /// </summary>
		public string fdRegiPost
		{
			get{return _fdRegiPost;}
			set{_fdRegiPost = value;}
		}
		private string _fdRegiPhone = "";
		 /// <summary>
		 /// 电话 10 varchar
		 /// </summary>
		public string fdRegiPhone
		{
			get{return _fdRegiPhone;}
			set{_fdRegiPhone = value;}
		}
		private string _fdRegiFax = "";
		 /// <summary>
		 /// 传真 10 varchar
		 /// </summary>
		public string fdRegiFax
		{
			get{return _fdRegiFax;}
			set{_fdRegiFax = value;}
		}
		private string _fdRegiMobile = "";
		 /// <summary>
		 /// 手机 10 varchar
		 /// </summary>
		public string fdRegiMobile
		{
			get{return _fdRegiMobile;}
			set{_fdRegiMobile = value;}
		}
		private string _fdRegiEmail = "";
		 /// <summary>
		 /// 电子邮箱 15 varchar
		 /// </summary>
		public string fdRegiEmail
		{
			get{return _fdRegiEmail;}
			set{_fdRegiEmail = value;}
		}
		private string _fdRegiWebSite = "";
		 /// <summary>
		 /// 网址 50 varchar
		 /// </summary>
		public string fdRegiWebSite
		{
			get{return _fdRegiWebSite;}
			set{_fdRegiWebSite = value;}
		}
		private string _fdRegiBusiness = "";
		 /// <summary>
		 /// 业务类型 50 nvarchar
		 /// </summary>
		public string fdRegiBusiness
		{
			get{return _fdRegiBusiness;}
			set{_fdRegiBusiness = value;}
		}
		private string _fdRegiTarget1 = "";
		 /// <summary>
		 /// 黑色家电 50 nvarchar
		 /// </summary>
		public string fdRegiTarget1
		{
			get{return _fdRegiTarget1;}
			set{_fdRegiTarget1 = value;}
		}
		private string _fdRegiTarget2 = "";
		 /// <summary>
		 /// 白色家电 50 nvarchar
		 /// </summary>
		public string fdRegiTarget2
		{
			get{return _fdRegiTarget2;}
			set{_fdRegiTarget2 = value;}
		}
		private string _fdRegiTarget3 = "";
		 /// <summary>
		 /// 小家电 50 nvarchar
		 /// </summary>
		public string fdRegiTarget3
		{
			get{return _fdRegiTarget3;}
			set{_fdRegiTarget3 = value;}
		}
		private string _fdRegiTarget4 = "";
		 /// <summary>
		 /// 厨房及浴室家电 50 nvarchar
		 /// </summary>
		public string fdRegiTarget4
		{
			get{return _fdRegiTarget4;}
			set{_fdRegiTarget4 = value;}
		}
		private string _fdRegiTarget5 = "";
		 /// <summary>
		 /// 家电配件 50 nvarchar
		 /// </summary>
		public string fdRegiTarget5
		{
			get{return _fdRegiTarget5;}
			set{_fdRegiTarget5 = value;}
		}
		private string _fdRegiTarget6 = "";
		 /// <summary>
		 /// 服务及刊物 50 nvarchar
		 /// </summary>
		public string fdRegiTarget6
		{
			get{return _fdRegiTarget6;}
			set{_fdRegiTarget6 = value;}
		}
		private string _fdRegiFunction = "";
		 /// <summary>
		 /// fdRegiFunction 50 nvarchar
		 /// </summary>
		public string fdRegiFunction
		{
			get{return _fdRegiFunction;}
			set{_fdRegiFunction = value;}
		}
		private string _fdRegiPurpose = "";
		 /// <summary>
		 /// 目的 50 nvarchar
		 /// </summary>
		public string fdRegiPurpose
		{
			get{return _fdRegiPurpose;}
			set{_fdRegiPurpose = value;}
		}
		private int _fdRegiDecision = 0;
		 /// <summary>
		 /// 是否决策
		 /// </summary>
		public int fdRegiDecision
		{
			get{return _fdRegiDecision;}
			set{_fdRegiDecision = value;}
		}
		private int _fdRegiBudget = 0;
		 /// <summary>
		 /// 采购预算
		 /// </summary>
		public int fdRegiBudget
		{
			get{return _fdRegiBudget;}
			set{_fdRegiBudget = value;}
		}
		private string _fdRegiFrom = "";
		 /// <summary>
		 /// 获知渠道 50 nvarchar
		 /// </summary>
		public string fdRegiFrom
		{
			get{return _fdRegiFrom;}
			set{_fdRegiFrom = value;}
		}
		private int _fdRegiInterest = 0;
		 /// <summary>
		 /// 是否感兴趣
		 /// </summary>
		public int fdRegiInterest
		{
			get{return _fdRegiInterest;}
			set{_fdRegiInterest = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Regist_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Regist_bean funcGetByID(string id)
        {
            AW_Regist_bean bean = new AW_Regist_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Regist_bean funcGetByID(int id)
        {
            AW_Regist_bean bean = new AW_Regist_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Regist_bean funcGetByID(string id, string columns)
        {
            AW_Regist_bean bean = new AW_Regist_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Regist_bean funcGetByID(int id, string columns)
        {
            AW_Regist_bean bean = new AW_Regist_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
