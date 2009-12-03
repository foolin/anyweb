using System;
using System.Text;

using Studio.Array;

namespace Studio.Security
{
	/// <summary>
	/// AnyP通行证信息
	/// </summary>
	public class UserInfo
	{
		public UserInfo(){}

		public UserInfo(KeyValueCollection ks)
		{
			this.UserID		= int.Parse(ks["userid"]);
			this.DomainName	= ks["domainname"];
			this.Email			= ks["email"];
			this.UserName		= ks["username"];
		}

		int _userID;
		/// <summary>
		/// 通行证号
		/// </summary>
		public int UserID
		{
			get{return _userID;}
			set{_userID = value;}
		}

		string _userName;
		/// <summary>
		/// 昵称
		/// </summary>
		public string UserName
		{
			get{return _userName;}
			set{_userName = value;}
		}

		string _email;
		/// <summary>
		/// 电子邮箱
		/// </summary>
		public string Email
		{
			get{return _email;}
			set{_email = value;}
		}

		string _domain;
		/// <summary>
		/// 域名
		/// </summary>
		public string DomainName
		{
			get{return _domain;}
			set{_domain = value;}
		}

		public override string ToString()
		{
			return String.Format("userid={0}&username={1}&email={2}&domainname={3}",
				this.UserID,
				this.UserName.Replace('&', '~').Replace('=', '`').Replace("|",""),
				this.Email,
				this.DomainName);
		}
	}
}
