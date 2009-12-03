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
using Common.Common;
using Common.Agent;

public partial class AdvertisementEdit :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            switch ( QS( "mode" ) )
            {
                case "select":
                    this.fv1.ChangeMode( FormViewMode.ReadOnly );
                    litTitle.Text = "查看广告";
                    break;
                case "update":
                    this.fv1.ChangeMode( FormViewMode.Edit );
                    litTitle.Text = "修改广告";
                    break;
                case "delete":
                    if ( WebAgent.IsInt32( QS( "adid" ) ) )
                    {
                        using ( AdvertisementAgent at = new AdvertisementAgent() )
                        {
                            Advertisement a = new Advertisement();
                            a.ID = int.Parse( QS( "adid" ) );
                            if ( at.AdDelete(a) > 0 )
                            {
                                WebAgent.SuccAndGo( "删除成功" , "AdvertisementList.aspx" );
                            }
                        }
                    }
                    break;
                default:
                    this.fv1.ChangeMode( FormViewMode.Insert );
                    litTitle.Text = "添加广告";
                    break;
            }
        }

    }
  
    protected void ods3_Inserted(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Insert , "添加广告" , "添加广告" );

            WebAgent.SuccAndGo( "添加成功." , "AdvertisementList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "添加失败." , ViewState["BACK"].ToString() );
        }
    }
    protected void ods3_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Update , "修改广告" , "修改广告" );

            WebAgent.SuccAndGo( "修改成功." , "AdvertisementList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "修改失败." , ViewState["BACK"].ToString() );
        }
    }
    protected void ods3_Deleted(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Delete , "删除广告" , "删除广告" );

            WebAgent.SuccAndGo( "删除成功." , "AdvertisementList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "删除失败." , ViewState["BACK"].ToString() );
        }
    }
}
