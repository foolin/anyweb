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
        /// ����ID
        /// </summary>
        public int LinkID
        {
            get { return _LinkID; }
            set { _LinkID = value; }
        }

        private string _LinkName;
        /// <summary>
        /// ��������
        /// </summary>
        public string LinkName
        {
            get { return _LinkName; }
            set { _LinkName = value; }
        }

        private string _LinkUrl;
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        public string LinkUrl
        {
            get { return _LinkUrl; }
            set { _LinkUrl = value; }
        }

        private string _LinkImage;
        /// <summary>
        /// ͼƬ·��
        /// </summary>
        public string LinkImage
        {
            get { return _LinkImage; }
            set { _LinkImage = value; }
        }

        private int _LinkSort;
        /// <summary>
        /// ����
        /// </summary>
        public int LinkSort
        {
            get { return _LinkSort; }
            set { _LinkSort = value; }
        }

        private int _LinkType;
        /// <summary>
        /// ��������
        /// </summary>
        public int LinkType
        {
            get { return _LinkType; }
            set { _LinkType = value; }
        }
    }
}
