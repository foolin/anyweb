<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Position2.ascx.cs" Inherits="Control_Position2" %>
<div class="choIndustry" id="ChoosePosition2">
    <div class="top">
        <i class="iTit">请选择职能</i> <span class="topRight white">[<a href="javascript:void(0);"
            onclick="confirmDate('choosePos');return false;">确认</a>] </span>
    </div>
    <div class="con gray">
        <h3 class="green">
            已选职能</h3>
        <dl id="choosePos">
        </dl>
        <div class="dashLine">
        </div>
        <ul id="position2_ul">
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,1,'subwPos2_',wPos);">
                计算机硬件</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,5,'subwPos2_',wPos);">
                计算机软件</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,20,'subwPos2_',wPos);">
                互联网开发及应用</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,37,'subwPos2_',wPos);">
                IT-管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,47,'subwPos2_',wPos);">
                IT-品管、技术支持及其它</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,61,'subwPos2_',wPos);">
                通信技术</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,72,'subwPos2_',wPos);">
                电子/电器/半导体/仪器仪表</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,97,'subwPos2_',wPos);">
                销售管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,111,'subwPos2_',wPos);">
                销售人员</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,120,'subwPos2_',wPos);">
                销售行政及商务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,130,'subwPos2_',wPos);">
                客服及技术支持</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,143,'subwPos2_',wPos);">
                财务/审计/税务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,167,'subwPos2_',wPos);">
                证券/金融/投资</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,179,'subwPos2_',wPos);">
                银行</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,200,'subwPos2_',wPos);">
                保险</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,214,'subwPos2_',wPos);">
                生产/营运</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,229,'subwPos2_',wPos);">
                质量/安全管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,243,'subwPos2_',wPos);">
                工程/机械/能源</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,279,'subwPos2_',wPos);">
                汽车</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,291,'subwPos2_',wPos);">
                技工</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,306,'subwPos2_',wPos);">
                服装/纺织/皮革</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,319,'subwPos2_',wPos);">
                采购</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,327,'subwPos2_',wPos);">
                贸易</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,336,'subwPos2_',wPos);">
                物流/仓储</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,360,'subwPos2_',wPos);">
                生物/制药/医疗器械</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,382,'subwPos2_',wPos);">
                化工</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,392,'subwPos2_',wPos);">
                医院/医疗/护理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,414,'subwPos2_',wPos);">
                广告</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,426,'subwPos2_',wPos);">
                公关/媒介</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,439,'subwPos2_',wPos);">
                市场/营销</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,458,'subwPos2_',wPos);">
                影视/媒体</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,472,'subwPos2_',wPos);">
                写作/出版/印刷</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,490,'subwPos2_',wPos);">
                艺术/设计</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,504,'subwPos2_',wPos);">
                建筑工程</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,532,'subwPos2_',wPos);">
                房地产</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,542,'subwPos2_',wPos);">
                物业管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,550,'subwPos2_',wPos);">
                人力资源</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,567,'subwPos2_',wPos);">
                高级管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,578,'subwPos2_',wPos);">
                行政/后勤</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,588,'subwPos2_',wPos);">
                咨询/顾问</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,598,'subwPos2_',wPos);">
                律师/法务/合规</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,608,'subwPos2_',wPos);">
                教师</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,620,'subwPos2_',wPos);">
                培训</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,627,'subwPos2_',wPos);">
                科研人员</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,630,'subwPos2_',wPos);">
                餐饮/娱乐</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,642,'subwPos2_',wPos);">
                酒店/旅游</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,661,'subwPos2_',wPos);">
                美容/健身/体育</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,677,'subwPos2_',wPos);">
                百货/连锁/零售服务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,691,'subwPos2_',wPos);">
                交通运输服务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,702,'subwPos2_',wPos);">
                保安/家政/其他服务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,711,'subwPos2_',wPos);">
                公务员</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,713,'subwPos2_',wPos);">
                翻译</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,727,'subwPos2_',wPos);">
                在校学生</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,732,'subwPos2_',wPos);">
                储备干部/培训生/实习生</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,736,'subwPos2_',wPos);">
                兼职</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,738,'subwPos2_',wPos);">
                其他</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,742,'subwPos2_',wPos);">
                环保</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,746,'subwPos2_',wPos);">
                农/林/牧/渔</a></li>
        </ul>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>
</div>
