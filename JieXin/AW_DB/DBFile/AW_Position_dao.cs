using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Position_dao : Dao_Base
	{
		public AW_Position_dao()
        {
            this._propTable = "AW_Position";
            this._propPK = "fdPosiID";
            this._propFields = "fdPosiID,fdPosiResuID,fdPosiBegin,fdPosiEnd,fdPosiName,fdPosiOrg,fdPosiIntro,fdPosiIsShow";
        }

        public List<AW_Position_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Position_bean> list = new List<AW_Position_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Position_bean bean = new AW_Position_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
