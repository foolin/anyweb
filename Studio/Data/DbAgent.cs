using System;
using System.Data;
using System.Data.SqlClient;
//using System.Data.OracleClient;
//using System.Data.OleDb;

namespace Studio.Data
{
    /// <summary>
    /// Name:数据代理
    /// Description:为数据逻辑层提供实现基础
    /// </summary>
    public abstract class DbAgent : IDisposable
    {
        string _connectString;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        protected string ConnectionString
        {
            get { return _connectString; }
            set { _connectString = value; }
        }

        DatabaseType _dbtype;
        /// <summary>
        /// 数据库类型
        /// </summary>
        protected DatabaseType DBType
        {
            get { return _dbtype; }
            set { _dbtype = value; }
        }

        /// <summary>
        /// 创建一个数据库连接
        /// </summary>
        protected IDbConnection NewConnection()
        {
            switch (this.DBType)
            {
                case DatabaseType.SqlServer:
                    {
                        return new SqlConnection(this.ConnectionString);
                    }
                default:
                    {
                        return new SqlConnection(this.ConnectionString);
                    }
            }
        }

        /// <summary>
        ///创建一个数据库连接
        /// </summary>
        /// <param name="name">存储过程参数名称</param>
        /// <param name="valu">传进的值</param>
        /// <param name="type">数据类型</param>
        /// <param name="len">类型长度</param>
        /// <param name="output">是否为输出参数</param>
        /// <returns>参数类</returns>
        protected IDbDataParameter NewParam(string name, object valu, DbType type, int len, bool output)
        {
            IDbDataParameter param;
            switch (this.DBType)
            {
                case DatabaseType.SqlServer:
                    {
                        param = new SqlParameter();
                        break;
                    }
                default:
                    {
                        param = new SqlParameter();
                        break;
                    }
            }

            param.DbType = type;
            param.ParameterName = name;
            param.Value = valu;
            if (len > 0)
            {
                param.Size = len;
            }

            if (output)
            {
                param.Direction = ParameterDirection.Output;
            }
            return param;
        }



        /// <summary>
        /// 创建一个数据库连接
        /// </summary>
        protected IDbDataParameter NewParam(string name, object valu, DbType type, int len)
        {
            return this.NewParam(name, valu, type, len, false);
        }

        /// <summary>
        /// 创建一个数据库连接
        /// </summary>
        protected IDbDataParameter NewParam(string name, object valu)
        {
            switch (valu.GetType().Name)
            {
                case "String":
                    return this.NewParam(name, valu, DbType.String, 0);
                case "DateTime":
                    return this.NewParam(name, valu, DbType.DateTime, 8);
                case "Boolean":
                    return this.NewParam(name, valu, DbType.Boolean, 1);
                case "Int32":
                    return this.NewParam(name, valu, DbType.Int32, 4);
                case "Int16":
                    return this.NewParam(name, valu, DbType.Int16, 2);
                default:
                    return this.NewParam(name, valu, DbType.String, 0);
            }
        }

        public DbAgent() { }

        public DbAgent(DatabaseType dbType, string connectString)
        {
            this.DBType = dbType;
            this.ConnectionString = connectString;
        }

        /// <summary>
        /// 根据数据库类别和连接字符串创建一个执行者
        /// </summary>
        protected IDbExecutor NewExecutor()
        {
            return DbFactory.CreateExecutor(this.DBType, this.ConnectionString);
        }

        #region IDisposable 成员

        public void Dispose()
        {
            // TODO:  添加 DataAgent.Dispose 实现
        }

        #endregion
    }
}
