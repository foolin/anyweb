using System;
using System.Collections.Generic;
using System.Text;
using Common.Common;
using Studio.Data;
using System.Data;

namespace Common.Agent
{
    public class StatAgent : AgentBase
    {
        public int GetNewStatByTypeID(int typeid)
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds=db.GetDataSet( CommandType.StoredProcedure , "Shop_GetStatInfo",
                               this.NewParam( "@ShopID",ShopInfo.ID ),
                               this.NewParam("@TypeID",typeid));
            }

            if ( ds.Tables[0].Rows.Count > 0 )
            {
                Stat s = new Stat();
                s.Number = (int)ds.Tables[0].Rows[0]["Number"];
                return s.Number;
            }
            else
            {
                return 0;
            }
        }
    }
}
