using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Studio.Data;
using System.Data;
using Common.Common;
using System.Web;

namespace Common.Agent
{
    public class LinkAgent:AgentBase
    {
        public ArrayList GetLinkList()
        {
             DataSet ds = new DataSet();

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetLinkList",
                            this.NewParam("@ShopID",ShopInfo.ID));
            }

            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Link(dr));
            }

            return list;
        }

        /// <summary>
        /// 链接列表
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetLinkList2(int pagesize , int pageno , out int recordCount)
        {
            DataSet ds;
            IDbDataParameter record = this.NewParam( "@RecordCount" , 0 , DbType.Int32 , 8 , true );
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetLinkList2" ,
                                this.NewParam( "@PageSize" , pagesize ) ,
                                this.NewParam( "@PageNo" , pageno ) ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ),
                                record);
            }
            recordCount = (int)record.Value;
            ArrayList list=new ArrayList();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                list.Add( new Link( dr ) );
            }
            return list;
        }

        /// <summary>
        /// 修改链接
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public int LinkUpdate(Link l)
        {
            int result;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                result = db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_LinkUpdate" ,
                                    this.NewParam( "@LinkID" , l.ID ) ,
                                    this.NewParam( "@LinkName" , l.Name ) ,
                                    this.NewParam( "@Image" , l.Image ) ,
                                    this.NewParam( "@LinkUrl" , l.LinkUrl ) ,
                                    this.NewParam( "@Sort" , l.Sort ) );
            }
            HttpRuntime.Cache.Remove("LINK_" + ShopInfo.ID.ToString());
            return result;
        }

        /// <summary>
        /// 添加链接
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public int LinkAdd(Link l)
        {
            int result;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                result = db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_LinkAdd" ,
                                    this.NewParam( "@LinkName" , l.Name ) ,
                                    this.NewParam( "@Image" , l.Image ) ,
                                    this.NewParam( "@LinkUrl" , l.LinkUrl ) ,
                                    this.NewParam("@LinkType",l.LinkType),
                                    this.NewParam( "@Sort" , l.Sort ) ,
                                    this.NewParam("@ShopID",ShopInfo.ID));
            }
            HttpRuntime.Cache.Remove("LINK_" + ShopInfo.ID.ToString());
            return result;
        }
        
        /// <summary>
        /// 删除链接
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public int LinkDelete(Link l)
        {
            int result;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                result = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_LinkDelete",
                                            this.NewParam("@LinkID", l.ID));
            }
            HttpRuntime.Cache.Remove("LINK_" + ShopInfo.ID.ToString());
            return result;
        }

        /// <summary>
        /// 获取单个链接
        /// </summary>
        /// <param name="linkid"></param>
        /// <returns></returns>
        public Link GetLinkByID(int linkid)
        { 

            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetLinkByID" ,
                                this.NewParam( "@LinkID" , linkid ) );
            }
            if ( ds.Tables[0].Rows.Count > 0 )
            {
                return new Link( ds.Tables[0].Rows[0] );

            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取前10个友情链接
        /// </summary>
        /// <returns></returns>
        public ArrayList GetTop10LinkList(int ShopID)
        {
            DataSet ds = new DataSet();
            ArrayList list = (ArrayList)HttpRuntime.Cache["LINK_" + ShopID.ToString()];
            if (list != null)
                return list;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetTop10LinkList",
                            this.NewParam("@ShopID", ShopInfo.ID));
            }

            list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Link(dr));
            }
            HttpRuntime.Cache.Insert("LINK_" + ShopID.ToString(), list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));
            return list;
        }
    }
}
