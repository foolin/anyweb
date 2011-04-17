using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.IO;
using Studio.IO;
using System.Text;

public partial class Admin_Content_TemplateEdit : PageAdmin
{
    AW_Template_bean bean;

    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "修改模板";
        int sid = 0, tid = 0;

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

        int.TryParse( QS( "id" ), out tid );
        if( tid == 0 )
        {
            Fail( "模板不存在！" );
        }

        bean = CurrentSite.GetTemplate( tid );
        if( bean == null )
        {
            Fail( "模板不存在！" );
        }

        if( !IsPostBack )
        {
            txtName.Text = bean.fdTempName;
            lblType.Text = bean.TempTypeName;
            txtContent.Text = bean.fdTempContent;
        }
    }

    protected void btnSave_Click( object sender, EventArgs e )
    {
        AW_Template_dao dao = new AW_Template_dao();
        if( dao.funcCheckNameExist( bean.fdTempID, txtName.Text.Trim() ) )
        {
            Fail( "模板名称已存在，请重新输入！", true );
        }

        string oldName = "";
        if( bean.fdTempName != txtName.Text.Trim() )
        {
            oldName = bean.fdTempName;
        }
        bean.fdTempName = txtName.Text.Trim();
        bean.fdTempContent = txtContent.Text;
        if( dao.funcUpdate( bean ) > 0 )
        {
            AddLog( EventType.Insert, "修改模板", string.Format( "站点[{0}]修改模板:[{1}]", CurrentSite.fdSiteName, bean.fdTempName ) );

            string templatePath = Server.MapPath( string.Format( "/Files/Template/{0}/", CurrentSite.fdSiteID ) );
            if( !Directory.Exists( templatePath ) )
            {
                Directory.CreateDirectory( templatePath );
            }

            FileAgent.WriteText( templatePath + "\\" + bean.fdTempName + ".ascx", bean.fdTempContent, false, Encoding.UTF8 );

            if( oldName.Length > 0 )
            {
                string oldTemplate = templatePath + "\\" + oldName + ".ascx";
                if( File.Exists( oldTemplate ) )
                {
                    File.Delete( oldTemplate );
                }
            }

            Response.Write( "<script type=text/javascript>parent.editTemplateOK();</script>" );
            Response.End();
        }
        else
        {
            Fail( "模板修改失败，请稍候再试！", true );
        }
    }
}
