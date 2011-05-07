using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_Content_SingleArticle : PageAdmin
{
    protected AW_SingleArticle_bean bean;
    protected void Page_Load( object sender, EventArgs e )
    {
        int cid = 0;
        int.TryParse( QS( "cid" ), out cid );
        if( cid == 0 )
        {
            Fail( "栏目不存在！" );
        }

        CurrentColumn = new AW_Column_dao().funcGetColumnInfo( cid );

        if( CurrentColumn == null )
        {
            Fail( "栏目不存在！" );
        }

        bean = new AW_SingleArticle_dao().funcGetSingleArticle( cid );

        if( !IsPostBack && bean != null )
        {
            txtTitle.Text = bean.fdSingTitle;
            txtContent.Text = bean.fdSingContent;
            chkEnableComment.Checked = bean.fdSingCanComment == 0 ? true : false;
        }
        lblColumn.Text = CurrentColumn.fdColuName;
    }

    protected void btnSave_Click( object sender, EventArgs e )
    {
        AW_SingleArticle_dao dao = new AW_SingleArticle_dao();
        if( bean == null )
        {
            bean = new AW_SingleArticle_bean();
            bean.fdSingColuID = CurrentColumn.fdColuID;
        }
        bean.fdSingTitle = txtTitle.Text.Trim();
        bean.fdSingContent = txtContent.Text;
        bean.fdSingCanComment = chkEnableComment.Checked ? 0 : 1;

        int result = 0;
        if( bean.fdSingID == 0 )
        {
            bean.fdSingID = dao.funcNewID();
            result = dao.funcInsert( bean );
        }
        else
        {
            result = dao.funcUpdate( bean );
        }

        if( result > 0 )
        {
            AddLog( EventType.Update, "修改单篇文档", string.Format( "栏目[{0}]修改单篇文档:[{1}({2})]", CurrentColumn.fdColuName, bean.fdSingTitle, bean.fdSingID ) );
            Response.Write( "<script type=text/javascript>parent.editSingleOK();</script>" );
            Response.End();
        }
        else
        {
            Fail( "文档修改失败，请稍候再试！", true );
        }
    }
}
