using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Studio.Array;
using System.Collections;

namespace AnyWeb.AW
{
    /// <summary>
    ///菜单项对象
    /// </summary>
    public class DropMenuItem
    {
        public DropMenuItem()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _url;
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
            }
        }

        private string _target = "";
        /// <summary>
        /// 链接目标
        /// </summary>
        public string Target
        {
            get { return _target; }
            set { _target = value; }
        }

        private string _name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private ArrayList _children;
        /// <summary>
        /// 下级列表
        /// </summary>
        public ArrayList Children
        {
            get { return _children; }
            set { _children = value; }
        }

        private DropMenuItem _parent;
        /// <summary>
        /// 上级
        /// </summary>
        public DropMenuItem Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        private int _depth;
        /// <summary>
        /// 当前级别
        /// </summary>
        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        private int _function;
        /// <summary>
        /// 操作级别，通常1表示只读，2表示可修改
        /// </summary>
        public int Function
        {
            get { return _function; }
            set { _function = value; }
        }

        private int _module;
        /// <summary>
        /// 所属模块编号
        /// </summary>
        public int Module
        {
            get { return _module; }
            set { _module = value; }
        }

        private int _sort;
        /// <summary>
        /// 排列顺序
        /// </summary>
        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        private int _type;
        /// <summary>
        /// 项目类别，通常1表示普通，2表示分隔符，3表示内部操作，菜单不显示，4表示快捷操作
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _icon;
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        private string _shortkey;
        /// <summary>
        /// 快捷键
        /// </summary>
        public string ShortKey
        {
            get { return _shortkey; }
            set { _shortkey = value; }
        }

        public string Permission
        {
            get { return this.Module.ToString() + '-' + this.Function.ToString(); }
        }
    }
}
