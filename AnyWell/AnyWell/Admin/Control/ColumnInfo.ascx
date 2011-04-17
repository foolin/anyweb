<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ColumnInfo.ascx.cs" Inherits="Admin_Control_ColumnInfo" %>
<div class="operation" id="ColumnInfo">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('ColumnInfo')">
            <img src="../images/icons/arrow2.gif" /></a>栏目信息</h3>
    <div class="opr-mbd">
        <ul>
            <li class="name">
                <%=CurrentColumn.fdColuName %></li>
            <li class="template"><strong>栏目模板</strong>:
                <%if( CurrentColumn.IndexTemplate == null )
                  {%>
                <input type="text" title="新建模板" value="未设置" readonly="readonly" onclick="window.open('../Template/TemplateAdd.aspx?column=true&sid=<%=CurrentSite.fdSiteID %>&cid=<%=CurrentColumn.fdColuID %>&type=1', 'template');" />
                <%}
                  else
                  { %>
                <input type="text" title="修改模板" value="<%=CurrentColumn.IndexTemplate.fdTempName %>"
                    readonly="readonly" onclick="window.open('../Template/TemplateEdit.aspx?sid=<%=CurrentSite.fdSiteID %>&id=<%=CurrentColumn.fdColuIndexTemplateID %>', 'template');" />
                <%} %>
                <img src="../images/icons/set.gif" title="设置模板" alt="设置模板" onclick="parent.setTemplate(<%=CurrentSite.fdSiteID %>,1,<%=CurrentColumn.fdColuID %>)" />
            </li>
            <li class="template"><strong>内页模板</strong>:
                <%if( CurrentColumn.ContentTemplate == null )
                  {%>
                <input type="text" title="新建模板" value="未设置" readonly="readonly" onclick="window.open('../Template/TemplateAdd.aspx?column=true&sid=<%=CurrentSite.fdSiteID %>&cid=<%=CurrentColumn.fdColuID %>&type=2', 'template');" />
                <%}
                  else
                  { %>
                <input type="text" title="修改模板" value="<%=CurrentColumn.ContentTemplate.fdTempName %>"
                    readonly="readonly" onclick="window.open('../Template/TemplateEdit.aspx?sid=<%=CurrentSite.fdSiteID %>&id=<%=CurrentColumn.fdColuContentTemplateID %>', 'template');" />
                <%} %>
                <img src="../images/icons/set.gif" title="设置模板" alt="设置模板" onclick="parent.setTemplate(<%=CurrentSite.fdSiteID %>,2,<%=CurrentColumn.fdColuID %>)" />
            </li>
            <li><strong>所属站点</strong>:<%=CurrentColumn.Site.fdSiteName %>
            </li>
            <li><strong>栏目类型</strong>:<%=CurrentColumn.ColumnTypeText %>
            </li>
        </ul>
    </div>
</div>
