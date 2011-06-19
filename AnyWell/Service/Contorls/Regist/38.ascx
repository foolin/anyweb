<%@ Control Language="C#" AutoEventWireup="true" CodeFile="38.ascx.cs" Inherits="Contorls_Regist_38" %>
<h2 class="tit lblue">
    Visitor Pre-Registration</h2>
<div class="blank5px">
</div>
<p>
    <img src="/images/img_pro_4.png" width="330" height="23" /></p>
<div class="blank10px">
</div>
<div class="conBox lh18">
    <strong>Pre-registration Confirmation</strong><br />
    <p class="lh24 lblue">
        <strong>Dear <%=bean.fdRegiAppellation == 1 ? "Mr." : bean.fdRegiAppellation == 2 ? "Mrs." : bean.fdRegiAppellation == 3 ? "Miss." : "Ms."%> <%=bean.fdRegiName %> <%=bean.fdRegiSurname %>,</strong></p>
    <p>
        Thank you for your registration to visit China International Exposition for Household
        Electrical Appliances 2011.</p>
    <p>
        Deadline for pre-registration is 18:00 pm, 14th Oct. 2011.
    </p>
</div>
<div class="blank10px">
</div>
<div class="conBox lh18">
    <p class="lblue lh24">
        <strong>Your details:</strong></p>
    <p>
        <%=bean.fdRegiAppellation == 1 ? "Mr." : bean.fdRegiAppellation == 2 ? "Mrs." : bean.fdRegiAppellation == 3 ? "Miss." : "Ms."%> <%=bean.fdRegiName %> <%=bean.fdRegiSurname %><br />
        <%=bean.fdRegiCompany %><br />
        <%=bean.fdRegiPosition %><br />
        <%=bean.fdRegiAddress %><br />
        <%=bean.fdRegiPost %><br />
        <%=getCountry()%>
    </p>
    <p class="blank5px">
    </p>
    <p class="fb">
        Your registration number is: <%=83000000 + bean.fdRegiID%></p>
    <p>
        <strong>
            <img src="/Service/GetBandCode.aspx?code=<%=83000000 + bean.fdRegiID %>" height='50'></strong></p>
    <p class="blank5px">
    </p>
</div>
<div class="blank10px">
</div>
<div class="conBox lh18">
    <p class="lblue lh24">
        <strong>Opening hours:</strong></p>
    <p>
        17-19 October 9:00 am to 17:00 pm (Monday to Wednesday)</p>
    <p>
        20 October 9:00 am to 15:00 pm (Thursday)
    </p>
    <p class="red">
        (Visitor registration will close 30 minutes before show closing time)</p>
    <p class="blank10px">
    </p>
    <p>
        To ensure a smooth registration process, please print out this confirmation letter
        and bring along this to the visitor pre-registration counter in exchange for your
        visitor badge.
    </p>
</div>
<div class="blank10px">
</div>
<div class="conBox lh18">
    <p class="lblue lh24">
        <strong>The visitor pre-registration counter is located at:</strong></p>
    <p>
        Foyer, Hall 1</p>
    <p>
        Shunde Exhibition Centre,</p>
    <p>
        Caihong Road, Daliang, Shunde</p>
    <p>
        Guangdong, PR China</p>
    <p class="blank10px">
    </p>
    <p>
        We'll provide shuttle bus service during the show dates. For more travel information,
        please visit our official <u class="lblue"><a href="http://www.shundeexpo.com/" class="line">
            website</a></u>.</p>
</div>
<div class="blank10px">
</div>
<p class="lh20 orange">
    <strong>We look forward to welcoming you at China Shunde International Exposition for
        Household Electrical Appliances 2011!</strong></p>
