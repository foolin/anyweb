using System;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Web;
using System.Text;
using System.Collections;
using System.Timers;

using System.Resources;
using System.Globalization;

using Studio.Data;

namespace AnyWeb.AnyWeb_DL
{
    /// <summary>
    /// Biz BlogœµÕ≥…Ë÷√
    /// </summary>
    public class SysSetting
    {
        public SysSetting()
        {
            this.DbConnectionString = ConfigurationSettings.AppSettings["DbConnectionString"];
            this.DbType = DatabaseType.SqlServer;
        }

        string _connectString;
        public string DbConnectionString
        {
            get
            {
                return _connectString;
            }
            set { _connectString = value; }
        }

        DatabaseType _dbtype;
        public DatabaseType DbType
        {
            get
            {
                return _dbtype;
            }
            set { _dbtype = value; }
        }

        public string MapPath(string relativePath)
        {
            return HttpContext.Current.Server.MapPath(relativePath);
        }

        public static SysSetting GetSettings()
        {
            return Nested.instance;
        }
        class Nested
        {
            static Nested() { }
            internal static readonly SysSetting instance = new SysSetting();
        }


    }
}
