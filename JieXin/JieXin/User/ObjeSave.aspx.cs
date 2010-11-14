using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class User_ObjeSave : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }

        bean = AW_Resume_bean.funcGetByID( int.Parse( QS( "id" ) ) );
        if( bean == null || bean.fdResuUserID != this.LoginUser.fdUserID )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        bean.fdResuObjeType = int.Parse( QF( "Obje_Type" ) );

        ClearArea();
        string AreaIDs = QF( "Obje_AreaID" ).Trim();
        if( AreaIDs.EndsWith( ";" ) )
        {
            AreaIDs = AreaIDs.Substring( 0, AreaIDs.Length - 1 );
        }
        string AreaNames = QF( "Obje_AreaName" ).Trim();
        if( AreaIDs.Length > 0 )
        {
            string[] AreaID = AreaIDs.Split( ';' );
            string[] AreaName = AreaNames.Split( ';' );
            for( int i = 0; i < AreaID.Length; i++ )
            {
                switch( i )
                {
                    case 0:
                        bean.fdResuObjeAreaID1 = int.Parse( AreaID[ i ] );
                        bean.fdResuObjeArea1 = AreaName[ i ];
                        break;
                    case 1:
                        bean.fdResuObjeAreaID2 = int.Parse( AreaID[ i ] );
                        bean.fdResuObjeArea2 = AreaName[ i ];
                        break;
                    case 2:
                        bean.fdResuObjeAreaID3 = int.Parse( AreaID[ i ] );
                        bean.fdResuObjeArea3 = AreaName[ i ];
                        break;
                    case 3:
                        bean.fdResuObjeAreaID4 = int.Parse( AreaID[ i ] );
                        bean.fdResuObjeArea4 = AreaName[ i ];
                        break;
                    case 4:
                        bean.fdResuObjeAreaID5 = int.Parse( AreaID[ i ] );
                        bean.fdResuObjeArea5 = AreaName[ i ];
                        break;
                    default:
                        break;
                }
            }
        }

        ClearIndustry();
        string IndustryIDs = QF( "Obje_IndustryID" ).Trim();
        if( IndustryIDs.EndsWith( ";" ) )
        {
            IndustryIDs = IndustryIDs.Substring( 0, IndustryIDs.Length - 1 );
        }
        string IndustryNames = QF( "Obje_IndustryName" ).Trim();
        if( IndustryIDs.Length > 0 )
        {
            string[] IndustryID = IndustryIDs.Split( ';' );
            string[] IndustryName = IndustryNames.Split( ';' );
            for( int i = 0; i < IndustryID.Length; i++ )
            {
                switch( i )
                {
                    case 0:
                        bean.fdResuObjeIndustryID1 = int.Parse( IndustryID[ i ] );
                        bean.fdResuObjeIndustry1 = IndustryName[ i ];
                        break;
                    case 1:
                        bean.fdResuObjeIndustryID2 = int.Parse( IndustryID[ i ] );
                        bean.fdResuObjeIndustry2 = IndustryName[ i ];
                        break;
                    case 2:
                        bean.fdResuObjeIndustryID3 = int.Parse( IndustryID[ i ] );
                        bean.fdResuObjeIndustry3 = IndustryName[ i ];
                        break;
                    case 3:
                        bean.fdResuObjeIndustryID4 = int.Parse( IndustryID[ i ] );
                        bean.fdResuObjeIndustry4 = IndustryName[ i ];
                        break;
                    case 4:
                        bean.fdResuObjeIndustryID5 = int.Parse( IndustryID[ i ] );
                        bean.fdResuObjeIndustry5 = IndustryName[ i ];
                        break;
                    default:
                        break;
                }
            }
        }

        ClearFuncType();
        string FuncTypeIDs = QF( "Obje_FuncTypeID" ).Trim();
        if( FuncTypeIDs.EndsWith( ";" ) )
        {
            FuncTypeIDs = FuncTypeIDs.Substring( 0, FuncTypeIDs.Length - 1 );
        }
        string FuncTypeNames = QF( "Obje_FuncTypeName" ).Trim();
        if( FuncTypeIDs.Length > 0 )
        {
            string[] FuncTypeID = FuncTypeIDs.Split( ';' );
            string[] FuncTypeName = FuncTypeNames.Split( ';' );
            for( int i = 0; i < FuncTypeID.Length; i++ )
            {
                switch( i )
                {
                    case 0:
                        bean.fdResuObjeFuncTypeID1 = int.Parse( FuncTypeID[ i ] );
                        bean.fdResuObjeFuncType1 = FuncTypeName[ i ];
                        break;
                    case 1:
                        bean.fdResuObjeFuncTypeID2 = int.Parse( FuncTypeID[ i ] );
                        bean.fdResuObjeFuncType2 = FuncTypeName[ i ];
                        break;
                    case 2:
                        bean.fdResuObjeFuncTypeID3 = int.Parse( FuncTypeID[ i ] );
                        bean.fdResuObjeFuncType3 = FuncTypeName[ i ];
                        break;
                    case 3:
                        bean.fdResuObjeFuncTypeID4 = int.Parse( FuncTypeID[ i ] );
                        bean.fdResuObjeFuncType4 = FuncTypeName[ i ];
                        break;
                    case 4:
                        bean.fdResuObjeFuncTypeID5 = int.Parse( FuncTypeID[ i ] );
                        bean.fdResuObjeFuncType5 = FuncTypeName[ i ];
                        break;
                    default:
                        break;
                }
            }
        }

        bean.fdResuObjeSalery = int.Parse( QF( "Obje_Salery" ) );
        bean.fdResuObjeEntryTime = int.Parse( QF( "Obje_EntryTime" ) );
        bean.fdResuObjeDepartment = QF( "Obje_Department" ).Trim();
        bean.fdResuObjeCompType = int.Parse( QF( "Obje_CompType" ) );
        bean.fdResuObjeIntro = QF( "Obje_Intro" ).Trim();

        bean.fdResuStatus = 0;
        bean.fdResuUpdateAt = DateTime.Now;

        new AW_Resume_dao().funcUpdate( bean );
    }

    protected void ClearArea()
    {
        bean.fdResuObjeAreaID1 = 0;
        bean.fdResuObjeArea1 = "";
        bean.fdResuObjeAreaID2 = 0;
        bean.fdResuObjeArea2 = "";
        bean.fdResuObjeAreaID3 = 0;
        bean.fdResuObjeArea3 = "";
        bean.fdResuObjeAreaID4 = 0;
        bean.fdResuObjeArea4 = "";
        bean.fdResuObjeAreaID5 = 0;
        bean.fdResuObjeArea5 = "";
    }

    protected void ClearIndustry()
    {
        bean.fdResuObjeIndustryID1 = 0;
        bean.fdResuObjeIndustry1 = "";
        bean.fdResuObjeIndustryID2 = 0;
        bean.fdResuObjeIndustry2 = "";
        bean.fdResuObjeIndustryID3 = 0;
        bean.fdResuObjeIndustry3 = "";
        bean.fdResuObjeIndustryID4 = 0;
        bean.fdResuObjeIndustry4 = "";
        bean.fdResuObjeIndustryID5 = 0;
        bean.fdResuObjeIndustry5 = "";
    }

    protected void ClearFuncType()
    {
        bean.fdResuObjeFuncTypeID1 = 0;
        bean.fdResuObjeFuncType1 = "";
        bean.fdResuObjeFuncTypeID2 = 0;
        bean.fdResuObjeFuncType2 = "";
        bean.fdResuObjeFuncTypeID3 = 0;
        bean.fdResuObjeFuncType3 = "";
        bean.fdResuObjeFuncTypeID4 = 0;
        bean.fdResuObjeFuncType4 = "";
        bean.fdResuObjeFuncTypeID5 = 0;
        bean.fdResuObjeFuncType5 = "";
    }

    private AW_Resume_bean _bean;
    public AW_Resume_bean bean
    {
        get
        {
            return _bean;
        }
        set
        {
            _bean = value;
        }
    }
}
