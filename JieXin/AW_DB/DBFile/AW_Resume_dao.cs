using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Resume_dao : Dao_Base
	{
		public AW_Resume_dao()
        {
            this._propTable = "AW_Resume";
            this._propPK = "fdResuID";
            this._propFields = "fdResuID,fdResuUserID,fdResuName,fdResuSex,fdResuMarry,fdResuBirthday,fdResuHeight,fdResuCountry,fdResuNation,fdResuAddress,fdResuHouseAddress,fdResuIdentificationID,fdResuIdentificationNum,fdResuPoliticalState,fdResuEmail,fdResuContact1,fdResuContactPhone1,fdResuContact2,fdResuContactPhone2,fdResuContact3,fdResuContactPhone3,fdResuPostCode,fdResuContactAddress,fdResuWebsite,fdResuWorkType,fdResuArea,fdResuIndustry,fdResuJob,fdResuSalary,fdResuArriveAt,fdResuIntro,fdResuType,fdResuStatus";
        }

        public List<AW_Resume_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Resume_bean> list = new List<AW_Resume_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Resume_bean bean = new AW_Resume_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
