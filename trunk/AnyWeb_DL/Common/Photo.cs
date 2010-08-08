using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AnyWeb.AnyWeb_DL
{
    /// <summary>
    /// ͼƬչʾ
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
            this.PhotCateID = (int)row["PhotCateID"];
        }

        private int _PhotID;
        /// <summary>
        /// ͼƬID
        /// </summary>
        public int PhotID
        {
            get { return _PhotID; }
            set { _PhotID = value; }
        }

        private string _PhotName;
        /// <summary>
        /// ͼƬ����
        /// </summary>
        public string PhotName
        {
            get { return _PhotName; }
            set { _PhotName = value; }
        }

        private string _PhotUrl;
        /// <summary>
        /// ͼƬ����
        /// </summary>
        public string PhotUrl
        {
            get { return _PhotUrl; }
            set { _PhotUrl = value; }
        }

        private string _PhotPath;
        /// <summary>
        /// ͼƬ·��
        /// </summary>
        public string PhotPath
        {
            get { return _PhotPath; }
            set { _PhotPath = value; }
        }

        private int _PhotOrder;
        /// <summary>
        /// ����
        /// </summary>
        public int PhotOrder
        {
            get { return _PhotOrder; }
            set { _PhotOrder = value; }
        }

        private DateTime _PhotUploadAt;
        /// <summary>
        /// �ϴ�ʱ��
        /// </summary>
        public DateTime PhotUploadAt
        {
            get { return _PhotUploadAt; }
            set { _PhotUploadAt = value; }
        }

        private int _PhotCateID;
        /// <summary>
        /// ���ID
        /// </summary>
        public int PhotCateID
        {
            get { return _PhotCateID; }
            set { _PhotCateID = value; }
        }
    }
}
