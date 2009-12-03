using System;
using System.Collections;

namespace Studio.Array
{
	/// <summary>
	/// 扩展ArrayList对象,实现排序和查找
	/// </summary>
	public class ObjectList : ArrayList
	{
		bool _sorted = false;
		ArrayList _innerList = null;

        public ObjectList(ObjectList c)
            : base(c)
        {
            _innerList = new ArrayList(c);
        }

		public ObjectList()
		{
            _innerList = new ArrayList();
		}

		public override int Add(object obj)
		{
			_innerList.Add(obj);
            _sorted = false;
			return base.Add (obj);
		}

		public override void Remove(object obj)
		{
			_innerList.Remove(obj);
			base.Remove (obj);
		}

        public override void Clear()
        {
            _innerList.Clear();
            base.Clear();
        }

        public override void Insert(int index, object value)
        {
            _innerList.Insert(index, value);
            _sorted = false;
            base.Insert(index, value);
        }

		public virtual object GetById( int id)
		{
			if( this.Count == 0 || this[0] is IdObject == false)
			{
				return null;
			}
			if( _sorted == false)
			{
				IdCompare ic = new IdCompare();
				_innerList.Sort(ic);
				_sorted = true;
			}

			int idx = GetIdx(0, this.Count - 1, id);
			if( idx == -1)
				return null;
			else
				return _innerList[idx];

		}

		int GetIdx(int a, int b, int id)
		{
			int m;
			if( a == b)
			{
				if( ((IdObject)_innerList[a]).ID == id)
					return a;
				else
					return -1;
			}
			else
			{
				m = (a + b)/2;
				if( id < ((IdObject)_innerList[m]).ID) return GetIdx( a, m, id);
				if( id > ((IdObject)_innerList[m]).ID) return GetIdx( m + 1, b, id);
				//if( id == ((IdObject)_innerList[m]).ID) return GetIdx( m , m , id);
				return m;
			}
		}

		/// <summary>
		/// 获取当前对象位置的下一个对象
		/// </summary>
		/// <param name="me">当前对象自己</param>
		public virtual object GetNextItem(IdObject me)
		{
			int idx = 0;
			IEnumerator dic = this.GetEnumerator();
			while(dic.MoveNext())
			{
				if(((IdObject)dic.Current).ID == me.ID)
				{
					break;
				}
				idx ++;
			}

			if( idx < this.Count -1)
				return this[ idx + 1];
			else
				return null;
		}

		/// <summary>
		/// 获取当前对象位置的上一个对象
		/// </summary>
		/// <param name="me">当前对象自己</param>
		public virtual object GetPreviousItem(IdObject me)
		{
			int idx = 0;

			IEnumerator dic = this.GetEnumerator();
			while(dic.MoveNext())
			{
				if(((IdObject)dic.Current).ID == me.ID)
				{					
					break;
				}
				idx ++;
			}
			
			if( idx > 0)
			{
				return this[idx - 1];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获取新对象的位置
		/// </summary>
		public virtual int GetNewOrder()
		{
			if( this.Count < 2)
				return this.Count + 1;
			else
			{
				if( ((IdObject)this[0]).Order > ((IdObject)this[1]).Order)
					return ((IdObject)this[0]).Order + 1;
				else
					return (((IdObject)this[this.Count - 1]).Order + 1);
			}		

		}

	}
}
