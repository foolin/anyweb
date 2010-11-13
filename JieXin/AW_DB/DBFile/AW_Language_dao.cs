using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Language_dao : Dao_Base
	{
		public AW_Language_dao()
        {
            this._propTable = "AW_Language";
            this._propPK = "fdLangID";
            this._propFields = "fdLangID,fdLangResuID,fdLangType,fdLangMaster,fdLangRWAbility,fdLangLiAbility";
        }

        public List<AW_Language_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Language_bean> list = new List<AW_Language_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Language_bean bean = new AW_Language_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
