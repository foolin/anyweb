using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Position_bean : Bean_Base
	{
		private int _fdPosiID = 0;
		 /// <summary>
		 /// 职务编号
		 /// </summary>
		public int fdPosiID
		{
			get{return _fdPosiID;}
			set{_fdPosiID = value;}
		}
		private int _fdPosiResuID = 0;
		 /// <summary>
		 /// 简历编号
		 /// </summary>
		public int fdPosiResuID
		{
			get{return _fdPosiResuID;}
			set{_fdPosiResuID = value;}
		}
		private DateTime _fdPosiBegin = DateTime.Parse("1900-01-01");
		 /// <summary>
		 /// 开始时间
		 /// </summary>
		public DateTime fdPosiBegin
		{
			get{return _fdPosiBegin;}
			set{_fdPosiBegin = value;}
		}
        private DateTime _fdPosiEnd = DateTime.Parse( "1900-01-01" );
		 /// <summary>
		 /// 结束时间
		 /// </summary>
		public DateTime fdPosiEnd
		{
			get{return _fdPosiEnd;}
			set{_fdPosiEnd = value;}
		}
		private string _fdPosiName = "";
		 /// <summary>
		 /// 职务名称 100 nvarchar
		 /// </summary>
		public string fdPosiName
		{
			get{return _fdPosiName;}
			set{_fdPosiName = value;}
		}
		private string _fdPosiOrg = "";
		 /// <summary>
		 /// 单位 100 nvarchar
		 /// </summary>
		public string fdPosiOrg
		{
			get{return _fdPosiOrg;}
			set{_fdPosiOrg = value;}
		}
		private string _fdPosiIntro = "";
		 /// <summary>
		 /// 职位描述 4000 nvarchar
		 /// </summary>
		public string fdPosiIntro
		{
			get{return _fdPosiIntro;}
			set{_fdPosiIntro = value;}
		}
		private int _fdPosiIsShow = 0;
		 /// <summary>
		 /// 是否显示(0:是1:否)
		 /// </summary>
		public int fdPosiIsShow
		{
			get{return _fdPosiIsShow;}
			set{_fdPosiIsShow = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Position_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Position_bean funcGetByID(string id)
        {
            AW_Position_bean bean = new AW_Position_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Position_bean funcGetByID(int id)
        {
            AW_Position_bean bean = new AW_Position_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Position_bean funcGetByID(string id, string columns)
        {
            AW_Position_bean bean = new AW_Position_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Position_bean funcGetByID(int id, string columns)
        {
            AW_Position_bean bean = new AW_Position_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
