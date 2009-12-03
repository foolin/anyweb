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

public partial class CommentReplay :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }

    protected void ods3_Updated(object sender , ObjectDataSourceStatusEventArgs e)
    {

        if ( (int)e.ReturnValue > 0 )
        {
            this.AddLog( EventID.Insert , "回复评论" , "回复评论,评论编号：" + QS( "cid" ) );

            WebAgent.SuccAndGo( "回复成功." , "CommentList.aspx" );
        }
        else
        {   
            WebAgent.FailAndGo( "回复失败." , "CommentList.aspx" );
        }
      
    }
    
}
