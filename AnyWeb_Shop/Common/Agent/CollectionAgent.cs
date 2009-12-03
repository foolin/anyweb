using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Collections;
using System.Data;
using Common.Common;

namespace Common.Agent
{
    public class CollectionAgent:AgentBase
    {
        /// <summary>
        /// 获取用户收藏
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetCollectionList(int pageSize, int pageNo, out int recordCount)
        {
            DataSet ds = new DataSet();

            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetCollectionList",
                                    this.NewParam("@MemberID", UserInfo.ID),
                                    this.NewParam("@PageSize", pageSize),
                                     this.NewParam("@PageNo", pageNo),
                                     record);
                recordCount = (int)record.Value;
            }

            if (ds.Tables[0].Rows.Count == 0)
                return null;


            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Collection c = new Collection();

                c.ID = (int)dr["CID"];
                c.CreateAt = (DateTime)dr["CreateAt"];
      
                Goods gs = new Goods();
                gs.ID = (int)dr["GoodsID"];
                gs.GoodsName = (string)dr["GoodsName"];
                gs.Price = (double)dr["Price"];
                gs.MarketPrice = (double)dr["MarketPrice"];
                gs.Image = (string)dr["Image"];
                gs.CategoryID = (int)dr["CategoryID"];
                gs.Comments = (int)dr["Comments"];
                gs.Clicks = (int)dr["Clicks"];
                gs.CreateAt = (DateTime)dr["CreateAt"];
                gs.Score = (int)dr["Score"];
                gs.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);

                c.OfGoods = gs;

                c.OfMember = UserInfo;

                list.Add(c);
            }

            return list;
        }

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="goodsid"></param>
        /// <returns></returns>
        public int CollectionAdd(int goodsid)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteProcedure("Shop_CollectionAdd",
                                        this.NewParam("@GoodsID", goodsid),
                                        this.NewParam("@MemberID", UserInfo.ID));
            }
        }

        /// <summary>
        /// 用户删除收藏
        /// </summary>
        /// <param name="goodsid"></param>
        /// <returns></returns>
        public int CollectionDelete(int goodsid)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure,"Shop_CollectionDelete",
                                        this.NewParam("@GoodsID", goodsid),
                                        this.NewParam("@MemberID", UserInfo.ID));
            }
        }
    }
}
