<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Area2.ascx.cs" Inherits="Control_Area2" %>
<div class="choArea" id="ChooseArea2">
    <div class="top">
        <i class="iTit">请选择工作地点</i> <span class="topRight white">[<a href="javascript:void(0);"
            onclick="ClearArea();return false;">不限</a>]&nbsp;&nbsp; <a href="javascript:void(0);"
                onclick="closeWindow('ChooseArea');return false;">
                <img src="/images/icon_close.gif" width="15" height="15" /></a> </span>
    </div>
    <div class="con gray">
        <h3>
            主要城市：</h3>
        <dl>
            <dt>华北东北：</dt>
            <dd>
                <ul>
                    <li title="计算机软件">
                        <input type="checkbox" id="industry_1" value="计算机软件|1" />计算机软件</li>
                    <li title="计算机软件">
                        <input type="checkbox" id="Checkbox1" value="计算机软件|1" />计算机软件</li>
                </ul>
                </dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this,334);return false;">大连</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this,333);return false;">沈阳</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this,348);return false;">长春</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this,319);return false;">哈尔滨</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="AreaName(this,231);return false;">石家庄</a></dd>
        </dl>
        <dl>
            <dt>华东地区：</dt>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,20);return false;">上海</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,84);return false;">南京</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,85);return false;">苏州</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,109);return false;">杭州</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,110);return false;">宁波</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,213);return false;">合肥</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,158);return false;">福州</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,168);return false;">济南</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,169);return false;">青岛</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,186);return false;">南昌</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,86);return false;">无锡</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,87);return false;">常州</a></dd>
        </dl>
        <dl>
            <dt>华南华中：</dt>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,40);return false;">广州</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,74);return false;">深圳</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,58);return false;">东莞</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,262);return false;">武汉</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,280);return false;">长沙</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,243);return false;">郑州</a></dd>
        </dl>
        <dl>
            <dt>西北西南：</dt>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,295);return false;">西安</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,125);return false;">成都</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,82);return false;">重庆</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,359);return false;">昆明</a></dd>
        </dl>
        <h3>
            所有省份：</h3>
        <dl>
            <dt>华东东北：</dt>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,230,'subArea_',areas);"
                    onclick="return false;">河北省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,306,'subArea_',areas);"
                    onclick="return false;">山西省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,400,'subArea_',areas);"
                    onclick="return false;">内蒙古</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,332,'subArea_',areas);"
                    onclick="return false;">辽宁省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,347,'subArea_',areas);"
                    onclick="return false;">吉林省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,318,'subArea_',areas);"
                    onclick="return false;">黑龙江省</a></dd>
        </dl>
        <dl>
            <dt>华东地区：</dt>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,83,'subArea_',areas);"
                    onclick="return false;">江苏省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,108,'subArea_',areas);"
                    onclick="return false;">浙江省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,212,'subArea_',areas);"
                    onclick="return false;">安徽省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,157,'subArea_',areas);"
                    onclick="return false;">福建省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,185,'subArea_',areas);"
                    onclick="return false;">江西省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,167,'subArea_',areas);"
                    onclick="return false;">山东省</a></dd>
        </dl>
        <dl>
            <dt>华南华中：</dt>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,39,'subArea_',areas);"
                    onclick="return false;">广东省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,197,'subArea_',areas);"
                    onclick="return false;">广西省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,147,'subArea_',areas);"
                    onclick="return false;">海南省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,242,'subArea_',areas);"
                    onclick="return false;">河南省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,261,'subArea_',areas);"
                    onclick="return false;">湖北省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,279,'subArea_',areas);"
                    onclick="return false;">湖南省</a></dd>
        </dl>
        <dl>
            <dt>西北西南：</dt>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,294,'subArea_',areas);"
                    onclick="return false;">陕西省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,385,'subArea_',areas);"
                    onclick="return false;">甘肃省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,446,'subArea_',areas);"
                    onclick="return false;">青海省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,413,'subArea_',areas);"
                    onclick="return false;">宁夏</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,427,'subArea_',areas);"
                    onclick="return false;">新疆</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,124,'subArea_',areas);"
                    onclick="return false;">四川省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,375,'subArea_',areas);"
                    onclick="return false;">贵州省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,358,'subArea_',areas);"
                    onclick="return false;">云南省</a></dd>
            <dd>
                <a href="javascript:void(0);" class="prov" onmouseover="overDetail(this,419,'subArea_',areas);"
                    onclick="return false;">西藏</a></dd>
        </dl>
        <dl>
            <dt>其它：</dt>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,455);return false;">香港</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,456);return false;">澳门</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,457);return false;">台湾</a></dd>
            <dd>
                <a href="javascript:void(0);" onclick="AreaName(this,458);return false;">国外</a></dd>
        </dl>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>
</div>
