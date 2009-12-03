using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using Common.Common;
using System.Collections;

namespace Common.Agent
{
    public class ChangeGoodsAgent:AgentBase
    {
        /// <summary>
        /// 获得兑换商品列表 (前台)
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetChangeGoodsList(int pagesize,int pageno,out int recordCount)
        { 
            DataSet ds;
            IDbDataParameter record = this.NewParam( "@RecordCount" , 0 , DbType.Int32 , 8 , true );
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetChangeGoodsList" ,
                                this.NewParam( "@PageSize" , pagesize ) ,
                                this.NewParam( "@PageNo" , pageno ) ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ),
                                record);
            }
            recordCount = (int)record.Value;
            ArrayList list=new ArrayList();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                ChangeGoods cg = new ChangeGoods();
                cg.ID = (int)dr["ChangeID"];
                cg.ShopID = (int)dr["ShopID"];
                cg.Name = (string)dr["ChangeName"];
                cg.EndTime = (DateTime)dr["EndTime"];
                cg.StartTime = (DateTime)dr["StartTime"];
                cg.Price = (double)dr["Price"];
                cg.Image = (string)dr["Image"];
                cg.Score = (int)dr["Score"];
                list.Add( cg);
            }
            return list;
        }

        /// <summary>
        /// 获得兑换商品列表 (后台)
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetChangeGoodsAll(int pagesize,int pageno,out int recordCount)
        { 
            DataSet ds;
            IDbDataParameter record = this.NewParam( "@RecordCount" , 0 , DbType.Int32 , 8 , true );
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetChangeGoodsAll" ,
                                this.NewParam( "@PageSize" , pagesize ) ,
                                this.NewParam( "@PageNo" , pageno ) ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ),
                                record);
            }
            recordCount = (int)record.Value;
            ArrayList list=new ArrayList();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                ChangeGoods cg = new ChangeGoods();
                cg.ID = (int)dr["ChangeID"];
                cg.ShopID = (int)dr["ShopID"];
                cg.Name = (string)dr["ChangeName"];
                cg.EndTime = (DateTime)dr["EndTime"];
                cg.StartTime = (DateTime)dr["StartTime"];
                cg.Price = (double)dr["Price"];
                cg.Image = (string)dr["Image"];
                cg.Score = (int)dr["Score"];
                list.Add( cg);
            }
            return list;
        }

        /// <summary>
        /// 获取单个积分礼品
        /// </summary>
        /// <param name="linkid"></param>
        /// <returns></returns>
        public ChangeGoods GetChangeGoodsByID(int cid)
        {

            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetChangeGoodsByID" ,
                                this.NewParam( "@ChangeID" , cid ) );
            }
            if ( ds.Tables[0].Rows.Count > 0 )
            {
                return new ChangeGoods( ds.Tables[0].Rows[0] );

            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 修改兑换商品
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int UpdateChangeGoods(ChangeGoods c)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ChangeGoodsUpdate" ,
                                    this.NewParam( "@ChangeID" ,c.ID) ,
                                    this.NewParam( "@StartTime" , c.StartTime ) ,
                                    this.NewParam( "@EndTime" , c.EndTime ) ,
                                    this.NewParam( "@Price" , c.Price ) ,
                                    this.NewParam( "@Image" , c.Image ) ,
                                    this.NewParam( "@ChangeName" , c.Name ),
                                    this.NewParam( "@Score",c.Score),
                                    this.NewParam("@Intro",c.Intro));
            }

        }

        /// <summary>
        /// 添加兑换商品
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int AddChangeGoods(ChangeGoods c)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ChangeGoodsAdd" ,
                                    this.NewParam( "@ShopID" ,ShopInfo.ID ) ,
                                    this.NewParam( "@EndTime" , c.EndTime ) ,
                                    this.NewParam( "@Price" , c.Price ) ,
                                    this.NewParam( "@Image" , c.Image ) ,
                                     this.NewParam("@Score",c.Score),
                                    this.NewParam( "@ChangeName" , c.Name ) ,
                                    this.NewParam( "@Intro" , c.Intro ) );
            }

        }

        /// <summary>
        /// 删除积分礼品
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int DeleteChangeGoods(ChangeGoods c)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ChangeGoodsDelete" ,
                                    this.NewParam( "@ChangeID" ,c.ID) );
            }

        }


       /// <summary>
        /// 获得积分礼品流量
       /// </summary>
       /// <param name="pagesize"></param>
       /// <param name="pageno"></param>
       /// <param name="changename"></param>
       /// <param name="recordCount"></param>
       /// <returns></returns>
        public ArrayList GetChangeGoodsStat(int pagesize , int pageno ,string changename, out int recordCount)
        {
            DataSet ds;
            IDbDataParameter record = this.NewParam( "@RecordCount" , 0 , DbType.Int32 , 8 , true );
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetChangegoodsStat" ,
                                this.NewParam("@ChangeName",changename),
                                this.NewParam( "@PageSize" , pagesize ) ,
                                this.NewParam( "@PageNo" , pageno ) ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                record );
            }
            recordCount = (int)record.Value;
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                ChangeGoods cg = new ChangeGoods();
                cg.ID = (int)dr["ChangeID"];
                cg.Name = (string)dr["ChangeName"];
                cg.Price = (double)dr["Price"];
                cg.Quantity = (int)dr["Number"];
                cg.Score = (int)dr["Score"];
                list.Add( cg );
            }
            return list;

        }


    }
}
