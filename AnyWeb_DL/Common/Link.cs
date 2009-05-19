using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb_DL
{
    public class Link
    {
        public Link()
        { }

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
    }
}
