using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using System.Data;
using Common.Common;
using Studio.Data;
using System.Web;
using Studio.Array;

namespace Common.Agent
{
    public class CommentAgent:AgentBase
    {
        /// <summary>
        /// 评论列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="sourceId"></param>
        /// <param name="userName"></param>
        /// <param name="shopID"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>

        public ArrayList GetCommentList(int pageSize , int pageNo ,int typeId, int sourceId , string userName, out int recordCount)
        {
            DataSet ds;
           
            IDbDataParameter record = this.NewParam( "@RecordCount" , 0 , DbType.Int32 , 8 , true );
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetCommentList" ,
                             this.NewParam( "@PageSize" , pageSize ) ,
                             this.NewParam( "@PageNo" , pageNo ) ,
                             this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                             this.NewParam( "@TypeID" , typeId ) ,
                             this.NewParam( "@UserName" , userName ) ,
                             this.NewParam( "@SourceID" , sourceId ) ,
                             record );
            }
            recordCount = (int)record.Value;
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                list.Add( new Comment( dr ) );

            }
        
            return list;
        }

        /// <summary>
        /// 获得回复信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Comment GetReplayByID(int cid)
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds=db.GetDataSet( CommandType.StoredProcedure , "Shop_GetReplayByID" ,
                                this.NewParam( "@CommentID" , cid ) );
            }
            if ( ds.Tables[0].Rows.Count > 0 )
            {
                Comment co = new Comment();
                co.ID = (int)ds.Tables[0].Rows[0]["CommentID"];
                co.Content = (string)ds.Tables[0].Rows[0]["Content"];
                co.CommentAt = (DateTime)ds.Tables[0].Rows[0]["CommentAt"];
                co.Replay = ds.Tables[0].Rows[0]["Replay"] == System.DBNull.Value ? "" : (string)ds.Tables[0].Rows[0]["Replay"];
                co.ReplayAt = ds.Tables[0].Rows[0]["ReplayAt"] == System.DBNull.Value ? DateTime.MinValue : (DateTime)ds.Tables[0].Rows[0]["ReplayAt"];
                co.UserName = (string)ds.Tables[0].Rows[0]["UserName"];
                return co;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 修改回复
        /// </summary>
        /// <param name="c"></param>
        public int UpdateReplay(Comment c)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
               return  db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ReplayUpdate",
                                    this.NewParam("@CommentID",c.ID),
                                    this.NewParam("@Replay",c.Replay));
            }
        }

        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="num"></param>
        public void CommentsDelete(string ids , int num)
        { 
            using(IDbExecutor db=this.NewExecutor())
            {
                db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_CommentsDelete",
                                    this.NewParam( "@CommentsID",ids ),
                                    this.NewParam("@Num",num));
            }
        }

        /// <summary>
        /// 获取留言信息
        /// </summary>
        /// <param name="typeid"></param>
        /// <param name="sourceid"></param>
        /// <returns></returns>
        public ArrayList GetLastCommentList(int typeid,int sourceid)
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                 ds =  db.GetDataSet(CommandType.StoredProcedure, "Shop_GetLastComment",
                                this.NewParam("@TypeID", typeid),
                                this.NewParam("@SourceID", sourceid),
                                this.NewParam("@ShopID", ShopInfo.ID));
            }

            ArrayList list = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Comment(dr));
            }

            return list;
        }

        public ArrayList GetUserComment(int pageSize, int pageNo, out int recordCount)
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter recount = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetUserComment",
                                    this.NewParam("@PageSize",pageSize),
                                    this.NewParam("@PageNo",pageNo),
                                    this.NewParam("@ShopID",ShopInfo.ID),
                                    this.NewParam("@UserID",UserInfo.ID),
                                    recount);

                recordCount = (int)recount.Value;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            ArrayList list = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Comment(dr));
            }

            return list;
 
        }


        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CommentAdd(Comment c)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_CommentAdd",
                                        this.NewParam("@ShopID", ShopInfo.ID),
                                        this.NewParam("@UserID", UserInfo == null ? 0 :UserInfo.ID),
                                        this.NewParam("@UserName", c.UserName),
                                        this.NewParam("@IP", c.IP),
                                        this.NewParam("@CommentAt", c.CommentAt),
                                        this.NewParam("@Content", c.Content),
                                        this.NewParam("@UrlRef", c.UrlRef),
                                        this.NewParam("@TypeID", c.TypeID),
                                        this.NewParam("@SourceID", c.SourceID),
                                        this.NewParam("@Area", c.Area));
            }
        }
    }
}
