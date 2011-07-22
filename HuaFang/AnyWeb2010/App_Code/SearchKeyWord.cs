using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;


/// <summary>
///SearchKeyWord 的摘要说明
/// </summary>
public class SearchKeyWord
{
    public static string _keyString = String.Empty;

    /// <summary>
    /// 刷新搜索分词
    /// </summary>
    public static void refresh()
    {
        string path = HttpContext.Current.Server.MapPath("~/App_Data/SearchSplit.xml");
        if (File.Exists(path))
        {
            XmlDocument xml;
            try
            {
                xml = new XmlDocument();
                xml.Load(path);
                XmlNode root = xml.SelectSingleNode("words");
                foreach (XmlNode node in root.SelectNodes("word"))
                {
                    _keyString += "|" + node.InnerText;
                }
            }
            catch
            {
                _keyString = "";
            }
        }
        if (_keyString.Length > 0)
        {
            _keyString = _keyString.Substring(1);
        }
    }

    /// <summary>
    /// 匹配搜索分词，返回搜索字符串
    /// </summary>
    /// <param name="searchKeyword"></param>
    /// <returns></returns>
    public static string getQueryString(string searchKeyword)
    {
        string queryString = string.Format("fdArtiTitle LIKE '%{0}%'", searchKeyword);
        if (string.IsNullOrEmpty(_keyString))
        {
            refresh();
        }
        if (string.IsNullOrEmpty(_keyString))
        {
            return queryString;
        }
        MatchCollection mc = Regex.Matches(searchKeyword, _keyString);
        if (mc.Count > 0)
        {
            foreach (Match m in mc)
            {
                queryString += string.Format(" OR fdArtiTitle LIKE '%{0}%'", m.Value);
            }
        }
        return queryString;
    }
}
