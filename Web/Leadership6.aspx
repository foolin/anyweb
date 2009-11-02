<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership6.aspx.cs" Inherits="Leadership6" Title="领导分工" %>
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
                        <h3 style="width:100%;text-align:center;">驾驶员岗位职责</h3>
                        <p>一、	学习执行交通法规，遵守交通规则和司机守则。</p>
                        <p>二、	注意安全行车、文明行车。</p>
                        <p>三、	服从安排、按时出车。</p>
                        <p>四、	做好车辆安全检查、保养和清洁卫生工作，防止损坏、失窃，发现问题及时报告。保证车辆处于良好备用状态。</p>
                        <p>五、	认真参加驾驶员安全学习，努力提高安全行车意识。</p>
                        <p>六、	协助各部门办理相关事项。</p>
                        <p>七、	及时完成领导和车辆管理员交办的其他工作。</p>
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


