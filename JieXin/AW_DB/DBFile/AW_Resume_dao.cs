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
            this._propFields = "fdResuID,fdResuUserID,fdResuName,fdResuSex,fdResuBirthday,fdResuExperience,fdResuIdentificationID,fdResuIdentificationNum,fdResuAddressID,fdResuAddress,fdResuEmail,fdResuSalary,fdResuCurrType,fdResuCurrentSituation,fdResuMobilePhone,fdResuCompPhone,fdResuFamiPhone,fdResuHouseAddressID,fdResuHouseAddress,fdResuCountry,fdResuHeight,fdResuPostCode,fdResuContactAddr,fdResuMarry,fdResuWebsite,fdResuPhoto,fdResuStatus,fdResuEnLevel,fdResuTOEFL,fdResuGRE,fdResuJpLevel,fdResuGMAT,fdResuIELTS,fdResuCreateAt,fdResuUpdateAt";
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
