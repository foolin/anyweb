using System;
using System.Collections.Generic;
using System.Text;

using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class Currency:IdObject
    {

        public Currency()
        {
 
        }

        public Currency(DataRow dr)
        {
            this.ID = (int)dr["CurrencyID"];
            this._name = (string)dr["Name"];
            this._denotation = (string)dr["Denotation"];
            this._exchangeRate = (decimal)dr["ExchangeRate"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._country = (string)dr["Country"];

        }

        /// <summary>
        /// 货币名称
        /// </summary>
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// 货币符号
        /// </summary>
        private string _denotation;

        public string Denotation
        {
            get { return _denotation; }
            set { _denotation = value; }
        }

        /// <summary>
        /// 与人民币汇率
        /// </summary>
        private decimal _exchangeRate;

        public decimal ExchangeRate
        {
            get { return _exchangeRate; }
            set { _exchangeRate = value; }
        }

        /// <summary>
        /// 货币所属国家
        /// </summary>
        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _createAt;

        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }
	
	
	
	
	


    }


}
