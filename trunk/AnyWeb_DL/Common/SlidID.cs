using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb_DL
{
    public class SlidID
    {
        public SlidID()
        { }

        private int _SlidID;
        /// <summary>
        /// ͼƬID
        /// </summary>
        public int SlidID
        {
            get { return _SlidID; }
            set { _SlidID = value; }
        }

        private string _SlidTitle;
        /// <summary>
        /// ͼƬ����
        /// </summary>
        public string SlidTitle
        {
            get { return _SlidTitle; }
            set { _SlidTitle = value; }
        }

        private string _SlidPath;
        /// <summary>
        /// ͼƬ·��
        /// </summary>
        public string SlidPath
        {
            get { return _SlidPath; }
            set { _SlidPath = value; }
        }

        private string _SlidUrl;
        /// <summary>
        /// ͼƬ���ӵ�ַ
        /// </summary>
        public string SlidUrl
        {
            get { return _SlidUrl; }
            set { _SlidUrl = value; }
        }	
    }
}
