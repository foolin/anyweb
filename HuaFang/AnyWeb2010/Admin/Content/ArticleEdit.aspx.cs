using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using AnyWell.AW_DL;
using Studio.Web;
using System.IO;
using System.Collections.Generic;

public partial class Admin_ArticleEdit : ArticleBase
{
    protected AW_Article_bean article;

    protected override void OnPreRender(EventArgs e)
    {
        string id = QS("id");

        if (!WebAgent.IsInt32(id)) WebAgent.AlertAndBack("编号不正确!");

        article = new AW_Article_dao().funcGetArticleById( int.Parse( QS( "id" ) ), true );
        article.Column = AW_Column_bean.funcGetByID(article.fdArtiColumnID);
        if (article == null) WebAgent.AlertAndBack("文章不存在!");

        if (!this.IsPostBack && Request.UrlReferrer != null)
        {
            ViewState["REFURL"] = Request.UrlReferrer.PathAndQuery;
        }
        else
        {
            ViewState["REFURL"] = "ArticleList.aspx";
        }

        txtTitle.Text = article.fdArtiTitle;
        drpType.SelectedValue = article.fdArtiType.ToString();
        if( article.fdArtiType == 0 )
        {
            txtContent.Text = article.fdArtiContent;
        }
        else if( article.fdArtiType == 1 )
        {
            repImgList.DataSource = article.PictureList;
            repImgList.DataBind();
            chkDesc.Checked = article.fdArtiPicDesc == 1 ? true : false;
        }
        else
        {
            txtContent2.Text = article.fdArtiContent;
            repCatWalk.DataSource = article.CatWalkList;
            repCatWalk.DataBind();
            repBackStage.DataSource = article.BackStageList;
            repBackStage.DataBind();
            repCloseUp.DataSource = article.CloseUpList;
            repCloseUp.DataBind();
            repFrontRow.DataSource = article.FrontRowList;
            repFrontRow.DataBind();
            drpCategory.SelectedValue = article.fdArtiCategory.ToString();
            drpCity.SelectedValue = article.fdArtiCity.ToString();
            chkRecommend.Checked = article.fdArtiRecommend == 1 ? true : false;
            txtFlashDesc.Text = article.fdArtiFlashDesc;
        }
        txtDesc.Text = article.fdArtiDesc;
        txtSort.Text = article.fdArtiSort.ToString();
        txtCreateAt.Text = article.fdArtiCreateAt.ToString("yyyy-MM-dd");
        txtFrom.Text = article.fdArtiFrom;
        txtAuthor.Text = article.fdArtiAuthor;
        int i = 0;
        foreach (AW_Column_bean bean1 in (new AW_Column_dao()).funcGetColumns())
        {
            drpColumn.Items.Add(new ListItem(bean1.fdColuName, bean1.fdColuID.ToString()));
            litJs.Text += string.Format("child[{0}] = new Array;", i);
            int j = 0;
            if (bean1.fdColuID == article.Column.fdColuParentID || bean1.fdColuID == article.Column.fdColuID)
            {
                drpChild.Items.Add(new ListItem("不选择二级栏目", "0"));
                foreach (AW_Column_bean bean2 in bean1.Children)
                {
                    drpChild.Items.Add(new ListItem(bean2.fdColuName, bean2.fdColuID.ToString()));
                    litJs.Text += string.Format("child[{0}][{1}] = \"{2}:{3}\";", i, j, bean2.fdColuID, bean2.fdColuName);
                    j++;
                }
            }
            else
            {
                foreach (AW_Column_bean bean2 in bean1.Children)
                {
                    litJs.Text += string.Format("child[{0}][{1}] = \"{2}:{3}\";", i, j, bean2.fdColuID, bean2.fdColuName);
                    j++;
                }
            }
            i++;
        }
        if (article.Column.fdColuParentID == 0)
        {
            drpColumn.SelectedValue = article.Column.fdColuID.ToString();
            drpChild.SelectedValue = "0";
        }
        else
        {
            drpColumn.SelectedValue = article.Column.fdColuParentID.ToString();
            drpChild.SelectedValue = article.Column.fdColuID.ToString();
        }
    }

