<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership3.aspx.cs" Inherits="Leadership3" Title="领导分工" %>
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
                        <h3 style="width:100%;text-align:center;">人事行政科副科长岗位职责</h3>
                        <p>一、	在社主任的领导下，负责社人事行政科物业方面的工作。</p>
                        <p>二、	熟悉物业租赁等方面的政策法规，认真贯彻执行物业租赁、管理、维修的政策、法规、条例及相关规定。</p>
                        <p>三、	组织落实租赁合同的起草、洽谈、整理、归档及管理等工作。</p>
                        <p>四、	每二个月（突发事件及节前检查除外）组织定期或不定期下店检查、沟通，及时解决隐患和存在问题，保持与租户进行良好沟通。掌握市场信息、动态，租户的信息和要求，提前为续约和招租提出合理可行的建议。</p>
                        <p>五、	负责组织起草门店维修、装修、改建等的可行性报告并对实施过程进行管理和监督。</p>
                        <p>六、	负责组织落实办公室及龙口东市场与水电相关的业务及维修；尽可能为租户提供水电方面的协助。</p>
                        <p>七、	负责社现有财产的登记和管理，车辆的管理和调度工作。</p>
                        <p>八、	负责房屋产权证照、资料的保存工作。负责营业执照、代码证的申领、年审、变更的工作。</p>
                        <p>九、	完善社物业租赁的规章制度。</p>
                        <p>十、	负责按月上报社的统计资料，填写统计报表。</p>
                        <p>十一、	协助办公室的管理工作。</p>
                        <p>十二、	协助篱竹供应及保管，防洪物资的供应。</p>
                        <p>十三、	认真学习，努力提高业务和管理水平，大胆提出物业管理，物业开发方面的合理化建议。</p>
                        <p>十四、	及时完成领导交办的其他工作。</p>

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


