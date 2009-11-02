<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership11.aspx.cs" Inherits="Leadership11" Title="领导分工" %>
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
                        <h3 style="width:100%;text-align:center;">经理的岗位职责</h3>
                        <p>一、	经理是企业的法定代表人，主持公司的全面工作。</p>
                        <p>二、	贯彻执行党和国家的各项方针、政策、法令、法规和上级的指示、规定。严格按照企业法的要求领导各项工作。对投资人负责。</p>
                        <p>三、	负责制订年度拓展计划，部署各阶段的工作，并督导贯彻落实。</p>
                        <p>四、	负责企业业务的开拓、管理、跟踪服务的监督和落实。</p>
                        <p>五、	定期向投资人汇报工作进展。重大问题及时向投资从请示、汇报。</p>
                        <p>六、	负责制订、完善并严格执行企业管理的规章制度，强化企业管理。</p>
                        <p>七、	掌握市场信息，多与同行交流与学习，努力开展业务并拓宽发展的思路。</p>
                        <p>八、	严格执行财务管理制度和规定，审核和严格管理现有资金和财务开支，努力增收节支。</p>
                        <p>九、	审核和签署对外合同、协议，审核部门计划、请示。</p>
                        <p>十、	注重学习和综合素质的提高，努力实现企业的经营效益与社会效应和谐发展。</p>
                        <p>十一、	及时完成上级领导交办的其他工作。</p>
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