    protected void btnOk_Click( object sender, EventArgs e )
    {
        if( String.IsNullOrEmpty( txtTitle.Text ) )
            WebAgent.AlertAndBack( "标题不能为空" );

        if( drpType.SelectedValue == "0" && String.IsNullOrEmpty( txtContent.Text ) )
        {
            WebAgent.AlertAndBack( "内容不能为空" );
        }

        if( drpType.SelectedValue == "2" && string.IsNullOrEmpty( txtContent2.Text ) )
        {
            WebAgent.AlertAndBack( "内容不能为空" );
        }

        if( txtDesc.Text.Trim().Length > 1000 )
            WebAgent.AlertAndBack( "文章摘要不能超出1000字" );

        if( string.IsNullOrEmpty( txtSort.Text ) )
            WebAgent.AlertAndBack( "排序不能为空" );

        if( !WebAgent.IsInt32( txtSort.Text.Trim() ) )
            WebAgent.AlertAndBack( "排序格式不正确" );

        DateTime date = DateTime.Now;
        if( !string.IsNullOrEmpty( txtCreateAt.Text.Trim() ) && !DateTime.TryParse( txtCreateAt.Text.Trim(), out date ) )
        {
            WebAgent.AlertAndBack( "发布时间格式不正确" );
        }

        article = new AW_Article_dao().funcGetArticleById( int.Parse( QS( "id" ) ), false );
        string childColumn = Request.Form[ drpChild.UniqueID ] + "";
        article.fdArtiCreateAt = date;
        article.fdArtiTitle = txtTitle.Text.Trim();
        article.fdArtiType = int.Parse( drpType.SelectedValue );
        article.fdArtiPic = QF( "imgPath" ).Trim();
        article.fdArtiFrom = txtFrom.Text.Trim();
        article.fdArtiAuthor = txtAuthor.Text.Trim();
        if( article.fdArtiType == 0 )
        {
            article.fdArtiContent = txtContent.Text;
        }
        else if( article.fdArtiType == 2 )
        {
            article.fdArtiContent = txtContent2.Text;
        }
        if( txtDesc.Text.Trim().Length > 0 )
        {
            article.fdArtiDesc = txtDesc.Text.Trim();
        }
        else
        {
            string strDesc = WebAgent.GetText( article.fdArtiContent );
            if( strDesc.Length < 1000 )
            {
                article.fdArtiDesc = strDesc;
            }
            else
            {
                article.fdArtiDesc = strDesc.Substring( 0, 1000 );
            }
        }
        article.fdArtiSort = int.Parse( txtSort.Text.Trim() );
        if( article.fdArtiSort == 0 )
            article.fdArtiSort = article.fdArtiID * 100;
        if( childColumn != "0" )
        {
            article.fdArtiColumnID = int.Parse( childColumn );
        }
        else
        {
            article.fdArtiColumnID = int.Parse( drpColumn.SelectedValue );
        }

        //设置图片
        if( article.fdArtiType == 1 )
        {
            article.fdArtiPicDesc = chkDesc.Checked ? 1 : 0;
            article.PictureList = new List<AW_Article_Picture_bean>();
            string pics = QF( "pics" );
            if( pics.Length > 0 )
            {
                InitPic( article, pics, 0 );
            }
        }
        else if( article.fdArtiType == 2 )
        {
            article.fdArtiCategory = int.Parse( drpCategory.SelectedValue );
            article.fdArtiCity = int.Parse( drpCity.SelectedValue );
            article.fdArtiRecommend = chkRecommend.Checked ? 1 : 0;
            article.fdArtiFlashPath = QF( "txtflash" ).Trim();
            article.fdArtiFlashDesc = txtFlashDesc.Text;
            article.CatWalkList = new List<AW_Article_Picture_bean>();
            article.BackStageList = new List<AW_Article_Picture_bean>();
            article.CloseUpList = new List<AW_Article_Picture_bean>();
            article.FrontRowList = new List<AW_Article_Picture_bean>();
            string pics = QF( "CatWalkPics" );
            if( pics.Length > 0 )
            {
                InitPic( article, pics, 1 );
            }
            pics = QF( "BackStagePics" );
            if( pics.Length > 0 )
            {
                InitPic( article, pics, 2 );
            }
            pics = QF( "CloseUpPics" );
            if( pics.Length > 0 )
            {
                InitPic( article, pics, 3 );
            }
            pics = QF( "FrontRowPics" );
            if( pics.Length > 0 )
            {
                InitPic( article, pics, 4 );
            }
        }

        new AW_Article_dao().funcUpdate( article );

        using( AW_Article_Picture_dao dao = new AW_Article_Picture_dao() )
        {
            string temp = "";
            if( article.fdArtiType == 1 )
            {
                if( article.PictureList.Count > 0 )
                {
                    foreach( AW_Article_Picture_bean pic in article.PictureList )
                    {
                        if( pic.fdArPiID == 0 )
                        {
                            pic.fdArPiID = dao.funcNewID();
                            dao.funcInsert( pic );
                        }
                        else
                        {
                            dao.funcUpdate( pic );
                        }
                        temp += "," + pic.fdArPiID.ToString();
                    }
                }
            }
            else if( article.fdArtiType == 2 )
            {
                if( article.CatWalkList.Count > 0 )
                {
                    foreach( AW_Article_Picture_bean pic in article.CatWalkList )
                    {
                        if( pic.fdArPiID == 0 )
                        {
                            pic.fdArPiID = dao.funcNewID();
                            dao.funcInsert( pic );
                        }
                        else
                        {
                            dao.funcUpdate( pic );
                        }
                        temp += "," + pic.fdArPiID.ToString();
                    }
                }
                if( article.BackStageList.Count > 0 )
                {
                    foreach( AW_Article_Picture_bean pic in article.BackStageList )
                    {
                        if( pic.fdArPiID == 0 )
                        {
                            pic.fdArPiID = dao.funcNewID();
                            dao.funcInsert( pic );
                        }
                        else
                        {
                            dao.funcUpdate( pic );
                        }
                        temp += "," + pic.fdArPiID.ToString();
                    }
                }
                if( article.CloseUpList.Count > 0 )
                {
                    foreach( AW_Article_Picture_bean pic in article.CloseUpList )
                    {
                        if( pic.fdArPiID == 0 )
                        {
                            pic.fdArPiID = dao.funcNewID();
                            dao.funcInsert( pic );
                        }
                        else
                        {
                            dao.funcUpdate( pic );
                        }
                        temp += "," + pic.fdArPiID.ToString();
                    }
                }
                if( article.FrontRowList.Count > 0 )
                {
                    foreach( AW_Article_Picture_bean pic in article.FrontRowList )
                    {
                        if( pic.fdArPiID == 0 )
                        {
                            pic.fdArPiID = dao.funcNewID();
                            dao.funcInsert( pic );
                        }
                        else
                        {
                            dao.funcUpdate( pic );
                        }
                        temp += "," + pic.fdArPiID.ToString();
                    }
                }
            }
            if( temp.Length > 0 )
            {
                temp = temp.Substring( 1 );
            }
            else
            {
                temp = "0";
            }
            dao.funcDeletePictureNoExists( article.fdArtiID, temp );
        }
        
        this.SetTags( article, QF( "tags" ).Trim() );
        this.AddLog( EventType.Update, "修改文章", "修改文章[" + article.fdArtiTitle + "]" );
        Success( "修改文章成功", ViewState[ "REFURL" ].ToString() );
    }

