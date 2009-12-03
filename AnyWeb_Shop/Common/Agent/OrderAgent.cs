using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Studio.Data;
using System.Data;
using Common.Common;
using Studio.Array;
using System.Web;

namespace Common.Agent
{
    public class OrderAgent:AgentBase
    {

        /// <summary>
        /// 订单列表
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="pageno"></param>
        /// <param name="orderid"></param>
        /// <param name="username"></param>
        /// <param name="status"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        public ArrayList GetOrderList(int userid,int pagesize , int pageno , int orderid , string username , int status , DateTime starttime , DateTime endtime ,DateTime ordertime,DateTime ordertime2, out int record)
        {
            DataSet ds;

            IDbDataParameter records = this.NewParam( "@RecordCount" , 0 , DbType.Int32 , 8 , true );
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetOrderList" ,
                                this.NewParam( "@PageSize" , pagesize ) ,
                                this.NewParam( "PageNo" , pageno ) ,
                                this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                this.NewParam( "@Status" , status ) ,
                                this.NewParam( "@OrderID" , orderid ) ,
                                this.NewParam( "@UserName" , username ) ,
                                this.NewParam( "@StartTime" , starttime ) ,
                                this.NewParam( "@EndTime" , endtime ) ,
                                this.NewParam( "@OrderTime" , ordertime ) ,
                                this.NewParam( "@OrderTime2" , ordertime2 ) ,
                                this.NewParam("@UserID",userid),
                               records );
            }
            ArrayList list = new ArrayList();
            record = (int)records.Value;
            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                Order o = new Order();
                o.ID = (int)dr["OrderID"];
                o.Price = (double)dr["Price"];
                o.Status=(int)dr["Status"];
                o.UserName = (string)dr["UserName"];
                o.CreateAt = (DateTime)dr["CreateAt"];
                o.DeliverTime = (DateTime)dr["DeliverTime"];
                list.Add(o);
            }

            return list;
        }


        /// <summary>
        /// 获得单个订单信息
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public Order GetOrderByID(int oid)
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetOrderByID" ,
                                    this.NewParam( "@OrderID" , oid ) );
            }
            if ( ds.Tables[0].Rows.Count > 0 )
            {
                Order o = new Order( ds.Tables[0].Rows[0] );
                o.TotalPrice = (double)ds.Tables[0].Rows[0]["Price"] - (double)ds.Tables[0].Rows[0]["PaymentPrice"] - (double)ds.Tables[0].Rows[0]["DeliverPrice"];
      
                Mode m1 = new Mode();
                if ( ds.Tables[1].Rows.Count > 0 )
                {
                    m1.Title = (string)ds.Tables[1].Rows[0]["Title"];
                    m1.ID = (int)ds.Tables[1].Rows[0]["ModeID"];
                    o.OfPayMode = m1;
                }
                if ( ds.Tables[2].Rows.Count > 0 )
                {
                    Mode m2 = new Mode();
                    m2.Title = (string)ds.Tables[2].Rows[0]["Title"];
                    m2.CreateAt = (DateTime)ds.Tables[2].Rows[0]["CreateAt"];
                    m2.ID = (int)ds.Tables[2].Rows[0]["ModeID"];
                    o.OfSendMode = m2;
                }
                if ( ds.Tables[3].Rows.Count > 0 )
                {
                    o.OrderItems = new ObjectList();

                    foreach ( DataRow dr in ds.Tables[3].Rows )
                    {
                        Order_Item oi = new Order_Item();
                        oi.ID = (int)dr["ItemID"];
                        oi.Quantity = (int)dr["Quantity"];


                        Goods g = new Goods();
                        g.ID = (int)dr["GoodsID"];
                        g.GoodsName = (string)dr["GoodsName"];
                        g.Image = (string)dr["Image"];
                        g.Score = (int)dr["Score"];
                        g.Unit = (string)dr["Unit"];
                        g.Price = (double)dr["Price"];
                        g.OfCategory = ( new CategoryAgent() ).GetCategoryByid( (int)dr["CategoryID"] );
                        g.OfCategory.OfShop = ShopInfo;
                        oi.OfGoods = g;

                        o.OrderItems.Add(oi);
                    }
                }
                if ( ds.Tables[4].Rows.Count > 0 )
                {
                    o.ChangeList = new ObjectList();
                    foreach ( DataRow dr in ds.Tables[4].Rows )
                    {
                        ChangeNote cn = new ChangeNote();
                        cn.ID = (int)dr["ChangeNoteID"];

                        cn.OfChangeGoods = new ChangeGoods();

                        cn.OfChangeGoods.Name = (string)dr["ChangeName"];
                        cn.OfChangeGoods.Image = (string)dr["Image"];
                        cn.NoteTime = (DateTime)dr["NoteTime"];
                        cn.OfChangeGoods.Score = (int)dr["Score"];
                        cn.OfChangeGoods.Price = (double)dr["Price"];

                        o.ChangeList.Add( cn );
                    }
                  
                   
                }

                return o;
            }
            else
            {
                return null;
            }
        }
       /// <summary>
       /// 获得订单项
       /// </summary>
       /// <param name="orderid"></param>
       /// <returns></returns>
        public ArrayList GetOrderItems(int orderid)
        {

            DataSet ds;

            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetOrderItems" ,
                                this.NewParam( "@OrderID" , orderid ) );
            }

            Order o = new Order();
            ObjectList list = new ObjectList();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Order_Item oi = new Order_Item();
                Goods g = new Goods();
                oi.ID = (int)dr["ItemID"];
                oi.Quantity = (int)dr["Quantity"];

                g.ID = (int)dr["GoodsID"];
                g.GoodsName = (string)dr["GoodsName"];

                g.OfCategory = (Category)ShopInfo.Categorys.GetById((int)dr["CategoryID"]);
                g.Image = (string)dr["Image"];
                g.Unit = (string)dr["Unit"];
                g.Price = (double)dr["Price"];
                g.Score = (int)dr["Score"];

                oi.OfGoods = g;

                list.Add(oi);
            }

            o.OrderItems = list;

            return list;

        }

        /// <summary>
        /// 获取购物车,没有则创建
        /// </summary>
        /// <returns></returns>
        public Order GetShopCart()
        {
            string sessionID = "SHOP_" + ShopInfo.ID.ToString();

            Order o = (Order)HttpContext.Current.Session[sessionID];
            if (o == null)
            {
                o = new Order();
                o.OrderItems = new ObjectList();

                int userid = 0;
                if (UserInfo != null)
                {
                    userid = UserInfo.ID;
                }

                o.ShopID = ShopInfo.ID;
                o.Status = 1;

                o.UserID = userid;
                o.CreateAt = DateTime.Now;

                HttpContext.Current.Session.Add(sessionID, o);

            }
            return o;          

        }

        /// <summary>
        /// 提交订单
        /// </summary>
        /// <returns></returns>
        public int AddOrder()
        {
            Order o = GetShopCart();

            if (o.OrderItems == null || o.OrderItems.Count == 0)
            {
                return 0;
            }
            using (IDbExecutor db = this.NewExecutor())
            {
                o.ID = db.ExecuteProcedure("Shop_OrderAdd",
                        this.NewParam("@ShopID", ShopInfo.ID),
                        this.NewParam("@UserID", UserInfo == null ?0:UserInfo.ID),
                        this.NewParam("@CreateAt", o.CreateAt),
                        this.NewParam("@Price", o.MathPaymentPrice),
                        this.NewParam("@UserName", o.UserName),
                        this.NewParam("@UserEmail", o.UserEmail),
                        this.NewParam("@UserPhone", o.UserPhone),
                        this.NewParam("@Mobile", o.Mobile),
                        this.NewParam("@Address", o.Address),
                        this.NewParam("@Postalcode", o.Postalcode),
                        this.NewParam("@DeliverTime", o.DeliverTime),
                        this.NewParam("@Remark", o.Remark),
                        this.NewParam("@DeliverModeID", o.OfSendMode.ID),
                        this.NewParam("@PaymentModeID", o.OfPayMode.ID),
                        this.NewParam("@PaymentPrice", o.OfPayMode.MathPayMent),
                        this.NewParam("@DeliverPrice", o.OfSendMode.MathDeliver));
            }

            if (o.ID == 0)
            {
                return 0;
            }

            foreach (Order_Item oi in o.OrderItems)
            {
                using (IDbExecutor db = this.NewExecutor())
                {
                    db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_OrderItemAdd",
                                        this.NewParam("@OrderID", o.ID),
                                        this.NewParam("@GoodsID", oi.OfGoods.ID),
                                        this.NewParam("@Quantity", oi.Quantity));
                }
            }
            return o.ID;
        }

        /// <summary>
        /// 移除购物车
        /// </summary>
        public void RemoveShopCart()
        {
            string sessionID = "SHOP_" + ShopInfo.ID.ToString();

            HttpContext.Current.Session.Remove(sessionID);
        }


        /// <summary>
        /// 处理订单
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public int DealOrder(int status,int orderid,int point,int memberid,string cancelreson)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
              int value=  db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_DealOrder" ,
                                this.NewParam( "@OrderID" , orderid ) ,
                                this.NewParam( "@Status" , status ) ,
                                this.NewParam("@MemberID",memberid),
                                this.NewParam("@Point",point),
                                this.NewParam( "@CancleReson",cancelreson ) );
              if ( value > 0 )
              {
                  HttpContext.Current.Cache.Remove( ShopInfo.ID.ToString() + "USER_INFO_" + memberid.ToString() );
              }
              return value;
            }
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="o"></param>
        public void UpdateOrderWeb(Order o)
        {
            Order o1 = GetShopCart();

            o1.Address = o.Address;
            o1.DeliverTime = o.DeliverTime;
            o1.UserEmail = o.UserEmail;

            o1.UserName = o.UserName;
            o1.Remark = o.Remark;

            o1.UserPhone = o.UserPhone;

            o1.Mobile = o.Mobile;
            o1.Postalcode = o.Postalcode;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public void OrderDelete(string ids,int count)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                 db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_OrderDelete" ,
                                    this.NewParam( "@OrderIDs" , ids ) ,
                                    this.NewParam( "@Count" , count ) );
            }
        }

        /// <summary>
        /// 删除单个订单
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public int OrderDeleteByID(Order o)
        {

            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_OrderDeleteByID" ,
                                   this.NewParam( "@OrderID" , o.ID )  );
            }
        }


        /// <summary>
        /// 订单统计
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public int OrderStat(int status)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteProcedure("Shop_GetOrderStat" ,
                                   this.NewParam( "@Status" , status ),
                                   this.NewParam("@ShopID",ShopInfo.ID));
            }
        }
    }
}
