using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Studio.Data;
using Common.Framework;
using Common.Common;
using Studio.Array;
using System.Collections;
namespace Common.Agent
{
    public class WidGetAgent : AgentBase
    {
        /// <summary>
        /// 获取所有组件
        /// </summary>
        /// <returns>返回所有组件</returns>
        public bool GetWidgets()
        {
            DataSet ds = new DataSet();
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetWidgets" );
            }

            SysSetting.GetSetting().SysWidgets = new ObjectList();

            foreach ( DataRow r in ds.Tables[0].Select( "WidgetType=1" ) )
            {
                SysSetting.GetSetting().SysWidgets.Add( new Widget( r ) );
            }

            SysSetting.GetSetting().LeftWidgets = new ObjectList();
            foreach ( DataRow r in ds.Tables[0].Select( "WidgetType=2" ) )
            {
                SysSetting.GetSetting().LeftWidgets.Add( new Widget( r ) );
            }

            SysSetting.GetSetting().ContentWidgets = new ObjectList();
            foreach ( DataRow r in ds.Tables[0].Select( "WidgetType=3" ) )
            {
                SysSetting.GetSetting().ContentWidgets.Add( new Widget( r ) );
            }
            SysSetting.GetSetting().ListLeftWidgets = new ObjectList();
            foreach ( DataRow r in ds.Tables[0].Select( "WidgetType=4" ) )
            {
                SysSetting.GetSetting().ListLeftWidgets.Add( new Widget( r ) );
            }
            SysSetting.GetSetting().ArticleLeftWidgets = new ObjectList();
            foreach ( DataRow r in ds.Tables[0].Select( "WidgetType=5" ) )
            {
                SysSetting.GetSetting().ArticleLeftWidgets.Add( new Widget( r ) );
            }
            SysSetting.GetSetting().GoodsLeftWidgets = new ObjectList();
            foreach ( DataRow r in ds.Tables[0].Select( "WidgetType=6" ) )
            {
                SysSetting.GetSetting().GoodsLeftWidgets.Add( new Widget( r ) );
            }
            SysSetting.GetSetting().CarLeftWidgets = new ObjectList();
            foreach ( DataRow r in ds.Tables[0].Select( "WidgetType=7" ) )
            {
                SysSetting.GetSetting().CarLeftWidgets.Add( new Widget( r ) );
            }

            SysSetting.GetSetting().UserLeftWidgets = new ObjectList();
            foreach ( DataRow r in ds.Tables[0].Select( "WidgetType=8" ) )
            {
                SysSetting.GetSetting().UserLeftWidgets.Add( new Widget( r ) );
            }

          

            return true;
        }


        /// <summary>
        /// 初始化所有侧边组件
        /// </summary>
        /// <returns></returns>
        public ArrayList GetAllWidget(ObjectList widgets)
        {
            new CategoryAgent().EnsureCache();

            ArrayList list = new ArrayList();
            
            foreach ( Widget w in widgets )
            {
                switch ( w.ID )
                {
                    case 9://文章
                    case 12:
                    case 79:
                    case 22:
                    case 25:
                    case 27:
                    case 29:
                        {
                            ObjectList articleCategory = new CategoryAgent().GetArticleCategories();
                            if ( articleCategory.Count == 0 )
                            {
                                validWidget va = new validWidget();
                                va.DataID = -1;
                                va.Name = w.WidgetName;

                                va.OfWidget = new Widget();
                                va.OfWidget = w;

                                list.Add( va );
                            }
                            else
                            {
                                foreach ( Category c in articleCategory )
                                {
                                    validWidget va = new validWidget();
                                    va.DataID = c.ID;
                                    va.Name = w.WidgetName + "【" + c.Name + "】";

                                    va.OfWidget = new Widget();
                                    va.OfWidget = w;

                                    list.Add( va );

                                }
                            }
                            break;
                        }
                       
                    case 13://商品
                   
                        {
                            ObjectList goodsCategory = new CategoryAgent().GetPhotoCategories();
                            if ( goodsCategory.Count == 0 )
                            {
                                validWidget va = new validWidget();
                                va.DataID = -1;
                                va.Name = w.WidgetName;

                                va.OfWidget = new Widget();
                                va.OfWidget = w;

                                list.Add( va );
                            }
                            else
                            {
                                foreach ( Category c in goodsCategory )
                                {
                                    validWidget va = new validWidget();
                                    va.DataID = c.ID;
                                    va.Name = w.WidgetName + "【" + c.Name + "】";

                                    va.OfWidget = new Widget();
                                    va.OfWidget = w;

                                    list.Add( va);
                                }
                            }
                            break;
                        }

                    case 67:
                    case 85:
                    case 86:
                    case 87:
                    case 88:
                    case 89:
                    case 90://广告
                        {
                            ObjectList advertisement = new AdvertisementAgent().GetAdverList();
                            if ( advertisement.Count == 0 )
                            {
                                validWidget va = new validWidget();
                                va.DataID = -1;
                                va.Name = w.WidgetName;

                                va.OfWidget = new Widget();
                                va.OfWidget = w;

                                list.Add( va );
                            }
                            else
                            {
                                foreach ( Advertisement adv in advertisement )
                                {
                                    validWidget va = new validWidget();
                                    va.DataID = adv.ID;
                                    va.Name = w.WidgetName + "【" +adv.AdTitle + "】";

                                    va.OfWidget = new Widget();
                                    va.OfWidget = w;

                                    list.Add( va );
                                }
                            }
                            break;
                        }
                    case 66:
                        {
                            validWidget va = new validWidget();
                            va.DataID = 0;
                            va.Name = w.WidgetName ;

                            va.OfWidget = new Widget();
                            va.OfWidget = w;

                            list.Add( va );
                            break; 
                        }
                    default:
                        {
                            validWidget va = new validWidget();
                            va.DataID = 0;
                            va.Name = w.WidgetName;

                            va.OfWidget = new Widget();
                            va.OfWidget = w;

                            list.Add( va );
                            break;
                        }
                }
            }
            return list;
        }

