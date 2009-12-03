using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class Agio:IdObject
    {
        public Agio()
        {
 
        }

        public Agio(DataRow dr)
        {
            this.ID = (int)dr["AgioID"];
            this._type = (int)dr["Type"];
            this._shopID = (int)dr["ShopID"];
            this._money = (double)dr["Money"];
            this._category = (int)dr["Category"];
            this._agiomoney = (double)dr["Agio"];
            
        }

        /// <summary>
        /// �ۿ۷�ʽ
        /// </summary>
        private int _type;

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// ����ģ��
        /// </summary>
        private int _category;

        public int Category
        {
            get { return _category; }
            set { _category = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        private double _money;
        public double Money
        {
            get { return _money; }
            set { _money = value; }
        }

        /// <summary>
        /// �����ۿ�
        /// </summary>
        private double _agiomoney;

        public double Agiomoney
        {
            get { return _agiomoney; }
            set { _agiomoney = value; }
        }

        /// <summary>
        ///  �̵���
        /// </summary>
        private int _shopID;

        public int ShopID
        {
            get { return _shopID; }
            set { _shopID = value; }
        }


        private Shop _ofShop;

        public Shop OfShop
        {
            get { return _ofShop; }
            set { _ofShop = value; }
        }
	
	
	
	
    }
}
