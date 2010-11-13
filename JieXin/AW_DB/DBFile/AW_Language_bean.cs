using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Language_bean : Bean_Base
	{
		private int _fdLangID = 0;
		 /// <summary>
		 /// 语言能力编号
		 /// </summary>
		public int fdLangID
		{
			get{return _fdLangID;}
			set{_fdLangID = value;}
		}
		private int _fdLangResuID = 0;
		 /// <summary>
		 /// 简历编号
		 /// </summary>
		public int fdLangResuID
		{
			get{return _fdLangResuID;}
			set{_fdLangResuID = value;}
		}
		private int _fdLangType = 0;
		 /// <summary>
		 /// 语言类别
		 /// </summary>
		public int fdLangType
		{
			get{return _fdLangType;}
			set{_fdLangType = value;}
		}
		private int _fdLangMaster = 0;
		 /// <summary>
		 /// 掌握程度
		 /// </summary>
		public int fdLangMaster
		{
			get{return _fdLangMaster;}
			set{_fdLangMaster = value;}
		}
		private int _fdLangRWAbility = 0;
		 /// <summary>
		 /// 读写能力
		 /// </summary>
		public int fdLangRWAbility
		{
			get{return _fdLangRWAbility;}
			set{_fdLangRWAbility = value;}
		}
		private int _fdLangLiAbility = 0;
		 /// <summary>
		 /// 听写能力
		 /// </summary>
		public int fdLangLiAbility
		{
			get{return _fdLangLiAbility;}
			set{_fdLangLiAbility = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Language_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Language_bean funcGetByID(string id)
        {
            AW_Language_bean bean = new AW_Language_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Language_bean funcGetByID(int id)
        {
            AW_Language_bean bean = new AW_Language_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Language_bean funcGetByID(string id, string columns)
        {
            AW_Language_bean bean = new AW_Language_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Language_bean funcGetByID(int id, string columns)
        {
            AW_Language_bean bean = new AW_Language_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
