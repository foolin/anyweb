using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_Content_TemplateSet : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int sid = 0, type = 0;
        string key = QS( "key" ).Trim();

        int.TryParse( QS( "sid" ), out sid );
        if( sid == 0 )
        {
            ShowError( "请选择站点！" );
        }

        int.TryParse( QS( "type" ), out type );
        if( type == 0 )
        {
            ShowError( "模板类型错误！" );
        }

        AW_Site_dao siteDao = new AW_Site_dao();
        AW_Column_dao columnDao = new AW_Column_dao();

        CurrentSite = siteDao.funcGetSiteInfo( sid );
        if( CurrentSite == null )
        {
            ShowError( "站点不存在！" );
        }

        if( QS( "column" ) == "true" )
        {
            if( string.IsNullOrEmpty( QS( "cid" ) ) || !WebAgent.IsInt32( QS( "cid" ) ) )
            {
                ShowError( "请选择栏目！" );
            }
            CurrentColumn = columnDao.funcGetColumnInfo( int.Parse( QS( "cid" ) ) );
            if( CurrentColumn == null )
            {
                ShowError( "栏目不存在！" );
            }
        }

        if( !IsPostBack )
        {
            repTemplate.DataSource = new AW_Template_dao().funcGetTemplateList( CurrentSite.fdSiteID, key, type );
            repTemplate.DataBind();
        }
        else
        {
            if( string.IsNullOrEmpty( QF( "ids" ) ) )
            {
                ShowError( "请选择模板！" );
            }
            AW_Template_bean bean = CurrentSite.GetTemplate( int.Parse( QF( "ids" ) ) );
            if( bean == null )
            {
                ShowError( "模板不存在！" );
            }
            string tempTypeStr = "";
            if( QS( "column" ) == "true" )
            {
                if( type == 1 )
                {
                    CurrentColumn.fdColuIndexTemplateID = bean.fdTempID;
                    CurrentColumn.IndexTemplate = bean;
                    tempTypeStr = "栏目模板";
                }
                else if( type == 2 )
                {
                    CurrentColumn.fdColuContentTemplateID = bean.fdTempID;
                    CurrentColumn.ContentTemplate = bean;
                    tempTypeStr = "内容模板";
                }
                columnDao.funcUpdate( CurrentColumn );
                AddLog( EventType.Update, "设置模板", string.Format( "设置栏目[{0}]{1}", CurrentColumn.fdColuName, tempTypeStr ) );
            }
            else
            {
                if( type == 4 )
                {
                    CurrentSite.fdSiteIndexTemplateID = bean.fdTempID;
                    CurrentSite.IndexTemplate = bean;
                    tempTypeStr = "首页模板";
                }
                else if( type == 1 )
                {
                    CurrentSite.fdSiteColumnTemplateID = bean.fdTempID;
                    CurrentSite.ColumnTemplate = bean;
                    tempTypeStr = "栏目模板";
                }
                else if( type == 2 )
                {
                    CurrentSite.fdSiteContentTemplateID = bean.fdTempID;
                    CurrentSite.ContentTemplate = bean;
                    tempTypeStr = "内容模板";
                }
                siteDao.funcUpdate( CurrentSite );
                AddLog( EventType.Update, "设置模板", string.Format( "设置站点[{0}]{1}", CurrentSite.fdSiteName, tempTypeStr ) );
            }
            Response.Write( "<script type=text/javascript>parent.setTemplateOK();</script>" );
            Response.End();
        }
    }
}
