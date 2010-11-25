<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Area2.ascx.cs" Inherits="Control_Area2" %>
<div class="choArea" id="ChooseArea2">
    <div class="top">
        <i class="iTit">请选择工作地点（您最多能选择5项）</i> <span class="topRight white">[<a href="javascript:void(0);"
            onclick="confirmDate('Areas');return false;">确认</a>] </span>
    </div>
    <div class="con gray">
        <h3 style="float: left; width: 100px; clear: none;" class="green lh24">
            已选工作地点</h3>
        <dl style="float: left; width: 300px; margin-left: 0pt; clear: none;" id="chooseArea">
        </dl>
        <div class="dashLine">
        </div>
        <h3>
            主要城市：</h3>
        <div id="area2_ul">
            <dl>
                <dt>华北东北：</dt>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_1" value="北京|1|0" />北京</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_81" value="天津|81|0" />天津</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_334" value="大连|334|332" />大连</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_333" value="沈阳|333|332" />沈阳</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_348" value="长春|348|347" />长春</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_319" value="哈尔滨|319|318" />哈尔滨</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_231" value="石家庄|231|230" />石家庄</a></dd>
            </dl>
            <dl>
                <dt>华东地区：</dt>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_20" value="上海|20|0" />上海</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_84" value="南京|84|83" />南京</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_85" value="苏州|85|83" />苏州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_109" value="杭州|109|108" />杭州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_110" value="宁波|110|108" />宁波</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_213" value="合肥|213|212" />合肥</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_158" value="福州|158|157" />福州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_168" value="济南|168|167" />济南</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_169" value="青岛|169|167" />青岛</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_186" value="南昌|186" />南昌</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_86" value="无锡|86|185" />无锡</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_87" value="常州|87|83" />常州</a></dd>
            </dl>
            <dl>
                <dt>华南华中：</dt>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_40" value="广州|40|39" />广州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_74" value="深圳|74|39" />深圳</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_58" value="东莞|58|39" />东莞</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_262" value="武汉|262|261" />武汉</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_280" value="长沙|280|279" />长沙</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_243" value="郑州|243|242" />郑州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_56" value="佛山|56|39" />佛山</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_57" value="中山|57|39" />中山</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_55" value="珠海|55|39" />珠海</a></dd>
            </dl>
            <dl>
                <dt>西北西南：</dt>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_295" value="西安|295|294" />西安</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_125" value="成都|125|124" />成都</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_82" value="重庆|82|0" />重庆</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);return false;">
                        <input type="checkbox" id="area_359" value="昆明|359|358" />昆明</a></dd>
            </dl>
            <h3>
                所有省份：</h3>
            <dl>
                <dt>华东东北：</dt>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,230,'subArea1_',areas);return false;">
                        河北省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,306,'subArea1_',areas);return false;">
                        山西省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,400,'subArea1_',areas);return false;">
                        内蒙古</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,332,'subArea1_',areas);return false;">
                        辽宁省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,347,'subArea1_',areas);return false;">
                        吉林省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,318,'subArea1_',areas);return false;">
                        黑龙江省</a></dd>
            </dl>
            <dl>
                <dt>华东地区：</dt>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,83,'subArea1_',areas);return false;">
                        江苏省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,108,'subArea1_',areas);return false;">
                        浙江省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,212,'subArea1_',areas);return false;">
                        安徽省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,157,'subArea1_',areas);return false;">
                        福建省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,185,'subArea1_',areas);return false;">
                        江西省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,167,'subArea1_',areas);return false;">
                        山东省</a></dd>
            </dl>
            <dl>
                <dt>华南华中：</dt>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,39,'subArea1_',areas);return false;">
                        广东省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,197,'subArea1_',areas);return false;">
                        广西省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,147,'subArea1_',areas);return false;">
                        海南省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,242,'subArea1_',areas);return false;">
                        河南省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,261,'subArea1_',areas);return false;">
                        湖北省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,279,'subArea1_',areas);return false;">
                        湖南省</a></dd>
            </dl>
            <dl>
                <dt>西北西南：</dt>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,294,'subArea1_',areas);return false;">
                        陕西省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,385,'subArea1_',areas);return false;">
                        甘肃省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,446,'subArea1_',areas);return false;">
                        青海省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,413,'subArea1_',areas);return false;">
                        宁夏</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,427,'subArea1_',areas);return false;">
                        新疆</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,124,'subArea1_',areas);return false;">
                        四川省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,375,'subArea1_',areas);return false;">
                        贵州省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,358,'subArea1_',areas);return false;">
                        云南省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,419,'subArea1_',areas);return false;">
                        西藏</a></dd>
            </dl>
            <dl>
                <dt>其它：</dt>
                <dd>
                    <a href="javascript:void(0);">
                        <input type="checkbox" id="area_455" value="香港|455|0" />香港</a></dd>
                <dd>
                    <a href="javascript:void(0);">
                        <input type="checkbox" id="area_456" value="澳门|456|0" />澳门</a></dd>
                <dd>
                    <a href="javascript:void(0);">
                        <input type="checkbox" id="area_457" value="台湾|457|0" />台湾</a></dd>
                <dd>
                    <a href="javascript:void(0);">
                        <input type="checkbox" id="area_458" value="国外|458|0" />国外</a></dd>
            </dl>
        </div>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>
</div>
