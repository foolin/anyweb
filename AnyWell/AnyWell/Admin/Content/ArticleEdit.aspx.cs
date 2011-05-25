using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnyWell.AW_DL;
using Studio.Web;

public partial class Admin_Content_ArticleEdit : ArticlePageAdmin
{
    protected AW_Article_bean bean;
    protected string IsAuthorShip = "";
    protected void Page_Load( object sender, EventArgs e )
    {
        this.Title = "修改文档";
        int id = 0;
        int.TryParse( QS( "id" ), out id );
        if( id == 0 )
        {
            Fail( "文档不存在！" );
        }

        bean = AW_Article_bean.funcGetByID(id);

        if( bean == null )
        {
            Fail( "文档不存在！" );
        }

        //引用文档
        if( bean.fdArtiType == 4 )
        {
            Response.Redirect( "ArticleEdit.aspx?id=" + bean.fdArtiSourceID );
        }

        CurrentColumn = new AW_Column_dao().funcGetColumnInfo( bean.fdArtiColuID );

        if( !IsPostBack )
        {
            txtTitle.Text = bean.fdArtiTitle;
            drpType.SelectedValue = bean.fdArtiType.ToString();
            lblColumn.Text = CurrentColumn.fdColuName;
            switch( bean.fdArtiType )
            {
                case 0:
                    txtContent.Text = bean.fdArtiContent;
                    break;
                case 1:
                    txtTextContent.Text = bean.fdArtiContent;
                    break;
                case 2:
                    txtLink.Text = bean.fdArtiLink;
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            txtDesc.Text = bean.fdArtiDescription;
            radioIsAuthor.SelectedIndex = bean.fdArtiIsAuthorship;
            txtSubTitle.Text = bean.fdArtiSubTitle;
            txtFrom.Text = bean.fdArtiFrom;
            txtFromAuthor.Text = bean.fdArtiFromAuthor;
            txtFromLink.Text = bean.fdArtiFromLink;
            txtCreateAt.Text = bean.fdArtiCreateAt.ToString( "yyyy-MM-dd HH:mm" );
            txtSort.Text = bean.fdArtiSort.ToString();
            chkEnableComment.Checked = bean.fdArtiCanComment == 0 ? true : false;
            IsAuthorShip = bean.fdArtiIsAuthorship == 0 ? "true" : "false";
        }
    }

    protected void btnSave_Click( object sender, EventArgs e )
    {
        DateTime createAt;
        int sort = 0;
        string articleFile = QF( "txtFile" ).Trim();
        string articlePic = QF( "txtPic" ).Trim();
        if( !DateTime.TryParse( txtCreateAt.Text, out createAt ) )
        {
            Fail( "撰写时间格式不正确！", true );
        }

        if( drpType.SelectedValue == "3" && string.IsNullOrEmpty( articleFile ) )
        {
            Fail( "请选择要上传的文件！", true );
        }

        if( !int.TryParse( txtSort.Text.Trim(), out sort ) || sort < 0 )
        {
            Fail( "文档排序格式错误，请输入非负整数！", true );
        }

        AW_Article_dao dao = new AW_Article_dao();
        bean.fdArtiTitle = txtTitle.Text.Trim();
        bean.fdArtiColuID = CurrentColumn.fdColuID;
        bean.fdArtiType = int.Parse( drpType.SelectedValue );
        switch( int.Parse( drpType.SelectedValue ) )
        {
            case 0:
                bean.fdArtiContent = txtContent.Text;
                bean.fdArtiDescription = txtDesc.Text;
                bean.fdArtiLink = "";
                GetDesc( bean, chkDesc.Checked );
                break;
            case 1:
                bean.fdArtiContent = txtTextContent.Text;
                bean.fdArtiDescription = txtDesc.Text;
                GetDesc( bean, chkDesc.Checked );
                bean.fdArtiLink = "";
                break;
            case 2:
                bean.fdArtiLink = txtLink.Text.Trim();
                bean.fdArtiContent = "";
                bean.fdArtiDescription = "";
                break;
            case 3:
                bean.fdArtiLink = articleFile; 
                bean.fdArtiContent = "";
                bean.fdArtiDescription = "";
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

        bean.fdArtiImage = articlePic;

        if( bean.fdArtiStatus == 2 )
            bean.fdArtiStatus = 1;

        if( dao.funcUpdate( bean ) > 0 )
        {
            AddLog( EventType.Update, "修改文档", string.Format( "栏目[{0}]修改文档:[{1}({2})]", CurrentColumn.fdColuName, bean.fdArtiTitle, bean.fdArtiID ) );
            Response.Write( "<script type=text/javascript>parent.editArticleOK();</script>" );
            Response.End();
        }
        else
        {
            Fail( "文档修改失败，请稍候再试！", true );
        }
    }
}
