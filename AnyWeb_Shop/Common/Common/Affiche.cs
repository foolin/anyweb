using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    /// <summary>
    /// 公告实体
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
        /// 公告名称
        /// </summary>
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private int _memberID;
        /// <summary>
        /// 会员编号
        /// </summary>
        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }
        }

        private int _shopID;
        /// <summary>
        /// 商城编号
        /// </summary>
        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }


        /// <summary>
        /// 公告内容
        /// </summary>
        private string _context;

        public string Context
        {
            get { return _context; }
            set { _context = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _createat;

        public DateTime CreateAt
        {
            get { return _createat; }
            set { _createat = value; }
        }

        /// <summary>
        /// 所属商店
        /// </summary>
        private Shop _ofShop;

        public Shop OfShop
        {
            get { return _ofShop; }
            set { _ofShop = value; }
        }

        private int _type;
        /// <summary>
        /// 公告类型
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }
	
        /// <summary>
        /// 连接路径
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
