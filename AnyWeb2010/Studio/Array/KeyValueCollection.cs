using System;
using System.Collections;

namespace Studio.Array
{
	/// <summary>
	/// Name:键值集合
	/// Description:实现对"a=1&b=2&c=3"字符串的解释
	/// Author:谢康
	/// CreateDate:2005-07-20
	/// </summary>
	public class KeyValueCollection : CollectionBase
	{
		public void Add(string k, string v)
		{
			List.Add(new KeyValueData(k, v));
		}

		/// <summary>
		/// 从字符串生成集合
		/// </summary>
		/// <param name="str">形如"a=1&b=2&c=3"</param>
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
		/// 对集合生成字符串,形如"a=1&b=2&c=3"
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
		/// 实现按键查找的索引器
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
		/// 内部键值对象
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
