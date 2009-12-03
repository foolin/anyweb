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
using Common.Common;
using Studio.Web;

public partial class UserAfficheEdit : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            switch ( QS( "mode" ) )
            {

                case "update":
                    this.fv1.ChangeMode( FormViewMode.Edit );
                    litTitle.Text = "修改用户公告";
                    break;
                default:
                    this.fv1.ChangeMode( FormViewMode.ReadOnly );
                    litTitle.Text = "查看用户公告";
                    break;
            }
        }
    }

    protected void ods3_Updating(object sender , ObjectDataSourceMethodEventArgs e)
    {
        Affiche affi = (Affiche)e.InputParameters[0];
        affi.Type = 0;
    }
   
    protected void ods3_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Update , "修改公告" , "修改公告" );

            WebAgent.SuccAndGo( "修改成功." , "UserAfficheList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "修改失败." , "UserAfficheList.aspx" );
        }
    }
}
