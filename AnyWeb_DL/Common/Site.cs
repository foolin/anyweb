using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb.AnyWeb_DL
{
    public class Site
    {
        public Site()
        { }

        private int _SiteID;
        /// <summary>
        /// 站点ID
        /// </summary>
        public int SiteID
        {
            get { return _SiteID; }
            set { _SiteID = value; }
        }

        private string _SiteName;
        /// <summary>
        /// 站点名称
        /// </summary>
        public string SiteName
        {
            get { return _SiteName; }
            set { _SiteName = value; }
        }

        private string _SiteAddress;
        /// <summary>
        /// 联系地址
        /// </summary>
        public string SiteAddress
        {
            get { return _SiteAddress; }
            set { _SiteAddress = value; }
        }

        private string _SitePhone;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string SitePhone
        {
            get { return _SitePhone; }
            set { _SitePhone = value; }
        }

        private string _SiteFax;
        /// <summary>
        /// 传真
        /// </summary>
        public string SiteFax
        {
            get { return _SiteFax; }
            set { _SiteFax = value; }
        }

        private string _SiteEmail;
        /// <summary>
        /// 邮箱
        /// </summary>
        public string SiteEmail
        {
            get { return _SiteEmail; }
            set { _SiteEmail = value; }
        }

        private string _SiteRecordNO;
        /// <summary>
        /// 备案号
        /// </summary>
        public string SiteRecordNO
        {
            get { return _SiteRecordNO; }
            set { _SiteRecordNO = value; }
        }

        private int _SiteClicks;
        /// <summary>
        /// 点击数
        /// </summary>
        public int SiteClicks
        {
            get { return _SiteClicks; }
            set { _SiteClicks = value; }
        }

        private int _SiteArticleCount;
        /// <summary>
        /// 文章数
        /// </summary>
        public int SiteArticleCount
        {
            get { return _SiteArticleCount; }
            set { _SiteArticleCount = value; }
        }

        private int _SiteColumnCount;
        /// <summary>
        /// 栏目数
        /// </summary>
        public int SiteColumnCount
        {
            get { return _SiteColumnCount; }
            set { _SiteColumnCount = value; }
        }

        private int _SiteLeaveCount;
        /// <summary>
        /// 留言数
        /// </summary>
        public int SiteLeaveCount
        {
            get { return _SiteLeaveCount; }
            set { _SiteLeaveCount = value; }
        }
    }
}
