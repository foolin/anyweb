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
	public partial class AW_Order_dao : Dao_Base
	{
		public AW_Order_dao()
        {
            this._propTable = "AW_Order";
            this._propPK = "fdOrdeID";
            this._propFields = "fdOrdeID,fdOrdeNO,fdOrdeMemberID,fdOrdeCreateAt,fdOrderNote,fdOrdeGoodsPrice,fdOrdePayPrice,fdOrdeRemark,fdOrdeStatus,fdOrdeUserName,fdOrdeUserEmail,fdOrdeUserPhone,fdOrdeUserMobile,fdOrdeUserProvinceID,fdOrdeUserCityID,fdOrdeUserAreaID,fdOrdeUserAddress,fdOrdeUserPostcode,fdOrdePayModeID,fdOrdePayAt,fdOrdeDeliverTime,fdOrdeDeliverModeID,fdOrdeDeliverPrice,fdOrdeDeliverCompany,fdOrdeDeliverFormNo,fdOrdeSenderPhone,fdOrdeCancelReson,fdOrdeIsChangeGood,fdOrdeConfirmWay,fdOrdePayConfirmcode,fdOrdeInvoiceTitle";
        }

        public List<AW_Order_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Order_bean> list = new List<AW_Order_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Order_bean bean = new AW_Order_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
