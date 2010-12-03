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
        /// 更新浏览数
        /// </summary>
        /// <param name="resuId"></param>
        /// <returns></returns>
        public int funcUpdateViewCount( int resuId )
        {
            string sql = string.Format( "UPDATE AW_Resume SET fdResuViewCount=fdResuViewCount+1 WHERE fdResuID=@fdResuID" );
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

        /// <summary>
        /// 获取职位投递简历
        /// </summary>
        /// <param name="recrId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Resume_bean> funcGetApplyResumeList( int recrId,int pageIndex,int pageSize,out int recordCount )
        {
            this.propSelect = "fdResuID,fdResuBirthday,fdResuExperience,fdResuSex,fdResuAddress,fdResuUpdateAt";
            this.propTableApp = " INNER JOIN AW_Apply ON fdApplResuID=fdResuID";
            this.propWhere = "fdResuStatus=0 AND fdApplRecrID=" + recrId;
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;
            this.propOrder = "ORDER BY fdApplID DESC";
            List<AW_Resume_bean> list = this.funcGetList();
            recordCount = this.propCount;
            if( list.Count == 0 )
                return null;
            string ids = "";
            foreach( AW_Resume_bean bean in list )
            {
                ids += "," + bean.fdResuID;
            }
            if( ids.Length > 0 )
            {
                ids = ids.Substring( 1 );
            }
            DataSet ds = new AW_Education_dao().funcGetByResuIDs( ids );
            foreach( AW_Resume_bean bean in list )
            {
                DataRow[] row = ds.Tables[ 0 ].Select( "fdEducResuID=" + bean.fdResuID, "fdEducDegree DESC" );
                if( row.Length > 0 )
                {
                    AW_Education_bean edu = new AW_Education_bean();
                    edu.funcFromDataRow( row[ 0 ] );
                    bean.Education = edu;
                }
            }
            return list;
        }

        /// <summary>
        /// 人才搜索
        /// </summary>
        /// <param name="resuId"></param>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <param name="workfrom"></param>
        /// <param name="workto"></param>
        /// <param name="edufrom"></param>
        /// <param name="eduto"></param>
        /// <param name="agefrom"></param>
        /// <param name="ageto"></param>
        /// <param name="sex"></param>
        /// <param name="saleryfrom"></param>
        /// <param name="saleryto"></param>
        /// <param name="major"></param>
        /// <param name="address"></param>
        /// <param name="industry"></param>
        /// <param name="updatefrom"></param>
        /// <param name="updateto"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<AW_Resume_bean> funcSearchResume( int resuId, int type, string key, int workfrom, int workto, int edufrom, int eduto, int agefrom, int ageto, int sex, int saleryfrom, int saleryto, int[] major, int[] address, int[] industry, DateTime updatefrom, DateTime updateto,int pageIndex,int pageSize,out int recordCount )
        {

            this.propSelect = "fdResuID,fdResuBirthday,fdResuExperience,fdResuSex,fdResuAddress,fdResuUpdateAt";
            this.propTableApp = " LEFT JOIN AW_Education ON fdResuID=fdEducResuID";
            this.propWhere = "fdResuStatus=0";
            if( resuId != 0 )
            {
                this.propWhere += " AND fdResuID=" + resuId;
            }
            //关键字
            string whereStr = "";
            string[] keys = key.Split( ' ' );
            for( int i = 0; i < keys.Length; i++ )
            {
                if( !string.IsNullOrEmpty( keys[ i ] ) )
                {
                    keys[ i ] = keys[ i ].Replace( "'", "''" ).Replace( "\"", "\"\"" );
                    whereStr += string.Format( "OR \"{0}\"", keys[ i ] );
                }
            }
            switch( type )
            {
                case 1:
                    if( whereStr.Length > 0 )
                    {
                        this.propTableApp += " LEFT JOIN AW_Position ON fdResuID=fdPosiResuID LEFT JOIN AW_Work ON fdResuID=fdWorkResuID LEFT JOIN AW_Cert ON fdResuID=fdCertResuID";
                        whereStr = whereStr.Substring( 3 );
                        this.propWhere += string.Format( " AND (CONTAINS(fdPosiName,'{0}') OR CONTAINS(fdPosiOrg,'{0}') OR CONTAINS(fdPosiIntro,'{0}') OR CONTAINS(fdWorkName,'{0}') OR CONTAINS(fdWorkDepartment,'{0}') OR CONTAINS(fdWorkOtherJob,'{0}') OR CONTAINS(fdWorkIntro,'{0}') OR CONTAINS(fdEducSchool,'{0}') OR CONTAINS(fdEducOtherSpecialty,'{0}') OR CONTAINS(fdEducIntro,'{0}') OR CONTAINS(fdResuUserName,'{0}') OR CONTAINS(fdResuObjeIntro,'{0}'))", whereStr );
                    }
                    break;
                case 2:
                    if( whereStr.Length > 0 )
                    {
                        this.propTableApp += " LEFT JOIN AW_Position ON fdResuID=fdPosiResuID";
                        whereStr = whereStr.Substring( 3 );
                        this.propWhere += string.Format( " AND (CONTAINS(fdPosiName,'{0}') OR CONTAINS(fdPosiOrg,'{0}') OR CONTAINS(fdPosiIntro,'{0}'))", whereStr );
                    }
                    break;
                case 3:
                    if( whereStr.Length > 0 )
                    {
                        this.propTableApp += " LEFT JOIN AW_Work ON fdResuID=fdWorkResuID";
                        whereStr = whereStr.Substring( 3 );
                        this.propWhere += string.Format( " AND (CONTAINS(fdWorkName,'{0}') OR CONTAINS(fdWorkDepartment,'{0}') OR CONTAINS(fdWorkOtherJob,'{0}') OR CONTAINS(fdWorkIntro,'{0}') OR CONTAINS(fdCertName,'{0}'))", whereStr );
                    }
                    break;
                case 4:
                    if( whereStr.Length > 0 )
                    {
                        whereStr = whereStr.Substring( 3 );
                        this.propWhere += string.Format( " AND (CONTAINS(fdEducSchool,'{0}') OR CONTAINS(fdEducOtherSpecialty,'{0}') OR CONTAINS(fdEducIntro,'{0}'))", whereStr );
                    }
                    break;
                case 5:
                    if( whereStr.Length > 0 )
                    {
                        this.propTableApp += " LEFT JOIN AW_Cert ON fdResuID=fdCertResuID";
                        whereStr = whereStr.Substring( 3 );
                        this.propWhere += string.Format( " AND (CONTAINS(fdCertName,'{0}'))", whereStr );
                    }
                    break;
                case 6:
                    if( whereStr.Length > 0 )
                    {
                        whereStr = whereStr.Substring( 3 );
                        this.propWhere += string.Format( " AND (CONTAINS(fdResuUserName,'{0}') OR CONTAINS(fdResuObjeIntro,'{0}'))", whereStr );
                    }
                    break;
                default:
                    break;
            }
            if( workfrom != 0 )
            {
                this.propWhere += " AND fdResuExperience>=" + workfrom;
            }
            if( workto != 0 )
            {
                this.propWhere += " AND fdResuExperience<=" + workto;
            }
            if( edufrom != 0 )
            {
                this.propWhere += " AND fdEducDegree>=" + edufrom;
            }
            if( eduto != 0 )
            {
                this.propWhere += " AND fdEducDegree<=" + eduto;
            }
            if( agefrom != 0 )
            {
                this.propWhere += " AND fdResuBirthday<@agefrom";
                this.funcAddParam( "@agefrom", DateTime.Parse( string.Format( "{0}-1-1", DateTime.Now.Year - agefrom ) ) );
            }
            if( ageto != 0 )
            {
                this.propWhere += " AND fdResuBirthday>@ageto";
                this.funcAddParam( "@ageto", DateTime.Parse( string.Format( "{0}-1-1", DateTime.Now.Year - ageto ) ) );
            }
            if( sex != -1 )
            {
                this.propWhere += " AND fdResuSex=" + sex;
            }
            if( saleryfrom != 0 )
            {
                this.propWhere += " AND fdResuObjeSalery>=" + saleryfrom;
            }
            if( saleryto != 0 )
            {
                this.propWhere += " AND fdResuObjeSalery<=" + saleryto;
            }
            //专业
            string majStr = "";
            foreach( int maj in major )
            {
                if( maj != 0 )
                {
                    majStr += "," + maj.ToString();
                }
            }
            if( majStr.Length > 0 )
            {
                majStr = majStr.Substring( 1 );
                this.propTableApp += " INNER JOIN AW_Major ON fdEducSpecialityID=fdMajoID";
                this.propWhere += string.Format( " AND (fdMajoID IN ({0}) OR fdMajoParent IN ({0}))", majStr );
            }
            //住址
            string addStr = "";
            foreach( int addr in address )
            {
                if( addr != 0 )
                {
                    addStr += "," + addr.ToString();
                }
            }
            if( addStr.Length > 0 )
            {
                addStr = addStr.Substring( 1 );
                this.propTableApp += " INNER JOIN AW_Area ON fdResuAddressID=fdAreaID";
                this.propWhere += string.Format( " AND (fdAreaID IN ({0}) OR fdAreaParent IN ({0}))", addStr );
            }
            //行业
            string induStr = "";
            foreach( int indu in industry)
            {
                if( indu != 0 )
                {
                    induStr += "," + indu.ToString();
                }
            }
            if( induStr.Length > 0 )
            {
                induStr = induStr.Substring( 1 );
                this.propWhere += string.Format( " AND (fdResuObjeIndustryID1 IN ({0}) OR fdResuObjeIndustryID2 IN ({0}) OR fdResuObjeIndustryID3 IN ({0}) OR fdResuObjeIndustryID4 IN ({0}) OR fdResuObjeIndustryID5 IN ({0}))", induStr );
            }
            this.propWhere += " AND fdResuUpdateAt BETWEEN @updatefrom AND @updateto";
            this.funcAddParam( "@updatefrom", updatefrom );
            this.funcAddParam( "@updateto", updateto );
            this.propWhere += " GROUP BY fdResuID,fdResuBirthday,fdResuExperience,fdResuSex,fdResuAddress,fdResuUpdateAt";

            this.propOrder = "ORDER BY fdResuUpdateAt DESC";
            this.propGetCount = true;
            this.propPage = pageIndex;
            this.propPageSize = pageSize;

            List<AW_Resume_bean> list = this.funcGetList();
            recordCount = this.propCount;
            if( list.Count == 0 )
                return null;
            string ids = "";
            foreach( AW_Resume_bean bean in list )
            {
                ids += "," + bean.fdResuID;
            }
            if( ids.Length > 0 )
            {
                ids = ids.Substring( 1 );
            }
            DataSet ds = new AW_Education_dao().funcGetByResuIDs( ids );
            foreach( AW_Resume_bean bean in list )
            {
                DataRow[] row = ds.Tables[ 0 ].Select( "fdEducResuID=" + bean.fdResuID, "fdEducDegree DESC" );
                if( row.Length > 0 )
                {
                    AW_Education_bean edu = new AW_Education_bean();
                    edu.funcFromDataRow( row[ 0 ] );
                    bean.Education = edu;
                }
            }
            return list;
        }
	}
}
