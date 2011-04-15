using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Studio.Web;
using AnyWell.AW_DL;

public partial class Admin_Content_ArticleAdd : ArticlePageAdmin
{
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "新建文档";
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
        lblColumn.Text = CurrentColumn.fdColuName;
        txtCreateAt.Text = DateTime.Now.ToString( "yyyy-MM-dd HH:mm" );
    }

    protected void btnSaveAndContinue_Click( object sender, EventArgs e )
    {
        AddArticle();
        Response.Write( string.Format( "<script type=\"text/javascript\">parent.addArticleOK({0},\"{1}\",true);</script>", CurrentColumn.fdColuSiteID, CurrentColumn.ColumnIDPath ) );
        Response.End();
    }

    protected void btnSave_Click( object sender, EventArgs e )
    {
        AddArticle();
        Response.Write( string.Format( "<script type=text/javascript>parent.addArticleOK({0},\"{1}\");</script>", CurrentColumn.fdColuSiteID, CurrentColumn.ColumnIDPath ) );
        Response.End();
    }

    private void AddArticle()
    {
        DateTime createAt;
        int sort = 0;
        if( !DateTime.TryParse( txtCreateAt.Text, out createAt ) )
        {
            Fail( "撰写时间格式不正确！", true );
        }

        if( drpType.SelectedValue == "3" && fileUploader.PostedFile.ContentLength == 0 )
        {
            Fail( "请选择要上传的文件！", true );
        }

        if( fileUploader.PostedFile.ContentLength > 2097151 )
        {
            Fail( "文件大小不能超出2M！", true );
        }

        if( fileImage.PostedFile.ContentLength > 2097151 )
        {
            Fail( "文档图片大小不能超出2M！", true );
        }

        if( !int.TryParse( txtSort.Text.Trim(), out sort ) || sort < 0 )
        {
            Fail( "文档排序格式错误，请输入非负整数！", true );
        }

        AW_Article_dao dao = new AW_Article_dao();
        AW_Article_bean bean = new AW_Article_bean();
        bean.fdArtiID = dao.funcNewID();
        bean.fdArtiTitle = txtTitle.Text.Trim();
        bean.fdArtiColuID = CurrentColumn.fdColuID;
        bean.fdArtiType = int.Parse( drpType.SelectedValue );
        switch( int.Parse( drpType.SelectedValue ) )
        {
            case 0:
                bean.fdArtiContent = txtContent.Text;
                bean.fdArtiDescription = txtDesc.Text;
                GetDesc( bean, chkDesc.Checked );
                break;
            case 1:
                bean.fdArtiContent = txtTextContent.Text;
                bean.fdArtiDescription = txtDesc.Text;
                GetDesc( bean, chkDesc.Checked );
                break;
            case 2:
                bean.fdArtiLink = txtLink.Text.Trim();
                break;
            case 3:
                bean.fdArtiLink = SaveFile( fileUploader );
                break;
            default:
                Fail( "请选择文章类型！", true );
                break;
        }
        bean.fdArtiIsAuthorship = radioIsAuthor.SelectedIndex;
        bean.fdArtiSubTitle = txtSubTitle.Text.Trim();
        bean.fdArtiFrom = txtFrom.Text.Trim();
        bean.fdArtiFromAuthor = txtFromAuthor.Text.Trim();
        bean.fdArtiFromLink = txtFromLink.Text.Trim();
        bean.fdArtiCreateAt = createAt;
        bean.fdArtiCanComment = chkEnableComment.Checked ? 0 : 1;

        if( sort == 0 )
        {
            bean.fdArtiSort = bean.fdArtiID * 10;
        }
        else
        {
            bean.fdArtiSort = sort;
        }

        if( fileImage.PostedFile.ContentLength > 0 )
        {
            bean.fdArtiImage = SaveImage( fileImage, 120, 120 );
        }
        if( dao.funcInsert( bean ) > 0 )
        {
            AddLog( EventType.Insert, "添加文档", string.Format( "栏目[{0}]添加文档:[{1}({2})]", CurrentColumn.fdColuName, bean.fdArtiTitle, bean.fdArtiID ) );
        }
        else
        {
            Fail( "文档添加失败，请稍候再试！", true );
        }
    }
}
