using System;
using System.Collections.Generic;
using System.Text;
using Studio.Data;
using System.Data;
using System.Collections;

namespace AnyWeb.AnyWeb_DL
{
    public class UserAgent : DbAgent
    {
        public UserAgent() : base(SysSetting.GetSettings().DbType, SysSetting.GetSettings().DbConnectionString) { }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public ArrayList GetUserList(int UserStatus)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetUserList",
                    this.NewParam("@UserStatus", UserStatus));
            }
            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                User u = new User(row);
                list.Add(u);
            }
            return list;
        }

        /// <summary>
        /// 检查登陆名
        /// </summary>
        /// <param name="UserAcc"></param>
        /// <returns></returns>
        public bool CheckUserAcc(string UserAcc)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteProcedure("CheckUserAcc",
                    this.NewParam("@UserAcc", UserAcc)) == 1;
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteProcedure("AddUser",
                    this.NewParam("@UserAcc", user.UserAcc),
                    this.NewParam("@UserPass", user.UserPass),
                    this.NewParam("@UserName", user.UserName),
                    this.NewParam("@UserCreateAt", user.UserCreateAt),
                    this.NewParam("@UserStatus", user.UserStatus),
                    this.NewParam("@UserPermission", user.UserPermission),
                    this.NewParam("@UserIsAdmin", user.UserIsAdmin)) > 0;
            }
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public User GetUserInfo(int UserID)
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetUserInfo",
                    this.NewParam("@UserID", UserID));
            }
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            else
            {
                User u = new User(ds.Tables[0].Rows[0]);
                return u;
            }
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUserInfo(User user)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "UpdateUserInfo",
                    this.NewParam("@UserID", user.UserID),
                    this.NewParam("@UserPass", user.UserPass),
                    this.NewParam("@UserName", user.UserName),
                    this.NewParam("@UserIsAdmin", user.UserIsAdmin));
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int DeleteUser(int UserID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "DeleteUser",
                    this.NewParam("@UserID", UserID));
            }
        }

        /// <summary>
        /// 冻结用户
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int LockUser(int UserID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "LockUser",
                    this.NewParam("@UserID", UserID));
            }
        }

        /// <summary>
        /// 解冻用户
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public int UnlockUser(int UserID)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(CommandType.StoredProcedure, "UnlockUser",
                    this.NewParam("@UserID", UserID));
            }
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public ArrayList GetAllUserList()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetAllUserList");
            }
            ArrayList list = new ArrayList();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                User u = new User(row);
                list.Add(u);
            }
            return list;
        }
    }
}
