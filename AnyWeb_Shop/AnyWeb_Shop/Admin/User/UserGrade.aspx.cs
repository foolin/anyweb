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
using Admin.Framework;
using Studio.Web;

public partial class User_UserGrade : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            using ( UserAgent ua = new UserAgent() )
            {
                DataTable datarow = ua.GetMemberGrade();
                if ( datarow.Rows.Count <= 10 )
                {

                    for ( int i = datarow.Rows.Count ; i <= 10 ; i++ )
                    {
                        DataRow dr = datarow.NewRow();
                        dr["GradeName"] = "";
                        dr["MaxPoint"] = 0;
                        datarow.Rows.Add( dr );

                    }


                    repUser.DataSource = datarow;
                    repUser.DataBind();

                }
            }
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        
    }

    protected void btnSave_Click(object sender , EventArgs e)
    {
        TextBox txtGradeName;
        TextBox txtMaxPoint;
        DataTable dt = new DataTable();
        dt.Columns.Add( new DataColumn( "GradeName" ) );
        dt.Columns.Add( new DataColumn( "MaxPoint" ) );
        for ( int i = 0 ; i < repUser.Items.Count ; i++ )
        {
            txtGradeName = (TextBox)repUser.Items[i].FindControl( "txtGradeName" );
            txtMaxPoint = (TextBox)repUser.Items[i].FindControl( "txtMaxPoint" );
            if ( txtGradeName.Text.Trim() == "" )
                break;
            if ( !WebAgent.IsInt32( txtMaxPoint.Text ) )
                break;
            DataRow dr = dt.NewRow();
            dr["GradeName"] = txtGradeName.Text;
            dr["MaxPoint"] = int.Parse( txtMaxPoint.Text );
            dt.Rows.Add( dr );
        }

        using ( UserAgent ua = new UserAgent() )
        {
            ua.UpdateGrade( dt );
           
        }
        WebAgent.SuccAndGo( "修改成功." , Request.RawUrl );
    }
   

    protected void repUser_Load(object sender , EventArgs e)
    {
        if ( repUser.Items.Count > 0 )
        {
            TextBox txtPoint = (TextBox)repUser.Items[0].FindControl( "txtMaxPoint" );

            if ( txtPoint != null )
            {
                txtPoint.ReadOnly = true;
                txtPoint.BorderStyle = System.Web.UI.WebControls.BorderStyle.None;
            }
        }
    }

    protected void btnReset_Click(object sender , EventArgs e)
    {
        using ( UserAgent ua = new UserAgent() )
        {
            if ( ua.GradeDelete()>0 )
            {
                WebAgent.SuccAndGo( "重置成功" , "UserGrade.aspx" );
            }
        }
    }
}
