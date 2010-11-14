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
            this._propFields = "fdResuID,fdResuUserID,fdResuName,fdResuUserName,fdResuSex,fdResuBirthday,fdResuExperience,fdResuIdentificationID,fdResuIdentificationNum,fdResuAddressID,fdResuAddress,fdResuEmail,fdResuSalary,fdResuCurrType,fdResuCurrentSituation,fdResuMobilePhone,fdResuCompPhone,fdResuFamiPhone,fdResuHouseAddressID,fdResuHouseAddress,fdResuCountry,fdResuHeight,fdResuPostCode,fdResuContactAddr,fdResuMarry,fdResuWebsite,fdResuPhoto,fdResuObjeType,fdResuObjeAreaID1,fdResuObjeArea1,fdResuObjeAreaID2,fdResuObjeArea2,fdResuObjeAreaID3,fdResuObjeArea3,fdResuObjeAreaID4,fdResuObjeArea4,fdResuObjeAreaID5,fdResuObjeArea5,fdResuObjeIndustryID1,fdResuObjeIndustry1,fdResuObjeIndustryID2,fdResuObjeIndustry2,fdResuObjeIndustryID3,fdResuObjeIndustry3,fdResuObjeIndustryID4,fdResuObjeIndustry4,fdResuObjeIndustryID5,fdResuObjeIndustry5,fdResuObjeFuncTypeID1,fdResuObjeFuncType1,fdResuObjeFuncTypeID2,fdResuObjeFuncType2,fdResuObjeFuncTypeID3,fdResuObjeFuncType3,fdResuObjeFuncTypeID4,fdResuObjeFuncType4,fdResuObjeFuncTypeID5,fdResuObjeFuncType5,fdResuObjeSalery,fdResuObjeEntryTime,fdResuObjeDepartment,fdResuObjeCompType,fdResuObjeIntro,fdResuEnLevel,fdResuTOEFL,fdResuGRE,fdResuJpLevel,fdResuGMAT,fdResuIELTS,fdResuViewCount,fdResuCreateAt,fdResuUpdateAt,fdResuStatus";
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
