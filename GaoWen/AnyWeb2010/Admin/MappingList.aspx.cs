using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;

public partial class Admin_MappingList : PageAdmin
{
    protected override void OnPreRender(EventArgs e)
    {
        repMapping.DataSource = new AW_Mapping_dao().funcGetMappingList();
        repMapping.DataBind();
    }
}
