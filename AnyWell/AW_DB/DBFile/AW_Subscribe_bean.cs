using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Subscribe_bean : Bean_Base
	{
		private int _fdSubsID = 0;
		 /// <summary>
		 /// 订阅编号
		 /// </summary>
		public int fdSubsID
		{
			get{return _fdSubsID;}
			set{_fdSubsID = value;}
		}
		private int _fdSubsSiteID = 0;
		 /// <summary>
		 /// 站点编号
		 /// </summary>
		public int fdSubsSiteID
		{
			get{return _fdSubsSiteID;}
			set{_fdSubsSiteID = value;}
		}
		private string _fdSubsCompany = "";
		 /// <summary>
		 /// 公司名 100 nvarchar
		 /// </summary>
		public string fdSubsCompany
		{
			get{return _fdSubsCompany;}
			set{_fdSubsCompany = value;}
		}
		private string _fdSubsSurname = "";
		 /// <summary>
		 /// 姓氏 10 nvarchar
		 /// </summary>
		public string fdSubsSurname
		{
			get{return _fdSubsSurname;}
			set{_fdSubsSurname = value;}
		}
		private string _fdSubsName = "";
		 /// <summary>
		 /// 名称 10 nvarchar
		 /// </summary>
		public string fdSubsName
		{
			get{return _fdSubsName;}
			set{_fdSubsName = value;}
		}
		private string _fdSubsEmail = "";
		 /// <summary>
		 /// 电子邮件 25 varchar
		 /// </summary>
		public string fdSubsEmail
		{
			get{return _fdSubsEmail;}
			set{_fdSubsEmail = value;}
		}
        private int _fdSubsSort = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
        public int fdSubsSort
		{
            get { return _fdSubsSort; }
            set { _fdSubsSort = value; }
		}
        


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Subscribe_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Subscribe_bean funcGetByID(string id)
        {
            AW_Subscribe_bean bean = new AW_Subscribe_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Subscribe_bean funcGetByID(int id)
        {
            AW_Subscribe_bean bean = new AW_Subscribe_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Subscribe_bean funcGetByID(string id, string columns)
        {
            AW_Subscribe_bean bean = new AW_Subscribe_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Subscribe_bean funcGetByID(int id, string columns)
        {
            AW_Subscribe_bean bean = new AW_Subscribe_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
