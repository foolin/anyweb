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
            this.PhotDesc = (string)row["PhotDesc"];
            this.PhotPath = (string)row["PhotPath"];
            this.PhotOrder = (int)row["PhotOrder"];
            this.PhotUploadAt = (DateTime)row["PhotUploadAt"];
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

        private string _PhotDesc;
        /// <summary>
        /// Í¼Æ¬ÃèÊö
        /// </summary>
        public string PhotDesc
        {
            get { return _PhotDesc; }
            set { _PhotDesc = value; }
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
	
    }
}
