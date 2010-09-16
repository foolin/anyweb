using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Education_dao : Dao_Base
	{
		public AW_Education_dao()
        {
            this._propTable = "AW_Education";
            this._propPK = "fdEducID";
            this._propFields = "fdEducID,fdEducResuID,fdEducBegin,fdEducEnd,fdEducSchool,fdEducSpeciality,fdEducOtherSpecialty,fdEducDegree,fdEducIntro";
        }

        public List<AW_Education_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Education_bean> list = new List<AW_Education_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Education_bean bean = new AW_Education_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
