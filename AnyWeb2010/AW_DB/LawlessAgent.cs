using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using Studio.Data;
using System.Data;
using System.Reflection;
using AnyWeb.AW_DL;
using System.Text.RegularExpressions;
using System.Collections;
using System.Configuration;

namespace FortuneAge.IBOX_UC
{
    #region 关键字实体
    /// <summary>
    /// 关键字实体
    /// </summary>
    public class FA_Lawless_Keyword
    {
        private int _fdLakeID = 0;
        /// <summary>
        /// 关键编号
        /// </summary>
        public int fdLakeID
        {
            get { return _fdLakeID; }
            set { _fdLakeID = value; }
        }
        private string _fdLakeKey = "";
        /// <summary>
        /// 关键字 200 nvarchar
        /// </summary>
        public string fdLakeKey
        {
            get { return _fdLakeKey; }
            set { _fdLakeKey = value; }
        }
        private LawlessLevel _fdLakeType = 0;
        /// <summary>
        /// 关键类型 ABC三种
        /// </summary>
        public LawlessLevel fdLakeType
        {
            get { return _fdLakeType; }
            set { _fdLakeType = value; }
        }
        private DateTime _fdLakeCreateAt = DateTime.Now;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime fdLakeCreateAt
        {
            get { return _fdLakeCreateAt; }
            set { _fdLakeCreateAt = value; }
        }
        private int _fdLakeCreateBy = 0;
        /// <summary>
        /// 创建人员编号
        /// </summary>
        public int fdLakeCreateBy
        {
            get { return _fdLakeCreateBy; }
            set { _fdLakeCreateBy = value; }
        }

        /// <summary>
        /// 枚举,表示关键字等级 A只记录，B直接替换为星号，C拒绝发布
        /// </summary>
        public enum LawlessLevel
        {
            OK = 0,
            A = 1,
            B = 2,
            C = 3,
        }
    }
    #endregion
    #region 源实体
    /// <summary>
    ///  源实体
    /// </summary>
    public class FA_Lawless_Source
    {
        private int _fdLasoID = 0;
        /// <summary>
        /// 来源编号
        /// </summary>
        public int fdLasoID
        {
            get { return _fdLasoID; }
            set { _fdLasoID = value; }
        }
        private string _fdLasoName = "";
        /// <summary>
        /// 来源名称 200 nvarchar
        /// </summary>
        public string fdLasoName
        {
            get { return _fdLasoName; }
            set { _fdLasoName = value; }
        }
        private string _fdLasoConnStr = "";
        /// <summary>
        /// web.config所用连接字符串（插件可能跨库） 200 nvarchar
        /// </summary>
        public string fdLasoConnStr
        {
            get { return _fdLasoConnStr; }
            set { _fdLasoConnStr = value; }
        }
        private string _fdLasoTable = "";
        /// <summary>
        /// 数据库表名 50 varchar
        /// </summary>
        public string fdLasoTable
        {
            get { return _fdLasoTable; }
            set { _fdLasoTable = value; }
        }
        private string _fdLasoPriKey = "";
        /// <summary>
        /// 表主键 50 varchar
        /// </summary>
        public string fdLasoPriKey
        {
            get { return _fdLasoPriKey; }
            set { _fdLasoPriKey = value; }
        }
        private string _fdLasoFields = "";
        /// <summary>
        /// 需要检查的字段 500 varchar
        /// </summary>
        public string fdLasoFields
        {
            get { return _fdLasoFields; }
            set { _fdLasoFields = value; }
        }
    }
    #endregion
    #region 记录实体
    /// <summary>
    /// 捕获记录源
    /// </summary>
    public class FA_Lawless_Record
    {
        private int _fdLareID = 0;
        /// <summary>
        /// 记录编号
        /// </summary>
        public int fdLareID
        {
            get { return _fdLareID; }
            set { _fdLareID = value; }
        }
        private int _fdLareSourceID = 0;
        /// <summary>
        /// 所属来源
        /// </summary>
        public int fdLareSourceID
        {
            get { return _fdLareSourceID; }
            set { _fdLareSourceID = value; }
        }
        private string _fdLareField = "";
        /// <summary>
        /// 字段 100 varchar
        /// </summary>
        public string fdLareField
        {
            get { return _fdLareField; }
            set { _fdLareField = value; }
        }
        private string _fdLareKey = "";
        /// <summary>
        /// 捕获的关键字 200 nvarchar
        /// </summary>
        public string fdLareKey
        {
            get { return _fdLareKey; }
            set { _fdLareKey = value; }
        }
        private string _fdLareContent = "";
        /// <summary>
        /// 原文
        /// </summary>
        public string fdLareContent
        {
            get { return _fdLareContent; }
            set { _fdLareContent = value; }
        }
        private DateTime _fdLareCreateAt = DateTime.Now;
        /// <summary>
        /// 捕获时间
        /// </summary>
        public DateTime fdLareCreateAt
        {
            get { return _fdLareCreateAt; }
            set { _fdLareCreateAt = value; }
        }
        private int _fdLareStatus = 0;
        /// <summary>
        /// 处理状态 0未处理 1已清空字段2已删除 3已忽略
        /// </summary>
        public int fdLareStatus
        {
            get { return _fdLareStatus; }
            set { _fdLareStatus = value; }
        }

