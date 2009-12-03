using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;
using Common.Agent;

namespace Common.Common
{
    /// <summary>
    /// 文章实体
    /// </summary>
    public class Article:IdObject
    {

        public  Article() { }

        public  Article(DataRow dr)
        {
            this.ID = (int)dr["ArticleID"];
            this._title = (string)dr["Title"];
            this._shopID = (int)dr["ShopID"];
            this._isComment = (bool)dr["IsComment"];
            this._content = (string)dr["Content"];
            this._categoryID = (int)dr["CategoryID"];
            this._clickCount = (int)dr["ClickCount"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._commentCount = (int)dr["CommentCount"];
        }

        private string _title;
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
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

        private int _categoryID;
        /// <summary>
        /// 所属栏目编号
        /// </summary>
        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        private string _content;
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private int _clickCount;
        /// <summary>
        /// 点击率
        /// </summary>
        public int ClickCount
        {
            get { return _clickCount; }
            set { _clickCount = value; }
        }

        private int _commentCount;
        /// <summary>
        /// 评论数
        /// </summary>
        public int CommentCount
        {
            get { return _commentCount; }
            set { _commentCount = value; }
        }

     
        private bool _isComment;
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public bool IsComment
        {
            get { return _isComment; }
            set { _isComment = value; }
        }

        private int _shopID;
        /// <summary>
        /// 所属商店编号
        /// </summary>
        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }

        /// <summary>
        /// 所属栏目
        /// </summary>
        private Category _ofCategory;

        public Category OfCategory
        {
            get { return _ofCategory; }
            set { _ofCategory = value; }
        }

        /// <summary>
        /// 路径
        /// </summary>
        private string _linkUrl;

        public string LinkUrl
        {
            get
            {
                if (_linkUrl == null)
                    _linkUrl = string.Format("{0}/c/{1}/{2}.aspx", "http://"+this.OfCategory.OfShop.ShopDomain, this.OfCategory.Path, this.ID);
                return _linkUrl;
            }
            set { _linkUrl = value; }
        }

        private string _backUrl;

        public string BackUrl
        {
            get
            {
                return _backUrl;
            }
            set { _backUrl = value; }
        }

    }
}
