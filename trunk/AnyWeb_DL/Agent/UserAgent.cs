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
        public ArrayList GetUserList()
        {
            DataSet ds;
            using (IDbExecutor db = this.NewExecutor())
            {
                ds = db.GetDataSet(CommandType.StoredProcedure, "GetUserList");
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
    }
}
