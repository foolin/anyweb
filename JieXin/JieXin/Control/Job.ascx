<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Job.ascx.cs" Inherits="Control_Job" %>
<div class="choIndustry" id="ChooseJob">
    <div class="top">
        <i class="iTit">请选择职能(您最多能选择5项)</i> <span class="topRight white">[<a href="javascript:void(0);"
            onclick="confirmDate();return false">确认</a>] </span>
    </div>
    <div class="con gray">
        <h3 class="green">
            已选职能</h3>
        <dl id="job_choosed">
        </dl>
        <div class="dashLine">
        </div>
        <ul id="job_ul">
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,1,'subwJob_',wPos);"
                onclick="return false;">计算机硬件</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,5,'subwJob_',wPos);"
                onclick="return false;">计算机软件</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,20,'subwJob_',wPos);"
                onclick="return false;">互联网开发及应用</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,37,'subwJob_',wPos);"
                onclick="return false;">IT-管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,47,'subwJob_',wPos);"
                onclick="return false;">IT-品管、技术支持及其它</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,61,'subwJob_',wPos);"
                onclick="return false;">通信技术</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,72,'subwJob_',wPos);"
                onclick="return false;">电子/电器/半导体/仪器仪表</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,97,'subwJob_',wPos);"
                onclick="return false;">销售管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,111,'subwJob_',wPos);"
                onclick="return false;">销售人员</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,120,'subwJob_',wPos);"
                onclick="return false;">销售行政及商务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,130,'subwJob_',wPos);"
                onclick="return false;">客服及技术支持</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,143,'subwJob_',wPos);"
                onclick="return false;">财务/审计/税务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,167,'subwJob_',wPos);"
                onclick="return false;">证券/金融/投资</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,179,'subwJob_',wPos);"
                onclick="return false;">银行</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,200,'subwJob_',wPos);"
                onclick="return false;">保险</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,214,'subwJob_',wPos);"
                onclick="return false;">生产/营运</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,229,'subwJob_',wPos);"
                onclick="return false;">质量/安全管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,243,'subwJob_',wPos);"
                onclick="return false;">工程/机械/能源</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,279,'subwJob_',wPos);"
                onclick="return false;">汽车</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,291,'subwJob_',wPos);"
                onclick="return false;">技工</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,306,'subwJob_',wPos);"
                onclick="return false;">服装/纺织/皮革</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,319,'subwJob_',wPos);"
                onclick="return false;">采购</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,327,'subwJob_',wPos);"
                onclick="return false;">贸易</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,336,'subwJob_',wPos);"
                onclick="return false;">物流/仓储</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,360,'subwJob_',wPos);"
                onclick="return false;">生物/制药/医疗器械</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,382,'subwJob_',wPos);"
                onclick="return false;">化工</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,392,'subwJob_',wPos);"
                onclick="return false;">医院/医疗/护理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,414,'subwJob_',wPos);"
                onclick="return false;">广告</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,426,'subwJob_',wPos);"
                onclick="return false;">公关/媒介</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,439,'subwJob_',wPos);"
                onclick="return false;">市场/营销</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,458,'subwJob_',wPos);"
                onclick="return false;">影视/媒体</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,472,'subwJob_',wPos);"
                onclick="return false;">写作/出版/印刷</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,490,'subwJob_',wPos);"
                onclick="return false;">艺术/设计</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,504,'subwJob_',wPos);"
                onclick="return false;">建筑工程</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,532,'subwJob_',wPos);"
                onclick="return false;">房地产</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,542,'subwJob_',wPos);"
                onclick="return false;">物业管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,550,'subwJob_',wPos);"
                onclick="return false;">人力资源</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,567,'subwJob_',wPos);"
                onclick="return false;">高级管理</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,578,'subwJob_',wPos);"
                onclick="return false;">行政/后勤</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,588,'subwJob_',wPos);"
                onclick="return false;">咨询/顾问</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,598,'subwJob_',wPos);"
                onclick="return false;">律师/法务/合规</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,608,'subwJob_',wPos);"
                onclick="return false;">教师</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,620,'subwJob_',wPos);"
                onclick="return false;">培训</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,627,'subwJob_',wPos);"
                onclick="return false;">科研人员</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,630,'subwJob_',wPos);"
                onclick="return false;">餐饮/娱乐</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,642,'subwJob_',wPos);"
                onclick="return false;">酒店/旅游</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,661,'subwJob_',wPos);"
                onclick="return false;">美容/健身/体育</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,677,'subwJob_',wPos);"
                onclick="return false;">百货/连锁/零售服务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,691,'subwJob_',wPos);"
                onclick="return false;">交通运输服务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,702,'subwJob_',wPos);"
                onclick="return false;">保安/家政/其他服务</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,711,'subwJob_',wPos);"
                onclick="return false;">公务员</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,713,'subwJob_',wPos);"
                onclick="return false;">翻译</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,727,'subwJob_',wPos);"
                onclick="return false;">在校学生</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,732,'subwJob_',wPos);"
                onclick="return false;">储备干部/培训生/实习生</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,736,'subwJob_',wPos);"
                onclick="return false;">兼职</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,738,'subwJob_',wPos);"
                onclick="return false;">其他</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,742,'subwJob_',wPos);"
                onclick="return false;">环保</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,746,'subwJob_',wPos);"
                onclick="return false;">农/林/牧/渔</a></li>
        </ul>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>
</div>
