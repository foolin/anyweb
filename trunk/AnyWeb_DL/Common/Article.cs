using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AnyWeb.AnyWeb_DL
{
    public class Article
    {
        public Article()
        { }

        public Article(DataRow row)
        {
            ArtiID = (int)row["ArtiID"];
            ArtiTitle = (string)row["ArtiTitle"];
            ArtiCreateAt = (DateTime)row["ArtiCreateAt"];
            ArtiColumnID = (int)row["ArtiColumnID"];
            ArtiStatus = (int)row["ArtiStatus"];
            ArtiIsTop = (bool)row["ArtiIsTop"];
            ArtiClicks = (int)row["ArtiClicks"];
            ArtiOrder = (int)row["ArtiOrder"];
            ArtiUserID = (int)row["ArtiUserID"];
            ArtiUserName = (string)row["ArtiUserName"];
        }

        private int _ArtiID;
        /// <summary>
        /// ����ID
        /// </summary>
        public int ArtiID
        {
            get { return _ArtiID; }
            set { _ArtiID = value; }
        }

        private string _ArtiTitle;
        /// <summary>
        /// ���±���
        /// </summary>
        public string ArtiTitle
        {
            get { return _ArtiTitle; }
            set { _ArtiTitle = value; }
        }

        private string _ArtiContent;
        /// <summary>
        /// ��������
        /// </summary>
        public string ArtiContent
        {
            get { return _ArtiContent; }
            set { _ArtiContent = value; }
        }

        private DateTime _ArtiCreateAt;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime ArtiCreateAt
        {
            get { return _ArtiCreateAt; }
            set { _ArtiCreateAt = value; }
        }

        private int _ArtiColumnID;
        /// <summary>
        /// ��ĿID
        /// </summary>
        public int ArtiColumnID
        {
            get { return _ArtiColumnID; }
            set { _ArtiColumnID = value; }
        }

        private int _ArtiStatus;
        /// <summary>
        /// ����״̬��0������1��ɾ����
        /// </summary>
        public int ArtiStatus
        {
            get { return _ArtiStatus; }
            set { _ArtiStatus = value; }
        }

        private bool _ArtiIsTop;
        /// <summary>
        /// 0������1�ö�
        /// </summary>
        public bool ArtiIsTop
        {
            get { return _ArtiIsTop; }
            set { _ArtiIsTop = value; }
        }

        private int _ArtiClicks;
        /// <summary>
        /// �����
        /// </summary>
        public int ArtiClicks
        {
            get { return _ArtiClicks; }
            set { _ArtiClicks = value; }
        }

        private int _ArtiOrder;
        /// <summary>
        /// ����
        /// </summary>
        public int ArtiOrder
        {
            get { return _ArtiOrder; }
            set { _ArtiOrder = value; }
        }

        private int _ArtiUserID;
        /// <summary>
        /// �û�ID
        /// </summary>
        public int ArtiUserID
        {
            get { return _ArtiUserID; }
            set { _ArtiUserID = value; }
        }

        private string _ArtiUserName;
        /// <summary>
        /// �û���
        /// </summary>
        public string ArtiUserName
        {
            get { return _ArtiUserName; }
            set { _ArtiUserName = value; }
        }

        private string _ArtiColunmName;
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string ArtiColumnName
        {
            get { return _ArtiColunmName; }
            set { _ArtiColunmName = value; }
        }
    }
}
