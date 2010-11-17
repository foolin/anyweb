using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Skills_dao
	{
        public List<AW_Skills_bean> funcGetSkillList( int resuId )
        {
            this.propWhere = "fdSkilResuID=" + resuId;
            return this.funcGetList();
        }
	}
}
