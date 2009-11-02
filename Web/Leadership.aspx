<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Leadership.aspx.cs" Inherits="Leadership" Title="领导分工 " %>

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
                        <h3 style="width:100%;text-align:center;">社主任的岗位职责</h3>
                        <p>一、	社主任是企业的法定代表人，兼任党支部书记，主持全面工作。</p>
                        <p>二、	贯彻执行党和国家的各项方针、政策、法令、法规和上级的指示、规定。严格按照企业法的要求领导各项工作。对上级主管负责。</p>
                        <p>三、	按照上级主管部门的要求，根据本社实际情况，制订年度计划、发展规划，部署各阶段的中心工作，并督导贯彻落实。执行《社务管理委员会议事规则》，主持社务委员会会议。</p>
                        <p>四、	定期向上级主管领导汇报工作。重大问题及时向上级请示、报告。</p>
                        <p>五、	主持和召开职工会议，通报重大社务工作，发扬民主，集思广益，注重听取职工意见，营造企业和谐的工作氛围。</p>
                        <p>六、	制定、完善和严格执行企业管理的规章制度，强化企业管理。</p>
                        <p>七、	调查研究、掌握信息，努力挖掘企业发展的潜力，寻找新的经济增长点及合作开发项目，稳步推进供销社经济的可持续发展。</p>
                        <p>八、	切实抓好社有物业、龙口东市场的经营管理工作，保证企业支柱经济的良性发展。大力拓宽企业的经营渠道和业务范围，开拓创新。</p>
                        <p>九、	执行区联社财务管理制度和规定，审核和严格管理现有资金和财务开支，努力增收节支。</p>
                        <p>十、	审核和签署对外合同、协议，审核各部门计划、请示。</p>
                        <p>十一、重视人才的培养和使用，关心职工的生活，努力提高职工福利，充分调动和发挥职工的积极性，提高职工队伍的综合素质，努力建造高效敬业的员工队伍。</p>
                        <p>十二、加强党支部建设，发挥党支部战斗堡垒作用和党员的先锋模范作用。</p>
                        <p>十三、及时完成上级领导交办的其他工作。</p>               
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

