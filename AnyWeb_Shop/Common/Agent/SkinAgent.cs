using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;

using Studio.Data;

using Common.Framework;
using Common.Common;
using System.Collections;
using Studio.Web;
using System.Web;
using System.IO;
using Studio.IO;

namespace Common.Agent
{
   public class SkinAgent:AgentBase
    {

        /// <summary>
        /// 获取模版
        /// </summary>
        /// <returns></returns>
        public bool GetSkinList()
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetSkinList");
            }

                SysSetting.GetSetting().Skins = new ObjectList();

                foreach (DataRow dr in ds.Tables[0].Rows)
                    SysSetting.GetSetting().Skins.Add(new Skin(dr));

                return true;

        }

       /// <summary>
       /// 获取该商店所属类别下的所有模版
       /// </summary>
       /// <param name="typeID"></param>
       /// <returns></returns>
       public ArrayList GetSkinsOfShop(int typeID)
       {
           DataSet ds;
           using ( IDbExecutor db = this.NewExecutor() )
           {
               ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetSkinsOfShop" ,
                               this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                               this.NewParam( "@TypeID" , typeID ) );
           }
           ArrayList list = new ArrayList();
           foreach ( DataRow dr in ds.Tables[0].Rows )
           {
               list.Add(new Skin( dr ));
           }
           return list;
       }


       /// <summary>
       /// 更换商店模版
       /// </summary>
       /// <param name="skinid"></param>
       /// <returns></returns>
       public int ChangeShopSkin(int skinid,int typeid)
       {
           using ( IDbExecutor db = this.NewExecutor() )
           {
               return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ChangeShopSkin" ,
                                   this.NewParam( "@SkinID" , skinid ),
                                   this.NewParam("@TypeID",typeid),
                                   this.NewParam("@ShopID",ShopInfo.ID));
           }
       }


       /// <summary>
       /// 获得公司模版名称
       /// </summary>
       /// <returns></returns>
       public Shop GetShopSkinName()
       {
           DataSet ds;
           using ( IDbExecutor db = this.NewExecutor() )
           {
               ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetShopSkinName" ,
                                this.NewParam("@ShopID",ShopInfo.ID));
           }
           if ( ds.Tables[0].Rows.Count> 0 )
           {
               Shop sp = new Shop();
               sp.OfSkin = new Skin();
               sp.OfSkin.SkinName = (string)ds.Tables[0].Rows[0]["SkinName"];
               sp.OfType = new Typies();
               sp.OfType.TypeName = (string)ds.Tables[0].Rows[0]["TypeName"];
               return sp;
           }
           else 
           {
               return null;
           }
       }


       /// <summary>
       /// 修改首页css代码
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public int SaveHomeCss(Shop s)
       {
           using ( IDbExecutor db = this.NewExecutor() )
           {
               return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SaveHomeCss" ,
                                   this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                   this.NewParam( "@HomeCss" , s.HomeCss ) );
           }
       }

       /// <summary>
       /// 设置内页css代码
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public int SavePageCss(Shop s)
       {
           using ( IDbExecutor db = this.NewExecutor() )
           {
               return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SavePageCss" ,
                                   this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                   this.NewParam( "@PageCss" , s.PageCss ) );
           }
       }

   

       /// <summary>
       /// 设置购物车css代码
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public int SaveCarCss(Shop s)
       {
           using ( IDbExecutor db = this.NewExecutor() )
           {
               return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SaveCarCss" ,
                                   this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                   this.NewParam( "@CarCss" , s.CarCss ) );
           }
       }

       /// <summary>
       /// 设置文章css代码
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public int SaveArticleCss(Shop s)
       {
           using ( IDbExecutor db = this.NewExecutor() )
           {
               return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SaveArticleCss" ,
                                   this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                   this.NewParam( "@ArticleCss" , s.ArticleCss ) );
           }
       }

       /// <summary>
       /// 设置商品css代码
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public int SaveGoodsCss(Shop s)
       {
           using ( IDbExecutor db = this.NewExecutor() )
           {
               return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SaveGoodsCss" ,
                                   this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                   this.NewParam( "@GoodsCss" , s.GoodsCss ) );
           }
       }

       /// <summary>
       /// 设置列表页css代码
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public int SaveListCss(Shop s)
       {
           using ( IDbExecutor db = this.NewExecutor() )
           {
               return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SaveListCss" ,
                                   this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                   this.NewParam( "@ListCss" , s.ListCss ) );
           }
       }


       /// <summary>
       /// 获得 css代码
       /// </summary>
       /// <returns></returns>
       public Shop GetCss()
       {
           DataSet ds;
           using ( IDbExecutor db = this.NewExecutor() )
           {
               ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetCss" ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) );
                
           }
           if ( ds.Tables[0].Rows.Count > 0 )
           {
               Shop s = new Shop();
               s.ID = (int)ds.Tables[0].Rows[0]["ShopID"];
               s.HomeCss = ds.Tables[0].Rows[0]["HomeCss"] == System.DBNull.Value ? "" : (string)ds.Tables[0].Rows[0]["HomeCss"];
               s.ListCss = ds.Tables[0].Rows[0]["ListCss"] == System.DBNull.Value ? "" : (string)ds.Tables[0].Rows[0]["ListCss"]; ;
               s.GoodsCss = ds.Tables[0].Rows[0]["GoodsCss"] == System.DBNull.Value ? "" : (string)ds.Tables[0].Rows[0]["GoodsCss"]; ;
               s.CarCss = ds.Tables[0].Rows[0]["CarCss"] == System.DBNull.Value ? "" : (string)ds.Tables[0].Rows[0]["CarCss"]; ;
               s.ArticleCss = ds.Tables[0].Rows[0]["ArticleCss"] == System.DBNull.Value ? "" : (string)ds.Tables[0].Rows[0]["ArticleCss"]; ;
               s.PageCss = ds.Tables[0].Rows[0]["PageCss"] == System.DBNull.Value ? "" : (string)ds.Tables[0].Rows[0]["PageCss"]; ;

               return s;
           }
           else
           {
               return null;
           }
       }

     }
}
