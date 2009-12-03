using System;

namespace Studio.Array
{
	/// <summary>
	/// 树形结构对象
	/// </summary>
	public class TreeObject : ISortable
	{
		string _id;
		public string ID
		{
			get{return _id;}
			set{_id = value;}
		}

		string _name;
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		string _parentId;
		public string ParentID
		{
			get{return _parentId;}
			set{_parentId = value;}
		}

		public TreeObject Parent
		{
			get
			{
				if(this.ParentID != null && this.MyCollection != null)
				{
					return this.MyCollection[this.ParentID];
				}
				else
				{
					return null;
				}
			}
		}

		TreeObjectCollection _collection;
		/// <summary>
		/// 同一棵树的集合
		/// </summary>
		public TreeObjectCollection MyCollection
		{
			get{return _collection;}
			set{_collection = value;}
		}
		#region ISortable 成员
		short _order;
		public short Order
		{
			get
			{
				return _order;
			}
			set
			{
				_order = value;
			}
		}

		public string ObjectID
		{
			get{return this.ID;}
		}
		#endregion


		TreeObjectCollection _children;
		public TreeObjectCollection Children
		{
			get
			{
				if(_children == null)
				{
					_children = new TreeObjectCollection();
					foreach(TreeObject obj in this.MyCollection)
					{
						if(obj.ParentID == this.ID)
						{
							_children.Insert(_children.Count, obj);
						}
					}
					_children.Sort();
				}
				return _children;
			}
		}
	}
}
