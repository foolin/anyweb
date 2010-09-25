using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
    public partial class AW_ScrollAD_dao : Dao_Base
    {
        public AW_ScrollAD_dao()
        {
            this._propTable = "AW_AD";
            this._propPK = "fdAdID";
            this._propFields = "fdAdID,fdAdName,fdAdPic,fdAdLink,fdAdType,fdAdSort";
        }

        public List<AW_ScrollAD_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_ScrollAD_bean> list = new List<AW_ScrollAD_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_ScrollAD_bean bean = new AW_ScrollAD_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
    }//
}//
