using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb.AnyWeb_DL
{
    public class Navigation
    {
        public Navigation()
        { }

        private int _NaviID;
        /// <summary>
        /// 导航栏ID
        /// </summary>
        public int NaviID
        {
            get { return _NaviID; }
            set { _NaviID = value; }
        }

        private string _NaviName;
        /// <summary>
        /// 导航栏名称
        /// </summary>
        public string NaviName
        {
            get { return _NaviName; }
            set { _NaviName = value; }
        }

        private int _NaviOrder;
        /// <summary>
        /// 排序
        /// </summary>
        public int NaviOrder
        {
            get { return _NaviOrder; }
            set { _NaviOrder = value; }
        }

        private DateTime _NaviCreateAt;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime NaviCreateAt
        {
            get { return _NaviCreateAt; }
            set { _NaviCreateAt = value; }
        }

        private string _NaviUrl;
        /// <summary>
        /// 链接地址
        /// </summary>
        public string NaviUrl
        {
            get { return _NaviUrl; }
            set { _NaviUrl = value; }
        }

        private int _NaviType;
        /// <summary>
        /// 0:文章栏目1:自定义栏目2:扩展
        /// </summary>
        public int NaviType
        {
            get { return _NaviType; }
            set { _NaviType = value; }
        }
    }
}
