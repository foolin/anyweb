using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
    public partial class AW_Library_dao : Dao_Base
	{
        public AW_Library_dao()
        {
            this._propTable = "AW_Library";
            this._propPK = "fdLibrID";
            this._propFields = "fdLibrID,fdLibrType,fdLibrName,fdLibrEnName,fdLibrPic,fdLibrFirLetter,fdLibrDesc,fdLibrSort";
        }

        public List<AW_Library_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Library_bean> list = new List<AW_Library_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Library_bean bean = new AW_Library_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
    }
}
