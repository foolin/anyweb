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
using Common.Common;

public partial class ComplaintsEdit : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }


    protected override void OnPreRender(EventArgs e)
    {

        using ( ComplaintsAgent ca = new ComplaintsAgent() )
        { 
            if(WebAgent.IsInt32(Request.QueryString["cid"]))
            {
                Complaints cs =  ca.GetComplaintsByID( int.Parse( Request.QueryString["cid"] ) );
                litContent.Text = cs.Content;
            }
        }
    }

    protected void btnSave_Click(object sender , EventArgs e)
    {
       
        if ( WebAgent.IsInt32( Request.QueryString["cid"] ) && WebAgent.IsInt32( Request.QueryString["mid"] ) )
        {
          
            using ( AfficheAgent aa = new AfficheAgent() )
            {
                Affiche af = new Affiche();
                af.MemberID = int.Parse( Request.QueryString["mid"] );
                af.Order = 0;
                af.Title = ShopInfo.Name + "回复您的投诉信息";
                af.ShopID = ShopInfo.ID;
                af.Context = txtReplay.Text;
                af.Type = 1;
                af.CreateAt = DateTime.Now;
                int a=aa.AfficheAdd( af );
                if ( a > 0 )
                {
                    using ( ComplaintsAgent ca = new ComplaintsAgent() )
                    {
                        if ( ca.UpdateComplaints( int.Parse( Request.QueryString["cid"] ) , a ) > 0 )
                        {
                            this.AddLog( EventID.Update , "回复投诉单" , "回复投诉，投诉编号" + Request.QueryString["mid"] );
                            WebAgent.SuccAndGo( "回复成功." , "ComplaintsList.aspx" );
                        }
                    }
                }

            }
          
        }
    }
}
