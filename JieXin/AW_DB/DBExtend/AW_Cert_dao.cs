using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Cert_dao
	{
        public List<AW_Cert_bean> funcGetCertList( int resuId )
        {
            this.propWhere = "fdCertResuID=" + resuId;
            return this.funcGetList();
        }
	}
}
