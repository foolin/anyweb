using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Favorite_dao
	{
        /// <summary>
        /// 获取已收藏的编号
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<int> funcGetExistIds( int userId, string ids )
        {
            string sql = string.Format( "SELECT fdFavoID FROM AW_Favorite WHERE fdFavoUserID={0} AND fdFavoRecrID IN ({1})", userId, ids );
            DataSet ds = this.funcGet( sql );
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                List<int> list = new List<int>();
                foreach( DataRow row in ds.Tables[ 0 ].Rows )
                {
                    list.Add( ( int ) row[ 0 ] );
                }
                return list;
            }
            else
            {
                return null;
            }
        }
	}
}
