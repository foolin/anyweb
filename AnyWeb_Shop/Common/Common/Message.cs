using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class Message:IdObject
    {

        public Message() { }
        
        public Message(DataRow dr)
        {
            this.ID = (int)dr["MsgID"];
            this._shopID = (int)dr["ShopID"];
            this._userID = (int)dr["UserID"];
            this._userName = (string)dr["UserName"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._replay = dr["Replay"] == System.DBNull.Value ? "" : (string)dr["Replay"];
            this._replayAt = dr["ReplayAt"] == System.DBNull.Value ? DateTime.MinValue : (DateTime)dr["ReplayAt"];
            this._ip = (string)dr["IP"];
            this._area =dr["Area"] == System.DBNull.Value ? "" : (string)dr["Area"];
            this._content = (string)dr["Content"];
            this._deleted = (bool)dr["Deleted"];
        }

        private int _shopID;
        /// <summary>
        /// 商城编号
        /// </summary>
        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }

        private int _userID;
       /// <summary>
       /// 用户编号
       /// </summary>
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private string _userName;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _ip;
        /// <summary>
        /// ip
        /// </summary>
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private string _area;
        /// <summary>
        /// 地区
        /// </summary>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

        private DateTime _createAt;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }

        private string _content;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private bool _deleted;
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool Deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }

        private string _replay;
        /// <summary>
        /// 回复
        /// </summary>
        public string Replay
        {
            get { return _replay; }
            set { _replay = value; }
        }

        private DateTime _replayAt;
        /// <summary>
        /// 回复时间
        /// </summary>
        public DateTime ReplayAt
        {
            get { return _replayAt; }
            set { _replayAt = value; }
        }

    }
}
    