using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Regist_dao : Dao_Base
	{
		public AW_Regist_dao()
        {
            this._propTable = "AW_Regist";
            this._propPK = "fdRegiID";
            this._propFields = "fdRegiID,fdRegiSiteID,fdRegiAppellation,fdRegiSurname,fdRegiName,fdRegiPosition,fdRegiPositionType,fdRegiCompany,fdRegiAddress,fdRegiCountry,fdRegiPost,fdRegiPhone,fdRegiFax,fdRegiMobile,fdRegiEmail,fdRegiWebSite,fdRegiBusiness,fdRegiTarget1,fdRegiTarget2,fdRegiTarget3,fdRegiTarget4,fdRegiTarget5,fdRegiTarget6,fdRegiFunction,fdRegiPurpose,fdRegiDecision,fdRegiBudget,fdRegiFrom,fdRegiInterest";
        }

        public List<AW_Regist_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Regist_bean> list = new List<AW_Regist_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Regist_bean bean = new AW_Regist_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
