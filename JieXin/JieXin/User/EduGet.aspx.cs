﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class User_EduGet : PageUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if( string.IsNullOrEmpty( QS( "id" ) ) || !WebAgent.IsInt32( QS( "id" ) ) )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        AW_Resume_bean bean = new AW_Resume_dao().funcGetResumeById( int.Parse( QS( "id" ) ) );
        if( bean == null || bean.fdResuUserID != this.LoginUser.fdUserID )
        {
            Response.Clear();
            Response.Write( "" );
            Response.End();
        }
        this._eduId = new AW_Education_dao().funcNewID();
    }

    private int _eduId;
    public int eduID
    {
        get { return _eduId; }
        set { _eduId = value; }
    }
}
