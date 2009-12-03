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
using Studio.Web;
using Common.Agent;
using Common.Common;

public partial class Service :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }
 

    protected override void OnPreRender(EventArgs e)
    {
        using ( ShopSettingAgent sa = new ShopSettingAgent() )
        {
            ShopSetting s = sa.GetShopSettingInfo();
            if ( s != null )
            {
                txtContent.Text = s.Service;
            }
        }
    }
    protected void btnSave_Click(object sender , EventArgs e)
    {
        using ( ShopSettingAgent sa = new ShopSettingAgent() )
        {
            ShopSetting s = new ShopSetting();
            s.Service = txtContent.Text;
            if ( sa.UpdateService( s ) > 0 )
            {
                this.AddLog( Common.Common.EventID.Update , "编辑服务条款" , "编辑服务条款" );
                WebAgent.SuccAndGo( "保存成功" , "Service.aspx" );
            }
        }
    }
}
