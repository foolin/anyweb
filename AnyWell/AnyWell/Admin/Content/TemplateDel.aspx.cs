using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.IO;
using System.Data;

public partial class Admin_Content_TemplateDel : PageAdmin
{
    DataSet ds;
    AW_Column_dao columnDao = new AW_Column_dao();
    protected void Page_Load( object sender, EventArgs e )
    {
        int sid = 0;
        int.TryParse( QS( "sid" ), out sid );
        if( sid == 0 )
        {
            ShowError( "站点不存在！" );
        }

        CurrentSite = new AW_Site_dao().funcGetSiteInfo( sid );
        if( CurrentSite == null )
        {
            ShowError( "站点不存在！" );
        }

        string ids = QS( "ids" ).Trim();
        if( string.IsNullOrEmpty( ids ) )
        {
            ShowError( "请选择模板！" );
        }

        AW_Template_dao dao = new AW_Template_dao();
        List<AW_Template_bean> list = new List<AW_Template_bean>();

        foreach( string templateid in ids.Split(',') )
        {
            AW_Template_bean bean = CurrentSite.GetTemplate( int.Parse( templateid ) );
            if( bean != null )
            {
                list.Add( bean );
            }
        }

        if( !IsPostBack )
        {
            ds = columnDao.funcGetColumnListByTemplate( CurrentSite.fdSiteID, ids );
            repTemplate.DataSource = list;
            repTemplate.DataBind();
        }
        else
        {
            if( dao.funcDeleteTemplate( ids ) )
            {
                string templatePath = Server.MapPath( "/Files/Template/" );
                //更新栏目模板
                new AW_Column_dao().funcDeleteColumnTemplate( CurrentSite.Columns, list );
                foreach( AW_Template_bean bean in list )
                {
                    //更新站点模板
                    if( CurrentSite.fdSiteIndexTemplateID == bean.fdTempID )
                    {
                        CurrentSite.fdSiteIndexTemplateID = 0;
                        CurrentSite.IndexTemplate = null;
                    }

                    if( CurrentSite.fdSiteColumnTemplateID == bean.fdTempID )
                    {
                        CurrentSite.fdSiteColumnTemplateID = 0;
                        CurrentSite.ColumnTemplate = null;
                    }

                    if( CurrentSite.fdSiteContentTemplateID == bean.fdTempID )
                    {
                        CurrentSite.fdSiteContentTemplateID = 0;
                        CurrentSite.ContentTemplate = null;
                    }
                    //移除模板
                    CurrentSite.TemplateList.Remove( bean );

                    AddLog( EventType.Delete, "删除模板", string.Format( "站点[{0}]删除模板:[{1}]", CurrentSite.fdSiteName, bean.fdTempName ) );
                    string fileTemplate = string.Format( "{0}\\{1}\\{2}.ascx", templatePath, bean.fdTempSiteID, bean.fdTempName );
                    if( File.Exists( fileTemplate ) )
                    {
                        File.Delete( fileTemplate );
                    }
                }
            }
            Response.Write( "<script type=text/javascript>parent.delTemplateOK();</script>" );
            Response.End();
        }
    }

    protected void repTemplate_ItemDataBound( object sender, RepeaterItemEventArgs e )
    {
        AW_Template_bean bean = ( AW_Template_bean ) e.Item.DataItem;
        Literal litUserdFor = ( Literal ) e.Item.FindControl( "litUserdFor" );
        string names = "";
        if( CurrentSite.fdSiteIndexTemplateID == bean.fdTempID )
        {
            names = "、站点首页";
        }
        else if( CurrentSite.fdSiteColumnTemplateID == bean.fdTempID )
        {
            names = "、站点栏目页";
        }
        else if(CurrentSite.fdSiteContentTemplateID==bean.fdTempID)
        {
            names = "、站点内容页";
        }
        names += columnDao.funcGetColumnNamesByTemplate( bean, ds );
        if( names.Length > 0 )
        {
            litUserdFor.Text = string.Format( "[已被{0}使用]", names.Substring( 1 ) );
        }
    }
}
