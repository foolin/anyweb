using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb_DL
{
    public class Notice
    {
        public Notice()
        { }

        private int _NotiID;
        /// <summary>
        /// ����ID
        /// </summary>
        public int NotiID
        {
            get { return _NotiID; }
            set { _NotiID = value; }
        }

        private string _NotiTitle;
        /// <summary>
        /// �������
        /// </summary>
        public string NotiTitle
        {
            get { return _NotiTitle; }
            set { _NotiTitle = value; }
        }

        private DateTime _NotiCreateAt;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime NotiCreateAt
        {
            get { return _NotiCreateAt; }
            set { _NotiCreateAt = value; }
        }

        private string _NotiContent;
        /// <summary>
        /// ��������
        /// </summary>
        public string NotiContent
        {
            get { return _NotiContent; }
            set { _NotiContent = value; }
        }
    }
}
