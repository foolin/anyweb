using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class Order_Item:IdObject
    {
        public Order_Item() { }

        public Order_Item(DataRow dr)
        {
            this.ID = (int)dr["ItemID"];
            //this._orderID = (int)dr["OrderID"];
            //this._goodsID = (int)dr["GoodsID"];
            this._quantity = (int)dr["Quantity"];
            OfGoods = new Goods();
            this._status = (int)dr["Status"];
        }

        /// <summary>
        /// 数量
        /// </summary>
        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        /// <summary>
        /// 订单
        /// </summary>
        private Order _ofOrder;

        public Order OfOrder
        {
            get { return _ofOrder; }
            set { _ofOrder = value; }
        }

        /// <summary>
        /// 商品
        /// </summary>
        private Goods _ofGoods;

        public Goods OfGoods
        {
            get { return _ofGoods; }
            set { _ofGoods = value; }
        }
        /// <summary>
        ///价格
        /// </summary>
        public double Price
        {
            get
            {
                return this.OfGoods.Price * this.Quantity;
            }
        }

        private int _status;
        /// <summary>
        /// 状态

        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }


        /// <summary>
        /// 市场价格
        /// </summary>
        public double MarketPrice
        {
            get
            {
                return this.OfGoods.MarketPrice * this.Quantity;
            }
        }
    }
}
