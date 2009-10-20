using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace AnyWeb.AnyWeb_DL
{
    public class Site
    {
        public Site()
        { }

        public Site(DataRow row)
        {
            this.SiteID = (int)row["SiteID"];
            this.SiteName = (string)row["SiteName"];
            this.SiteAddress = (string)row["SiteAddress"];
            this.SitePhone = (string)row["SitePhone"];
            this.SiteFax = (string)row["SiteFax"];
            this.SiteEmail = (string)row["SiteEmail"];
            this.SiteRecordNO = (string)row["SiteRecordNO"];
            this.SiteClicks = (int)row["SiteClicks"];
            this.SiteArticleCount = (int)row["SiteArticleCount"];
            this.SiteColumnCount = (int)row["SiteColumnCount"];
            this.SiteLeaveCount = (int)row["SiteLeaveCount"];
            this.SitePicCount = (int)row["SitePicCount"];
            this.SiteNoticeCount = (int)row["SiteNoticeCount"];
            this.SiteLinkCount = (int)row["SiteLinkCount"];
        }

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

        private ArrayList _UserList;
        /// <summary>
        /// 用户集合
        /// </summary>
        public ArrayList UserList
        {
            get { return _UserList; }
            set { _UserList = value; }
        }

        private ArrayList _NavigationList;
        /// <summary>
        /// 导航栏
        /// </summary>
        public ArrayList NavigationList
        {
            get { return _NavigationList; }
            set { _NavigationList = value; }
        }

        private int _SitePicCount;
        /// <summary>
        /// 图片数
        /// </summary>
        public int SitePicCount
        {
            get { return _SitePicCount; }
            set { _SitePicCount = value; }
        }

        private int _SiteNoticeCount;
        /// <summary>
        /// 流动通知数
        /// </summary>
        public int SiteNoticeCount
        {
            get { return _SiteNoticeCount; }
            set { _SiteNoticeCount = value; }
        }

        private int _SiteLinkCount;
        /// <summary>
        /// 链接数
        /// </summary>
        public int SiteLinkCount
        {
            get { return _SiteLinkCount; }
            set { _SiteLinkCount = value; }
        }
	

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userAcc"></param>
        /// <returns></returns>
        public User GetUserByID(int UserID)
        {
            foreach (User u in this.UserList)
            {
                if (u.UserID == UserID) return u;
            }
            return null;
        }
    }
}
