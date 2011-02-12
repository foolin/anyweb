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
	public partial class AW_Order_Item_dao
	{
        /// <summary>
        /// 根据订单ID获取订单项
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public List<AW_Order_Item_bean> funcGetListByOrderID(int orderID)
        {
            this.propWhere = "fdItemOrderID = " + orderID;
            DataSet ds = base.funcCommon();
            List<AW_Order_Item_bean> list = new List<AW_Order_Item_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Order_Item_bean bean = new AW_Order_Item_bean();
                bean.funcFromDataRow(r);
                bean.Goods = AW_DL.AW_Goods_bean.funcGetByID(bean.fdItemGoodsID);
                list.Add(bean);
            }
            return list;
        }

        public List<AW_Order_Item_bean> funcGetListByGoodsIds(string ids)
        {
            this.propWhere = String.Format("fdItemGoodsID IN ({0})", ids);
            return this.funcGetList();
        }
	}
}
