using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;

public partial class Controls_SideMenu : System.Web.UI.UserControl
{
    protected void Page_Load( object sender, EventArgs e )
    {
        repSideMenu.DataSource = navigationList;
        repSideMenu.DataBind();
    }

    private List<AW_Navigation_bean> _navigationList;
    public List<AW_Navigation_bean> navigationList
    {
        get
        {
            if( _navigationList == null )
            {
                _navigationList = new AW_Navigation_dao().funcGetNavigations();
            }
            return _navigationList;
        }
    }

    public int navigationCount
    {
        get
        {
            return _navigationList.Count;
        }
    }
}
