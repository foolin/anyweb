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
using Common.Agent;
using Studio.Web;

public partial class _Default : AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {
       

    }

    protected override void OnPreRender(EventArgs e)
    {
       
        if ( ( Request.Cookies["SHOPID"] == null ) )
        {
            pn2.Visible = true;
            pn1.Visible = false;
        }
        else
        {
            pn2.Visible = false;
            pn1.Visible = true;
            using ( StatAgent s = new StatAgent() )
            {
                this.litComment.Text = ( ShopInfo.CommentCount - s.GetNewStatByTypeID( 1 ) ).ToString();
                this.litLeave.Text = ( ShopInfo.MessageCount - s.GetNewStatByTypeID( 2 ) ).ToString();
                this.litOrder.Text = ( ShopInfo.OrderCount - s.GetNewStatByTypeID( 3 ) ).ToString();
                this.litUser.Text = ( ShopInfo.UserCount - s.GetNewStatByTypeID( 4 ) ).ToString();

                using ( OrderAgent oa = new OrderAgent() )
                {
                    litorder1.Text = oa.OrderStat( 1 ).ToString();
                    litOrder2.Text = oa.OrderStat( 2 ).ToString();
                    litOrder3.Text = oa.OrderStat( 3 ).ToString();
                }

            }
        }
    }
    protected void btnOpen_Click(object sender , EventArgs e)
    {

    }
}
