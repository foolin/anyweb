using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using System.IO;
using Studio.Web;

public partial class Admin_Content_ColumnEdit : PageAdmin
{
    protected AW_Column_bean bean;
    protected void Page_Load( object sender, EventArgs e )
    {
        int cid = 0;
        AW_Column_dao dao = new AW_Column_dao();
        int.TryParse( QS( "cid" ), out cid );
        if( cid == 0 )
        {
            ShowError( "栏目不存在！" );
        }

        bean = dao.funcGetColumnInfo( cid );
        if( bean == null )
        {
            ShowError( "栏目不存在！" );
        }

        if( !IsPostBack )
        {
            if( bean.Parent == null )
            {
                lblParent.Text = "无上级栏目";
            }
            else
            {
                lblParent.Text = bean.Parent.fdColuName;
            }

            txtName.Text = bean.fdColuName;
            lblType.Text = bean.ColumnTypeText;
            txtDesc.Text = bean.fdColuDesc;
        }
        else
        {
            bean.fdColuName = txtName.Text.Trim();
            bean.fdColuDesc = txtDesc.Text;

            if( string.IsNullOrEmpty( QF( "iconPath" ).Trim() ) )
            {
                bean.fdColuIcon = "";
            }

            if( string.IsNullOrEmpty( QF( "picPath" ).Trim() ) )
            {
                bean.fdColuPict = "";
            }

            string extensions = ".jpg,.gif,.png";
            string dir = AnyWellSetting.GetSetting().DataRootPath + "/Column";

            bean.fdColuIcon = QF( "iconPath" );
            bean.fdColuPict = QF( "picPath" );

            if( dao.funcUpdate( bean ) > 0 )
            {
                AddLog( EventType.Update, "修改栏目", string.Format( "添加修改:{0}({1})", bean.fdColuName, bean.fdColuID ) );
                Response.Write( string.Format( "<script type=text/javascript>parent.editColumnOK({0},\"{1}\");</script>", bean.fdColuSiteID, bean.ColumnIDPath ) );
                Response.End();
            }
        }
    }
}
