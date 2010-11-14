<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Area.ascx.cs" Inherits="Control_Area" %>
<div class="choArea" id="ChooseArea">
    <div class="top">
        <i class="iTit">请选择工作地点</i> <span class="topRight white">[<a href="javascript:void(0);"
            onclick="ClearArea()">不限</a>]&nbsp;&nbsp; <a href="javascript:void(0);" onclick="closeWindow('ChooseArea')">
                <img src="/images/icon_close.gif" width="15" height="15" /></a> </span>
    </div>
    <div class="con gray">
        <h3>
            主要城市：</h3>
        <dl>
            <dt>华北东北：</dt>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,1);">北京</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,81);">天津</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,334);">大连</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,333);">沈阳</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,348);">长春</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,319);">哈尔滨</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,231);">石家庄</a></dd>
        </dl>
        <dl>
            <dt>华东地区：</dt>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,20);">上海</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,84);">南京</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,85);">苏州</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,109);">杭州</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,110);">宁波</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,213);">合肥</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,158);">福州</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,168);">济南</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,169);">青岛</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,186);">南昌</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,86);">无锡</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,87);">常州</a></dd>
        </dl>
        <dl>
            <dt>华南华中：</dt>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,40);">广州</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,74);">深圳</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,58);">东莞</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,262);">武汉</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,280);">长沙</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,243);">郑州</a></dd>
        </dl>
        <dl>
            <dt>西北西南：</dt>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,295);">西安</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,125);">成都</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,82);">重庆</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,359);">昆明</a></dd>
        </dl>
        <h3>
            所有省份：</h3>
        <dl>
            <dt>华东东北：</dt>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,230,'subArea_',areas);">河北省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,306,'subArea_',areas);">山西省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,400,'subArea_',areas);">内蒙古</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,332,'subArea_',areas);">辽宁省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,347,'subArea_',areas);">吉林省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,318,'subArea_',areas);">黑龙江省</a></dd>
        </dl>
        <dl>
            <dt>华东地区：</dt>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,83,'subArea_',areas);">江苏省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,108,'subArea_',areas);">浙江省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,212,'subArea_',areas);">安徽省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,157,'subArea_',areas);">福建省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,185,'subArea_',areas);">江西省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,167,'subArea_',areas);">山东省</a></dd>
        </dl>
        <dl>
            <dt>华南华中：</dt>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,39,'subArea_',areas);">广东省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,197,'subArea_',areas);">广西省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,147,'subArea_',areas);">海南省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,242,'subArea_',areas);">河南省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,261,'subArea_',areas);">湖北省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,279,'subArea_',areas);">湖南省</a></dd>
        </dl>
        <dl>
            <dt>西北西南：</dt>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,294,'subArea_',areas);">陕西省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,385,'subArea_',areas);">甘肃省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,446,'subArea_',areas);">青海省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,413,'subArea_',areas);">宁夏</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,427,'subArea_',areas);">新疆</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,124,'subArea_',areas);">四川省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,375,'subArea_',areas);">贵州省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,358,'subArea_',areas);">云南省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,419,'subArea_',areas);">西藏</a></dd>
        </dl>
        <dl>
            <dt>其它：</dt>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,455);">香港</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,456);">澳门</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,457);">台湾</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,458);">国外</a></dd>
        </dl>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>
</div>

