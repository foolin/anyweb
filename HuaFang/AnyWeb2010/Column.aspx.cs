using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class Column : PageBase
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
        if( columnID == null )
        {
            WebAgent.AlertAndBack( "栏目不存在！" );
        }

        this.Title = column.fdColuName + GeneralConfigs.GetConfig().TitleExtension;

        List<AW_Article_bean> list=new List<AW_Article_bean>();
        using( AW_Article_dao dao = new AW_Article_dao() )
        {
            list = dao.funcGetArticle( column, PN1.PageSize, PN1.PageID );
            PN1.RecordCount = dao.propCount;
            PN2.RecordCount = dao.propCount;
        }
        rep1.DataSource = list.Count > 0 ? list.GetRange( 0, 1 ) : null;
        rep1.DataBind();
        rep2.DataSource = list.Count > 1 ? list.GetRange( 1, list.Count >= 3 ? 2 : list.Count - 1 ) : null;
        rep2.DataBind();
        if( list.Count > 3 )
        {
            rep3.DataSource = list.Count > 3 ? list.GetRange( 3, list.Count >= 8 ? 5 : list.Count - 3 ) : null;
            rep3.DataBind();
            if( list.Count > 8 )
            {
                rep4.DataSource = list.GetRange( 8, list.Count >= 13 ? 5 : list.Count - 8 );
                rep4.DataBind();
            }
            else
            {
                div1.Visible = false;
            }
            if( list.Count > 13 )
            {
                rep5.DataSource = list.GetRange( 13, list.Count - 13 );
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
