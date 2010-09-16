using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Area_bean : Bean_Base
	{
		private int _fdAreaID = 0;
		 /// <summary>
		 /// 地点编号
		 /// </summary>
		public int fdAreaID
		{
			get{return _fdAreaID;}
			set{_fdAreaID = value;}
		}
		private string _fdAreaName = "";
		 /// <summary>
		 /// 地点名称 100 nvarchar
		 /// </summary>
		public string fdAreaName
		{
			get{return _fdAreaName;}
			set{_fdAreaName = value;}
		}
		private int _fdAreaParent = 0;
		 /// <summary>
		 /// 父级编号
		 /// </summary>
		public int fdAreaParent
		{
			get{return _fdAreaParent;}
			set{_fdAreaParent = value;}
		}
		private int _fdAreaOrder = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdAreaOrder
		{
			get{return _fdAreaOrder;}
			set{_fdAreaOrder = value;}
		}
		private int _fdAreaIsHot = 0;
		 /// <summary>
		 /// 主要城市
		 /// </summary>
		public int fdAreaIsHot
		{
			get{return _fdAreaIsHot;}
			set{_fdAreaIsHot = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Area_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Area_bean funcGetByID(string id)
        {
            AW_Area_bean bean = new AW_Area_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Area_bean funcGetByID(int id)
        {
            AW_Area_bean bean = new AW_Area_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Area_bean funcGetByID(string id, string columns)
        {
            AW_Area_bean bean = new AW_Area_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Area_bean funcGetByID(int id, string columns)
        {
            AW_Area_bean bean = new AW_Area_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
