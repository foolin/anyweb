using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Admin.Framework;
using Studio.Web;
using Common.Common;
using Common.Agent;

public partial class SingerArticleEdit : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
      
    }

    protected override void OnPreRender(EventArgs e)
    {
        switch ( QS( "mode" ) )
        {
            case "update":
                Panel1.Visible = true;
                Panel2.Visible = false;
                litTitle.Text = "修改单篇文章栏目";
                if ( WebAgent.IsInt32( QS( "cid" ) ) )
                {
                    using ( ArticleAgent aa = new ArticleAgent() )
                    {
                        SingleArticle sa = aa.GetSingleArticle( int.Parse( QS( "cid" ) ) );
                        Category c = new Category();
                        c = sa.OfCategory;
                        this.txtContent.Text = sa.Content;
                        txtPath.Text = c.Path;
                        txtName.Text = c.Name;
                    }
                }
                break;
            case "delete":
                if ( WebAgent.IsInt32( QS( "cid" ) ) )
                {
                    using ( CategoryAgent ar = new CategoryAgent() )
                    {
                        Category a = new Category();
                        a.ID = int.Parse( QS( "cid" ) );
                        if ( ar.DeleteCategory( a) > 0 )
                        {
                            WebAgent.SuccAndGo( "删除成功" , "ArticleCategoryList.aspx" );
                        }
                    }
                }
                break;
            default:
                Panel1.Visible = false;
                Panel2.Visible = true;
                litTitle.Text = "添加单篇文章栏目";
                break;
        }
    }

    protected void btnSaveUpdate_Click(object sender , EventArgs e)
    {
        if ( WebAgent.IsInt32( QS( "cid" ) ) )
        {
            using ( ArticleAgent aa = new ArticleAgent() )
            {
                SingleArticle sa = new SingleArticle();
                Category c = new Category();
                c.Name = txtName.Text;
                c.Path = txtPath.Text;
                sa.Content = txtContent.Text;
                sa.OfCategory = c;
                sa.CategoryID =int.Parse( QS( "cid" ));

                if ( aa.SingleArticleUpdate( sa ) > 0 )
                {
                    this.AddLog( EventID.Update , "修改单篇文章栏目" , "修改单篇文章栏目，栏目编号：" + QS( "cid" ) );
                    WebAgent.SuccAndGo( "修改成功" , "ArticleCategoryList.aspx" );
                }
            }
        }
    }
    protected void btnDelete_Click(object sender , EventArgs e)
    {
        if ( WebAgent.IsInt32( QS( "cid" ) ) )
        {
            using ( ArticleAgent aa = new ArticleAgent() )
            {
            
                if(aa.SingerArticleDelet( int.Parse( QS( "cid" ) ) )>0)
                {
                     this.AddLog( EventID.Update , "删除单篇文章栏目" , "删除单篇文章栏目，栏目编号："+ QS( "cid" ) );
                    WebAgent.SuccAndGo( "删除成功" , "ArticleCategoryList.aspx" );
                }
            }
        }
    }

    protected void btnSaveAdd_Click(object sender , EventArgs e)
    {
        
            using ( ArticleAgent aa = new ArticleAgent() )
            {
                SingleArticle sa = new SingleArticle();
                Category c = new Category();
                c.Name = txtNameAdd.Text;
                c.Path = txtPathAdd.Text;
                sa.Content = txtContentAdd.Text;
                sa.OfCategory = c;
               
                if ( aa.SingleArticleAdd( sa ) > 0 )
                {
                    this.AddLog( EventID.Update , "添加单篇文章栏目" , "添加修改单篇文章栏目" );
                    WebAgent.SuccAndGo( "添加成功" , "ArticleCategoryList.aspx" );
                }
            }
       
    }
}
