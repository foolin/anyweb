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
using Common.Agent;

public partial class SetMailBox :AdminBase
{
    protected void Page_Load(object sender , EventArgs e)
    {

    }

    protected override void OnPreRender(EventArgs e)
    {
        using ( ShopAgent sa = new ShopAgent() )
        {
            Shop s = sa.GetShopBasicInfo();
            if ( s != null )
            {
                txtEmail.Text = s.Email;
                hidEmailPass.Value = s.EmailPass;
                txtEmailContent.Text = s.EmailContent;

                int j = 0;
                for ( int i = 0 ; i < drpSend.Items.Count ; i++ )
                {
                    if ( drpSend.Items[i].Text .Equals(s.EmailSend ))
                    {
                        j++;
                    }
                }
                if ( j > 0 )
                {
                    drpSend.SelectedItem.Text = s.EmailSend;
                }
                else
                {
                    txtSend.Text = s.EmailSend;
                }
            }
        }
   }

  
    protected void btnSave_Click(object sender , EventArgs e)
    {
        using ( ShopAgent sa = new ShopAgent() )
        { 
            Shop s=new Shop();
            s.Email=txtEmail.Text;
            s.EmailContent=txtEmailContent.Text;
            s.EmailPass = txtEmailPass.Text == "" ? hidEmailPass.Value : txtEmailPass.Text;
            if ( chk1.Checked )
            {
                s.EmailSend = txtSend.Text;
            }
            else
            {
                s.EmailSend = drpSend.SelectedItem.Text;
            }

            if ( sa.SetMail( s ) >0)
            {
                this.AddLog( EventID.Update , "修改邮箱设置" , "修改邮箱设置" );
                WebAgent.SuccAndGo( "设置邮箱成功。" ,Request.RawUrl);
            }
        }
    }
}
