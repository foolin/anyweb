<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductSearchOperation.ascx.cs" Inherits="Admin_Control_ProductSearchOperation" %>
<div class="operation"id="ProductOpr">
    <h3 class="opr-mhd">
        <a href="javascript:showFolder('ProductOpr')">
            <img src="../images/icons/arrow2.gif" /></a>文档操作任务</h3>
    <div class="opr-mbd">
        <ul>
            <li class="recFile"><a href="javascript:recycleProduct()">放入回收站</a></li>
            <li class="moveFile"><a href="javascript:moveProduct()">移动产品到</a></li>
            <li class="copyFile"><a href="javascript:copyProduct()">复制产品到</a></li>
            <li class="pointFile"><a href="javascript:pointProduct()">引用产品到</a></li>
        </ul>
    </div>
</div>