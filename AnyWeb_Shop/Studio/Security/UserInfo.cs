using System;
using System.Text;

using Studio.Array;

namespace Studio.Security
{
	/// <summary>
	/// AnyPͨ��֤��Ϣ
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
		/// ͨ��֤��
		/// </summary>
		public int UserID
		{
			get{return _userID;}
			set{_userID = value;}
		}

		string _userName;
		/// <summary>
		/// �ǳ�
		/// </summary>
		public string UserName
		{
			get{return _userName;}
			set{_userName = value;}
		}

		string _email;
		/// <summary>
		/// ��������
		/// </summary>
		public string Email
		{
			get{return _email;}
			set{_email = value;}
		}

		string _domain;
		/// <summary>
		/// ����
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
