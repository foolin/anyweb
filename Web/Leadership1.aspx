<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership1.aspx.cs" Inherits="Leadership1" Title="领导分工" %>
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
                        <h3 style="width:100%;text-align:center;">社副主任的岗位职责</h3>
                        <p>一、	坚决贯彻执行党和国家各项方针政策法律法规和上级的批示、规定。</p>
                        <p>二、	按班子分工，组织和处理分管部门和事项的工作，向主任负责。</p>
                        <p>三、	全面负责企业的消防、卫生、安全生产、防洪物资储备、环保等工作。</p>
                        <p>四、	兼任社工会主席，分管人事行政、共青团、妇委等工作，。</p>
                        <p>五、	熟悉和掌握分管部门和事项的政策法规，组织拟定专项计划、总结，协助主任决策和组织完成全局性的重要工作任务。</p>
                        <p>六、	协助主任协调平衡部门之间的工作关系，加强协作配合，充分发挥各部门的职能作用，调动其积极性，提高办事效率和工作质量。</p>
                        <p>七、	多与职工沟通，了解职工所需及思想变动及时反映，协助社主任更好地开展工作。</p>
                        <p>八、	注意收集分析信息，提出改进工作的合理化建议，依照班子工作部署制订具体实施措施，并监督、检查和反馈各部门各事项的落实情况。</p>
                        <p>九、	及时完成班子交办的其它工作。</p>
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
