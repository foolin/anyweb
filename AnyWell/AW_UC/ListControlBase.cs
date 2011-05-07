using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Web.UI;

namespace AnyWell.AW_UC
{
    public abstract class ListControlBase : ControlBase
    {
        private string _order;
        /// <summary>
        /// 获取或设置额外排序条件
        /// </summary>
        [Description( "设置额外排序条件" )]
        public virtual string Order
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

        private int _topCount = 0;
        /// <summary>
        /// 获取或设置返回数据条数
        /// </summary>
        [Description( "设置返回数据条数" ), DefaultValue( 0 )]
        public virtual int TopCount
        {
            get
            {
                return _topCount;
            }
            set
            {
                _topCount = value;
            }
        }

        private string _where;
        /// <summary>
        /// 获取或设置额外检索条件
        /// </summary>
        [Description( "设置额外检索条件" )]
        public virtual string Where
        {
            get
            {
                return _where;
            }
            set
            {
                _where = value;
            }
        }
    }
}
