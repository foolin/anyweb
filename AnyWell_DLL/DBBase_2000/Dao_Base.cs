using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Reflection;
using Microsoft.Win32;

using Studio.Security;
using Studio.Data;
using System.ComponentModel;

namespace AnyWell.AW_DL
{
    public class Dao_Base : DbAgent
    {
        public string _propTable = "";
        public string _propPK = "";
        public string _propFields = "";
        public string _propBlobFields = "";//保存Oracle数据库中类型是BLOB的字段
        public ArrayList _propParameters = new ArrayList();
        public string propSelect = "*";
        public string propTableApp = "";
        public string propWhere = "1=1";
        public string propOrder = "";
        public int propTopCount = 0;
        public int propPage = 0;
        public int propPageSize = 0;
        public bool propGetCount = false;
        public int propCount = 0;
        public string propCacheKey = "";
        public int propCachMin = 3;
        public string propProcedureName = "";
        public IDbConnection propConnection = null;
        public static CommandType propDefaultCommandType = CommandType.Text;//默认公共操作的命令类型

        static int dbType = 1;
        protected static NameValueCollection dbConnectionStrings = new NameValueCollection();

        /// <summary>
        /// 静态构造函数,从web.config读取所有数据库连接字符串,并对加密的进行解密,放进连接字符串集合
        /// </summary>
        static Dao_Base()
        {
            int.TryParse(ConfigurationManager.AppSettings["DBType"], out dbType);
            if (dbType == 0) dbType = 1;
            foreach(ConnectionStringSettings conn in ConfigurationManager.ConnectionStrings)
            {
                string name = conn.Name;
                //string value = RetrieveConnectionString(name, conn.ConnectionString);
                string value = conn.ConnectionString;
                dbConnectionStrings.Add(name, value);
            }
        }

        protected void EnsureConnectionString(string key)
        {
            if (dbConnectionStrings[key] == null)
            {
                if (ConfigurationManager.ConnectionStrings[key] != null)
                {
                    //string conn = RetrieveConnectionString(key, ConfigurationManager.ConnectionStrings[key].ConnectionString);
                    string conn = ConfigurationManager.ConnectionStrings[key].ConnectionString;
                    dbConnectionStrings.Add(key, conn);
                }
            }
        }

        public Dao_Base()
        {
            this.DBType = (DatabaseType)dbType;
            this.ConnectionString = dbConnectionStrings["ANYWELL_DB"];
        }

        /// <summary>
        /// 根据ID获取单条记录
        /// </summary>
        /// <param name="aID">表主键值</param>
        /// <returns></returns>
        public virtual DataSet funcGetByID(string aID)
        {
            aID = funcReplaceForIDs(aID);
            string sql = string.Format
                (
                "select * from {0} where {1} = @{1}",
                this._propTable,
                this._propPK
                );
            string cmdText = propDefaultCommandType == CommandType.Text ? sql : _propTable + "_GetByID";
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.GetDataSet(propDefaultCommandType, cmdText, this.funcAddParam("@" + this._propPK, aID));
            }
        }

