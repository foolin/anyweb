<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArticleSearchOperation.ascx.cs" Inherits="Admin_Control_ArticleSearchOperation" %>
<div class="operation"id="ArticleOpr">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('ArticleOpr')">
            <img src="../images/icons/arrow2.gif" /></a>文档操作任务</h3>
    <div class="opr-mbd">
        <ul>
            <li class="recFile"><a href="javascript:recycleArticle()">放入回收站</a></li>
            <li class="moveFile"><a href="javascript:moveArticle()">移动文档到</a></li>
            <li class="copyFile"><a href="javascript:copyArticle()">复制文档到</a></li>
            <li class="pointFile"><a href="javascript:pointArticle()">引用文档到</a></li>
        </ul>
    </div>
</div>