using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AnyWeb.AnyWeb_DL
{
    public class Link
    {
        public Link()
        { }

        public Link(DataRow row)
        {
            this.LinkID = (int)row["LinkID"];
            this.LinkName = (string)row["LinkName"];
            this.LinkUrl = (string)row["LinkUrl"];
            this.LinkOrder = (int)row["LinkOrder"];
            this.LinkSortID = (int)row["LinkSortID"];
        }

        private int _LinkID;
        /// <summary>
        /// ����ID
        /// </summary>
        public int LinkID
        {
            get { return _LinkID; }
            set { _LinkID = value; }
        }

        private string _LinkName;
        /// <summary>
        /// ��������
        /// </summary>
        public string LinkName
        {
            get { return _LinkName; }
            set { _LinkName = value; }
        }

        private string _LinkUrl;
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        public string LinkUrl
        {
            get { return _LinkUrl; }
            set { _LinkUrl = value; }
        }
        

        private int _LinkOrder;
        /// <summary>
        /// ����
        /// </summary>
        public int LinkOrder
        {
            get { return _LinkOrder; }
            set { _LinkOrder = value; }
        }

        private int _LinkSortID;
        /// <summary>
        /// ���ID
        /// </summary>
        public int LinkSortID
        {
            get { return _LinkSortID; }
            set { _LinkSortID = value; }
        }

        private string _LinkSortName;
        /// <summary>
        /// �������
        /// </summary>
        public string LinkSortName
        {
            get { return _LinkSortName; }
            set { _LinkSortName = value; }
        }
    }
}
