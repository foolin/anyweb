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
using Common.Common;
using Studio.Web;
using Common.Agent;

public partial class ArticleCategoryHandle :AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            switch (QS("mode"))
            {
                case "update":
                    this.fv1.ChangeMode(FormViewMode.Edit);
                    litTitle.Text = "编辑文章栏目";
                    Button btndel = (Button)fv1.FindControl( "btnDelete" );
                    if ( btndel != null )
                    {
                        btndel.Attributes["onclick"] = "javascript:return confirm('删除此栏目会将相关前台显示内容一并移除，确定删除？');";
                    }
                    break;
                case "delete":
                    if ( WebAgent.IsInt32( QS( "cid" ) ) )
                    {
                        using ( CategoryAgent ar = new CategoryAgent() )
                        {
                            Category c = new Category();
                            c.ID = int.Parse( QS( "cid" ) );
                            if ( ar.DeleteCategory(c)> 0 )
                            {
                                WebAgent.SuccAndGo( "删除成功" , "ArticleCategoryList.aspx" );
                            }
                        }
                    }
                    break;
              
                default:
                    this.fv1.ChangeMode(FormViewMode.Insert);
                    litTitle.Text = "添加文章栏目";
                    break;
            }
            

        }
    }

    protected void ods3_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (((int)e.ReturnValue) > 0)
        {
            this.AddLog( EventID.Update , "修改文章类别" , "修改文章类别,类别编号：" + QS( "cid" ) );

            WebAgent.SuccAndGo( "修改成功." , ViewState["BACK"].ToString() );                         
        }
    }

    protected void ods3_Deleting(object sender , ObjectDataSourceMethodEventArgs e)
    {
       
    }

    protected void ods3_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Delete , "删除文章类别" , "删除文章类别,类别编号：" + QS( "cid" ) );

            WebAgent.SuccAndGo( "删除成功." , ViewState["BACK"].ToString() );
        }

    }
    protected void ods3_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue  > 0 )
        {
            this.AddLog( EventID.Insert , "添加文章类别" , "添加文章类别" );

            WebAgent.SuccAndGo("添加成功.", ViewState["BACK"].ToString());
        }

    }

    protected void ods3_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        Category c = (Category)e.InputParameters[0];

        c.Pater = 0;
        c.Type = 1;
    }

    protected void ods3_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        Category c = (Category)e.InputParameters[0];

        c.Type = 1;
        c.Pater = 0;
    }

   
}
