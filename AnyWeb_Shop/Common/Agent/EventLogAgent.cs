using System;
using System.Collections.Generic;
using System.Text;
using Common.Framework;
using System.Web;
using Studio.Data;
using Common.Common;
using System.Data;
using System.Collections;

namespace Common.Agent
{
    /// <summary>
    /// ��־��ҵ�����ݲ���
    /// </summary>
    public class EventLogAgent : AgentBase
    {
        
        /// <summary>
        /// �����־
        /// </summary>
        /// <param name="el"></param>
        public void AddLog(EventLog el)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_AddLog",
                                    this.NewParam("@ShopID", el.ShopID),
                                    this.NewParam("@EventID", (short)el.EventType),
                                    this.NewParam("@EventName", el.EventName),
                                    this.NewParam("@Description", el.Description),
                                    this.NewParam("@FromIP", el.FromIP));
            }
        }

        /// <summary>
        /// �����־
        /// </summary>
        public void ClearLog()
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "shop_ClearLog");
            }
        }

        /// <summary>
        /// ���������־
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="eventid"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public ArrayList GetLogList(int pagesize,int pageno,int eventid ,out int record )
        { 
      
            DataSet ds;
            IDbDataParameter records=this.NewParam("@RecordCount",0,DbType.Int32,8,true);
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetLogList" ,
                                this.NewParam( "@PageSize" , pagesize ) ,
                                this.NewParam( "@PageNo" , pageno ) ,
                                this.NewParam( "@EventID" , eventid ) ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                records );
            }
            record = (int)records.Value;
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                list.Add( new EventLog( dr ) );
            }

            return list;
        }

    }
}
