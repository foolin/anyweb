using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Education_bean : Bean_Base
	{
		private int _fdEducID = 0;
		 /// <summary>
		 /// 教育经历编号
		 /// </summary>
		public int fdEducID
		{
			get{return _fdEducID;}
			set{_fdEducID = value;}
		}
		private int _fdEducResuID = 0;
		 /// <summary>
		 /// 简历编号
		 /// </summary>
		public int fdEducResuID
		{
			get{return _fdEducResuID;}
			set{_fdEducResuID = value;}
		}
		private DateTime _fdEducBegin = DateTime.Parse("1900-01-01");
		 /// <summary>
		 /// 开始时间
		 /// </summary>
		public DateTime fdEducBegin
		{
			get{return _fdEducBegin;}
			set{_fdEducBegin = value;}
		}
        private DateTime _fdEducEnd = DateTime.Parse( "1900-01-01" );
		 /// <summary>
		 /// 结束时间
		 /// </summary>
		public DateTime fdEducEnd
		{
			get{return _fdEducEnd;}
			set{_fdEducEnd = value;}
		}
		private string _fdEducSchool = "";
		 /// <summary>
		 /// 学校 100 nvarchar
		 /// </summary>
		public string fdEducSchool
		{
			get{return _fdEducSchool;}
			set{_fdEducSchool = value;}
		}
		private int _fdEducSpecialityID = 0;
		 /// <summary>
		 /// 专业编号
		 /// </summary>
		public int fdEducSpecialityID
		{
			get{return _fdEducSpecialityID;}
			set{_fdEducSpecialityID = value;}
		}
		private string _fdEducSpeciality = "";
		 /// <summary>
		 /// 专业 40 nvarchar
		 /// </summary>
		public string fdEducSpeciality
		{
			get{return _fdEducSpeciality;}
			set{_fdEducSpeciality = value;}
		}
		private string _fdEducOtherSpecialty = "";
		 /// <summary>
		 /// 其它专业 40 nvarchar
		 /// </summary>
		public string fdEducOtherSpecialty
		{
			get{return _fdEducOtherSpecialty;}
			set{_fdEducOtherSpecialty = value;}
		}
		private int _fdEducDegree = 0;
		 /// <summary>
		 /// 学历(1初中,2高中,3中技,4中专,5大专,6本科,7MBA,8硕士,9博士,10其他)
		 /// </summary>
		public int fdEducDegree
		{
			get{return _fdEducDegree;}
			set{_fdEducDegree = value;}
		}
		private string _fdEducIntro = "";
		 /// <summary>
		 /// 专业描述 4000 nvarchar
		 /// </summary>
		public string fdEducIntro
		{
			get{return _fdEducIntro;}
			set{_fdEducIntro = value;}
		}
		private int _fdEducIsOverSeas = 0;
		 /// <summary>
		 /// 海外学习经历(0:是1:否)
		 /// </summary>
		public int fdEducIsOverSeas
		{
			get{return _fdEducIsOverSeas;}
			set{_fdEducIsOverSeas = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Education_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Education_bean funcGetByID(string id)
        {
            AW_Education_bean bean = new AW_Education_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Education_bean funcGetByID(int id)
        {
            AW_Education_bean bean = new AW_Education_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Education_bean funcGetByID(string id, string columns)
        {
            AW_Education_bean bean = new AW_Education_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Education_bean funcGetByID(int id, string columns)
        {
            AW_Education_bean bean = new AW_Education_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
