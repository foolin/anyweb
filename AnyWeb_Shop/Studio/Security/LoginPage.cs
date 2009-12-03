using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections.Specialized;

using Studio.Web;

namespace Studio.Security
{
	/// <summary>
	/// 统一认证登陆页面
	/// </summary>
	public class LoginPage : Page
	{
		protected Button btnSignIn;					//登陆确定按钮（Button）
		protected LinkButton lnkSignIn;				//登陆确定按钮（LinkButton）
		protected Button btnSignOut;				//注销按钮（Button）
		protected LinkButton lnkSignOut;			//注销按钮（LinkButton）
		protected Panel panSignIn;					//登陆窗口（未登陆时显示）
		protected Panel panSignOut;					//信息窗口（已登陆后显示）
		protected Label lblStatus;					//状态信息
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
			if( Request.Params["clientid"] != null) //SSO Server返回的客户端标识
			{
				SSOAgent.GetAgent().SaveClientID(Request.Params["clientid"]);
				if( Request.Params["token"] + "" != "")
					LoginSucc();
			}
			else//当前登陆数据
			{
				switch( Request.Params["action"])	//自动登陆（注销）通知接收程序
				{
					case "signin":					//用户在其他系统登陆
					{
						//LoginSucc();
						//Response.End();
						break;
					}
					case "signout":					//用户在其他系统注销
						DoSignOut();break;
					default:
						DoLogin();break;			//在本系统登陆
				}
			}

			//返回最初访问的页面
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
					lblStatus.Text = lblStatus.Text = "欢迎您!" + this.UserName;
				}
//				if( lblStatus != null)
//				{
//					Ticket t = SSOAgent.GetAgent().GetCurrentTicket();
//					if( t != null)
//					{
//						this.UserID = t.User.UserID;
//						this.UserName = t.User.UserName;
//						this.DomainName = t.User.DomainName;
//						lblStatus.Text = "欢迎您!" + t.User.UserName;
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
					Response.Write("<html><head><title>登陆</title></head><body>");
					Response.Write("<font style='font-size:12px;'>登陆成功,正在加载页面...</font>");
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
					Alert("对不起,登陆失败！请检查输入的用户名和密码！");
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
