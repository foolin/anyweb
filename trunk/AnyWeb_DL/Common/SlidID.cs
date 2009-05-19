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
        /// Í¼Æ¬ID
        /// </summary>
        public int SlidID
        {
            get { return _SlidID; }
            set { _SlidID = value; }
        }

        private string _SlidTitle;
        /// <summary>
        /// Í¼Æ¬±êÌâ
        /// </summary>
        public string SlidTitle
        {
            get { return _SlidTitle; }
            set { _SlidTitle = value; }
        }

        private string _SlidPath;
        /// <summary>
        /// Í¼Æ¬Â·¾¶
        /// </summary>
        public string SlidPath
        {
            get { return _SlidPath; }
            set { _SlidPath = value; }
        }

        private string _SlidUrl;
        /// <summary>
        /// Í¼Æ¬Á´½ÓµØÖ·
        /// </summary>
        public string SlidUrl
        {
            get { return _SlidUrl; }
            set { _SlidUrl = value; }
        }	
    }
}
