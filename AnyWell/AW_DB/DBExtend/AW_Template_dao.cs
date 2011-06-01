using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Template_dao
	{
        /// <summary>
        /// 获取模板列表
        /// </summary>
        /// <param name="ids">id集合</param>
        /// <returns></returns>
        public List<AW_Template_bean> funcGetTemplateList( string ids )
        {
            this.propTableApp = "INNER JOIN AW_Site ON fdTempSiteID=fdSiteID";
            this.propSelect = "fdTempID,fdTempSiteID,fdTempName,fdSiteID,fdSiteName";
            this.propWhere = string.Format( "fdTempID IN ({0})", ids );
            this.propOrder = "ORDER BY fdTempID DESC";
            DataSet ds = this.funcCommon();
            List<AW_Template_bean> list = new List<AW_Template_bean>();
            foreach( DataRow row in ds.Tables[ 0 ].Rows )
            {
                AW_Template_bean bean = new AW_Template_bean();
                bean.funcFromDataRow( row );
                bean.Site = new AW_Site_bean();
                bean.Site.funcFromDataRow( row );
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 获取站点模板
        /// </summary>
        /// <param name="sid">站点编号</param>
        /// <returns></returns>
        public List<AW_Template_bean> funcGetTemplateList( int sid )
        {
            this.propWhere = "fdTempSiteID=" + sid;
            this.propOrder = "ORDER BY fdTempID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取模板列表
        /// </summary>
        /// <param name="sid">站点编号</param>
        /// <param name="key">关键字</param>
        /// <param name="type">模板类型</param>
        /// <returns></returns>
        public List<AW_Template_bean> funcGetTemplateList( int sid, string key,int type )
        {
            this.propSelect = "fdTempID,fdTempName";
            this.propWhere = string.Format( "fdTempSiteID={0} AND fdTempType={1}", sid, type );
            if( !string.IsNullOrEmpty( key ) )
            {
                this.propWhere += string.Format( " AND fdTempName LIKE '%{0}%'", key );
            }
            this.propOrder = "ORDER BY fdTempID DESC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取模板列表
        /// </summary>
        /// <param name="sid">站点编号</param>
        /// <param name="key">关键字</param>
        /// <param name="field">排序字段</param>
        /// <param name="orderBy">排序方式</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public List<AW_Template_bean> funcGetTemplateList( int sid, int type, string key, string field, string orderBy, int pageIndex, int pageSize, out int recordCount )
        {
            this.propSelect = "fdTempID,fdTempSiteID,fdTempName,fdTempType,fdTempCreateAt";
            this.propWhere = "fdTempSiteID=" + sid;
            if( type > 0 )
            {
                this.propWhere += " AND fdTempType=" + type;
            }
            if( !string.IsNullOrEmpty( key ) )
            {
                this.propWhere += string.Format( " AND fdTempName LIKE '%{0}%'", key );
            }
            if( !string.IsNullOrEmpty( field ) && !string.IsNullOrEmpty( orderBy ) )
            {
                this.propOrder = string.Format( "ORDER BY {0} {1}", field, orderBy );
            }
            else
            {
                this.propOrder = "ORDER BY fdTempID DESC";
            }
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            DataSet ds = this.funcCommon();
            recordCount = this.propCount;
            List<AW_Template_bean> list = new List<AW_Template_bean>();
            for( int i = 0; i < ds.Tables[ 0 ].Rows.Count; i++ )
            {
                DataRow row = ds.Tables[ 0 ].Rows[ i ];
                AW_Template_bean bean = new AW_Template_bean();
                bean.funcFromDataRow( row );
                bean.fdAutoId = pageSize * ( pageIndex - 1 ) + i + 1;
                list.Add( bean );
            }
            return list;
        }

        /// <summary>
        /// 检查模板名称是否存在
        /// </summary>
        /// <param name="id">模板编号</param>
        /// <param name="name">站点编号</param>
        /// <param name="name">模板名称</param>
        /// <returns></returns>
        public bool funcCheckNameExist( int id, int siteID, string name )
        {
            this.propSelect = "fdTempID";
            this.propWhere = string.Format( "fdTempSiteID={0} AND fdTempName='{1}'", siteID, name );
            if( id > 0 )
            {
                this.propWhere += " AND fdTempID<>" + id;
            }
            return this.funcCommon().Tables[ 0 ].Rows.Count > 0;
        }

        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool funcDeleteTemplate( string ids )
        {
            bool result = false;

            IDbConnection conn = this.NewConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append( string.Format( "DELETE AW_Template WHERE fdTempID IN ({0});", ids ) );
                sql.Append( string.Format( "UPDATE AW_Site SET fdSiteIndexTemplateID=0 WHERE fdSiteIndexTemplateID IN ({0});", ids ) );
                sql.Append( string.Format( "UPDATE AW_Site SET fdSiteColumnTemplateID=0 WHERE fdSiteColumnTemplateID IN ({0});", ids ) );
                sql.Append( string.Format( "UPDATE AW_Site SET fdSiteContentTemplateID=0 WHERE fdSiteContentTemplateID IN ({0});", ids ) );
                sql.Append( string.Format( "UPDATE AW_Column SET fdColuIndexTemplateID=0 WHERE fdColuIndexTemplateID IN ({0});", ids ) );
                sql.Append( string.Format( "UPDATE AW_Column SET fdColuContentTemplateID=0 WHERE fdColuContentTemplateID IN ({0});", ids ) );
                funcExecute( sql.ToString(), tran );
                tran.Commit();
                result = true;
            }
            catch( Exception )
            {
                tran.Rollback();
                result = false;
            }
            finally
            {
                conn.Dispose();
            }
            return result;
        }
	}
}
