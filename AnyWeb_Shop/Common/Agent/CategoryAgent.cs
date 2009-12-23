using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using Common.Framework;
using Common.Common;

using Studio.Data;
using Studio.Array;
using System.Web;

namespace Common.Agent
{
    /// <summary>
    /// 栏目类别代理
    /// </summary>
    public class CategoryAgent:AgentBase
    {
        /// <summary>
        /// 类别列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetCategoryList()
        {
            ArrayList listTemp = ShopInfo.Categorys;
            ArrayList list = new ArrayList();
            foreach (Category c in listTemp)
            {
                if (c.Pater == 0)
                    list.Add(c);
            }
            return list;
        }

        /// <summary>
        /// 初始化类别缓存
        /// </summary>
        /// <returns></returns>
        public ObjectList GetCategorys(int ShopID)
        {
            DataSet ds;
            ObjectList list = (ObjectList)HttpRuntime.Cache["CATEGORY_" + ShopID.ToString()];
            if (list != null)
                return list;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetCategorys",
                    this.NewParam("@ShopID", ShopID));
            }
            list = new ObjectList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Category c = new Category(row);
                list.Add(c);
            }
            HttpRuntime.Cache.Insert("CATEGORY_" + ShopID.ToString(), list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));
            return list;
        }

        /// <summary>
        /// 获取子类别
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public ArrayList GetCategoryChildren(int categoryId)
        {
            ArrayList list = new ArrayList();
            foreach (Category c in ShopInfo.Categorys)
            {
                if (c.Pater == categoryId)
                    list.Add(c);
            }
            return list;
        }

        public ObjectList GetCategoryListWeb()
        {
            ObjectList list =  ShopInfo.Categorys;
            ObjectList list1 = new ObjectList();

            foreach (Category c in list)
            {
                if (c.IsShow == true)
                {
                    list1.Add(c);
                }
            }

            return list1;
        }

        /// <summary>
        /// 添加栏目类别
        /// </summary>
        /// <param name="c"></param>
        public int AddCategory(Category c)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
               int id =  db.ExecuteProcedure("Shop_CategoryAdd" ,
                                    this.NewParam( "@CategoryName" , c.Name ) ,
                                    this.NewParam( "@ShopID" , ShopInfo.ID) ,
                                    this.NewParam( "@Type" , c.Type ),
                                    this.NewParam("@Path",""),
                                    this.NewParam("@Pater",c.Pater));

               if ( id > 0 )
               {
                   c.ID = id;
                   ShopInfo.Categorys.Add( c );
                   
               }

               return id;

            }

            
        }

        /// <summary>
        /// 修改栏目类别
        /// </summary>
        /// <param name="c"></param>
        public int UpdateCategory(Category c)
        {
            int result;
            using ( IDbExecutor db = this.NewExecutor() )
            {
               result = db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_CategoryUpdate" ,
                                    this.NewParam("@CategoryID",c.ID),
                                    this.NewParam( "@CategoryName" , c.Name ) ,
                                    this.NewParam( "@Type" , c.Type ) ,
                                    this.NewParam("@Pater",c.Pater),
                                    this.NewParam("@Path",""));
            }

            foreach (Category ca in ShopInfo.Categorys)
            {
                if (ca.ID == c.ID)
                {
                    ca.Name = c.Name;
                    ca.Type = c.Type;
                    ca.Pater = c.Pater;
                    ca.Path = c.Path;
                }
            }
            return result;
        }

        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="id"></param>
        public int DeleteCategory(Category c)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                int value= db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_CategoryDelete" ,
                                    this.NewParam( "@CategoryID" , c.ID ),
                                    this.NewParam("@ShopID",ShopInfo.ID));

                if ( value > 0 )
                {
                    ShopInfo.Categorys.Remove(ShopInfo.Categorys.GetById( c.ID )); 
                }
                return value;
                
            }      
        }

        /// <summary>
        /// 获取单个栏目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetCategoryByid(int id)
        {
            foreach (Category c in ShopInfo.Categorys)
            {
                if (c.ID == id)
                    return c;
            }
            return null;
        }

        /// <summary>
        /// 获取所有商品一级类别

        /// </summary>
        /// <returns></returns>
        public ArrayList GetCategoryName()
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetCategoryName" ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) );
            }
           ArrayList list = new ArrayList();
           foreach ( DataRow dr in ds.Tables[0].Rows )
           {

               Category ca = new Category();
               ca.ID=(int)dr["CategoryID"];
               ca.Name = (string)dr["CategoryName"];

               list.Add( ca );
           }
           return list;
        }

        /// <summary>
        /// 获取所有商品类别（有子级类别除外）
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ArrayList GetCategoryNameByTypeWeb()
        {
            ArrayList categorylist = (ArrayList)HttpRuntime.Cache["Categorylist_" + ShopInfo.ID.ToString()];

            if (categorylist != null)
            {
                return categorylist;
            }

            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetCategoryNameByType",
                                this.NewParam("@ShopID", ShopInfo.ID));
            }
            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int count = 0;
                foreach (DataRow dr2 in ds.Tables[0].Rows)
                {
                    if ((int)dr["Pater"] == 0 && (int)dr["CategoryID"] == (int)dr2["Pater"])
                    {
                        count += 1;
                    }
                }
                if (count == 0)
                {

                    Category ca = new Category();
                    ca.Name = (string)dr["CategoryName"];
                    ca.ID = (int)dr["CategoryID"];
                    list.Add(ca);
                }
            }
            HttpRuntime.Cache.Insert("Categorylist_" + ShopInfo.ID.ToString(), list, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(5));


            return list;
        }


        /// <summary>
        /// 获取所有商品类别（有子级类别除外）
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ArrayList GetCategoryNameByType()
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetCategoryNameByType" ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) );
            }
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                int count = 0;
                foreach (DataRow dr2 in ds.Tables[0].Rows)
                {
                    if ((int)dr["Pater"] == 0 && (int)dr["CategoryID"] == (int)dr2["Pater"])
                    {
                        count += 1;
                    }
                }
                if (count == 0)
                {

                    Category ca = new Category();
                    ca.Name = (string)dr["CategoryName"];
                    ca.ID = (int)dr["CategoryID"];
                    list.Add(ca);
                }
            }

            return list;
        }

        /// <summary>
        /// 获得所有文章类别

        /// </summary>
        /// <returns></returns>
        public ArrayList GetArticleType()
        { 
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetArticleType" ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) );
            }
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                Category a = new Category();
                a.ID = (int)dr["CategoryID"];
                a.Name = (string)dr["CategoryName"];
                list.Add( a );
            }
            return list;
        }

        /// <summary>
        /// 确保缓存中已经存在数据

        /// </summary>
        public void EnsureCache()
        {
            if ( ShopInfo.Categorys == null || ShopInfo.Categorys.Count== 0 )
            {
                this.EnsureCategory();
            }
        }

        /// <summary>
        /// 将类别加入ShopInfo
        /// </summary>
        public void EnsureCategory()
        {

            ShopInfo.Categorys = new ObjectList();
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_CategoryGetList" ,
                                   this.NewParam( "@ShopID" , ShopInfo.ID ) );
            }
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                Category c=new Category( dr );
                c.OfShop = ShopInfo;
                ShopInfo.Categorys.Add( c );

            }
        }

        /// <summary>
        /// 获取所有文章类别（缓存）

        /// </summary>
        /// <returns></returns>
        public ObjectList GetArticleCategories()
        {
            this.EnsureCache();
            ObjectList list = new ObjectList();
            foreach ( Category c in ShopInfo.Categorys )
            {
                if ( c.Type == 1 )
                    list.Add( c );
            }

            return list;
        }

        /// <summary>
        /// 获取所有商品类别（缓存）
        /// </summary>
        /// <returns></returns>
        public ObjectList GetPhotoCategories()
        {
            this.EnsureCache();
            ObjectList list = new ObjectList();
            foreach ( Category c in ShopInfo.Categorys )
            {
                if ( c.Type == 2 )
                {
                    bool child = true;

                    foreach ( Category ca in ShopInfo.Categorys )
                    {
                        if ( ca.Type == 2 && ca.Pater == c.ID )
                        {
                            child = false;

                            break;
                        }
                    }

                    if ( child == true )
                        list.Add( c );
                }
            }

            return list;
        }

        /// <summary>
        /// 获取商品所有父类别
        /// </summary>
        /// <returns></returns>
        public ObjectList GetGoodsCategoryPater()
        {
            ObjectList list = new ObjectList();
            foreach (Category c in ShopInfo.Categorys)
            {
                if (c.Type == 2 && c.Pater == 0)
                    list.Add(c);
            }

            return list;
        }

        /// <summary>
        /// 获取商品子类别
        /// </summary>
        /// <returns></returns>
        public ObjectList GetGoodsCategoryChild(int categoryid)
        {
            ObjectList list = new ObjectList();

            foreach (Category c in ShopInfo.Categorys)
            {
                if (c.Type == 2 && c.Pater == categoryid)
                    list.Add(c);
            }

            Category cg = new Category();
            cg.ID = 0;
            cg.Name = "所有";
            cg.Pater = categoryid;
            cg.Path = "p/" + categoryid;
            cg.OfShop = ShopInfo;

            list.Add(cg);

            return list;
        }

        /// <summary>
        /// 获得文章类别
        /// </summary>
        /// <returns></returns>
        public ArrayList GetArticleCategory()
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetArticleCategoryList" ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) );
            }
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                Category a = new Category();
                a.ID = (int)dr["CategoryID"];
                a.BackUrl = string.Format( "http://{0}/c/{1}.aspx" , ShopInfo.ShopDomain , (string)dr["Path"] );
                a.CreateAt = (DateTime)dr["CreateAt"];
                a.Path = (string)dr["Path"];
                a.Pater = (int)dr["Pater"];
                a.Type = (int)dr["Type"];
                a.Name = (string)dr["CategoryName"];
                list.Add( a );
            }
            return list;
        }



        /// <summary>
        /// 获取要设置栏目列表

        /// </summary>
        /// <returns></returns>
        public ArrayList GetSetCategory()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetSetCategory",
                                    this.NewParam("@ShopID", ShopInfo.ID));

            }

            ArrayList list = new ArrayList();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Category c = new Category();
                    c.ID = (int)dr["CategoryID"];
                    c.Name = (string)dr["CategoryName"];
                    c.IsShow = (bool)dr["IsShow"];
                    list.Add(c);
                }
            }

            return list;
        }

        /// <summary>
        /// 设置导航
        /// </summary>
        /// <param name="categoryid"></param>
        public void SetCategory(string categoryid,int count)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_SetCategory",
                                    this.NewParam("@ShopID",ShopInfo.ID),
                                    this.NewParam("@CategoryString", categoryid),
                                    this.NewParam("@Count",count));
            }
        }

    }

}
