using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    /// <summary>
    /// ����ʵ��
    /// </summary>
    public class Affiche : IdObject
    {
        public Affiche()
        {
 
        }
        public Affiche(DataRow dr)
        {
            this.ID = (int)dr["AfficheID"];
            this._title = (string)dr["Title"];
            this._context = (string)dr["Context"];
            this._createat = (DateTime)dr["CreateAt"];
            this._type = (int)dr["Type"];
            this._memberID = (int)dr["MemberID"];
        }

        /// <summary>
        /// ��������
        /// </summary>
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private int _memberID;
        /// <summary>
        /// ��Ա���
        /// </summary>
        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }
        }

        private int _shopID;
        /// <summary>
        /// �̳Ǳ��
        /// </summary>
        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }


        /// <summary>
        /// ��������
        /// </summary>
        private string _context;

        public string Context
        {
            get { return _context; }
            set { _context = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        private DateTime _createat;

        public DateTime CreateAt
        {
            get { return _createat; }
            set { _createat = value; }
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

        private int _type;
        /// <summary>
        /// ��������
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
	
        /// <summary>
        /// ����·��
        /// </summary>
        private string _linkUrl;

        public string LinkUrl
        {
            get
            {
                if (_linkUrl == null)
                    _linkUrl = string.Format("{0}/a/{1}.aspx", "http://" + this.OfShop.ShopDomain,this.ID);
                return _linkUrl;
            }
            set { _linkUrl = value; }
        }

    }
}
