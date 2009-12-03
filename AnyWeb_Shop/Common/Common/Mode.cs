using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;
using Common.Agent;

namespace Common.Common
{
    public class Mode:IdObject
    {
        public Mode()
        { 
        }
        public Mode(DataRow dr)
        {
            this.ID = (int)dr["ModeID"];
            this._shopID = (int)dr["ShopID"];
            this._type =  Convert.ToInt32(dr["Type"]);
            this._createAt = (DateTime)dr["CreateAt"];
            this._content = (string)dr["Content"];
            this._title = (string)dr["Title"];
            this._poundage = (double)dr["Poundage"];
            this._mostPoundage = (double)dr["MostPoundage"];
        }

        /// <summary>
        /// �̵���
        /// </summary>
        private int _shopID;

        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }

        /// <summary>
        /// ֧������������
        /// </summary>
        private string _content;

        public string Content
        {
            get { return _content; }
            set { _content = value; }
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

        /// <summary>
        ///���1֧����ʽ��2���ͷ�ʽ
        /// </summary>
        private int _type;

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        private double _poundage;

        public double Poundage
        {
            get { return _poundage; }
            set { _poundage = value; }
        }

        /// <summary>
        /// ����շ�
        /// </summary>
        private double _mostPoundage;

        public double MostPoundage
        {
            get { return _mostPoundage; }
            set { _mostPoundage = value; }
        }

        /// <summary>
        /// ֧���ܽ��
        /// </summary>
        public double MathPayMent
        {
            get
            {
                Order o = (new OrderAgent()).GetShopCart();
                double MathPoundage = o.MathPrice * this.Poundage / 1000;

                if (MathPoundage < this.MostPoundage)
                {
                    return MostPoundage;
                }
                else
                {
                    return MathPoundage;
                }
            }
        }

        /// <summary>
        /// �����ܽ��
        /// </summary>
        public double MathDeliver
        {
            get 
            {
                Order o = (new OrderAgent()).GetShopCart();
                double MathPoundage = o.MathWeight * this.Poundage;

                if (MathPoundage < this.MostPoundage)
                {
                    return MostPoundage;
                }
                else
                {
                    return MathPoundage;
                }
            }
        }
    }
}
