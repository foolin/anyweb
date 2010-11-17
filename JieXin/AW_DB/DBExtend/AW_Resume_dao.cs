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
        /// 获取简历名称
        /// </summary>
        /// <param name="resuId"></param>
        /// <returns></returns>
        public AW_Resume_bean funcGetResumeName( int resuId )
        {
            this.propSelect = "fdResuID,fdResuUserID,fdResuName,fdResuStatus";
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
        /// 修改简历名称
        /// </summary>
        /// <param name="bean"></param>
        /// <returns></returns>
        public int funcUpdateResumeName( AW_Resume_bean bean )
        {
            string sql = "UPDATE AW_Resume SET fdResuName=@fdResuName,fdResuUpdateAt=@fdResuUpdateAt,fdResuStatus=0 WHERE fdResuID=@fdResuID";
            this.funcAddParam( "@fdResuName", bean.fdResuName );
            this.funcAddParam( "@fdResuUpdateAt", DateTime.Now );
            this.funcAddParam( "@fdResuID", bean.fdResuID );
            return this.funcExecute( sql );
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

        /// <summary>
        /// 刷新所有简历
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int funcRefurbishAll(int userId)
        {
            string sql = string.Format( "UPDATE AW_Resume SET fdResuUpdateAt=@fdResuUpdateAt WHERE fdResuUserID=@fdResuUserID" );
            this.funcAddParam( "@fdResuUpdateAt", DateTime.Now );
            this.funcAddParam( "@fdResuUserID", userId );
            return this.funcExecute( sql );
        }

        /// <summary>
        /// 刷新简历
        /// </summary>
        /// <param name="resuId"></param>
        /// <returns></returns>
        public int funcRefurbish( int resuId )
        {
            string sql = string.Format( "UPDATE AW_Resume SET fdResuUpdateAt=@fdResuUpdateAt WHERE fdResuID=@fdResuID" );
            this.funcAddParam( "@fdResuUpdateAt", DateTime.Now );
            this.funcAddParam( "@fdResuID", resuId );
            return this.funcExecute( sql );
        }

        /// <summary>
        /// 获取简历
        /// </summary>
        /// <param name="resuId"></param>
        /// <returns></returns>
        public AW_Resume_bean funcGetResume( int resuId, bool isShow )
        {
            AW_Resume_bean bean = AW_Resume_bean.funcGetByID( resuId );
            if( bean == null )
                return null;
            bean.EducationList = new AW_Education_dao().funcGetEducationList( resuId );
            bean.RewardList = new AW_Rewards_dao().funcGetRewardList( resuId, isShow );
            bean.PositionList = new AW_Position_dao().funcGetPositionList( resuId, isShow );
            bean.WorkList = new AW_Work_dao().funcGetWorkList( resuId );
            bean.LanguageList = new AW_Language_dao().funcGetLanguageList( resuId );
            bean.CertList = new AW_Cert_dao().funcGetCertList( resuId );
            bean.AwardList = new AW_Awards_dao().funcGetAwardList( resuId );
            bean.SkillList = new AW_Skills_dao().funcGetSkillList( resuId );
            return bean;
        }
	}
}
