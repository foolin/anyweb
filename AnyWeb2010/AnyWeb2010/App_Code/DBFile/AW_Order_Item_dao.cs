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
	public partial class AW_Order_Item_dao : Dao_Base
	{
		public AW_Order_Item_dao()
        {
            this._propTable = "AW_Order_Item";
            this._propPK = "fdItemID";
            this._propFields = "fdItemID,fdItemOrderID,fdItemGoodsID,fdItemGoodsPrice,fdItemQuantity,fdItemStatus";
        }

        public List<AW_Order_Item_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Order_Item_bean> list = new List<AW_Order_Item_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Order_Item_bean bean = new AW_Order_Item_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