        //public ArrayList GetContentWidget()
        //{
        //    ArrayList list = new ArrayList();
        //    foreach ( Widget w in SysSetting.GetSetting().ContentWidgets )
        //    { 
        //        switch(w.ID)
        //        {
        //            case 9://文章列表
        //                ObjectList articleList = new CategoryAgent().GetArticleCategories();
        //                if ( articleList.Count == 0 )
        //                {
        //                    validWidget va = new validWidget();

        //                }
        //                break;
        //            case 13://图片列表
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}

        /// <summary>
        /// 获得所有组件
        /// </summary>
        /// <param name="widgetType">1-系统组件 2-侧栏组件 3-内容区组件</param>
        /// <returns></returns>
        public ArrayList GetAllUserWidget(int widgetType)
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetUserWidgetList" ,
                            this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                            this.NewParam( "@WidgetType" , widgetType ) );
            }
            ArrayList list = new ArrayList();
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                UserWidget uw = new UserWidget( dr );
                Widget w = new Widget();
                w.ID = (int)dr["WidgetID"];
                w.Icon = (string)dr["Icon"];
                w.WidgetType = (int)dr["WidgetType"];
                uw.OfWidget = w;

                list.Add( uw );
            }
            return list;
        }

        /// <summary>
        /// 获取首页所有组件
        /// </summary>
        /// <returns></returns>
        public ArrayList GetHomeWidGet()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetHomeWidGet",
                                         this.NewParam("@ShopID", ShopInfo.ID));
            }
            ArrayList list = new ArrayList();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                UserWidget uw = new UserWidget(dr);
                Widget w = new Widget();
                w.ID = (int)dr["WidgetID"];
                w.Icon = (string)dr["Icon"];
                w.WidgetType = (int)dr["WidgetType"];
                uw.OfWidget = w;

                list.Add(uw);
            }
            return list;
        }

        /// <summary>
        /// 修改组件
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int UpdateWidget(string data,int wtype)
        {
          
            this.DeleteWidget( wtype );

            string[] widget = data.Split( ',' );
         
            using ( IDbExecutor db = this.NewExecutor() )
            {
                for ( int i = 0 ; i < widget.Length ; i++ )
                {
                    string wdata = widget[i];
                    if ( wdata != "" )
                    {
                        string[] ws = wdata.Split( '|' );
                        db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_UserWidgetAdd" ,
                                      this.NewParam( "@WidgetID" , int.Parse( ws[0] ) ) ,
                                      this.NewParam( "@Name" , ws[1] ) ,
                                      this.NewParam( "@Sort" , i ) ,
                                      this.NewParam( "@DataID" , int.Parse( ws[2] ) ) ,
                                      this.NewParam( "@ShopID" , ShopInfo.ID ) );
                    }
                }
            }
            
            return 1;
        }

        /// <summary>
        /// 修改列表页侧边组件
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //public int UpdateListLeftWidget(string data)
        //{
        //    this.DeleteWidget( 4 );
        //    string[] widget = data.Split( ',' );

        //    using ( IDbExecutor db = this.NewExecutor() )
        //    {
        //        for ( int i = 0 ; i < widget.Length ; i++ )
        //        {
        //            string wdata = widget[i];
        //            string[] ws = wdata.Split( '|' );
        //            db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_UserWidgetAdd" ,
        //                          this.NewParam( "@WidgetID" , int.Parse( ws[0] ) ) ,
        //                          this.NewParam( "@Name" , ws[1] ) ,
        //                          this.NewParam( "@Sort" , i ) ,
        //                          this.NewParam( "@DataID" , int.Parse( ws[2] ) ) ,
        //                          this.NewParam( "@ShopID" , ShopInfo.ID ) );
        //        }
        //    }
        //    return 1;
        //}

        /// <summary>
        /// 清空组件
        /// </summary>
        /// <param name="widgetType"></param>
        /// <returns></returns>
        public int DeleteWidget(int widgetType)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_DeleteWidget" ,
                                    this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                    this.NewParam( "@WidgetType" , widgetType ) );
            }
        }
    }
}
