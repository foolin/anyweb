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
        /// ��ȡ�������
        /// </summary>
        /// <returns>�����������</returns>
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
        /// ��ʼ�����в�����
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
                    case 9://����
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
                                    va.Name = w.WidgetName + "��" + c.Name + "��";

                                    va.OfWidget = new Widget();
                                    va.OfWidget = w;

                                    list.Add( va );

                                }
                            }
                            break;
                        }
                       
                    case 13://��Ʒ
                   
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
                                    va.Name = w.WidgetName + "��" + c.Name + "��";

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
                    case 90://���
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
                                    va.Name = w.WidgetName + "��" +adv.AdTitle + "��";

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
        //            case 9://�����б�
        //                ObjectList articleList = new CategoryAgent().GetArticleCategories();
        //                if ( articleList.Count == 0 )
        //                {
        //                    validWidget va = new validWidget();

        //                }
        //                break;
        //            case 13://ͼƬ�б�
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="widgetType">1-ϵͳ��� 2-������� 3-���������</param>
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
        /// ��ȡ��ҳ�������
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
        /// �޸����
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
        /// �޸��б�ҳ������
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
        /// ������
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
