using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Studio.Array;
namespace Common.Common
{
    public class Link:IdObject
    {
        public Link()
        { 
        }
        public Link(DataRow dr)
        {
            this.ID = (int)dr["LinkID"];
            this._name = (string)dr["LinkName"];
            this._image = (string)dr["Image"];
            this._linkUrl = (string)dr["LinkUrl"];
            this._sort = (short)dr["Sort"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._ofShop = new Shop();
            
        }

        /// <summary>
        /// ��������
        /// </summary>
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// ͼƬ
        /// </summary>
        private string _image;
            
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string ImageWeb
        {
            get
            { 
                return "shopdata/" + OfShop.ID + this.Image; 
            }
           
        }


        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        private string _linkUrl;

        public string LinkUrl
        {
            get { return _linkUrl; }
            set { _linkUrl = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        private short _sort;

        public short Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }

        /// <summary>
        /// �����̵�
        /// </summary>
        private Shop _ofShop;

        public Shop OfShop
        {
            get { return _ofShop; }
            set { _ofShop = value; }
        }

        /// <summary>
        /// ����ʱ�� 
        /// </summary>
        private DateTime _createAt;

        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }

        private int _linkType;
        /// <summary>
        /// �������
        /// </summary>
        public int LinkType
        {
            get { return _linkType; }
            set { _linkType = value; }
        }

    }
}
