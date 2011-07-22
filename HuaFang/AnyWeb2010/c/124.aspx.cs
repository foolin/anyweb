using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using AnyWell.Configs;

public partial class c_124 : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "秀场直击" + GeneralConfigs.GetConfig().TitleExtension;

        repHot.DataSource = new AW_Article_dao().funcGetArticleListByUC( 124, 10, true, "fdArtiRecommend=1", "", "", false );
        repHot.DataBind();
    }
}
