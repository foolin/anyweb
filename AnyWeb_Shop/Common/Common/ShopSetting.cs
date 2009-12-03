using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

namespace Common.Common
{
    public class ShopSetting : IdObject
    {
        public ShopSetting() { }

        public ShopSetting(DataRow dr)
        {
            this.ID = (int)dr["SettingID"];
            this._service = dr["Service"] == System.DBNull.Value ? "" : (string)dr["Service"];
            this._shopId = (int)dr["ShopID"];
            
        }

        private string _service;
        /// <summary>
        /// 服务条款
        /// </summary>
        public string Service
        {
            get { return _service; }
            set { _service = value; }
        }

        private int _shopId;
        /// <summary>
        /// 商城编号
        /// </summary>
        public int ShopID
        {
            get { return _shopId; }
            set { _shopId = value; }
        }

    }
}
