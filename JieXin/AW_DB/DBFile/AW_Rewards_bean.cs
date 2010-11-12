using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Rewards_bean : Bean_Base
	{
		private int _fdRewaID = 0;
		 /// <summary>
		 /// 奖励编号
		 /// </summary>
		public int fdRewaID
		{
			get{return _fdRewaID;}
			set{_fdRewaID = value;}
		}
		private int _fdRewaResuID = 0;
		 /// <summary>
		 /// 简历编号
		 /// </summary>
		public int fdRewaResuID
		{
			get{return _fdRewaResuID;}
			set{_fdRewaResuID = value;}
		}
		private DateTime _fdRewaBegin = DateTime.Parse("1900-01-01");
		 /// <summary>
		 /// 开始时间
		 /// </summary>
        public DateTime fdRewaBegin
		{
            get{return _fdRewaBegin;}
            set{_fdRewaBegin = value;}
        }
        private DateTime _fdRewaEnd = DateTime.Parse( "1900-01-01" );
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime fdRewaEnd
        {
            get{ return _fdRewaEnd;}
            set{ _fdRewaEnd = value;}
        }
		private string _fdRewaName = "";
		 /// <summary>
		 /// 奖项 100 nvarchar
		 /// </summary>
		public string fdRewaName
		{
			get{return _fdRewaName;}
			set{_fdRewaName = value;}
		}
		private string _fdRewaLevel = "";
		 /// <summary>
		 /// 级别 100 nvarchar
		 /// </summary>
		public string fdRewaLevel
		{
			get{return _fdRewaLevel;}
			set{_fdRewaLevel = value;}
		}
		private int _fdRewaIsShow = 0;
		 /// <summary>
		 /// 是否显示(0:是1:否)
		 /// </summary>
		public int fdRewaIsShow
		{
			get{return _fdRewaIsShow;}
			set{_fdRewaIsShow = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Rewards_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Rewards_bean funcGetByID(string id)
        {
            AW_Rewards_bean bean = new AW_Rewards_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Rewards_bean funcGetByID(int id)
        {
            AW_Rewards_bean bean = new AW_Rewards_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Rewards_bean funcGetByID(string id, string columns)
        {
            AW_Rewards_bean bean = new AW_Rewards_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Rewards_bean funcGetByID(int id, string columns)
        {
            AW_Rewards_bean bean = new AW_Rewards_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
