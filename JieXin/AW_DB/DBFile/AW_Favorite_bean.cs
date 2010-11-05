using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Favorite_bean : Bean_Base
	{
		private int _fdFavoID = 0;
		 /// <summary>
		 /// 收藏编号
		 /// </summary>
		public int fdFavoID
		{
			get{return _fdFavoID;}
			set{_fdFavoID = value;}
		}
		private int _fdFavoUserID = 0;
		 /// <summary>
		 /// 会员编号
		 /// </summary>
		public int fdFavoUserID
		{
			get{return _fdFavoUserID;}
			set{_fdFavoUserID = value;}
		}
		private int _fdFavoRecrID = 0;
		 /// <summary>
		 /// 职位编号
		 /// </summary>
		public int fdFavoRecrID
		{
			get{return _fdFavoRecrID;}
			set{_fdFavoRecrID = value;}
		}
		private DateTime _fdFavoCreateAt = DateTime.Now;
		 /// <summary>
		 /// 创建时间
		 /// </summary>
		public DateTime fdFavoCreateAt
		{
			get{return _fdFavoCreateAt;}
			set{_fdFavoCreateAt = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Favorite_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Favorite_bean funcGetByID(string id)
        {
            AW_Favorite_bean bean = new AW_Favorite_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Favorite_bean funcGetByID(int id)
        {
            AW_Favorite_bean bean = new AW_Favorite_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Favorite_bean funcGetByID(string id, string columns)
        {
            AW_Favorite_bean bean = new AW_Favorite_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Favorite_bean funcGetByID(int id, string columns)
        {
            AW_Favorite_bean bean = new AW_Favorite_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
