using System;
using System.Collections;

using Studio.Array;

namespace Studio.Security
{
	/// <summary>
	/// 登陆票据
	/// </summary>
	public class Ticket
	{		
		public Ticket()
		{
			this.Delegates = new ArrayList(3);
		}

		public Ticket( string token) : this()
		{
			string[] tokens = token.Split('|');
			KeyValueCollection ks = new KeyValueCollection();
			ks.FromString(tokens[0]);

			this.ClientID = ks["clientid"];
			this.SignInAt = DateTime.Parse(ks["signinat"]);
			this.ExpireAt = DateTime.Parse(ks["expireat"]);
			this.FromIP	  = ks["fromip"];
			this.FromSystemID = ks["fromsystem"];
			string delegates = ks["delegates"];
			if( delegates != "")
			{
				string[] deles = delegates.Split(';');
				foreach( string dele in deles)
				{
					this.Delegates.Add(dele);
				}
			}

			ks.FromString(tokens[1]);
			this.UserData = ks;
			this.User = new UserInfo(ks);
		}

		KeyValueCollection _data;
		public KeyValueCollection UserData
		{
			get{return _data;}
			set{_data = value;}
		}
		string _clientID;
		/// <summary>
		/// 客户端标识
		/// </summary>
		public string ClientID
		{
			get{return _clientID;}
			set{_clientID = value;}
		}

		string _fromIP = "";
		/// <summary>
		/// 登陆来源IP
		/// </summary>
		public string FromIP
		{
			get{return _fromIP;}
			set{_fromIP = value;}
		}

		string _fromSystemID = "0";
		/// <summary>
		/// 登陆来源系统编号
		/// </summary>
		public string FromSystemID
		{
			get{return _fromSystemID;}
			set{_fromSystemID = value;}
		}

		DateTime _signInAt;
		/// <summary>
		/// 登陆时间
		/// </summary>
		public DateTime SignInAt
		{
			get{return _signInAt;}
			set{_signInAt = value;}
		}

		DateTime _expireAt;
		/// <summary>
		/// 过期时间
		/// </summary>
		public DateTime ExpireAt
		{
			get{return _expireAt;}
			set{_expireAt = value;}
		}

		bool _authenticated = false;
		public bool Authenticated
		{
			get{return _authenticated;}
			set{_authenticated = value;}
		}

		ArrayList _delegates;
		public ArrayList Delegates
		{
			get{return _delegates;}
			set{_delegates = value;}
		}

		public string Identity
		{
			get{return this.User.UserID.ToString();}
		}

		public string IdentityName
		{
			get{return this.User.UserName;}
		}

		UserInfo _user;
		/// <summary>
		/// 用户信息
		/// </summary>
		public UserInfo User
		{
			get{return _user;}
			set{_user = value;}
		}

		public override string ToString()
		{
			string delegates = "";
			foreach( string dele in this.Delegates)
			{
				delegates += dele + ";";
			}
			if( delegates.Length > 0)
				delegates = delegates.Remove( delegates.Length - 1, 1);

			return String.Format("clientid={0}&signinat={1}&expireat={2}&fromip={3}&fromsystem={4}&delegates={5}|{6}",
				this.ClientID,
				this.SignInAt.ToString("yyyy-MM-dd HH:mm:ss"),
				this.ExpireAt.ToString("yyyy-MM-dd HH:mm:ss"),
				this.FromIP,
				this.FromSystemID,
				delegates,
				this.User.ToString());
		}
	}
}
