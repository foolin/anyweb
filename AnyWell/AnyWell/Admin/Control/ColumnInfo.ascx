<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ColumnInfo.ascx.cs" Inherits="Admin_Control_ColumnInfo" %>
<div class="operation" id="ColumnInfo">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('ColumnInfo')">
            <img src="../images/icons/arrow2.gif" /></a>栏目信息</h3>
    <div class="opr-mbd">
        <ul>
            <li class="name">
                <%=CurrentColumn.fdColuName %></li>
            <li class="template"><strong>栏目模板</strong>:<input type="text" title="修改模板" value="未设置" />
                <img src="../images/icons/set.gif" alt="更换模板" />
            </li>
            <li class="template"><strong>内页模板</strong>:<input type="text" title="修改模板" value="未设置" />
                <img src="../images/icons/set.gif" alt="更换模板" />
            </li>
            <li><strong>所属站点</strong>:<%=CurrentColumn.Site.fdSiteName %> </li>
            <li><strong>栏目类型</strong>:<%=CurrentColumn.ColumnTypeText %> </li>
        </ul>
    </div>
</div>