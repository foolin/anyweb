using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class Stat : IdObject
    {
        public Stat() { }

        public Stat(DataRow dr)
        {
            this.ID = (int)dr["StatID"];
            this._type = (int)dr["Type"];
            this._creatAt = (DateTime)dr["CreateAt"];
            this._number = (int)dr["Number"];
            this._shopID = (int)dr["ShopID"];
        }

        private int _type;
        /// <summary>
        /// 类型 0-流量 1－评论 2－留言 3－订单 4－用户
        /// </summary>
        public int Type
        {
            get { return _type; }
            set { _type = value; }
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

        private int _number;
        /// <summary>
        /// 统计总数
        /// </summary>
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        private DateTime _creatAt;
        /// <summary>
        /// 统计时间
        /// </summary>
        public DateTime CreateAt
        {
            get { return _creatAt; }
            set { _creatAt = value; }
        }

    }
}
