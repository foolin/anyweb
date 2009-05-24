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
            this.LinkImage = (string)row["LinkImage"];
            this.LinkUrl = (string)row["LinkUrl"];
            this.LinkSort = (int)row["LinkSort"];
            this.LinkType = (int)row["LinkType"];
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

        private string _LinkImage;
        /// <summary>
        /// 图片路径
        /// </summary>
        public string LinkImage
        {
            get { return _LinkImage; }
            set { _LinkImage = value; }
        }

        private int _LinkSort;
        /// <summary>
        /// 排序
        /// </summary>
        public int LinkSort
        {
            get { return _LinkSort; }
            set { _LinkSort = value; }
        }

        private int _LinkType;
        /// <summary>
        /// 链接类型
        /// </summary>
        public int LinkType
        {
            get { return _LinkType; }
            set { _LinkType = value; }
        }
    }
}
