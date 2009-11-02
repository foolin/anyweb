<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership9.aspx.cs" Inherits="Leadership9" Title="领导分工" %>
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
                        <h3 style="width:100%;text-align:center;">防洪物资仓篱竹仓经理岗位职责</h3>
                        <p>一、	在社主任的领导下，全面负责防洪物资仓篱竹仓的工作。</p>
                        <p>二、	按照上级主管部门的要求及年度计划，制订防洪物资及篱竹的供应计划及实施方案。</p>
                        <p>三、	负责组织防洪物资的采购、保管、调度、供应等工作。</p>
                        <p>四、	负责组织防洪物资的定期检查、保证物资的完好率并及时补充物资。负责组织汛期物资持续供应及汛期的上堤检查和值班工作。</p>
                        <p>五、	负责组织篱竹的采购、供应、贮存、调度等工作。</p>
                        <p>六、	负责保证篱竹质量、供应及时，以满足农户的要求。</p>
                        <p>七、	负责防洪及篱竹仓的安全保卫，防火防盗工作。</p>
                        <p>八、	加强学习，努力提高工作效率和质量，并为社的发展多提合理化的建议。</p>
                        <p>九、	及时完成领导交办的其他工作。</p>

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

