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
        /// ��Ʒ��ϸ��Ϣ
        /// </summary>
        private Goods _ofGoods;

        public Goods OfGoods
        {
            get { return _ofGoods; }
            set { _ofGoods = value; }
        }

        /// <summary>
        /// ��Ա��Ϣ
        /// </summary>
        private User _ofMember;

        public User OfMember
        {
            get { return _ofMember; }
            set { _ofMember = value; }
        }

        /// <summary>
        /// �ղ�ʱ��
        /// </summary>
        private DateTime _createAt;

        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }
	
	
	
    }
}
