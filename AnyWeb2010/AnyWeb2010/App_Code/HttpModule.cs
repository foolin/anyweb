using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Xml;
using System.Text;


namespace AnyWeb.AW
{
    /// <summary>
    ///HttpHandle 的摘要说明
    /// </summary>
    public class HttpModule : System.Web.IHttpModule
    {
        /// <summary>
        /// 实现接口的Init方法
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(ReWriteUrl_BeginRequest);
            context.Error += new EventHandler(context_Error);
        }

        void context_Error(object sender, EventArgs e)
        {
            HttpContext Context = ((HttpApplication)sender).Context;
            string[] _excepts = { "Invalid_Viewstate", "Maximum request length exceeded", "Cannot use a leading .. to exit above the top directory" };
            foreach (Exception ex in Context.AllErrors)
            {
                foreach (string except in _excepts)
                {
                    if (ex.InnerException.Message.Contains(except))
                        break;
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Time:{0}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    sb.AppendFormat("IP:{0}\r\n", HttpContext.Current.Request.UserHostAddress)
                        .AppendFormat("Url:http://{0}{1}\r\n", HttpContext.Current.Request.Url.Host, HttpContext.Current.Request.RawUrl)
                        .AppendFormat("UrlRef:{0}\r\n", HttpContext.Current.Request.UrlReferrer == null ? "" : HttpContext.Current.Request.UrlReferrer.ToString())
                        .AppendFormat("Message:{0}\r\n\r\n", ex.InnerException.ToString());
                }
                else
                {
                    sb.Append(ex.InnerException.ToString())
                        .Append("\r\n");
                }

                Studio.IO.FileAgent.WriteText(HttpContext.Current.Server.MapPath("~/Error.log"), sb.ToString(), true);
            }
        }

        /// <summary>
        /// 实现接口的Dispose方法
        /// </summary>
        public void Dispose(){}

        void ReWriteUrl_BeginRequest(object sender, EventArgs e)
        {

            HttpContext context = ((HttpApplication)sender).Context;

            string _fullpath = context.Request.Path.ToLower().Replace(".aspx", "").Replace("//", "/").Substring(1);


            string[] paths = _fullpath.Split('/');

            string requestPath = context.Request.Path.ToLower().Replace(".aspx","");

            foreach (SiteUrls.URLRewrite url in SiteUrls.GetSiteUrls().Urls)
            {
                if (Regex.IsMatch(requestPath, url.Pattern, RegexOptions.None | RegexOptions.IgnoreCase))
                {
                    string newUrl = Regex.Replace(requestPath, url.Pattern, HttpUtility.UrlDecode(url.QueryString), RegexOptions.None | RegexOptions.IgnoreCase);
                    string queryString = context.Request.QueryString.Count == 0 ? newUrl : (context.Request.QueryString.ToString() + "&" + newUrl);
                    context.RewritePath(url.Page, string.Empty, queryString);
                    return;
                }
            }
        }
    }




    //////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 站点伪Url信息类
    /// </summary>
    public class SiteUrls
    {
        #region 内部属性和方法
        private static object lockHelper = new object();
        private static volatile SiteUrls instance = null;

        string SiteUrlsFile = HttpContext.Current.Server.MapPath("~/App_Data/urls.config");
        private System.Collections.ArrayList _Urls;
        public System.Collections.ArrayList Urls
        {
            get
            {
                return _Urls;
            }
            set
            {
                _Urls = value;
            }
        }

        private System.Collections.Specialized.NameValueCollection _Paths;
        public System.Collections.Specialized.NameValueCollection Paths
        {
            get
            {
                return _Paths;
            }
            set
            {
                _Paths = value;
            }
        }

        private SiteUrls()
        {
            Urls = new System.Collections.ArrayList();
            Paths = new System.Collections.Specialized.NameValueCollection();

            XmlDocument xml = new XmlDocument();

            xml.Load(SiteUrlsFile);

            XmlNode root = xml.SelectSingleNode("urls");
            foreach (XmlNode n in root.ChildNodes)
            {
                if (n.NodeType != XmlNodeType.Comment && n.Name.ToLower() == "rewrite")
                {
                    XmlAttribute name = n.Attributes["name"];
                    XmlAttribute path = n.Attributes["path"];
                    XmlAttribute page = n.Attributes["page"];
                    XmlAttribute querystring = n.Attributes["querystring"];
                    XmlAttribute pattern = n.Attributes["pattern"];

                    if (name != null && path != null && page != null && querystring != null && pattern != null)
                    {
                        Paths.Add(name.Value, path.Value);
                        Urls.Add(new URLRewrite(name.Value, pattern.Value, page.Value.Replace("^", "&"), querystring.Value.Replace("^", "&")));
                    }
                }
            }
        }
        #endregion

        public static SiteUrls GetSiteUrls()
        {
            if (instance == null)
            {
                lock (lockHelper)
                {
                    if (instance == null)
                    {
                        instance = new SiteUrls();
                    }
                }
            }
            return instance;

        }

        public static void SetInstance(SiteUrls anInstance)
        {
            if (anInstance != null)
                instance = anInstance;
        }

        public static void SetInstance()
        {
            SetInstance(new SiteUrls());
        }


        /// <summary>
        /// 重写伪地址
        /// </summary>
        public class URLRewrite
        {
            #region 成员变量
            private string _Name;
            public string Name
            {
                get
                {
                    return _Name;
                }
                set
                {
                    _Name = value;
                }
            }

            private string _Pattern;
            public string Pattern
            {
                get
                {
                    return _Pattern;
                }
                set
                {
                    _Pattern = value;
                }
            }

            private string _Page;
            public string Page
            {
                get
                {
                    return _Page;
                }
                set
                {
                    _Page = value;
                }
            }

            private string _QueryString;
            public string QueryString
            {
                get
                {
                    return _QueryString;
                }
                set
                {
                    _QueryString = value;
                }
            }
            #endregion

            #region 构造函数
            public URLRewrite(string name, string pattern, string page, string querystring)
            {
                _Name = name;
                _Pattern = pattern;
                _Page = page;
                _QueryString = querystring;
            }
            #endregion
        }

    }
}
