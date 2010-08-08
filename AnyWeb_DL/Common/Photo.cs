using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AnyWeb.AnyWeb_DL
{
    /// <summary>
    /// 图片展示
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
        /// 图片ID
        /// </summary>
        public int PhotID
        {
            get { return _PhotID; }
            set { _PhotID = value; }
        }

        private string _PhotName;
        /// <summary>
        /// 图片名称
        /// </summary>
        public string PhotName
        {
            get { return _PhotName; }
            set { _PhotName = value; }
        }

        private string _PhotUrl;
        /// <summary>
        /// 图片描述
        /// </summary>
        public string PhotUrl
        {
            get { return _PhotUrl; }
            set { _PhotUrl = value; }
        }

        private string _PhotPath;
        /// <summary>
        /// 图片路径
        /// </summary>
        public string PhotPath
        {
            get { return _PhotPath; }
            set { _PhotPath = value; }
        }

        private int _PhotOrder;
        /// <summary>
        /// 排序
        /// </summary>
        public int PhotOrder
        {
            get { return _PhotOrder; }
            set { _PhotOrder = value; }
        }

        private DateTime _PhotUploadAt;
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime PhotUploadAt
        {
            get { return _PhotUploadAt; }
            set { _PhotUploadAt = value; }
        }

        private int _PhotCateID;
        /// <summary>
        /// 类别ID
        /// </summary>
        public int PhotCateID
        {
            get { return _PhotCateID; }
            set { _PhotCateID = value; }
        }
    }
}
