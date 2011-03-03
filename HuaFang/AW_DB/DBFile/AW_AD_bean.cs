using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_AD_bean : Bean_Base
	{
		private int _fdAdID = 0;
		 /// <summary>
		 /// 广告编号
		 /// </summary>
		public int fdAdID
		{
			get{return _fdAdID;}
			set{_fdAdID = value;}
		}
        private string _fdAdName = "";
        /// <summary>
        /// 广告名称
        /// </summary>
        public string fdAdName
        {
            get { return _fdAdName; }
            set { _fdAdName = value; }
        }
		private string _fdAdPic = "";
		 /// <summary>
		 /// 广告图片 200 varchar
		 /// </summary>
		public string fdAdPic
		{
			get{return _fdAdPic;}
			set{_fdAdPic = value;}
		}
		private string _fdAdLink = "";
		 /// <summary>
		 /// 广告链接 200 varchar
		 /// </summary>
		public string fdAdLink
		{
			get{return _fdAdLink;}
			set{_fdAdLink = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_AD_dao(); 
				}
				return _dao;
			}
        }

        public static AW_AD_bean funcGetByID(string id)
        {
            AW_AD_bean bean = new AW_AD_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_AD_bean funcGetByID(int id)
        {
            AW_AD_bean bean = new AW_AD_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_AD_bean funcGetByID(string id, string columns)
        {
            AW_AD_bean bean = new AW_AD_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_AD_bean funcGetByID(int id, string columns)
        {
            AW_AD_bean bean = new AW_AD_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
