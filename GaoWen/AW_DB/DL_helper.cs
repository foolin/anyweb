using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Net;

namespace AnyWeb.AW_DL
{
    /// <summary>
    /// DL_helper 的摘要说明。
    /// </summary>
    public class DL_helper
    {
        //private static string funcGetConnectString()
        //{
        //    return WebConfigurationManager.AppSettings["DB"];
        //}

        //private static int funcOpenConnection(OleDbConnection aCon)
        //{
        //    if (aCon == null || aCon.State != ConnectionState.Open)
        //    {
        //        funcTrace("funcOpenConnection", "");

        //        if (aCon == null)
        //        {
        //            aCon = new OleDbConnection();
        //        }

        //        aCon.ConnectionString = funcGetConnectString();
        //        aCon.Open();

        //        return 1;
        //    }

        //    return 0;
        //}

        //public static OleDbConnection funcGetConnection()
        //{
        //    OleDbConnection con = new OleDbConnection(funcGetConnectString());
        //    funcOpenConnection(con);
        //    return con;
        //}

        //public static DataSet funcGetDataSet(string aSql)
        //{
        //    return funcGetDataSet(aSql, 0, 0);
        //}

        //public static DataSet funcGetDataSet(string aSql, int aPage, int aPageSize)
        //{
        //    funcTrace(aSql);

        //    using (OleDbConnection aCon = funcGetConnection())
        //    {
        //        OleDbDataAdapter adapter = new OleDbDataAdapter(aSql, aCon);
        //        DataSet dst = new DataSet();

        //        int r = 0;

        //        try
        //        {
        //            if (aPageSize != 0)
        //            {
        //                int startRecord = (aPage - 1) * aPageSize;

        //                r = adapter.Fill(dst, startRecord, aPageSize, "P");
        //            }
        //            else
        //            {
        //                r = adapter.Fill(dst, "P");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            funcTrace(ex.ToString());

        //            return null;
        //        }

        //        return dst;
        //    }
        //}

        //public static int funcExcute(string aSql)
        //{
        //    funcTrace(aSql);

        //    using (OleDbConnection aCon = funcGetConnection())
        //    {
        //        OleDbCommand cmd = new OleDbCommand(aSql, aCon);

        //        int r = 0;

        //        try
        //        {
        //            r = cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception ex)
        //        {
        //            funcTrace(ex.ToString());

        //            return 0;
        //        }

        //        return r;
        //    }
        //}

        //public static object funcExcuteScalar(string aSql)
        //{
        //    funcTrace(aSql);

        //    using (OleDbConnection aCon = funcGetConnection())
        //    {

        //        OleDbCommand cmd = new OleDbCommand(aSql, aCon);

        //        object r = null;

        //        try
        //        {
        //            r = cmd.ExecuteScalar();
        //        }
        //        catch (Exception ex)
        //        {
        //            funcTrace(ex.ToString());

        //            return null;
        //        }

        //        return r;
        //    }
        //}

        public static void funcSetRowDefault(DataRow aRow)
        {
            foreach (DataColumn dcol in aRow.Table.Columns)
            {
                if (dcol.AutoIncrement == true)
                {
                    continue;
                }

                if (dcol.DataType == typeof(string))
                {
                    aRow[dcol.ColumnName] = "";
                }
                else if (dcol.DataType == typeof(int))
                {
                    aRow[dcol.ColumnName] = 0;
                }
                else if (dcol.DataType == typeof(DateTime))
                {
                    aRow[dcol.ColumnName] = DateTime.Now;
                }
                else
                {
                    //					try
                    //					{
                    //						drow[dcol.ColumnName] = "";
                    //					}
                    //					catch {}
                }
            }
        }

