<%@ Application Language="C#" %>

<%@ Import Namespace="Studio.Web" %>
<%@ Import Namespace="Common.Agent" %>
<%@ Import Namespace="Common.Common" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码
        //获取插件列表
        new Common.Agent.WidGetAgent().GetWidgets();
        
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }

    void Application_BeginRequest(object sender, EventArgs e)
     {
         if (Request.Cookies["SHOPID"] != null)
         {

             Shop s2 = (new ShopAgent()).GetShopInfo(int.Parse(Request.Cookies["SHOPID"].Value));

             if (s2 != null)
             {
                 Context.Items.Add("SHOP_INFO", s2);
             }
         }
     }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。

    }
       
</script>
