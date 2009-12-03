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
using Common.Agent;
using Studio.Web;

public partial class CommentList1 :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        btnDel.Attributes["onclick"] = "javascript:return confirm('确定删除,是否继续？');";
        if ( QS( "sid" ) != "" )
        {
            int sid = int.Parse(QS( "sid" ));
            if ( sid > 0 )
            { 
                  HttpRuntime.Cache.Remove( "COMMENTLIST" );
            }
        }
   
    }
    protected void btnSearch_Click(object sender , EventArgs e)
    {
      
        Response.Redirect( "CommentList.aspx?username=" + txtName.Text );
    }

    protected void ods3_Selecting(object sender , ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["userName"] = QS( "username" );
    }


    protected void ods3_Selected(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( e.OutputParameters["recordCount"] != null )
        {
            PN1.SetPage( (int)e.OutputParameters["recordCount"] );
        }
    }

    protected void btnDel_Click(object sender , EventArgs e)
    {

        if ( Request.Form["ids"] + "" != "" )
        {
            using (Common.Agent.CommentAgent ca = new Common.Agent.CommentAgent() )
            {
               
                ca.CommentsDelete( Request.Form["ids"] , Request.Form["ids"].Split( ',' ).Length );

                HttpRuntime.Cache.Remove( "COMMENTLIST" );

                this.AddLog( Common.Common.EventID.Delete , "删除评论" , "删除评论" );

                WebAgent.SuccAndGo( "删除成功。" , "CommentList.aspx" );
            }
        }
        else
        {
            WebAgent.FailAndGo( "请在要删除的项前打勾。" , "CommentList.aspx" );
        }
    }
}
