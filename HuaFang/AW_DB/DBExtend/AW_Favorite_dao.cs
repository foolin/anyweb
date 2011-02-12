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
	public partial class AW_Favorite_dao
	{
        /// <summary>
        /// 检查某个会员是否收藏了某商品
        /// </summary>
        /// <param name="goodsID"></param>
        /// <param name="memberID"></param>
        /// <returns></returns>
        public bool funcCheckMemberHasFavGoods(int goodsID, int memberID)
        {
            this.propWhere = "fdFavoGoodsID=" + goodsID.ToString() + " AND fdFavoMemberID=" + memberID.ToString();
            return this.funcCommon().Tables[0].Rows.Count > 0;
        }

        /// <summary>
        /// 删除会员商品收藏
        /// </summary>
        /// <returns></returns>
        public int funcDelete(int favoriteId,int memberId)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                string sql = String.Format("DELETE FROM AW_Favorite WHERE fdFavoID = {0} AND fdFavoMemberID = {1}", favoriteId, memberId);
                return db.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// 会员商品收藏列表
        /// </summary>
        /// <returns></returns>
        public List<AW_Favorite_bean> funcGetFavorites(int memberId, int pageSize, int pageIndex)
        {
            this.propSelect = "f.*,g.fdGoodID,g.fdGoodName,g.fdGoodSalePrice,g.fdGoodMarketPrice,g.fdGoodIsRecommend,g.fdGoodIsPromotion,g.fdGoodPromPrice,g.fdGoodListImage,g.fdGoodFavCount,g.fdGoodStatus";
            this.propTableApp = "f INNER JOIN AW_Goods g on f.fdFavoGoodsID = g.fdGoodID";
            this.propWhere = "f.fdFavoMemberID = " + memberId.ToString();
            this.propOrder = " ORDER BY fdFavoCreateAt ASC";
            this.propPageSize = pageSize;
            this.propPage = pageIndex;
            this.propGetCount = true;
            DataSet ds = base.funcCommon();
            List<AW_Favorite_bean> list = new List<AW_Favorite_bean>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                AW_Favorite_bean bean = new AW_Favorite_bean();
                bean.funcFromDataRow(r);
                bean.Goods = new AW_Goods_bean();
                bean.Goods.funcFromDataRow(r);
                list.Add(bean);
            }
            return list; 
        }
	
	}
}
