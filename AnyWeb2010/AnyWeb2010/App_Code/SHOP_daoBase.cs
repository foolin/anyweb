using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using AnyWeb.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWeb.AW_DL
{
    /// <summary>
    ///SHOP_daoBase 的摘要说明
    /// </summary>
    public class SHOP_daoBase : Dao_Base
    {
        public SHOP_daoBase()
        {
            this.DBType = Studio.Data.DatabaseType.SqlServer;
            this.ConnectionString = ConfigurationManager.ConnectionStrings["SHOP_DB"].ConnectionString;
        }

        //public int funcNewID()
        //{
        //    using (IDbExecutor db = this.NewExecutor())
        //    {
        //        return db.ExecuteProcedure("s_GetNewID", this.NewParam("@TableName", this._propTable));
        //    }
        //}
    }

}
