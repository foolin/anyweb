using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Awards_dao
	{
        public List<AW_Awards_bean> funcGetAwardList( int resuId )
        {
            this.propWhere = "fdAwarResuID=" + resuId;
            return this.funcGetList();
        }
	}
}
