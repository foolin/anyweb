using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Tag_dao
	{
        /// <summary>
        /// 检查标签是否存在
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        public bool funcCheckTagExist( string tagName, int tagId )
        {
            this.propWhere = "fdTagName=@fdTagName";
            this.funcAddParam( "@fdTagName", tagName );
            if( tagId >= 0 )
            {
                this.propWhere += " AND fdTagID<>" + tagId;
            }
            DataSet ds = this.funcCommon();
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="key"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Tag_bean> funcGetTagList( string key, int pageSize, int pageIndex, out int recordCount )
        {
            this.propSelect = "fdTagID,fdTagName,fdArtiCount=(SELECT COUNT(fdTaAsID) from AW_Tag_Associated where fdTaAsTagID=fdTagID AND fdTaAsType=0),fdGoodCount=(SELECT COUNT(fdTaAsID) from AW_Tag_Associated where fdTaAsTagID=fdTagID AND fdTaAsType=1)";
            if( !string.IsNullOrEmpty( key ) )
            {
                key = key.Replace( "[", "[[]" ).Replace( "%", "[%]" );
                key = string.Format( "%{0}%", key );
                this.propWhere += "fdTagName LIKE @key";
                this.funcAddParam( "@key", key );
            }
            this.propOrder = "ORDER BY fdTagName ASC";
            this.propGetCount = true;
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Tag_bean> list = new List<AW_Tag_bean>();
            foreach( DataRow row in ds.Tables[ 0 ].Rows )
            {
                AW_Tag_bean bean = new AW_Tag_bean();
                bean.funcFromDataRow( row );
                bean.fdArtiCount = ( int ) row[ "fdArtiCount" ];
                bean.fdGoodCount = ( int ) row[ "fdGoodCount" ];
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 获取前18个常用标签
        /// </summary>
        /// <returns></returns>
        public List<AW_Tag_bean> funcGetTopTag()
        {
            string sql = "SELECT fdTagName FROM AW_Tag WHERE fdTagID IN (SELECT TOP 18 fdTaAsTagID FROM AW_Tag_Associated GROUP BY fdTaAsTagID ORDER BY COUNT(fdTaAsTagID))";
            DataSet ds = this.funcGet( sql );
            List<AW_Tag_bean> list = new List<AW_Tag_bean>();
            foreach( DataRow row in ds.Tables[ 0 ].Rows )
            {
                AW_Tag_bean bean = new AW_Tag_bean();
                bean.funcFromDataRow( row );
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 标签查找
        /// </summary>
        /// <param name="key"></param>
        /// <param name="order"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Tag_bean> funcSearchTag( string key, int order, int pageSize, int pageIndex, out int recordCount )
        {
            if( !string.IsNullOrEmpty( key ) )
            {
                key = key.Replace( "[", "[[]" ).Replace( "%", "[%]" );
                key = string.Format( "%{0}%", key );
                this.propWhere = "fdTagName LIKE @key";
                this.funcAddParam( "@key", key );
            }
            switch( order )
            {
                case 0:
                    this.propOrder = "ORDER BY fdTagName ASC";
                    break;
                case 1:
                    this.propOrder = "ORDER BY fdTagName DESC";
                    break;
                case 2:
                    this.propOrder = "ORDER BY fdTagID ASC";
                    break;
                case 3:
                    this.propOrder = "ORDER BY fdTagID DESC";
                    break;
                default:
                    this.propOrder = "ORDER BY fdTagName ASC";
                    break;
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            List<AW_Tag_bean> list = this.funcGetList();
            recordCount = this.propCount;
            return list;
        }
	}
}
