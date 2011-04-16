<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TemplateOperation.ascx.cs" Inherits="Admin_Control_TemplateOperation" %>
<div class="operation"id="TemplateOpr">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('TemplateOpr')">
            <img src="../images/icons/arrow2.gif" /></a>模板操作任务</h3>
    <div class="opr-mbd">
        <ul>
            <li class="new"><a href="TemplateAdd.aspx?sid=<%=CurrentSite.fdSiteID %>" target="template">新建模板</a></li>
            <li class="recFile"><a href="javascript:delTemplate(<%=CurrentSite.fdSiteID %>)">删除模板</a></li>
        </ul>
    </div>
</div>