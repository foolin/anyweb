using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb.AnyWeb_DL
{
    public class Article
    {
        public Article()
        { }

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

        private int _ArtiOrderD;
        /// <summary>
        /// ����
        /// </summary>
        public int ArtiOrderD
        {
            get { return _ArtiOrderD; }
            set { _ArtiOrderD = value; }
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
	
    }
}
