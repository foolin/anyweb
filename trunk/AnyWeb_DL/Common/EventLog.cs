using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb_DL
{
    public class EventLog
    {
        public EventLog()
        { }

        private int _EvenID;
        /// <summary>
        /// ��־ID
        /// </summary>
        public int EvenID
        {
            get { return _EvenID; }
            set { _EvenID = value; }
        }

        private string _EvenDesc;
        /// <summary>
        /// ��־����
        /// </summary>
        public string EvenDesc
        {
            get { return _EvenDesc; }
            set { _EvenDesc = value; }
        }

        private string _EvenIP;
        /// <summary>
        /// IP
        /// </summary>
        public string EvenIP
        {
            get { return _EvenIP; }
            set { _EvenIP = value; }
        }

        private DateTime _EvenAt;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime EvenAt
        {
            get { return _EvenAt; }
            set { _EvenAt = value; }
        }

        private string _UserAcc;
        /// <summary>
        /// �û��ʺ�
        /// </summary>
        public string UserAcc
        {
            get { return _UserAcc; }
            set { _UserAcc = value; }
        }
    }
}
