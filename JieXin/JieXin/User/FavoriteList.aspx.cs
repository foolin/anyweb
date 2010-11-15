using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class User_FavoriteList : PageUser
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int recordCount = 0;
        rep.DataSource = new AW_Favorite_dao().funcGetFavoriteList( this.LoginUser.fdUserID, PN1.PageIndex, PN1.PageSize, out recordCount );
        rep.DataBind();
        PN1.SetPage( recordCount );
    }
}
