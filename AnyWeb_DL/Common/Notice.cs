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
        /// 公告ID
        /// </summary>
        public int NotiID
        {
            get { return _NotiID; }
            set { _NotiID = value; }
        }

        private string _NotiTitle;
        /// <summary>
        /// 公告标题
        /// </summary>
        public string NotiTitle
        {
            get { return _NotiTitle; }
            set { _NotiTitle = value; }
        }

        private DateTime _NotiCreateAt;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime NotiCreateAt
        {
            get { return _NotiCreateAt; }
            set { _NotiCreateAt = value; }
        }

        private string _NotiContent;
        /// <summary>
        /// 公告内容
        /// </summary>
        public string NotiContent
        {
            get { return _NotiContent; }
            set { _NotiContent = value; }
        }
    }
}
