using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb.AnyWeb_DL
{
    public class Active
    {
        public Active()
        { }

        private int _ActiID;
        /// <summary>
        /// ר��ID
        /// </summary>
        public int ActiID
        {
            get { return _ActiID; }
            set { _ActiID = value; }
        }

        private int _ActiColumnID;
        /// <summary>
        /// ��ĿID
        /// </summary>
        public int ActiColumnID
        {
            get { return _ActiColumnID; }
            set { _ActiColumnID = value; }
        }

        private string _ActiImage;
        /// <summary>
        /// ר��ͼƬ
        /// </summary>
        public string ActiImage
        {
            get { return _ActiImage; }
            set { _ActiImage = value; }
        }

        private string _ActiName;
        /// <summary>
        /// ר������
        /// </summary>
        public string ActiName
        {
            get { return _ActiName; }
            set { _ActiName = value; }
        }
    }
}
