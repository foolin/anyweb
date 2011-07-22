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
using Studio.Web;
using AnyWell.AW_DL;
using System.Collections.Generic;

public partial class Admin_ArticleAdd : ArticleBase
{
    protected AW_Article_bean bean;
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        int i = 0;
        List<AW_Column_bean> coluList = new AW_Column_dao().funcGetColumns();
        if (coluList.Count == 0)
        {
            WebAgent.FailAndGo("文章栏目为空，请先添加文章栏目！", "ColumnAdd.aspx");
        }
        foreach (AW_Column_bean bean1 in coluList)
        {
            drpColumn.Items.Add(new ListItem(bean1.fdColuName, bean1.fdColuID.ToString()));
            litJs.Text += string.Format("child[{0}] = new Array;", i);
            int j = 0;
            foreach (AW_Column_bean bean2 in bean1.Children)
            {
                litJs.Text += string.Format("child[{0}][{1}] = \"{2}:{3}\";", i, j, bean2.fdColuID, bean2.fdColuName);
                j++;
            }
            i++;
        }

        ListItem li = drpColumn.Items.FindByValue(QS("cid"));
        if (li != null) li.Selected = true;

        if (!this.IsPostBack && Request.UrlReferrer != null)
        {
            ViewState["REFURL"] = Request.UrlReferrer.PathAndQuery;
        }
        else
        {
            ViewState["REFURL"] = "ArticleList.aspx";
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

        string childColumn = Request.Form[ "drpChild" ] + "";

        bean = new AW_Article_bean();
        bean.fdArtiCreateAt = date;
        if( childColumn != "0" )
        {
            bean.fdArtiColumnID = int.Parse( childColumn );
        }
        else
        {
            bean.fdArtiColumnID = int.Parse( drpColumn.SelectedValue );
        }
        bean.fdArtiType = int.Parse( drpType.SelectedValue );
        bean.fdArtiTitle = txtTitle.Text.Trim();
        if( bean.fdArtiType == 0 )
        {
            bean.fdArtiContent = txtContent.Text;
        }
        else if( bean.fdArtiType == 2 )
        {
            bean.fdArtiContent = txtContent2.Text;
        }
        if( txtDesc.Text.Trim().Length > 0 )
        {
            bean.fdArtiDesc = txtDesc.Text.Trim();
        }
        else
        {
            string strDesc = WebAgent.GetText( bean.fdArtiContent );
            if( strDesc.Length < 1000 )
            {
                bean.fdArtiDesc = strDesc;
            }
            else
            {
                bean.fdArtiDesc = strDesc.Substring( 0, 1000 );
            }
        }
        bean.fdArtiSort = int.Parse( txtSort.Text.Trim() );
        bean.fdArtiPic = QF( "imgPath" ).Trim();
        bean.fdArtiFrom = txtFrom.Text.Trim();
        bean.fdArtiAuthor = txtAuthor.Text.Trim();

        if( bean.fdArtiType == 1 )
        {
            bean.fdArtiPicDesc = chkDesc.Checked ? 1 : 0;
            bean.PictureList = new List<AW_Article_Picture_bean>();
            string pics = QF( "pics" );
            if( pics.Length > 0 )
            {
                InitPic( bean, pics, 0 );
            }
        }
        else if( bean.fdArtiType == 2 )
        {
            bean.fdArtiCategory = int.Parse( drpCategory.SelectedValue );
            bean.fdArtiCity = int.Parse( drpCity.SelectedValue );
            bean.fdArtiRecommend = chkRecommend.Checked ? 1 : 0;
            bean.fdArtiFlashPath = QF( "txtflash" ).Trim();
            bean.fdArtiFlashDesc = txtFlashDesc.Text;
            bean.CatWalkList = new List<AW_Article_Picture_bean>();
            bean.BackStageList = new List<AW_Article_Picture_bean>();
            bean.CloseUpList = new List<AW_Article_Picture_bean>();
            bean.FrontRowList = new List<AW_Article_Picture_bean>();
            string pics = QF( "CatWalkPics" );
            if( pics.Length > 0 )
            {
                InitPic( bean, pics, 1 );
            }
            pics = QF( "BackStagePics" );
            if( pics.Length > 0 )
            {
                InitPic( bean, pics, 2 );
            }
            pics = QF( "CloseUpPics" );
            if( pics.Length > 0 )
            {
                InitPic( bean, pics, 3 );
            }
            pics = QF( "FrontRowPics" );
            if( pics.Length > 0 )
            {
                InitPic( bean, pics, 4 );
            }
        }

        using( AW_Article_dao dao = new AW_Article_dao() )
        {
            bean.fdArtiID = dao.funcNewID();
            if( bean.fdArtiSort == 0 )
                bean.fdArtiSort = bean.fdArtiID * 100;

            dao.funcInsert( bean );
        }
        using( AW_Article_Picture_dao dao = new AW_Article_Picture_dao() )
        {
            if( bean.fdArtiType == 1 )
            {
                if( bean.PictureList.Count > 0 )
                {
                    foreach( AW_Article_Picture_bean pic in bean.PictureList )
                    {
                        pic.fdArPiID = dao.funcNewID();
                        pic.fdArPiArtiID = bean.fdArtiID;
                        dao.funcInsert( pic );
                    }
                }
            }
            else if( bean.fdArtiType == 2 )
            {
                if( bean.CatWalkList.Count > 0 )
                {
                    foreach( AW_Article_Picture_bean pic in bean.CatWalkList )
                    {
                        pic.fdArPiID = dao.funcNewID();
                        pic.fdArPiArtiID = bean.fdArtiID;
                        dao.funcInsert( pic );
                    }
                }
                if( bean.BackStageList.Count > 0 )
                {
                    foreach( AW_Article_Picture_bean pic in bean.BackStageList )
                    {
                        pic.fdArPiID = dao.funcNewID();
                        pic.fdArPiArtiID = bean.fdArtiID;
                        dao.funcInsert( pic );
                    }
                }
                if( bean.CloseUpList.Count > 0 )
                {
                    foreach( AW_Article_Picture_bean pic in bean.CloseUpList )
                    {
                        pic.fdArPiID = dao.funcNewID();
                        pic.fdArPiArtiID = bean.fdArtiID;
                        dao.funcInsert( pic );
                    }
                }
                if( bean.FrontRowList.Count > 0 )
                {
                    foreach( AW_Article_Picture_bean pic in bean.FrontRowList )
                    {
                        pic.fdArPiID = dao.funcNewID();
                        pic.fdArPiArtiID = bean.fdArtiID;
                        dao.funcInsert( pic );
                    }
                }
            }
        }
        this.SetTags( bean, QF( "tags" ).Trim() );
        this.AddLog( EventType.Insert, "添加文章", "栏目[" + drpColumn.SelectedItem.Text + "]添加文章[" + bean.fdArtiTitle + "]" );
        Success( "添加成功", "ArticleList.aspx" );
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
                    picture.fdArPiPath = pic[ i ].Trim();
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
                    picture.fdArPiPath = pic[ i ].Trim();
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
