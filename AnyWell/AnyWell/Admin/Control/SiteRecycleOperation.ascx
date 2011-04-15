<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SiteRecycleOperation.ascx.cs" Inherits="Admin_Control_SiteRecycleOperation" %>
<div class="operation" id="RecycleOpr">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('RecycleOpr')">
            <img src="../images/icons/arrow2.gif" /></a>文档操作任务</h3>
    <div class="opr-mbd">
        <ul>
            <li class="revFile"><a href="javascript:revokeArticle()">恢复文档</a></li>
            <li class="recFile"><a href="javascript:deleteArticle()">彻底删除文档</a></li>
            <li class="delFile"><a href="javascript:clearSiteRecycle(<%=CurrentSite.fdSiteID %>)">
                清空回收站</a></li>
        </ul>
    </div>
</div>