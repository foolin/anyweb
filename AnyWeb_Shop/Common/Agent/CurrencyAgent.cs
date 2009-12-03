using System;
using System.Collections.Generic;
using System.Text;

using Studio.Data;
using Studio.Array;

using System.Collections;
using System.Data;
using Common.Common;

namespace Common.Agent
{
    public class CurrencyAgent:AgentBase
    {

        /// <summary>
        /// 根据商店获取商店设置支付货币
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public ArrayList GetSettingCurrencyByShop()
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetSetting_CurrencyByShop",
                                this.NewParam("@ShopID", ShopInfo.ID));
            }

            ArrayList list = new ArrayList();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Setting_Currency sc = new Setting_Currency(dr);

                    Currency c = new Currency();
                    c.Name = (string)dr["Name"];
                    c.Denotation = (string)dr["Denotation"];
                    c.Country = (string)dr["Country"];
                    c.ExchangeRate = (decimal)dr["ExchangeRate"];

                    sc.OfCurrency = c;

                    list.Add(sc);
                }
            }

            return list;
        }

        /// <summary>
        /// 获取全部货币信息
        /// </summary>
        /// <returns></returns>
        public ArrayList GetCurrencyList()
        {
            DataSet ds = new DataSet();

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetCurrencyList",
                                    this.NewParam("@ShopID",ShopInfo.ID));
            }

            ArrayList list = new ArrayList();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new Currency(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 删除支付货币
        /// </summary>
        /// <param name="setid"></param>
        /// <returns></returns>
        public int DeleteSetCurrency(int setid)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
               return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_DeleteSettring_Currency",
                                    this.NewParam("@SetID", setid));
            }
        }

        public int InsertSetCurrency(int currencyid)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_InsertSettring_Currency",
                                        this.NewParam("@CurrencyID", currencyid),
                                        this.NewParam("@ShopID", ShopInfo.ID));
            }
        }
    }
}
