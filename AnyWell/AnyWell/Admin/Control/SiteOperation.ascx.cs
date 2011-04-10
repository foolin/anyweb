using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Admin_Control_SiteOperation : UserControlBase
{
    protected AW_Site_bean CurrentSite
    {
        get
        {
            return ( ( PageAdmin ) Page ).CurrentSite;
        }
    }
}
