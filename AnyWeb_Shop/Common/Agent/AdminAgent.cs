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
        /// 获取所有用户(缓存)
        /// </summary>
        /// <returns></returns>
        public List<Admin> GetAdmins(int pageSize, int pageNo, out int recordCount)
        {
            List<Admin> admins = (List<Admin>)HttpRuntime.Cache["PageAdmins"];
            if (admins != null)
            {
                recordCount = admins.Count;
                return admins;
            }
            admins = new List<Admin>();

            DataSet ds = new DataSet();
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter recount = this.NewParam("@RecordCount", 0, DbType.Int32, 8, true);

                ds = db.GetDataSet(CommandType.StoredProcedure, "Shop_GetAdmins",
                                    this.NewParam("@PageSize", pageSize),
                                    this.NewParam("@PageNo", pageNo),
                                    recount);
                recordCount = (int)recount.Value;
            }

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Admin a = new Admin(row);
                admins.Add(a);
            }

            HttpRuntime.Cache.Insert("PageAdmins", admins, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));

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

            Admin admin = new Admin();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Admin a = new Admin(dr);
                admin = a;
            }

            return admin;
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
                if(value>0)
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
    }
}
