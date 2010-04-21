using System;

namespace Studio.Array
{
	/// <summary>
	/// Name:可排序的接口
	/// Description:可排序的接口
	/// Author:谢康
	/// CreateDate:2005-07-20
	/// </summary>
	public interface ISortable
	{
		short Order
		{
			get;
			set;
		}

		string ObjectID
		{
			get;
		}
	}
}
