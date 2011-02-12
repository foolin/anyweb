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
	public partial class AW_Goods_Brand_bean : Bean_Base
	{
		private int _fdGoBrID = 0;
		/// <summary>
		/// 关系编号
		/// </summary>
		public int fdGoBrID
		{
			get{return _fdGoBrID;}
			set{_fdGoBrID = value;}
		}

		private int _fdGoBrGoodsID = 0;
		/// <summary>
		/// 商品编号
		/// </summary>
		public int fdGoBrGoodsID
		{
			get{return _fdGoBrGoodsID;}
			set{_fdGoBrGoodsID = value;}
		}

		private int _fdGoBrBrandID = 0;
		/// <summary>
		/// 品牌编号
		/// </summary>
		public int fdGoBrBrandID
		{
			get{return _fdGoBrBrandID;}
			set{_fdGoBrBrandID = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Goods_Brand_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Goods_Brand_bean funcGetByID(string id)
        {
            AW_Goods_Brand_bean bean = new AW_Goods_Brand_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Goods_Brand_bean funcGetByID(int id)
        {
            AW_Goods_Brand_bean bean = new AW_Goods_Brand_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Goods_Brand_bean funcGetByID(string id, string columns)
        {
            AW_Goods_Brand_bean bean = new AW_Goods_Brand_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Goods_Brand_bean funcGetByID(int id, string columns)
        {
            AW_Goods_Brand_bean bean = new AW_Goods_Brand_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
