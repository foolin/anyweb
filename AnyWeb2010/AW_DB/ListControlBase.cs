using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Reflection;

using AnyWeb.AW_DL;

namespace FortuneAge.AW_UC
{
    /// <summary>
    /// 多条数据控件基类，返回一个列表，类似Repeater控件用ItemTemplate绑定数据项
    /// </summary>
    public abstract class ListControlBase : ControlBase
    {
        int _topCount = 0;
        /// <summary>
        /// 获取或设置返回数据条数
        /// </summary>
        [Description("设置返回数据条数"), DefaultValue(0)]
        public virtual int TopCount
        {
            get { return _topCount; }
            set { _topCount = value; }
        }

        int _titleLen = 1000;
        /// <summary>
        /// 获取或设置文章标题长度
        /// </summary>
        [Description("设置文章标题长度"), DefaultValue(1000)]
        public virtual int TitleLen
        {
            get { return _titleLen; }
            set { _titleLen = value; }
        }

        string _where;
        /// <summary>
        /// 获取或设置额外检索条件
        /// </summary>
        [Description("设置额外检索条件")]
        public virtual string Where
        {
            get 
            {
                if (string.IsNullOrEmpty(_where) == false)
                {
                    //可获取当前对象的属性
                    string condReg = "@[\\w\\d]+";
                    Match m = Regex.Match(_where, condReg);
                    if (m.Success)
                    {
                        string propName = m.Value.Substring(1);
                        PropertyInfo property = (((IDataItemContainer)Parent).DataItem).GetType().GetProperty(propName);
                        string propValue = property == null ? "" : property.GetValue(((IDataItemContainer)Parent).DataItem, null).ToString();
                        _where = Regex.Replace(_where, condReg, propValue);
                    }
                    //替换系统变量
                    _where = ReplaceSystemArgs(_where);
                }
                return _where; 
            }
            set { _where = value; }
        }

        string _order;
        /// <summary>
        /// 获取或设置额外排序条件
        /// </summary>
        [Description("设置额外排序条件")]
        public virtual string Order
        {
            get { return _order; }
            set { _order = value; }
        }

        private int _startPos = 0;
        /// <summary>
        /// 获取或设置起始项序号
        /// </summary>
        [Description("设置起始项序号"), DefaultValue(0)]
        public virtual int StartPos
        {
            get { return _startPos; }
            set { _startPos = value; }
        }

        protected virtual string ReplaceSystemArgs(string text)
        {
            if(Context.Items.Contains("BUILD_SITEID"))
            {
                text = text.Replace("{SITEID}", ((int)Context.Items["BUILD_SITEID"]).ToString());
            }
            if (Context.Items.Contains("BUILD_SITENAME"))
            {
                text = text.Replace("{SITENAME}", (string)Context.Items["BUILD_SITENAME"]);
            }
            if (Context.Items.Contains("BUILD_COLUMNID"))
            {
                text = text.Replace("{COLUMNID}", ((int)Context.Items["BUILD_COLUMNID"]).ToString());
            }
            if (Context.Items.Contains("BUILD_COLUMNNAME"))
            {
                text = text.Replace("{COLUMNNAME}", (string)Context.Items["BUILD_COLUMNNAME"]);
            }
            return text;
        }
    }
}
