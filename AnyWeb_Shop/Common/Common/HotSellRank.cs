using System;
using System.Collections.Generic;
using System.Text;

using Studio.Array;
using Studio.Data;
using System.Data;
using Common.Common;
using System.Web;
namespace Common.Common
{
    class HotSellRank: IdObject
    {
        public HotSellRank()
        { 
        }
        public HotSellRank(DataRow dr)
        {
            this.HotSellID = (int)dr["HotSellID"];
            this.GoodsID = (int)dr["GoodsID"];
            this.Sort = (short)dr["Sort"];
        }

        private int _hotSellID;
        /// <summary>
        /// 热门销售排行ID
        /// </summary>
        public int HotSellID
        {
            get { return _hotSellID; }
            set { _hotSellID = value; }
        }


        private int _goodsId;
        /// <summary>
        /// 商品ID
        /// </summary>
        public int GoodsID
        {
            get { return _goodsId; }
            set { _goodsId = value; }
        }

        private short _sort;
        /// <summary>
        /// 商品排序
        /// </summary>
        public short Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        private Goods _ofGoods;
        /// <summary>
        /// 商品
        /// </summary>
        public Goods OfGoods
        {
            get { return _ofGoods; }
            set { _ofGoods = value; }
        }
        
    }
}
