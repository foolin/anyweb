using System;
using System.Collections.Generic;
using System.Text;
using Common.Common;
using System.Data;
using Studio.Data;

namespace Common.Agent
{
   public  class ShopSettingAgent: AgentBase
    {
        /// <summary>
        /// 获得商城相关信息
        /// </summary>
        /// <returns></returns>
        public ShopSetting GetShopSettingInfo()
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetShopSettingInfo" ,
                            this.NewParam( "@ShopID" , ShopInfo.ID) );
            }
            if ( ds.Tables[0].Rows.Count > 0 )
            {
                return new ShopSetting( ds.Tables[0].Rows[0] );
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 修改页脚
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int UpdateService(ShopSetting st)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ServiceUpdate" ,
                                        this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                        this.NewParam( "@Service", st.Service));


            }
        }
    }
}
