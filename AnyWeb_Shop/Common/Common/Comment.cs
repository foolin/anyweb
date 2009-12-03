using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class Comment:IdObject
    {

        public Comment() { }

        public Comment(DataRow dr)
        {
            this.ID = (int)dr["CommentID"];
            this._shopID = (int)dr["ShopID"];
            this._userid = (int)dr["UserID"];
            this._userName = (string)dr["UserName"];
            this._typeID = (int)dr["TypeID"];
            this._sourceID = (int)dr["SourceID"];
            this._ip = (string)dr["IP"];
            this._deleted = (bool)dr["Deleted"];
            this._content = (string)dr["Content"];
            this._commentAt = (DateTime)dr["CommentAt"];
            this._area = (string)dr["Area"];
            this._urlRef = (string)dr["UrlRef"];
            this._replay = dr["Replay"] == System.DBNull.Value ? "" : (string)dr["Replay"];
            this._replayAt = dr["ReplayAt"] == System.DBNull.Value ? DateTime.MaxValue : (DateTime)dr["ReplayAt"];
        }

        private int  _shopID;
        /// <summary>
        /// 商店编号
        /// </summary>
        public int  ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }

        private int _userid;
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
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
        private DateTime _commentAt;
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentAt
        {
            get { return _commentAt; }
            set { _commentAt = value; }
        }
        private string _content;
        /// <summary>
        /// 评论内容
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
        private string _urlRef;
        /// <summary>
        /// 来源地址
        /// </summary>
        public string UrlRef
        {
            get { return _urlRef; }
            set { _urlRef = value; }
        }
        private int _typeID;
        /// <summary>
        /// 类型 0-商品 1-文章
        /// </summary>
        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }

        private int _sourceID;
        /// <summary>
        /// 来源编号
        /// </summary>
        public int SourceID
        {
            get { return _sourceID; }
            set { _sourceID = value; }
        }
        private string _area;
        /// <summary>
        /// ip范围
        /// </summary>
        public string Area
        {
            get { return _area; }
            set { _area = value; }
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
