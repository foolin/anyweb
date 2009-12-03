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
using System.Net.Mail;
using Studio.Security;

public partial class OrderItem :AdminBase
{
  
    protected void Page_Load(object sender , EventArgs e)
    {
        paneReason.Visible = false;
        chk1.Visible = false;
        pChange.Visible = false;
        divchk1.Visible = false;
    } 

    protected void btnDeal_Click(object sender , ImageClickEventArgs e)
    {
        using ( OrderAgent oa = new OrderAgent() )
        {
            Literal litEmail = (Literal)fv1.FindControl( "litEmail" );
            Literal litid = (Literal)fv1.FindControl( "litid" );
            Literal litUserName = (Literal)fv1.FindControl( "litUserName" );
            Literal litscore = (Literal)fv1.FindControl( "litScore" );
            Literal lituid = (Literal)fv1.FindControl( "lituid" );

            if ( WebAgent.IsInt32( QS( "oid" ) ) )
            {

                if ( oa.DealOrder( 2 , int.Parse( QS( "oid" ) ) , int.Parse( litscore.Text ) , int.Parse( lituid.Text ) , txtCancleReson.Text ) > 0 )
                {
                    if ( litEmail != null && litEmail.Text != "" )
                    {
                        //----发货成功------------发送公告
                        if ( int.Parse( lituid.Text ) > 0 )
                        {
                            using ( AfficheAgent ag = new AfficheAgent() )
                            {
                                Affiche ac = new Affiche();
                                ac.MemberID = int.Parse( lituid.Text );
                                ac.Title = litUserName.Text + "，您的" + litid.Text + "号购物订单已发货，注意查收";
                                ac.Context = "亲爱的/尊敬的"+litUserName.Text + "：<br/>" + ShopInfo.EmailContent;
                                ac.Type = 1;

                                ag.AfficheAdd( ac );
                            }
                        }

                        //----发货成功------------发送邮件
                        if ( ShopInfo.EmailSend == "" || ShopInfo.EmailPass == "" )
                        {
                            WebAgent.FailAndGo( "处理成功。已向用户发布公告| 邮件发送失败，您还未正确设置商城使用邮箱" , Request.RawUrl );
                        }
                        else
                        {
                            string contentemail = "";

                            if(ShopInfo.Logo=="")
                            {
                                contentemail="<div style='line-height:30px; padding:10px;border:solid 4px #d6eefe;'><strong>亲爱的" + litUserName.Text + "：</strong><br/>" + ShopInfo.EmailContent + "</div>";
                            }
                            else
                            {
                                contentemail="<div style='line-height:30px; padding:10px;border:solid 4px #d6eefe;'><h1><img src='" + ShopInfo.Url + "shopdata/" + ShopInfo.ID + "/Logo.jpg'></h1><strong>亲爱的" + litUserName.Text + "：</strong><br/>" + ShopInfo.EmailContent + "</div>";
                            }

                            this.SendMail( ShopInfo.EmailSend , ShopInfo.Email , ShopInfo.EmailPass , litEmail.Text , ShopInfo.Name + "确认您的购物订单" , contentemail );

                            this.AddLog( Common.Common.EventID.Update , "订单发货" , "订单" + litid.Text + "已发货" );

                            WebAgent.SuccAndGo( "处理成功.并向用户发出了邮件和公告." , Request.RawUrl );
                        }
                    }
                }
                else
                {
                    WebAgent.SuccAndGo( "处理失败" , ViewState["BACK"].ToString() );
                }
            }
        }
    }
    protected void btnCancle_Click(object sender , ImageClickEventArgs e)
    {
        paneReason.Visible = true;

        Literal litUserName = (Literal)fv1.FindControl( "litUserName" );
        Literal litid = (Literal)fv1.FindControl( "litid" );
  
        string emailRea = "亲爱的" + litUserName.Text + "："; 
        txtRegard.Text = emailRea;

        string emailContent="<br/>感谢您光临" + ShopInfo.Name + "！<br/>"; 
        emailContent += "您的" + litid.Text + "号订单，我们无法提供发货服务。<br/>";

        string emailReson = "原因是：( 请将原因填写在下框 )" + txtCancleReson.Text + "<br/>";
        
        string emailSorry = "为此，我们深表歉意，希望您保持愉快的心情。同时我们也期待您能为我们提出宝贵建议和意见。欢迎下次光临！<br/>";
        
        string emailEnd = "------------------------------------------------------------------------------------------ <br/>此信由系统发出。如有任何疑问，请联系我们客服，或者访问商脉通http://www.anyp.com与我们取得联系。";
        txtContent.Text = emailContent + emailReson + emailSorry + emailEnd;
        
    }

  

