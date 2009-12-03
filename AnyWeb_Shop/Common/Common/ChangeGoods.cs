using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public  class ChangeGoods : IdObject
    {
        public ChangeGoods() { }

        public ChangeGoods(DataRow dr)
        {
            this.ID = (int)dr["ChangeID"];
            this._name = (string)dr["ChangeName"];
            this._startTime = (DateTime)dr["StartTime"];
            this._endTime = (DateTime)dr["EndTime"];
            this._price = (double)dr["Price"];
            this._image = (string)dr["Image"];
            this._shopID = (int)dr["ShopID"];
            this._score = (int)dr["Score"];
            this._intro = dr["Intro"] == System.DBNull.Value ? "" : (string)dr["Intro"];
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    

        private DateTime  _startTime;

        public DateTime  StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        private DateTime _endTime;

        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        private double _price;

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

        private int _shopID;

        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }

        private int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        private string _intro;

        public string Intro
        {
            get { return _intro; }
            set { _intro = value; }
        }

        private int _quantity;
        /// <summary>
        /// 兑换总数
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }


    }
}
