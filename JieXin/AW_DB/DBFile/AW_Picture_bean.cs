using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Picture_bean : Bean_Base
	{
		private int _fdPictID = 0;
		 /// <summary>
		 /// 企业图片广告编号
		 /// </summary>
		public int fdPictID
		{
			get{return _fdPictID;}
			set{_fdPictID = value;}
		}
		private string _fdPictName = "";
		 /// <summary>
		 /// 企业名称 100 nvarchar
		 /// </summary>
		public string fdPictName
		{
			get{return _fdPictName;}
			set{_fdPictName = value;}
		}
		private string _fdPictPath = "";
		 /// <summary>
		 /// 图片路径
		 /// </summary>
		public string fdPictPath
		{
			get{return _fdPictPath;}
			set{_fdPictPath = value;}
		}
		private string _fdPictUrl = "";
		 /// <summary>
		 /// 企业链接 200 varchar
		 /// </summary>
		public string fdPictUrl
		{
			get{return _fdPictUrl;}
			set{_fdPictUrl = value;}
		}
		private int _fdPictOrder = 0;
		 /// <summary>
		 /// 排序
		 /// </summary>
		public int fdPictOrder
		{
			get{return _fdPictOrder;}
			set{_fdPictOrder = value;}
		}
		private int _fdPictType = 0;
		 /// <summary>
		 /// 图片类型：1大型图片2中型图片3大型图片
		 /// </summary>
		public int fdPictType
		{
			get{return _fdPictType;}
			set{_fdPictType = value;}
		}


		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Picture_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Picture_bean funcGetByID(string id)
        {
            AW_Picture_bean bean = new AW_Picture_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Picture_bean funcGetByID(int id)
        {
            AW_Picture_bean bean = new AW_Picture_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Picture_bean funcGetByID(string id, string columns)
        {
            AW_Picture_bean bean = new AW_Picture_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Picture_bean funcGetByID(int id, string columns)
        {
            AW_Picture_bean bean = new AW_Picture_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
