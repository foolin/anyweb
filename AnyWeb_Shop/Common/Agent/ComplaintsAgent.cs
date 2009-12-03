using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using System.Collections;
using Common.Common;

namespace Common.Agent
{
    public class ComplaintsAgent : AgentBase
    {
        /// <summary>
        /// 发起投诉
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public int ComplaintsAdd(string title,string content)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_ComplaintsAdd",
                                this.NewParam("@UserID", UserInfo.ID),
                                this.NewParam("@ShopID", ShopInfo.ID),
                                this.NewParam("@Title", title),
                                this.NewParam("@Content", content));
            }
        }

        /// <summary>
        /// 投诉列表
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetComplaintsList(int pagesize,int pageno,out int recordCount)
        {
            DataSet ds;
            IDbDataParameter records = this.NewParam( "@RecordCount" , 0 , DbType.Int32 , 8 , true );
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetComplaintsList" ,
                                this.NewParam( "@PageSize" , pagesize ) ,
                                this.NewParam( "@PageNo" , pageno ) ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                records );
            }
            recordCount = (int)records.Value;
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                Complaints cp = new Complaints( dr );
                cp.OfUser = new User();
                cp.OfUser.MemberName = (string)dr["MemberName"];
                list.Add( cp );
            }
            return list;
        }

        /// <summary>
        /// 获取单个投诉
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public Complaints GetComplaintsByID(int cid)
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetComplaintsByID" ,
                            this.NewParam( "@Cid" , cid ) );
            }
            if ( ds.Tables[0].Rows.Count > 0 )
            {
               return  new Complaints( ds.Tables[0].Rows[0] );
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 处理投诉
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public int UpdateComplaints(int cid,int afficheid)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
               return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ComplaintsUpdata" ,
                                    this.NewParam( "@ComplaintsID" , cid ),
                                    this.NewParam("@AfficheID",afficheid));
            }
        }

        /// <summary>
        /// 批量删除投诉
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public int DeleteComplaints(string ids , int number)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ComplaintsDelete" ,
                                     this.NewParam( "@ComplaintsID" , ids ) ,
                                     this.NewParam( "@Num" , number ) );
            }
        }

    }
}
