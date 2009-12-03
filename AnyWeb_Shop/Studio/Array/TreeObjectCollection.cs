using System;

namespace Studio.Array
{
	/// <summary>
	/// 树形对象集合
	/// </summary>
	public class TreeObjectCollection : Collection
	{
		public void Add(TreeObject obj)
		{
			obj.MyCollection = this;
			List.Add(obj);
		}

		public void Insert(int index, TreeObject obj)
		{
			List.Insert(index, obj);
		}

		public TreeObject this[int i]
		{
			get{return (TreeObject)List[i];}
		}

		public TreeObject this[string id]
		{
			get
			{
				for(int i = 0;i<List.Count;i++)
				{
					if(this[i].ID == id)
					{
						return this[i];
					}
				}
				return null;
			}
		}
	}
}
