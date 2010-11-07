using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class AnyWell_Article : PageBase
{
    protected override void OnPreRender( EventArgs e )
    {
        int articleid = 0;
        int.TryParse( Context.Items[ "ARTICLEID" ] + "", out articleid );
        if( articleid == 0 )
        {
            goErrorPage();
        }

        AW_Article_bean article = AW_Article_bean.funcGetByID( articleid );
        if( article == null )
        {
            goErrorPage();
        }

        HttpContext.Current.Items.Add( "ARTICLE_" + articleid, article );

        new AW_Article_dao().funcUpdateClick( article.fdArtiID );

        this.Title = "广州市杰信人力资源有限公司 - " + article.fdArtiTitle;
    }
}
