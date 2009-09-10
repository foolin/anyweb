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
        }

        private int _LinkID;
        /// <summary>
        /// Á´½ÓID
        /// </summary>
        public int LinkID
        {
            get { return _LinkID; }
            set { _LinkID = value; }
        }

        private string _LinkName;
        /// <summary>
        /// Á´½ÓÃû³Æ
        /// </summary>
        public string LinkName
        {
            get { return _LinkName; }
            set { _LinkName = value; }
        }

        private string _LinkUrl;
        /// <summary>
        /// Á´½ÓµØÖ·
        /// </summary>
        public string LinkUrl
        {
            get { return _LinkUrl; }
            set { _LinkUrl = value; }
        }

        private string _LinkImage;
        /// <summary>
        /// Í¼Æ¬Â·¾¶
        /// </summary>
        public string LinkImage
        {
            get { return _LinkImage; }
            set { _LinkImage = value; }
        }

        private int _LinkSort;
        /// <summary>
        /// ÅÅÐò
        /// </summary>
        public int LinkSort
        {
            get { return _LinkSort; }
            set { _LinkSort = value; }
        }
    }
}
