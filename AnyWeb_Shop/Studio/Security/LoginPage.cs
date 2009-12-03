using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections.Specialized;

using Studio.Web;

namespace Studio.Security
{
	/// <summary>
	/// ͳһ��֤��½ҳ��
	/// </summary>
	public class LoginPage : Page
	{
		protected Button btnSignIn;					//��½ȷ����ť��Button��
		protected LinkButton lnkSignIn;				//��½ȷ����ť��LinkButton��
		protected Button btnSignOut;				//ע����ť��Button��
		protected LinkButton lnkSignOut;			//ע����ť��LinkButton��
		protected Panel panSignIn;					//��½���ڣ�δ��½ʱ��ʾ��
		protected Panel panSignOut;					//��Ϣ���ڣ��ѵ�½����ʾ��
		protected Label lblStatus;					//״̬��Ϣ
		protected int UserID;
		protected string UserName;
		protected string DomainName;

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			if( lnkSignOut != null)
				lnkSignOut.Click += new EventHandler(lnkSignOut_Click);

			if( btnSignOut != null)
				btnSignOut.Click += new EventHandler(btnSignOut_Click);
		}

		protected override void OnLoad(EventArgs e)
		{
			if( Request.Params["clientid"] != null) //SSO Server���صĿͻ��˱�ʶ
			{
				SSOAgent.GetAgent().SaveClientID(Request.Params["clientid"]);
				if( Request.Params["token"] + "" != "")
					LoginSucc();
			}
			else//��ǰ��½����
			{
				switch( Request.Params["action"])	//�Զ���½��ע����֪ͨ���ճ���
				{
					case "signin":					//�û�������ϵͳ��½
					{
						//LoginSucc();
						//Response.End();
						break;
					}
					case "signout":					//�û�������ϵͳע��
						DoSignOut();break;
					default:
						DoLogin();break;			//�ڱ�ϵͳ��½
				}
			}

			//����������ʵ�ҳ��
			if( Request.Params["backurl"] != null && Request.Params["noback"] == null && Request.Params["backurl"].ToLower().IndexOf("login.aspx") < 0)
			{
				SSOAgent.GetAgent().TransPageByPost(Server.UrlDecode(Request.Params["backurl"]), new NameValueCollection());			
			}

			base.OnLoad(e);
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			
			if( SSOAgent.GetAgent().IsAuthenticated())
			{
				if( panSignIn != null)
				{
					panSignIn.Visible = false;
				}

				if( panSignOut != null)
				{
					panSignOut.Visible = true;
				}

				this.UserID = int.Parse(SSOAgent.GetAgent().GetIdentity());
				this.UserName = SSOAgent.GetAgent().GetIdentityName();
				this.DomainName = "http://www.anyp.cn";
				if( lblStatus != null)
				{
					lblStatus.Text = lblStatus.Text = "��ӭ��!" + this.UserName;
				}
//				if( lblStatus != null)
//				{
//					Ticket t = SSOAgent.GetAgent().GetCurrentTicket();
//					if( t != null)
//					{
//						this.UserID = t.User.UserID;
//						this.UserName = t.User.UserName;
//						this.DomainName = t.User.DomainName;
//						lblStatus.Text = "��ӭ��!" + t.User.UserName;
//					}
//				}
			}
			else
			{
				if( panSignIn != null)
				{
					panSignIn.Visible = true;
				}

				if( panSignOut != null)
				{
					panSignOut.Visible = false;
				}
			}
		}

		protected virtual void DoLogin()
		{
			string identity = Request.Params["identity"] + "";
			string password = Request.Params["password"];
			int method = 1;

			if( identity == "")
			{
				if( WebAgent.IsInt32( Request.Params["userid"]))
					identity = Request.Params["userid"];
				else
					if( Request.Params["domain"] + "" != "")
					identity = Request.Params["domain"];
				else
					if( Request.Params["email"] + "" != "")
					identity = Request.Params["domain"];
			}
			if( identity != "" && password != null)
			{
				if( WebAgent.IsNumeric( Request.Params["loginmethod"]))
				{
					method = int.Parse( Request.Params["loginmethod"]);
				}

				Ticket t = SSOAgent.GetAgent().SignIn( identity, method, password);

				if( t != null)
				{
					SSOAgent.GetAgent().SetIdentity(t.Identity, t.IdentityName);
					
					this.DoAfterSignIn(t.Identity);

					Response.Clear();
					Response.Write("<html><head><title>��½</title></head><body>");
					Response.Write("<font style='font-size:12px;'>��½�ɹ�,���ڼ���ҳ��...</font>");
					Response.Write("<script language='javascript'>");
					if( Request.QueryString["backurl"] != null)
						Response.Write("function Go(){document.location.href='" + String.Format(Request.QueryString["backurl"], t.Identity, t.IdentityName) + "';}");
					else
						Response.Write("function Go(){document.location.href=document.location.href + '?r=1';}");
					Response.Write("setTimeout('Go()',3000);");
					Response.Write("</script>");
//					int i = 0;
//					foreach( string delegateUrl in t.Delegates)
//					{
//						if( Request.Url.ToString().ToLower().IndexOf(delegateUrl.ToLower()) < 0)
//						{
//							Response.Write("<iframe style='width:1px;height:1px;' name='innerF" + (++i).ToString() + "'></iframe>");
//							NameValueCollection datas = new NameValueCollection(5);
//							datas.Add("action", "signin");
//							datas.Add("token", SSOAgent.GetAgent().Encode(t.ToString()));
//							SSOAgent.GetAgent().CreateForm( i, delegateUrl, "innerF" + i.ToString(), datas);
//						}
//					}
					
					Response.Write("</body></html>");
					Response.Flush();
					Response.End();
				}
				else
				{
					Alert("�Բ���,��½ʧ�ܣ�����������û��������룡");
				}
			}
		}

		void LoginSucc()
		{
			string ticketStr = SSOAgent.GetAgent().Decode(Request.Params["token"]);
			Ticket t = new Ticket(ticketStr);
			if( t.ClientID != "" && t.ClientID == SSOAgent.GetAgent().GetCurrentClientID())
			{
				SSOAgent.GetAgent().SetIdentity( t.Identity, t.IdentityName);
				this.DoAfterSignIn(t.Identity);
			}
		}

		void DoSignOut()
		{
			string identity = SSOAgent.GetAgent().GetIdentity();
			SSOAgent.GetAgent().SignOut();
			
			this.DoAfterSignOut( identity);

			Response.Redirect(Request.Path);
		}

		protected virtual void DoAfterSignIn( string identity){}
		protected virtual void DoAfterSignOut( string identity){}

		void Alert( string message)
		{
			Response.Write("<script language='javascript'>alert('" + message + "');</script>");
		}

		private void lnkSignOut_Click(object sender, EventArgs e)
		{
			DoSignOut();
		}

		private void btnSignOut_Click(object sender, EventArgs e)
		{
			DoSignOut();
		}
	}
}
