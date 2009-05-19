using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb_DL
{
    public class Article
    {
        public Article()
        { }

        private int _ArtiID;
        /// <summary>
        /// 文章ID
        /// </summary>
        public int ArtiID
        {
            get { return _ArtiID; }
            set { _ArtiID = value; }
        }

        private string _ArtiTitle;
        /// <summary>
        /// 文章标题
        /// </summary>
        public string ArtiTitle
        {
            get { return _ArtiTitle; }
            set { _ArtiTitle = value; }
        }

        private string _ArtiContent;
        /// <summary>
        /// 文章内容
        /// </summary>
        public string ArtiContent
        {
            get { return _ArtiContent; }
            set { _ArtiContent = value; }
        }

        private DateTime _ArtiCreateAt;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime ArtiCreateAt
        {
            get { return _ArtiCreateAt; }
            set { _ArtiCreateAt = value; }
        }

        private int _ArtiColumnID;
        /// <summary>
        /// 栏目ID
        /// </summary>
        public int ArtiColumnID
        {
            get { return _ArtiColumnID; }
            set { _ArtiColumnID = value; }
        }

        private int _ArtiStatus;
        /// <summary>
        /// 文章状态（0：正常1：删除）
        /// </summary>
        public int ArtiStatus
        {
            get { return _ArtiStatus; }
            set { _ArtiStatus = value; }
        }

        private bool _ArtiIsTop;
        /// <summary>
        /// 0：正常1置顶
        /// </summary>
        public bool ArtiIsTop
        {
            get { return _ArtiIsTop; }
            set { _ArtiIsTop = value; }
        }

        private int _ArtiClicks;
        /// <summary>
        /// 点击数
        /// </summary>
        public int ArtiClicks
        {
            get { return _ArtiClicks; }
            set { _ArtiClicks = value; }
        }

        private int _ArtiOrderD;
        /// <summary>
        /// 排序
        /// </summary>
        public int ArtiOrderD
        {
            get { return _ArtiOrderD; }
            set { _ArtiOrderD = value; }
        }

        private int _ArtiUserID;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int ArtiUserID
        {
            get { return _ArtiUserID; }
            set { _ArtiUserID = value; }
        }

        private string _ArtiUserName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string ArtiUserName
        {
            get { return _ArtiUserName; }
            set { _ArtiUserName = value; }
        }
	
    }
}
