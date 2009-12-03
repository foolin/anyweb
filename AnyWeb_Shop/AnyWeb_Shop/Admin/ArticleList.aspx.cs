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

public partial class ArticleList : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        
       this.btnDel.Attributes["onclick"] = "javascript:return confirm('确定删除，是否继续？');";
       
    }

    protected void ods3_Selected(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( e.OutputParameters["recordCount"] != null )
        {
            int record = (int)e.OutputParameters["recordCount"];
            PN1.SetPage( record );
        }
    }

    protected void drpType_DataBound(object sender , EventArgs e)
    {
        ListItem item = new ListItem("所有文章类别","0");
        drpType.Items.Insert( 0 , item );
        int cid = 0;
        if ( WebAgent.IsInt32( QS( "cid" ) ) )
        {
            cid= int.Parse(QS( "cid" ));
        }
      
        drpType.SelectedValue = cid.ToString();
        

    }


    protected void btnSearch_Click(object sender , EventArgs e)
    {
        
        Response.Redirect( "ArticleList.aspx?&cid="+int.Parse(drpType.SelectedValue)+"&title=" + txtTitle.Text );
    }


    protected void ods3_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["title"] =  QS( "title" );
    }


    protected void btnDel_Click(object sender , EventArgs e)
    {
        if ( Request.Form["ids"] + "" != "" )
        {
            using ( ArticleAgent ag = new ArticleAgent() )
            {

                ag.ArticlesDelete( Request.Form["ids"] , Request.Form["ids"].Split( ',' ).Length);          

                WebAgent.SuccAndGo( "删除成功。" , "ArticleList.aspx" );
            }
        }
        else
        {
            WebAgent.FailAndGo( "请在要删除的项前打勾。" , "ArticleList.aspx" );
        }
    }
}
