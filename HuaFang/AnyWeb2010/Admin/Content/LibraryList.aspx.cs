using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using AnyWell.AW_DL;

public partial class Admin_LibraryList : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        drpLibrary.SelectedValue = QS("library");
        drpCelebrity.SelectedValue = QS( "celebrity" );
        drpFirstLetter.SelectedValue = QS("firstLetter");
        string keyword = txtKey.Text = QS( "key" ).Trim();

        if( keyword.Contains( "%" ) )
        {
            keyword = keyword.Replace( "%", "[%]" );
        }
        if( keyword.Contains( "'" ) )
        {
            keyword = keyword.Replace( "'", "''" );
        }
        string querryString = SearchKeyWord.getLibraryQueryString( keyword );

        using (AW_Library_dao dao = new AW_Library_dao())
        {
            repLibrary.DataSource = dao.funcGetLibrary( int.Parse( drpLibrary.SelectedValue ), int.Parse( drpCelebrity.SelectedValue ), int.Parse( drpFirstLetter.SelectedValue ), querryString, PN1.PageSize, PN1.PageIndex );
            repLibrary.DataBind();
            PN1.SetPage(dao.propCount);
        }
    }
}
