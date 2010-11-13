using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Cert_bean : Bean_Base
	{
		private int _fdCertID = 0;
		 /// <summary>
		 /// 证书编号
		 /// </summary>
		public int fdCertID
		{
			get{return _fdCertID;}
			set{_fdCertID = value;}
		}
		private int _fdCertResuID = 0;
		 /// <summary>
		 /// 简历编号
		 /// </summary>
		public int fdCertResuID
		{
			get{return _fdCertResuID;}
			set{_fdCertResuID = value;}
		}
		private DateTime _fdCertDate = DateTime.Parse("1900-01-01");
		 /// <summary>
		 /// 获得时间
		 /// </summary>
		public DateTime fdCertDate
		{
			get{return _fdCertDate;}
			set{_fdCertDate = value;}
		}
		private string _fdCertName = "";
		 /// <summary>
		 /// 证书名称 100 nvarchar
		 /// </summary>
		public string fdCertName
		{
			get{return _fdCertName;}
			set{_fdCertName = value;}
		}
		private int _fdCertScore = 0;
		 /// <summary>
		 /// 成绩
		 /// </summary>
		public int fdCertScore
		{
			get{return _fdCertScore;}
			set{_fdCertScore = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Cert_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Cert_bean funcGetByID(string id)
        {
            AW_Cert_bean bean = new AW_Cert_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Cert_bean funcGetByID(int id)
        {
            AW_Cert_bean bean = new AW_Cert_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Cert_bean funcGetByID(string id, string columns)
        {
            AW_Cert_bean bean = new AW_Cert_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Cert_bean funcGetByID(int id, string columns)
        {
            AW_Cert_bean bean = new AW_Cert_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
