<%@ Control Language="C#" AutoEventWireup="true" CodeFile="33.ascx.cs" Inherits="Contorls_Regist_33" %>
<h2 class="tit lblue">
    观众预登记</h2>
<div class="blank5px">
</div>
<p>
    <img src="/images/img_pro_4.png" width="330" height="23" /></p>
<div class="blank10px">
</div>
<div class="conBox lh18">
    <p class="lh24 lblue">
        <strong>尊敬的<%=bean.fdRegiSurname %> <%=bean.fdRegiName %> <%=bean.fdRegiAppellation == 1 ? "先生" : bean.fdRegiAppellation == 2 ? "小姐" : bean.fdRegiAppellation == 3 ? "女士" : "博士"%>，</strong></p>
    <p>
        恭喜您！您已成功预先登记为2011中国顺德国际家用电器博览会的专业观众！</p>
    <p>
        网上预登记截止日期为2011年10月14日下午18:00点。如您在2011年9月25日 18:00成功提交，我们将会把参展证寄到您所填地址（仅限中国大陆观众）。</p>
</div>
<div class="blank10px">
</div>
<div class="conBox lh18">
    <p class="lblue lh24">
        <strong>您的资料如下:</strong></p>
    <p>
        姓名称谓：<%=bean.fdRegiSurname %> <%=bean.fdRegiName %> <%=bean.fdRegiAppellation == 1 ? "先生" : bean.fdRegiAppellation == 2 ? "小姐" : bean.fdRegiAppellation == 3 ? "女士" : "博士"%></p>
    <p>
        公司：<%=bean.fdRegiCompany %></p>
    <p>
        职位：<%=bean.fdRegiPosition %></p>
    <p>
        地址：<%=bean.fdRegiAddress %></p>
    <p>
        邮政编码：<%=bean.fdRegiPost %></p>
    <p>
        国家/地区：<%=getCountry()%></p>
    <p class="blank5px">
    </p>
    <p>
        <strong>
            <img src="/Service/GetBandCode.aspx?code=<%=83000000 + bean.fdRegiID %>" height="50"></strong></p>
    <p class="blank5px">
    </p>
    <p>
        您的注册号码是： <%=83000000 + bean.fdRegiID%></p>
</div>
<div class="blank10px">
</div>
<div class="conBox lh18">
    <p class="lblue lh24">
        <strong>展会开放时间为：</strong></p>
    <p>
        2011年10月17 - 19日（周一 - 周三）：上午9点整–下午5点整</p>
    <p>
        2011年10月20日（周四）：上午9点整–下午3点整</p>
    <p>
        2011年9月25日18：00以后直至截止日期前登记的观众，请您携带打印好的此确认函（预登记成功页面），前往展会现场<strong>观众预登记柜台</strong>领取免费胸卡。</p>
</div>
<div class="blank10px">
</div>
<div class="conBox lh18">
    <p class="lblue lh24">
        <strong>"观众预登记柜台"位置：</strong></p>
    <p>
        1号馆序厅</p>
    <p>
        中国&#8226;顺德展览中心</p>
    <p>
        佛山市顺德区大良镇新城区彩虹路，</p>
    <p>
        为方便各地专业观众前往参观顺德家电展， 主办单位在将展会期间安排免费穿梭巴士至展馆。巴士时间表及酒店等其他旅行服务，请留意 <a href="http://www.shundeexpo.cn/"
            target="_blank" title="http://www.shundeexpo.cn/">www.shundeexpo.cn</a>的更新信息。
    </p>
    <p>
        &nbsp;</p>
</div>
<div class="blank10px">
</div>
<p class="lh24 orange">
    <strong>我们诚挚的期待您的到来！</strong></p>
<div class="blank120">
</div>
