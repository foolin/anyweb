using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Publish_dao : Dao_Base
	{
		public AW_Publish_dao()
        {
            this._propTable = "AW_Publish";
            this._propPK = "fdPublID";
            this._propFields = "fdPublID,fdPublName,fdPublAdminID,fdPublCreateAt,fdPublStartAt,fdPublFinishAt,fdPublStatus,fdPublError,fdPublObjType,fdPublObjID,fdPublType";
        }

        public List<AW_Publish_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Publish_bean> list = new List<AW_Publish_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Publish_bean bean = new AW_Publish_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
