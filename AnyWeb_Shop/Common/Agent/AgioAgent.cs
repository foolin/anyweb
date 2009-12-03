using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Studio.Data;
using System.Data;
using Common.Common;
namespace Common.Agent
{
    public class AgioAgent : AgentBase
    {
        
        /// <summary>
        /// 获取推荐折扣
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public Agio GetAgio(int category,int shopid)
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetAgio",
                                   this.NewParam("@ShopID", shopid),
                                   this.NewParam("@Category",category));
            }

            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
                return new Agio(ds.Tables[0].Rows[0]);
        }

        /// <summary>
        /// 设置推荐折扣
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int SetAgio(Agio a)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_SetAgio",
                                            this.NewParam("@AgioID", a.ID),
                                            this.NewParam("@Type", a.Type),
                                            this.NewParam("@Category", a.Category),
                                            this.NewParam("@Money", a.Money),
                                            this.NewParam("@Agio", a.Agiomoney),
                                            this.NewParam("@ShopID", ShopInfo.ID));
            }
        }



    }


}
