using System;
using System.Collections.Generic;
using System.Text;

namespace AnyWeb.AnyWeb_DL
{
    public class User
    {
        public User()
        { }

        private int _UserID;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private string _UserAcc;
        /// <summary>
        /// 登陆名
        /// </summary>
        public string UserAcc
        {
            get { return _UserAcc; }
            set { _UserAcc = value; }
        }

        private string _UserPass;
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPass
        {
            get { return _UserPass; }
            set { _UserPass = value; }
        }

        private string _UserName;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private DateTime _UserCreateAt;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime UserCreateAt
        {
            get { return _UserCreateAt; }
            set { _UserCreateAt = value; }
        }

        private int _UserStatus;
        /// <summary>
        /// 用户状态（0：正常1锁定）
        /// </summary>
        public int UserStatus
        {
            get { return _UserStatus; }
            set { _UserStatus = value; }
        }

        private string _UserPermission;
        /// <summary>
        /// 用户权限
        /// </summary>
        public string UserPermission
        {
            get { return _UserPermission; }
            set { _UserPermission = value; }
        }

        private bool _UserIsAdmin;
        /// <summary>
        /// 0普通1超管
        /// </summary>
        public bool UserIsAdmin
        {
            get { return _UserIsAdmin; }
            set { _UserIsAdmin = value; }
        }
    }
}
