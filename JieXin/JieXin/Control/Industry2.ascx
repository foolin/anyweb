<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Industry2.ascx.cs" Inherits="Control_Industry2" %>
<div class="choIndustry" id="ChooseIndustry2">
    <div class="top">
        <i class="iTit">请选择行业(您最多能选择5项)</i> <span class="topRight white">[<a href="javascript:void(0);"
            onclick="confirmDate();return false">确认</a>] </span>
    </div>
    <div class="con gray">
        <h3 class="green">
            已选行业</h3>
        <dl id="industry_choosed">
        </dl>
        <div class="dashLine">
        </div>
        <ul id="industry2_ul">
            <li title="计算机软件">
                <input type="checkbox" id="industry_1" value="计算机软件|1" />计算机软件</li>
            <li title="计算机硬件">
                <input type="checkbox" id="industry_2" value="计算机硬件|2" />计算机硬件</li>
            <li title="计算机服务(系统、数据服务，维修)">
                <input type="checkbox" id="industry_3" value="计算机服务(系统、数据服务，维修)|3" />计算机服务(系统、数据服务，维修)</li>
            <li title="通信/电信/网络设备">
                <input type="checkbox" id="industry_4" value="通信/电信/网络设备|4" />通信/电信/网络设备</li>
            <li title="通信/电信运营、增值服务">
                <input type="checkbox" id="industry_5" value="通信/电信运营、增值服务|5" />通信/电信运营、增值服务</li>
            <li title="互联网/电子商务">
                <input type="checkbox" id="industry_6" value="互联网/电子商务|6" />互联网/电子商务</li>
            <li title="网络游戏">
                <input type="checkbox" id="industry_7" value="网络游戏|7" />网络游戏</li>
            <li title="电子技术/半导体/集成电路">
                <input type="checkbox" id="industry_8" value="电子技术/半导体/集成电路|8" />电子技术/半导体/集成电路</li>
            <li title="仪器仪表/工业自动化">
                <input type="checkbox" id="industry_9" value="仪器仪表/工业自动化|9" />仪器仪表/工业自动化</li>
            <li title="会计/审计">
                <input type="checkbox" id="industry_10" value="会计/审计|10" />会计/审计</li>
            <li title="金融/投资/证券">
                <input type="checkbox" id="industry_11" value="金融/投资/证券|11" />金融/投资/证券</li>
            <li title="银行">
                <input type="checkbox" id="industry_12" value="银行|12" />银行</li>
            <li title="保险">
                <input type="checkbox" id="industry_13" value="保险|13" />保险</li>
            <li title="贸易/进出口">
                <input type="checkbox" id="industry_14" value="贸易/进出口|14" />贸易/进出口</li>
            <li title="批发/零售">
                <input type="checkbox" id="industry_15" value="批发/零售|15" />批发/零售</li>
            <li title="快速消费品(食品,饮料,化妆品)">
                <input type="checkbox" id="industry_16" value="快速消费品(食品,饮料,化妆品)|16" />快速消费品(食品,饮料,化妆品)</li>
            <li title="服装/纺织/皮革">
                <input type="checkbox" id="industry_17" value="服装/纺织/皮革|17" />服装/纺织/皮革</li>
            <li title="家具/家电/工艺品/玩具/珠宝">
                <input type="checkbox" id="industry_18" value="家具/家电/工艺品/玩具/珠宝|18" />家具/家电/工艺品/玩具/珠宝</li>
            <li title="办公用品及设备">
                <input type="checkbox" id="industry_19" value="办公用品及设备|19" />办公用品及设备</li>
            <li title="机械/设备/重工">
                <input type="checkbox" id="industry_20" value="机械/设备/重工|20" />机械/设备/重工</li>
            <li title="汽车及零配件">
                <input type="checkbox" id="industry_21" value="汽车及零配件|21" />汽车及零配件</li>
            <li title="制药/生物工程">
                <input type="checkbox" id="industry_22" value="制药/生物工程|22" />制药/生物工程</li>
            <li title="医疗/护理/保健/卫生">
                <input type="checkbox" id="industry_23" value="医疗/护理/保健/卫生|23" />医疗/护理/保健/卫生</li>
            <li title="医疗设备/器械">
                <input type="checkbox" id="industry_24" value="医疗设备/器械|24" />医疗设备/器械</li>
            <li title="广告">
                <input type="checkbox" id="industry_25" value="广告|25" />广告</li>
            <li title="公关/市场推广/会展">
                <input type="checkbox" id="industry_26" value="公关/市场推广/会展|26" />公关/市场推广/会展</li>
            <li title="影视/媒体/艺术">
                <input type="checkbox" id="industry_27" value="影视/媒体/艺术|27" />影视/媒体/艺术</li>
            <li title="文字媒体/出版">
                <input type="checkbox" id="industry_28" value="文字媒体/出版|28" />文字媒体/出版</li>
            <li title="印刷/包装/造纸">
                <input type="checkbox" id="industry_29" value="印刷/包装/造纸|29" />印刷/包装/造纸</li>
            <li title="房地产开发">
                <input type="checkbox" id="industry_30" value="房地产开发|30" />房地产开发</li>
            <li title="建筑/建材/工程">
                <input type="checkbox" id="industry_31" value="建筑/建材/工程|31" />建筑/建材/工程</li>
            <li title="家居/室内设计/装潢">
                <input type="checkbox" id="industry_32" value="家居/室内设计/装潢|32" />家居/室内设计/装潢</li>
            <li title="物业管理/商业中心">
                <input type="checkbox" id="industry_33" value="物业管理/商业中心|33" />物业管理/商业中心</li>
            <li title="中介服务">
                <input type="checkbox" id="industry_34" value="中介服务|34" />中介服务</li>
            <li title="专业服务(咨询，人力资源)">
                <input type="checkbox" id="industry_35" value="专业服务(咨询，人力资源)|35" />专业服务(咨询，人力资源)</li>
            <li title="外包服务">
                <input type="checkbox" id="industry_36" value="外包服务|36" />外包服务</li>
            <li title="检测，认证">
                <input type="checkbox" id="industry_37" value="检测，认证|37" />检测，认证</li>
            <li title="法律">
                <input type="checkbox" id="industry_38" value="法律|38" />法律</li>
            <li title="教育/培训">
                <input type="checkbox" id="industry_39" value="教育/培训|39" />教育/培训</li>
            <li title="学术/科研">
                <input type="checkbox" id="industry_40" value="学术/科研|40" />学术/科研</li>
            <li title="餐饮业">
                <input type="checkbox" id="industry_41" value="餐饮业|41" />餐饮业</li>
            <li title="酒店/旅游">
                <input type="checkbox" id="industry_42" value="酒店/旅游|42" />酒店/旅游</li>
            <li title="娱乐/休闲/体育">
                <input type="checkbox" id="industry_43" value="娱乐/休闲/体育|43" />娱乐/休闲/体育</li>
            <li title="美容/保健">
                <input type="checkbox" id="industry_44" value="美容/保健|44" />美容/保健</li>
            <li title="生活服务">
                <input type="checkbox" id="industry_45" value="生活服务|45" />生活服务</li>
            <li title="交通/运输/物流">
                <input type="checkbox" id="industry_46" value="交通/运输/物流|46" />交通/运输/物流</li>
            <li title="航天/航空">
                <input type="checkbox" id="industry_47" value="航天/航空|47" />航天/航空</li>
            <li title="石油/化工/矿产/地质">
                <input type="checkbox" id="industry_48" value="石油/化工/矿产/地质|48" />石油/化工/矿产/地质</li>
            <li title="采掘业/冶炼">
                <input type="checkbox" id="industry_49" value="采掘业/冶炼|49" />采掘业/冶炼</li>
            <li title="电力/水利">
                <input type="checkbox" id="industry_50" value="电力/水利|50" />电力/水利</li>
            <li title="原材料和加工">
                <input type="checkbox" id="industry_51" value="原材料和加工|51" />原材料和加工</li>
            <li title="政府">
                <input type="checkbox" id="industry_52" value="政府|52" />政府</li>
            <li title="非盈利机构">
                <input type="checkbox" id="industry_53" value="非盈利机构|53" />非盈利机构</li>
            <li title="环保">
                <input type="checkbox" id="industry_54" value="环保|54" />环保</li>
            <li title="农业/渔业/林业">
                <input type="checkbox" id="industry_55" value="农业/渔业/林业|55" />农业/渔业/林业</li>
            <li title="多元化业务集团公司">
                <input type="checkbox" id="industry_56" value="多元化业务集团公司|56" />多元化业务集团公司</li>
            <li title="其他行业">
                <input type="checkbox" id="industry_57" value="其他行业|57" />其他行业</li>
        </ul>
        <span class="blank5px"></span>
    </div>
    <div class="btm">
    </div>
</div>
