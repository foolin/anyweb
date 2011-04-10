using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.IO;
using Studio.Web;

public partial class Admin_Content_ColumnAdd : PageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        int sid = 0, cid = 0;
        int.TryParse( QS( "sid" ), out sid );
        int.TryParse( QS( "cid" ), out cid );
        AW_Site_bean site = new AW_Site_bean();
        AW_Column_bean column = new AW_Column_bean();
        AW_Site_dao siteDao = new AW_Site_dao();
        AW_Column_dao columnDao = new AW_Column_dao();

        if( sid == 0 && cid == 0 )
        {
            ShowError( "请选择站点或栏目！" );
        }

        if( sid > 0 )
        {
            site = siteDao.funcGetSiteInfo( sid );
            if( site == null )
            {
                ShowError( "站点不存在！" );
            }
        }
        else
        {
            column = columnDao.funcGetColumnInfo( cid );
            if( column == null )
            {
                ShowError( "栏目不存在！" );
            }
        }

        if( !IsPostBack )
        {
            if( sid > 0 )
            {
                lblParent.Text = "无上级栏目";
            }
            else
            {
                if( column.fdColuType != ( int ) ColumnType.Product )
                {
                    drpType.Items.Remove( drpType.Items.FindByValue( "2" ) );
                }
                else
                {
                    drpType.Items.Clear();
                    drpType.Items.Add( new ListItem( "产品栏目", "2" ) );
                }
                lblParent.Text = column.fdColuName;
            }
        }
        else
        {
            AW_Column_bean bean = new AW_Column_bean();
            bean.fdColuID = columnDao.funcNewID();
            bean.fdColuName = txtName.Text.Trim();
            bean.fdColuType = int.Parse( drpType.SelectedValue );
            bean.fdColuDesc = txtDesc.Text;
            bean.fdColuSort = bean.fdColuID;
            bean.Children = new List<AW_Column_bean>();
            if( bean.fdColuDesc.Length > 255 )
            {
                Fail( "栏目说明长度不能超出255个字！" );
            }

            string extensions = ".jpg,.gif,.png";
            string dir = AnyWellSetting.GetSetting().DataRootPath + "/Column";

            if( fileIcon.PostedFile.ContentLength > 0 )
            {
                if( !fileIcon.PostedFile.ContentType.ToLower().Contains( "image" ) )
                {
                    Fail( "小图格式错误，请上传jpg,gif,png格式的图片" );
                }
                string extension = Path.GetExtension( this.fileIcon.PostedFile.FileName ).ToLower();
                if( extensions.IndexOf( extension ) == -1 )
                {
                    Fail( "小图格式错误，请上传jpg,gif,png格式的图片" );
                }
                if( this.fileIcon.PostedFile.ContentLength > 2097151 )
                {
                    Fail( "小图文件大小不能超出2M！" );
                }

                if( !Directory.Exists( this.Server.MapPath( dir ) ) )
                {
                    Directory.CreateDirectory( this.Server.MapPath( dir ) );
                }
                string fileName = dir + DL_helper.funcGetTicks().ToString() + extension;
                WebAgent.SaveFile( fileIcon.PostedFile, Server.MapPath( fileName ), 32, 32 );
                bean.fdColuIcon = fileName;
            }

            if( filePicture.PostedFile.ContentLength > 0 )
            {
                if( !filePicture.PostedFile.ContentType.ToLower().Contains( "image" ) )
                {
                    Fail( "大图格式错误，请上传jpg,gif,png格式的图片" );
                }
                string extension = Path.GetExtension( this.filePicture.PostedFile.FileName ).ToLower();
                if( extensions.IndexOf( extension ) == -1 )
                {
                    Fail( "大图格式错误，请上传jpg,gif,png格式的图片" );
                }
                if( this.filePicture.PostedFile.ContentLength > 2097151 )
                {
                    Fail( "大图文件大小不能超出2M！" );
                }

                if( !Directory.Exists( this.Server.MapPath( dir ) ) )
                {
                    Directory.CreateDirectory( this.Server.MapPath( dir ) );
                }
                string fileName = dir + DL_helper.funcGetTicks().ToString() + extension;
                WebAgent.SaveFile( filePicture.PostedFile, Server.MapPath( fileName ), 120, 120 );
                bean.fdColuPict = fileName;
            }

            int result = 0;
            if( sid > 0 )
            {
                bean.fdColuSiteID = site.fdSiteID;
                bean.fdColuParentID = 0;
                result = columnDao.funcAddColumn( site, bean );
            }
            else
            {
                bean.fdColuSiteID = column.fdColuSiteID;
                bean.fdColuParentID = column.fdColuID;
                result = columnDao.funcAddColumn( column, bean );
            }

            if( result > 0 )
            {
                AddLog( EventType.Insert, "添加栏目", string.Format( "添加栏目:{0}({1})", bean.fdColuName, bean.fdColuID ) );
                Response.Write( string.Format( "<script type=text/javascript>parent.addColumnOK({0},\"{1}\");</script>", bean.fdColuSiteID, bean.ColumnIDPath ) );
                Response.End();
            }
        }
    }
}
