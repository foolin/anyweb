<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership7.aspx.cs" Inherits="Leadership7" Title="领导分工" %>
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
                        <h3 style="width:100%;text-align:center;">财务科科长岗位职责</h3>
                        <p>一、	在社主任的领导下，全面负责社财务方面的工作。</p>
                        <p>二、	根据国家财务制度和财经法规，在区联社财务科指导下，结合本社实际情况制定适用的财务管理办法和财务人员的管理制度。</p>
                        <p>三、	围绕社的发展规划和年度计划，编制社财务计划和费用预算。</p>
                        <p>四、	负责社主办会计的工作，组织好租金的收取与费用支出管理，组织完成好上级部门下达的租金收取、消化历史包袱、管理费上交等任务，按要求认真审核好各项开支，妥善保管好财务会计的档案资料。</p>
                        <p>五、	负责社财会人员的业务培训和考核监督工作。</p>
                        <p>六、	熟悉社资金的来源和流向比例，合理调控资金的分布，以优化资金，提高资金效益。</p>
                        <p>七、	定期向社主任汇报社经济运作情况，提出合理化建议，为社的经营发展提供参考依据。</p>
                        <p>八、	定期检查财务计划，费用预算执行情况，在上级部门和领导的指导下，根据实际情况进行有效的修订，努力达到利润最大化。</p>
                        <p>九、	注重信息的收集和交流，掌握最新的财会法规和规定，注重吸取同行的优秀经验，为社的可持续发展出谋划策。</p>
                        <p>十、	严格遵守财务制度纪律，保守财务秘密。</p>
                        <p>十一、	与各部门之间遇事积极沟通，相互配合，相互帮助，明确职责，按章办事。</p>
                        <p>十二、	及时完成领导交办的其他工作。</p>

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

