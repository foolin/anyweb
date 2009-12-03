using System;
using System.Collections.Generic;
using System.Text;
using Common.Common;
using Studio.Data;
using System.Data;
using System.Collections;

namespace Common.Agent
{
    public class ChangeNoteAgent:AgentBase
    {
        /// <summary>
        /// 添加兑换记录
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AddChangeNote(ChangeNote c)
        { 
            using ( IDbExecutor db = this.NewExecutor() )
            {
               return db.ExecuteProcedure("Shop_ChangeNoteAdd" ,
                                    this.NewParam("@UserID",c.UserID),
                                    this.NewParam( "@ChangeID" , c.ChangeID ) );
            }
        }

        /// <summary>
        /// 获得用户兑换记录
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public ArrayList GetUserChangeNote(int userid,int status,int pagesize,int pageno,out int recordCount)
        {
            DataSet ds;
            IDbDataParameter record = this.NewParam( "@RecordCount" , 0 , DbType.Int32 , 8 , true );
            using ( IDbExecutor db = this.NewExecutor() )
            { 
                ds=db.GetDataSet(CommandType.StoredProcedure,"Shop_GetUserChangeNote",
                            this.NewParam("@UserID",userid),
                            this.NewParam("@PageSize",pagesize ),
                            this.NewParam("@PageNo",pageno ),
                            this.NewParam("@Status",status),
                            record );

                recordCount = (int)record.Value;
            }
            
            ArrayList list = new ArrayList();

            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                ChangeNote cn = new ChangeNote();
                cn.ID = (int)dr["ChangeNoteID"];
                cn.OfChangeGoods= new ChangeGoods();

                cn.SendStatus = (int)dr["SendStatus"];
                cn.Score = (int)dr["Score"];
                cn.OfChangeGoods.Name = (string)dr["ChangeName"];
                cn.OfChangeGoods.Image = (string)dr["Image"];
                cn.NoteTime = (DateTime)dr["NoteTime"];
                cn.OfChangeGoods.Price = (double)dr["Price"];

                list.Add( cn );

            }
            return list;
        }


        /// <summary>
        /// 根据订单编号获得数据
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public ArrayList GetChangeNoteByOrderID(int orderID)
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetChangeNote" ,
                            this.NewParam( "@OrderID" ,  orderID ) );
            }
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                ChangeNote cn = new ChangeNote();
                cn.ID = (int)dr["ChangeNoteID"];

                cn.OfChangeGoods = new ChangeGoods();
                cn.OfChangeGoods.Name = (string)dr["ChangeName"];
                cn.OfChangeGoods.Image = (string)dr["Image"];
                cn.NoteTime = (DateTime)dr["NoteTime"];
                cn.OfChangeGoods.Score = (int)dr["Score"];
                cn.OfChangeGoods.Price = (double)dr["Price"];

                list.Add( cn );

            }
            return list;
        }


        /// <summary>
        /// 将用户积分礼品并入订单
        /// </summary>
        /// <param name="changeids"></param>
        /// <param name="orderid"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int ChangeNoteOrder(string changeids,int orderid,int num)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ChagenOrderIDUpdate" ,
                                     this.NewParam( "@ChangeIDs" ,changeids  ) ,
                                     this.NewParam( "@OrderID" ,  orderid ),
                                     this.NewParam( "@Num" , num ) );
            }
        }


        /// <summary>
        /// 删除用户礼品－未发货
        /// </summary>
        /// <param name="changenoteid"></param>
        /// <returns></returns>
        public int DeleteChangeNote(int changenoteid)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ChangeNoteDelete" ,
                                     this.NewParam( "@ChangeNoteID" , changenoteid ) );
            }
        }
    }
}
