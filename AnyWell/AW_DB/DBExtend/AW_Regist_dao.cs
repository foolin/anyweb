using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Regist_dao
	{
        /// <summary>
        /// 检查邮箱是否存在
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool funcCheckEmailExist( int siteId, string email )
        {
            this.propWhere = string.Format( "fdRegiSiteID={0} AND fdRegiEmail='{1}'", siteId, email );
            return this.funcCommon().Tables[ 0 ].Rows.Count > 0;
        }
	}
}
