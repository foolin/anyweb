using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Tag_Associated_bean : Bean_Base
	{
		private int _fdTaAsID = 0;
		 /// <summary>
		 /// 标签关联编号
		 /// </summary>
		public int fdTaAsID
		{
			get{return _fdTaAsID;}
			set{_fdTaAsID = value;}
		}
		private int _fdTaAsTagID = 0;
		 /// <summary>
		 /// 标签编号
		 /// </summary>
		public int fdTaAsTagID
		{
			get{return _fdTaAsTagID;}
			set{_fdTaAsTagID = value;}
		}
		private int _fdTaAsDataID = 0;
		 /// <summary>
		 /// 文章/产品编号
		 /// </summary>
		public int fdTaAsDataID
		{
			get{return _fdTaAsDataID;}
			set{_fdTaAsDataID = value;}
		}
		private int _fdTaAsType = 0;
		 /// <summary>
		 /// 关联类型(0文章1产品)
		 /// </summary>
		public int fdTaAsType
		{
			get{return _fdTaAsType;}
			set{_fdTaAsType = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Tag_Associated_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Tag_Associated_bean funcGetByID(string id)
        {
            AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Tag_Associated_bean funcGetByID(int id)
        {
            AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Tag_Associated_bean funcGetByID(string id, string columns)
        {
            AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Tag_Associated_bean funcGetByID(int id, string columns)
        {
            AW_Tag_Associated_bean bean = new AW_Tag_Associated_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
