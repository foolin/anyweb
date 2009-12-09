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

public partial class ArticleEdit :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            switch ( QS( "mode" ) )
            {
                case "update":
                    this.fv1.ChangeMode( FormViewMode.Edit );
                    litTitle.Text = "修改文章";
                    break;
                case "select":
                    this.fv1.ChangeMode( FormViewMode.ReadOnly );
                    litTitle.Text = "查看文章";
                    break;
                default:
                    this.fv1.ChangeMode( FormViewMode.Insert );
                    litTitle.Text = "添加文章";
                    break;
            }
        }
    }
    protected void ods3_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        Article ar = (Article)e.InputParameters[0];

        if ( WebAgent.IsInt32( QS( "aid" ) ) )
        {
            e.InputParameters["id"] = int.Parse(QS( "aid" ));
        }
       
    }

    protected void fv1_DataBound(object sender , EventArgs e)
    {
        Article ar = (Article)fv1.DataItem;
        DropDownList drpType = (DropDownList)fv1.FindControl( "drpType" );

        if (QS("mode") != "select")
        {
            if (drpType.Items.Count <= 0)
            {
                WebAgent.FailAndGo("您当前任何文章栏目，请先添加文章栏目。", "ArticleCategoryHandle.aspx?mode=insert");
            }

            if (drpType != null && ar != null)
            {
                drpType.SelectedValue = ar.CategoryID.ToString();
            }
            if (QS("mode") == "insert")
            {
                CheckBox chkComm = (CheckBox)fv1.FindControl("chkComm");

                if (chkComm != null)
                {
                    chkComm.Checked = true;
                }
            }
        }
    }

    protected void ods3_Inserting(object sender , ObjectDataSourceMethodEventArgs e)
    {
        Article ar = (Article)e.InputParameters[0];

        DropDownList drpType = (DropDownList)fv1.FindControl( "drpType" );

        if( drpType != null)
        {
            ar.CategoryID = int.Parse(drpType.SelectedValue); 
        } 
    }

    protected void ods3_Inserted(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
           
            this.AddLog( EventID.Insert , "添加文章" , "添加文章" );

            WebAgent.SuccAndGo( "添加成功。" , "ArticleList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "添加失败。" , ViewState["BACK"].ToString() );
        }
    }

    protected void ods3_Updating(object sender , ObjectDataSourceMethodEventArgs e)
    {
        Article ar = (Article)e.InputParameters[0];

        DropDownList drpType = (DropDownList)fv1.FindControl( "drpType" );
    
        if ( drpType != null )
        {
            ar.CategoryID = int.Parse( drpType.SelectedValue );
        }
    }
    
    protected void ods3_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {

        if ( (int)e.ReturnValue > 0 )
        {
         
            this.AddLog( EventID.Update , "修改文章" , "修改文章" );

            WebAgent.SuccAndGo( "修改成功。" , "ArticleList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "修改失败。" , ViewState["BACK"].ToString() );
        }
    }

    protected void ods3_Deleted(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {

            this.AddLog( EventID.Delete , "删除文章" , "删除文章" );

            WebAgent.SuccAndGo( "删除成功。" , "ArticleList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "删除失败。" , ViewState["BACK"].ToString() );
        }
    }
}
