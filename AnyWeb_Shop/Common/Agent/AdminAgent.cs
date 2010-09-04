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
    public class AdminAgent : AgentBase
    {
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<Admin> GetAdmins()
        {
            List<Admin> admins = new List<Admin>();
            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetAdmins");
            }

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Admin a = new Admin(row);
                admins.Add(a);
            }
            return admins;
        }

        /// <summary>
        /// 获取某个用户信息
        /// </summary>
        /// <returns></returns>
        public Admin GetAdminByID(int aid)
        {
            DataSet ds;

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetAdminByID",
                                   this.NewParam("@AdminID", aid));
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                Admin admin = new Admin();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Admin a = new Admin(dr);
                    admin = a;
                }

                return admin;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="at"></param>
        public int AddAdmin(Admin a)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                int value = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_AdminAdd",
                                            this.NewParam("@AdminAcc", a.AdminAcc),
                                            this.NewParam("@AdminName", a.AdminName),
                                            this.NewParam("@AdminPass", Studio.Security.Secure.Md5(a.AdminPass)));
                if (value > 0)
                    HttpRuntime.Cache.Remove("PageAdmins");

                return value;
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="a"></param>
        public int UpdateAdmin(Admin a)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                int value = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_AdminUpdate",
                                            this.NewParam("@AdminID", a.ID),
                                            this.NewParam("@AdminAcc", a.AdminAcc),
                                            this.NewParam("@AdminName", a.AdminName),
                                            this.NewParam("@AdminPass", Studio.Security.Secure.Md5(a.AdminPass)));
                if (value > 0)
                    HttpRuntime.Cache.Remove("PageAdmins");

                return value;
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public int DeleteAdmin(Admin a)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                int value = db.ExecuteNonQuery(CommandType.StoredProcedure, "Shop_AdminDelete",
                                    this.NewParam("@AdminID", a.ID));
                if (value > 0)
                    HttpRuntime.Cache.Remove("PageAdmins");

                return value;
            }
        }

        /// <summary>
        /// 检查帐号是否存在
        /// </summary>
        /// <param name="adminAcc"></param>
        /// <returns>true:存在;false:不存在</returns>
        public bool checkAdminExists(string adminAcc)
        {
            DataSet ds;

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_CheckAdminExists",
                                   this.NewParam("@AdminAcc", adminAcc));
            }

            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        public Admin Login(string adminAcc, string adminPass)
        {
            DataSet ds;

            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_Login",
                                   this.NewParam("@AdminAcc", adminAcc),
                                   this.NewParam("@AdminPass", Studio.Security.Secure.Md5(adminPass)));
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                return new Admin(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
