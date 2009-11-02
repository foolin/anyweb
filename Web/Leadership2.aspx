<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership2.aspx.cs" Inherits="Leadership2" Title="领导分工" %>
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
                        <h3 style="width:100%;text-align:center;">人事行政科科长岗位职责</h3>
                        <p>一、	在社主任的领导下，负责社人事行政方面的工作。</p>
                        <p>二、	贯彻执行党和国家的路线方针政策和各项人事劳动政策法规。</p>
                        <p>三、	建立健全社的各项规章制度并按章执行，并根据执行的情况及时反馈调整及修改。</p>
                        <p>四、	深入基层，关心职工的生活，了解职工的思想动态，及时反映职工的意见、传达领导的意图。</p>
                        <p>五、	关心退休职工，热情耐心地做好日常管理及退休人员社会化管理工作，协助退休职工尤其是孤寡退休人员解决实际困难。</p>
                        <p>六、	负责招聘、续订合同、晋升、调整、解约、办理退休、考核、工资福利、计划生育等与职工有关的具体工作。</p>
                        <p>七、	负责办理企业社会保险缴交及年度调整方案的制订和落实；负责劳动年审、社保年审以及劳资季度报表、年度报表的上报工作；负责企业住房公积金的年度调整工作。</p>
                        <p>八、	熟悉档案管理的规定和要求，做好职工档案的收集整理制作保管工作，做好退休职工档案移交工作。</p>
                        <p>九、	负责社文件的传阅、收集、起草、整理、归档、保存工作。负责社务委员会会议记录，办公用品的采购管理发放工作。</p>
                        <p>十、	组织落实对退休及在职职工的日常慰问及各大节日慰问工作。</p>
                        <p>十一、认真学习，努力提高业务和管理水平，大胆提出合理化建议。</p>
                        <p>十二、负责社部意见及建议箱的管理，及时收集信息并向领导反映。</p>
                        <p>十三、配合好各科室开展工作，积极主动不推诿，营造和谐工作氛围。</p>
                        <p>十四、及时完成领导交办的其他工作。</p>

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

