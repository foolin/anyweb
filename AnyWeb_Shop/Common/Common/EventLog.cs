using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using Studio.Array;

namespace Common.Common
{
    /// <summary>
    /// 日志实体
    /// </summary>
    public class EventLog:IdObject
    {
        public EventLog()
        {  }

        public EventLog(DataRow dr)
        {
            this.ID = (int)dr["LogID"];
            this._eventName = (string)dr["EventName"];
            this._fromIP = (string)dr["FromIP"];
            this._raiseAt = (DateTime)dr["RaiseAt"];
            this._description = (string)dr["Description"];
            this._eventType = (EventID)(int)dr["EventID"];
            this._eventID = (int)dr["EventID"];
 
        }

        /// <summary>
        /// 商店编号
        /// </summary>
        private int _shopID;

        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }

        /// <summary>
        /// 日志类别
        /// </summary>
        private EventID _eventType;

        public EventID EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        private string _eventName;

        public string EventName
        {
            get { return _eventName; }
            set { _eventName = value; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// 日志记录时间
        /// </summary>
        private DateTime _raiseAt;

        public DateTime RaiseAt
        {
            get { return _raiseAt; }
            set { _raiseAt = value; }
        }

        /// <summary>
        /// 来源IP
        /// </summary>
        private string _fromIP;

        public string FromIP
        {
            get { return _fromIP; }
            set { _fromIP = value; }
        }

        private int _eventID;
        /// <summary>
        /// 操作编号
        /// </summary>
        public int EventID
        {
            get { return _eventID; }
            set { _eventID = value; }
        }

    }

    /// <summary>
    /// 枚举：1登陆,2添加,3修改,4删除
    /// </summary>
    public enum EventID :int
    {
        Login = 1,
        Insert = 2,
        Update = 3,
        Delete = 4
    }
}
