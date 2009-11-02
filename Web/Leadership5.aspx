<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership5.aspx.cs" Inherits="Leadership5" Title="领导分工" %>
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
                        <h3 style="width:100%;text-align:center;">炊事员及值班员岗位职责</h3>
                        <p>一、	工作上服从人事行政科的领导和调配。</p>
                        <p>二、	负责根据每天的就餐人员合理采购和搭配，在中午十一时四十五分前提供安全卫生的午餐。</p>
                        <p>三、	做好用餐食品的清洗工作，搞好伙房的清洁卫生，各种物品摆放整齐。</p>
                        <p>四、	负责办公室非办公时间的值班工作，杜绝无关人员进入办公室，做好办公室的防火防盗工作。</p>
                        <p>五、	负责办公室公共场所、主任室、会议室的日常保洁工作。</p>
                        <p>六、	负责办公室的花卉管理及开水供应，每天夹好当天的报纸。</p>
                        <p>七、	保持通道、一至三楼楼梯的畅通和清洁，每二周洗一次楼梯。</p>
                        <p>八、	勤俭节约，注意用水用电用气的安全和节约。</p>
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

