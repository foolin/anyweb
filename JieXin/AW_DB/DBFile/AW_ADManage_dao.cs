using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
    public partial class AW_ADManage_dao : Dao_Base
    {
        public AW_ADManage_dao()
        {
            this._propTable = "AW_AD";
            this._propPK = "fdAdID";
            this._propFields = "fdAdID,fdAdName,fdAdPic,fdAdLink,fdAdType,fdAdSort";
        }

        public List<AW_ADManage_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_ADManage_bean> list = new List<AW_ADManage_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_ADManage_bean bean = new AW_ADManage_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
    }//
}//
