<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership4.aspx.cs" Inherits="Leadership4" Title="领导分工" %>
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
                        <h3 style="width:100%;text-align:center;">人事行政科业务主管岗位职责</h3>
                        <p>一、	在人事行政科副科长的直接领导下，负责社人事行政科物业方面的具体工作。</p>
                        <p>二、	熟悉并掌握物业租赁、管理、维修方面的政策法规，及时了解新的政策及相关规定，为领导传递信息并提供建议。</p>
                        <p>三、	具体负责所分管门店的租赁合同的起草、洽谈、登记、执行、变更，合同执行过程中的跟踪服务和管理：租金追缴、增减租的建议和洽谈、日常的维修，安全防火、防盗的检查、督促和整改等工作，合同期满的信息反馈和落实：续约、转租、重新招租的工作。</p>
                        <p>四、	每二个月（突发事件及节前检查除外）定期或不定期下所分管的门店进行检查、沟通，排除隐患，规范管理。掌握市场信息、动态，租户的信息和要求，保持与租户进行良好沟通，为资产的保值增效提供意见。</p>
                        <p>五、	根据分工落实办公室和龙口东市场水电方面的业务及维修；尽可能为租户提供水电方面的协助。</p>
                        <p>六、	加强学习，开拓创新，为完善社的物业租赁管理制度多提出合理化的意见和建议。</p>
                        <p>七、	做好人事行政科安排的其他具体工作。</p>
                        <p>八、	及时完成领导交办的其他工作。</p>


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

