﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Setting_LinksDel : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string ids = QF( "ids" );
        string url = Request.UrlReferrer == null ? "LinkList.aspx" : Request.UrlReferrer.AbsoluteUri;
        if( String.IsNullOrEmpty( ids ) )
        {
            Response.Redirect( url );
        }

        int record = new AW_Link_dao().funcDeletes( ids );
        if( record > 0 )
        {
            this.AddLog( EventType.Delete, "批量删除友情链接", "批量删除友情链接编号[" + ids + "]" );
            Studio.Web.WebAgent.SuccAndGo( "删除成功", url );
        }
    }
}
