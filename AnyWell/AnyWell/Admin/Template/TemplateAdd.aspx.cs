using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.IO;
using Studio.IO;
using System.Text;
using Studio.Web;

public partial class Admin_Content_TemplateAdd : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "新建模板";
        int sid = 0;
        int.TryParse( QS( "sid" ), out sid );
        if( sid == 0 )
        {
            Fail( "站点不存在！" );
        }
        CurrentSite = new AW_Site_dao().funcGetSiteInfo( sid );
        if( CurrentSite == null )
        {
            Fail( "站点不存在！" );
        }

        string type = QS( "type" ).Trim();

        if( QS( "site" ) == "true" )
        {
            if( string.IsNullOrEmpty( type ) || !WebAgent.IsInt32( type ) || ( type != "1" && type != "2" && type != "4" ) )
            {
                Fail( "模板类型错误！" );
            }
            else
            {
                drpType.SelectedValue = type;
                drpType.Enabled = false;
            }
        }

        if( QS( "column" ) == "true" )
        {
            if( string.IsNullOrEmpty( type ) || !WebAgent.IsInt32( type ) || ( type != "1" && type != "2" ) )
            {
                Fail( "模板类型错误！" );
            }
            if( string.IsNullOrEmpty( QS( "cid" ) ) || !WebAgent.IsInt32( QS( "cid" ) ) )
            {
                Fail( "栏目不存在！" );
            }
            CurrentColumn = new AW_Column_dao().funcGetColumnInfo( int.Parse( QS( "cid" ) ) );
            if( CurrentColumn == null )
            {
                Fail( "栏目不存在！" );
            }
            else
            {
                drpType.SelectedValue = type;
                drpType.Enabled = false;
            }
        }
    }

    protected void btnSave_Click( object sender, EventArgs e )
    {
        AW_Template_dao dao = new AW_Template_dao();
        if( dao.funcCheckNameExist( 0, txtName.Text.Trim() ) )
        {
            Fail( "模板名称已存在，请重新输入！", true );
        }
        AW_Template_bean bean = new AW_Template_bean();
        bean.fdTempID = dao.funcNewID();
        bean.fdTempSiteID = CurrentSite.fdSiteID;
        bean.fdTempName = txtName.Text.Trim();
        if( !string.IsNullOrEmpty( QS( "type" ) ) )
        {
            bean.fdTempType = int.Parse( QS( "type" ) );
        }
        else
        {
            bean.fdTempType = int.Parse( drpType.SelectedValue );
        }
        bean.fdTempCreateAt = DateTime.Now;
        bean.fdTempContent = txtContent.Text;
        CurrentSite.TemplateList.Insert( 0, bean );
        if( dao.funcInsert( bean ) > 0 )
        {
            if( QS( "site" ) == "true" )
            {
                if( QS( "type" ) == "1" )
                {
                    CurrentSite.fdSiteColumnTemplateID = bean.fdTempID;
                    CurrentSite.ColumnTemplate = bean;
                }
                else if( QS( "type" ) == "2" )
                {
                    CurrentSite.fdSiteContentTemplateID = bean.fdTempID;
                    CurrentSite.ContentTemplate = bean;
                }
                else if( QS( "type" ) == "4" )
                {
                    CurrentSite.fdSiteIndexTemplateID = bean.fdTempID;
                    CurrentSite.IndexTemplate = bean;
                }
                new AW_Site_dao().funcUpdate( CurrentSite );
            }
            if( QS( "column" ) == "true" )
            {
                if( QS( "type" ) == "1" )
                {
                    CurrentColumn.fdColuIndexTemplateID = bean.fdTempID;
                    CurrentColumn.IndexTemplate = bean;
                }
                else if( QS( "type" ) == "2" )
                {
                    CurrentColumn.fdColuContentTemplateID = bean.fdTempID;
                    CurrentColumn.ContentTemplate = bean;
                }
                new AW_Column_dao().funcUpdate( CurrentColumn );
            }
            AddLog( EventType.Insert, "添加模板", string.Format( "站点[{0}]添加模板:[{1}]", CurrentSite.fdSiteName, bean.fdTempName ) );
            string templatePath = Server.MapPath( string.Format( "/Files/Template/{0}/", CurrentSite.fdSiteID ) );
            if( !Directory.Exists( templatePath ) )
            {
                Directory.CreateDirectory( templatePath );
            }
            FileAgent.WriteText( templatePath + "\\" + bean.fdTempName + ".ascx", bean.fdTempContent, false, Encoding.UTF8 );
            Response.Write( string.Format( "<script type=text/javascript>parent.addTemplateOK({0});</script>", CurrentSite.fdSiteID ) );
            Response.End();
        }
        else
        {
            Fail( "模板新建失败，请稍候再试！", true );
        }
    }
}
