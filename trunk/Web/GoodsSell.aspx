<%@ Page Language="C#" MasterPageFile="~/Web.master" AutoEventWireup="true" CodeFile="Company.aspx.cs" Inherits="Company" Title="商品销售" %>

<%@ Register Src="Controls/CompanyNav.ascx" TagName="CompanyNav" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="location">您的位置： <a href="Index.aspx">首页</a> → 商品销售</div>
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
                        商品销售
                    </h3> 
                    <div class="art-info"> 
                        [字体： <a href="javascript:fontZoomMax()">大</a> <a href="javascript:fontZoomMid()">中</a> <a href="javascript:fontZoomMin()">小</a> ] &nbsp;[<a href="javascript:window.print()">打印</a> ] &nbsp;[<a href="javascript:window.close()">关闭</a>]
                        <script language="javascript" type="text/javascript" src="/JS/fontzoom.js"></script>
                    </div> 
                    <!-- art-info end --> 
                    <div class="art-content" id="art-content"> 
                        
		                <p>信息时报讯 高校开学，“导生”成了迎新队伍最为活跃的角色。目前，广州大学的“导生”要竞争才能上岗，可谓十里挑一。</p> 
		                <p>导生成新生指路人</p> 
		                <p>“师兄，旅游专业是不是只能做导游？”“师姐，会计是不是要考很多证？”开学第一天，就有新生迫不及待地发问了。此时，最忙碌的莫过于“导生”了。“导生”，就是对刚入学的新生进行熟悉大学生活和学习的教育的高年级学生，有些高校称为“助班”或者“班导”。记者看到，“导生”不但要为新生报到提供各种服务，还要负责解答学生的各种问题。“导生师兄是我来到学校后接触的第一个师兄，我找不到宿舍，他马上就赶过来，还热情地帮我提东西、找宿舍，他真好！”来自韶关的小语感动地说。据介绍，广州大学自2005年开始全面实施“导生”工作制度，该校现有“导生”320人.</p> 
		                <p>导生也要竞争上岗</p> 
		                <p>据悉，在广州大学今年的“导生”选拔中，一些学院的选拔工作渐趋激烈。据该校人文学院党委副书记李芬介绍，今年学院有200多人报名导生，经过投简历、演讲、场景模拟考察等一系列环节的筛选，最终确定了22人，竞争非常激烈。“竞争激烈，责任重大啊！想到可以帮助新生，自己又可以得到锻炼，再难我们也要争取啦！”“导生”郑礼军说。</p> 
		                <p>为了选拨优秀人才，许多学院对“导生”的要求很高，如学习成绩达到良好以上；学生党员、院系优秀学生干部以及在某些方面有特长的高年级学生优先考虑，还设置了多道环节考验报名者。</p> 
		                <p>据悉，“导生”一般由本专业的高年级学生担任。广州大学新闻与传播学院要求新生每班必须有2个“导生”，学院又额外增加了2个“导生”。而广州大学商学院坚持“导生”由三年级学生担任，对于二年级学生，一般是鼓励其担任导生助理，协助导生各项事务。“大二的刚从大一升上来，专业知识、生活学习经历还不够成熟，所以还是以大三学生为主。”商学院学工办主任孟强说。</p> 
		                <p>（消息来源：信息时报 2009、9、13、A3版? 编发：欧阳琳）<br /></p> 
                 
                    </div> 
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


