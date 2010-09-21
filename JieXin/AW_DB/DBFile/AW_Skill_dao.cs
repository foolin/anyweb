using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Skill_dao : Dao_Base
	{
		public AW_Skill_dao()
        {
            this._propTable = "AW_Skill";
            this._propPK = "fdSkilID";
            this._propFields = "fdSkilID,fdSkilName,fdSkilParent,fdSkilOrder";
        }

        public List<AW_Skill_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Skill_bean> list = new List<AW_Skill_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Skill_bean bean = new AW_Skill_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
