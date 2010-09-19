﻿<%@ Application Language="C#" %>
<%@ Import Namespace="System.IO" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码

    }

    /// <summary>
    /// 错误日志
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Application_Error(object sender, EventArgs e)
    {
        HttpContext Context = ((HttpApplication)sender).Context;
        foreach (Exception ex in Context.AllErrors)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Time:{0}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                sb.AppendFormat("IP:{0}\r\n", HttpContext.Current.Request.UserHostAddress)
                    .AppendFormat("Url:{0}\r\n", HttpContext.Current.Request.RawUrl)
                    .AppendFormat("UrlRef:{0}\r\n", HttpContext.Current.Request.UrlReferrer == null ? "" : HttpContext.Current.Request.UrlReferrer.ToString())
                    .AppendFormat("Message:{0}\r\n\r\n", ex.ToString());
            }
            else
            {
                sb.Append(ex.ToString())
                    .Append("\r\n");
            }

            try
            {
                FileInfo fi = new FileInfo(Server.MapPath("/Error.log"));
                if (fi.Exists && fi.Length > 1024 * 1024 * 100)
                {
                    fi.MoveTo(Server.MapPath(string.Format("/Error_{0}.log", DateTime.Now.ToString("yyyyMMddHHmmss"))));
                }
                Studio.IO.FileAgent.WriteText(Server.MapPath("/Error.log"), sb.ToString(), true);
            }
            finally
            { }
        }
    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }

    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        string actualPath;
        AnalyseRequest(out actualPath);
        if (actualPath == string.Empty || actualPath == null) 
            actualPath = "/index.aspx";
        Context.RewritePath(actualPath, Request.PathInfo, Request.QueryString.ToString());
    }

    void AnalyseRequest(out string realPath)
    {
        realPath = "/index.aspx";
        string requestPath = Request.Path.ToLower();
        if (requestPath == "/" || requestPath == "/index.aspx") //首页
        {
            return; 
        }
        if (requestPath.IndexOf("/admin") > -1)  //管理后台
        {
            realPath = Request.Path;
            return; 
        }
        requestPath = Request.Path.ToLower().Replace("\\", "/").Replace(".aspx", "").Substring(1);

        if (requestPath.EndsWith("/"))
            requestPath = requestPath.Remove(requestPath.Length - 1, 1);

        string[] urlInfo = requestPath.Split('/');
        if (urlInfo.Length < 2) 
        {
            realPath = "/Error.html";
        }
        switch (urlInfo[0])
        {
            case "c":   //文章列表页
                {
                    realPath = "/ArticleList_temp.aspx";
                    Context.Items.Add("COLUMNID", urlInfo[1]);
                    break;
                }
            case "a":   //文章内容页
                {
                    realPath = "/Article_Temp.aspx";
                    Context.Items.Add("ARTICLEID", urlInfo[1]);
                    break;
                }
            case "notice":  //公告列表页
                {
                    realPath = "/NoticeList_Temp.aspx";
                    break;
                }
            case "n":   //公告内容页
                {
                    realPath = "/Notice_Temp.aspx";
                    Context.Items.Add("NOTICEID", urlInfo[1]);
                    break;
                }
            default:
                {
                    realPath = "/Error.html";
                    break;
                }
        }
    }
       
</script>