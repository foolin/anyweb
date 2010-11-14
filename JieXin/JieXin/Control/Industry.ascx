<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Industry.ascx.cs" Inherits="Control_Industry" %>
<div class="choIndustry" id="ChooseIndustry">
    <div class="top">
        <i class="iTit">请选择行业</i> <span class="topRight white"><a href="javascript:void(0);"
            onclick="closeWindow('ChooseIndustry')">
            <img src="/images/icon_close.gif" width="15" height="15" /></a> </span>
    </div>
    <div class="con gray">
        <ul id="hylist_1">
            <li><a href="javascript:void(0);" onclick="AreaName(this,1);">计算机软件</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,2);">计算机硬件</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,3);">计算机服务(系统、数据服务，维修)</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,4);">通信/电信/网络设备</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,5);">通信/电信运营、增值服务</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,6);">互联网/电子商务</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,7);">网络游戏</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,8);">电子技术/半导体/集成电路</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,9);">仪器仪表/工业自动化</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,10);">会计/审计</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,11);">金融/投资/证券</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,12);">银行</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,13);">保险</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,14);">贸易/进出口</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,15);">批发/零售</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,16);">快速消费品(食品,饮料,化妆品)</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,17);">服装/纺织/皮革</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,18);">家具/家电/工艺品/玩具/珠宝</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,19);">办公用品及设备</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,20);">机械/设备/重工</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,21);">汽车及零配件</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,22);">制药/生物工程</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,23);">医疗/护理/保健/卫生</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,24);">医疗设备/器械</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,25);">广告</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,26);">公关/市场推广/会展</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,27);">影视/媒体/艺术</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,28);">文字媒体/出版</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,29);">印刷/包装/造纸</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,30);">房地产开发</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,31);">建筑/建材/工程</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,32);">家居/室内设计/装潢</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,33);">物业管理/商业中心</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,34);">中介服务</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,35);">专业服务(咨询，人力资源)</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,36);">外包服务</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,37);">检测，认证</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,38);">法律</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,39);">教育/培训</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,40);">学术/科研</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,41);">餐饮业</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,42);">酒店/旅游</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,43);">娱乐/休闲/体育</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,44);">美容/保健</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,45);">生活服务</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,46);">交通/运输/物流</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,47);">航天/航空</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,48);">石油/化工/矿产/地质</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,49);">采掘业/冶炼</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,50);">电力/水利</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,51);">原材料和加工</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,52);">政府</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,53);">非盈利机构</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,54);">环保</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,55);">农业/渔业/林业</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,56);">多元化业务集团公司</a></li>
            <li><a href="javascript:void(0);" onclick="AreaName(this,57);">其他行业</a></li>
        </ul>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>
</div>
