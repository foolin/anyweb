using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

namespace AnyWeb.AW_DL
{
    public partial class AW_Article_dao : Dao_Base
    {
        public AW_Article_dao()
        {
            this._propTable = "AW_Article";
            this._propPK = "fdArtiID";
            this._propFields = "fdArtiID,fdArtiColumnID,fdArtiTitle,fdArtiContent,fdArtiCreateAt,fdArtiSort";
        }

        public List<AW_Article_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Article_bean> list = new List<AW_Article_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Article_bean bean = new AW_Article_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
    }
}