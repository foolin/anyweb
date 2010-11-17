using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Position_dao
	{
        public List<AW_Position_bean> funcGetPositionList( int resuId, bool isShow )
        {
            this.propWhere = "fdPosiResuID=" + resuId;
            if( isShow )
            {
                this.propWhere += " AND fdPosiIsShow=0";
            }
            return this.funcGetList();
        }
	}
}
