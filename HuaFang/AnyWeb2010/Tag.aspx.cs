using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;
using AnyWell.Configs;

public partial class Tag : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int tagId = 0;
        if( !int.TryParse( ( string ) Context.Items[ "TAGID" ], out tagId ) )
        {
            WebAgent.AlertAndBack( "页面不存在！" );
        }
        tag = AW_Tag_bean.funcGetByID( tagId );
        if( tag == null )
        {
            WebAgent.AlertAndBack( "页面不存在！" );
        }
        this.Title = tag.fdTagName + GeneralConfigs.GetConfig().TitleExtension;

        int record = 0;
        List<AW_Article_bean> list = new List<AW_Article_bean>();
        using( AW_Article_dao dao = new AW_Article_dao() )
        {
            list = dao.funcGetArticleListByTag( tag.fdTagID, PN1.PageID, PN1.PageSize, out record );
        }
        if( record == 0 )
        {
            divSearch.Visible = false;
            divNull.Visible = true;
        }
        else
        {
            rep1.DataSource = list.Count > 5 ? list.GetRange( 0, 5 ) : list;
            rep1.DataBind();
            if( list.Count > 5 )
            {
                rep2.DataSource = list.GetRange( 5, list.Count >= 10 ? 5 : list.Count - 5 );
                rep2.DataBind();
            }
            else
            {
                div1.Visible = false;
            }
            if( list.Count > 10 )
            {
                rep3.DataSource = list.GetRange( 10, list.Count - 10 );
                rep3.DataBind();
            }
            else
            {
                div2.Visible = false;
            }
        }
        PN1.RecordCount = record;
        PN2.RecordCount = record;
    }

    private AW_Tag_bean _tag;
    public AW_Tag_bean tag
    {
        get
        {
            return _tag;
        }
        set
        {
            _tag = value;
        }
    }
}
