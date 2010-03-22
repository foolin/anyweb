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
                hsr.OfGoods.Description = (string)dr["Description"];
                hsr.OfGoods.Status = (int)dr["Status"];
                list.Add(hsr);
            }

            return list;
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetHotSellRankList()
        {
            int recordCount = 0;
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
                hsr.OfGoods.Description = (string)dr["Description"];
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
        public int AddGoods(string addIds, string delIds)
        {
            int result = 0;
            using (IDbExecutor db = this.NewExecutor())
            {
                result = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_HotSellRankAdd",
                                    this.NewParam("@AddGoodIDs", addIds),
                                    this.NewParam("@DelGoodIDs", delIds));
            }
            return result;
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
        /// 向上排序
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public bool GoodsSortUp(int goodsId)
        {
            int result = 0;
            using (IDbExecutor db = this.NewExecutor())
            {
                result = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_HotSellRankSort",
                                    this.NewParam("@GoodsId", goodsId),
                                    this.NewParam("@SortType", "up"));
            }

            if (result > 0)
                return true;

            return false;
        }

        /// <summary>
        /// 向下排序
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public bool GoodsSortDown(int goodsId)
        {
            int result = 0;
            using (IDbExecutor db = this.NewExecutor())
            {
                result = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_HotSellRankSort",
                                    this.NewParam("@GoodsId", goodsId),
                                    this.NewParam("@SortType", "down"));
            }

            if (result > 0)
                return true;

            return false;
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
