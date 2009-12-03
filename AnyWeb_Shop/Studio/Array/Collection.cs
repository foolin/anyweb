using System;
using System.Collections;

namespace Studio.Array
{
	/// <summary>
	/// Name:自定义集合基类
	/// Description:实现成员对象排序等基本功能
	/// Author:谢康
	/// CreateDate:2005-07-20
	/// </summary>
	public class Collection : CollectionBase
	{
		/// <summary>
		/// 顺序排序
		/// </summary>
		public virtual void Sort()
		{
			ArrayList tempList = new ArrayList();
			for(int i = 0;i < this.List.Count; i ++)
			{
				tempList.Add(new SortObject((ISortable)List[i]));
			}
			tempList.Sort();
			List.Clear();
			for(int i = 0;i < tempList.Count; i ++)
			{
				List.Add(((SortObject)tempList[i]).Obj);
			}
		}

		/// <summary>
		/// 倒序排序
		/// </summary>
		public virtual void SortDesc()
		{
			ArrayList tempList = new ArrayList();
			for(int i = 0;i < this.List.Count; i ++)
			{
				tempList.Add(new SortObject((ISortable)List[i]));
			}
			tempList.Sort();
			tempList.Reverse();
			List.Clear();
			for(int i = 0;i < tempList.Count; i ++)
			{
				List.Add(((SortObject)tempList[i]).Obj);
			}
		}

		/// <summary>
		/// 反转
		/// </summary>
		public void Reverse()
		{
			InnerList.Reverse();
		}

		/// <summary>
		/// 获取当前对象位置的下一个对象
		/// </summary>
		/// <param name="me">当前对象自己</param>
		public virtual object GetNextItem(ISortable me)
		{
			int idx = 0;
			IEnumerator dic = List.GetEnumerator();
			while(dic.MoveNext())
			{
				if(((ISortable)dic.Current).ObjectID == me.ObjectID)
				{
					break;
				}
				idx ++;
			}

			if( idx < List.Count -1)
				return List[ idx + 1];
			else
				return null;
		}

		/// <summary>
		/// 获取当前对象位置的上一个对象
		/// </summary>
		/// <param name="me">当前对象自己</param>
		public virtual object GetPreviousItem(ISortable me)
		{
			int idx = 0;

			IEnumerator dic = List.GetEnumerator();
			while(dic.MoveNext())
			{
				if(((ISortable)dic.Current).ObjectID == me.ObjectID)
				{					
					break;
				}
				idx ++;
			}
			
			if( idx > 0)
			{
				return List[idx - 1];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获取新对象的位置
		/// </summary>
		public virtual short GetNewOrder()
		{
			if( List.Count < 2)
				return Convert.ToInt16(List.Count + 1);
			else
			{
				if( ((ISortable)List[0]).Order > ((ISortable)List[1]).Order)
					return Convert.ToInt16(((ISortable)List[0]).Order + 1);
				else
					return Convert.ToInt16(((ISortable)List[List.Count - 1]).Order + 1);
			}		

		}

		internal class SortObject : IComparable
		{
			public int Order;

			public ISortable Obj;

			internal SortObject(ISortable obj)
			{
				this.Order = obj.Order;
				this.Obj = obj;
			}

			#region IComparable 成员

			public int CompareTo(object obj)
			{
				if (obj == null) return 1;

				int compareOrder = ((SortObject)obj).Order;
            
				if (this.Order == compareOrder) return 0;
				if (this.Order < compareOrder) return -1;
				if (this.Order > compareOrder) return 1;
				return 0;			}

			#endregion
		}
	}
}
