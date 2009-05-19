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
        /// 专题ID
        /// </summary>
        public int ActiID
        {
            get { return _ActiID; }
            set { _ActiID = value; }
        }

        private int _ActiColumnID;
        /// <summary>
        /// 栏目ID
        /// </summary>
        public int ActiColumnID
        {
            get { return _ActiColumnID; }
            set { _ActiColumnID = value; }
        }

        private string _ActiImage;
        /// <summary>
        /// 专题图片
        /// </summary>
        public string ActiImage
        {
            get { return _ActiImage; }
            set { _ActiImage = value; }
        }

        private string _ActiName;
        /// <summary>
        /// 专题名称
        /// </summary>
        public string ActiName
        {
            get { return _ActiName; }
            set { _ActiName = value; }
        }
    }
}
