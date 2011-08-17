using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class Asp_Column : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int columnID = 0;
        int.TryParse( ( string ) Context.Items[ "COLUMNID" ], out columnID );
        if( columnID == 0 )
        {
            WebAgent.AlertAndBack( "栏目不存在！" );
        }
        AW_Column_bean column = new AW_Column_dao().funcGetColumnInfo( columnID );
        if( column == null )
        {
            WebAgent.AlertAndBack( "栏目不存在！" );
        }

        this.Title = column.fdColuName + GeneralConfigs.GetConfig().TitleExtension;

        int record = 0;
        List<AW_Article_bean> hotList = new AW_Article_dao().funcGetArticleListByUC( column.fdColuID, 3, true, "", "", "", false );
        List<AW_Article_bean> list = new List<AW_Article_bean>();
        string topIds = "";
        foreach( AW_Article_bean a in hotList )
        {
            topIds += "," + a.fdArtiID;
        }
        if( topIds.Length > 0 )
        {
            topIds = topIds.Substring( 1 );
            list = new AW_Article_dao().funcGetArticleListByUC( column.fdColuID, true, string.Format( "fdArtiID NOT IN ({0})", topIds ), "", PN1.PageID, PN1.PageSize, out record, false );
        }

        PN1.RecordCount = PN2.RecordCount = record;

        rep1.DataSource = hotList.Count > 0 ? hotList.GetRange( 0, 1 ) : null;
        rep1.DataBind();
        rep2.DataSource = hotList.Count > 1 ? hotList.GetRange( 1, hotList.Count - 1 ) : null;
        rep2.DataBind();
        if( list.Count > 0 )
        {
            rep3.DataSource = list.GetRange( 0, list.Count >= 5 ? 5 : list.Count );
            rep3.DataBind();
            if( list.Count > 5 )
            {
                rep4.DataSource = list.GetRange( 5, list.Count >= 10 ? 5 : list.Count - 5 );
                rep4.DataBind();
            }
            else
            {
                div1.Visible = false;
            }
            if( list.Count > 10 )
            {
                rep5.DataSource = list.GetRange( 10, list.Count - 10 );
                rep5.DataBind();
            }
            else
            {
                div2.Visible = false;
            }
        }
        else
        {
            divMore1.Visible = false;
            divMore2.Visible = false;
        }
    }
}
