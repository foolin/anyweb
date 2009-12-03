using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Studio.Data;
using Common.Common;

namespace Common.Agent
{
    public class AfficheAgent:AgentBase
    {
     
        /// <summary>
        /// 获得公告列表
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetAfficheList(int pagesize , int pageno , int memberID,out int recordCount)
        {
            DataSet ds;
            IDbDataParameter record = this.NewParam( "@RecordCount" , 0 , DbType.Int32 , 8 , true );
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetAfficheList" ,
                                   this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                   this.NewParam( "@PageSize" , pagesize ) ,
                                   this.NewParam( "@PageNo" , pageno ) ,
                                   this.NewParam("@MemberID", memberID),
                                   record );
            }
            recordCount = (int)record.Value;
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                Affiche a = new Affiche();

                a.ID = (int)dr["AfficheID"];
                a.Title = (string)dr["Title"];
                a.CreateAt = (DateTime)dr["CreateAt"];
                a.Type = (int)dr["Type"];
                a.MemberID = (int)dr["MemberID"];
                a.OfShop = ShopInfo;
                list.Add( a );
            }
            return list;
        }


          /// <summary>
          /// 获得系统公告列表
          /// </summary>
          /// <param name="pagesize"></param>
          /// <param name="pageno"></param>
          /// <param name="recordCount"></param>
          /// <returns></returns>
        public ArrayList GetAfficheListweb(int pagesize, int pageno,out int recordCount)
        {
            ArrayList list = GetAfficheListweb(pagesize, pageno, 0,0,out recordCount);

            return list;
        }

        /// <summary>
        /// 获取个人公告列表
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="userid"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetAfficheListweb(int pagesize, int pageno,int userid,int type, out int recordCount)
        {
            DataSet ds;
            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetAfficheListweb",
                                   this.NewParam("@ShopID", ShopInfo.ID),
                                   this.NewParam("@PageSize", pagesize),
                                   this.NewParam("@PageNo", pageno),
                                   this.NewParam("@UserID",userid),
                                   this.NewParam("@Type",type),
                                   record);
            }
            recordCount = (int)record.Value;
            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Affiche a = new Affiche();

                a.ID = (int)dr["AfficheID"];
                a.Title = (string)dr["Title"];
                a.CreateAt = (DateTime)dr["CreateAt"];
                a.Type = (int)dr["Type"];
                a.MemberID = (int)dr["MemberID"];
                a.OfShop = ShopInfo;
                list.Add(a);
            }
            return list;
        }

      


        /// <summary>
        /// 获得单个公告
        /// </summary>
        /// <param name="affID"></param>
        /// <returns></returns>
        public Affiche GetAfficheByID(int affID)
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetAfficheByID" ,
                                   this.NewParam( "@AfficheID" ,affID ) );
            }
            if ( ds.Tables[0].Rows.Count > 0 )
            {
                return new Affiche( ds.Tables[0].Rows[0] );
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 添加公告
        /// </summary>
        /// <param name="af"></param>
        /// <returns></returns>
        public int AfficheAdd(Affiche af)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return  db.ExecuteProcedure( "Shop_AfficheAdd" ,
                                    this.NewParam( "@Title" , af.Title ) ,
                                    this.NewParam( "@Context" , af.Context ) ,
                                    this.NewParam( "@Type" , af.Type ) ,
                                    this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                    this.NewParam( "@MemberID" , af.MemberID ) );
            }
        }

        /// <summary>
        /// 修改公告
        /// </summary>
        /// <param name="af"></param>
        /// <returns></returns>
        public int AfficheUpdate(Affiche af)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return  db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_AfficheUpdate" ,
                                    this.NewParam( "@Title" , af.Title ) ,
                                    this.NewParam( "@Context" , af.Context ) ,
                                    this.NewParam( "@Type" , af.Type ) ,
                                    this.NewParam("@AfficheID",af.ID));
            }
        }

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="af"></param>
        /// <returns></returns>
        public int AfficheDelete(Affiche af)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_AfficheDelete" ,
                                    this.NewParam( "@AfficheID" , af.ID ) );
            }
        }
        /// <summary>
        /// 用户批量删除公告
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int AfficheDeletes(string ids, int count)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_AfficheUserDelete",
                                            this.NewParam("@STRING", ids),
                                            this.NewParam("@COUNT", count));
            }
        }
    }
}
