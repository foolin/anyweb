using System;
using System.Collections;

namespace Studio.Array
{
	/// <summary>
	/// Name:��ֵ����
	/// Description:ʵ�ֶ�"a=1&b=2&c=3"�ַ����Ľ���
	/// Author:л��
	/// CreateDate:2005-07-20
	/// </summary>
	public class KeyValueCollection : CollectionBase
	{
		public void Add(string k, string v)
		{
			List.Add(new KeyValueData(k, v));
		}

		/// <summary>
		/// ���ַ������ɼ���
		/// </summary>
		/// <param name="str">����"a=1&b=2&c=3"</param>
		public void FromString(string str)
		{
			List.Clear();
			if(str == "")
			{
				return;
			}
			string[] ss = str.Split('&');
			foreach(string s in ss)
			{
                if (s.Trim().Length <= 1) continue;
                if (!s.Trim().Contains("=")) continue;
				this.Add(s.Substring(0, s.IndexOf('=')), s.Substring(s.IndexOf('=') + 1).Replace('~', '&').Replace('`', '='));
			}
		}

		/// <summary>
		/// �Լ��������ַ���,����"a=1&b=2&c=3"
		/// </summary>
		public override string ToString()
		{
			string s = "";
			IEnumerator dic = this.GetEnumerator();
			while(dic.MoveNext())
			{
				s += ((KeyValueData)dic.Current).Key + '=' + ((KeyValueData)dic.Current).Value.Replace('&', '~').Replace('=', '`') + '&';
			}
			if(s.Length > 0)
			{
				s = s.Remove(s.Length -1, 1);
			}
			return s;
		}

		/// <summary>
		/// ʵ�ְ������ҵ�������
		/// </summary>
		public string this[string key]
		{
			get
			{
				for(int i=0;i<List.Count;i++)
				{
					if(((KeyValueData)List[i]).Key == key)
					{
						return ((KeyValueData)List[i]).Value;
					}
				}
				return String.Empty;
			}
			set
			{
				for(int i=0;i<List.Count;i++)
				{
					if(((KeyValueData)List[i]).Key == key)
					{
						((KeyValueData)List[i]).Value = value;
						return;
					}
				}
				this.Add(key, value);
			}
		}

		/// <summary>
		/// �ڲ���ֵ����
		/// </summary>
		public class KeyValueData
		{
            public KeyValueData(string k, string v)
			{
				this.Key = k;
				this.Value = v;
			}
			string _key;
            public string Key
			{
				get{return _key;}
				set{_key = value;}
			}

			string _value;
            public string Value
			{
				get{return _value;}
				set{_value = value;}
			}
		}
	}
}
