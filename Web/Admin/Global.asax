<%@ Application Language="C#" %>
<%@ Import Namespace="AnyWeb.AnyWeb_DL" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码
        for (int i = 0; i < Context.AllErrors.Length; i++)
        {
            SysAgent.GetAgent().WriteError(Context.AllErrors[i]);
        }
    }

    void Application_BeginRequest(object sender, EventArgs e)
    {
        int UserID = 0;
        if (Request.Cookies["USERINFO"] != null && Studio.Web.WebAgent.IsInt32(Request.Cookies["USERINFO"]["UserID"]))
        {
            UserID = int.Parse(Request.Cookies["USERINFO"]["UserID"]);
        }

        if (UserID > 0)
        {
            Site site = new SiteAgent().GetSiteInfo();
            if (site != null)
            {
                Context.Items.Add("SITEINFO", site);
                AnyWeb.AnyWeb_DL.User loginUser = site.GetUserByID(UserID);
                if (loginUser != null)
                    Context.Items.Add("LOGIN_USER", loginUser);
            }
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
       
</script>
