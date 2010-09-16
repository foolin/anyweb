using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace AnyWell.AW_UC
{
    public abstract class ItemControlBase : ControlBase
    {
        private ItemObjectType _itemType = ItemObjectType.Current;
        /// <summary>
        /// 设置或获取数据项类型
        /// </summary>
        [Description("设置数据项类型"), DefaultValue(ItemObjectType.Current)]
        public virtual ItemObjectType ItemType
        {
            get { return _itemType; }
            set { _itemType = value; }
        }

        /// <summary>
        /// 获取数据项内容
        /// </summary>
        /// <returns></returns>
        protected abstract object GetItemObject();

        protected override object GetDataObject()
        {
            return this.GetItemObject();
        }
    }

    public enum ItemObjectType : int
    {
        Current = 1,
        Previous = 2,
        Next = 3,
        Parent = 4
    }
}
