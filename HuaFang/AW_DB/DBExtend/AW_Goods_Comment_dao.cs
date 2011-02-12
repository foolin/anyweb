using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AnyWell.AW_DL;
using System.Web;
using Studio.Data;

namespace AnyWell.AW_DL
{
	public partial class AW_Goods_Comment_dao
	{
        /// <summary>
        /// 后台管理搜索评论
        /// </summary>
        /// <param name="goodsName"></param>
        /// <param name="memberName"></param>
        /// <param name="ip"></param>
        /// <param name="reply"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<AW_Goods_Comment_bean> funcCommentSearch(string goodsName,string memberName,string ip,string reply,int pageSize,int pageIndex)
        {
            this.propSelect = "gc.*,g.fdGoodID,g.fdGoodName";
            this.propTableApp = "gc,AW_Goods g";
            this.propOrder = "ORDER BY fdCommCreateAt DESC";
            this.propWhere = "gc.fdCommGoodsID=g.fdGoodID";
            if (!String.IsNullOrEmpty(goodsName))
            {
                this.propWhere += String.Format(" AND g.fdGoodName like '%{0}%' ", goodsName.Replace(" ","%") );
            }
            if (!String.IsNullOrEmpty(memberName))
            {
                this.propWhere += String.Format(" AND gc.fdCommUserName LIKE '%{0}%' ", memberName.Replace(" ", "%"));
            }
            if (!String.IsNullOrEmpty(ip))
            {
                this.propWhere += String.Format(" AND gc.fdCommIP = '{0}' ", ip );
            }
            if (!String.IsNullOrEmpty(reply))
            {
                if(reply=="1")
                    this.propWhere += " AND gc.fdCommReply != '' ";
                else
                    this.propWhere += " AND gc.fdCommReply = '' ";
            }
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;
            DataSet ds = base.funcCommon();
            List<AW_Goods_Comment_bean> list = new List<AW_Goods_Comment_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Goods_Comment_bean bean = new AW_Goods_Comment_bean();
                bean.funcFromDataRow(r);
                bean.Goods = new AW_Goods_bean();
                bean.Goods.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;   
        }

        /// <summary>
        /// 回复评论
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reply"></param>
        /// <returns></returns>
        public int funcCommentReply(int id, string reply)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                int record = db.ExecuteNonQuery(
                    CommandType.Text
                    , "UPDATE AW_Goods_Comment SET fdCommReply = @fdCommReply,fdCommReplyAt = getdate() WHERE fdCommID = @fdCommID "
                    , this.NewParam("@fdCommReply", reply)
                    , this.NewParam("@fdCommID", id)
                    );
                return record;
            }
        }

        public int funcCommentNotReplyCount()
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return (int)db.ExecuteScalar("SELECT COUNT(*) FROM AW_Goods_Comment WHERE fdCommReply = ''");
            }
        }

        /// <summary>
        /// 获取商品评论列表
        /// </summary>
        /// <param name="goodsID"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public List<AW_Goods_Comment_bean> funcGetCommentList(int goodsID, int pageSize, int pageIndex)
        {
            this.propWhere = " fdCommGoodsID=" + goodsID.ToString() + " AND fdCommIsDeleted=0";
            this.propOrder = " ORDER BY fdCommID DESC";
            this.propGetCount = true;
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            return this.funcGetList();
        }

        /// <summary>
        /// 检查用户今天是否对商品提交过评论
        /// </summary>
        /// <param name="goodsID"></param>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public bool funcCheckMemberHasCommentToday(int goodsID, int memberID)
        {
            this.propWhere = " fdCommGoodsID=" + goodsID.ToString() + " AND fdCommMemberID=" + memberID + " AND fdCommCreateAt>'"+DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss")+"'";
            return (this.funcGetList().Count > 0);
        }

        public List<AW_Goods_Comment_bean> funcGetMemberCommentList(int memberId, int pageSize, int pageIndex)
        {
            this.propSelect = "gc.*,g.fdGoodID,g.fdGoodName,g.fdGoodSalePrice,g.fdGoodMarketPrice,g.fdGoodIsRecommend,g.fdGoodIsPromotion,g.fdGoodPromPrice,g.fdGoodListImage,g.fdGoodFavCount,g.fdGoodStatus";
            this.propTableApp = "gc INNER JOIN AW_Goods g on gc.fdCommGoodsID = g.fdGoodID";
            this.propWhere = "gc.fdCommIsDeleted=0 AND gc.fdCommMemberID = " + memberId.ToString();
            this.propOrder = " ORDER BY fdCommCreateAt DESC";
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;
            DataSet ds = base.funcCommon();
            List<AW_Goods_Comment_bean> list = new List<AW_Goods_Comment_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Goods_Comment_bean bean = new AW_Goods_Comment_bean();
                bean.funcFromDataRow(r);
                bean.Goods = new AW_Goods_bean();
                bean.Goods.funcFromDataRow(r);
                list.Add(bean);
            }
            return list;
        }

        public AW_Goods_Comment_bean funcGetMemberComment(int commentId, int memberId)
        {
            this.propSelect = "gc.*,g.fdGoodID,g.fdGoodName,g.fdGoodSalePrice,g.fdGoodMarketPrice,g.fdGoodIsRecommend,g.fdGoodIsPromotion,g.fdGoodPromPrice,g.fdGoodListImage,g.fdGoodFavCount,g.fdGoodStatus";
            this.propTableApp = "gc INNER JOIN AW_Goods g on gc.fdCommGoodsID = g.fdGoodID";
            this.propWhere = "gc.fdCommID = " + commentId + " AND gc.fdCommMemberID = " + memberId;
            DataSet ds = base.funcCommon();
            AW_Goods_Comment_bean bean = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                bean = new AW_Goods_Comment_bean();
                bean.funcFromDataRow(ds.Tables[0].Rows[0]);
                bean.Goods = new AW_Goods_bean();
                bean.Goods.funcFromDataRow(ds.Tables[0].Rows[0]);
            }
            return bean;
        }
	}
}
