using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AnyWeb.AnyWeb_DL
{
    public class Notice
    {
        public Notice()
        { }

        public Notice(DataRow row)
        {
            NotiID = (int)row["NotiID"];
            NotiArtiID = (int)row["NotiArtiID"];
            NotiOrder = (int)row["NotiOrder"];
            NotiCreateAt = (DateTime)row["NotiCreateAt"];
        }

        private int _NotiID;
        /// <summary>
        /// ����֪ͨID
        /// </summary>
        public int NotiID
        {
            get { return _NotiID; }
            set { _NotiID = value; }
        }

        private int _NotiArtiID;
        /// <summary>
        /// ��������ID
        /// </summary>
        public int NotiArtiID
        {
            get { return _NotiArtiID; }
            set { _NotiArtiID = value; }
        }

        private string _Title;
        /// <summary>
        /// ����֪ͨ����
        /// </summary>
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }


        private int _NotiOrder;
        /// <summary>
        /// ����
        /// </summary>
        public int NotiOrder
        {
            get { return _NotiOrder; }
            set { _NotiOrder = value; }
        }
	

        private DateTime _NotiCreateAt;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime NotiCreateAt
        {
            get { return _NotiCreateAt; }
            set { _NotiCreateAt = value; }
        }
    }
}
