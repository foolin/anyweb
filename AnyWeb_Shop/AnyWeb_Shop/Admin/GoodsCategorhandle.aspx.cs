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
using Common.Common;
using Admin.Framework;
using Common.Agent;
using Studio.Web;

public partial class GoodsCategorhandle :AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            switch (QS("mode"))
            {
                case "update":
                    this.fv1.ChangeMode(FormViewMode.Edit);
                    litTitle.Text = "编辑商品类别";
                    Button btndel = (Button)fv1.FindControl( "btnDelete" );
                    if ( btndel != null )
                    {
                        btndel.Attributes["onclick"] = "javascript:return confirm('删除此商品类别会将相关前台显示内容一并移除，确定删除？');";

                    }
                    break;
                case "delete":
                    if ( WebAgent.IsInt32( QS( "cid" ) ) )
                    {
                        using ( CategoryAgent ca = new CategoryAgent() )
                        {
                            Category c = new Category();
                            c.ID = int.Parse( QS( "cid" ) );
                            if ( ca.DeleteCategory( c ) > 0 )
                            {
                                WebAgent.SuccAndGo( "删除成功" , "GoodsCategoryList.aspx" );
                            }

                        }
                    }
               
                    break;    
                default:
                    this.fv1.ChangeMode(FormViewMode.Insert);
                    litTitle.Text = "添加商品类别";
                    break;
            }
        }
    }
    protected void fv1_DataBound(object sender, EventArgs e)
    {
        Category ca = (Category)fv1.DataItem;

        DropDownList drppater = (DropDownList)this.fv1.FindControl("drpPater");

        ListItem item = new ListItem("没有上级类别", "0");  
        drppater.Items.Insert(0, item);
        int pater = 0;

        if (QS("mode") == "update")
        {
            pater = ca.Pater;

            if (((new CategoryAgent()).GetCategoryChildren(ca.ID)).Count > 0)
            {
                drppater.Enabled = false;
            }
        }
        drppater.SelectedValue = pater.ToString();

    }

    protected void ods3_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ((int)e.ReturnValue >0)
        {
            this.AddLog( EventID.Update , "修改商品类别" , "修改商品类别" );

            WebAgent.SuccAndGo( "修改成功." , ViewState["BACK"].ToString() );
        }
    }

    protected void ods3_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ( ( int )e.ReturnValue  >0 )
        {
            this.AddLog( EventID.Delete , "删除商品类别" , "删除商品类别" );

            WebAgent.SuccAndGo( "删除成功." , ViewState["BACK"].ToString() );
        }

    }
    protected void ods3_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Insert , "添加商品类别" , "添加商品类别" );

            WebAgent.SuccAndGo( "添加成功." , ViewState["BACK"].ToString() );
        }

    }

    protected void ods3_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        Category c = (Category)e.InputParameters[0];

        DropDownList drppater = (DropDownList)this.fv1.FindControl("drpPater");

        if (drppater != null)
        {
            c.Pater = int.Parse(drppater.SelectedValue);
        }

        c.Type = 2;
    }

    protected void ods3_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        Category c = (Category)e.InputParameters[0];

        DropDownList drppater = (DropDownList)this.fv1.FindControl("drpPater");
   
        if (drppater != null)
        {
            c.Pater = int.Parse(drppater.SelectedValue);
        }

        c.Type = 2;
    }
}
