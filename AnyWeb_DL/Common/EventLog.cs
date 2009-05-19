using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb.AnyWeb_DL
{
    public class EventLog
    {
        public EventLog()
        { }

        private int _EvenID;
        /// <summary>
        /// 日志ID
        /// </summary>
        public int EvenID
        {
            get { return _EvenID; }
            set { _EvenID = value; }
        }

        private string _EvenDesc;
        /// <summary>
        /// 日志描述
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
        /// 操作时间
        /// </summary>
        public DateTime EvenAt
        {
            get { return _EvenAt; }
            set { _EvenAt = value; }
        }

        private string _EvenUserAcc;
        /// <summary>
        /// 用户帐号
        /// </summary>
        public string EvenUserAcc
        {
            get { return _EvenUserAcc; }
            set { _EvenUserAcc = value; }
        }
    }
}
