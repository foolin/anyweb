using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Rewards_dao
	{
        public List<AW_Rewards_bean> funcGetRewardList( int resuId, bool isShow )
        {
            this.propWhere = "fdRewaResuID=" + resuId;
            if( !isShow )
            {
                this.propWhere += " AND fdRewaIsShow=0";
            }
            return this.funcGetList();
        }
	}
}