    protected string GetTags(string resule)
    {
        string str = "";
        foreach( AW_Tag_bean bean in article.TagList )
        {
            str += "," + bean.fdTagName;
        }
        if( str.Length > 0 )
        {
            return str.Substring( 1 );
        }
        else
        {
            return resule;
        }
    }

    /// <summary>
    /// 初始化文章图片
    /// </summary>
    /// <param name="article"></param>
    /// <param name="pics"></param>
    /// <param name="picType"></param>
    protected void InitPic( AW_Article_bean article, string pics, int picType )
    {
        List<AW_Article_Picture_bean> list;
        switch( picType )
        {
            case 0:
                list = article.PictureList;
                break;
            case 1:
                list = article.CatWalkList;
                break;
            case 2:
                list = article.BackStageList;
                break;
            case 3:
                list = article.CloseUpList;
                break;
            case 4:
                list = article.FrontRowList;
                break;
            default:
                return;
        }
        string[] pic = pics.Split( ',' );
        if( picType != 0 )
        {
            for( int i = 0; i < pic.Length; i++ )
            {
                if( pic[ i ].Trim().Length > 0 )
                {
                    AW_Article_Picture_bean picture = new AW_Article_Picture_bean();
                    if( pic[ i ].Contains( ":" ) )
                    {
                        picture.fdArPiID = int.Parse( pic[ i ].Substring( 0, pic[ i ].IndexOf( ":" ) ) );
                        picture.fdArPiArtiID = article.fdArtiID;
                        picture.fdArPiPath = pic[ i ].Substring( pic[ i ].IndexOf( ":" ) + 1 );
                    }
                    else
                    {
                        picture.fdArPiArtiID = article.fdArtiID;
                        picture.fdArPiPath = pic[ i ];
                    }
                    picture.fdArPiType = picType;
                    picture.fdArPiSort = i;
                    list.Add( picture );
                }
            }
        }
        else
        {
            string[] picDesc = Request.Form.GetValues( "txtPicDesc" );
            for( int i = 0; i < pic.Length; i++ )
            {
                if( pic[ i ].Trim().Length > 0 )
                {
                    AW_Article_Picture_bean picture = new AW_Article_Picture_bean();
                    if( pic[ i ].Contains( ":" ) )
                    {
                        picture.fdArPiID = int.Parse( pic[ i ].Substring( 0, pic[ i ].IndexOf( ":" ) ) );
                        picture.fdArPiArtiID = article.fdArtiID;
                        picture.fdArPiPath = pic[ i ].Substring( pic[ i ].IndexOf( ":" ) + 1 );
                    }
                    else
                    {
                        picture.fdArPiArtiID = article.fdArtiID;
                        picture.fdArPiPath = pic[ i ];
                    }
                    picture.fdArPiType = picType;
                    picture.fdArPiDesc = picDesc[ i ];
                    picture.fdArPiSort = i;
                    if( picture.fdArPiDesc.Length > 400 )
                    {
                        picture.fdArPiDesc = picture.fdArPiDesc.Substring( 0, 400 );
                    }
                    list.Add( picture );
                }
            }
        }
    }
}
