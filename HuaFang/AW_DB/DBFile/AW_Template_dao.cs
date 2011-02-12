using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Template_dao : Dao_Base
	{
		public AW_Template_dao()
        {
            this._propTable = "AW_Template";
            this._propPK = "fdTempID";
            this._propFields = "fdTempID,fdTempName,fdTempType,fdTempCreateAt,fdTempContent,fdTempPath";
        }

        public List<AW_Template_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Template_bean> list = new List<AW_Template_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Template_bean bean = new AW_Template_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
