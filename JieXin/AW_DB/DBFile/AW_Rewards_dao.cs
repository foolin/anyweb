using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Rewards_dao : Dao_Base
	{
		public AW_Rewards_dao()
        {
            this._propTable = "AW_Rewards";
            this._propPK = "fdRewaID";
            this._propFields = "fdRewaID,fdRewaResuID,fdRewaBegin,fdRewaEnd,fdRewaName,fdRewaLevel,fdRewaIsShow";
        }

        public List<AW_Rewards_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Rewards_bean> list = new List<AW_Rewards_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Rewards_bean bean = new AW_Rewards_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
