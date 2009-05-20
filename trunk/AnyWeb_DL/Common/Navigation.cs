using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AnyWeb.AnyWeb_DL
{
    public class Navigation
    {
        public Navigation()
        { }

        public Navigation(DataRow row)
        {
            this.NaviID = (int)row["NaviID"];
            this.NaviName = (string)row["NaviName"];
            this.NaviOrder = (int)row["NaviOrder"];
            this.NaviCreateAt = (DateTime)row["NaviCreateAt"];
            this.NaviUrl = (string)row["NaviUrl"];
        }

        private int _NaviID;
        /// <summary>
        /// ������ID
        /// </summary>
        public int NaviID
        {
            get { return _NaviID; }
            set { _NaviID = value; }
        }

        private string _NaviName;
        /// <summary>
        /// ����������
        /// </summary>
        public string NaviName
        {
            get { return _NaviName; }
            set { _NaviName = value; }
        }

        private int _NaviOrder;
        /// <summary>
        /// ����
        /// </summary>
        public int NaviOrder
        {
            get { return _NaviOrder; }
            set { _NaviOrder = value; }
        }

        private DateTime _NaviCreateAt;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime NaviCreateAt
        {
            get { return _NaviCreateAt; }
            set { _NaviCreateAt = value; }
        }

        private string _NaviUrl;
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        public string NaviUrl
        {
            get { return _NaviUrl; }
            set { _NaviUrl = value; }
        }

        private int _NaviType;
        /// <summary>
        /// 0:������Ŀ1:�Զ�����Ŀ2:��չ
        /// </summary>
        public int NaviType
        {
            get { return _NaviType; }
            set { _NaviType = value; }
        }
    }
}
