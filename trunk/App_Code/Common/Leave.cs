using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace AnyP.BizPortal.Common
{
	/// <summary>
	/// 留言信息
	/// </summary>
	public class Leave
	{
		public Leave()
		{
		}
		
		public Leave(DataRow r)
		{
			MsgID = (int)r["MsgID"];
			HostID = (int)r["HostID"];
			ComID = (int)r["ComID"];
			UserName = (string)r["UserName"];
			IP = (string)r["IP"];
			CreateAt = (DateTime)r["CreateAt"];
			Message = (string)r["Message"];
			Deleted = (bool)r["Deleted"];
			Revert = (string)r["Revert"];
			RevertAt = (DateTime)r["RevertAt"];
			Displayed = (bool)r["Displayed"];
			Email = (string)r["Email"];
			Mobile = (string)r["Mobile"];
			Area = (string)r["Area"];
		}

		private int _MsgID;
		/// <summary>
		/// 留言编号
		/// </summary>
		public int MsgID
		{
			get { return _MsgID; }
			set { _MsgID = value; }
		}
		
		private int _HostID;
		/// <summary>
		/// 站长编号
		/// </summary>
		public int HostID
		{
			get { return _HostID; }
			set { _HostID = value;}
		}
		
		private int _ComID;
		/// <summary>
		/// 留言者公司编号
		/// </summary>
		public int ComID
		{
			get { return _ComID; }
			set { _ComID = value; }
		}
		
		private string _UserName;
		/// <summary>
		/// 留言者昵称
		/// </summary>
		public string UserName
		{
			get { return _UserName; }
			set { _UserName = value; }
		}
		
		private string _IP;
		/// <summary>
		/// 留言者IP
		/// </summary>
		public string IP
		{
			get { return _IP; }
			set { _IP = value; }
		}
		
		private DateTime _CreateAt;
		/// <summary>
		/// 留言时间
		/// </summary>
		public DateTime CreateAt
		{
			get { return _CreateAt; }
			set { _CreateAt = value; }
		}
		
		private string _Message;
		/// <summary>
		/// 留言内容
		/// </summary>
		public string Message
		{
			get { return _Message; }
			set { _Message = value; }
		}
		
		private bool _Deleted;
		/// <summary>
		/// 留言已删除
		/// </summary>
		public bool Deleted
		{
			get { return _Deleted; }
			set { _Deleted = value; }
		}
		
		private string _Revert;
		/// <summary>
		/// 内容回复
		/// </summary>
		public string Revert
		{
			get { return _Revert; }
			set { _Revert = value; }
		}
		
		private DateTime _RevertAt;
		/// <summary>
		/// 留言时间
		/// </summary>
		public DateTime RevertAt
		{
			get { return _RevertAt; }
			set { _RevertAt = value; }
		}
		
		private bool _Displayed;
		/// <summary>
		/// 是否显示
		/// </summary>
		public bool Displayed
		{
			get { return _Displayed; }
			set { _Displayed = value; }
		}
		
		private string _Email;
		/// <summary>
		/// 留言Email
		/// </summary>
		public string Email
		{
			get { return _Email; }
			set { _Email = value; }
		}
		
		private string _Mobile;
		/// <summary>
		/// 留言手机号码
		/// </summary>
		public string Mobile
		{
			get { return _Mobile; }
			set { _Mobile = value; }
		}
		
		private string _Area;
		/// <summary>
		/// 留言者区域
		/// </summary>
		public string Area
		{
			get { return _Area; }
			set { _Area = value; }
		}

	}
}