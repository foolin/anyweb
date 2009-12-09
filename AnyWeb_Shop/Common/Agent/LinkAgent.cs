using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Studio.Data;
using System.Data;
using Common.Common;

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
        /// �����б�
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
        /// �޸�����
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public int LinkUpdate(Link l)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_LinkUpdate" ,
                                    this.NewParam( "@LinkID" , l.ID ) ,
                                    this.NewParam( "@LinkName" , l.Name ) ,
                                    this.NewParam( "@Image" , l.Image ) ,
                                    this.NewParam( "@LinkUrl" , l.LinkUrl ) ,
                                    this.NewParam( "@Sort" , l.Sort ) );
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public int LinkAdd(Link l)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_LinkAdd" ,
                                    this.NewParam( "@LinkName" , l.Name ) ,
                                    this.NewParam( "@Image" , l.Image ) ,
                                    this.NewParam( "@LinkUrl" , l.LinkUrl ) ,
                                    this.NewParam("@LinkType",l.LinkType),
                                    this.NewParam( "@Sort" , l.Sort ) ,
                                    this.NewParam("@ShopID",ShopInfo.ID));
            }
        }
        
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public int LinkDelete(Link l)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_LinkDelete" ,
                                            this.NewParam( "@LinkID" , l.ID ) );
            }
        }

        /// <summary>
        /// ��ȡ��������
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
    }
}