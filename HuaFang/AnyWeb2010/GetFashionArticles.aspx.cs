using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.Text;

public partial class GetFashionArticles : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int col = 0, cate = 0, city = 0;
        int.TryParse( QS( "col" ), out col );
        int.TryParse( QS( "cate"), out cate  );
        int.TryParse( QS( "city" ), out city );
        if( col == 0 || cate == 0 || city == 0 )
            return;
        List<AW_Article_bean> list = new AW_Article_dao().funcGetFashionArticleList( col, cate, city );
        StringBuilder sb = new StringBuilder();
        foreach( AW_Article_bean bean in list )
        {
            sb.AppendFormat( "var a = new article({0},\"{1}\");articles.push(a);", bean.fdArtiID, bean.fdArtiTitle );
        }
        Response.Clear();
        Response.Write( sb.ToString() );
        Response.End();
    }
}
