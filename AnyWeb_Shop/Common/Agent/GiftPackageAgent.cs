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
    public class GiftPackageAgent : AgentBase
    {

        /// <summary>
        /// 获取大礼包列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="isShow"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetGiftPackageList(int pageSize, int pageNo, bool isShow, out int recordCount)
        {
            DataSet ds;

            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGiftPackageList",
                                     this.NewParam("@PageSize", pageSize),
                                     this.NewParam("@PageNo", pageNo),
                                     this.NewParam("@IsShow", isShow),
                                     record);
            }
            recordCount = (int)record.Value;

            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                GiftPackage gp = new GiftPackage();
                gp.PackID = (int)dr["PackID"];
                gp.PackNo = (string)dr["PackNo"];
                gp.PackName = (string)dr["PackName"];
                gp.GoodsIds = (string)dr["GoodsIds"];
                gp.Price = (double)dr["Price"];
                gp.Image = (string)dr["Image"];
                gp.Intro = (string)dr["Intro"];
                gp.Description = (string)dr["Description"];
                gp.IsShow = (bool)dr["IsShow"];
                gp.Sort = (int)dr["Sort"];
                list.Add(gp);
            }
            return list;
        }

        /// <summary>
        /// 获取大礼包列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="isShow"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetGiftPackageList(int pageSize, int pageNo, bool isShow)
        {
            int recordCount;
            DataSet ds;

            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGiftPackageList",
                                     this.NewParam("@PageSize", pageSize),
                                     this.NewParam("@PageNo", pageNo),
                                     this.NewParam("@IsShow", isShow),
                                     record);
            }
            recordCount = (int)record.Value;

            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                GiftPackage gp = new GiftPackage();
                gp.PackID = (int)dr["PackID"];
                gp.PackNo = (string)dr["PackNo"];
                gp.PackName = (string)dr["PackName"];
                gp.GoodsIds = (string)dr["GoodsIds"];
                gp.Price = (double)dr["Price"];
                gp.Image = (string)dr["Image"];
                gp.Intro = (string)dr["Intro"];
                gp.Description = (string)dr["Description"];
                gp.IsShow = (bool)dr["IsShow"];
                gp.Sort = (int)dr["Sort"];
                list.Add(gp);
            }
            return list;
        }

        public GiftPackage GetGiftPackageByID(int packID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGiftPackageByID",
                            this.NewParam("@PackID", packID));
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                GiftPackage gp = new GiftPackage(ds.Tables[0].Rows[0]);
                return gp;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="packID"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetGoodsListByPackID(int packID, out int recordCount)
        {
            DataSet ds;

            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGiftPackGoodsList",
                                     this.NewParam("@PackID", packID),
                                     record);
            }
            recordCount = (int)record.Value;

            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Goods gs = new Goods();
                gs.ID = (int)dr["GoodsID"];
                gs.GoodsName = (string)dr["GoodsName"];
                gs.Status = (int)dr["Status"];
                gs.Price = (double)dr["Price"];
                gs.MarketPrice = (double)dr["MarketPrice"];
                gs.Image = (string)dr["Image"];
                gs.CategoryID = (int)dr["CategoryID"];
                gs.Clicks = (int)dr["Clicks"];
                gs.Model = (string)dr["Model"];
                gs.EndTime = (DateTime)dr["EndTime"];
                gs.IsRecommend = (bool)dr["IsRecommend"];
                gs.Order = (int)dr["Order"];
                /*
                gs.OfCategory = new Category();
                gs.OfCategory.Name = (string)dr["CategoryName"];
                gs.OfCategory.Path = (string)dr["Path"];
                gs.OfCategory.OfShop = ShopInfo;
                 */
                list.Add(gs);
            }
            return list;
        }


        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="goodsIds"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetGoodsListByPackID(string goodsIds, out int recordCount)
        {
            DataSet ds;

            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGiftPackGoodsListByIds",
                                     this.NewParam("@Ids", goodsIds),
                                     record);
            }
            recordCount = (int)record.Value;

            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Goods gs = new Goods();
                gs.ID = (int)dr["GoodsID"];
                gs.GoodsName = (string)dr["GoodsName"];
                gs.Status = (int)dr["Status"];
                gs.Price = (double)dr["Price"];
                gs.MarketPrice = (double)dr["MarketPrice"];
                gs.Image = (string)dr["Image"];
                gs.CategoryID = (int)dr["CategoryID"];
                gs.Clicks = (int)dr["Clicks"];
                gs.Model = (string)dr["Model"];
                gs.EndTime = (DateTime)dr["EndTime"];
                gs.IsRecommend = (bool)dr["IsRecommend"];
                gs.Order = (int)dr["Order"];
                gs.OfCategory = new Category();
                gs.OfCategory.Name = (string)dr["CategoryName"];
                gs.OfCategory.Path = (string)dr["Path"];
                gs.OfCategory.OfShop = ShopInfo;
                list.Add(gs);
            }
            return list;
        }


        /// <summary>
        /// 增加大礼包
        /// </summary>
        /// <param name="gp"></param>
        /// <returns></returns>
        public int AddGiftPackage(GiftPackage gp)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GiftPackageAdd",
                                 this.NewParam("@PackNo", gp.PackNo),
                                 this.NewParam("@PackName", gp.PackName),
                                 this.NewParam("@GoodsIds", gp.GoodsIds),
                                 this.NewParam("@Price", gp.Price),
                                 this.NewParam("@Image", gp.Image),
                                 this.NewParam("@Intro", gp.Intro),
                                 this.NewParam("@Description", gp.Description),
                                 this.NewParam("@IsShow", gp.IsShow),
                                 this.NewParam("@Sort", gp.Sort));
            }
        }

        /// <summary>
        /// 更新大礼包
        /// </summary>
        /// <param name="gp"></param>
        /// <returns></returns>
        public int UpdateGiftPackage(GiftPackage gp)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GiftPackageUpdate",
                                 this.NewParam("@PackID", gp.PackID),
                                 this.NewParam("@PackNo", gp.PackNo),
                                 this.NewParam("@PackName", gp.PackName),
                                 this.NewParam("@GoodsIds", gp.GoodsIds),
                                 this.NewParam("@Price", gp.Price),
                                 this.NewParam("@Image", gp.Image),
                                 this.NewParam("@Intro", gp.Intro),
                                 this.NewParam("@Description", gp.Description),
                                 this.NewParam("@IsShow", gp.IsShow),
                                 this.NewParam("@Sort", gp.Sort));
            }
        }


        /// <summary>
        /// 批量删除大礼包
        /// </summary>
        /// <param name="packIds"></param>
        /// <returns></returns>
        public int DeleteGiftPackage(string packIds)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GiftPackageDelete",
                                 this.NewParam("@PackIds", packIds));
            }
        }

        /// <summary>
        /// 删除大礼包
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteGiftPackage(int packID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GiftPackageDelete",
                                 this.NewParam("@PackIds", packID.ToString()));
            }
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="gp"></param>
        /// <returns></returns>
        public int DeleteGiftPackage(GiftPackage gp)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GiftPackageDelete",
                                 this.NewParam("@PackIds", gp.PackID.ToString()));
            }
        }


    }
}
