using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Skill_bean : Bean_Base
	{
		private int _fdSkilID = 0;
		 /// <summary>
		 /// 技能编号
		 /// </summary>
		public int fdSkilID
		{
			get{return _fdSkilID;}
			set{_fdSkilID = value;}
		}
		private string _fdSkilName = "";
		 /// <summary>
		 /// 技能名称 100 nvarchar
		 /// </summary>
		public string fdSkilName
		{
			get{return _fdSkilName;}
			set{_fdSkilName = value;}
		}
		private int _fdSkilParent = 0;
		 /// <summary>
		 /// 父级编号
		 /// </summary>
		public int fdSkilParent
		{
			get{return _fdSkilParent;}
			set{_fdSkilParent = value;}
		}
		private int _fdSkilOrder = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdSkilOrder
		{
			get{return _fdSkilOrder;}
			set{_fdSkilOrder = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Skill_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Skill_bean funcGetByID(string id)
        {
            AW_Skill_bean bean = new AW_Skill_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Skill_bean funcGetByID(int id)
        {
            AW_Skill_bean bean = new AW_Skill_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Skill_bean funcGetByID(string id, string columns)
        {
            AW_Skill_bean bean = new AW_Skill_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Skill_bean funcGetByID(int id, string columns)
        {
            AW_Skill_bean bean = new AW_Skill_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