        public static string funcGetTopString(int aPage, int aPageSize)
        {
            string top = "top " + (aPage * aPageSize);

            return top;
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

        static Mutex _propMutex_funcGetTicks = new Mutex();
        public static long funcGetTicks()
        {
            _propMutex_funcGetTicks.WaitOne();

            long r = DateTime.Now.Ticks;
            Thread.Sleep(50);

            _propMutex_funcGetTicks.ReleaseMutex();

            return r;
        }

        public static string funcGetStringHashCode(string aStr)
        {
            int aCode = aStr.GetHashCode();

            if (aCode < 0)
            {
                return aCode.ToString().Replace("-", "m");
            }

            return aCode.ToString();
        }

        static int _propTicks_ex = 100;
        public static int funcGetNextInt()
        {
            _propTicks_ex++;

            if (_propTicks_ex > 800)
            {
                _propTicks_ex = 100;
            }

            return _propTicks_ex;
        }

        //public static string funcGetTicks().ToString()
        //{
        //	return funcGetTicks().ToString() + funcGetNextInt().ToString();
        //}

        public static void funcBuildSql(string aTable, string aSelect, string aTableApp, string aWhere, string aOrder,
    int aPage, int aPageSize, bool aGetCount, out string aSqlCount, out string aSql)
        {
            aSqlCount = null;
            aSql = null;

            string top_str = "";
            //			if (aPage != 0)
            //			{
            //				top_str = "top " + (aPage * aPageSize);
            //			}

            aSql = string.Format
                (
                "select {0} {1} from {2} {3} where {4} {5}",
                top_str,
                aSelect,
                aTable.ToUpper(),
                aTableApp,
                aWhere,
                aOrder
                );

            if (aGetCount)
            {
                aSqlCount = string.Format
                    (
                    "select count(*) from {0} {1} where {2}",
                    aTable,
                    aTableApp,
                    aWhere
                    );
            }

        }


        #region string
        ///把字符串截到指定长度
        public static string funcFixString(string s, int len)
        {
            if (s.Length >= len)
            {
                int l = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    l += (int)s[i] > 255 ? 2 : 1;//逐字计算，全角或中文算2个字节，半角英文算1个字节
                    if (l >= len * 2 - 1)//约定len为中文长度（双字节），换成字节要×2，结果不能大于目标字节数，所以需要－1
                    {
                        return s.Substring(0, i + 1);//i＋1为取值长度
                    }
                }
            }
            return s;
        }

        //获取 s 被MD5编码后的字符串
        public static string funcGetMD5(string s)
        {
            byte[] cb = Encoding.ASCII.GetBytes(s);

            byte[] mb = (new MD5CryptoServiceProvider()).ComputeHash(cb);

            //return Encoding.ASCII.GetString(mb);

            return BitConverter.ToString(mb).Replace("-", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aByteList">B0-D7-CE-C4-BB-DC</param>
        /// <returns>白文卉</returns>
        public static string funcGetStringByByteList(string aByteList)
        {
            string[] ss = aByteList.Split('-');
            byte[] buffer = new byte[ss.Length];

            for (int i = 0; i < ss.Length; i++)
            {
                buffer[i] = Convert.ToByte(ss[i], 16);
            }

            string sout = System.Text.Encoding.Default.GetString(buffer);

            return sout;
        }

        /// <summary>
        /// 判断字符串里全是数字
        /// </summary>
        /// <param name="aStr"></param>
        /// <returns></returns>
        public static bool funcIsInt(string aStr)
        {
            foreach (char c in aStr)
            {
                if (!Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static int funcIsInt32(string aStr)
        {
            int aNum = 0;
            int.TryParse(aStr, out aNum);

            return aNum;
        }

        public static decimal funcIsDecimal(string aStr)
        {
            decimal aNum = 0;
            decimal.TryParse(aStr, out aNum);

            return aNum;
        }

        public static DateTime funcIsDateTime(string aStr)
        {
            DateTime dt = DateTime.Now;
            DateTime.TryParse(aStr, out dt);

            return dt;
        }

        /// <summary>
        /// 下载URL内容
        /// </summary>
        /// <param name="aUrl"></param>
        /// <returns></returns>
        public static string funcGetUrlContent(string aUrl)
        {
            WebClient obj = new WebClient();
            byte[] content = null;
            string urlcontent = null;
            //WebRequest myre=WebRequest.Create();
            try
            {
                content = obj.DownloadData(aUrl);
                urlcontent = Encoding.UTF8.GetString(content);
                return urlcontent;
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }//
}//
