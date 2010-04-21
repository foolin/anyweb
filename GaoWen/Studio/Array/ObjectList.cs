using System;
using System.Collections;
using System.Collections.Generic;

namespace Studio.Array
{
	/// <summary>
	/// 扩展ArrayList对象,实现排序和查找
	/// </summary>
    public class ObjectList<T> : List<T> where T : IdObject
    {
        // Fields
        private List<T> _innerList;
        private bool _sorted;

        // Methods
        public ObjectList()
        {
            this._sorted = false;
            this._innerList = new List<T>();
        }

        public new void Add(T obj)
        {
            this._innerList.Add(obj);
            base.Add(obj);
        }

        public virtual T GetById(int id)
        {
            if (base.Count == 0)
            {
                return default(T);
            }
            if (!this._sorted)
            {
                IdCompare<T> ic = new IdCompare<T>();
                this._innerList.Sort(ic);
                this._sorted = true;
            }
            int idx = this.GetIdx(0, base.Count - 1, id);
            if (idx == -1)
            {
                return default(T);
            }
            return this._innerList[idx];
        }

        private int GetIdx(int a, int b, int id)
        {
            if (a == b)
            {
                if (this._innerList[a].ID == id)
                {
                    return a;
                }
                return -1;
            }
            int m = (a + b) / 2;
            if (id < this._innerList[m].ID)
            {
                return this.GetIdx(a, m, id);
            }
            if (id > this._innerList[m].ID)
            {
                return this.GetIdx(m + 1, b, id);
            }
            return m;
        }

        public virtual int GetNewOrder()
        {
            if (base.Count < 2)
            {
                return (base.Count + 1);
            }
            if (base[0].Order > base[1].Order)
            {
                return (base[0].Order + 1);
            }
            return (base[base.Count - 1].Order + 1);
        }

        public virtual T GetNextItem(IdObject me)
        {
            int idx = 0;
            IEnumerator dic = base.GetEnumerator();
            while (dic.MoveNext())
            {
                if (((IdObject)dic.Current).ID == me.ID)
                {
                    break;
                }
                idx++;
            }
            if (idx < (base.Count - 1))
            {
                return base[idx + 1];
            }
            return default(T);
        }

        public virtual T GetPreviousItem(IdObject me)
        {
            int idx = 0;
            IEnumerator dic = base.GetEnumerator();
            while (dic.MoveNext())
            {
                if (((IdObject)dic.Current).ID == me.ID)
                {
                    break;
                }
                idx++;
            }
            if (idx > 0)
            {
                return base[idx - 1];
            }
            return default(T);
        }

        public new void Remove(T obj)
        {
            this._innerList.Remove(obj);
            base.Remove(obj);
        }
    }
}
