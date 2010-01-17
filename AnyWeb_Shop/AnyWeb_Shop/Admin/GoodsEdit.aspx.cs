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
using Common.Agent;
using Common.Common;
using System.IO;

public partial class GoodsEdit :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            switch ( QS( "mode" ) )
            {
                case "update":
                    this.fv1.ChangeMode( FormViewMode.Edit );
                    litTitle.Text = "修改商品";
                    break;
                case "select":
                    this.fv1.ChangeMode( FormViewMode.ReadOnly );
                    litTitle.Text = "查看商品";
                    break;
                default:
                    this.fv1.ChangeMode( FormViewMode.Insert );
                    litTitle.Text = "添加商品";
                    break;

            }
        }
    }
    protected void ods3_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        if ( WebAgent.IsInt32( QS( "gid" ) ) )
        {
            e.InputParameters["gid"] = int.Parse( QS( "gid" ) );
        }
      
    }

    protected void fv1_DataBound(object sender , EventArgs e)
    {
        if (QS("mode") != "select")
        {
            Goods gs = (Goods)fv1.DataItem;

            DropDownList type = (DropDownList)fv1.FindControl("drpType");
            DropDownList status = (DropDownList)fv1.FindControl("drpStatus");

            if (type.Items.Count <= 0)
            {
                WebAgent.FailAndGo("您当前没有任何商品类别，请先添加商品类别", "GoodsCategorhandle.aspx?mode=insert");
            }

            if (gs != null && type != null && status != null)
            {
                type.SelectedValue = gs.CategoryID.ToString();

                status.SelectedValue = gs.Status.ToString();
            }

            if (QS("mode") == "insert")
            {

                CheckBox chkComm = (CheckBox)fv1.FindControl("chkComm");

                TextBox txtdata = (TextBox)fv1.FindControl("txtData");
                TextBox txtdataend = (TextBox)fv1.FindControl("txtDataEnd");


                if (chkComm != null)
                {
                    chkComm.Checked = true;
                }

                if (txtdata != null)
                    txtdata.Text = DateTime.Now.ToString("yyyy-MM-dd");

                if (txtdataend != null)
                    txtdataend.Text = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd");
            }
        }
    }

    protected void ods3_Inserting(object sender , ObjectDataSourceMethodEventArgs e)
    {
        FileUpload img = (FileUpload)fv1.FindControl( "txtImage" );
        DropDownList drptype = (DropDownList)fv1.FindControl( "drpType" );

        Goods gs = (Goods)e.InputParameters[0];

        if ( drptype != null && gs != null )
        {
            gs.CategoryID = int.Parse( drptype.SelectedValue );
        }

        if ( img != null )
        {
            gs.Image = this.GetProductImg( img );
        }
    }

    protected void ods3_Inserted(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {

            this.AddLog( EventID.Insert , "添加商品" , "添加商品" );

            WebAgent.SuccAndGo( "添加成功!" , "GoodsList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "添加失败,请重试!" , "GoodsList.aspx" );
        }
    }

    protected void ods3_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {

            this.AddLog( EventID.Insert , "修改商品信息" , "修改商品信息,商品编号：" + QS( "gid" ) );

            WebAgent.SuccAndGo( "修改成功。" , "GoodsList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "修改失败。" , "GoodsList.aspx" ); 
        }
    }

    protected void ods3_Deleted(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Delete , "删除商品信息" , "删除商品信息,商品编号：" + QS( "gid" ) );

            WebAgent.SuccAndGo( "删除成功." , "GoodsList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "删除失败." , "GoodsList.aspx" );
        }
    }

    protected void ods3_Updating(object sender , ObjectDataSourceMethodEventArgs e)
    {
        FileUpload img = (FileUpload)fv1.FindControl( "txtImage" );
        DropDownList drptype = (DropDownList)fv1.FindControl( "drpType" );
        DropDownList status = (DropDownList)fv1.FindControl( "drpStatus" );

        Goods gs = (Goods)e.InputParameters[0];
        TextBox txtScore = (TextBox)fv1.FindControl( "txtScore" );

        gs.Unit = "";
        gs.Weight = 0;

        if ( gs!= null && drptype != null && status != null)
        {
            gs.CategoryID = int.Parse( drptype.SelectedValue );
            gs.Status = int.Parse( status.SelectedValue );
        }

        if ( gs != null && img != null )
        {
            string imgurl = this.GetProductImg( img );

            if ( imgurl != "" )
            {
                gs.Image = imgurl;
            }
        }
 
    }

    public string CheckStatus(int status , DateTime outDate)
    {
        string s = "";
        if ( status == 1 )
        {
            s = "<font color='green'>有货</font>";
        }
        if ( status == 2 )
        {
            s = "<font color='red'>缺货</font>";
        }
        if ( status == 3 || outDate < DateTime.Now )
        {
            s = "<font color='gray'>过期</font>";
        }
        return s;
    }    
}
