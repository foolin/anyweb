using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class Advertisement:IdObject
    {
        public Advertisement()
        { 
        }

        public Advertisement(DataRow dr)
        {
            this.ID = (int)dr["AdID"];
            this._adTitle = (string)dr["AdTitle"];
            this._adContent = dr["AdContent"] == System.DBNull.Value ? "" : (string)dr["AdContent"];
            this._createAt = (DateTime)dr["CreateAt"];
            this._sort = (int)dr["Sort"];

            this._ofShop = new Shop();
 
        }
        /// <summary>
        /// ����
        /// </summary>
        private string _adTitle;

        public string AdTitle
        {
            get { return _adTitle; }
            set { _adTitle = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        private string _adContent;

        public string AdContent
        {
            get { return _adContent; }
            set { _adContent = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        private int _sort;

        public int Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        private Shop _ofShop;

        public Shop OfShop
        {
            get { return _ofShop; }
            set { _ofShop = value; }
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
	
    }
}
