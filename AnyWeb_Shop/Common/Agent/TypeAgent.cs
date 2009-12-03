using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Studio.Array;
using Studio.Data;

using Common.Framework;
using System.Collections;
using Common.Common;

namespace Common.Agent
{
    /// <summary>
    /// 模版类别
    /// </summary>
    public class TypeAgent:AgentBase
    {
        /// <summary>
        /// 获取所有模版类别
        /// </summary>
        /// <returns></returns>
        public bool GetTypeAll()
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetTypeList");
            }
            SysSetting.GetSetting().Typies = new ObjectList();
            foreach (DataRow dr in ds.Tables[0].Rows)
                SysSetting.GetSetting().Typies.Add(new Common.Typies(dr));
            return true;
        }

        /// <summary>
        /// 获得类别列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetTypeList()
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetTypeList" );
            }
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                list.Add( new Typies( dr ) );
            }
            return list;
        }
    }

}
