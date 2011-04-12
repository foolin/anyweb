using System;
using System.Collections.Generic;
using System.Web;
using AnyWell.AW_DL;

/// <summary>
///UserControlBase 的摘要说明
/// </summary>
public class UserControlBase : System.Web.UI.UserControl
{
    protected string QS( string key )
    {
        return Request.QueryString[ key ] + "";
    }

    protected string QF( string key )
    {
        return Request.Form[ key ] + "";
    }

    protected AW_Column_bean CurrentColumn
    {
        get
        {
            return ( ( PageAdmin ) Page ).CurrentColumn;
        }
    }
}
