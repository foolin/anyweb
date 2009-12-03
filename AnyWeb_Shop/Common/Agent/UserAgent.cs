using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using Common.Common;
using System.Data;
using System.Web;
using System.Collections;
using Studio.Web;

namespace Common.Agent
{
    public class UserAgent:AgentBase
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="useracc">用户名</param>
        /// <param name="userpwd">密码</param>
        /// <returns></returns>
        public int UserLogin(string useracc, string userpwd)
        {
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_UserLogin",
                                    this.NewParam("@MemberAcc", useracc),
                                    this.NewParam("@MemberPass", userpwd),
                                    this.NewParam("@ShopID",ShopInfo.ID));
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                return 2;
            }
            if ((short)ds.Tables[0].Rows[0]["Status"] != 0)
            {
                return 1;
            }
            User u = new User(ds.Tables[0].Rows[0]);
            u.GradeName = (string)ds.Tables[0].Rows[0]["GradeName"];
            u.GradeID = (int)ds.Tables[0].Rows[0]["GradeID"];
            u.OfShop = ShopInfo;

            HttpCookie cok = new HttpCookie("USER_ID",u.ID.ToString());

            HttpContext.Current.Response.SetCookie(cok);

            HttpContext.Current.Cache.Insert(ShopInfo.ID.ToString() + "USER_INFO_" + u.ID, u,null,System.Web.Caching.Cache.NoAbsoluteExpiration,TimeSpan.FromMinutes(30));

            return 0;
        }


        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserInfo(int id)
        {
            //User u = (User)HttpRuntime.Cache[ShopInfo.ID.ToString() + "USER_INFO_" + id.ToString()];

            //if (u != null)
            //{
            //    return u;
            //}

            User u = new User();

            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetUserInfo",
                    this.NewParam("@UserID", id),
                    this.NewParam("@ShopID",ShopInfo.ID));

                if (ds.Tables[0].Rows.Count == 1)
                {
                    u = new User(ds.Tables[0].Rows[0]);
                    u.GradeName = (string)ds.Tables[0].Rows[0]["GradeName"];
                    u.GradeID = (int)ds.Tables[0].Rows[0]["GradeID"];
                    u.OfShop = ShopInfo;

                    //HttpCookie cok = new HttpCookie("USER_ID", u.ID.ToString());

                    //HttpContext.Current.Response.SetCookie(cok);

                    //HttpContext.Current.Cache.Insert(ShopInfo.ID.ToString() + "USER_INFO_" + u.ID, u, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(30));

                }
            }
            return u;
        }

        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserInfoWeb(int id)
        {
            User u = (User)HttpRuntime.Cache[ShopInfo.ID.ToString() + "USER_INFO_" + id.ToString()];

            if ( u != null )
            {
                return u;
            }

            DataSet ds = new DataSet();
            using ( IDbExecutor db = this.NewExecutor() )
            {

                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetUserInfo" ,
                    this.NewParam( "@UserID" , id ) ,
                    this.NewParam( "@ShopID" , ShopInfo.ID ) );

                if ( ds.Tables[0].Rows.Count == 1 )
                {
                    u = new User( ds.Tables[0].Rows[0] );
                    u.GradeName = (string)ds.Tables[0].Rows[0]["GradeName"];
                    u.GradeID = (int)ds.Tables[0].Rows[0]["GradeID"];
                    u.OfShop = ShopInfo;

                    HttpContext.Current.Cache.Insert( ShopInfo.ID.ToString() + "USER_INFO_" + u.ID , u , null , System.Web.Caching.Cache.NoAbsoluteExpiration , TimeSpan.FromMinutes( 30 ) );

                }
            }
            return u;
        }
     
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UserRegist(User u)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
               return db.ExecuteProcedure("Shop_UserRegist",
                                    this.NewParam("@MemberAcc", u.MemberAcc),
                                    this.NewParam("@MemberPass", Studio.Security.Secure.Md5(u.MemberPass)),
                                    this.NewParam("@MemberName", u.MemberName),
                                    this.NewParam("@ShopID", ShopInfo.ID),
                                    this.NewParam("@Status", u.Status),
                                    this.NewParam("@Sex", u.Sex),
                                    this.NewParam("@Photo", u.Photo),
                                    this.NewParam("@Address", u.Address),
                                    this.NewParam("@Mobile", u.Mobile),
                                    this.NewParam("@Phone", u.Phone),
                                    this.NewParam("@Email", u.Email),
                                    this.NewParam("@RegisterEmail",u.RegisterEmail),
                                    this.NewParam("@QQ", u.QQ),
                                    this.NewParam("@MSN", u.MSN),
                                    this.NewParam("@OtherContact", u.OtherContact),
                                    this.NewParam("@Point", u.Point),
                                    this.NewParam("@Advance", u.Advance),
                                    this.NewParam("@Postalcode", u.Postalcode));

           
            }
        }

        /// <summary>
        /// 判断帐号是否存在
        /// </summary>
        /// <param name="useracc"></param>
        /// <returns></returns>
        public int ExistUserAcc(string useracc)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteProcedure("Shop_ExistUserAcc",
                    this.NewParam("@UserAcc", useracc),
                    this.NewParam( "@ShopID" , ShopInfo.ID ) );
            }
        }

        /// <summary>
        /// 获取用户订单
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public ArrayList GetUserOrder(int userid,int status)
        {
            DataSet ds = new DataSet();

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetUserOrder",
                                    this.NewParam("@UserID", userid),
                                    this.NewParam("@ShopID", ShopInfo.ID),
                                    this.NewParam("@Status",status));

            }

            ArrayList list = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Order o = new Order();
                o.ID = (int)dr["OrderID"];
                o.Price = (double)dr["Price"];
                o.Status = (int)dr["Status"];
                o.UserName = (string)dr["UserName"];
                o.DeliverTime = (DateTime)dr["DeliverTime"];
                o.CreateAt = (DateTime)dr["CreateAt"];
                list.Add(o);
            }

            return list;
        }

        /// <summary>
        /// 移除用户信息 
        /// </summary>
        /// <param name="id"></param>
        public void RemoveUser()
        {

            HttpCookie cok = HttpContext.Current.Response.Cookies["USER_ID"];

            if (cok != null)
            {
                HttpContext.Current.Cache.Remove(ShopInfo.ID.ToString() + "USER_INFO_" + cok.Value);

                cok.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.SetCookie(cok);
            }
        }

        /// <summary>
        /// 获取商店会员列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetUserList(int pageSize, int pageNo, out int recordCount)
        {
            DataSet ds = new DataSet();

            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter recount = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetUser",
                                    this.NewParam("@ShopID", ShopInfo.ID),
                                    this.NewParam("@PageSize", pageSize),
                                    this.NewParam("@PageNo", pageNo),
                                    recount);

                recordCount = (int)recount.Value;
            }

            ArrayList list = new ArrayList();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                User u = new User(dr);
                u.OfShop = ShopInfo;

                list.Add(u);
            }

            return list;
        }

        /// <summary>
        /// 获取商店会员列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public ArrayList GetUserList2(string userName,string useracc,int status,int pageSize , int pageNo , out int recordCount)
        {
            DataSet ds = new DataSet();

            using ( IDbExecutor db = this.NewExecutor() )
            {
                IDbDataParameter recount = this.NewParam( "@RecordCount" , 0 , DbType.Int32 , 8 , true );

                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetUserList" ,
                                    this.NewParam("@MemberAcc",useracc),
                                    this.NewParam("@MemberName",userName),
                                    this.NewParam("@Status",status),
                                    this.NewParam( "@ShopID" , ShopInfo.ID ) ,
                                    this.NewParam( "@PageSize" , pageSize ) ,
                                    this.NewParam( "@PageNo" , pageNo ) ,
                                    recount );

                recordCount = (int)recount.Value;
            }

            ArrayList list = new ArrayList();

            foreach ( DataRow dr in ds.Tables[0].Rows )
            {
                User u = new User( dr );
                list.Add( u );
            }

            return list;
        }

        /// <summary>
        /// 添加积分
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="point"></param>
        public void UpdateUserPoint(int userid,int point)
        {
             
            using (IDbExecutor db = this.NewExecutor())
            {
                 db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_UpdateUserPoint",
                                        this.NewParam("@Point", point),
                                        this.NewParam("@UserID", userid),
                                        this.NewParam("@ShopID", ShopInfo.ID));
            }
        }


        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdateUserStatus(int userid, int status)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_UpdateUserStatus",
                                        this.NewParam("@Status", status),
                                        this.NewParam("@UserID", userid),
                                        this.NewParam("@ShopID", ShopInfo.ID));
            }
        }

        /// <summary>
        /// 冻结用户
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="status"></param>
        /// <param name="freezeReson"></param>
        /// <returns></returns>
        public int SetFreezeUser(int userid , string freezeReson)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_FreezeUserUpdate" ,
                                        this.NewParam( "@UserID" , userid ) ,
                                        this.NewParam( "@FreezeReson" , freezeReson ) );
            }
        }

        /// <summary>
        /// 找回会员密码
        /// </summary>
        /// <param name="memberacc"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public User FindMemberPass(string memberacc , string email)
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_FindMemberPass" ,
                                this.NewParam("@MemberAcc",memberacc),
                                this.NewParam("@ShopID",ShopInfo.ID),
                                this.NewParam( "@RegisterEmail" , email ) );
            }
            if ( ds.Tables[0].Rows.Count == 0 )
                return null;
            else
               return  new User( ds.Tables[0].Rows[0] );
        }



        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdateUser(User u)
        {  
            using (IDbExecutor db = this.NewExecutor())
            {

                int value= db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_MemberUpdate" ,
                                        this.NewParam("@MemberName", u.MemberName),
                                        this.NewParam("@MemberID", UserInfo.ID),
                                        this.NewParam( "@Address" , u.Address ) ,
                                        this.NewParam( "@Phone" , u.Phone) ,
                                        this.NewParam( "@Email" , u.Email ) ,
                                        this.NewParam( "@QQ" , u.QQ ) ,
                                        this.NewParam( "@MSN" , u.MSN ) ,
                                        this.NewParam( "@Postalcode" , u.Postalcode ) ,
                                        this.NewParam("@Mobile",u.Mobile),
                                        this.NewParam("@Sex", u.Sex));
                if ( value > 0 )
                {
                    HttpContext.Current.Cache.Remove( ShopInfo.ID.ToString() + "USER_INFO_" + UserInfo.ID.ToString() );
                }
                return value;
            }
        }

        /// <summary>
        /// 获得会员等级
        /// </summary>
        /// <param name="forumID"></param>
        /// <returns></returns>
        public DataTable GetMemberGrade()
        {
            DataSet ds;
            using ( IDbExecutor db = this.NewExecutor() )
            {
                ds = db.GetDataSet( CommandType.StoredProcedure , "Shop_GetMemberGrade" ,
                    NewParam( "@ShopID" , ShopInfo.ID ) );
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 修改会员等级
        /// </summary>
        /// <param name="dt"></param>
        public void UpdateGrade(DataTable dt)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {
                db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_ClearGrade" ,
                                    this.NewParam( "@ShopID" , ShopInfo.ID ),
                                    this.NewParam("@GradeID", dt.Rows.Count));

                for ( int i = 0 ; i < dt.Rows.Count ; i++ )
                {
                    db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_SetMemberGrade" ,
                        NewParam( "@ShopID" , ShopInfo.ID ) ,
                        NewParam( "@GradeName" , dt.Rows[i]["GradeName"] ) ,
                        NewParam( "@GradeID" , i + 1 ) ,
                        NewParam( "@MaxPoint" , Convert.ToInt32( dt.Rows[i]["MaxPoint"] ) ) );
                }
            }

            
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdateUserPwd(int uid,string userpwd)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {

                return db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_UpdateUserPwd",
                                        this.NewParam( "@MemberID" , uid ) ,
                                        this.NewParam( "@MemberPass" , Studio.Security.Secure.Md5( userpwd ) ) );
              
            }
        }

        /// <summary>
        /// 修改用户密码-前台
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int UpdateUserPwdWeb(string userpwd,string oldpass)
        {
            using ( IDbExecutor db = this.NewExecutor() )
            {

                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_UserPwdUpdate" ,
                                        this.NewParam( "@MemberID" , UserInfo.ID ) ,
                                        this.NewParam( "@MemberPass" , Studio.Security.Secure.Md5( userpwd ) ),
                                        this.NewParam("@OldPass", Studio.Security.Secure.Md5(oldpass)));

            }
        }


        /// <summary>
        /// 删除等级
        /// </summary>
        /// <returns></returns>
        public int GradeDelete()
        { 
            using ( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( CommandType.StoredProcedure , "Shop_GradeDelete" ,
                                    this.NewParam( "@ShopID" , ShopInfo.ID )); 
            }
        }
    }
}
