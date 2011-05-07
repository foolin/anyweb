using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_SingleArticle_dao
	{
        /// <summary>
        /// 根据栏目编号获取单篇文档
        /// </summary>
        /// <param name="coluId">栏目编号</param>
        /// <returns></returns>
        public AW_SingleArticle_bean funcGetSingleArticle( int coluId )
        {
            this.propSelect = "TOP 1 *";
            this.propWhere = "fdSingColuID=" + coluId;
            List<AW_SingleArticle_bean> list = this.funcGetList();
            if( list.Count > 0 )
            {
                return list[ 0 ];
            }
            else
                return null;
        }
	}
}
