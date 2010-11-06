using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Recruit_dao : Dao_Base
	{
		public AW_Recruit_dao()
        {
            this._propTable = "AW_Recruit";
            this._propPK = "fdRecrID";
            this._propFields = "fdRecrID,fdRecrTitle,fdRecrCompany,fdRecrJob,fdRecrAreaID,fdRecrAreaName,fdRecrContent,fdRecrType,fdRecrSort,fdRecrCreateAt";
        }

        public List<AW_Recruit_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Recruit_bean> list = new List<AW_Recruit_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Recruit_bean bean = new AW_Recruit_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
