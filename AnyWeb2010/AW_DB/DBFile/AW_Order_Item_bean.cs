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
	public partial class AW_Order_Item_bean : Bean_Base
	{
		private int _fdItemID = 0;
		/// <summary>
		/// 订单项编号
		/// </summary>
		public int fdItemID
		{
			get{return _fdItemID;}
			set{_fdItemID = value;}
		}

		private int _fdItemOrderID = 0;
		/// <summary>
		/// 订单编号
		/// </summary>
		public int fdItemOrderID
		{
			get{return _fdItemOrderID;}
			set{_fdItemOrderID = value;}
		}

		private int _fdItemGoodsID = 0;
		/// <summary>
		/// 货品编号
		/// </summary>
		public int fdItemGoodsID
		{
			get{return _fdItemGoodsID;}
			set{_fdItemGoodsID = value;}
		}

		private float _fdItemGoodsPrice = 0;
		/// <summary>
		/// 商品价格=商品单价（促销期间用促销价）*数量
		/// </summary>
		public float fdItemGoodsPrice
		{
			get{return _fdItemGoodsPrice;}
			set{_fdItemGoodsPrice = value;}
		}

		private int _fdItemQuantity = 0;
		/// <summary>
		/// 数量
		/// </summary>
		public int fdItemQuantity
		{
			get{return _fdItemQuantity;}
			set{_fdItemQuantity = value;}
		}

		private int _fdItemStatus = 0;
		/// <summary>
		/// 状态
		/// </summary>
		public int fdItemStatus
		{
			get{return _fdItemStatus;}
			set{_fdItemStatus = value;}
		}



		/////////////////////////////////////////
		
		Dao_Base _dao = null;
		protected override Dao_Base dao
        {
            get { 
				if( _dao == null)
				{
					_dao = new AW_Order_Item_dao(); 
				}
				return _dao;
			}
        }

        public static AW_Order_Item_bean funcGetByID(string id)
        {
            AW_Order_Item_bean bean = new AW_Order_Item_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Order_Item_bean funcGetByID(int id)
        {
            AW_Order_Item_bean bean = new AW_Order_Item_bean();
            return bean.funcGetDataByID(id) ? bean : null;
        }

        public static AW_Order_Item_bean funcGetByID(string id, string columns)
        {
            AW_Order_Item_bean bean = new AW_Order_Item_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }

        public static AW_Order_Item_bean funcGetByID(int id, string columns)
        {
            AW_Order_Item_bean bean = new AW_Order_Item_bean();
            return bean.funcGetDataByID(id, columns) ? bean : null;
        }
		/////////////////////////////////////////

	}//
}//
