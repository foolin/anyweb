using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class Setting_Currency:IdObject
    {
        public Setting_Currency()
        { 
        }
        public Setting_Currency(DataRow dr)
        {
            this.ID = (int)dr["SetID"];
            this._currencyID = (int)dr["CurrencyID"];
            this._shopID = (int)dr["ShopID"];
            this._createAt = (DateTime)dr["CreateAt"];
        }

        /// <summary>
        /// 货币编号
        /// </summary>
        private int _currencyID;

        public int CurrencyID
        {
            get { return _currencyID; }
            set { _currencyID = value; }
        }


        private Currency _ofCurrency;

        public Currency OfCurrency
        {
            get { return _ofCurrency; }
            set { _ofCurrency = value; }
        }
	

        /// <summary>
        /// 商店编号
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

        /// <summary>
        /// 设置时间 
        /// </summary>
        private DateTime  _createAt;

        public DateTime  CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }
	

	
	
    }


}
