using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Common.Framework;
using Common.Common;

using Studio.Data;
using Studio.Array;
using System.Web;
using System.IO;

using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Studio.Web;
using System.Net;

namespace Common.Agent
{
    public class GoodsAgent : AgentBase
    {
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="goodsName"></param>
        /// <param name="status"></param>
        /// <param name="categoryID"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetGoodsList(int pageSize, int pageNo, string goodsName, int status, int categoryID,bool isrecommend, out int recordCount)
        {
            DataSet ds;

            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGoodsList",
                                     this.NewParam("@PageSize", pageSize),
                                     this.NewParam("@PageNo", pageNo),
                                     this.NewParam("@GoodsName", goodsName),
                                     this.NewParam("@CategoryID", categoryID),
                                     this.NewParam("@Status", status),
                                     this.NewParam("@Isrecommend" , isrecommend ) ,
                                     this.NewParam("@ShopID", ShopInfo.ID),
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

                gs.OfCategory = new Category();
                gs.OfCategory.Name = (string)dr["CategoryName"];
                gs.OfCategory.Path = (string)dr["Path"];
                gs.OfCategory.OfShop = ShopInfo;
                list.Add(gs);
            }


            return list;
        }

        /// <summary>
        /// 获取单个商品
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public Goods GetGoodsByID(int gid)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGoodsByID",
                            this.NewParam("@GoodsID", gid));
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                Goods gs = new Goods(ds.Tables[0].Rows[0]);
                Category ca = new Category();
                ca.Name = (string)ds.Tables[0].Rows[0]["CategoryName"];
                gs.OfCategory = ca;
                return gs;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 前台获取单个商品
        /// </summary>
        /// <param name="goodid"></param>
        /// <returns></returns>
        public Goods GetGoodsWeb(int goodid)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGoodsByID",
                            this.NewParam("@GoodsID", goodid));
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }

            Goods gs = new Goods(ds.Tables[0].Rows[0]);
            gs.OfCategory = (Category)ShopInfo.Categorys.GetById((int)ds.Tables[0].Rows[0]["CategoryID"]);

            return gs;
        }

        /// <summary>
        /// 添加点击次数
        /// </summary>
        /// <param name="goodsid"></param>
        public void GoodsClicksAdd(int goodsid)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GoodsClicksAdd",
                    this.NewParam("@GoodsID", goodsid));
            }
        }
        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="gs"></param>
        public int UpdateGoods(Goods gs)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GoodsUpdate",
                                     this.NewParam("@GoodsID", gs.ID),
                                     this.NewParam("@GoodsName", gs.GoodsName),
                                     this.NewParam("@Price", gs.Price),
                                     this.NewParam("@CategoryID", gs.CategoryID),
                                     this.NewParam("@Order", gs.Order),
                                     this.NewParam("@Recommend", gs.Recommend),
                                     this.NewParam("@StartTime", gs.StartTime),
                                     this.NewParam("@EndTime", gs.EndTime),
                                     this.NewParam("@Image ", gs.Image),
                                     this.NewParam("@ShopID", ShopInfo.ID),
                                     this.NewParam("@Status", gs.Status),
                                     this.NewParam("@MarketPrice", gs.MarketPrice),
                                     this.NewParam("@Description", gs.Description),
                                     this.NewParam("@Score", gs.Score),
                                     this.NewParam("@Weight", gs.Weight),
                                     this.NewParam("@Model", gs.Model),
                                     this.NewParam("@Unit", gs.Unit),
                                     this.NewParam("@IsRecommend", gs.IsRecommend),
                                     this.NewParam("@Service", gs.Service),
                                     this.NewParam("@Factory", gs.Factory));

            }
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="gs"></param>
        public int AddGoods(Goods gs)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GoodsAdd",
                                    this.NewParam("@GoodsName", gs.GoodsName),
                                    this.NewParam("@Price", gs.Price),
                                    this.NewParam("@CategoryID", gs.CategoryID),
                                    this.NewParam("@Recommend", gs.Recommend),
                                    this.NewParam("@StartTime", gs.StartTime),
                                    this.NewParam("@EndTime", gs.EndTime),
                                    this.NewParam("@Image ", gs.Image),
                                    this.NewParam("@ShopID", ShopInfo.ID),
                                    this.NewParam("@MarketPrice", gs.MarketPrice),
                                    this.NewParam("@Description", gs.Description),
                                    this.NewParam("@Score", gs.Score),
                                    this.NewParam("@Weight", gs.Weight),
                                    this.NewParam("@Model", gs.Model),
                                    this.NewParam("@Unit", gs.Unit),
                                    this.NewParam("@Service", gs.Service),
                                    this.NewParam("@Factory", gs.Factory),
                                    this.NewParam("@IsRecommend", gs.IsRecommend));

            }
        }

        /// <summary>
        /// 批量删除商品
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="count"></param>
        public void DeleteGoods(string ids, int count)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GoodsDelete",
                                this.NewParam("@GoodsIDs", ids),
                                this.NewParam("@Count", count));
            }
        }

        /// <summary>
        /// 删除单个商品
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public int GoodsDeletes(Goods g)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GoodsDeletes",
                                this.NewParam("@GoodsID", g.ID));
            }

        }

        /// <summary>
        /// 根据栏目获取10条商品信息(根据order排序)
        /// </summary>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        public ObjectList GetLastGoods(int categoryid)
        {


            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetLastGoods",
                                 this.NewParam("@CategoryID", categoryid));
            }
            ObjectList list = new ObjectList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Goods g = new Goods(dr);
                g.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);

                list.Add(g);
            }
            return list;
        }

        /// <summary>
        /// 获取该栏目下所有商品

        /// </summary>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        public ArrayList GetGoodsByCategoryID(int categoryid)
        {
            DataSet ds = new DataSet();

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGoodsByCategoryID",
                                this.NewParam("@CategoryID", categoryid));
            }

            ArrayList list = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
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
                gs.IsRecommend = (bool)dr["IsRecommend"];
                gs.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);
                list.Add(gs);
            }

            return list;
        }

        /// <summary>
        /// 添加产品评论数

        /// </summary>
        /// <param name="goodsid"></param>
        public void GoodsCommentsAdd(int goodsid)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GoodsCommentstAdd",
                    this.NewParam("@GoodsID", goodsid));
            }
        }

        /// <summary>
        /// 最热商品

        /// </summary>
        /// <returns></returns>
        public ArrayList GetHotGoods()
        {

            ArrayList list2 = (ArrayList)HttpRuntime.Cache["GetHotGoods_" + ShopInfo.ID.ToString()];

            if (list2 != null)
                return list2;

            DataSet ds = new DataSet();

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetHotGoods",
                                this.NewParam("@ShopID", ShopInfo.ID));
            }

            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Goods gs = new Goods();
                gs.ID = (int)dr["GoodsID"];
                gs.GoodsName = (string)dr["GoodsName"];
                gs.Price = (double)dr["Price"];
                gs.MarketPrice = (double)dr["MarketPrice"];
                gs.Image = (string)dr["Image"];
                gs.CategoryID = (int)dr["CategoryID"];
                gs.Comments = (int)dr["Comments"];
                gs.Clicks = (int)dr["Clicks"];
                gs.Score = (int)dr["Score"];
                gs.CreateAt = (DateTime)dr["CreateAt"];
                gs.IsRecommend = (bool)dr["IsRecommend"];
                gs.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);
                list.Add(gs);
            }

            HttpRuntime.Cache.Insert("GetHotGoods_" + ShopInfo.ID.ToString(), list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));

            return list;
        }

        /// <summary>
        /// 推荐商品
        /// </summary>
        /// <returns></returns>
        public ArrayList GetCommendGoods()
        {
            ArrayList list2 = (ArrayList)HttpRuntime.Cache["GetCommend_" + ShopInfo.ID.ToString()];

            if (list2 != null)
                return list2;

            DataSet ds = new DataSet();

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGoodsCommend",
                                this.NewParam("@ShopID", ShopInfo.ID));
            }

            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Goods gs = new Goods();
                gs.ID = (int)dr["GoodsID"];
                gs.GoodsName = (string)dr["GoodsName"];
                gs.Price = (double)dr["Price"];
                gs.MarketPrice = (double)dr["MarketPrice"];
                gs.Image = (string)dr["Image"];
                gs.CategoryID = (int)dr["CategoryID"];
                gs.Score = (int)dr["Score"];
                gs.Comments = (int)dr["Comments"];
                gs.Clicks = (int)dr["Clicks"];
                gs.IsRecommend = true;

                gs.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);
                list.Add(gs);
            }

            HttpRuntime.Cache.Insert("GetCommend_" + ShopInfo.ID.ToString(), list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));

            return list;
        }
        /// <summary>
        /// 12条最新商品

        /// </summary>
        /// <returns></returns>
        public ArrayList GetNewGoods()
        {

            ArrayList list2 = (ArrayList)HttpRuntime.Cache["NewGoods_" + ShopInfo.ID.ToString()];

            if (list2 != null)
                return list2;

            DataSet ds = new DataSet();

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGoodsNew",
                                this.NewParam("@ShopID", ShopInfo.ID));
            }

            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Goods gs = new Goods();
                gs.ID = (int)dr["GoodsID"];
                gs.GoodsName = (string)dr["GoodsName"];
                gs.Price = (double)dr["Price"];
                gs.MarketPrice = (double)dr["MarketPrice"];
                gs.Image = (string)dr["Image"];
                gs.CategoryID = (int)dr["CategoryID"];
                gs.Score = (int)dr["Score"];
                gs.Comments = (int)dr["Comments"];
                gs.Clicks = (int)dr["Clicks"];
                gs.CreateAt = (DateTime)dr["CreateAt"];
                gs.IsRecommend = (bool)dr["IsRecommend"];

                gs.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);
                list.Add(gs);
            }

            HttpRuntime.Cache.Insert("NewGoods_" + ShopInfo.ID.ToString(), list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));

            return list;
        }

        /// <summary>
        /// 获取更多新商品

        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetNewGoodsMove(int pageSize, int pageNo, out int recordCount)
        {
            DataSet ds = new DataSet();

            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetNewGoodsMove",
                                    this.NewParam("@ShopID", ShopInfo.ID),
                                    this.NewParam("@PageSize", pageSize),
                                    this.NewParam("@PageNo", pageNo),
                                    record);
                recordCount = (int)record.Value;
            }

            ArrayList list = new ArrayList();

            if (ds.Tables[0].Rows.Count == 0)
                return null;


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
                gs.CreateAt = (DateTime)dr["CreateAt"];
                gs.Comments = (int)dr["Comments"];
                gs.IsRecommend = (bool)dr["IsRecommend"];

                gs.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);
                list.Add(gs);
            }

            return list;
        }
        /// <summary>
        /// 更多最热商品

        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetHotGoodsMove(int pageSize, int pageNo, out int recordCount)
        {
            DataSet ds = new DataSet();

            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetHotGoodsMove",
                                    this.NewParam("@ShopID", ShopInfo.ID),
                                    this.NewParam("@PageSize", pageSize),
                                    this.NewParam("@PageNo", pageNo),
                                    record);
                recordCount = (int)record.Value;
            }

            ArrayList list = new ArrayList();

            if (ds.Tables[0].Rows.Count == 0)
                return null;


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
                gs.CreateAt = (DateTime)dr["CreateAt"];
                gs.Comments = (int)dr["Comments"];
                gs.IsRecommend = (bool)dr["IsRecommend"];

                gs.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);
                list.Add(gs);
            }

            return list;
        }

        /// <summary>
        /// 更多推荐商品
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetCommendGoodsMove(int pageSize, int pageNo, out int recordCount)
        {
            DataSet ds = new DataSet();

            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetCommentGoodsMove",
                                    this.NewParam("@ShopID", ShopInfo.ID),
                                    this.NewParam("@PageSize", pageSize),
                                    this.NewParam("@PageNo", pageNo),
                                    record);
                recordCount = (int)record.Value;
            }

            ArrayList list = new ArrayList();

            if (ds.Tables[0].Rows.Count == 0)
                return null;


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
                gs.CreateAt = (DateTime)dr["CreateAt"];
                gs.Comments = (int)dr["Comments"];
                gs.IsRecommend = (bool)dr["IsRecommend"];


                gs.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);
                list.Add(gs);
            }

            return list;
        }

        /// <summary>
        /// 根据商品名称模糊查询商品
        /// </summary>
        /// <param name="goodsname"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList SelectGoodsName(string goodsname, int categoryid, int pageSize, int pageNo, int type, out int recordCount)
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter recod = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_SelectGoodsName",
                            this.NewParam("@GoodsName", goodsname),
                            this.NewParam("@ShopID", ShopInfo.ID),
                            this.NewParam("@CategorID", categoryid),
                            this.NewParam("@PageSize", pageSize),
                            this.NewParam("@PageNo", pageNo),
                            this.NewParam("@Type", type),
                            recod);
                recordCount = (int)recod.Value;
            }
            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Goods gs = new Goods();
                gs.ID = (int)dr["GoodsID"];
                gs.GoodsName = (string)dr["GoodsName"];
                gs.Price = (double)dr["Price"];
                gs.MarketPrice = (double)dr["MarketPrice"];
                gs.Image = (string)dr["Image"];
                gs.CategoryID = (int)dr["CategoryID"];
                gs.Score = (int)dr["Score"];
                gs.Comments = (int)dr["Comments"];
                gs.Clicks = (int)dr["Clicks"];
                gs.CreateAt = (DateTime)dr["CreateAt"];
                gs.IsRecommend = (bool)dr["IsRecommend"];

                Category c = new Category();
                c.Path = (string)dr["Path"];
                c.OfShop = ShopInfo;

                gs.OfCategory = c;

                list.Add(gs);
            }

            return list;
        }
        /// <summary>
        /// 获取大栏目下所有商品

        /// </summary>
        /// <param name="categoryid"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetGoodsCategory(int categoryid, int pageSize, int pageNo, int type, out int recordCount)
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter recod = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGoodsCategory",
                            this.NewParam("@ShopID", ShopInfo.ID),
                            this.NewParam("@CategoryID", categoryid),
                            this.NewParam("@PageSize", pageSize),
                            this.NewParam("@PageNo", pageNo),
                            this.NewParam("@Type", type),
                            recod);
                recordCount = (int)recod.Value;
            }
            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Goods gs = new Goods();
                gs.ID = (int)dr["GoodsID"];
                gs.GoodsName = (string)dr["GoodsName"];
                gs.Price = (double)dr["Price"];
                gs.MarketPrice = (double)dr["MarketPrice"];
                gs.Image = (string)dr["Image"];
                gs.CategoryID = (int)dr["CategoryID"];
                gs.Score = (int)dr["Score"];
                gs.Comments = (int)dr["Comments"];
                gs.Clicks = (int)dr["Clicks"];
                gs.CreateAt = (DateTime)dr["CreateAt"];
                gs.IsRecommend = (bool)dr["IsRecommend"];
                Category c = new Category();
                c.Path = (string)dr["Path"];
                c.OfShop = ShopInfo;

                gs.OfCategory = c;

                list.Add(gs);
            }

            return list;

        }

        /// <summary>
        /// 设置推荐产品
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GoodsRecommend(int gid, bool type)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GoodsRecommend",
                                     this.NewParam("@GoodsID", gid),
                                     this.NewParam("@Type", type));
            }
        }

        /// <summary>
        /// 获得最便宜，最贵商品 
        /// </summary>
        /// <param name="type">1－便宜</param>
        /// <returns></returns>
        public ArrayList GetTopGoods()
        {
            ArrayList list2 = (ArrayList)HttpRuntime.Cache["GetTopGoods_" + ShopInfo.ID.ToString()];

            if (list2 != null)
                return list2;


            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetTopGoods",
                                this.NewParam("@ShopID", ShopInfo.ID));
            }

            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Goods gs = new Goods();
                gs.ID = (int)dr["GoodsID"];
                gs.GoodsName = (string)dr["GoodsName"];
                gs.Price = (double)dr["Price"];
                gs.MarketPrice = (double)dr["MarketPrice"];
                gs.Image = (string)dr["Image"];
                gs.CategoryID = (int)dr["CategoryID"];
                gs.Score = (int)dr["Score"];
                gs.Comments = (int)dr["Comments"];
                gs.Clicks = (int)dr["Clicks"];
                gs.CreateAt = (DateTime)dr["CreateAt"];
                gs.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);
                list.Add(gs);

            }

            HttpRuntime.Cache.Insert("GetTopGoods_" + ShopInfo.ID.ToString(), list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));

            return list;

        }

        /// <summary>
        /// 获取5个热门关键字
        /// </summary>
        /// <returns></returns>
        public ArrayList GetHotKeyWord()
        {
            ArrayList list2 = (ArrayList)HttpRuntime.Cache["GetHotKeyWord_" + ShopInfo.ID.ToString()];

            if (list2 != null)
                return list2;


            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetHotKeyWord",
                                this.NewParam("@ShopID", ShopInfo.ID));
            }

            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Goods gs = new Goods();
                gs.ID = (int)dr["GoodsID"];
                gs.GoodsName = (string)dr["GoodsName"];
                gs.CategoryID = (int)dr["CategoryID"];
                gs.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);
                list.Add(gs);

            }

            HttpRuntime.Cache.Insert("GetHotKeyWord_" + ShopInfo.ID.ToString(), list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));

            return list;

        }

        /// <summary>
        /// 获得商脉通产品

        /// </summary>
        /// <returns></returns>
        public DataTable GetSmtGoods(int pagesize, int pageno, string productName, out int recordCount)
        {
            DataSet ds;
            IDbDataParameter record = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);
            using (IDbExecutor db = this.NewExecutor())
            {

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetSmtGoodsList",
                                this.NewParam("@ShopID", ShopInfo.ComID),
                                this.NewParam("@PageSize", pagesize),
                                this.NewParam("@PageNo", pageno),
                                this.NewParam("@ProductName", productName),
                                record);

            }
            recordCount = (int)record.Value;
            return ds.Tables[0];
        }

        /// <summary>
        /// 获得商脉通的产品类别
        /// </summary>
        /// <returns></returns>
        public DataTable GetSmtCategory()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetSmtProductCategory",
                                this.NewParam("@Comid", ShopInfo.ComID));
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 批量加入商脉通商品

        /// </summary>
        /// <returns></returns>
        public int AddSmtGoods(string photos,string pids, string cid, int status)
        {
            int value = 0;
            string[] pid = pids.Split(',');
            string[] photo = photos.Split( ',' );
            if (pid.Length > 0)
            {

                for (int i = 0; i < pid.Length; i++)
                {
                    using (IDbExecutor db = this.NewExecutor())
                    {
                        value = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_AddSmtGoods",
                                            this.NewParam("@ProductID", pid[i]),
                                            this.NewParam("@ShopID", ShopInfo.ID),
                                            this.NewParam("@Status", status),
                                            this.NewParam("@CategoryID", int.Parse(cid)));

                    } 
                    //---------------copy商品图片--------------//
                    if ( photo.Length > 0 )
                    {
                        if ( photo[i] != "" )
                        {
                            CopyPhoto( photo[i] );
                        }
                    }
                }
            }

            return value;
        }

        /// <summary>
        /// 根据产品类别批量加入商脉通数据

        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="categoryids"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int AddSmtGoodsList(int goodsId, string categoryids, int num, int status)
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_AddSmtGoodsList",
                                    this.NewParam("@ShopID", ShopInfo.ID),
                                    this.NewParam("@GoodsCategory", goodsId),
                                    this.NewParam("@CategoryIDs", categoryids),
                                    this.NewParam("@Status", status),
                                    this.NewParam("@Num", num));

            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if ((string)dr["Photo"] + "" != "")
                {
                    CopyPhoto((string)dr["Photo"]);
                }
            }
            return ds.Tables[0].Rows.Count;
        }


        public void CopyPhoto(string url)
        {
            string folder = HttpContext.Current.Server.MapPath(ShopInfo.DataPath + "/Goods/");
            int outwidth, outheight = 0;

            //-----------下载图片------------//
            if ( ShopInfo.ComAcc != "" )
            {
                string sRmFile = "http://" + ShopInfo.ComAcc + ".anyp.com" + url.Replace( "S_" , "" ); //获得商脉通原图

                string newfilename = url.Substring( url.IndexOf( "/products/" ) + 12 , url.Length - ( url.IndexOf( "/products/" ) + 12 ) );
                WebClient wc = new WebClient();
                if ( newfilename.Contains( "." ) )
                {

                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }

                    wc.DownloadFile( sRmFile , folder + newfilename );

                    ////------------生成缩略图---------------//
                    int maxSize = 1024 * 1024 * 2;
                    int maxW = 120 , maxH = 120;

                   
                    string photos = folder + "S_" + newfilename;

                    WebAgent.SaveFile(folder + newfilename, photos, maxW, maxH, out outwidth, out outheight);
                }
               
            }
           
        }


        /// <summary>
        /// 获得商品相关图片
        /// </summary>
        /// <param name="goodsid"></param>
        /// <returns></returns>
        public ArrayList GetGoodsImages(int goodsid)
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetGoodsImages",
                                    this.NewParam("@GoodsID", goodsid));

            }
            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new GoodsImages(dr));
            }

            return list;
        }


        /// <summary>
        /// 添加商品相关图片
        /// </summary>
        /// <param name="gi"></param>
        /// <returns></returns>
        public int AddGoodsImage(GoodsImages gi)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_AddGoodsImage",
                                     this.NewParam("@GoodsID", gi.GoodsID),
                                     this.NewParam("@ImageName", gi.ImageName),
                                     this.NewParam("@ImageUrl", gi.ImageUrl));
            }

        }


        /// <summary>
        /// 批量删除相关图片
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int GoodsImagesDelete(string ids, int count)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GoodsImagesDelete",
                                     this.NewParam("@ImageIDs", ids),
                                     this.NewParam("@Num", count));
            }

        }

        /// <summary>
        /// 销售商品统计

        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetVenditionStat(int categoryid,DateTime starttime, DateTime endtime, int pagesize, int pageno, out int recordCount)
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter recod = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_VenditionStat",
                            this.NewParam("@ShopID", ShopInfo.ID),
                            this.NewParam("@StartTime",starttime),
                            this.NewParam("@EndTime",endtime),
                            this.NewParam("@CategoryID",categoryid),
                            this.NewParam("@PageSize", pagesize),
                            this.NewParam("@PageNo", pageno),
                            recod);
                recordCount = (int)recod.Value;
            }
            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Goods gs = new Goods();
                gs.ID = (int)dr["GoodsID"];
                gs.GoodsName = (string)dr["GoodsName"];
                gs.Price = (double)dr["Price"];
                gs.Clicks = (int)dr["Clicks"];
                gs.PayCount = (int)dr["Qcount"];
                gs.Comments = (int)dr["Comments"];
                gs.IsRecommend = (bool)dr["IsRecommend"];
                Category c = new Category();
                c.ID = (int)dr["CategoryID"];
                c.Name = (string)dr["CategoryName"];
                gs.OfCategory = c;

                list.Add(gs);
            }

            return list;
        }

        /// <summary>
        /// 商品流量统计
        /// </summary>
        /// <param name="categoryid"></param>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetClickStat(int categoryid,int pagesize, int pageno, out int recordCount)
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter recod = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GoodsStat",
                            this.NewParam("@ShopID", ShopInfo.ID),
                            this.NewParam("@CategoryID",categoryid),
                            this.NewParam("@PageSize", pagesize),
                            this.NewParam("@PageNo", pageno),
                            recod);
                recordCount = (int)recod.Value;
            }
            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Goods gs = new Goods();
                gs.ID = (int)dr["GoodsID"];
                gs.GoodsName = (string)dr["GoodsName"];
                gs.Price = (double)dr["Price"];
                gs.Clicks = (int)dr["Clicks"];
                gs.Comments = (int)dr["Comments"];
                gs.IsRecommend = (bool)dr["IsRecommend"];
                Category c = new Category();
                c.ID = (int)dr["CategoryID"];
                c.Name = (string)dr["CategoryName"];
                gs.OfCategory = c;

                list.Add(gs);
            }

            return list;
        }

        /// <summary>
        /// 排前
        /// </summary>
        /// <param name="GoodID"></param>
        /// <returns></returns>
        public int GoodsUp(int GoodID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GoodsUp",
                                    this.NewParam("@GoodsID", GoodID));

            }
        }

        /// <summary>
        /// 排后
        /// </summary>
        /// <param name="GoodID"></param>
        /// <returns></returns>
        public int GoodsDown(int GoodID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_GoodsDown",
                                    this.NewParam("@GoodsID", GoodID));

            }
        }
    }
}
