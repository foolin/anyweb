<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiteInfo.ascx.cs" Inherits="Admin_Control_SiteInfo" %>
<div class="operation" id="SiteInfo">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('SiteInfo')">
            <img src="../images/icons/arrow2.gif" /></a>站点信息</h3>
    <div class="opr-mbd">
        <ul>
            <li class="name">
                <%=CurrentSite.fdSiteName %></li>
            <li class="template"><strong>首页模板</strong>:
                <%if( CurrentSite.IndexTemplate == null )
                  {%>
                <input type="text" title="新建模板" value="未设置" readonly="readonly" onclick="window.open('TemplateAdd.aspx?site=true&sid=<%=CurrentSite.fdSiteID %>&type=4', 'template');" />
                <%}
                  else
                  { %>
                <input type="text" title="修改模板" value="<%=CurrentSite.IndexTemplate.fdTempName %>"
                    readonly="readonly" onclick="window.open('TemplateEdit.aspx?sid=<%=CurrentSite.fdSiteID %>&id=<%=CurrentSite.fdSiteIndexTemplateID %>', 'template');" />
                <%} %>
                <img src="../images/icons/set.gif" title="设置模板" alt="设置模板" onclick="parent.setTemplate(<%=CurrentSite.fdSiteID %>,4)" />
            </li>
            <li class="template"><strong>栏目模板</strong>:
                <%if( CurrentSite.ColumnTemplate == null )
                  {%>
                <input type="text" title="新建模板" value="未设置" readonly="readonly" onclick="window.open('TemplateAdd.aspx?site=true&sid=<%=CurrentSite.fdSiteID %>&type=1', 'template');" />
                <%}
                  else
                  { %>
                <input type="text" title="修改模板" value="<%=CurrentSite.ColumnTemplate.fdTempName %>"
                    readonly="readonly" onclick="window.open('TemplateEdit.aspx?sid=<%=CurrentSite.fdSiteID %>&id=<%=CurrentSite.fdSiteColumnTemplateID %>', 'template');" />
                <%} %>
                <img src="../images/icons/set.gif" title="设置模板" alt="设置模板" onclick="parent.setTemplate(<%=CurrentSite.fdSiteID %>,1)" />
            </li>
            <li class="template"><strong>内页模板</strong>:
                <%if( CurrentSite.ContentTemplate == null )
                  {%>
                <input type="text" title="新建模板" value="未设置" readonly="readonly" onclick="window.open('TemplateAdd.aspx?site=true&sid=<%=CurrentSite.fdSiteID %>&type=2', 'template');" />
                <%}
                  else
                  { %>
                <input type="text" title="修改模板" value="<%=CurrentSite.ContentTemplate.fdTempName %>"
                    readonly="readonly" onclick="window.open('TemplateEdit.aspx?sid=<%=CurrentSite.fdSiteID %>&id=<%=CurrentSite.fdSiteContentTemplateID %>', 'template');" />
                <%} %>
                <img src="../images/icons/set.gif" title="设置模板" alt="设置模板" onclick="parent.setTemplate(<%=CurrentSite.fdSiteID %>,2)" />
            </li>
            <li><strong>站点目录</strong>:<%=CurrentSite.fdSitePath %>
            </li>
            <li><strong>站点域名</strong>:<br />
                <a style="padding-left: 0;" href="<%=CurrentSite.fdSiteUrl %>" target="_blank">
                    <%=CurrentSite.fdSiteUrl %></a></li>
        </ul>
    </div>
</div>
