<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiteOperation.ascx.cs"
    Inherits="Admin_Control_SiteOperation" %>
<div class="operation" id="SiteOpr">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('SiteOpr')">
            <img src="../images/icons/arrow2.gif" /></a>站点操作任务</h3>
    <div class="opr-mbd">
        <ul>
            <li class="new"><a href="javascript:parent.addSiteColumn(<%=CurrentSite.fdSiteID %>);">
                新建栏目</a></li>
            <li class="perFile"><a href="javascript:parent.editSite(<%=CurrentSite.fdSiteID %>)">
                修改站点</a></li>
            <li class="delFile"><a href="javascript:parent.delSite(<%=CurrentSite.fdSiteID %>)">
                删除站点</a></li>
        </ul>
    </div>
</div>
