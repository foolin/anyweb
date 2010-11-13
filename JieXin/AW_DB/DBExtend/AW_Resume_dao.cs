using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Resume_dao
	{
        /// <summary>
        /// 获取简历列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<AW_Resume_bean> funcGetResumeList(int userId)
        {
            this.propSelect = "fdResuID,fdResuName,fdResuViewCount";
            this.propWhere = string.Format("fdResuUserID={0} AND fdResuStatus=0", userId);
            this.propOrder = "ORDER BY fdResuID ASC";
            return this.funcGetList();
        }

        /// <summary>
        /// 获取简历
        /// </summary>
        /// <param name="resuId"></param>
        /// <returns></returns>
        public AW_Resume_bean funcGetResumeById( int resuId )
        {
            this.propSelect = "fdResuID,fdResuUserID";
            this.propWhere = "fdResuID=" + resuId;
            DataSet ds = this.funcCommon();
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                AW_Resume_bean bean = new AW_Resume_bean();
                bean.funcFromDataRow( ds.Tables[ 0 ].Rows[ 0 ] );
                return bean;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新简历状态
        /// </summary>
        /// <param name="resuId"></param>
        /// <returns></returns>
        public int funcUpdateResumeStatus( int resuId )
        {
            string sql = "UPDATE AW_Resume SET fdResuUpdateAt=@fdResuUpdateAt,fdResuStatus=0 WHERE fdResuID=@fdResuID";
            this.funcAddParam( "@fdResuUpdateAt", DateTime.Now );
            this.funcAddParam( "@fdResuID", resuId );
            return this.funcExecute( sql );
        }

        /// <summary>
        /// 获取语言等级
        /// </summary>
        /// <param name="resuId"></param>
        /// <returns></returns>
        public AW_Resume_bean funcGetLangLevel( int resuId )
        {
            this.propSelect = "fdResuID,fdResuUserID,fdResuEnLevel,fdResuTOEFL,fdResuGRE,fdResuJpLevel,fdResuGMAT,fdResuIELTS,fdResuUpdateAt";
            this.propWhere = "fdResuID=" + resuId;
            DataSet ds = this.funcCommon();
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                AW_Resume_bean bean = new AW_Resume_bean();
                bean.funcFromDataRow( ds.Tables[ 0 ].Rows[ 0 ] );
                return bean;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新语言等级
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public int funcUpdateLangLevel(AW_Resume_bean bean)
        {
            string sql = "UPDATE AW_Resume SET fdResuEnLevel=@fdResuEnLevel,fdResuTOEFL=@fdResuTOEFL,fdResuGRE=@fdResuGRE,fdResuJpLevel=@fdResuJpLevel,fdResuGMAT=@fdResuGMAT,fdResuIELTS=@fdResuIELTS,fdResuUpdateAt=@fdResuUpdateAt WHERE fdResuID=@fdResuID";
            this.funcAddParam( "@fdResuEnLevel", bean.fdResuEnLevel );
            this.funcAddParam( "@fdResuTOEFL", bean.fdResuTOEFL );
            this.funcAddParam( "@fdResuGRE", bean.fdResuGRE );
            this.funcAddParam( "@fdResuJpLevel", bean.fdResuJpLevel );
            this.funcAddParam( "@fdResuGMAT", bean.fdResuGMAT );
            this.funcAddParam( "@fdResuIELTS", bean.fdResuIELTS );
            this.funcAddParam( "@fdResuUpdateAt", DateTime.Now );
            this.funcAddParam( "@fdResuID", bean.fdResuID );
            return this.funcExecute( sql );
        }

        /// <summary>
        /// 获取简历数
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int funcGetResumeCount( int userId )
        {
            string sql = string.Format( "SELECT COUNT(fdResuID) FROM AW_Resume WHERE fdResuUserID={0} AND fdResuStatus=0", userId );
            DataSet ds = this.funcGet( sql );
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                return ( int ) ds.Tables[ 0 ].Rows[ 0 ][ 0 ];
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取最后更新时间
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DateTime funcGetLastUpdateTime( int userId )
        {
            string sql = string.Format( "SELECT TOP 1 fdResuUpdateAt FROM AW_Resume WHERE fdResuUserID={0} AND fdResuStatus=0 ORDER BY fdResuUpdateAt DESC", userId );
            DataSet ds = this.funcGet( sql );
            if( ds.Tables[ 0 ].Rows.Count > 0 )
            {
                return ( DateTime ) ds.Tables[ 0 ].Rows[ 0 ][ 0 ];
            }
            else
            {
                return DateTime.Parse("1900-01-01");
            }
        }
	}
}
