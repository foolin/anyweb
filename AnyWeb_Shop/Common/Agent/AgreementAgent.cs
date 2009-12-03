using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using Common.Common;
using System.Collections;

namespace Common.Agent
{
    public class AgreementAgent : AgentBase
    {
        /// <summary>
        /// 修改用户协议
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int UpdateAgreement(string content)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_UpdateAgreement",
                               this.NewParam("@Content", content),
                               this.NewParam("@ShopID", ShopInfo.ID));
            }
        }

        /// <summary>
        /// 获取用户注册协议
        /// </summary>
        /// <returns></returns>
        public Agreement GetAgreement()
        {
            DataSet ds = new DataSet();

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetAgreement",
                                this.NewParam("@ShopID",ShopInfo.ID));
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;

            }
            else
            {
                Agreement a = new Agreement(ds.Tables[0].Rows[0]);
                a.OfShop = ShopInfo;
                return a; 
            }

        }
    }
}
