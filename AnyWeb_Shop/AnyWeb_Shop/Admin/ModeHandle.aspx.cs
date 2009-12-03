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

public partial class ModeHandle : AdminBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( !IsPostBack )
        {

            if ( QS( "mode" ) == "insert" )
            {
                this.fv1.ChangeMode( FormViewMode.Insert );
                litTitle.Text = "添加支付方式";
            }
            if ( QS( "mode" ) == "delete" )
            {
                if ( WebAgent.IsInt32( QS( "mid" ) ) )
                {
                    using ( ModeAgent ma = new ModeAgent() )
                    {
                        Mode m = new Mode();
                        m.ID = int.Parse(QS( "mid" ));
                        if ( ma.DeleteMode( m ) > 0 )
                        {
                            WebAgent.SuccAndGo( "删除成功" , "PaymentModeList.aspx" );
                        }
                    }
                }
            }
            if ( QS( "mode" ) == "update" )
            {
                this.fv1.ChangeMode( FormViewMode.Edit );
                litTitle.Text = "编辑支付方式";
            }
        }
    }

    protected void fv1_DataBound(object sender, EventArgs e)
    {
        if (QS("mode") == "insert")
        {
            DropDownList ddldeliver = (DropDownList)fv1.FindControl("ddlSysDeliver");

            ListItem item = new ListItem("选择支付方式范例", "0");
            ddldeliver.Items.Insert(0, item);
        }
        if (QS("mode") == "insert" && WebAgent.IsInt32(QS("mid")))
        {

            Mode m = (new ModeAgent()).GetModeInfo(int.Parse(QS("mid")));

            if (m == null)
            {
                return;
            }

            TextBox txttitle = (TextBox)this.fv1.FindControl("txtTitle");
            txttitle.Text = m.Title;

            TinyMce txtContent = (TinyMce)this.fv1.FindControl("txtContent");
            txtContent.Text = m.Content;

            DropDownList ddldeliver = (DropDownList)fv1.FindControl("ddlSysDeliver");
            ddldeliver.SelectedValue = m.ID.ToString();
        }


       HiddenField h =(HiddenField)this.fv1.FindControl("hidtype");
       h.Value = "1";
    }
    protected void ods3_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ((int)e.ReturnValue > 0)
        {
            this.AddLog( EventID.Insert , "添加支付方式" , "添加支付方式" );
            WebAgent.SuccAndGo( "添加成功!" , "PaymentModeList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo("添加失败,请重试!",ViewState["BACK"].ToString());
        }
        
    }
    protected void ods3_Updated(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ((int)e.ReturnValue > 0)
        {
            this.AddLog( EventID.Update , "修改支付方式" , "修改支付方式" );
            WebAgent.SuccAndGo( "修改成功!" , "PaymentModeList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo("修改失败,请重试!", ViewState["BACK"].ToString());
        }
    }

    protected void ods3_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if ((int)e.ReturnValue > 0)
        {
            this.AddLog( EventID.Delete , "删除支付方式" , "删除支付方式" );
            WebAgent.SuccAndGo("删除成功!",  "PaymentModeList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo("删除失败,请重试!", ViewState["BACK"].ToString());
        }
    }

    protected void ddlSysDeliver_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddldeliver = (DropDownList)fv1.FindControl("ddlSysDeliver");
        Response.Redirect("ModeHandle.aspx?mode=insert&mid=" + ddldeliver.SelectedValue);
    }

   
}
