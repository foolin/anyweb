using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnyWell.AW_DL;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace Import
{
    public partial class ImportForm : Form
    {
        bool stop = false;  //停止标识
        int AllCount = 0;   //总条数
        int CurrentCount = 0;
        int pageIndex = 1;  //当前页
        int pageSize = 20;  //页条数
        List<AW_Area_bean> AreaList;
        List<AW_Industry_bean> IndustryList;
        List<AW_Job_bean> JobList;

        public ImportForm()
        {
            InitializeComponent();
        }

        private void btnImport_Click( object sender, EventArgs e )
        {
            AllCount = 0;
            CurrentCount = 0;
            pageIndex = 1;
            btnImport.Enabled = false;
            stop = false;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnStop_Click( object sender, EventArgs e )
        {
            stop = true;
            btnStop.Text = "正在停止";
            btnStop.Enabled = false;
        }

        private void backgroundWorker1_DoWork( object sender, DoWorkEventArgs e )
        {
            BackgroundWorker worker = ( BackgroundWorker ) sender;
            worker.ReportProgress( 0, "正在准备数据..." );
            string errorIds = "";
            AW_Import_dao dao = new AW_Import_dao();
            AllCount = dao.funcGetCount();
            AreaList = new AW_Area_dao().funcGetList();
            IndustryList = new AW_Industry_dao().funcGetList();
            JobList = new AW_Job_dao().funcGetList();
            List<AW_Import_bean> list = dao.funcGetImportList( pageIndex, pageSize );
            while( list != null && list.Count > 0 && !stop )
            {
                foreach( AW_Import_bean bean in list )
                {
                    if( stop )
                    {
                        return;
                    }
                    //try
                    //{
                        insertData( bean );
                    //}
                    //catch( Exception )
                    //{
                    //    errorIds += "," + bean.no;
                    //}
                    CurrentCount++;
                    worker.ReportProgress( CurrentCount * 100 / AllCount, string.Format( "导入进度：{0}/{1}", CurrentCount, AllCount ) );
                }
                pageIndex++;
                worker.ReportProgress( CurrentCount * 100 / AllCount, "正在准备下一批数据..." );
                list = dao.funcGetImportList( pageIndex, pageSize );
            }
            if( errorIds.Length > 0 )
            {
                errorIds = errorIds.Substring( 1 );
                Studio.IO.FileAgent.WriteText( System.Environment.CurrentDirectory + "/ErrorIds.log", errorIds, true );
            }
        }

        private void backgroundWorker1_ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
            ProgressBar1.Value = e.ProgressPercentage;
            StatusLabel1.Text = e.UserState.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
        {
            btnImport.Enabled = true;
            if( stop )
            {
                btnStop.Text = "停 止";
                btnStop.Enabled = true;
            }
            StatusLabel1.Text = "导入完成！";
            MessageBox.Show( "导入完成！" );
        }

        private void insertData( AW_Import_bean bean )
        {
            string[] addr;
            AW_Resume_bean resume = new AW_Resume_bean();
            resume.WorkList = new List<AW_Work_bean>();
            resume.EducationList = new List<AW_Education_bean>();
            resume.LanguageList = new List<AW_Language_bean>();
            resume.SkillList = new List<AW_Skills_bean>();
            resume.CertList = new List<AW_Cert_bean>();
            //简历编号
            resume.fdResuID = new AW_Resume_dao().funcNewID();
            //用户编号
            resume.fdResuUserID = 10033;
            //简历名称
            resume.fdResuName = "我的简历";
            //姓名
            resume.fdResuUserName = bean.Name;
            //性别
            resume.fdResuSex = bean.Sex.Trim() == "女" ? 1 : 0;
            //出生日期
            resume.fdResuBirthday = DateTime.Parse( bean.Birthday.Trim() + "-1" );
            //居住地
            resume.fdResuAddressID = 40;
            resume.fdResuAddress = "广州";
            addr = bean.Address.Trim().Split( '-' );
            if( addr[ 0 ] != "广州" )
            {
                int addressID = new AW_Area_dao().funcGetAreaID( addr[ 0 ] );
                if( addressID != 0 )
                {
                    resume.fdResuAddressID = addressID;
                    resume.fdResuAddress = addr[ 0 ];
                }
            }
            //工作年限
            resume.fdResuExperience = this.getExpId( bean.Experience.Trim() );
            //户口
            resume.fdResuHouseAddressID = 40;
            resume.fdResuHouseAddress = "广州";
            addr = bean.Address.Trim().Split( '-' );
            if( addr[ 0 ] != "广州" )
            {
                int addressID = new AW_Area_dao().funcGetAreaID( addr[ 0 ] );
                if( addressID != 0 )
                {
                    resume.fdResuHouseAddressID = addressID;
                    resume.fdResuHouseAddress = addr[ 0 ];
                }
            }
            //年薪
            resume.fdResuSalary = getSalaryId( bean.Salary.Trim() );
            //联系地址
            resume.fdResuContactAddr = bean.ContactAddress.Trim();
            //邮编
            resume.fdResuPostCode = bean.PostCode.Trim();
            //电子邮箱
            resume.fdResuEmail = bean.Email.Trim();
            //家庭电话
            string[] famiPhone = bean.FamilyPhone.Trim().Split( '-' );
            if( famiPhone.Length == 3 )
            {
                resume.fdResuFamiPhone = bean.FamilyPhone;
            }
            else if( famiPhone.Length == 2 )
            {
                resume.fdResuFamiPhone = bean.FamilyPhone + "-";
            }
            else
            {
                resume.fdResuFamiPhone = "";
            }
            //移动电话
            string[] mobilePhone = bean.MobilePhone.Trim().Split( '-' );
            if( mobilePhone.Length == 2 )
            {
                resume.fdResuMobilePhone = bean.MobilePhone;
            }
            //公司电话
            string[] companyPhone = bean.CompanyPhone.Trim().Split( '-' );
            if( companyPhone.Length == 4 )
            {
                resume.fdResuCompPhone = bean.MobilePhone;
            }
            else if(companyPhone.Length==3)
            {
                resume.fdResuCompPhone = bean.MobilePhone + "-";
            }
            else if( companyPhone.Length == 2 )
            {
                resume.fdResuCompPhone = bean.MobilePhone + "-" + "-";
            }
            else
            {
                resume.fdResuCompPhone = "";
            }
            //自我评价
            resume.fdResuObjeIntro = bean.ObjIntro.Trim();
            if( resume.fdResuObjeIntro.Length > 500 )
            {
                resume.fdResuObjeIntro = resume.fdResuObjeIntro.Substring( 0, 500 );
            }
            //工作类型
            resume.fdResuObjeType = getObjeTypeId( bean.ObjType.Trim() );
            //希望行业
            if( !string.IsNullOrEmpty( bean.ObjIndustry.Trim() ) )
            {
                int index = 1;
                foreach( AW_Industry_bean industry in IndustryList )
                {
                    if( bean.ObjIndustry.Trim().IndexOf( industry.fdInduName ) > -1 )
                    {
                        switch( index )
                        {
                            case 1:
                                resume.fdResuObjeIndustry1 = industry.fdInduName;
                                resume.fdResuObjeIndustryID1 = industry.fdInduID;
                                index++;
                                break;
                            case 2:
                                resume.fdResuObjeIndustry2 = industry.fdInduName;
                                resume.fdResuObjeIndustryID2 = industry.fdInduID;
                                index++;
                                break;
                            case 3:
                                resume.fdResuObjeIndustry3 = industry.fdInduName;
                                resume.fdResuObjeIndustryID3 = industry.fdInduID;
                                index++;
                                break;
                            case 4:
                                resume.fdResuObjeIndustry4 = industry.fdInduName;
                                resume.fdResuObjeIndustryID4 = industry.fdInduID;
                                index++;
                                break;
                            case 5:
                                resume.fdResuObjeIndustry5 = industry.fdInduName;
                                resume.fdResuObjeIndustryID5 = industry.fdInduID;
                                index++;
                                break;
                        }
                        if( bean.ObjIndustry.Trim() == industry.fdInduName )
                        {
                            break;
                        }
                    }
                }
            }
            //目标地点
            if( !string.IsNullOrEmpty( bean.ObjAddress.Trim() ) )
            {
                int index = 1;
                foreach( AW_Area_bean area in AreaList )
                {
                    if( bean.ObjAddress.Trim().IndexOf( area.fdAreaName ) > -1 )
                    {
                        switch( index )
                        {
                            case 1:
                                resume.fdResuObjeArea1 = area.fdAreaName;
                                resume.fdResuObjeAreaID1 = area.fdAreaID;
                                index++;
                                break;
                            case 2:
                                resume.fdResuObjeArea2 = area.fdAreaName;
                                resume.fdResuObjeAreaID2 = area.fdAreaID;
                                index++;
                                break;
                            case 3:
                                resume.fdResuObjeArea3 = area.fdAreaName;
                                resume.fdResuObjeAreaID3 = area.fdAreaID;
                                index++;
                                break;
                            case 4:
                                resume.fdResuObjeArea4 = area.fdAreaName;
                                resume.fdResuObjeAreaID4 = area.fdAreaID;
                                index++;
                                break;
                            case 5:
                                resume.fdResuObjeArea5 = area.fdAreaName;
                                resume.fdResuObjeAreaID5 = area.fdAreaID;
                                index++;
                                break;
                        }
                        if( bean.ObjAddress.Trim() == area.fdAreaName )
                        {
                            break;
                        }
                    }
                }
            }
            //目标职能
            if( !string.IsNullOrEmpty( bean.ObjFuncType.Trim() ) )
            {
                int index = 1;
                foreach( AW_Job_bean job in JobList )
                {
                    if( bean.ObjFuncType.Trim().IndexOf( job.fdJobName ) > -1 )
                    {
                        switch( index )
                        {
                            case 1:
                                resume.fdResuObjeFuncType1 = job.fdJobName;
                                resume.fdResuObjeFuncTypeID1 = job.fdJobID;
                                index++;
                                break;
                            case 2:
                                resume.fdResuObjeFuncType2 = job.fdJobName;
                                resume.fdResuObjeFuncTypeID2 = job.fdJobID;
                                index++;
                                break;
                            case 3:
                                resume.fdResuObjeFuncType3 = job.fdJobName;
                                resume.fdResuObjeFuncTypeID3 = job.fdJobID;
                                index++;
                                break;
                            case 4:
                                resume.fdResuObjeFuncType4 = job.fdJobName;
                                resume.fdResuObjeFuncTypeID4 = job.fdJobID;
                                index++;
                                break;
                            case 5:
                                resume.fdResuObjeFuncType5 = job.fdJobName;
                                resume.fdResuObjeFuncTypeID5 = job.fdJobID;
                                index++;
                                break;
                        }
                        if( bean.ObjFuncType.Trim() == job.fdJobName )
                        {
                            break;
                        }
                    }
                }
            }
            //工作经验
            if( !string.IsNullOrEmpty( bean.Work.Trim() ) )
            {
                Regex regex = new Regex( "\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*" );
                string[] works = regex.Split( bean.Work.Trim() );
                foreach( string str in works )
                {
                    AW_Work_bean work = new AW_Work_bean();
                    work.fdWorkID = new AW_Work_dao().funcNewID();
                    work.fdWorkResuID = resume.fdResuID;
                    //时间
                    string FromAndTo = str.Substring( 0, str.IndexOf( "——" ) );
                    string from = FromAndTo.Split( '至' )[ 0 ];
                    string to = FromAndTo.Split( '至' )[ 1 ];
                    work.fdWorkBegin = DateTime.Parse( from.Trim() + "-1" );
                    if( to.Trim() == "今" )
                    {
                        work.fdWorkEnd = DateTime.Parse( "1900-01-01" );
                    }
                    else
                    {
                        work.fdWorkEnd = DateTime.Parse( to.Trim() + "-1" );
                    }
                    //公司名、公司规模
                    string workName = str.Substring( str.IndexOf( "公司:" ) + 3, str.IndexOf( "部门:" ) - str.IndexOf( "公司:" ) - 3 ).Trim();
                    if( workName.IndexOf( ")" ) > -1 && workName.LastIndexOf( ")" ) == workName.Length - 1 )
                    {
                        work.fdWorkName = workName.Substring( 0, workName.IndexOf( "(" ) ).Trim();
                        work.fdWorkDimension = getDimensionId( workName.Substring( workName.LastIndexOf( "(" ) + 1, workName.LastIndexOf( ")" ) - workName.LastIndexOf( "(" ) - 1 ).Trim() );
                    }
                    else
                    {
                        work.fdWorkName = workName;
                        work.fdWorkDimension = 0;
                    }
                    //部门
                    work.fdWorkDepartment = str.Substring( str.IndexOf( "部门:" ) + 3, str.IndexOf( "职位:" ) - str.IndexOf( "部门:" ) - 3 ).Trim();
                    if( work.fdWorkDepartment.Length > 20 )
                    {
                        work.fdWorkDepartment = work.fdWorkDepartment.Substring( 0, 20 );
                    }
                    //职位
                    string jobName = str.Substring( str.IndexOf( "职位:" ) + 3, str.IndexOf( "工作描述：" ) - str.IndexOf( "职位:" ) - 3 ).Trim();
                    if( !string.IsNullOrEmpty( jobName ) )
                    {
                        foreach( AW_Job_bean job in JobList )
                        {
                            if( job.fdJobName == jobName )
                            {
                                work.fdWorkJob = job.fdJobName;
                                work.fdWorkJobID = job.fdJobID;
                                break;
                            }
                        }
                        if( work.fdWorkJobID == 0 )
                        {
                            work.fdWorkOtherJob = jobName;
                            if( work.fdWorkOtherJob.Length > 20 )
                            {
                                work.fdWorkOtherJob = work.fdWorkOtherJob.Substring( 0, 20 );
                            }
                        }
                    }
                    //工作描述
                    work.fdWorkIntro = str.Substring( str.IndexOf( "工作描述：" ) + 5 ).Trim();
                    if( work.fdWorkIntro.Length > 2000 )
                    {
                        work.fdWorkIntro = work.fdWorkIntro.Substring( 0, 2000 );
                    }
                    work.fdWorkIsOverSeas = 1;
                    resume.WorkList.Add( work );
                }
            }
            //教育经历
            if( !string.IsNullOrEmpty( bean.Education.Trim() ) )
            {
                Regex regex = new Regex( "\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*\\*" );
                string[] educations = regex.Split( bean.Education.Trim() );
                foreach( string str in educations )
                {
                    AW_Education_bean education = new AW_Education_bean();
                    string strTemp = "";
                    education.fdEducID = new AW_Education_dao().funcNewID();
                    education.fdEducResuID = resume.fdResuID;
                    //时间
                    string FromAndTo = str.Substring( 0, str.IndexOf( "——" ) );
                    string from = FromAndTo.Split( '至' )[ 0 ];
                    string to = FromAndTo.Split( '至' )[ 1 ];
                    education.fdEducBegin = DateTime.Parse( from.Trim() + "-1" );
                    if( to.Trim() == "今" )
                    {
                        education.fdEducEnd = DateTime.Parse( "1900-01-01" );
                    }
                    else
                    {
                        education.fdEducEnd = DateTime.Parse( to.Trim() + "-1" );
                    }
                    //学校
                    strTemp = str.Substring( str.IndexOf( "——" ) + 2 ).Trim();
                    education.fdEducSchool = strTemp.Substring( 0, strTemp.IndexOf( "\r\n" ) ).Trim();
                    //专业、学历
                    strTemp = strTemp.Substring( strTemp.IndexOf( "\r\n" ) + 2 ).Trim();
                    string MajorAndDegree;
                    if( strTemp.IndexOf( "\r\n" ) > -1 )
                    {
                        MajorAndDegree = strTemp.Substring( 0, strTemp.IndexOf( "\r\n" ) ).Trim();
                    }
                    else
                    {
                        MajorAndDegree = strTemp;
                    }
                    string degree = "";
                    int degreeId = getDegreeId( MajorAndDegree, out degree );
                    if( degreeId == 0 )
                    {
                        education.fdEducSpecialityID = new AW_Major_dao().funcGetMajorId( MajorAndDegree );
                        if( education.fdEducSpecialityID != 0 )
                        {
                            education.fdEducSpeciality = MajorAndDegree;
                        }
                        else
                        {
                            education.fdEducOtherSpecialty = MajorAndDegree;
                        }
                    }
                    else
                    {
                        education.fdEducDegree = degreeId;
                        string major = MajorAndDegree.Replace( degree, "" );
                        education.fdEducSpecialityID = new AW_Major_dao().funcGetMajorId( major );
                        if( education.fdEducSpecialityID != 0 )
                        {
                            education.fdEducSpeciality = major;
                        }
                        else
                        {
                            education.fdEducOtherSpecialty = major;
                        }
                    }
                    //专业描述
                    if( strTemp.IndexOf( "\r\n" ) > -1 )
                    {
                        strTemp = strTemp.Substring( strTemp.IndexOf( "\r\n" ) + 2 ).Trim();
                        if( !string.IsNullOrEmpty( strTemp ) )
                        {
                            education.fdEducIntro = strTemp;
                            if( education.fdEducIntro.Length > 2000 )
                            {
                                education.fdEducIntro = education.fdEducIntro.Substring( 0, 2000 );
                            }
                        }
                    }
                    education.fdEducIsOverSeas = 1;
                    resume.EducationList.Add( education );
                }
            }
            //语言能力
            if( !string.IsNullOrEmpty( bean.Language.Trim() ) )
            {
                string[] lang = bean.Language.Trim().Split( '\n' );
                foreach( string str in lang )
                {
                    if( str.Trim().StartsWith( "英语级别" ) )
                    {
                        resume.fdResuEnLevel = getEnLevelId( str.Trim() );
                    }
                    else if( str.Trim().StartsWith( "日语等级" ) )
                    {
                        resume.fdResuJpLevel = getJpLevelId( str.Trim() );
                    }
                    else
                    {
                        AW_Language_bean language = new AW_Language_bean();
                        language.fdLangID = new AW_Language_dao().funcNewID();
                        language.fdLangResuID = resume.fdResuID;
                        string[] level = str.Trim().Split( '/' );
                        foreach( string le in level )
                        {
                            if( le.Trim().StartsWith( "TOFEL:" ) )
                            {
                                int tofel = 0;
                                if( int.TryParse( str.Trim().Substring( 6 ), out tofel ) )
                                {
                                    resume.fdResuTOEFL = tofel;
                                }
                                continue;
                            }
                            else if( le.Trim().StartsWith( "IELTS:" ) )
                            {
                                float ielts = 0;
                                if( float.TryParse( str.Trim().Substring( 6 ), out ielts ) )
                                {
                                    resume.fdResuIELTS = ( int ) ielts;
                                }
                                continue;
                            }
                            else if( le.Trim().StartsWith( "听说" ) )
                            {
                                language.fdLangLiAbility = getLangAbilityId( le.Trim().Substring( 4, 2 ) );
                            }
                            else if( le.Trim().StartsWith( "读写" ) )
                            {
                                language.fdLangRWAbility = getLangAbilityId( le.Trim().Substring( 4, 2 ) );
                            }
                            else
                            {
                                if( le.Trim().IndexOf( "(" ) > -1 )
                                {
                                    language.fdLangType = getLangTypeId( le.Trim().Substring( 0, le.Trim().IndexOf( "(" ) ) );
                                    language.fdLangMaster = getLangAbilityId( le.Trim().Substring( le.Trim().IndexOf( "(" ), 2 ) );
                                }
                                else
                                {
                                    language.fdLangType = getLangTypeId( le.Trim() );
                                }
                            }
                        }
                        resume.LanguageList.Add( language );
                    }
                }
            }
            //技能
            if( !string.IsNullOrEmpty( bean.Skill.Trim() ) )
            {
                string[] strSkill = bean.Skill.Trim().Split( '\n' );
                foreach( string str in strSkill )
                {
                    AW_Skills_bean skill = new AW_Skills_bean();
                    skill.fdSkilID = new AW_Skills_dao().funcNewID();
                    skill.fdSkilResuID = resume.fdResuID;
                    string[] strTemp = str.Trim().Split( '-' );
                    for( int i = 0; i < strTemp.Length; i++ )
                    {
                        if( i == 0 )
                        {
                            skill.fdSkilName = strTemp[ i ].Trim();
                        }
                        else if( i == 1 )
                        {
                            skill.fdSkilLevel = getSkillLevelId( strTemp[ i ].Trim() );
                        }
                        else
                        {
                            skill.fdSkilMonth = int.Parse( strTemp[ i ].Trim().Substring( 0, strTemp[ i ].Trim().Length - 1 ) );
                        }
                    }
                    resume.SkillList.Add( skill );
                }
            }
            //证书
            if( !string.IsNullOrEmpty( bean.Cert.Trim() ) )
            {
                string[] strCert = bean.Cert.Trim().Split( '\n' );
                foreach( string str in strCert )
                {
                    AW_Cert_bean cert = new AW_Cert_bean();
                    cert.fdCertID = new AW_Cert_dao().funcNewID();
                    cert.fdCertResuID = resume.fdResuID;
                    DateTime date;
                    if( DateTime.TryParse( str.Trim().Substring( 0, str.Trim().IndexOf( "——" ) ) + "-1", out date ) )
                    {
                        cert.fdCertDate = date;
                    }
                    else
                    {
                        cert.fdCertDate = DateTime.Now;
                    }
                    if( str.IndexOf( ":" ) > -1 )
                    {
                        cert.fdCertName = str.Trim().Substring( str.Trim().IndexOf( "——" ) + 2, str.Trim().IndexOf( ":" ) - str.Trim().IndexOf( "——" ) - 2 );
                        int score = 0;
                        if( int.TryParse( str.Trim().Substring( str.Trim().IndexOf( ":" ) + 1 ), out score ) )
                        {
                            cert.fdCertScore = score;
                        }
                    }
                    else
                    {
                        cert.fdCertName = str.Trim().Substring( str.Trim().IndexOf( "——" ) + 2 );
                    }
                    resume.CertList.Add( cert );
                }
            }
            //创建时间
            resume.fdResuCreateAt = DateTime.Now;
            //更新时间
            resume.fdResuUpdateAt = DateTime.Now;
            //简历状态
            resume.fdResuStatus = 0;
            try
            {
                new AW_Resume_dao().funcInsert( resume );
                foreach( AW_Work_bean work in resume.WorkList )
                {
                    new AW_Work_dao().funcInsert( work );
                }
                foreach( AW_Education_bean education in resume.EducationList )
                {
                    new AW_Education_dao().funcInsert( education );
                }
                foreach( AW_Language_bean language in resume.LanguageList )
                {
                    new AW_Language_dao().funcInsert( language );
                }
                foreach( AW_Skills_bean skill in resume.SkillList )
                {
                    new AW_Skills_dao().funcInsert( skill );
                }
                foreach( AW_Cert_bean cert in resume.CertList )
                {
                    new AW_Cert_dao().funcInsert( cert );
                }
            }
            catch( Exception ex )
            {
                FileInfo fi = new FileInfo( System.Environment.CurrentDirectory + "/Error.log" );
                StringBuilder sb = new StringBuilder();
                sb.AppendLine( "No:" + bean.no + "\r\n" );
                sb.Append( ex.ToString() )
                        .Append( "\r\n" );
                Studio.IO.FileAgent.WriteText( System.Environment.CurrentDirectory + "/Error.log", sb.ToString(), true );
                throw ex;
            }
        }

        /// 获取工作年限
        /// </summary>
        /// <param name="expId"></param>
        /// <returns></returns>
        protected int getExpId( string str )
        {
            switch( str )
            {
                case "在读学生":
                    return 1;
                case "应届毕业生":
                    return 1;
                case "一年以上":
                    return 2;
                case "二年以上":
                case "三年以上":
                case "四年以上":
                    return 3;
                case "五年以上":
                case "六年以上":
                case "七年以上":
                case "八年以上":
                case "九年以上":
                    return 4;
                case "十年以上":
                    return 5;
                default:
                    return 1;
            }
        }

        /// <summary>
        /// 获取年薪
        /// </summary>
        /// <param name="salaryId"></param>
        /// <returns></returns>
        protected int getSalaryId( string str )
        {
            switch( str )
            {
                case "2万以下":
                    return 1;
                case "2-3万":
                    return 2;
                case "3-4万":
                    return 3;
                case "4-5万":
                    return 4;
                case "5-6万":
                    return 5;
                case "6-8万":
                    return 6;
                case "8-10万":
                    return 7;
                case "10-15万":
                    return 8;
                case "15-30万":
                    return 9;
                case "30-50万":
                    return 10;
                case "50-100万":
                    return 11;
                case "100万以上":
                    return 12;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 获取工作类型
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public int getObjeTypeId( string str )
        {
            switch( str )
            {
                case "全职":
                    return 1;
                case "兼职":
                    return 2;
                case "实习":
                    return 3;
                case "全/兼职":
                    return 4;
                default:
                    return 0;
            }
        }

        /// 获取公司规模
        /// </summary>
        /// <param name="dimensionId"></param>
        /// <returns></returns>
        protected int getDimensionId( string str )
        {
            switch( str )
            {
                case "少于50人":
                    return 1;
                case "50-150人":
                    return 2;
                case "150-500人":
                    return 3;
                case "500人以上":
                    return 4;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 获取学历
        /// </summary>
        /// <param name="degreeId"></param>
        /// <returns></returns>
        protected int getDegreeId( string str,out string degree )
        {
            if( str.IndexOf( "初中" ) > -1 )
            {
                degree = "初中";
                return 1;
            }
            else if( str.IndexOf( "高中" ) > -1 )
            {
                degree = "高中";
                return 2;
            }
            else if( str.IndexOf( "中技" ) > -1 )
            {
                degree = "中技";
                return 3;
            }
            else if( str.IndexOf( "中专" ) > -1 )
            {
                degree = "中专";
                return 4;
            }
            else if( str.IndexOf( "大专" ) > -1 )
            {
                degree = "大专";
                return 5;
            }
            else if( str.IndexOf( "本科" ) > -1 )
            {
                degree = "本科";
                return 6;
            }
            else if( str.IndexOf( "MBA" ) > -1 )
            {
                degree = "MBA";
                return 7;
            }
            else if( str.IndexOf( "硕士" ) > -1 )
            {
                degree = "硕士";
                return 8;
            }
            else if( str.IndexOf( "博士" ) > -1 )
            {
                degree = "博士";
                return 9;
            }
            else if( str.IndexOf( "其他" ) > -1 )
            {
                degree = "其他";
                return 10;
            }
            else
            {
                degree = "";
                return 0;
            }
        }

        /// <summary>
        /// 获取语言类别
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        protected int getLangTypeId( string str )
        {
            switch( str )
            {
                case "英语":
                    return 1;
                case "日语":
                    return 2;
                case "俄语":
                    return 3;
                case "阿拉伯语":
                    return 4;
                case "法语":
                    return 5;
                case "德语":
                    return 6;
                case "西班牙语":
                    return 7;
                case "葡萄牙语":
                    return 8;
                case "意大利语":
                    return 9;
                case "韩语/朝鲜语":
                    return 10;
                case "普通话":
                    return 11;
                case "粤语":
                    return 12;
                case "闽南语":
                    return 13;
                case "上海话":
                    return 14;
                case "其它":
                    return 15;
                default:
                    return 1;
            }
        }

        /// <summary>
        /// 获取语言能力
        /// </summary>
        /// <param name="abilId"></param>
        /// <returns></returns>
        protected int getLangAbilityId( string str )
        {
            switch( str )
            {
                case "不限":
                    return 1;
                case "一般":
                    return 2;
                case "良好":
                    return 3;
                case "熟练":
                    return 4;
                case "精通":
                    return 5;
                default:
                    return 1;
            }
        }

        /// <summary>
        /// 获取英语等级
        /// </summary>
        /// <param name="levelId"></param>
        /// <returns></returns>
        protected int getEnLevelId( string str )
        {
            if( str.IndexOf( "未参加" ) > -1 )
            {
                return 1;
            }
            else if( str.IndexOf( "未通过" ) > -1 )
            {
                return 2;
            }
            else if( str.IndexOf( "英语四级" ) > -1 )
            {
                return 3;
            }
            else if( str.IndexOf( "英语六级" ) > -1 )
            {
                return 4;
            }
            else if( str.IndexOf( "专业四级" ) > -1 )
            {
                return 5;
            }
            else if( str.IndexOf( "专业八级" ) > -1 )
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取英语等级
        /// </summary>
        /// <param name="levelId"></param>
        /// <returns></returns>
        protected int getJpLevelId( string str )
        {
            if( str.IndexOf( "无" ) > -1 )
            {
                return 1;
            }
            else if( str.IndexOf( "一级" ) > -1 )
            {
                return 2;
            }
            else if( str.IndexOf( "二级" ) > -1 )
            {
                return 3;
            }
            else if( str.IndexOf( "三级" ) > -1 )
            {
                return 4;
            }
            else if( str.IndexOf( "四级" ) > -1 )
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取技能熟练程度
        /// </summary>
        /// <param name="skillId"></param>
        /// <returns></returns>
        protected int getSkillLevelId( string str )
        {
            switch( str )
            {
                case "精通":
                    return 1;
                case "熟练":
                    return 2;
                case "一般":
                    return 3;
                case "了解":
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
