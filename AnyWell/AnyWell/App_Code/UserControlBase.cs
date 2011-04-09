using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///UserControlBase 的摘要说明
/// </summary>
public class UserControlBase : System.Web.UI.UserControl
{
    public UserControlBase()
    {
        
    }

    protected string QS( string key )
    {
        return Request.QueryString[ key ] + "";
    }

    protected string QF( string key )
    {
        return Request.Form[ key ] + "";
    }
}
