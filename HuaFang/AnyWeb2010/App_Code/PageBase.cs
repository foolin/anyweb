using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class PageBase : Page
{
    protected string QS( string key )
    {
        return Request.QueryString[ key ] + "";
    }

    protected string QF( string key )
    {
        return Request.Form[ key ] + "";
    }
}
