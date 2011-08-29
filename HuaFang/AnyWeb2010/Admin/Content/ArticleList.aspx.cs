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

public partial class Admin_ArticleList : PageAdmin
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);

        int cid = 0;
        int.TryParse( QS( "cid" ), out cid );
        AW_Column_bean column = null;
        if( cid > 0 )
        {
            column = new AW_Column_dao().funcGetColumnInfo( cid );
        }

        litJs.Text = "child[0] = new Array;";
        int i = 1;
        foreach( AW_Column_bean bean1 in ( new AW_Column_dao() ).funcGetColumns() )
        {
            drpColumn.Items.Add( new ListItem( bean1.fdColuName, bean1.fdColuID.ToString() ) );
            litJs.Text += string.Format( "child[{0}] = new Array;", i );
            int j = 0;

            if( column != null && ( bean1.fdColuID == column.fdColuID || bean1.fdColuID == column.fdColuParentID ) )
            {
                foreach( AW_Column_bean bean2 in bean1.Children )
                {
                    drpChild.Items.Add( new ListItem( bean2.fdColuName, bean2.fdColuID.ToString() ) );
                    litJs.Text += string.Format( "child[{0}][{1}] = \"{2}:{3}\";", i, j, bean2.fdColuID, bean2.fdColuName );
                    j++;
                }
            }
            else
            {
                foreach( AW_Column_bean bean2 in bean1.Children )
                {
                    litJs.Text += string.Format( "child[{0}][{1}] = \"{2}:{3}\";", i, j, bean2.fdColuID, bean2.fdColuName );
                    j++;
                }
            }
            i++;
        }

        if( column != null )
        {
            if( column.fdColuParentID == 0 )
            {
                drpColumn.SelectedValue = column.fdColuID.ToString();
                drpChild.SelectedValue = "0";
            }
            else
            {
                drpColumn.SelectedValue = column.fdColuParentID.ToString();
                drpChild.SelectedValue = column.fdColuID.ToString();
            }
        }

        txtKey.Text = QS( "key" ).Trim();

        using (AW_Article_dao dao = new AW_Article_dao())
        {
            compRep.DataSource = dao.funcGetArticle( column, txtKey.Text, PN1.PageSize, PN1.PageIndex );
            compRep.DataBind();
            PN1.SetPage(dao.propCount);
        }
    }

}
