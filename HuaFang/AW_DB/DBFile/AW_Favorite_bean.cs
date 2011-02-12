using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Favorite_bean : Bean_Base
	{
		private int _fdFavoID = 0;
		/// <summary>
		/// fdFavoID
		/// </summary>
		public int fdFavoID
		{
			get{return _fdFavoID;}
			set{_fdFavoID = value;}
		}

		private int _fdFavoMemberID = 0;
		/// <summary>
		/// fdFavoMemberID
		/// </summary>
		public int fdFavoMemberID
		{
			get{return _fdFavoMemberID;}
			set{_fdFavoMemberID = value;}
		}

		private int _fdFavoGoodsID = 0;
		/// <summary>
		/// fdFavoGoodsID
		/// </summary>
		public int fdFavoGoodsID
		{
			get{return _fdFavoGoodsID;}
			set{_fdFavoGoodsID = value;}
		}

		private DateTime _fdFavoCreateAt = DateTime.Now;
		/// <summary>
		/// fdFavoCreateAt
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
