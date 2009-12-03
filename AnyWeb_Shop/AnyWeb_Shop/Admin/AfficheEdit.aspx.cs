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
using Common.Agent;

public partial class AfficheEdit :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            switch ( QS( "mode" ) )
            {
                case "update":
                    this.fv1.ChangeMode( FormViewMode.Edit );
                    litTitle.Text = "修改公告";
                    break;
                case "delete":
                    if ( WebAgent.IsInt32( QS( "affid" ) ) )
                    {
                        using ( AfficheAgent af = new AfficheAgent() )
                        {
                            Affiche a = new Affiche();
                            a.ID = int.Parse( QS( "affid" ) );
                            if ( af.AfficheDelete( a ) > 0 )
                            {
                                WebAgent.SuccAndGo( "删除成功" , "AfficheList.aspx" );
                            }
                        }
                    }
                    break;
                default:
                    this.fv1.ChangeMode( FormViewMode.Insert );
                    litTitle.Text = "添加公告";
                    break;
            }
        }
    }
    protected void ods3_Updating(object sender , ObjectDataSourceMethodEventArgs e)
    {
       Affiche affi =(Affiche)e.InputParameters[0];
       affi.Type = 0;
    }
    protected void ods3_Inserted(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Insert , "添加公告" , "添加公告" );

            WebAgent.SuccAndGo( "添加成功." , ViewState["BACK"].ToString() );
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
            this.AddLog( EventID.Update , "修改公告" , "修改公告,公告编号：" + QS( "affid" ) );

            WebAgent.SuccAndGo( "修改成功." , ViewState["BACK"].ToString() );
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
            this.AddLog( EventID.Delete , "删除公告" , "删除公告,公告编号：" + QS( "affid" ) );

            WebAgent.SuccAndGo( "删除成功." , ViewState["BACK"].ToString() );
        }
        else
        {
            WebAgent.FailAndGo( "删除失败." , ViewState["BACK"].ToString() );
        }
    }
}
