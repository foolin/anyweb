﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ExhibitorSearch : PageBase
{
    protected void Page_Load( object sender, EventArgs e )
    {
        string templatePath = string.Format( "~/Contorls/Exhibitor/Search/{0}.ascx", SiteID );
        BuildPage( templatePath );
    }
}
