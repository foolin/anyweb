using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Goods_Picture_bean : Bean_Base
	{
		private int _fdPictID = 0;
		/// <summary>
		/// 图片编号
		/// </summary>
		public int fdPictID
		{
			get{return _fdPictID;}
			set{_fdPictID = value;}
		}

		private int _fdPictGoodID = 0;
		/// <summary>
		/// 货品编号
		/// </summary>
		public int fdPictGoodID
		{
			get{return _fdPictGoodID;}
			set{_fdPictGoodID = value;}
		}

		private string _fdPictName = "";
		/// <summary>
		/// 图片名称 200 nvarchar
		/// </summary>
		public string fdPictName
		{
			get{return _fdPictName;}
			set{_fdPictName = value;}
		}

		private string _fdPictPath = "";
		/// <summary>
		/// 图片路径 100 varchar
		/// </summary>
		public string fdPictPath
		{
			get{return _fdPictPath;}
			set{_fdPictPath = value;}
		}

		private DateTime _fdPictCreateAt = DateTime.Now;
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime fdPictCreateAt
		{
			get{return _fdPictCreateAt;}
			set{_fdPictCreateAt = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Goods_Picture_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Goods_Picture_bean funcGetByID(string id)
        {
            AW_Goods_Picture_bean bean = new AW_Goods_Picture_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Goods_Picture_bean funcGetByID(int id)
        {
            AW_Goods_Picture_bean bean = new AW_Goods_Picture_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Goods_Picture_bean funcGetByID(string id, string columns)
        {
            AW_Goods_Picture_bean bean = new AW_Goods_Picture_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Goods_Picture_bean funcGetByID(int id, string columns)
        {
            AW_Goods_Picture_bean bean = new AW_Goods_Picture_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
