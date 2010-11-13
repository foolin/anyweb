using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Cert_dao : Dao_Base
	{
		public AW_Cert_dao()
        {
            this._propTable = "AW_Cert";
            this._propPK = "fdCertID";
            this._propFields = "fdCertID,fdCertResuID,fdCertDate,fdCertName,fdCertScore";
        }

        public List<AW_Cert_bean> funcGetList()
        {
            DataSet ds = base.funcCommon();
            List<AW_Cert_bean> list = new List<AW_Cert_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Cert_bean bean = new AW_Cert_bean();
                bean.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }
	}//
}//
