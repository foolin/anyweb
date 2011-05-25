using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Publish_bean : Bean_Base
	{
		private int _fdPublID = 0;
		 /// <summary>
		 /// 发布编号
		 /// </summary>
		public int fdPublID
		{
			get{return _fdPublID;}
			set{_fdPublID = value;}
		}
		private string _fdPublName = "";
		 /// <summary>
		 /// 发布名称 200 nvarchar
		 /// </summary>
		public string fdPublName
		{
			get{return _fdPublName;}
			set{_fdPublName = value;}
		}
		private int _fdPublAdminID = 0;
		 /// <summary>
		 /// 创建者编号
		 /// </summary>
		public int fdPublAdminID
		{
			get{return _fdPublAdminID;}
			set{_fdPublAdminID = value;}
		}
		private DateTime _fdPublCreateAt = DateTime.Now;
		 /// <summary>
		 /// 创建时间
		 /// </summary>
		public DateTime fdPublCreateAt
		{
			get{return _fdPublCreateAt;}
			set{_fdPublCreateAt = value;}
		}
		private DateTime _fdPublStartAt = DateTime.Now;
		 /// <summary>
		 /// 开始时间
		 /// </summary>
		public DateTime fdPublStartAt
		{
			get{return _fdPublStartAt;}
			set{_fdPublStartAt = value;}
		}
		private DateTime _fdPublFinishAt = DateTime.Now;
		 /// <summary>
		 /// 结束时间
		 /// </summary>
		public DateTime fdPublFinishAt
		{
			get{return _fdPublFinishAt;}
			set{_fdPublFinishAt = value;}
		}
		private int _fdPublStatus = 0;
		 /// <summary>
		 /// 发布状态(0创建1运行中2完成3失败)
		 /// </summary>
		public int fdPublStatus
		{
			get{return _fdPublStatus;}
			set{_fdPublStatus = value;}
		}
		private string _fdPublError = "";
		 /// <summary>
		 /// 错误信息 1000 nvarchar
		 /// </summary>
		public string fdPublError
		{
			get{return _fdPublError;}
			set{_fdPublError = value;}
		}
		private int _fdPublObjType = 0;
		 /// <summary>
		 /// 对象类型
		 /// </summary>
		public int fdPublObjType
		{
			get{return _fdPublObjType;}
			set{_fdPublObjType = value;}
		}
		private int _fdPublObjID = 0;
		 /// <summary>
		 /// 对象编号
		 /// </summary>
		public int fdPublObjID
		{
			get{return _fdPublObjID;}
			set{_fdPublObjID = value;}
		}
		private int _fdPublType = 0;
		 /// <summary>
		 /// 发布类型(1发布首页2增量发布3完全发布)
		 /// </summary>
		public int fdPublType
		{
			get{return _fdPublType;}
			set{_fdPublType = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Publish_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Publish_bean funcGetByID(string id)
        {
            AW_Publish_bean bean = new AW_Publish_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Publish_bean funcGetByID(int id)
        {
            AW_Publish_bean bean = new AW_Publish_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Publish_bean funcGetByID(string id, string columns)
        {
            AW_Publish_bean bean = new AW_Publish_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Publish_bean funcGetByID(int id, string columns)
        {
            AW_Publish_bean bean = new AW_Publish_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
