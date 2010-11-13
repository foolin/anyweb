using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Objective_bean : Bean_Base
	{
		private int _fdObjeID = 0;
		 /// <summary>
		 /// 求职意向编号
		 /// </summary>
		public int fdObjeID
		{
			get{return _fdObjeID;}
			set{_fdObjeID = value;}
		}
		private int _fdObjeResuID = 0;
		 /// <summary>
		 /// 简历编号
		 /// </summary>
		public int fdObjeResuID
		{
			get{return _fdObjeResuID;}
			set{_fdObjeResuID = value;}
		}
		private int _fdObjeType = 0;
		 /// <summary>
		 /// 工作类型
		 /// </summary>
		public int fdObjeType
		{
			get{return _fdObjeType;}
			set{_fdObjeType = value;}
		}
		private int _fdObjeAreaID1 = 0;
		 /// <summary>
		 /// 地点编号
		 /// </summary>
		public int fdObjeAreaID1
		{
			get{return _fdObjeAreaID1;}
			set{_fdObjeAreaID1 = value;}
		}
		private string _fdObjeArea1 = "";
		 /// <summary>
		 /// 地点 20 nvarchar
		 /// </summary>
		public string fdObjeArea1
		{
			get{return _fdObjeArea1;}
			set{_fdObjeArea1 = value;}
		}
		private int _fdObjeAreaID2 = 0;
		 /// <summary>
		 /// 地点编号
		 /// </summary>
		public int fdObjeAreaID2
		{
			get{return _fdObjeAreaID2;}
			set{_fdObjeAreaID2 = value;}
		}
		private string _fdObjeArea2 = "";
		 /// <summary>
		 /// 地点 20 nvarchar
		 /// </summary>
		public string fdObjeArea2
		{
			get{return _fdObjeArea2;}
			set{_fdObjeArea2 = value;}
		}
		private int _fdObjeAreaID3 = 0;
		 /// <summary>
		 /// 地点编号
		 /// </summary>
		public int fdObjeAreaID3
		{
			get{return _fdObjeAreaID3;}
			set{_fdObjeAreaID3 = value;}
		}
		private string _fdObjeArea3 = "";
		 /// <summary>
		 /// 地点 20 nvarchar
		 /// </summary>
		public string fdObjeArea3
		{
			get{return _fdObjeArea3;}
			set{_fdObjeArea3 = value;}
		}
		private int _fdObjeAreaID4 = 0;
		 /// <summary>
		 /// 地点编号
		 /// </summary>
		public int fdObjeAreaID4
		{
			get{return _fdObjeAreaID4;}
			set{_fdObjeAreaID4 = value;}
		}
		private string _fdObjeArea4 = "";
		 /// <summary>
		 /// 地点 20 nvarchar
		 /// </summary>
		public string fdObjeArea4
		{
			get{return _fdObjeArea4;}
			set{_fdObjeArea4 = value;}
		}
		private int _fdObjeAreaID5 = 0;
		 /// <summary>
		 /// 地点编号
		 /// </summary>
		public int fdObjeAreaID5
		{
			get{return _fdObjeAreaID5;}
			set{_fdObjeAreaID5 = value;}
		}
		private string _fdObjeArea5 = "";
		 /// <summary>
		 /// 地点 20 nvarchar
		 /// </summary>
		public string fdObjeArea5
		{
			get{return _fdObjeArea5;}
			set{_fdObjeArea5 = value;}
		}
		private int _fdObjeIndustryID1 = 0;
		 /// <summary>
		 /// 行业编号
		 /// </summary>
		public int fdObjeIndustryID1
		{
			get{return _fdObjeIndustryID1;}
			set{_fdObjeIndustryID1 = value;}
		}
		private string _fdObjeIndustry1 = "";
		 /// <summary>
		 /// 行业 40 nvarchar
		 /// </summary>
		public string fdObjeIndustry1
		{
			get{return _fdObjeIndustry1;}
			set{_fdObjeIndustry1 = value;}
		}
		private int _fdObjeIndustryID2 = 0;
		 /// <summary>
		 /// 行业编号
		 /// </summary>
		public int fdObjeIndustryID2
		{
			get{return _fdObjeIndustryID2;}
			set{_fdObjeIndustryID2 = value;}
		}
		private string _fdObjeIndustry2 = "";
		 /// <summary>
		 /// 行业 40 nvarchar
		 /// </summary>
		public string fdObjeIndustry2
		{
			get{return _fdObjeIndustry2;}
			set{_fdObjeIndustry2 = value;}
		}
		private int _fdObjeIndustryID3 = 0;
		 /// <summary>
		 /// 行业编号
		 /// </summary>
		public int fdObjeIndustryID3
		{
			get{return _fdObjeIndustryID3;}
			set{_fdObjeIndustryID3 = value;}
		}
		private string _fdObjeIndustry3 = "";
		 /// <summary>
		 /// 行业 40 nvarchar
		 /// </summary>
		public string fdObjeIndustry3
		{
			get{return _fdObjeIndustry3;}
			set{_fdObjeIndustry3 = value;}
		}
		private int _fdObjeIndustryID4 = 0;
		 /// <summary>
		 /// 行业编号
		 /// </summary>
		public int fdObjeIndustryID4
		{
			get{return _fdObjeIndustryID4;}
			set{_fdObjeIndustryID4 = value;}
		}
		private string _fdObjeIndustry4 = "";
		 /// <summary>
		 /// 行业 40 nvarchar
		 /// </summary>
		public string fdObjeIndustry4
		{
			get{return _fdObjeIndustry4;}
			set{_fdObjeIndustry4 = value;}
		}
		private int _fdObjeIndustryID5 = 0;
		 /// <summary>
		 /// 行业编号
		 /// </summary>
		public int fdObjeIndustryID5
		{
			get{return _fdObjeIndustryID5;}
			set{_fdObjeIndustryID5 = value;}
		}
		private string _fdObjeIndustry5 = "";
		 /// <summary>
		 /// 行业 40 nvarchar
		 /// </summary>
		public string fdObjeIndustry5
		{
			get{return _fdObjeIndustry5;}
			set{_fdObjeIndustry5 = value;}
		}
		private int _fdObjeFuncTypeID1 = 0;
		 /// <summary>
		 /// 职能编号
		 /// </summary>
		public int fdObjeFuncTypeID1
		{
			get{return _fdObjeFuncTypeID1;}
			set{_fdObjeFuncTypeID1 = value;}
		}
		private string _fdObjecFuncType1 = "";
		 /// <summary>
		 /// 职能 40 nvarchar
		 /// </summary>
		public string fdObjecFuncType1
		{
			get{return _fdObjecFuncType1;}
			set{_fdObjecFuncType1 = value;}
		}
		private int _fdObjeFuncTypeID2 = 0;
		 /// <summary>
		 /// 职能编号
		 /// </summary>
		public int fdObjeFuncTypeID2
		{
			get{return _fdObjeFuncTypeID2;}
			set{_fdObjeFuncTypeID2 = value;}
		}
		private string _fdObjecFuncType2 = "";
		 /// <summary>
		 /// 职能 40 nvarchar
		 /// </summary>
		public string fdObjecFuncType2
		{
			get{return _fdObjecFuncType2;}
			set{_fdObjecFuncType2 = value;}
		}
		private int _fdObjeFuncTypeID3 = 0;
		 /// <summary>
		 /// 职能编号
		 /// </summary>
		public int fdObjeFuncTypeID3
		{
			get{return _fdObjeFuncTypeID3;}
			set{_fdObjeFuncTypeID3 = value;}
		}
		private string _fdObjecFuncType3 = "";
		 /// <summary>
		 /// 职能 40 nvarchar
		 /// </summary>
		public string fdObjecFuncType3
		{
			get{return _fdObjecFuncType3;}
			set{_fdObjecFuncType3 = value;}
		}
		private int _fdObjeFuncTypeID4 = 0;
		 /// <summary>
		 /// 职能编号
		 /// </summary>
		public int fdObjeFuncTypeID4
		{
			get{return _fdObjeFuncTypeID4;}
			set{_fdObjeFuncTypeID4 = value;}
		}
		private string _fdObjecFuncType4 = "";
		 /// <summary>
		 /// 职能 40 nvarchar
		 /// </summary>
		public string fdObjecFuncType4
		{
			get{return _fdObjecFuncType4;}
			set{_fdObjecFuncType4 = value;}
		}
		private int _fdObjeFuncTypeID5 = 0;
		 /// <summary>
		 /// 职能编号
		 /// </summary>
		public int fdObjeFuncTypeID5
		{
			get{return _fdObjeFuncTypeID5;}
			set{_fdObjeFuncTypeID5 = value;}
		}
		private string _fdObjecFuncType5 = "";
		 /// <summary>
		 /// 职能 40 nvarchar
		 /// </summary>
		public string fdObjecFuncType5
		{
			get{return _fdObjecFuncType5;}
			set{_fdObjecFuncType5 = value;}
		}
		private int _fdObjecSalery = 0;
		 /// <summary>
		 /// 期望薪水
		 /// </summary>
		public int fdObjecSalery
		{
			get{return _fdObjecSalery;}
			set{_fdObjecSalery = value;}
		}
		private int _fdObjeEntryTime = 0;
		 /// <summary>
		 /// 到岗时间
		 /// </summary>
		public int fdObjeEntryTime
		{
			get{return _fdObjeEntryTime;}
			set{_fdObjeEntryTime = value;}
		}
		private string _fdObjeDepartment = "";
		 /// <summary>
		 /// 部门 40 nvarchar
		 /// </summary>
		public string fdObjeDepartment
		{
			get{return _fdObjeDepartment;}
			set{_fdObjeDepartment = value;}
		}
		private int _fdObjeCompType = 0;
		 /// <summary>
		 /// 公司性质
		 /// </summary>
		public int fdObjeCompType
		{
			get{return _fdObjeCompType;}
			set{_fdObjeCompType = value;}
		}
		private string _fdObjeIntro = "";
		 /// <summary>
		 /// 自我介绍 1000 nvarchar
		 /// </summary>
		public string fdObjeIntro
		{
			get{return _fdObjeIntro;}
			set{_fdObjeIntro = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Objective_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Objective_bean funcGetByID(string id)
        {
            AW_Objective_bean bean = new AW_Objective_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Objective_bean funcGetByID(int id)
        {
            AW_Objective_bean bean = new AW_Objective_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Objective_bean funcGetByID(string id, string columns)
        {
            AW_Objective_bean bean = new AW_Objective_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Objective_bean funcGetByID(int id, string columns)
        {
            AW_Objective_bean bean = new AW_Objective_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
