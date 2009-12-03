using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Framework;
using Common.Agent;
using Studio.Web;

public partial class ShopArticleSet : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            chkShow.Checked = ShopInfo.ShowHelp;
        }
    }

    protected override void OnPreLoad(EventArgs e)
    {
        
    }

    protected void btnSave_Click(object sender , EventArgs e)
    {
        using ( ShopAgent sa = new ShopAgent() )
        {
            if ( sa.updateShowHelp( this.chkShow.Checked ) > 0 )
            {
                WebAgent.SuccAndGo( "设置成功" , "ShopArticleList.aspx" );
            }

        }
    }
}
