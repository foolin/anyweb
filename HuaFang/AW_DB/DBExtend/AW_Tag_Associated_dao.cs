using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Tag_Associated_dao
	{
        /// <summary>
        /// 删除标签关联
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="objId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int funcDelAssociated( int tagId, int objId, int type )
        {
            string sql = string.Format( "DELETE AW_Tag_Associated WHERE fdTaAsTagID={0} AND fdTaAsDataID={1} AND fdTaAsType={2}", tagId, objId, type );
            return this.funcExecute( sql );
        }

        /// <summary>
        /// 清除标签关联
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int funcClearAssociateds( string ids, int type )
        {
            string sql = string.Format( "DELETE AW_Tag_Associated WHERE fdTaAsDataID IN ({0}) AND fdTaAsType={1}", ids, type );
            return this.funcExecute( sql );
        }
	}
}
