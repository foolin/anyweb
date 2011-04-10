<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiteInfo.ascx.cs" Inherits="Admin_Control_SiteInfo" %>
<div class="operation" id="SiteInfo">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('SiteInfo')">
            <img src="../images/icons/arrow2.gif" /></a>站点信息</h3>
    <div class="opr-mbd">
        <ul>
            <li class="name">
                <%=CurrentSite.fdSiteName %></li>
            <li class="template"><strong>首页模板</strong>:<input type="text" title="修改模板" value="未设置" />
                <img src="../images/icons/set.gif" alt="更换模板" />
            </li>
            <li class="template"><strong>栏目模板</strong>:<input type="text" title="修改模板" value="未设置" />
                <img src="../images/icons/set.gif" alt="更换模板" />
            </li>
            <li class="template"><strong>内页模板</strong>:<input type="text" title="修改模板" value="未设置" />
                <img src="../images/icons/set.gif" alt="更换模板" />
            </li>
            <li><strong>目录名称</strong>:目录名称 </li>
            <li><strong>站点域名</strong>:<br />
                <a style="padding-left: 0;" href="<%=CurrentSite.fdSiteUrl %>" target="_blank">
                    <%=CurrentSite.fdSiteUrl %></a></li>
        </ul>
    </div>
</div>
