using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AnyWeb.AnyWeb_DL
{
    public class Link
    {
        public Link()
        { }

        public Link(DataRow row)
        {
            this.LinkID = (int)row["LinkID"];
            this.LinkName = (string)row["LinkName"];
            this.LinkUrl = (string)row["LinkUrl"];
            this.LinkOrder = (int)row["LinkOrder"];
            this.LinkSortID = (int)row["LinkSortID"];
        }

        private int _LinkID;
        /// <summary>
        /// 链接ID
        /// </summary>
        public int LinkID
        {
            get { return _LinkID; }
            set { _LinkID = value; }
        }

        private string _LinkName;
        /// <summary>
        /// 链接名称
        /// </summary>
        public string LinkName
        {
            get { return _LinkName; }
            set { _LinkName = value; }
        }

        private string _LinkUrl;
        /// <summary>
        /// 链接地址
        /// </summary>
        public string LinkUrl
        {
            get { return _LinkUrl; }
            set { _LinkUrl = value; }
        }
        

        private int _LinkOrder;
        /// <summary>
        /// 排序
        /// </summary>
        public int LinkOrder
        {
            get { return _LinkOrder; }
            set { _LinkOrder = value; }
        }

        private int _LinkSortID;
        /// <summary>
        /// 类别ID
        /// </summary>
        public int LinkSortID
        {
            get { return _LinkSortID; }
            set { _LinkSortID = value; }
        }

        private string _LinkSortName;
        /// <summary>
        /// 类别名称
        /// </summary>
        public string LinkSortName
        {
            get { return _LinkSortName; }
            set { _LinkSortName = value; }
        }
    }
}
