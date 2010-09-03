using System;
using System.Collections.Generic;
using System.Text;
using Studio.Array;
using System.Data;
using Common.Agent;

namespace Common.Common
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class Admin : IdObject
    {
        public Admin () { }

        public Admin(DataRow dr)
        {
            this.ID = (int)dr["AdminID"];
            this._adminAcc = (string)dr["AdminAcc"];
            this._adminName = (string)dr["AdminName"];
            this._adminPass = (string)dr["AdminPass"];
        }

        /// <summary>
        /// 登陆帐号
        /// </summary>
        private string _adminAcc;

        public string AdminAcc
        {
            get { return _adminAcc; }
            set { _adminAcc = value; }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string _adminPass;

        public string AdminPass
        {
            get { return _adminPass; }
            set { _adminPass = value; }
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        private string _adminName;

        public string AdminName
        {
            get { return _adminName; }
            set { _adminName = value; }
        }
    }
}
