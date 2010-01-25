using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
	public partial class AW_Member_dao : SHOP_daoBase
	{
		public AW_Member_dao()
        {
            this._propTable = "AW_Member";
            this._propPK = "fdMembID";
            this._propFields = "fdMembID,fdMembPwd,fdMembName,fdMembRegAt,fdMembStatus,fdMembTrueName,fdMembSex,fdMembAvator,fdMembAddress,fdMembPostcode,fdMembMobile,fdMembPhone,fdMembEmail,fdMembQQ,fdMembMSN,fdMembOtherContact,fdMembPoint,fdMembProvinceID,fdMembCityID,fdMembAreaID,fdMembBirthday,fdMembLoginAt,fdMembLoginIP,fdMembUpdateAt,fdMembPwdQuestion,fdMembPwdAnswer,fdMembRegType";
        }

        public List<AW_Member_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Member_bean> list = new List<AW_Member_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Member_bean bean = new AW_Member_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
