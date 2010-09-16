using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Company_dao : Dao_Base
	{
		public AW_Company_dao()
        {
            this._propTable = "AW_Company";
            this._propPK = "fdCompID";
            this._propFields = "fdCompID,fdCompAccount,fdCompPwd,fdCompName,fdCompCity,fdCompAddress,fdCompEmail,fdCompInduID,fdCompCateID,fdCompDimension,fdCompIntro,fdCompContact,fdCompPhone,fdCompWebsite";
        }

        public List<AW_Company_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Company_bean> list = new List<AW_Company_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Company_bean bean = new AW_Company_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