        private int _fdLareObjectID = 0;

        public int fdLareObjectID
        {
            get { return _fdLareObjectID; }
            set { _fdLareObjectID = value; }
        }

    }
    #endregion
    public class LawlessAgent : Dao_Base
    {
        public LawlessAgent()
        {
            funcInitLawlessSource();//初始化自定义表单
            GetKeywords();
            funGetSourceList();
        }

        /// <summary>
        /// 初始化自定义表单
        /// </summary>
        public void funcInitLawlessSource()
        {
            this.ConnectionString = dbConnectionStrings["Plugin_DB"];

            List<FA_Lawless_Source> list = new List<FA_Lawless_Source>();
            using (IDbExecutor db = this.NewExecutor())
            {
                DataSet ds_Form = null;
                try
                {
                    ds_Form = db.GetDataSet("SELECT fdFormID,fdFormName,fdFormTable FROM FO_Form");
                }
                catch
                {
                    this.ConnectionString = dbConnectionStrings["IBOX_DB"];
                    return;
                }

                if (ds_Form != null && ds_Form.Tables.Count > 0 && ds_Form.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr_Form in ds_Form.Tables[0].Rows)
                    {
                        DataSet ds_Field = db.GetDataSet("SELECT fdFielName FROM FO_Field WHERE fdFielFormID = " + dr_Form["fdFormID"].ToString() + " AND (fdFielCtrlType =1 OR fdFielCtrlType =2)");

                        string fields = "";
                        if (ds_Field.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr_field in ds_Field.Tables[0].Rows)
                            {
                                fields += "," + dr_field["fdFielName"];
                            }
                            fields = fields.Substring(1);
                        }

                        FA_Lawless_Source s = new FA_Lawless_Source();
                        s.fdLasoID = (90000 +  int.Parse(dr_Form["fdFormID"].ToString()));
                        s.fdLasoName = dr_Form["fdFormName"].ToString();
                        s.fdLasoConnStr = "Plugin_DB";
                        s.fdLasoTable = dr_Form["fdFormTable"].ToString();
                        s.fdLasoPriKey = "fdID";
                        s.fdLasoFields = fields;

                        list.Add(s);
                    }
                }
            }

            this.ConnectionString = dbConnectionStrings["IBOX_DB"];

