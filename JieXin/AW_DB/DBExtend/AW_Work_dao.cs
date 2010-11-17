using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Work_dao
	{
        public List<AW_Work_bean> funcGetWorkList( int resuId )
        {
            this.propWhere = "fdWorkResuID=" + resuId;
            return this.funcGetList();
        }
	}
}
