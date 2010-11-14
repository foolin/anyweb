using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class User_ObjeEdit : PageUser
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
    }

    protected string getAreaName()
    {
        string str = "";
        if( bean.fdResuObjeAreaID1 != 0 )
        {
            str += "+" + bean.fdResuObjeArea1;
        }
        if( bean.fdResuObjeAreaID2 != 0 )
        {
            str += "+" + bean.fdResuObjeArea2;
        }
        if( bean.fdResuObjeAreaID3 != 0 )
        {
            str += "+" + bean.fdResuObjeArea3;
        }
        if( bean.fdResuObjeAreaID4 != 0 )
        {
            str += "+" + bean.fdResuObjeArea4;
        }
        if( bean.fdResuObjeAreaID5 != 0 )
        {
            str += "+" + bean.fdResuObjeArea5;
        }
        if( str.Length > 0 )
            return str.Substring( 1 );
        else
            return "选择/修改";
    }

    protected string getIndustryName()
    {
        string str = "";
        if( bean.fdResuObjeIndustryID1 != 0 )
        {
            str += "+" + bean.fdResuObjeIndustry1;
        }
        if( bean.fdResuObjeIndustryID2 != 0 )
        {
            str += "+" + bean.fdResuObjeIndustry2;
        }
        if( bean.fdResuObjeIndustryID3 != 0 )
        {
            str += "+" + bean.fdResuObjeIndustry3;
        }
        if( bean.fdResuObjeIndustryID4 != 0 )
        {
            str += "+" + bean.fdResuObjeIndustry4;
        }
        if( bean.fdResuObjeIndustryID5 != 0 )
        {
            str += "+" + bean.fdResuObjeIndustry5;
        }
        if( str.Length > 0 )
            return str.Substring( 1 );
        else
            return "选择/修改";
    }

    protected string getFuncTypeName()
    {
        string str = "";
        if( bean.fdResuObjeFuncTypeID1 != 0 )
        {
            str += "+" + bean.fdResuObjeFuncType1;
        }
        if( bean.fdResuObjeFuncTypeID2 != 0 )
        {
            str += "+" + bean.fdResuObjeFuncType2;
        }
        if( bean.fdResuObjeFuncTypeID3 != 0 )
        {
            str += "+" + bean.fdResuObjeFuncType3;
        }
        if( bean.fdResuObjeFuncTypeID4 != 0 )
        {
            str += "+" + bean.fdResuObjeFuncType4;
        }
        if( bean.fdResuObjeFuncTypeID5 != 0 )
        {
            str += "+" + bean.fdResuObjeFuncType5;
        }
        if( str.Length > 0 )
            return str.Substring( 1 );
        else
            return "选择/修改";
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
