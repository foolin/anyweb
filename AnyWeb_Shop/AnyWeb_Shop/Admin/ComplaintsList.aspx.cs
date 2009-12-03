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
using Common.Agent;
using Studio.Web;
using Admin.Framework;

public partial class ComplaintsList : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

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
        if ( Request.Form["ck1"] + "" != "" )
           
        {
            using ( ComplaintsAgent ca= new ComplaintsAgent() )
            {

                if ( ca.DeleteComplaints( Request.Form["ck1"] , Request.Form["ck1"].Split( ',' ).Length ) > 0 )
                {


                    this.AddLog( Common.Common.EventID.Delete , "删除投诉" , "删除投诉，投诉编号为：" + Request.Form["ck1"] );

                    WebAgent.SuccAndGo( "删除成功。" , "ComplaintsList.aspx" );
                }
            }
        }
        else
        {
            WebAgent.FailAndGo( "请在要删除的项前打勾。" , "ComplaintsList.aspx" );
        }
    }
}
