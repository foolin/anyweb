<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership8.aspx.cs" Inherits="Leadership8" Title="领导分工" %>
<%@ Register Src="Controls/CompanyNav.ascx" TagName="CompanyNav" TagPrefix="uc1" %>
<%@ Register Src="~/Controls/ShipList.ascx" TagName="Ship" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main">
        <div class="container">
            <div class="column-sider">
                <!--栏目-->
                    <uc1:companynav id="CompanyNav1" runat="server"></uc1:companynav>
                <!--栏目-->
            </div>
            <div class="column-main">
                <div class="article"> 
                    <h3 class="art-title"> 
                        领导分工 
                    </h3> 
                    <div class="art-info"> 
                        [字体： <a href="javascript:fontZoomMax()">大</a> <a href="javascript:fontZoomMid()">中</a> <a href="javascript:fontZoomMin()">小</a> ] &nbsp;[<a href="javascript:window.print()">打印</a> ] &nbsp;[<a href="javascript:window.close()">关闭</a>]
                        <script language="javascript" type="text/javascript" src="/JS/fontzoom.js"></script>
                    </div> 
                    <!-- art-info end --> 
                    <div class="art-content" id="art-content"> 
                        <h3 style="width:100%;text-align:center;">财务科出纳岗位职责</h3>
                        <p>一、	在财务科科长的直接领导下，负责社财务科出纳的工作。</p>
                        <p>二、	熟悉并遵守国家财务制度和政策法规。</p>
                        <p>三、	负责现金日记帐、银行存款日记帐登记工作，做到日清月结。</p>
                        <p>四、	负责按时收取租金、及时进行费用报销、工资奖金的发放、水电费的缴交和收取等与现金收支和银行转帐有关的工作。</p>
                        <p>五、	负责保管现金、空白支票、银行印鉴卡等。按规定对超出备用额的现金送行，不得超额留存现金。</p>
                        <p>六、	负责管理银行帐户，办理银行结算业务，月终及时对帐，并根据需要编制银行存款余额调节表。</p>
                        <p>七、	加强货币资金的管理，严格执行有关现金管理和银行帐户管理的法规，防止资金流失和帐户被盗用。</p>
                        <p>八、	加强学习，不断提高业务技能，大胆提出合理化建议。</p>
                        <p>九、	严格遵守财务制度纪律，保守财务秘密。</p>
                        <p>十、	负责本单位的住房公积金的月缴及人员变动的更改调整工作。</p>
                        <p>十一、	及时完成领导交办的其他工作。</p>
                    </div> 
                    <uc1:Ship ID="ship1" runat="server" />
                    <!-- art-content end --> 
                </div> 
                <!-- article end --> 
             </div>
            <!-- column-main end -->
        </div>
        <!--container end -->
    </div>
    <!-- main end -->
</asp:Content>

