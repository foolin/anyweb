using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWeb.AW_DL;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnPreRender(EventArgs e)
    {
    }

    public List<AW_AD_bean> adList
    {
        get 
        { 
            return new AW_AD_dao().funcGetAdList();
        }
    }
}
