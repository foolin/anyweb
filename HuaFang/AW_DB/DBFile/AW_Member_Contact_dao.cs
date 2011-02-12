using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Member_Contact_dao : Dao_Base
	{
		public AW_Member_Contact_dao()
        {
            this._propTable = "AW_Member_Contact";
            this._propPK = "fdContID";
            this._propFields = "fdContID,fdContMemberID,fdContProvinceID,fdContCityID,fdContAreaID,fdContAddress,fdContPostcode,fdContTel,fdContCreateAt,fdContName";
        }

        public List<AW_Member_Contact_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Member_Contact_bean> list = new List<AW_Member_Contact_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Member_Contact_bean bean = new AW_Member_Contact_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
