using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

/// <summary>
/// 菜单(页面)项目
/// </summary>
namespace AnyP.BizBlog.Admin
{
    public class XMenuItem
    {
        public XMenuItem()
        {

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
                _fileName = value.ToLower();

                if (_fileName.IndexOf('?') > 0)
                {
                    _fileName = _fileName.Substring(0, _fileName.IndexOf('?'));
                }
            }
        }

        private string _fileName;
        /// <summary>
        /// 页面文件名称
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }


        private string _name;
        /// <summary>
        /// 页面名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _desc;
        /// <summary>
        /// 页面描述
        /// </summary>
        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }

        private ArrayList _children;
        /// <summary>
        /// 下级页面列表
        /// </summary>
        public ArrayList Children
        {
            get { return _children; }
            set { _children = value; }
        }

        private XMenuItem _parent;
        /// <summary>
        /// 上级页面
        /// </summary>
        public XMenuItem Parent
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

        private bool _selected;
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
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

        private bool _visible;
        /// <summary>
        /// 是否可见菜单项目
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        private int _type;
        /// <summary>
        /// 项目类别，通常1表示普通，2表示附加，附加项目可重复
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

        public string Permission
        {
            get { return this.Module.ToString() + '-' + this.Function.ToString(); }
        }
    }
}
