<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Area2.ascx.cs" Inherits="Admin_Control_Area2" %>
<div class="choArea" id="ChooseArea2">
    <div class="top">
        <i class="iTit">请选择工作地点（您最多能选择3项）</i> <span class="topRight white">[<a href="javascript:void(0);"
            onclick="confirmDate('Areas');">确认</a>] </span>
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
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_1" value="北京|1|0" onclick="this.checked=!this.checked;" />北京</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_81" value="天津|81|0" onclick="this.checked=!this.checked;" />天津</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_334" value="大连|334|332" onclick="this.checked=!this.checked;" />大连</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_333" value="沈阳|333|332" onclick="this.checked=!this.checked;" />沈阳</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_348" value="长春|348|347" onclick="this.checked=!this.checked;" />长春</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_319" value="哈尔滨|319|318" onclick="this.checked=!this.checked;" />哈尔滨</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_231" value="石家庄|231|230" onclick="this.checked=!this.checked;" />石家庄</a></dd>
            </dl>
            <dl>
                <dt>华东地区：</dt>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_20" value="上海|20|0" onclick="this.checked=!this.checked;" />上海</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_84" value="南京|84|83" onclick="this.checked=!this.checked;" />南京</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_85" value="苏州|85|83" onclick="this.checked=!this.checked;" />苏州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_109" value="杭州|109|108" onclick="this.checked=!this.checked;" />杭州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_110" value="宁波|110|108" onclick="this.checked=!this.checked;" />宁波</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_213" value="合肥|213|212" onclick="this.checked=!this.checked;" />合肥</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_158" value="福州|158|157" onclick="this.checked=!this.checked;" />福州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_168" value="济南|168|167" onclick="this.checked=!this.checked;" />济南</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_169" value="青岛|169|167" onclick="this.checked=!this.checked;" />青岛</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_186" value="南昌|186" onclick="this.checked=!this.checked;" />南昌</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_86" value="无锡|86|185" onclick="this.checked=!this.checked;" />无锡</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_87" value="常州|87|83" onclick="this.checked=!this.checked;" />常州</a></dd>
            </dl>
            <dl>
                <dt>华南华中：</dt>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_40" value="广州|40|39" onclick="this.checked=!this.checked;" />广州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_74" value="深圳|74|39" onclick="this.checked=!this.checked;" />深圳</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_58" value="东莞|58|39" onclick="this.checked=!this.checked;" />东莞</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_262" value="武汉|262|261" onclick="this.checked=!this.checked;" />武汉</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_280" value="长沙|280|279" onclick="this.checked=!this.checked;" />长沙</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_243" value="郑州|243|242" onclick="this.checked=!this.checked;" />郑州</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_56" value="佛山|56|39" onclick="this.checked=!this.checked;" />佛山</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_57" value="中山|57|39" onclick="this.checked=!this.checked;" />中山</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_55" value="珠海|55|39" onclick="this.checked=!this.checked;" />珠海</a></dd>
            </dl>
            <dl>
                <dt>西北西南：</dt>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_295" value="西安|295|294" onclick="this.checked=!this.checked;" />西安</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_125" value="成都|125|124" onclick="this.checked=!this.checked;" />成都</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_82" value="重庆|82|0" onclick="this.checked=!this.checked;" />重庆</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_359" value="昆明|359|358" onclick="this.checked=!this.checked;" />昆明</a></dd>
            </dl>
            <h3>
                所有省份：</h3>
            <dl>
                <dt>华东东北：</dt>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,230,'subArea1_',areas);">
                        河北省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,306,'subArea1_',areas);">
                        山西省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,400,'subArea1_',areas);">
                        内蒙古</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,332,'subArea1_',areas);">
                        辽宁省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,347,'subArea1_',areas);">
                        吉林省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,318,'subArea1_',areas);">
                        黑龙江省</a></dd>
            </dl>
            <dl>
                <dt>华东地区：</dt>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,83,'subArea1_',areas);">
                        江苏省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,108,'subArea1_',areas);">
                        浙江省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,212,'subArea1_',areas);">
                        安徽省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,157,'subArea1_',areas);">
                        福建省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,185,'subArea1_',areas);">
                        江西省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,167,'subArea1_',areas);">
                        山东省</a></dd>
            </dl>
            <dl>
                <dt>华南华中：</dt>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,39,'subArea1_',areas);">
                        广东省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,197,'subArea1_',areas);">
                        广西省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,147,'subArea1_',areas);">
                        海南省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,242,'subArea1_',areas);">
                        河南省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,261,'subArea1_',areas);">
                        湖北省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,279,'subArea1_',areas);">
                        湖南省</a></dd>
            </dl>
            <dl>
                <dt>西北西南：</dt>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,294,'subArea1_',areas);">
                        陕西省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,385,'subArea1_',areas);">
                        甘肃省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,446,'subArea1_',areas);">
                        青海省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,413,'subArea1_',areas);">
                        宁夏</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,427,'subArea1_',areas);">
                        新疆</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,124,'subArea1_',areas);">
                        四川省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,375,'subArea1_',areas);">
                        贵州省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,358,'subArea1_',areas);">
                        云南省</a></dd>
                <dd>
                    <a href="javascript:void(0);" class="prov" onmouseover="overDetail3(this,419,'subArea1_',areas);">
                        西藏</a></dd>
            </dl>
            <dl>
                <dt>其它：</dt>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_455" value="香港|455|0" onclick="this.checked=!this.checked;" />香港</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_456" value="澳门|456|0" onclick="this.checked=!this.checked;" />澳门</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_457" value="台湾|457|0" onclick="this.checked=!this.checked;" />台湾</a></dd>
                <dd>
                    <a href="javascript:void(0);" onclick="chooseAreaInput(this);">
                        <input type="checkbox" id="area_458" value="国外|458|0" onclick="this.checked=!this.checked;" />国外</a></dd>
            </dl>
        </div>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>
</div>
