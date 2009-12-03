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
	/// ͳһ��֤����
	/// </summary>
	public class SSOAgent
	{
		/// <summary>
		/// ��SSO Server����,ͨ����Session_Start����ʱ
		/// </summary>
		/// <param name="backUrl">���ر�ϵͳ��Url</param>
		/// <param name="loginUrl">��ϵͳ�ĵ�½����Url</param>
		public void SayHello(string backUrl, string loginUrl)
		{
			//��Web���񲻲���
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
		/// ����POST��ʽת����һ��ҳ��
		/// </summary>
		/// <param name="action">Ŀ��ҳ��</param>
		/// <param name="datas">��Ҫ���ݵ����ݼ�</param>
		public void TransPageByPost( string action, NameValueCollection datas)
		{
			HttpResponse response = HttpContext.Current.Response;
			HttpRequest request = HttpContext.Current.Request;
			if( request.HttpMethod == "POST")					//����ҳ���õ�POST����һ�𴫵�
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
		/// ����һ��HtmlForm�����贫�ݵ���Ϣ����HttpInputHidden��
		/// </summary>
		/// <param name="idx">Form��ţ����ֶ��Form</param>
		/// <param name="action">Ŀ���ַ</param>
		/// <param name="target">Ŀ�괰��</param>
		/// <param name="datas">�贫�ݵ����ݼ���</param>
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
		/// �����������
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
		/// �ж��Ƿ��½
		/// </summary>
		/// <returns></returns>
		public bool IsAuthenticated()
		{
			return this.GetIdentity() != "";
		}

		/// <summary>
		/// ��ȡ��ǰ��½��ƾ֤��Ϣ���Զ����¹���ʱ��
		/// </summary>
		/// <returns>����֤����ݱ�ʶ</returns>
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
		/// ��ȡ��ǰ��½��ʱ��
		/// </summary>
		/// <returns>��½��ʱ��</returns>
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
		/// ��ȡ��ǰ��½��ƾ֤��Ϣ�ǳ�
		/// </summary>
		/// <returns>����֤����ݱ�ʶ���ǳ�</returns>
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
		/// ����ƾ֤���������Ժ�ĻỰ
		/// </summary>
		/// <param name="identity">����֤����ݱ�ʶ</param>
		public void SetIdentity( string identity)
		{
			if( identity == null)
				HttpContext.Current.Response.Cookies["SSOIdentity"].Value = "";
			else
				HttpContext.Current.Response.Cookies["SSOIdentity"].Value = this.Encode(identity + '|' + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
		}

		/// <summary>
		/// ����ƾ֤���������Ժ�ĻỰ
		/// </summary>
		/// <param name="identity">����֤����ݱ�ʶ</param>
		/// <param name="identityName">����ǳ�</param>
		public void SetIdentity( string identity, string identityName)
		{
			if( identity == null)
				HttpContext.Current.Response.Cookies["SSOIdentity"].Value = "";
			else
				HttpContext.Current.Response.Cookies["SSOIdentity"].Value = this.Encode(identity + '|' + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + '|' + identityName);
		}

		/// <summary>
		/// ��ȡ��ǰƾ֤����ϸ��Ϣ
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
		/// ǿ������ƾ֤��Ϣ���Զ�����֤������ͨ��֤��
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
		/// ��½
		/// </summary>
		/// <param name="identity">��ݱ�ʶ</param>
		/// <param name="method">��½��ʽ��1��ͨ��֤��2��������3��email��</param>
		/// <param name="password">����</param>
		/// <returns>��֤�ɹ������ɵ�ƾ֤�������֤ʧ�ܣ�����null</returns>
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
		/// ��֤�û�
		/// </summary>
		/// <param name="identity">��ݱ�ʶ</param>
		/// <param name="method">��½��ʽ��1��ͨ��֤��2��������3��email��</param>
		/// <param name="password">����</param>
		/// <returns>��֤�ɹ������ɵ�ƾ֤�������֤ʧ�ܣ�����null</returns>
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
		/// ��֤�û�
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
		/// ע����ǰ��½
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
		/// ��ȡ��ǰSSO�ͻ��˱�ʶ
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
		/// ����SSO���صĿͻ��˱�ʶ
		/// </summary>
		/// <param name="clientID"></param>
		public void SaveClientID(string clientID)
		{
			HttpContext.Current.Response.Cookies["SSOClientID"].Value = clientID;
		}

		string _publicKey = "";
		/// <summary>
		/// ������SSO�������������ܳ�
		/// </summary>
		/// <param name="clientID">��ǰSSO�ͻ��˱�ʶ</param>
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
		/// ��ȡSSO����������ҳ���ַ
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
		/// ��ȡ��ǰSSO��ϵͳ���
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
		/// ƾ֤�Ự����ʱ��
		/// </summary>
		public int Timeout
		{
			get{return _timeout;}
		}

		/// <summary>
		/// ����
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
		/// ����
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
