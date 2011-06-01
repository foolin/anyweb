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
                foreach( string str in AnyWellSetting.GetSetting().ColumnType )
                {
                    drpType.Items.Add( new ListItem( str.Split( ':' )[ 1 ], str.Split( ':' )[ 0 ] ) );
                }
                //drpType.Items.Add( new ListItem( "文档栏目", "0" ) );
                //drpType.Items.Add( new ListItem( "单篇文档栏目", "3" ) );
                //drpType.Items.Add( new ListItem( "产品栏目", "1" ) );
                //drpType.Items.Add( new ListItem( "图片栏目", "2" ) );
            }
            else
            {
                switch( column.fdColuType )
                {
                    case 0:
                        foreach( string str in AnyWellSetting.GetSetting().ColumnType )
                        {
                            if( str.StartsWith( "0:" ) || str.StartsWith( "3:" ) )
                            {
                                drpType.Items.Add( new ListItem( str.Split( ':' )[ 1 ], str.Split( ':' )[ 0 ] ) );
                            }
                        }
                        //drpType.Items.Add( new ListItem( "文档栏目", "0" ) );
                        //drpType.Items.Add( new ListItem( "单篇文档栏目", "3" ) );
                        break;
                    case 1:
                        foreach( string str in AnyWellSetting.GetSetting().ColumnType )
                        {
                            if( str.StartsWith( "1:" ) )
                            {
                                drpType.Items.Add( new ListItem( str.Split( ':' )[ 1 ], str.Split( ':' )[ 0 ] ) );
                            }
                        }
                        //drpType.Items.Add( new ListItem( "产品栏目", "1" ) );
                        break;
                    case 2:
                        foreach( string str in AnyWellSetting.GetSetting().ColumnType )
                        {
                            if( str.StartsWith( "2:" ) )
                            {
                                drpType.Items.Add( new ListItem( str.Split( ':' )[ 1 ], str.Split( ':' )[ 0 ] ) );
                            }
                        }
                        //drpType.Items.Add( new ListItem( "图片栏目", "2" ) );
                        break;
                    case 3:
                        foreach( string str in AnyWellSetting.GetSetting().ColumnType )
                        {
                            if( str.StartsWith( "0:" ) || str.StartsWith( "3:" ) )
                            {
                                drpType.Items.Add( new ListItem( str.Split( ':' )[ 1 ], str.Split( ':' )[ 0 ] ) );
                            }
                        }
                        //drpType.Items.Add( new ListItem( "文档栏目", "0" ) );
                        //drpType.Items.Add( new ListItem( "单篇文档栏目", "3" ) );
                        break;
                    case 10:
                        foreach( string str in AnyWellSetting.GetSetting().ColumnType )
                        {
                            if( str.StartsWith( "10:" ) )
                            {
                                drpType.Items.Add( new ListItem( str.Split( ':' )[ 1 ], str.Split( ':' )[ 0 ] ) );
                            }
                        }
                        break;
                    default:
                        break;
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
                Fail( "栏目说明长度不能超出255个字！", true );
            }

            bean.fdColuIcon = QF( "iconPath" );
            bean.fdColuPict = QF( "picPath" );

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
