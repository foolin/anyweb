using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class Complaints:IdObject
    {

        public Complaints()
        { 
        }

        public Complaints(DataRow dr)
        {
            this.ID = (int)dr["ComplaintsID"];
            this.Title = (string)dr["Title"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._content = (string)dr["Content"];
            this._userID = (int)dr["UserID"];
            this._shopID = (int)dr["ShopID"];
            this._status = (int)dr["Status"];
            this._afficheID = (int)dr["AfficheID"];
            this.OfUser = new User();
            this.OfShop = new Shop();
        }


        /// <summary>
        /// 用户编号
        /// </summary>
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        /// <summary>
        /// 用户
        /// </summary>
        private User  _ofUser;

        public User  OfUser
        {
            get { return _ofUser; }
            set { _ofUser = value; }
        }

        private Affiche _ofAffiche;

        public Affiche OfAffiche
        {
            get { return _ofAffiche; }
            set { _ofAffiche = value; }
        }

        private int _status;
        /// <summary>
        /// 处理状态
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }


        /// <summary>
        /// 投诉时间
        /// </summary>
        private DateTime _createAt;

        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }


        /// <summary>
        /// 投诉内容
        /// </summary>
        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
	
        /// <summary>
        /// 投诉原因
        /// </summary>
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        /// <summary>
        /// 投诉商店
        /// </summary>
        private Shop _ofShop;

        public Shop OfShop
        {
            get { return _ofShop; }
            set { _ofShop = value; }
        }

        /// <summary>
        /// 投诉商店编号
        /// </summary>
        private int _shopID;

        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }


        private int _afficheID;
        /// <summary>
        /// 公告编号
        /// </summary>
        public int AfficheID
        {
            get { return _afficheID; }
            set { _afficheID = value; }
        }

	
    }
}
