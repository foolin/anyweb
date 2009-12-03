using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class Collection:IdObject
    {
        public Collection()
        { 
        }

        public Collection(DataRow dr)
        {
            this.ID = (int)dr["CID"];
            this._createAt = (DateTime)dr["CreateAt"];
        }

        /// <summary>
        /// 商品详细信息
        /// </summary>
        private Goods _ofGoods;

        public Goods OfGoods
        {
            get { return _ofGoods; }
            set { _ofGoods = value; }
        }

        /// <summary>
        /// 会员信息
        /// </summary>
        private User _ofMember;

        public User OfMember
        {
            get { return _ofMember; }
            set { _ofMember = value; }
        }

        /// <summary>
        /// 收藏时间
        /// </summary>
        private DateTime _createAt;

        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }
	
	
	
    }
}
