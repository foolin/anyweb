using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    /// <summary>
    /// 组件实体
    /// </summary>
    public class Widget:IdObject
    {
        public  Widget() { }

        public  Widget(DataRow dr)
        {
            this.ID = (int)dr["WidgetID"];
            this._className = (string)dr["ClassName"];
            this._controlTag = (string)dr["ControlTag"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._controlDefine = (string)dr["ControlDefine"];
            this._icon = (string)dr["Icon"];
            this._isValid = (bool)dr["IsValid"];
            this._widgetName = (string)dr["WidgetName"];
            this._path = (string)dr["Path"];
            this._widgetType = (int)dr["WidgetType"];
            this._description = (string)dr["Description"];
        }

        private string _widgetName;
        /// <summary>
        /// 组件名称
        /// </summary>
        public string WidgetName
        {
            get { return _widgetName; }
            set { _widgetName = value; }
        }

        private DateTime _createAt;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }

        private bool _isValid;
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        private string _path;
        /// <summary>
        /// 组件路径
        /// </summary>
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        private string _className;
        /// <summary>
        /// 组件类名
        /// </summary>
        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }
        private int _widgetType;
        /// <summary>
        /// 组件类型 1-系统组件 2-侧边组件 3-内容组件
        /// </summary>
        public int WidgetType
        {
            get { return _widgetType; }
            set { _widgetType = value; }
        }

        private string _controlTag;
        /// <summary>
        /// 组件标签
        /// </summary>
        public string ControlTag
        {
            get { return _controlTag; }
            set { _controlTag = value; }
        }

        private string _controlDefine;
        /// <summary>
        /// 组件定义
        /// </summary>
        public string ControlDefine
        {
            get { return _controlDefine; }
            set { _controlDefine = value; }
        }

        private string _description;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _icon;
        /// <summary>
        /// 图片
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

    
    }

}
