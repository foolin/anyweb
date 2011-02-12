using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;

using Studio.Web;

using AnyWell.AW_DL;

namespace AnyWell.AW_UC
{
    /// <summary>
    /// 单条数据控件基类，根据Field获取单字段值或根据ItemTemplate展示一条数据的多个值
    /// </summary>
    public abstract class ItemControlBase : ControlBase
    {
        private string _field;
        /// <summary>
        /// 要获取数据的字段名
        /// </summary>
        public virtual string Field
        {
            get { return _field; }
            set { _field = value; }
        }


        private int _recID;
        /// <summary>
        /// 数据项ID
        /// </summary>
        public virtual int RecID
        {
            get { return _recID; }
            set { _recID = value; }
        }

        private string  _name;
        /// <summary>
        /// 数据项名称,如站点名称,栏目名称
        /// </summary>
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        private int _len = 0;
        /// <summary>
        /// 显示单属性字数(仅适合字符型)
        /// </summary>
        public virtual int Len
        {
            get { return _len; }
            set { _len = value; }
        }

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

        protected abstract Dao_Base Dao { get; }
        protected abstract object GetItemObject();

        protected override object GetDataObject()
        {
            if (string.IsNullOrEmpty(this.Field) == false) //取单属性
            {
                if (string.IsNullOrEmpty(this.Name) && (this.Field.ToLower().StartsWith("fd") == true || this.Field.ToLower().StartsWith("extproperties[fdext") == true))//根据ID取数据库字段
                {
                    this.Field = this.Field.Replace("ExtProperties[", "").Replace("]", "");
                    object result = Dao.funcGetField(this.RecID, this.Field);
                    //Oracle如果内容字段是Text的话，需要进行转换
                    if (result != null && result.GetType() == Type.GetType("System.Byte[]"))
                    {
                        try
                        {
                            result = Encoding.Default.GetString((byte[])result);
                        }
                        catch { }
                    }
                    if (this.Len > 0 && result != null && result is string)
                    {
                        return WebAgent.GetLeft((string)result, this.Len, false);
                    }
                    else
                    {
                        return result;
                    }
                }
                else //取属性
                {
                    object obj = this.GetItemObject();
                    if (obj == null)
                    {
                        return null;
                    }

                    PropertyInfo property = obj.GetType().GetProperty(this.Field);
                    if (property != null)
                    {
                        return property.GetValue(obj, null);
                    }
                    else
                    {
                        property = obj.GetType().GetProperty("ExtProperties"); //读取扩展字段属性
                        if (property != null)
                        {
                            Hashtable ht = (Hashtable)property.GetValue(obj, null);
                            if (ht != null)
                            {
                                Match m = Regex.Match(this.Field, "(?<=ExtProperties\\[).+?(?=\\])", RegexOptions.IgnoreCase);
                                if (m.Success)
                                {
                                    return ht[m.Value];
                                }
                            }
                        }
                        return null;
                    }
                }
            }
            else
            {
                return this.GetItemObject();
            }
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
