﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Position.ascx.cs" Inherits="Control_Position" %>
<div class="choIndustry" id="ChoosePosition" style="display: block;">
    <div class="top">
        <i class="iTit">请选择职位</i> <span class="topRight white">[<a href="javascript:void(0);"
            onclick="ClearArea()">无合适项</a>]&nbsp;&nbsp;<a href="javascript:void(0);" onclick="closeWindow('ChoosePosition')">
                <img src="/images/icon_close.gif" width="15" height="15" /></a> </span>
    </div>
    <div class="con gray">
        <ul>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,1,'subwPos_',wPos);">
                计算机硬件</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,5,'subwPos_',wPos);">
                计算机软件</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,20,'subwPos_',wPos);">
                互联网开发及应用</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,37,'subwPos_',wPos);">
                IT-管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,47,'subwPos_',wPos);">
                IT-品管、技术支持及其它</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,61,'subwPos_',wPos);">
                通信技术</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,72,'subwPos_',wPos);">
                电子/电器/半导体/仪器仪表</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,97,'subwPos_',wPos);">
                销售管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,111,'subwPos_',wPos);">
                销售人员</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,120,'subwPos_',wPos);">
                销售行政及商务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,130,'subwPos_',wPos);">
                客服及技术支持</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,143,'subwPos_',wPos);">
                财务/审计/税务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,167,'subwPos_',wPos);">
                证券/金融/投资</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,179,'subwPos_',wPos);">
                银行</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,200,'subwPos_',wPos);">
                保险</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,214,'subwPos_',wPos);">
                生产/营运</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,229,'subwPos_',wPos);">
                质量/安全管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,243,'subwPos_',wPos);">
                工程/机械/能源</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,279,'subwPos_',wPos);">
                汽车</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,291,'subwPos_',wPos);">
                技工</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,306,'subwPos_',wPos);">
                服装/纺织/皮革</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,319,'subwPos_',wPos);">
                采购</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,327,'subwPos_',wPos);">
                贸易</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,336,'subwPos_',wPos);">
                物流/仓储</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,360,'subwPos_',wPos);">
                生物/制药/医疗器械</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,382,'subwPos_',wPos);">
                化工</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,392,'subwPos_',wPos);">
                医院/医疗/护理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,414,'subwPos_',wPos);">
                广告</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,426,'subwPos_',wPos);">
                公关/媒介</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,439,'subwPos_',wPos);">
                市场/营销</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,458,'subwPos_',wPos);">
                影视/媒体</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,472,'subwPos_',wPos);">
                写作/出版/印刷</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,490,'subwPos_',wPos);">
                艺术/设计</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,504,'subwPos_',wPos);">
                建筑工程</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,532,'subwPos_',wPos);">
                房地产</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,542,'subwPos_',wPos);">
                物业管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,550,'subwPos_',wPos);">
                人力资源</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,567,'subwPos_',wPos);">
                高级管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,578,'subwPos_',wPos);">
                行政/后勤</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,588,'subwPos_',wPos);">
                咨询/顾问</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,598,'subwPos_',wPos);">
                律师/法务/合规</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,608,'subwPos_',wPos);">
                教师</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,620,'subwPos_',wPos);">
                培训</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,627,'subwPos_',wPos);">
                科研人员</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,630,'subwPos_',wPos);">
                餐饮/娱乐</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,642,'subwPos_',wPos);">
                酒店/旅游</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,661,'subwPos_',wPos);">
                美容/健身/体育</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,677,'subwPos_',wPos);">
                百货/连锁/零售服务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,691,'subwPos_',wPos);">
                交通运输服务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,702,'subwPos_',wPos);">
                保安/家政/其他服务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,711,'subwPos_',wPos);">
                公务员</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,713,'subwPos_',wPos);">
                翻译</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,727,'subwPos_',wPos);">
                在校学生</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,732,'subwPos_',wPos);">
                储备干部/培训生/实习生</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,736,'subwPos_',wPos);">
                兼职</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,738,'subwPos_',wPos);">
                其他</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,742,'subwPos_',wPos);">
                环保</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,746,'subwPos_',wPos);">
                农/林/牧/渔</a></li>
        </ul>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>
</div>