        public virtual object funcGetField(string id, string field)
        {
            id = funcReplaceForIDs(id);
            string sql = string.Format
                (
                "select {0} from {1} where {2} = @{2}",
                field,
                this._propTable,
                this._propPK
                );
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteScalar(CommandType.Text, sql, this.funcAddParam("@" + this._propPK, id));
            }
        }

        public virtual object funcGetField(int id, string field)
        {
            string sql = string.Format
                (
                "select {0} from {1} where {2} = @{2}",
                field,
                this._propTable,
                this._propPK
                );
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteScalar(CommandType.Text, sql, this.funcAddParam("@" + this._propPK, id));
            }
        }

        public virtual DataSet funcGetByID(int id)
        {
            string sql = string.Format
                (
                "SELECT * FROM {0} WHERE {1} = @{1}",
                this._propTable,
                this._propPK
                );
            string cmdText = propDefaultCommandType == CommandType.Text ? sql : _propTable + "_GetByID";
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.GetDataSet(propDefaultCommandType, cmdText, this.funcAddParam("@" + this._propPK, id));
            }
        }

        /// <summary>
        /// 根据ID获取单条记录指定字段
        /// </summary>
        /// <param name="aID">表主键值</param>
        /// <param name="aColumns">指定字段列表</param>
        /// <returns></returns>
        public virtual DataSet funcGetByID(string aID, string aColumns)
        {
            aID = funcReplaceForIDs(aID);

            string sql = string.Format
                (
                "SELECT {0} FROM {1} WHERE {2} = '{3}'",
                aColumns,
                this._propTable,
                this._propPK,
                aID
                );

            return funcGet(sql);
        }

        public virtual DataSet funcGetByID(int id, string columns)
        {
            string sql = string.Format
                (
                "SELECT {0} FROM {1} WHERE {2} = '{3}'",
                columns,
                this._propTable,
                this._propPK,
                id
                );

            return funcGet(sql);
        }

        /// <summary>
        /// 插入单条记录,根据对象类型自动读取参数和值
        /// </summary>
        /// <param name="aBean">要添加的对象实体</param>
        /// <returns></returns>
        public virtual int funcInsert(Bean_Base aBean)
        {
            return funcInsert(aBean, null);
        }

        public virtual int funcInsert(Bean_Base aBean, IDbTransaction tran)
        {
            string sql = string.Format("INSERT INTO {0} ({1}) VALUES({2})",
                _propTable,
                _propFields,
                "@" + _propFields.Replace(",", ",@"));

            string cmdText = propDefaultCommandType == CommandType.Text ? sql : _propTable + "_Insert";
            using (IDbExecutor db = this.NewExecutor())
            {
                if (tran == null)
                    return db.ExecuteNonQuery(propDefaultCommandType, cmdText, funcGenParameters(aBean, sql));
                else
                    return db.ExecuteNonQuery(propDefaultCommandType, cmdText, tran, funcGenParameters(aBean, sql));
            }
        }

        public virtual int funcUpdate(Bean_Base aBean)
        {
            return funcUpdate(aBean, null);
        }

        /// <summary>
        /// 修改数据,根据对象类型自动读取参数和值
        /// </summary>
        /// <param name="aBean">要修改的对象实体</param>
        /// <returns></returns>
        public virtual int funcUpdate(Bean_Base aBean, IDbTransaction tran)
        {
            string aParam = "";
            string[] fields = _propFields.Split(',');
            foreach (string field in fields)
            {
                if (field != this._propPK)
                    aParam += field + "=@" + field + ",";
            }
            aParam = aParam.Remove(aParam.Length - 1, 1);

            string sql = string.Format("UPDATE {0} SET {1} WHERE {2}=@{2}",
                 _propTable,
                 aParam,
                 _propPK);

            string cmdText = propDefaultCommandType == CommandType.Text ? sql : _propTable + "_Update";
            using (IDbExecutor db = this.NewExecutor())
            {
                if (tran == null)
                    return db.ExecuteNonQuery(propDefaultCommandType, cmdText, funcGenParameters(aBean, sql));
                else
                    return db.ExecuteNonQuery(propDefaultCommandType, cmdText, tran, funcGenParameters(aBean, sql));
            }
        }

        public virtual int funcDelete(string aID)
        {
            return funcDelete(aID, null);
        }
        /// <summary>
        /// 根据主键值删除单个对象
        /// </summary>
        /// <param name="aID">表主键值</param>
        /// <returns></returns>
        virtual public int funcDelete(string aID, IDbTransaction tran)
        {
            aID = funcReplaceSqlField(aID);

            string sql = string.Format
                (
                "DELETE FROM {0} WHERE {1} = @{1}",
                this._propTable,
                this._propPK
                );
            string cmdText = propDefaultCommandType == CommandType.Text ? sql : _propTable + "_Delete";
            using (IDbExecutor db = this.NewExecutor())
            {
                if (tran == null)
                    return db.ExecuteNonQuery(propDefaultCommandType, cmdText, this.funcAddParam("@" + this._propPK, aID));
                else
                    return db.ExecuteNonQuery(propDefaultCommandType, cmdText, tran, this.funcAddParam("@" + this._propPK, aID));
            }
        }
        public virtual int funcDelete(int id)
        {
            return funcDelete(id, null);
        }
        /// <summary>
        /// 根据主键值删除单个对象
        /// </summary>
        /// <param name="aID">表主键值</param>
        /// <returns></returns>
        virtual public int funcDelete(int id, IDbTransaction tran)
        {
            string sql = string.Format
                (
                "DELETE FROM {0} WHERE {1} = @{1}",
                this._propTable,
                this._propPK
                );
            string cmdText = propDefaultCommandType == CommandType.Text ? sql : _propTable + "_Delete";
            using (IDbExecutor db = this.NewExecutor())
            {
                if (tran == null)
                    return db.ExecuteNonQuery(propDefaultCommandType, cmdText, this.funcAddParam("@" + this._propPK, id));
                else
                    return db.ExecuteNonQuery(propDefaultCommandType, cmdText, tran, this.funcAddParam("@" + this._propPK, id));
            }
        }

        virtual public int funcDeletes(string aIDList)
        {
            aIDList = funcReplaceForIDs(aIDList);

            string sql = string.Format
                (
                "DELETE FROM {0} WHERE {1} IN ('{2}')",
                this._propTable,
                this._propPK,
                aIDList
                );

            int r = funcExecute(sql);

            return r;
        }

        /// <summary>
        /// 通用获取数据对象,需要单独设置参数值,如果是存储过程,需要指定存储过程名称
        /// </summary>
        /// <returns>结果数据集</returns>
        virtual public DataSet funcCommon()
        {
            DataSet dst = null;
            string sql;
            string sqlCount;

            if (propProcedureName != "")
            {
                return funcGetByProcedure();
            }

            //oracle环境下，需要将Top语句变成rownum
            if (propSelect != "*" && dbType == 2)
            {
                string aNum = "";
                propReplaceTopStr(ref propSelect, ref aNum);

                if (aNum != "0" && aNum.Trim() != "")
                {
                    if (propWhere != "")
                    {
                        propWhere += " AND ROWNUM < " + (int.Parse(aNum) + 1).ToString();
                    }
                }
            }

            funcBuildSql
                (
                _propTable, propSelect, propTableApp, propWhere, propOrder,
                propPage, propPageSize, propGetCount, out sqlCount, out sql
                );

            //string str_Regex = @"^?;\;\--|d(?:elete\sfrom|rop\stable)|insert\s*into|update\s.*set|union\s*select|xp_$|declare|exec";

            //if (System.Text.RegularExpressions.Regex.Matches(sql.ToLower(), str_Regex).Count > 0)
            //{
            //    DataSet ds = new DataSet();
            //    DataTable dt = new DataTable();
            //    ds.Tables.Add(dt);
            //    return ds;
            //}

            dst = funcGet(sql);

            if (propGetCount)
            {
                using (IDbExecutor db = this.NewExecutor())
                {
                    IDbDataParameter[] parameters = new IDbDataParameter[_propParameters.Count];
                    _propParameters.CopyTo(parameters);
                    object result = db.ExecuteScalar(CommandType.Text, sqlCount, parameters);
                    //当sqlCount查询语句里包含group b并又没有记录的时候rs将返回为null而不是0条
                    if (result != null && result != DBNull.Value)
                        propCount = int.Parse(result.ToString());
                }
            }

            return dst;
        }

        protected static void propReplaceTopStr(ref string aTopStr, ref string aNum)
        {
            aTopStr = aTopStr.ToLower();
            if (aTopStr.IndexOf("top") > -1)
            {
                foreach (string str in aTopStr.Split(' '))
                {
                    if (DL_helper.funcIsInt32(str) != 0)
                    {
                        aNum = str;
                    }
                }

                if (aNum != "")
                {
                    aTopStr = aTopStr.Replace("top ", "").Replace(aNum, "");
                }
            }
        }

        virtual public int funcCommon_Count()
        {
            string sql;
            string sqlCount;

            DL_helper.funcBuildSql
            (
            _propTable, propSelect, propTableApp, propWhere, propOrder,
            propPage, propPageSize, true, out sqlCount, out sql
            );

            string str_Regex = @"^?;\;\--|d(?:elete\sfrom|rop\stable)|insert\s*into|update\s.*set|union\s*select|xp_$";
            if (System.Text.RegularExpressions.Regex.Matches(sqlCount.ToLower(), str_Regex).Count > 0)
            {
                return 0;
            }


            using (IDbExecutor db = this.NewExecutor())
            {
                object count = int.Parse(db.ExecuteScalar(sqlCount).ToString());
                propCount = int.Parse(count.ToString());
            }


            return propCount;
        }

        /// <summary>
        /// 根据指定的存储过程名称和参数获取数据
        /// </summary>
        /// <returns></returns>
        protected virtual DataSet funcGetByProcedure()
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                IDbDataParameter[] parameters = new IDbDataParameter[_propParameters.Count];
                _propParameters.CopyTo(parameters);

                return db.GetDataSet(propProcedureName, parameters);
            }
        }

        public virtual DataSet funcGet(string sql)
        {
            IDbDataParameter[] parameters = new IDbDataParameter[_propParameters.Count];
            _propParameters.CopyTo(parameters);

            return funcGet(CommandType.Text, sql, parameters);
        }

        public virtual DataSet funcGet(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.GetDataSet(cmdType, cmdText, parameters);
            }
        }

        public virtual int funcExecute(string sql)
        {
            IDbDataParameter[] parameters = new IDbDataParameter[_propParameters.Count];
            _propParameters.CopyTo(parameters);

            return funcExecute(CommandType.Text, sql, parameters);
        }

        public virtual int funcExecute( string sql, IDbTransaction tran )
        {
            IDbDataParameter[] parameters = new IDbDataParameter[ _propParameters.Count ];
            _propParameters.CopyTo( parameters );

            return funcExecute( CommandType.Text, sql, tran, parameters );
        }

        public virtual int funcExecute(CommandType cmdType, string cmdText, params IDbDataParameter[] parameters)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                return db.ExecuteNonQuery(cmdType, cmdText, parameters);
            }
        }

        public virtual int funcExecute( CommandType cmdType, string cmdText, IDbTransaction tran, params IDbDataParameter[] parameters )
        {
            using( IDbExecutor db = this.NewExecutor() )
            {
                return db.ExecuteNonQuery( cmdType, cmdText, tran, parameters );
            }
        }

        /// <summary>
        /// 根据名称和值创建参数,自动判断类型
        /// </summary>
        public virtual IDbDataParameter funcNewParam(string aName, object aValue)
        {
            return this.NewParam(aName, aValue);
        }

        /// <summary>
        /// 创建输出参数
        /// </summary>
        public virtual IDbDataParameter funcNewOutputParam(string aName, object aValue, DbType aType, int aLength)
        {
            return this.NewParam(aName, aValue, aType, aLength, true);
        }

        /// <summary>
        /// 创建Oracle特有结果集参数，适用于存储过程返回多个结果集
        /// </summary>
        /// <param name="aName">参数名称</param>
        /// <param name="aLength">参数值容量</param>
        /// <returns></returns>
        public virtual IDbDataParameter funcAddOracleDSParam(string aName, int size)
        {
            IDbDataParameter param = new OracleParameter(aName, OracleType.Cursor, size, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Default, Convert.DBNull);
            this.funcAddParam(param);
            return param;
        }

        /// <summary>
        /// 创建并添加参数到存储过程参数集合
        /// </summary>
        /// <param name="aName"></param>
        /// <param name="aValue"></param>
        /// <returns></returns>
        public virtual IDbDataParameter funcAddParam(string aName, object aValue)
        {
            IDbDataParameter param = this.funcNewParam(aName, aValue);
            this.funcAddParam(param);
            return param;
        }

        /// <summary>
        /// 创建并添加输出参数到存储过程参数集合
        /// </summary>
        /// <returns></returns>
        public virtual IDbDataParameter funcAddOutputParam(string aName, object aValue, DbType aType, int aLength)
        {
            IDbDataParameter param = this.funcNewOutputParam(aName, aValue, aType, aLength);
            this.funcAddParam(param);
            return param;
        }

        public virtual void funcAddParam(IDbDataParameter aParam)
        {
            _propParameters.Add(aParam);
        }

        /// <summary>
        /// 清空参数列表
        /// </summary>
        public virtual void funcClearParams()
        {
            _propParameters.Clear();
        }

        /// <summary>
        /// 根据实体对象和指定sql语句自动提取参数并根据属性设定值
        /// </summary>
        /// <param name="aBean"></param>
        /// <param name="aSql"></param>
        /// <returns></returns>
        protected virtual IDbDataParameter[] funcGenParameters(Bean_Base aBean, string aSql)
        {
            ArrayList list = new ArrayList();
            MatchCollection mc = Regex.Matches(aSql, @"@\w+");
            foreach (Match m in mc)
            {
                object value = null;
                PropertyInfo prop = aBean.GetType().GetProperty(m.Value.Substring(1)); //通过反射读取实体类的属性
                IDbDataParameter parm = null;
                if (prop != null)
                {
                    value = prop.GetValue(aBean, null);
                    if (this.DBType == DatabaseType.Oracle)
                    {
                        object[] attris = prop.GetCustomAttributes(true);
                        if (attris.Length > 0 && attris[0].ToString() == "System.ComponentModel.DescriptionAttribute")
                        {
                            DescriptionAttribute desc = (DescriptionAttribute)attris[0];
                            if (desc.Description == "Text/Blob")
                            {
                                if(value.ToString() == "")
                                    parm = this.NewOracleParam(m.Value, System.DBNull.Value, OracleType.Blob, 0, false);
                                else
                                    parm = this.NewOracleParam(m.Value, Encoding.Default.GetBytes(value.ToString()), OracleType.Blob, 0, false);
                            }
                            else
                            {
                                parm = this.NewParam(m.Value, value);
                            }
                        }
                        else
                        {
                            parm = this.NewParam(m.Value, value);
                        }
                    }
                    else
                    {
                        parm = this.NewParam(m.Value, value);
                    }
                }
                else
                {
                    prop = aBean.GetType().GetProperty("ExtProperties"); //读取扩展字段属性
                    if (prop != null)
                    {
                        Hashtable ht = (Hashtable)prop.GetValue(aBean, null);
                        if (ht != null)
                        {
                            value = ht[m.Value.Substring(1)];
                        }
                        if (value == null)
                        {
                            value = "";
                        }
                    }
                    parm = this.NewParam(m.Value, value);
                }
                list.Add(parm);
            }
            IDbDataParameter[] parameters = new IDbDataParameter[list.Count];
            list.CopyTo(parameters);
            return parameters;
        }

        /// <summary>
        /// 将输入的IDS进行格式处理，用于组成SQL语句
        /// </summary>
        /// <param name="aStr">输入原IDS，1.输入为: 1,2,3,4;2.输入为: '1','2','3'</param>
        /// <returns>输出为:1','2','3</returns>
        public static string funcReplaceForIDs(string aStr)
        {
            aStr = aStr.Replace("'", "");
            aStr = funcReplaceSqlField(aStr);
            aStr = aStr.Replace(" ", "").Replace(",", "','");

            return aStr;
        }

        public static string funcReplaceSqlField(object aString)
        {
            string aStr = "";
            if (aString == null)
            {
                return "";
            }
            else
            {
                aStr = aString.ToString();
            }

            if (aStr.IndexOf('\'') != -1)
            {
                aStr = aStr.Replace("'", "''");
            }

            if (aStr.IndexOf(';') != -1)
            {
                aStr = aStr.Replace(";", "；");
            }

            if (aStr.IndexOf("--") != -1)
            {
                aStr = aStr.Replace("--", "－－");
            }

            return aStr;
        }

        public virtual void funcBuildSql(string aTable, string aSelect, string aTableApp, string aWhere, string aOrder,
            int aPage, int aPageSize, bool aGetCount, out string aSqlCount, out string aSql)
        {
            aSqlCount = null;
            aSql = null;

            int aMaxID = aPage * aPageSize;
            int aMinID = aMaxID - aPageSize + 1;

            if (aPageSize == 0)
                aSql = string.Format
                (
                "SELECT {0} FROM {1} {2} WHERE {3} {4}",
                aSelect,
                (aTable.Contains("\"") ? aTable : aTable.ToUpper()),
                aTableApp,
                aWhere,
                aOrder
                );
            else //分页,仅支持sql2005和Oracle
                if (string.IsNullOrEmpty(aOrder))
                {
                    if( dbType == 2 )
                    {
                        aSql = string.Format
                       (
                       "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY sysdate) AS idx, {0} FROM {1} {2} WHERE {3}) T WHERE idx BETWEEN {4} AND {5}",
                       aSelect == "*" ? _propFields : aSelect, aTable.ToUpper(), aTableApp, aWhere, aMinID, aMaxID
                       );
                    }
                    else
                    {
                        aSql = string.Format(
                            "DECLARE @TempTable TABLE(AutoID INT IDENTITY(1,1) NOT NULL,PKID INT NOT NULL);INSERT INTO @TempTable(PKID) SELECT {0} FROM {1} {2} WHERE {3};SELECT {4} FROM {1} {2} INNER JOIN @TempTable ON PKID={0} WHERE AutoID BETWEEN {5} AND {6} ORDER BY AutoID",
                            _propPK, aTable.ToUpper(), aTableApp, aWhere, aSelect, aMinID, aMaxID
                            );
                    }
                }
                else
                {
                    if( dbType == 2 )
                    {
                        aSql = string.Format
                       (
                       "SELECT * FROM (SELECT ROW_NUMBER() OVER({4}) AS idx, {0} FROM {1} {2} WHERE {3}) T WHERE idx BETWEEN {5} AND {6}",
                       aSelect == "*" ? _propFields : aSelect, aTable.ToUpper(), aTableApp, aWhere, aOrder, aMinID, aMaxID
                       );
                    }
                    else
                    {
                        aSql = string.Format(
                            "DECLARE @TempTable TABLE(AutoID INT IDENTITY(1,1) NOT NULL,PKID INT NOT NULL);INSERT INTO @TempTable(PKID) SELECT {0} FROM {1} {2} WHERE {3} {4};SELECT {5} FROM {1} {2} INNER JOIN @TempTable ON PKID={0} WHERE AutoID BETWEEN {6} AND {7} ORDER BY AutoID",
                            _propPK, aTable.ToUpper(), aTableApp, aWhere, aOrder, aSelect, aMinID, aMaxID
                            );
                    }
                }

            if (aGetCount)
            {
                aSqlCount = string.Format
                    (
                    "SELECT COUNT(*) FROM (SELECT {0} FROM {1} {2} WHERE {3}) T",
                    aSelect,
                    aTable.ToUpper(), 
                    aTableApp, 
                    aWhere
                    );
            }
        }


        /// <summary>
        /// 检查是否Blob数据字段
        /// </summary>
        /// <returns></returns>
        protected virtual bool funcIsBlobField(string name)
        {
            if (_propBlobFields == name)
                return true;
            if (_propBlobFields.StartsWith(name + ","))
                return true;
            if (_propBlobFields.EndsWith("," + name))
                return true;
            if (_propBlobFields.Contains("," + name + ","))
                return true;
            return false;
        }




        /// <summary>
        /// 获取当前表的主键ID值
        /// </summary>
        /// <returns></returns>
        public virtual int funcNewID()
        {
            if (this.DBType == DatabaseType.Oracle)
            {
                using (IDbExecutor db = this.NewExecutor())
                {
                    IDbDataParameter nextid = this.NewParam("p_NextID", 0, DbType.Int32, 4, true);
                    db.ExecuteNonQuery("sys_GetTableNextID", 
                        new System.Data.IDbDataParameter[]{
                            this.NewParam("p_TableName", this._propTable), nextid
                        }
                        );
                    return int.Parse(nextid.Value.ToString());
                }
            }
            else
            {
                using (IDbExecutor db = this.NewExecutor())
                {
                    return db.ExecuteProcedure("sys_GetTableNextID", this.NewParam("@TableName", this._propTable));
                } 
            }

        }
    }
}