            if (list.Count > 0)
            {
                foreach (FA_Lawless_Source s in list)
                {
                    string cmdText_Select = "SELECT COUNT(fdLasoID) FROM  FA_Lawless_Source WHERE fdLasoTable='" + s.fdLasoTable + "'";
                    int i = 0;
                    using (IDbExecutor db = this.NewExecutor())
                    {
                        i = int.Parse(db.ExecuteScalar(cmdText_Select).ToString());

                        if (i == 0)
                        {
                            string cmdText_Insert = string.Format("INSERT INTO FA_Lawless_Source(fdLasoID,fdLasoName,fdLasoConnStr,fdLasoTable,fdLasoPriKey,fdLasoFields) VALUES({0},'{1}','{2}','{3}','{4}','{5}') ", s.fdLasoID, s.fdLasoName, s.fdLasoConnStr, s.fdLasoTable, s.fdLasoPriKey, s.fdLasoFields);

                            db.ExecuteNonQuery(cmdText_Insert);
                        }
                    }
                 
                }
            }
        }

        #region 属性
        private List<FA_Lawless_Keyword> _keywords;
        /// <summary>
        ///所有关键字 
        /// </summary>
        public List<FA_Lawless_Keyword> Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }


        private string _atypeKeywords;
        /// <summary>
        ///A类关键字 
        /// </summary>
        public string AtypeKeywords
        {
            get { return _atypeKeywords; }
            set { _atypeKeywords = value; }
        }

        private string _btypeKeywords;
        /// <summary>
        ///B类关键字 
        /// </summary>
        public string BtypeKeywords
        {
            get { return _btypeKeywords; }
            set { _btypeKeywords = value; }
        }

        private string _ctypeKeywords;
        /// <summary>
        ///C类关键字 
        /// </summary>
        public string CtypeKeywords
        {
            get { return _ctypeKeywords; }
            set { _ctypeKeywords = value; }
        }

        private List<FA_Lawless_Source> _source;
        /// <summary>
        /// 源
        /// </summary>
        public List<FA_Lawless_Source> Source
        {
            get { return _source; }
            set { _source = value; }
        }

        #endregion
        /// <summary>
        /// 获取所有关键字,并且分类
        /// </summary>
        public void GetKeywords()
        {
            //初始划
            Keywords = new List<FA_Lawless_Keyword>();
            AtypeKeywords = "";
            BtypeKeywords = "";
            CtypeKeywords = "";
            using (IDbExecutor db = this.NewExecutor())
            {
                string cmdText = "SELECT * FROM FA_Lawless_Keyword";

                DataSet ds = db.GetDataSet(cmdText);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        FA_Lawless_Keyword keyword = new FA_Lawless_Keyword();
                        keyword.fdLakeID =  int.Parse( dr["fdLakeID"].ToString());
                        keyword.fdLakeKey = (string)dr["fdLakeKey"];
                        keyword.fdLakeType = (FA_Lawless_Keyword.LawlessLevel )(int.Parse(dr["fdLakeType"].ToString()));
                        keyword.fdLakeCreateAt = (DateTime)dr["fdLakeCreateAt"];
                        keyword.fdLakeCreateBy =  int.Parse(dr["fdLakeCreateBy"].ToString());
                        //加入关键字
                        Keywords.Add(keyword);


                        //加A类关键字
                        if (keyword.fdLakeType == FA_Lawless_Keyword.LawlessLevel.A)
                        {
                            AtypeKeywords += keyword.fdLakeKey + "|";
                        }
                        //加B类关键字
                        if (keyword.fdLakeType == FA_Lawless_Keyword.LawlessLevel.B)
                        {
                            BtypeKeywords += keyword.fdLakeKey + "|";
                        }
                        //加C类关键字
                        if (keyword.fdLakeType == FA_Lawless_Keyword.LawlessLevel.C)
                        {
                            CtypeKeywords += keyword.fdLakeKey + "|";
                        }
                    }
                }
            }

            if (AtypeKeywords.Length > 0)
            {
                AtypeKeywords = AtypeKeywords.Substring(0, AtypeKeywords.Length - 1);
            }

            if (BtypeKeywords.Length > 0)
            {
                BtypeKeywords = BtypeKeywords.Substring(0, BtypeKeywords.Length - 1);
            }

            if (CtypeKeywords.Length > 0)
            {
                CtypeKeywords = CtypeKeywords.Substring(0, CtypeKeywords.Length - 1);
            }
        }

        /// <summary>
        /// 刷新
        /// </summary> 
        public void Refresh()
        {
            GetKeywords();
            funGetSourceList();
        }

        /// <summary>
        /// 根据源表检查关键字(主意:如果是自定义表单,obj则传入Field实体)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tableName"></param>
        /// <param name="key"></param>
        /// <returns>返回obj等级</returns>
        public FA_Lawless_Keyword.LawlessLevel funcCheck(object obj, string tableName, out string key)
        {
            if (Source != null)
            {
                funGetSourceList();
            }
            key = "";
            if (Source.Count > 0)
            {
                foreach (FA_Lawless_Source s in Source)
                {
                    if (s.fdLasoTable == tableName)
                    {
                        return funcCheckByFields(obj, s.fdLasoID, s.fdLasoFields, s.fdLasoPriKey, out key);
                    }
                }
            }
            return FA_Lawless_Keyword.LawlessLevel.OK;
        }

        /// <summary>
        /// 获取源数据,为源实体赋值
        /// </summary>
        public void funGetSourceList()
        {
            Source = new List<FA_Lawless_Source>();

            string cmdText = "SELECT * FROM FA_Lawless_Source ";

            using (IDbExecutor db = this.NewExecutor())
            {
                DataSet ds = db.GetDataSet(cmdText);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        FA_Lawless_Source s = new FA_Lawless_Source();
                        s.fdLasoID = int.Parse( dr["fdLasoID"].ToString());
                        s.fdLasoName = (string)dr["fdLasoName"];

                        s.fdLasoConnStr = (string)dr["fdLasoConnStr"];
                        s.fdLasoTable = (string)dr["fdLasoTable"];
                        s.fdLasoPriKey = (string)dr["fdLasoPriKey"];
                        s.fdLasoFields = (string)dr["fdLasoFields"];

                        Source.Add(s);
                    }
                }
            }
        }


        /// <summary>
        /// 根据源编号检查关键字(主意:如果是自定义表单,obj则传入Field实体)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tableName"></param>
        /// <param name="key"></param>
        /// <returns>返回obj等级</returns>
        public FA_Lawless_Keyword.LawlessLevel funcCheck(object obj, int sourceid, out string key)
        {
            if (Source != null)
            {
                funGetSourceList();
            }

            key = "";
            if (Source.Count > 0)
            {
                foreach (FA_Lawless_Source s in Source)
                {
                    if (s.fdLasoID == sourceid)
                    {
                        return funcCheckByFields(obj, s.fdLasoID, s.fdLasoFields, s.fdLasoPriKey, out key);
                    }
                }
            }
            return FA_Lawless_Keyword.LawlessLevel.OK;
        }

        /// <summary>
        /// 检查等级
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tableName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public FA_Lawless_Keyword.LawlessLevel funcCheckByFields(object obj, int source, string fields, string prikey, out string key)
        {
            key = "";

            FA_Lawless_Keyword.LawlessLevel level = FA_Lawless_Keyword.LawlessLevel.OK;

            if (Keywords == null)
            {
                GetKeywords();
            }


            if (fields != "")
            {
                foreach (string field in fields.Split(','))
                {
                    PropertyInfo prop = null;
                    string lareContent = "";
                    int objectID = 0;

                    if (source < 90000)//判断是否是自定义表单
                    {
                        prop = obj.GetType().GetProperty(field);
                        PropertyInfo propPriKey = obj.GetType().GetProperty(prikey);
                        if (propPriKey != null)
                        {
                            if (Studio.Web.WebAgent.IsInt32(propPriKey.GetValue(obj, null) + ""))
                            {
                                objectID = (int)propPriKey.GetValue(obj, null);
                            }
                        }
                    }
                    else
                    {
                        PropertyInfo propFileName = obj.GetType().GetProperty("fdFielName");
                        if (propFileName != null)
                        {
                            string fileName = propFileName.GetValue(obj, null).ToString();
                            if (fileName != null && fileName == field)
                            {
                                prop = obj.GetType().GetProperty("Value");
                            }

                            if (fileName != null && fileName == prikey)
                            {
                                PropertyInfo propPriKey = obj.GetType().GetProperty("Value");
                                if (propPriKey != null)
                                {
                                    if (Studio.Web.WebAgent.IsInt32(propPriKey.GetValue(obj, null) + ""))
                                    {
                                        objectID = (int)propPriKey.GetValue(obj, null);
                                    }
                                }
                            }
                        }

                    }

                    if (prop != null)
                    {
                        string value = prop.GetValue(obj, null).ToString();//获取内容
                        lareContent = value;//保存原文

                        if (value == null || value == "")
                        {
                            continue;
                        }

                        //检查是否有次C类关键字
                        if (CtypeKeywords != null && CtypeKeywords != "")
                        {
                            MatchCollection mc = Regex.Matches(value, CtypeKeywords);
                            if (mc.Count > 0)
                            {
                                foreach (Match m in mc)
                                {
                                    if (key.IndexOf(m.Value) < 0)
                                    {
                                        key += m.Value + ",";
                                    }
                                }

                                if (key != "" && key.Substring(key.Length - 1) == ",")
                                {
                                    key = key.Substring(0, key.Length - 1);
                                }
                                funcInsertRecord(source, field, key, lareContent, objectID);
                                //如果是c类关键字,直接返回
                                return FA_Lawless_Keyword.LawlessLevel.C;
                            }
                        }

                        //检查是否有B类关键字
                        if (BtypeKeywords != null && BtypeKeywords != "")
                        {
                            MatchCollection mc = Regex.Matches(value, BtypeKeywords);
                            if (mc.Count > 0)
                            {
                                prop.SetValue(obj, value, null);
                                foreach (Match m in mc)
                                {
                                    if (key.IndexOf(m.Value) < 0)
                                    {
                                        key += m.Value + ",";
                                        prop.SetValue(obj, value.Replace(m.Value, "*"), null);
                                    }

                                }
                                //如果不是c类关键字,则继续检查.
                                if (level != FA_Lawless_Keyword.LawlessLevel.C)
                                {
                                    level = FA_Lawless_Keyword.LawlessLevel.B;
                                }

                            }
                        }

                        //检查是否有A类关键字
                        if (AtypeKeywords != null && AtypeKeywords != "")
                        {
                            MatchCollection mc = Regex.Matches(value, AtypeKeywords);
                            if (mc.Count > 0)
                            {
                                foreach (Match m in mc)
                                {
                                    if (key.IndexOf(m.Value) < 0)
                                    {
                                        key += m.Value + ",";
                                    }
                                }

                                if (level == FA_Lawless_Keyword.LawlessLevel.OK)
                                {
                                    level = FA_Lawless_Keyword.LawlessLevel.A;
                                }
                            }
                        }

                        if (FA_Lawless_Keyword.LawlessLevel.OK != level)
                        {
                            funcInsertRecord(source, field, key, lareContent, objectID);
                        }
                    }
                }
            }

            if (key != "" && key.Substring(key.Length - 1) == ",")
            {
                key = key.Substring(0, key.Length - 1);
            }
            return level;
        }

        public void funcInsertRecord(int sourceid, string field, string key, string content, int objectid)
        {
            FA_Lawless_Record rcord = new FA_Lawless_Record();
            rcord.fdLareID = funcGetNextTableId("FA_Lawless_Record");
            rcord.fdLareSourceID = sourceid;
            rcord.fdLareField = field;

            rcord.fdLareKey = key;

            if (key != "" && key.Substring(key.Length - 1) == ",")
            {
                rcord.fdLareKey = key.Substring(0, key.Length - 1);
            }

            rcord.fdLareContent = content;
            rcord.fdLareCreateAt = DateTime.Now;
            rcord.fdLareObjectID = objectid;

            _propTable = "FA_Lawless_Record";
            _propFields = "fdLareID,fdLareSourceID,fdLareField,fdLareKey,fdLareContent,fdLareCreateAt,fdLareStatus,fdLareObjectID";
            _propPK = "fdLareID";
            funcInsertRecord(rcord, null);
        }

        public int funcInsertRecord(FA_Lawless_Record aBean, IDbTransaction tran)
        {
            string sql = string.Format("INSERT INTO {0} ({1}) VALUES({2})",
                _propTable,
                _propFields,
                "@" + _propFields.Replace(",", ",@"));

            string cmdText = propDefaultCommandType == CommandType.Text ? sql : _propTable + "_Insert";
            using (IDbExecutor db = this.NewExecutor())
            {
                if (tran == null)
                    return db.ExecuteNonQuery(propDefaultCommandType, cmdText, funcGenRecordParameters(aBean, sql));
                else
                    return db.ExecuteNonQuery(propDefaultCommandType, cmdText, tran, funcGenRecordParameters(aBean, sql));
            }
        }

        protected IDbDataParameter[] funcGenRecordParameters(FA_Lawless_Record aBean, string aSql)
        {
            ArrayList list = new ArrayList();
            MatchCollection mc = Regex.Matches(aSql, @"@\w+");
            foreach (Match m in mc)
            {
                object value = null;
                PropertyInfo prop = aBean.GetType().GetProperty(m.Value.Substring(1)); //通过反射读取实体类的属性
                if (prop != null)
                {
                    value = prop.GetValue(aBean, null);
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
                }
                list.Add(this.NewParam(m.Value, value));
            }
            IDbDataParameter[] parameters = new IDbDataParameter[list.Count];
            list.CopyTo(parameters);
            return parameters;
        }

        /// <summary>
        /// 获取表新的编号
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns>返回新编号</returns>
        public int funcGetNextTableId(string tableName)
        {
            using (IDbExecutor db = this.NewExecutor())
            {
                int nextId = (int)db.ExecuteProcedure("sys_GetTableNextID",
                    this.NewParam("@tablename", tableName));
                return nextId;
            }
        }

        #region 单件
        public static LawlessAgent GetSetting()
        {
            return Nested.instance;
        }

        class Nested
        {
            static Nested() { }
            internal static readonly LawlessAgent instance = new LawlessAgent();
        }
        #endregion
    }
}