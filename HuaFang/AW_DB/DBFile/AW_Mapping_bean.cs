using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Mapping_bean : Bean_Base
	{
		private int _fdMappID = 0;
		/// <summary>
		/// 模版编号
		/// </summary>
		public int fdMappID
		{
			get{return _fdMappID;}
			set{_fdMappID = value;}
		}

		private int _fdMappTempID = 0;
		/// <summary>
		/// 模版编号
		/// </summary>
		public int fdMappTempID
		{
			get{return _fdMappTempID;}
			set{_fdMappTempID = value;}
		}

		private string _fdMappPath = "";
		/// <summary>
		/// 访问路径 1024 varchar
		/// </summary>
		public string fdMappPath
		{
			get{return _fdMappPath;}
			set{_fdMappPath = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Mapping_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Mapping_bean funcGetByID(string id)
        {
            AW_Mapping_bean bean = new AW_Mapping_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Mapping_bean funcGetByID(int id)
        {
            AW_Mapping_bean bean = new AW_Mapping_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Mapping_bean funcGetByID(string id, string columns)
        {
            AW_Mapping_bean bean = new AW_Mapping_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Mapping_bean funcGetByID(int id, string columns)
        {
            AW_Mapping_bean bean = new AW_Mapping_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
