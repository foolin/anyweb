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
	public partial class AW_Goods_Comment_dao : Dao_Base
	{
		public AW_Goods_Comment_dao()
        {
            this._propTable = "AW_Goods_Comment";
            this._propPK = "fdCommID";
            this._propFields = "fdCommID,fdCommGoodsID,fdCommMemberID,fdCommUserName,fdCommScore,fdCommIP,fdCommCreateAt,fdCommContent,fdCommIsDeleted,fdCommUrlRef,fdCommArea,fdCommReply,fdCommReplyAt";
        }

        public List<AW_Goods_Comment_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Goods_Comment_bean> list = new List<AW_Goods_Comment_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Goods_Comment_bean bean = new AW_Goods_Comment_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
