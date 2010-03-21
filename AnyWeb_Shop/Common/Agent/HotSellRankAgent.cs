using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Studio.Data;
using System.Data;
using Common.Common;
using System.Web;
using Studio.Web;

namespace Common.Agent
{
    public class HotSellRankAgent : AgentBase
    {
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetHotSellRankList(out int recordCount)
        {
            DataSet ds = new DataSet();

            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetHotSellRankList", record);
            }
            recordCount = (int)record.Value;

            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                HotSellRank hsr = new HotSellRank();
                hsr.HotSellID = (int)dr["HotSellID"];
                hsr.GoodsID = (int)dr["GoodsID"];
                hsr.Sort = (short)dr["Sort"];
                hsr.OfGoods = new Goods();
                hsr.OfGoods.GoodsName = (string)dr["GoodsName"];
                hsr.OfGoods.Image = (string)dr["Image"];
                hsr.OfGoods.Price = (double)dr["Price"];
                hsr.OfGoods.MarketPrice = (double)dr["MarketPrice"];
                hsr.OfGoods.Status = (int)dr["Status"];
                list.Add(hsr);
            }

            return list;
        }


        /// <summary>
        /// 获取畅销商品数
        /// </summary>
        /// <returns></returns>
        public int GetGoodsCount()
        {
            int count = 0;
            this.GetHotSellRankList(out count);
            return count;
        }

        /// <summary>
        /// 添加畅销商品
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public int AddGoods(int goodsId)
        {
            int result = 0;
            using (IDbExecutor db = this.NewExecutor())
            {
                result = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_HotSellRankAdd",
                                    this.NewParam("@GoodsId", goodsId),
                                    this.NewParam("@Sort", 0));
            }
            return result;
        }

        /// <summary>
        /// 添加畅销商品
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public int AddGoods(int goodsId, int sort)
        {
            int result = 0;
            using (IDbExecutor db = this.NewExecutor())
            {
                result = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_HotSellRankAdd",
                                    this.NewParam("@GoodsId", goodsId),
                                    this.NewParam("@Sort", sort));
            }
            return result;
        }


        /**
        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="addIds"></param>
        /// <returns></returns>
        public int AddGoods(string addIds)
        {
            string[] arrIds = addIds.Split(",".ToCharArray());  //按逗号将数据分割成一个数组
            int result = 0;
            WebAgent.Alert("AddIds:" + addIds);
            WebAgent.Alert("AddIds:" + arrIds.Length.ToString());
            for (int i = 0; i < arrIds.Length; i++)
            {
                using (IDbExecutor db = this.NewExecutor())
                {
                    if(db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_HotSellRankAdd",
                                        this.NewParam("@GoodsId", addIds[i]),
                                        this.NewParam("@Sort", 0))>0
                        )
                        result++;
                }
            }
            return result;

        }
        */


        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public int UpdateGoods(int goodsId, int sort)
        {
            int result = 0;
            using (IDbExecutor db = this.NewExecutor())
            {
                result = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_HotSellRankUpdate",
                                    this.NewParam("@GoodsId", goodsId),
                                    this.NewParam("@Sort", sort));
            }
            return result;
        }


        /// <summary>
        /// 删除畅销商品
        /// </summary>
        /// <param name="delIds"></param>
        /// <returns></returns>
        public int DeleteGoods(string delIds)
        {
            int result;
            using (IDbExecutor db = this.NewExecutor())
            {
                result = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_HotSellRankDelete",
                                            this.NewParam("@Ids", delIds));
            }
            return result;
        }


    }
}
