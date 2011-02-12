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
	public partial class AW_Order_Item_bean
	{
        private AW_Goods_bean _goods;
        /// <summary>
        /// 商品信息
        /// </summary>
        public AW_Goods_bean Goods
        {
            get { return _goods; }
            set { _goods = value; }
        }
	}
}
