using System;
using System.Collections;
using System.Reflection;

namespace Studio.Array
{
	/// <summary>
	/// 封装具有ID的对象,并实现排序
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
	

		#region IComparable 成员

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

	public class IdCompare : IComparer
	{
		#region IComparer 成员

		public int Compare(object x, object y)
		{
			if (x == null || y == null) return 0;

			int id2 = ((IdObject)y).ID;
            
			if (((IdObject)x).ID == id2) return 0;
			if (((IdObject)x).ID < id2) return -1;
			if (((IdObject)x).ID > id2) return 1;
			return 0;		
		}

		#endregion

	}

    public class StringCompare : IComparer
    {
        #region IComparer 成员

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