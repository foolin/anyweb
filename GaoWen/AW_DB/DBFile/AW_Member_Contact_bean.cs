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
	public partial class AW_Member_Contact_bean : Bean_Base
	{
		private int _fdContID = 0;
		/// <summary>
		/// 联系编号
		/// </summary>
		public int fdContID
		{
			get{return _fdContID;}
			set{_fdContID = value;}
		}

		private int _fdContMemberID = 0;
		/// <summary>
		/// 会员编号
		/// </summary>
		public int fdContMemberID
		{
			get{return _fdContMemberID;}
			set{_fdContMemberID = value;}
		}

		private int _fdContProvinceID = 0;
		/// <summary>
		/// 省份编号
		/// </summary>
		public int fdContProvinceID
		{
			get{return _fdContProvinceID;}
			set{_fdContProvinceID = value;}
        }

		private int _fdContCityID = 0;
		/// <summary>
		/// 城市编号
		/// </summary>
		public int fdContCityID
		{
			get{return _fdContCityID;}
			set{_fdContCityID = value;}
        }

        private int _fdContAreaID;
        /// <summary>
        /// 区域编号
        /// </summary>
        public int fdContAreaID
        {
            get { return _fdContAreaID; }
            set { _fdContAreaID = value; }
        }

		private string _fdContAddress = "";
		/// <summary>
		/// 地址 200 nvarchar
		/// </summary>
		public string fdContAddress
		{
			get{return _fdContAddress;}
			set{_fdContAddress = value;}
		}

		private string _fdContPostcode = "";
		/// <summary>
		/// 邮编 50 varchar
		/// </summary>
		public string fdContPostcode
		{
			get{return _fdContPostcode;}
			set{_fdContPostcode = value;}
		}

		private string _fdContTel = "";
		/// <summary>
		/// 电话 40 nvarchar
		/// </summary>
		public string fdContTel
		{
			get{return _fdContTel;}
			set{_fdContTel = value;}
		}

		private DateTime _fdContCreateAt = DateTime.Now;
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime fdContCreateAt
		{
			get{return _fdContCreateAt;}
			set{_fdContCreateAt = value;}
		}

        private string _fdContName = "";
        /// <summary>
        /// 收货人姓名 20 nvarchar
        /// </summary>
        public string fdContName
        {
            get { return _fdContName; }
            set { _fdContName = value; }
        }



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Member_Contact_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Member_Contact_bean funcGetByID(string id)
        {
            AW_Member_Contact_bean bean = new AW_Member_Contact_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Member_Contact_bean funcGetByID(int id)
        {
            AW_Member_Contact_bean bean = new AW_Member_Contact_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Member_Contact_bean funcGetByID(string id, string columns)
        {
            AW_Member_Contact_bean bean = new AW_Member_Contact_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Member_Contact_bean funcGetByID(int id, string columns)
        {
            AW_Member_Contact_bean bean = new AW_Member_Contact_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
