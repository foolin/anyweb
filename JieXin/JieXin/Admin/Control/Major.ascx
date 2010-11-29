<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Major.ascx.cs" Inherits="Admin_Control_Major" %>
<div class="choIndustry" id="ChooseMajor">
    <div class="top">
        <i class="iTit">请选择专业</i> <span class="topRight white">[<a href="javascript:void(0);"
            onclick="confirmDate('chooseMaj');">确认</a>] </span>
    </div>
    <div class="con gray">
        <h3 class="green">
            已选专业</h3>
        <dl id="chooseMaj">
        </dl>
        <div class="dashLine">
        </div>
        <ul id="major2_ul">
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,1,'subwMaj2_',majors);">
                管理科学与工程类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,7,'subwMaj2_',majors);">
                工商管理类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,20,'subwMaj2_',majors);">
                公共管理类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,31,'subwMaj2_',majors);">
                图书档案学类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,33,'subwMaj2_',majors);">
                电子信息类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,47,'subwMaj2_',majors);">
                机械类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,55,'subwMaj2_',majors);">
                仪器仪表类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,57,'subwMaj2_',majors);">
                能源动力类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,62,'subwMaj2_',majors);">
                材料类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,70,'subwMaj2_',majors);">
                轻工纺织食品类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,77,'subwMaj2_',majors);">
                土建类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,90,'subwMaj2_',majors);">
                力学类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,93,'subwMaj2_',majors);">
                环境科学与安全类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,98,'subwMaj2_',majors);">
                制药工程类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,100,'subwMaj2_',majors);">
                交通运输类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,108,'subwMaj2_',majors);">
                航空航天类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,113,'subwMaj2_',majors);">
                船舶与海洋工程类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,115,'subwMaj2_',majors);">
                水利类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,119,'subwMaj2_',majors);">
                测绘类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,121,'subwMaj2_',majors);">
                公安技术类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,123,'subwMaj2_',majors);">
                武器类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,130,'subwMaj2_',majors);">
                数学类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,133,'subwMaj2_',majors);">
                物理学类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,136,'subwMaj2_',majors);">
                化学类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,142,'subwMaj2_',majors);">
                生物类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,146,'subwMaj2_',majors);">
                天文地质地理类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,156,'subwMaj2_',majors);">
                经济学类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,168,'subwMaj2_',majors);">
                语言文学类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,185,'subwMaj2_',majors);">
                艺术类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,195,'subwMaj2_',majors);">
                法学类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,206,'subwMaj2_',majors);">
                哲学类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,210,'subwMaj2_',majors);">
                教育学类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,214,'subwMaj2_',majors);">
                医学类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,225,'subwMaj2_',majors);">
                农业类</a></li>
            <li><a href="javascript:void(0);" class="prov" onmouseover="overDetail2(this,240,'subwMaj2_',majors);">
                历史学类</a></li>
        </ul>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>
</div>
