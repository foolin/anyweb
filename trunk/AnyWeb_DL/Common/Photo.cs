using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AnyWeb.AnyWeb_DL
{
    /// <summary>
    /// Í¼Æ¬Õ¹Ê¾
    /// </summary>
    public class Photo
    {
        public Photo()
        { }

        public Photo(DataRow row)
        {
            this.PhotID = (int)row["PhotID"];
            this.PhotName = (string)row["PhotName"];
            this.PhotUrl = (string)row["PhotUrl"];
            this.PhotPath = (string)row["PhotPath"];
            this.PhotOrder = (int)row["PhotOrder"];
            this.PhotUploadAt = (DateTime)row["PhotUploadAt"];
            this.PhotSortID = (int)row["PhotSortID"];
        }

        private int _PhotID;
        /// <summary>
        /// Í¼Æ¬ID
        /// </summary>
        public int PhotID
        {
            get { return _PhotID; }
            set { _PhotID = value; }
        }

        private string _PhotName;
        /// <summary>
        /// Í¼Æ¬Ãû³Æ
        /// </summary>
        public string PhotName
        {
            get { return _PhotName; }
            set { _PhotName = value; }
        }

        private string _PhotUrl;
        /// <summary>
        /// Í¼Æ¬ÃèÊö
        /// </summary>
        public string PhotUrl
        {
            get { return _PhotUrl; }
            set { _PhotUrl = value; }
        }

        private string _PhotPath;
        /// <summary>
        /// Í¼Æ¬Â·¾¶
        /// </summary>
        public string PhotPath
        {
            get { return _PhotPath; }
            set { _PhotPath = value; }
        }

        private int _PhotOrder;
        /// <summary>
        /// ÅÅÐò
        /// </summary>
        public int PhotOrder
        {
            get { return _PhotOrder; }
            set { _PhotOrder = value; }
        }

        private DateTime _PhotUploadAt;
        /// <summary>
        /// ÉÏ´«Ê±¼ä
        /// </summary>
        public DateTime PhotUploadAt
        {
            get { return _PhotUploadAt; }
            set { _PhotUploadAt = value; }
        }

        private int _PhotSortID;
        /// <summary>
        /// À¸Ä¿ID
        /// </summary>
        public int PhotSortID
        {
            get { return _PhotSortID; }
            set { _PhotSortID = value; }
        }

        private string _PhotSortName;
        /// <summary>
        /// À¸Ä¿Ãû³Æ
        /// </summary>
        public string PhotSortName
        {
            get { return _PhotSortName; }
            set { _PhotSortName = value; }
        }
    }
}
