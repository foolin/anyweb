using System;
using System.Web;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

using Studio.Passport;
using Studio.Array;

namespace Studio.Security
{
	/// <summary>
	/// 统一认证代理
	/// </summary>
	public class SSOAgent
	{
		/// <summary>
		/// 与SSO Server握手,通常在Session_Start发生时
		/// </summary>
		/// <param name="backUrl">返回本系统的Url</param>
		/// <param name="loginUrl">本系统的登陆处理Url</param>
		public void SayHello(string backUrl, string loginUrl)
		{
			//对Web服务不操作
			if( HttpContext.Current.Request.Url.LocalPath.ToLower().IndexOf(".asmx") > 0)
			{
				return;
			}

			if( HttpContext.Current.Request.Browser.Cookies && HttpContext.Current.Request.Params["hello"] == null)
			{
				if( HttpContext.Current.Request.Cookies["SESSION_STARTED"] == null || DateTime.Now.AddMinutes(-this.Timeout) > DateTime.Parse(HttpContext.Current.Request.Cookies["SESSION_STARTED"].Value) )
				{
					HttpContext.Current.Response.Cookies["SESSION_STARTED"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

					NameValueCollection datas = new NameValueCollection(2);
					datas.Add( "b", Encode(backUrl));
					datas.Add( "l", Encode(loginUrl));
					datas.Add( "hello", "1");
					this.TransPageByPost( this.SSOPage, datas);
				}
			}
		}

		public void SayHello(string backUrl, string loginUrl, bool forceHello)
		{
			if( forceHello)
			{
				if( HttpContext.Current.Request.Cookies["SESSION_STARTED"] != null)
				{
					HttpContext.Current.Request.Cookies["SESSION_STARTED"].Value = DateTime.Now.AddMinutes(-(this.Timeout+1)).ToString("yyyy-MM-dd HH:mm:ss");
				}
			}

			SayHello(backUrl,loginUrl);
		}

		/// <summary>
		/// 采用POST方式转向另一个页面
		/// </summary>
		/// <param name="action">目标页面</param>
		/// <param name="datas">需要传递的数据集</param>
		public void TransPageByPost( string action, NameValueCollection datas)
		{
			HttpResponse response = HttpContext.Current.Response;
			HttpRequest request = HttpContext.Current.Request;
			if( request.HttpMethod == "POST")					//将本页面获得的POST数据一起传递
			{
				for( int i = 0; i < request.Form.Count; i++ )
				{
					if( datas[request.Form.Keys[i]] == null && request.Form.Keys[i] != "__VIEWSTATE")
					{
						datas.Add( request.Form.Keys[i], request.Form[i]);
					}
				}
			}

			response.Clear();
			response.Write("<html>");
			response.Write("<head>");
			response.Write("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\">");
			response.Write("</head>");
			response.Write("<body>");
			this.CreateForm( 1,action, "_self", datas);
			response.Write("</body>");
			response.Write("</html>");
			response.Flush();
			response.End();			
		}

		/// <summary>
		/// 创建一个HtmlForm，将需传递的信息生成HttpInputHidden域
		/// </summary>
		/// <param name="idx">Form编号，区分多个Form</param>
		/// <param name="action">目标地址</param>
		/// <param name="target">目标窗口</param>
		/// <param name="datas">需传递的数据集合</param>
		public void CreateForm( int idx, string action, string target, NameValueCollection datas)
		{
			HttpResponse response = HttpContext.Current.Response;
			if( action.IndexOf(',')>0)
				action = action.Substring(0, action.IndexOf(','));

			response.Write("<script language=javascript>");
			response.Write("f" + idx.ToString() + " = document.createElement(\"form\");");
			response.Write("f" + idx.ToString() + ".method = \"post\";");
			response.Write("f" + idx.ToString() + ".target = \"" + target + "\";");
			response.Write("f" + idx.ToString() + ".action = \"" + action + "\";");
			for( int i = 0; i<datas.Count; i++)
			{
				response.Write("h" + idx.ToString() + " = document.createElement(\"input\");");
				response.Write("h" + idx.ToString() + ".type = \"hidden\";");
				response.Write("h" + idx.ToString() + ".name = \"" + datas.Keys[i] + "\";");
				response.Write("h" + idx.ToString() + ".value = \"" + datas[i] + "\";");
				response.Write("f" + idx.ToString() + ".insertBefore(h" + idx.ToString() + ",null);");
			}
			response.Write("(document.body==undefined?document.documentElement:document.body).insertBefore(f" + idx.ToString() + ",null);");
			response.Write("f" + idx.ToString() + ".submit();");
			response.Write("</script>");			
		}

		/// <summary>
		/// 与服务器握手
		/// </summary>
		public void SayHello()
		{
			string path = HttpContext.Current.Request.RawUrl.ToString();
			string backUrl = HttpContext.Current.Server.UrlEncode(path);
			string loginUrl = "http://" + HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath + "/login.aspx";
			if( HttpContext.Current.Request.Url.Port != 80)
				loginUrl = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port.ToString() + HttpContext.Current.Request.ApplicationPath + "/login.aspx";
					
			SayHello( backUrl.Replace("//login", "/login"), loginUrl.Replace("//login", "/login"));
		}

		public void SayHello( bool forceHello)
		{
			if( forceHello)
			{
				if( HttpContext.Current.Request.Cookies["SESSION_STARTED"] != null)
				{
					HttpContext.Current.Request.Cookies["SESSION_STARTED"].Value = DateTime.Now.AddMinutes(-(this.Timeout+1)).ToString("yyyy-MM-dd HH:mm:ss");
				}
			}

			SayHello();
		}

		/// <summary>
		/// 判断是否登陆
		/// </summary>
		/// <returns></returns>
		public bool IsAuthenticated()
		{
			return this.GetIdentity() != "";
		}

		/// <summary>
		/// 获取当前登陆的凭证信息，自动更新过期时间
		/// </summary>
		/// <returns>已验证的身份标识</returns>
		public string GetIdentity()
		{
			if( HttpContext.Current.Request.Cookies["SSOIdentity"] == null || HttpContext.Current.Request.Cookies["SSOIdentity"].Value + "" == "")
				return "";
			else
			{
				string[] ssoValues = this.Decode(HttpContext.Current.Request.Cookies["SSOIdentity"].Value).Split('|');
				if( ssoValues.Length >= 2)// && DateTime.Parse(ssoValues[1]).AddMinutes(this.Timeout) > DateTime.Now)
				{
					//this.SetIdentity(ssoValues[0]);			
					return ssoValues[0];
				}
				else
					return "";
			}
		}

		/// <summary>
		/// 获取当前登陆的时间
		/// </summary>
		/// <returns>登陆的时间</returns>
		public DateTime GetLoginTime()
		{
			if( HttpContext.Current.Request.Cookies["SSOIdentity"] == null || HttpContext.Current.Request.Cookies["SSOIdentity"].Value + "" == "")
				return DateTime.MinValue;
			else
			{
				string[] ssoValues = this.Decode(HttpContext.Current.Request.Cookies["SSOIdentity"].Value).Split('|');
				if( ssoValues.Length >= 2)
				{
					return DateTime.Parse(ssoValues[1]);
				}
				else
					return DateTime.MinValue;
			}
		}

		/// <summary>
		/// 获取当前登陆的凭证信息昵称
		/// </summary>
		/// <returns>已验证的身份标识的昵称</returns>
		public string GetIdentityName()
		{
			if( HttpContext.Current.Request.Cookies["SSOIdentity"] == null || HttpContext.Current.Request.Cookies["SSOIdentity"].Value + "" == "")
				return "";
			else
			{
				string[] ssoValues = this.Decode(HttpContext.Current.Request.Cookies["SSOIdentity"].Value).Split('|');
				if( ssoValues.Length == 2)// && DateTime.Parse(ssoValues[1]).AddMinutes(this.Timeout) > DateTime.Now)
				{
					//this.SetIdentity(ssoValues[0]);			
					return ssoValues[0];
				}
				else
				{
					if( ssoValues.Length >= 3)
					{
						return ssoValues[2];
					}
					else
					{
						return "";
					}
				}
			}
		}

		/// <summary>
		/// 保存凭证，已用于以后的会话
		/// </summary>
		/// <param name="identity">已验证的身份标识</param>
		public void SetIdentity( string identity)
		{
			if( identity == null)
				HttpContext.Current.Response.Cookies["SSOIdentity"].Value = "";
			else
				HttpContext.Current.Response.Cookies["SSOIdentity"].Value = this.Encode(identity + '|' + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
		}

		/// <summary>
		/// 保存凭证，已用于以后的会话
		/// </summary>
		/// <param name="identity">已验证的身份标识</param>
		/// <param name="identityName">身份昵称</param>
		public void SetIdentity( string identity, string identityName)
		{
			if( identity == null)
				HttpContext.Current.Response.Cookies["SSOIdentity"].Value = "";
			else
				HttpContext.Current.Response.Cookies["SSOIdentity"].Value = this.Encode(identity + '|' + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + '|' + identityName);
		}

		/// <summary>
		/// 获取当前凭证的详细信息
		/// </summary>
		/// <returns></returns>
		public Ticket GetCurrentTicket()
		{
			string clientID = this.GetCurrentClientID();
			if( clientID == "")
			{
				return null;
			}

			string sign = this.GenSignKey(clientID);
			try
			{
				using( SSO s = new SSO())
				{
					string result = s.GetTicket(clientID, sign);
					if( result == "")
						return null;
					else
						return new Ticket(result);
				}
			}
			catch{}

			return null;
		}

		/// <summary>
		/// 强制生成凭证信息（自定义验证程序，如通行证）
		/// </summary>
		/// <param name="userID"></param>
		public void MakeTicket( int userID)
		{
			string clientID = this.GetCurrentClientID();
			if( clientID == "")
			{
				return;
			}

			string sign = this.GenSignKey(clientID);
			try
			{
				using( SSO s = new SSO())
				{
					s.MakeTicket(clientID, sign, HttpContext.Current.Request.UserHostAddress, this.SystemID, userID);	
				}

				this.SetIdentity(userID.ToString());
			}
			catch//(Exception ex)
			{}
		}

		/// <summary>
		/// 登陆
		/// </summary>
		/// <param name="identity">身份标识</param>
		/// <param name="method">登陆方式（1：通行证，2：域名，3：email）</param>
		/// <param name="password">密码</param>
		/// <returns>验证成功后生成的凭证，如果验证失败，返回null</returns>
		public Ticket SignIn(string identity, int method, string password)
		{
			string clientID = this.GetCurrentClientID();
			if( clientID == "")
			{
				return null;
			}

			string sign = this.GenSignKey(clientID);
			try
			{
				using( SSO s = new SSO())
				{
					string result = s.SignIn(clientID, sign, HttpContext.Current.Request.UserHostAddress, this.SystemID, identity, method, password);
					if( result == "")
						return null;
					else
						return new Ticket(result);
				}
			}
			catch{}

			return null;

		}

		/// <summary>
		/// 验证用户
		/// </summary>
		/// <param name="identity">身份标识</param>
		/// <param name="method">登陆方式（1：通行证，2：域名，3：email）</param>
		/// <param name="password">密码</param>
		/// <returns>验证成功后生成的凭证，如果验证失败，返回null</returns>
		public bool CheckLogin(string identity, int method, string password)
		{
			string clientID = Web.WebAgent.NewKey();

			string sign = this.GenSignKey(clientID);
			try
			{
				using( SSO s = new SSO())
				{
					string result = s.SignIn(clientID, sign, HttpContext.Current.Request.UserHostAddress, this.SystemID, identity, method, password);
					return result != "";
				}
			}
			catch{}

			return false;
		}


		/// <summary>
		/// 验证用户
		/// </summary>
		/// <param name="identity"></param>
		/// <param name="method"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public Ticket CheckLoginTicket(string identity, int method, string password)
		{
			string clientID = Web.WebAgent.NewKey();

			string sign = this.GenSignKey(clientID);
			try
			{
				using( SSO s = new SSO())
				{
					string result = s.SignIn(clientID, sign, HttpContext.Current.Request.UserHostAddress, this.SystemID, identity, method, password);
					return new Ticket(result);
				}
			}
#if(DEBUG)
			catch(Exception ex){ throw ex;}
#else
			catch{}
			return null;
#endif		
		}


		/// <summary>
		/// 注销当前登陆
		/// </summary>
		public void SignOut()
		{
			this.SetIdentity(null);

			string clientID = this.GetCurrentClientID();
			if( clientID == "")
			{
				return;
			}

			string sign = this.GenSignKey(clientID);
			try
			{
				using( SSO s = new SSO())
				{
					s.SignOut( clientID, sign);
				}
			}
			catch{}
		}

		/// <summary>
		/// 获取当前SSO客户端标识
		/// </summary>
		/// <returns></returns>
		public string GetCurrentClientID()
		{
			if( HttpContext.Current.Request.Browser.Cookies == false || HttpContext.Current.Request.Cookies["SSOClientID"] == null)
				return "";
			else
				return HttpContext.Current.Request.Cookies["SSOClientID"].Value;
		}

		/// <summary>
		/// 保存SSO返回的客户端标识
		/// </summary>
		/// <param name="clientID"></param>
		public void SaveClientID(string clientID)
		{
			HttpContext.Current.Response.Cookies["SSOClientID"].Value = clientID;
		}

		string _publicKey = "";
		/// <summary>
		/// 生成与SSO服务器交互的密匙
		/// </summary>
		/// <param name="clientID">当前SSO客户端标识</param>
		/// <returns></returns>
		string GenSignKey(string clientID)
		{
			if( _publicKey == "")
			{
				_publicKey = System.Configuration.ConfigurationSettings.AppSettings["PublicKey"];
			}
			return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(clientID + _publicKey, "MD5");
		}

		string _ssoPage = "";
		/// <summary>
		/// 获取SSO服务器握手页面地址
		/// </summary>
		public string SSOPage
		{
			get
			{
				if(_ssoPage == "")
				{
					_ssoPage = System.Configuration.ConfigurationSettings.AppSettings["PassportPage"];
				}
				return _ssoPage;
			}
		}

		string _systemID = "0";
		/// <summary>
		/// 获取当前SSO子系统编号
		/// </summary>
		public string SystemID
		{
			get
			{
				if(_systemID == "")
				{
					_systemID = System.Configuration.ConfigurationSettings.AppSettings["SystemID"];
				}
				return _systemID;
			}
		}

		int _timeout = 60;
		/// <summary>
		/// 凭证会话闲置时间
		/// </summary>
		public int Timeout
		{
			get{return _timeout;}
		}

		/// <summary>
		/// 编码
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public string Encode( string input)
		{
			//string code = System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(input));
			//code = code.Replace('=','~');
			//return code;
			//return HttpUtility.UrlEncode(input);
			return HttpUtility.UrlEncode(input);
		}

		/// <summary>
		/// 解码
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public string Decode( string input)
		{
			//input = input.Replace('~', '=');
			//string code = System.Text.Encoding.ASCII.GetString(System.Convert.FromBase64String(input));
			//return code;
			//return HttpUtility.UrlDecode(input);
			return HttpUtility.UrlDecode(input);
		}

		public static SSOAgent GetAgent()
		{
			return Nested.instance;
		}
		class Nested
		{
			static Nested(){}
			internal static readonly SSOAgent instance = new SSOAgent();
		}
	}
}
