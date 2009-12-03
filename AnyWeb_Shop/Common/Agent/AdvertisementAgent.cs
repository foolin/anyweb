using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using Common.Common;
using System.Collections;
namespace Common.Agent
{
    public class AdvertisementAgent:AgentBase
    {

        /// <summary>
        /// 获得广告列表
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="recordcount"></param>
        /// <returns></returns>
        public ArrayList GetAdList(int pagesize,int pageno,out int recordcount)
        {
            DataSet ds;

            IDbDataParameter record = this.NewParam( "@RecordCount" , 0 , DbType.Int32 , 8 , true );
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds=db.GetDataSet( CommandType.StoredProcedure , "Shop_GetAdvertisementList" ,
                                this.NewParam( "@PageSize" , pagesize ) ,
                                this.NewParam( "@PageNo",pageno ),
                                this.NewParam( "@ShopID",ShopInfo.ID ) ,
                                record);
            }
            recordcount = (int)record.Value;
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                Advertisement ad = new Advertisement();
                ad.ID = (int)dr["AdID"];
                ad.AdTitle = (string)dr["AdTitle"];
                ad.Sort = (int)dr["Sort"];
                ad.CreateAt = (DateTime)dr["CreateAt"];
                list.Add(ad);
            }
            return list;
        }

        /// <summary>
        /// 获得广告列表
        /// </summary>
        /// <returns></returns>
        public Studio.Array.ObjectList GetAdverList()
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetAdverList" ,
                             this.NewParam( "@ShopID" , ShopInfo.ID ));
            }
            Studio.Array.ObjectList list = new Studio.Array.ObjectList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                list.Add( new Advertisement( dr ) );
            }
            return list;
        }

        /// <summary>
        /// 获得广告列表
        /// </summary>
        /// <returns></returns>
        public Advertisement GetAdverByID(int adID)
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetAdverByID" ,
                             this.NewParam( "@AdID" , adID) );
            }
            if ( ds.Tables[0].Rows.Count == 0 )
                return null;
            else
                return new Advertisement( ds.Tables[0].Rows[0] );
        }

        /// <summary>
        /// 添加广告
        /// </summary>
        /// <param name="ad"></param>
        /// <returns></returns>
        public int AdAdd(Advertisement ad)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
              return  db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_AdvertisementAdd" ,
                                    this.NewParam( "@AdTitle" , ad.AdTitle ) ,
                                    this.NewParam( "@AdContent" , ad.AdContent ) ,
                                    this.NewParam( "@Sort" , ad.Sort ) ,
                                    this.NewParam( "@ShopID" , ShopInfo.ID ) );
            }
        }

        /// <summary>
        /// 修改广告
        /// </summary>
        /// <param name="ad"></param>
        /// <returns></returns>
        public int AdUpdate(Advertisement ad)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_AdvertisementUpdate" ,
                                      this.NewParam( "@AdTitle" , ad.AdTitle ) ,
                                      this.NewParam( "@AdContent" , ad.AdContent ) ,
                                      this.NewParam( "@AdID" , ad.ID ) );
            }
        }

        /// <summary>
        /// 删除广告
        /// </summary>
        /// <param name="ad"></param>
        /// <returns></returns>
        public int AdDelete(Advertisement ad)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_AdvertisementDelete" ,
                                      this.NewParam( "@AdID" , ad.ID ) );
            }
        }
    }
}
