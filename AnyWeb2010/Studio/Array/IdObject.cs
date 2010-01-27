using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Studio.Array
{
	/// <summary>
	/// ��װ����ID�Ķ���,��ʵ������
	/// </summary>
	public class IdObject : IComparable
	{
		public IdObject()
		{
			
		}

		int _id;
		public int ID
		{
			get{return _id;}
			set{_id = value;}
		}

		int _order;
		public int Order
		{
			get
			{
				if( _order == 0)
					return _id;
				else
					return _order;
			}
			set{_order = value;}
		}
	

		#region IComparable ��Ա

		public int CompareTo(object obj)
		{
			if (obj == null) return 1;

			int compareOrder = ((IdObject)obj).Order;
            
			if (this.Order == compareOrder) return 0;
			if (this.Order < compareOrder) return -1;
			if (this.Order > compareOrder) return 1;
			return 0;		
		}

		#endregion
	}

    public class IdCompare<T> : IComparer<T> where T : IdObject
    {
        public int Compare(T x, T y)
        {
            if ((x != null) && (y != null))
            {
                int id2 = y.ID;
                if (x.ID == id2)
                {
                    return 0;
                }
                if (x.ID < id2)
                {
                    return -1;
                }
                if (x.ID > id2)
                {
                    return 1;
                }
            }
            return 0;
        }
    }

    public class StringCompare : IComparer
    {
        #region IComparer ��Ա

        string _attribute = "Name";

        public StringCompare(string attributeName)
        {
            _attribute = attributeName;
        }

        public int Compare(object x, object y)
        {
            string a = (string)x.GetType().GetProperty(_attribute).GetValue(x, null);
            string b = (string)y.GetType().GetProperty(_attribute).GetValue(y, null);
            return string.Compare(a, b, false);
        }

        #endregion
    }
}