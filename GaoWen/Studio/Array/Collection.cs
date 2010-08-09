using System;
using System.Collections;

namespace Studio.Array
{
	/// <summary>
	/// Name:�Զ��弯�ϻ���
	/// Description:ʵ�ֳ�Ա��������Ȼ�������
	/// Author:л��
	/// CreateDate:2005-07-20
	/// </summary>
	public class Collection : CollectionBase
	{
		/// <summary>
		/// ˳������
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
		/// ��������
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
		/// ��ת
		/// </summary>
		public void Reverse()
		{
			InnerList.Reverse();
		}

		/// <summary>
		/// ��ȡ��ǰ����λ�õ���һ������
		/// </summary>
		/// <param name="me">��ǰ�����Լ�</param>
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
		/// ��ȡ��ǰ����λ�õ���һ������
		/// </summary>
		/// <param name="me">��ǰ�����Լ�</param>
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
		/// ��ȡ�¶����λ��
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

			#region IComparable ��Ա

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
