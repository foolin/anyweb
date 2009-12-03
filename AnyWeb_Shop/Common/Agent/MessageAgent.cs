using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Common.Framework;
using Common.Common;

using Studio.Data;
using Studio.Array;
using System.Web;


namespace Common.Agent
{
    public class MessageAgent: AgentBase
    {
        /// <summary>
        /// 获得留言列表
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetMessageList(int pagesize,int pageno,out int recordCount)
        {
            DataSet ds;
            IDbDataParameter record = this.NewParam( "@RecordCount" , 0 , DbType.Int32 , 8 , true );
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetMessageList" ,
                                this.NewParam( "@PageSize",pagesize ),
                                this.NewParam( "@PageNo",pageno ),
                                this.NewParam("@ShopID",ShopInfo.ID),
                               record);
            }
            recordCount = (int)record.Value;
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                list.Add( new Message(dr));
            }
            return list;
        }

        /// <summary>
        /// 获取用户留言信息
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetUserMessage(int pagesize, int pageno, out int recordCount)
        {
            DataSet ds;
            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetUserMessage",
                                this.NewParam("@PageSize", pagesize),
                                this.NewParam("@PageNo", pageno),
                                this.NewParam("@ShopID",ShopInfo.ID),
                                this.NewParam("@UserID",UserInfo.ID),
                               record);
            }
            recordCount = (int)record.Value;
            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Message(dr));
            }
            return list;
        }

        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int MessageAdd(Message m)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
              return   db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_MessageAdd" ,
                                    this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                    this.NewParam("@UserID",UserInfo == null ? 0:UserInfo.ID),
                                    this.NewParam("@UserName",m.UserName),
                                    this.NewParam("@IP",m.IP),
                                    this.NewParam("@Area",m.Area),
                                    this.NewParam("@Content",m.Content));
            }
        }

        /// <summary>
        /// 回复内容
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public Message GetReplay(int mid)
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetMessageReplay" ,
                                    this.NewParam("@MsgID",mid));
            }
            if ( ds.Tables[0].Rows.Count > 0 )
            {
                Message m = new Message();
                m.ID = (int)ds.Tables[0].Rows[0]["MsgID"];
                m.UserName = (string)ds.Tables[0].Rows[0]["UserName"];
                m.Content = (string)ds.Tables[0].Rows[0]["Content"];
                m.CreateAt = (DateTime)ds.Tables[0].Rows[0]["CreateAt"];
                m.ReplayAt = ds.Tables[0].Rows[0]["ReplayAt"] == System.DBNull.Value ? DateTime.MinValue : (DateTime)ds.Tables[0].Rows[0]["ReplayAt"];
                m.Replay = ds.Tables[0].Rows[0]["Replay"] == System.DBNull.Value ? "" : (string)ds.Tables[0].Rows[0]["Replay"];

                return m;
            }
            else
            {
                return null;
            }
        
        }

        /// <summary>
        /// 修改回复
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public int UpdateReplay(Message m)
        { 
            
             using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_MessageReplayUpdate" ,
                                    this.NewParam("@MsgID",m.ID),
                                    this.NewParam("@Replay",m.Replay));
             }
        }

        /// <summary>
        /// 批量删除留言
        /// </summary>
        /// <param name="mids"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int DeleteMessage(string mids , int num)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_MessageDelete" ,
                                        this.NewParam( "@MsgIDs" , mids ) ,
                                        this.NewParam( "@Num" , num ) );
            }
        }
    }

}
