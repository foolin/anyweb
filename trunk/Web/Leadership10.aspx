<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership10.aspx.cs" Inherits="Leadership10" Title="领导分工" %>
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
                        <h3 style="width:100%;text-align:center;">防洪物资仓篱竹仓仓管员岗位职责</h3>
                        <p>一、	在防洪物资仓篱竹仓经理的领导下，负责防洪物资仓篱竹仓物资管理的工作。</p>
                        <p>二、	负责防洪物资及篱竹的登记入仓、销售、领出、仓内物资的库存、月结清点等工作。</p>
                        <p>三、	对仓内物资进行定期检查以保证物资的完好率，并及时向经理汇报储备的情况，提交需补充物资的清单。</p>
                        <p>四、	负责日常的值班，做好仓内的清洁卫生工作，做好防霉、防虫、防盗、防火的工作。</p>
                        <p>五、	积极配合好防汛期，防洪物资采购、调配、运输等工作。</p>
                        <p>六、	积极配合好篱竹销售旺季的采购、调配、运输等工作。</p>
                        <p>七、	完成领导交办的其他工作。</p>
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
