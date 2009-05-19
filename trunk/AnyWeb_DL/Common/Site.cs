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
        /// վ��ID
        /// </summary>
        public int SiteID
        {
            get { return _SiteID; }
            set { _SiteID = value; }
        }

        private string _SiteName;
        /// <summary>
        /// վ������
        /// </summary>
        public string SiteName
        {
            get { return _SiteName; }
            set { _SiteName = value; }
        }

        private string _SiteAddress;
        /// <summary>
        /// ��ϵ��ַ
        /// </summary>
        public string SiteAddress
        {
            get { return _SiteAddress; }
            set { _SiteAddress = value; }
        }

        private string _SitePhone;
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string SitePhone
        {
            get { return _SitePhone; }
            set { _SitePhone = value; }
        }

        private string _SiteFax;
        /// <summary>
        /// ����
        /// </summary>
        public string SiteFax
        {
            get { return _SiteFax; }
            set { _SiteFax = value; }
        }

        private string _SiteEmail;
        /// <summary>
        /// ����
        /// </summary>
        public string SiteEmail
        {
            get { return _SiteEmail; }
            set { _SiteEmail = value; }
        }

        private string _SiteRecordNO;
        /// <summary>
        /// ������
        /// </summary>
        public string SiteRecordNO
        {
            get { return _SiteRecordNO; }
            set { _SiteRecordNO = value; }
        }

        private int _SiteClicks;
        /// <summary>
        /// �����
        /// </summary>
        public int SiteClicks
        {
            get { return _SiteClicks; }
            set { _SiteClicks = value; }
        }

        private int _SiteArticleCount;
        /// <summary>
        /// ������
        /// </summary>
        public int SiteArticleCount
        {
            get { return _SiteArticleCount; }
            set { _SiteArticleCount = value; }
        }

        private int _SiteColumnCount;
        /// <summary>
        /// ��Ŀ��
        /// </summary>
        public int SiteColumnCount
        {
            get { return _SiteColumnCount; }
            set { _SiteColumnCount = value; }
        }

        private int _SiteLeaveCount;
        /// <summary>
        /// ������
        /// </summary>
        public int SiteLeaveCount
        {
            get { return _SiteLeaveCount; }
            set { _SiteLeaveCount = value; }
        }
    }
}
