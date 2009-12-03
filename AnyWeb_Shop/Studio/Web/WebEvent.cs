using System;
using System.Text;

namespace Studio.Web
{
	/// <summary>
	/// Web�¼�����
	/// </summary>
	public class WebEvent
	{
		public WebEvent()
		{
		}

		//����ַ�������
		public WebEvent(string data)
		{
			string[] ds = data.Split('|');
			if( ds.Length >= 9)
			{
				_raiseAt	= DateTime.Parse(ds[0], System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.AdjustToUniversal);
				_eventID	= int.Parse(ds[1]);
				_type		= int.Parse(ds[2]);
				_userID		= int.Parse(ds[3]);
				_userID2	= int.Parse(ds[4]);
				_system		= ds[5];
				_fromIP		= ds[6];
				_fromAddr	= ds[7];
				_args		= ds[8].Replace('`','|');
			}
		}

		//����ṹ
		public WebEvent( int eventID,
			int eventType,
			int userID,
			int userID2,
			string fromSystem,
			string fromIP,
			string fromAddress,
			string args)
		{
			_raiseAt	= DateTime.Now;
			_eventID	= eventID;
			_type		= eventType;
			_userID		= userID;
			_userID2	= userID2;
			_system		= fromSystem;
			_fromIP		= fromIP;
			_fromAddr	= fromAddress;
			_args		= args;
		}

		int _eventID;
		/// <summary>
		/// �¼����
		/// </summary>
		public int EventID
		{
			get{return _eventID;}
			set{_eventID = value;}
		}

		DateTime _raiseAt;
		/// <summary>
		/// �¼�����ʱ��
		/// </summary>
		public DateTime RaiseAt
		{
			get{return _raiseAt;}
			set{_raiseAt = value;}
		}

		int _type;
		/// <summary>
		/// �¼�����
		/// </summary>
		public int Type
		{
			get{return _type;}
			set{_type = value;}
		}

		string _system;
		/// <summary>
		/// �¼�Դϵͳ
		/// </summary>
		public string FromSystem
		{
			get{return _system;}
			set{_system = value;}
		}

		int _userID;
		/// <summary>
		/// ֱ���û�ID
		/// </summary>
		public int UserID
		{
			get{return _userID;}
			set{_userID = value;}
		}

		int _userID2;
		/// <summary>
		/// ���������û�ID������Ϊ0��
		/// </summary>
		public int UserID2
		{
			get{return _userID2;}
			set{_userID2 = value;}
		}

		string _fromIP;
		/// <summary>
		/// �¼�ԴIP
		/// </summary>
		public string FromIP
		{
			get{return _fromIP;}
			set{_fromIP = value;}
		}

		string _fromAddr;
		/// <summary>
		/// �¼�Դ��ַ
		/// </summary>
		public string FromAddress
		{
			get{return _fromAddr;}
			set{_fromAddr = value;}
		}

		string _args;
		/// <summary>
		/// �¼�����
		/// </summary>
		public string Args
		{
			get{return _args;}
			set{_args = value;}
		}

		/// <summary>
		/// ������ַ���
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return new StringBuilder( DateTime.Now.ToString("r"))
				.Append('|')
				.Append(_eventID.ToString())
				.Append('|')
				.Append(_type.ToString())
				.Append('|')
				.Append(_userID)
				.Append('|')
				.Append(_userID2)
				.Append('|')
				.Append(_system)
				.Append('|')
				.Append(_fromIP)
				.Append('|')
				.Append(_fromAddr)
				.Append('|')
				.Append(_args.Replace("`","").Replace('|','`')).ToString();
		}
	}
}