    protected void fv1_DataBound(object sender , EventArgs e)
    {
        Order o = (Order)fv1.DataItem;
        if ( o != null && o.Status > 0)
        {

            switch ( o.Status )
            {
                case 1:
                    btnDeal.Visible = btnCancle.Visible = true;
                    break;
                case 2:
                    btnDeal.Visible = btnCancle.Visible = false;
                    litmsg.Text = "<span style='font-size:16px;font-weight:bold;'>【已发货】</span>";
                    break;
                case 3:
                    btnDeal.Visible = btnCancle.Visible = false;
                    litmsg.Text = "<span style='font-size:16px;font-weight:bold;'>【已取消该交易】</span>";
                    break;

            }
        }
    }
    protected void btnSendEmail_Click(object sender , EventArgs e)
    {
        Literal litEmail = (Literal)fv1.FindControl( "litEmail" );
        Literal litUserName = (Literal)fv1.FindControl( "litUserName" );
        Literal litid = (Literal)fv1.FindControl( "litid" );
        Literal lituid = (Literal)fv1.FindControl( "lituid" );

        using ( OrderAgent oa = new OrderAgent() )
        {
            if ( oa.DealOrder( 3 , int.Parse( QS( "oid" ) ) , 0 , 0 , txtCancleReson.Text ) > 0 )
            {
                 if ( litEmail != null && litEmail.Text != "" )
                 {
                    
                    if ( chkAffiche.Checked && int.Parse(lituid.Text)> 0)
                    {
                        //-------取消发货----------发送公告
                        using ( AfficheAgent ag = new AfficheAgent() )
                        {
                            Affiche ac = new Affiche();
                            ac.MemberID = int.Parse( lituid.Text );
                            ac.Title = litUserName.Text + "，您的购物订单" + litid.Text + "号被取消";
                            ac.Context = txtRegard.Text + txtContent.Text.ToString().Replace( "( 请将原因填写在下框 )" , txtCancleReson.Text );
                            ac.Type = 1;

                            ag.AfficheAdd( ac );
                        }
                    }
                    //------取消发货----------发送邮件
                    string contentemail2="",title = "";
                    if ( chkEmail.Checked )
                    {
                        title  = ShopInfo.Name + "通知您，您的购物订单" + litid.Text + "被取消";
                        if ( ShopInfo.EmailSend == "" || ShopInfo.EmailPass == "" )
                        {
                            WebAgent.FailAndGo( "已向用户发布公告| 邮件发送失败，您还未正确设置商城使用邮箱" , Request.RawUrl );
                        }
                        else
                        {
                            

                            if ( ShopInfo.Logo == "" )
                            {
                               contentemail2="<div style='line-height:30px; padding:10px;border:solid 4px #d6eefe;'><strong>" + txtRegard.Text + "</strong>" + txtContent.Text.ToString().Replace( "( 请将原因填写在下框 )" , txtCancleReson.Text ) + "</div>" ;
                            }
                            else
                            {
                                contentemail2 = "<div style='line-height:30px; padding:10px;border:solid 4px #d6eefe;'><h1><img src='" + ShopInfo.Url + "shopdata/" + ShopInfo.ID + "/Logo.jpg'></h1><strong>" + txtRegard.Text + "</strong>" + txtContent.Text.ToString().Replace( "( 请将原因填写在下框 )" , txtCancleReson.Text ) + "</div>" ;
                            }
                           
                        }
                    }

                    this.AddLog( Common.Common.EventID.Update , "取消发货" , "取消" + litid.Text + "号订单发货,原因：" + txtCancleReson.Text );

                    this.SendMail( ShopInfo.EmailSend , ShopInfo.Email , ShopInfo.EmailPass , litEmail.Text , title , contentemail2 );
                    WebAgent.SuccAndGo( "通知成功" , Request.RawUrl );
                 }  
              
            }
            else
            {
                WebAgent.FailAndGo( "通知失败" , Request.RawUrl );
            }
        }
    
        
    }

    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="port"></param>
    /// <param name="myEmail"></param>
    /// <param name="myPass"></param>
    /// <param name="sendemail"></param>
    /// <param name="title"></param>
    /// <param name="content"></param>
    public void SendMail(string port , string myEmail , string myPass ,string sendemail, string title , string content)
    {
        SmtpClient client = new SmtpClient( port );
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential( myEmail , myPass );
        client.DeliveryMethod = SmtpDeliveryMethod.Network;

        System.Net.Mail.MailMessage message = new MailMessage( myEmail , sendemail , title ,
          content );

        message.BodyEncoding = System.Text.Encoding.Default;

        message.IsBodyHtml = true;

        client.Send( message );
    }

    protected void btncancle2_Click1(object sender , EventArgs e)
    {
        paneReason.Visible = false;
    }

    protected void ods3_Deleted(object sender , ObjectDataSourceStatusEventArgs e)
    {
        if ( (int)e.ReturnValue > 0 )
        {
            WebAgent.SuccAndGo( "删除成功." , "OrderList.aspx" );
        }
        else
        {
            WebAgent.FailAndGo( "通知失败" , "OrderList.aspx" );
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        if ( WebAgent.IsInt32( QS( "oid" ) ) )
        {
            HiddenField litStatus = (HiddenField)fv1.FindControl( "litStatus" );

            //未发货则检查是否有积分礼品
            if ( litStatus.Value == "1" )
            {
                using ( ChangeNoteAgent ca = new ChangeNoteAgent() )
                {
                   ArrayList list= ca.GetChangeNoteByOrderID(int.Parse( QS( "oid" )));
                   if ( list.Count > 0 )
                   {
                       this.chk1.Visible = true;
                      
                       pChange.Visible = true;
                       divchk1.Visible = true;
                       repChangeNote.DataSource = list;
                       repChangeNote.DataBind();
                      
                   }
                }
            }
        }
    }
   
    protected void btnChange_Click1(object sender , EventArgs e)
    {
        if ( Request.Form["idsChange"] + "" != "" )
        {
            using ( ChangeNoteAgent ca = new ChangeNoteAgent() )
            {
                if ( ca.ChangeNoteOrder( Request.Form["idsChange"] , int.Parse( QS( "oid" ) ) , Request.Form["idsChange"].Split( ',' ).Length ) > 0 )
                {
                    WebAgent.SuccAndGo( "合并成功。" ,Request.RawUrl);
                }
            }
        }
    }
}
