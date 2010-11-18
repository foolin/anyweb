<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Major.ascx.cs" Inherits="Control_Major" %>
<div class="choArea" id="major">
    <div class="top">
        <i class="iTit">请选择专业</i> <span class="topRight white">[<a href="javascript:void(0);"
            onclick="ClearArea();return false;">不限</a>]&nbsp;&nbsp; <a href="javascript:void(0);" onclick="closeWindow('major');return false">
                <img src="/images/icon_close.gif" width="15" height="15" /></a> </span>
    </div>
    <div class="con majCon gray">
        <dl class="majItems">
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,1,'subMajor_',majors);" onclick="return false;">
                    管理科学与工程类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,7,'subMajor_',majors);" onclick="return false;">
                    工商管理类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,20,'subMajor_',majors);" onclick="return false;">
                    公共管理类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,31,'subMajor_',majors);" onclick="return false;">
                    图书档案学类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,33,'subMajor_',majors);" onclick="return false;">
                    电子信息类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,47,'subMajor_',majors);" onclick="return false;">
                    机械类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,55,'subMajor_',majors);" onclick="return false;">仪器仪表类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,57,'subMajor_',majors);" onclick="return false;">能源动力类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,62,'subMajor_',majors);" onclick="return false;">材料类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,70,'subMajor_',majors);" onclick="return false;">轻工纺织食品类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,77,'subMajor_',majors);" onclick="return false;">土建类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,90,'subMajor_',majors);" onclick="return false;">力学类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,93,'subMajor_',majors);" onclick="return false;">环境科学与安全类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,98,'subMajor_',majors);" onclick="return false;">制药工程类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,100,'subMajor_',majors);" onclick="return false;">交通运输类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,108,'subMajor_',majors);" onclick="return false;">航空航天类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,113,'subMajor_',majors);" onclick="return false;">船舶与海洋工程类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,115,'subMajor_',majors);" onclick="return false;">水利类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,119,'subMajor_',majors);" onclick="return false;">测绘类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,121,'subMajor_',majors);" onclick="return false;">公安技术类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,123,'subMajor_',majors);" onclick="return false;">武器类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,130,'subMajor_',majors);" onclick="return false;">数学类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,133,'subMajor_',majors);" onclick="return false;">物理学类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,136,'subMajor_',majors);" onclick="return false;">化学类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,142,'subMajor_',majors);" onclick="return false;">生物类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,146,'subMajor_',majors);" onclick="return false;">天文地质地理类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,156,'subMajor_',majors);" onclick="return false;">经济学类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,168,'subMajor_',majors);" onclick="return false;">语言文学类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,185,'subMajor_',majors);" onclick="return false;">艺术类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,195,'subMajor_',majors);" onclick="return false;">法学类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,206,'subMajor_',majors);" onclick="return false;">哲学类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,210,'subMajor_',majors);" onclick="return false;">教育学类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,214,'subMajor_',majors);" onclick="return false;">医学类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,225,'subMajor_',majors);" onclick="return false;">农业类</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,240,'subMajor_',majors);" onclick="return false;">历史学类</a></dd>
        </dl>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>
</div>
