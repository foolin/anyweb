<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership12.aspx.cs" Inherits="Leadership12" Title="领导分工" %>
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
                        <h3 style="width:100%;text-align:center;">人事专员岗位职责</h3>
                        <p>一、	在经理的领导下，负责具体执行公司对外接洽、代理业务办理、跟踪服务等工作。</p>
                        <p>二、	贯彻执行党和国家的路线方针政策和各项劳动政策法规。</p>
                        <p>三、	负责公司合同制订及修改。</p>
                        <p>四、	负责公司计划的具体落实。</p>
                        <p>五、	负责业务的拓展、客户的维护和服务、信息反馈，资料的收集、整理、保管、归档的工作。</p>
                        <p>六、	熟悉并跟踪学习国家和地方的劳动政策法规，努力提高业务水平，为客户提供经济有效的方案。</p>
                        <p>七、	与客户保持紧密的联系，每月至少进行一次电话访谈，跟踪工作进度。每两个月至少下企业一次，了解情况反馈信息，并做好书面记录。</p>
                        <p>八、	及时处理客户要求，在五个工作日内给予客户书面处理意见。重大问题在十个工作日内完成。</p>
                        <p>九、	定期向主管领导汇报工作，并大胆提出合理化建议。</p>
                        <p>十、	负责公司文件的传阅、收集、起草、整理、归档、保存工作。</p>
                        <p>十一、及时完成领导交办的其他工作。</p>
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

