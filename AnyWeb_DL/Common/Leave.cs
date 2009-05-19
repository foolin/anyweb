using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb_DL
{
    public class Leave
    {
        public Leave()
        { }

        private int _LeavID;
        /// <summary>
        /// ����ID
        /// </summary>
        public int LeavID
        {
            get { return _LeavID; }
            set { _LeavID = value; }
        }

        private int _LeavDepartment;
        /// <summary>
        /// ��������(1:�칫��2:�ۺϴ�3:����4:�Ͷ����ʴ�5:��ƴ�6:������)
        /// </summary>
        public int LeavDepartment
        {
            get { return _LeavDepartment; }
            set { _LeavDepartment = value; }
        }

        private bool _LeavType;
        /// <summary>
        /// ��������(0:��������1:������ѯ)
        /// </summary>
        public bool LeavType
        {
            get { return _LeavType; }
            set { _LeavType = value; }
        }

        private string _LeavUserName;
        /// <summary>
        /// ����
        /// </summary>
        public string LeavUserName
        {
            get { return _LeavUserName; }
            set { _LeavUserName = value; }
        }

        private string _LeavPhone;
        /// <summary>
        /// ���Ե绰
        /// </summary>
        public string LeavPhone
        {
            get { return _LeavPhone; }
            set { _LeavPhone = value; }
        }

        private string _LeavEmail;
        /// <summary>
        /// ��������
        /// </summary>
        public string LeavEmail
        {
            get { return _LeavEmail; }
            set { _LeavEmail = value; }
        }

        private string _LeavTitle;
        /// <summary>
        /// �������
        /// </summary>
        public string LeavTitle
        {
            get { return _LeavTitle; }
            set { _LeavTitle = value; }
        }

        private string _LeavContent;
        /// <summary>
        /// �������
        /// </summary>
        public string LeavContent
        {
            get { return _LeavContent; }
            set { _LeavContent = value; }
        }

        private string _LeavIP;
        /// <summary>
        /// ����IP
        /// </summary>
        public string LeavIP
        {
            get { return _LeavIP; }
            set { _LeavIP = value; }
        }

        private DateTime _LeavCreateAt;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime LeavCreateAt
        {
            get { return _LeavCreateAt; }
            set { _LeavCreateAt = value; }
        }

        private bool _LeavDeleted;
        /// <summary>
        /// 0:����1:��ɾ��
        /// </summary>
        public bool LeavDeleted
        {
            get { return _LeavDeleted; }
            set { _LeavDeleted = value; }
        }

        private string _LeavRevert;
        /// <summary>
        /// �ظ�����
        /// </summary>
        public string LeavRevert
        {
            get { return _LeavRevert; }
            set { _LeavRevert = value; }
        }

        private DateTime _LeavRevertat;
        /// <summary>
        /// �ظ�ʱ��
        /// </summary>
        public DateTime LeavRevertat
        {
            get { return _LeavRevertat; }
            set { _LeavRevertat = value; }
        }
    }
}
