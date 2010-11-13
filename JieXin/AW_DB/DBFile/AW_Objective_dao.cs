using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Objective_dao : Dao_Base
	{
		public AW_Objective_dao()
        {
            this._propTable = "AW_Objective";
            this._propPK = "fdObjeID";
            this._propFields = "fdObjeID,fdObjeResuID,fdObjeType,fdObjeAreaID1,fdObjeArea1,fdObjeAreaID2,fdObjeArea2,fdObjeAreaID3,fdObjeArea3,fdObjeAreaID4,fdObjeArea4,fdObjeAreaID5,fdObjeArea5,fdObjeIndustryID1,fdObjeIndustry1,fdObjeIndustryID2,fdObjeIndustry2,fdObjeIndustryID3,fdObjeIndustry3,fdObjeIndustryID4,fdObjeIndustry4,fdObjeIndustryID5,fdObjeIndustry5,fdObjeFuncTypeID1,fdObjecFuncType1,fdObjeFuncTypeID2,fdObjecFuncType2,fdObjeFuncTypeID3,fdObjecFuncType3,fdObjeFuncTypeID4,fdObjecFuncType4,fdObjeFuncTypeID5,fdObjecFuncType5,fdObjecSalery,fdObjeEntryTime,fdObjeDepartment,fdObjeCompType,fdObjeIntro";
        }

        public List<AW_Objective_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Objective_bean> list = new List<AW_Objective_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Objective_bean bean = new AW_Objective_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
