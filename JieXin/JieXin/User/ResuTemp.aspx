<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResuTemp.aspx.cs" Inherits="ResuTemp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" src="../js/jquery.js"></script>

    <script type="text/javascript" src="../js/form.js"></script>

    <script type="text/javascript" src="../js/resume.js"></script>

</head>
<body>
    <div>
        <table cellspacing="0" cellpadding="0" border="0" class="paragraph_title paragraph_title_mdf">
            <tbody>
                <tr>
                    <td valign="middle">
                        个人信息 <a name="BPI"></a>
                    </td>
                    <td align="right" valign="middle">
                        <img hspace="10" align="absmiddle" id="BPI_hidden" style="cursor: pointer;" onclick="showinfo('BPI');"
                            src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_shrink.gif">
                        <img hspace="10" align="absmiddle" id="BPI_show" style="cursor: pointer; display: none;"
                            onclick="showinfo('BPI');" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_spread.gif">
                    </td>
                </tr>
            </tbody>
        </table>
        <div id="BPI_info">
            <table cellspacing="0" cellpadding="0" border="0" class="weight780 weight780_mdf">
                <tbody>
                    <tr>
                        <td class="height10">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="col_name">
                            姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名
                        </td>
                        <td align="left" valign="top" class="weight195">
                            &nbsp;蔡壮茂
                        </td>
                        <td align="left" valign="top" class="col_name">
                            性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别
                        </td>
                        <td valign="top">
                            &nbsp;男
                        </td>
                        <td align="right">
                            <img style="cursor: pointer;" onclick="Bpi_edit();" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="col_name">
                            出生日期
                        </td>
                        <td valign="top">
                            1984年10月4日
                        </td>
                        <td align="left" valign="top" class="col_name">
                            工作年限
                        </td>
                        <td valign="top">
                            二年以上
                        </td>
                        <td align="center" valign="top" class="weight90 noborder" rowspan="4">
                            <img height="110" width="90" src="/cv/CV_Attach_Read.php?ReSumeID=69897533&amp;963151195&amp;AttachID=10591929">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="col_name">
                            证件类型
                        </td>
                        <td valign="top">
                            身份证
                        </td>
                        <td align="left" valign="top" class="col_name">
                            证件号
                        </td>
                        <td valign="top">
                            &nbsp;440582198410047435
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="col_name">
                            居住地
                        </td>
                        <td valign="top">
                            <span id="Location_id">&nbsp;广州-天河区</span>
                        </td>
                        <td align="left" valign="top" class="col_name">
                            Email
                        </td>
                        <td valign="top">
                            70785748@qq.com
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="col_name">
                            目前年薪
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left" valign="top" class="col_name">
                            手机号码
                        </td>
                        <td>
                            020-13631494997
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="col_name">
                            家庭电话
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left" valign="top" class="col_name">
                            公司电话
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" class="col_name">
                            求职状态
                        </td>
                        <td>
                            目前正在找工作
                        </td>
                        <td align="left" valign="top" class="col_name">
                            户&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;口
                        </td>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr id="resumeKeyLayer">
                        <td align="left" valign="top" class="col_name">
                            关键词
                        </td>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <table cellspacing="0" cellpadding="0" border="0" class="paragraph_title paragraph_title_mdf">
            <tbody>
                <tr>
                    <td valign="middle">
                        教育经历 <a name="EDU"></a>
                    </td>
                    <td align="right" valign="middle">
                        <img hspace="10" align="absmiddle" id="Edu_hidden" style="cursor: pointer;" onclick="showinfo('Edu');"
                            src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_shrink.gif">
                        <img hspace="10" align="absmiddle" id="Edu_show" style="cursor: pointer; display: none;"
                            onclick="showinfo('Edu');" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_spread.gif">
                    </td>
                </tr>
            </tbody>
        </table>
        <div id="Edu_info">
            <div id="Edu_edit">
                <span>
                    <div id="Edu_edit_57350784">
                        <table cellspacing="0" cellpadding="0" border="0" style="float: left;" class="weight780_mdf weight670">
                            <tbody>
                                <tr>
                                    <td align="left" valign="top" class="col_name">
                                        时&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;间
                                    </td>
                                    <td align="left" valign="top" class="edu_2">
                                        2004年9月 到2008年6月
                                    </td>
                                    <td valign="top" colspan="2" class="del_all">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col_name">
                                        学&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;校
                                    </td>
                                    <td valign="top" colspan="3">
                                        广州大学
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col_name">
                                        专&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;业
                                    </td>
                                    <td valign="top" colspan="3">
                                        软件工程
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col_name">
                                        学&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;历
                                    </td>
                                    <td valign="top" colspan="3">
                                        本科
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col_name">
                                        专业描述
                                    </td>
                                    <td valign="top" colspan="3">
                                        1、熟悉数据库系统功能开发，了解基本的性能优化技术<br>
                                        了解SQL优化方法，利用执行计划分析SQL性能损耗，为数据表添加索引、分区等。曾在商脉通由于数据量增大导致出现大量数据库连接超时的情况下进行全站优化，经过三个月的验证没再出现过类似情况。<br>
                                        2、具有.Net产品设计与开发经验<br>
                                        (1) 在校期间曾开发过人力资源招聘系统、深圳派出所暂住证管理系统、企业员工通讯录管理系统。<br>
                                        (2) 参与公司多个产品的开发与设计，工作范围较为全面，包括HTML、CSS、JAVASCRIPT、ASP.NET、数据库等均有涉及，完成速度快且代码质量较高。<br>
                                        3、熟悉使用各种软件工具，以及相关管理方法<br>
                                        (1)使用MQC软件进行BUG追踪管理。<br>
                                        (2)使用SVN和VSS管理代码版本。<br>
                                        4、具有良好的学习能力，有较强的责任心和抗压能力<br>
                                        (1)大四期间，为进入时代财富公司，通过一个月的ASP.NET学习,成功从C/S向B/S转型并通过面试，进入正式开发阶段。<br>
                                        (2)建设银行信用卡网站采用InterWoven TeamSite信息管理平台，经过一个多星期的学习，能顺利的使用Perl编写模版、CallOut和在线编辑器功能的开发。<br>
                                        (3)建设银行信用卡网站采用JSP+Spring+Hibernate+Strus进行开发，在从未接触过JSP的情况下，通过一个多星期的学习后，负责灵活度较高的热点调查模块，正式进入网站开发，并在规定时间内成功完成该模块。<br>
                                        5、具有较好的团队精神和沟通能力<br>
                                        曾带领团队(2名开发人员，1名文案/测试，1名技术支持)完成供销社门户网、机团销售网和香港高闻顾问门户网，期间负责了需求分析、数据库设计、系统架构设计、程序开发、服务器布署、维护等工作。
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col_name">
                                        海外学习经历
                                    </td>
                                    <td valign="top" colspan="3">
                                        否
                                        <input type="hidden" value="57350784" id="info_id" name="info_id">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <p>
                            <img style="cursor: pointer;" onclick="editinfo('Edu','57350784',1);" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                        </p>
                        <table cellspacing="0" cellpadding="0" border="0" class="linedot noborder weight700">
                            <tbody>
                                <tr>
                                    <td class="noborder">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </span>
            </div>
            <table cellspacing="0" cellpadding="0" border="0" class="weight780 weight780_mdf">
                <tbody>
                    <tr>
                        <td width="3%">
                        </td>
                        <td valign="top">
                            <img hspace="5" vspace="10" id="Edu_add" style="cursor: pointer;" onclick="addinfo('Edu');"
                                src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_addcontinue.gif">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div id="Student">
            <table cellspacing="0" cellpadding="0" border="0" class="paragraph_title paragraph_title_mdf">
                <tbody>
                    <tr>
                        <td valign="middle">
                            工作经验 <a name="WORK"></a>
                        </td>
                        <td align="right" valign="middle">
                            <img hspace="10" align="absmiddle" id="Work_hidden" style="cursor: pointer;" onclick="showinfo('Work');"
                                src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_shrink.gif">
                            <img hspace="10" align="absmiddle" id="Work_show" style="cursor: pointer; display: none;"
                                onclick="showinfo('Work');" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_spread.gif">
                        </td>
                    </tr>
                </tbody>
            </table>
            <div id="Work_info">
                <div id="Work_edit">
                    <span>
                        <div id="Work_edit_89964440">
                            <table cellspacing="0" cellpadding="0" border="0" style="float: left;" class="weight780 weight780_mdf weight670">
                                <tbody>
                                    <tr>
                                        <td align="left" valign="top" class="col_name">
                                            时&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;间
                                        </td>
                                        <td align="left" valign="top">
                                            2007年12月至今
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" class="col_name">
                                            公&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;司
                                        </td>
                                        <td valign="top">
                                            广州时代财富科技有限公司
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" class="col_name">
                                            公司性质
                                        </td>
                                        <td valign="top">
                                            民营公司
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" class="col_name">
                                            公司规模
                                        </td>
                                        <td valign="top">
                                            50-150人
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" class="col_name">
                                            行&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;业
                                        </td>
                                        <td valign="top">
                                            互联网/电子商务
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" class="col_name">
                                            部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;门
                                        </td>
                                        <td valign="top">
                                            技术研发部
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" class="col_name">
                                            职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;位
                                        </td>
                                        <td valign="top">
                                            互联网软件开发工程师
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" class="col_name">
                                            工作描述
                                        </td>
                                        <td valign="top" id="Cur_Val">
                                            1、个人博客系统“博易”的开发与维护
                                            <br>
                                            大型博客系统“博易”采用三层标准结构开发，降低系统复杂度，易于扩展并保证系统稳定、高效。 特色功能：系统采用模块化的静态技术，并可设置各个模块的数据更新周期，将服务器的资源消耗减到最低，并灵活利用控件化的编码方式调用公用显示页面，减少了对服务器空间的占用。
                                            <br>
                                            2、中小企业建站平台“商脉通”的开发与维护
                                            <br>
                                            商脉通是中国企业第二代平台智能建站平台，提供了普及版、标准版、增强版、豪华版四个版本，版本越高功能越多。特色功能：站内流量统计，提供时间段统计和报表呈现；模版定制：采用模版套用及首页模块定制，即使不懂建站的客户都能做出专业的网站；搜索引擎优化：让企业在各大搜索引擎中显示在竞争对手前面，省去推广费，获得更大的收益；企业博客系统：让全体员工都可以积极参与互动和管理，展示企业文化；非法关键字过滤：过滤企业用户发布内容中的非法关键字，避免由于个别网站导致整个服务器被上级关闭的风险；网上商城：集成网上销售系统，提供商品的展示。
                                            <br>
                                            3、中小企业建站平台“PAPS”的开发与维护
                                            <br>
                                            PAPS是商脉通的升级版，除了原有功能之外，优化了后台管理界面，具有更优秀的用户体验，并实现前台页面的拖拉定制，使其更加灵活。前台采用DIV+CSS，符合W3C标准。
                                            <br>
                                            4、富媒体内容管理系统“IBOX”的开发与维护
                                            <br>
                                            IBOX采用主系统+选件模式，面向对象及组件化的设计，易于扩展，并可快速实现不同应用的需求，如广告、调查、流量统计等。系统实现单一网站向集群网站升级，可以在同一系统下实现数百个子站点的管理，各分站独立运作，又可共享资源。特色功能：站点集群：真正的分布式、高安全、多站点内容；权限管理：按照用户管理、角色管理、群组管理实现权限的划分和应用；模版管理：可为每个栏目定制首页和内页模版，即方便保持全站风格统一，也能根据每个栏目的特点运用一些特色设计；静态发布：所有网站页面按目录发布成静态的HTML页面，极大减少数据库的读取次数，节省服务器资源，不易遭到黑客的攻击；元数据定义：通过元数据的定义，适用不同行业的扩展；工作流：利用工作流定义每个步骤的流程，大大增强了内容管理和权限的应用。
                                            <br>
                                            5、周边管理项目，如博易管理系统、商脉通代理商后台系统、商脉通内部管理系统等。
                                            <br>
                                            为方便代理商或内部员工的工作而开发的系统，如会员、企业、代理商、订单等管理的功能。
                                            <br>
                                            6、广佛都市网的开发
                                            <br>
                                            佛山综合信息门户(广佛都市网)主要实现佛山新闻门户网站的功能。特色功能：静态发布：稳定安全；通行证：实现门户与论坛的同步登陆；流量统计：提供时间段统计和报表呈现。
                                            <br>
                                            7、中国建设银行信用卡网站的开发
                                            <br>
                                            该系统通过信息管理平台InterWoven TeamSite进行内容管理和静态页面发布，并编写Perl程序实现模版、工作流等功能对平台进行扩展。如用户登陆、信用卡申请、内容搜索、热点调查、后台管理等需JSP程序支持的功能通过Spring+Hibernate+Strus的经典MVC三层架构实现。
                                            <br>
                                            8、广州天河沙河供销社门户网站的开发与维护
                                            <br>
                                            该系统主要展示广州天河沙河供销社的信息内容和上级的公告通知。通过三层结构和存储过程实现，系统更加安全、稳定，执行效率更高。
                                            <br>
                                            9、广州天河沙河供销社机团销售网的开发与维护
                                            <br>
                                            机团网主要对供销社的商品进行展示和宣传，使用户更加了解供销社的商品，为电子销售做好准备。
                                            <br>
                                            10、香港高闻顾问有限公司门户网站的开发与维护
                                            <br>
                                            高闻顾问有限公司门户网站主要提供成功案例的展示，引导潜在客户了解高闻，提高公司在行业的知名度和业务。
                                            <br>
                                            11、其它一些小型系统的开发，如天河政府网上投票系统、深圳暂住人口管理系统、建行理财工具包、IKown系统(类似百度知道)等。
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" class="col_name">
                                            海外工作经历
                                        </td>
                                        <td valign="top">
                                            否
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <p>
                                <img onclick="editinfo('Work','89964440',1);" style="cursor: pointer;" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                            </p>
                            <table cellspacing="0" cellpadding="0" border="0" class="linedot weight700">
                                <tbody>
                                    <tr>
                                        <td valign="top" class="noborder">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </span>
                </div>
                <table cellspacing="0" cellpadding="0" border="0" class="weight780 weight780_mdf">
                    <tbody>
                        <tr>
                            <td width="3%">
                            </td>
                            <td valign="top">
                                <img hspace="5" vspace="10" id="Work_add" style="cursor: pointer;" onclick="addinfo('Work');"
                                    src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_addcontinue.gif">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <table cellspacing="0" cellpadding="0" border="0" class="paragraph_title paragraph_title_mdf">
                <tbody>
                    <tr>
                        <td valign="middle">
                            求职意向 <a name="OTHER"></a>
                        </td>
                        <td align="right" valign="middle">
                            <img hspace="10" align="absmiddle" id="Other_hidden" style="cursor: pointer;" onclick="showinfo('Other');"
                                src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_shrink.gif">
                            <img hspace="10" align="absmiddle" id="Other_show" style="cursor: pointer; display: none;"
                                onclick="showinfo('Other');" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_spread.gif">
                        </td>
                    </tr>
                </tbody>
            </table>
            <div id="Other_info">
                <table cellspacing="0" cellpadding="0" border="0" align="left" style="float: left;"
                    class="weight780 weight780_mdf weight670">
                    <tbody>
                        <tr>
                            <td align="left" valign="top" class="col_name">
                                工作类型
                            </td>
                            <td align="left" valign="top">
                                全职
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" class="col_name">
                                地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;区
                            </td>
                            <td valign="top">
                                &nbsp;广州；汕头
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" class="col_name">
                                行&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;业
                            </td>
                            <td valign="top">
                                &nbsp;计算机软件；互联网/电子商务
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" class="col_name">
                                职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;能
                            </td>
                            <td valign="top">
                                &nbsp;互联网软件开发工程师；网站维护工程师；高级软件工程师；数据库工程师/管理员
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" class="col_name">
                                期望薪水
                            </td>
                            <td valign="top">
                                面议/月
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" class="col_name">
                                到岗时间
                            </td>
                            <td valign="top">
                                1-3个月
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" class="col_name">
                                自我评价
                            </td>
                            <td valign="top">
                                &nbsp;
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div>
                    <img style="cursor: pointer;" onclick="Other_edit();" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif"
                        valign="top" rowspan="2">
                </div>
            </div>
            <table cellspacing="0" cellpadding="0" border="0" class="paragraph_title paragraph_title_mdf">
                <tbody>
                    <tr>
                        <td valign="middle">
                            培训经历 <a name="TRA"></a>
                        </td>
                        <td align="right" valign="middle">
                            <img hspace="10" align="absmiddle" id="Tra_hidden" style="cursor: pointer;" onclick="showinfo('Tra');"
                                src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_shrink.gif">
                            <img hspace="10" align="absmiddle" id="Tra_show" style="cursor: pointer; display: none;"
                                onclick="showinfo('Tra');" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_spread.gif">
                        </td>
                    </tr>
                </tbody>
            </table>
            <div id="Tra_info">
                <div id="Tra_edit">
                    <span></span>
                </div>
                <table cellspacing="0" cellpadding="0" border="0" class="weight780 weight780_mdf">
                    <tbody>
                        <tr>
                            <td width="3%">
                            </td>
                            <td valign="top">
                                <img hspace="5" vspace="10" id="Tra_add" style="cursor: pointer;" onclick="addinfo('Tra');"
                                    src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_addcontinue.gif">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <table cellspacing="0" cellpadding="0" border="0" class="paragraph_title paragraph_title_mdf">
                <tbody>
                    <tr>
                        <td valign="middle">
                            语言能力 <a name="LAN"></a>
                        </td>
                        <td align="right" valign="middle">
                            <img hspace="10" align="absmiddle" id="Lan_hidden" style="cursor: pointer;" onclick="showinfo('Lan');"
                                src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_shrink.gif">
                            <img hspace="10" align="absmiddle" id="Lan_show" style="cursor: pointer; display: none;"
                                onclick="showinfo('Lan');" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_spread.gif">
                        </td>
                    </tr>
                </tbody>
            </table>
            <div id="Lan_info">
                <div id="Lan_edit">
                    <span>
                        <div id="Lan_edit_1">
                            <table cellspacing="0" cellpadding="0" border="0" style="float: left;" class="weight780 weight780_mdf weight670">
                                <tbody>
                                    <tr>
                                        <td align="left" valign="top" class="col_name">
                                            语言类别
                                        </td>
                                        <td align="left" valign="top" class="weight260">
                                            英语
                                        </td>
                                        <td align="left" class="col_name">
                                            掌握程度
                                        </td>
                                        <td valign="top">
                                            良好
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" class="col_name">
                                            读写能力
                                        </td>
                                        <td valign="top">
                                            良好
                                        </td>
                                        <td align="left" valign="top" class="col_name">
                                            听说能力
                                        </td>
                                        <td valign="top">
                                            一般
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <p>
                                <img onclick="editinfo('Lan','1',1);" style="cursor: pointer;" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                            </p>
                            <table cellspacing="0" cellpadding="0" border="0" class="linedot weight700">
                                <tbody>
                                    <tr>
                                        <td valign="top" class="noborder">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </span>
                </div>
                <table cellspacing="0" cellpadding="0" border="0" id="Lan_add" class="weight780 weight780_mdf">
                    <tbody>
                        <tr>
                            <td width="3%" class="height5">
                            </td>
                            <td valign="top">
                                <img hspace="5" vspace="10" style="cursor: pointer;" onclick="addinfo('Lan');" id="Lan_add"
                                    src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_addcontinue.gif">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="line02 line02_mdf">
                    &nbsp;</div>
                <div id="Language_info">
                    <table cellspacing="0" cellpadding="0" border="0" align="left" style="float: left;"
                        class="weight780 weight780_mdf weight670">
                        <tbody>
                            <tr>
                                <td align="left" valign="top" class="col_name">
                                    英语等级
                                </td>
                                <td align="left" valign="top" class="weight180">
                                    &nbsp;
                                </td>
                                <td align="left" valign="top" class="col_name weight60">
                                    TOEFL
                                </td>
                                <td align="left" valign="top" class="weight120">
                                    &nbsp;
                                </td>
                                <td align="left" valign="top" class="col_name weight60">
                                    GRE
                                </td>
                                <td align="left" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" class="col_name">
                                    日语等级
                                </td>
                                <td align="left" valign="top">
                                    &nbsp;
                                </td>
                                <td align="left" valign="top" class="col_name weight60">
                                    GMAT
                                </td>
                                <td align="left" valign="top">
                                    &nbsp;
                                </td>
                                <td align="left" valign="top" class="col_name weight60">
                                    IELTS
                                </td>
                                <td align="left" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div>
                        <img style="cursor: pointer;" onclick="Language_edit();" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                    </div>
                </div>
            </div>
            <table cellspacing="0" cellpadding="0" border="0" class="paragraph_title paragraph_title_mdf">
                <tbody>
                    <tr>
                        <td valign="middle">
                            附加信息 <a name="MISC"></a>
                        </td>
                        <td align="right" valign="middle">
                            <img hspace="10" align="absmiddle" id="MISC_hidden" style="cursor: pointer;" onclick="showinfo('MISC');"
                                src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_shrink.gif">
                            <img hspace="10" align="absmiddle" id="MISC_show" style="cursor: pointer; display: none;"
                                onclick="showinfo('MISC');" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_spread.gif">
                        </td>
                    </tr>
                </tbody>
            </table>
            <div id="MISC_info">
                <table cellspacing="0" cellpadding="0" border="0" class="rew_con_paragraph">
                    <tbody>
                        <tr>
                            <td valign="top">
                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                                    <tbody>
                                        <tr>
                                            <td align="left" class="subtitle title_blue">
                                                <strong style="padding-left: 35px;">·IT技能</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <div id="IT_edit">
                                                    <div id="IT_edit_14750788">
                                                        <table cellspacing="0" cellpadding="0" border="0" style="float: left;" class="weight780 weight780_mdf weight670">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" valign="top" class="col_name">
                                                                        技&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;能
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight180">
                                                                        Visual SourceSafe
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        使用时间
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight120">
                                                                        24月
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        掌握程度
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        熟练
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <p>
                                                            <img onclick="editinfo('IT','14750788',1);" style="cursor: pointer;" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                                                        </p>
                                                        <p style="clear: both;">
                                                        </p>
                                                    </div>
                                                    <div id="IT_edit_14750467">
                                                        <table cellspacing="0" cellpadding="0" border="0" style="float: left;" class="weight780 weight780_mdf weight670">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" valign="top" class="col_name">
                                                                        技&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;能
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight180">
                                                                        ASP.NET
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        使用时间
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight120">
                                                                        30月
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        掌握程度
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        熟练
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <p>
                                                            <img onclick="editinfo('IT','14750467',2);" style="cursor: pointer;" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                                                        </p>
                                                        <p style="clear: both;">
                                                        </p>
                                                    </div>
                                                    <div id="IT_edit_14750480">
                                                        <table cellspacing="0" cellpadding="0" border="0" style="float: left;" class="weight780 weight780_mdf weight670">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" valign="top" class="col_name">
                                                                        技&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;能
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight180">
                                                                        JSP
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        使用时间
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight120">
                                                                        3月
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        掌握程度
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        一般
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <p>
                                                            <img onclick="editinfo('IT','14750480',3);" style="cursor: pointer;" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                                                        </p>
                                                        <p style="clear: both;">
                                                        </p>
                                                    </div>
                                                    <div id="IT_edit_14750478">
                                                        <table cellspacing="0" cellpadding="0" border="0" style="float: left;" class="weight780 weight780_mdf weight670">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" valign="top" class="col_name">
                                                                        技&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;能
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight180">
                                                                        CSS
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        使用时间
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight120">
                                                                        30月
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        掌握程度
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        一般
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <p>
                                                            <img onclick="editinfo('IT','14750478',4);" style="cursor: pointer;" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                                                        </p>
                                                        <p style="clear: both;">
                                                        </p>
                                                    </div>
                                                    <div id="IT_edit_14750784">
                                                        <table cellspacing="0" cellpadding="0" border="0" style="float: left;" class="weight780 weight780_mdf weight670">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" valign="top" class="col_name">
                                                                        技&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;能
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight180">
                                                                        C#
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        使用时间
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight120">
                                                                        30月
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        掌握程度
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        熟练
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <p>
                                                            <img onclick="editinfo('IT','14750784',5);" style="cursor: pointer;" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                                                        </p>
                                                        <p style="clear: both;">
                                                        </p>
                                                    </div>
                                                    <div id="IT_edit_14750459">
                                                        <table cellspacing="0" cellpadding="0" border="0" style="float: left;" class="weight780 weight780_mdf weight670">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" valign="top" class="col_name">
                                                                        技&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;能
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight180">
                                                                        SQL Server
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        使用时间
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight120">
                                                                        48月
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        掌握程度
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        熟练
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <p>
                                                            <img onclick="editinfo('IT','14750459',6);" style="cursor: pointer;" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                                                        </p>
                                                        <p style="clear: both;">
                                                        </p>
                                                    </div>
                                                    <div id="IT_edit_14750766">
                                                        <table cellspacing="0" cellpadding="0" border="0" style="float: left;" class="weight780 weight780_mdf weight670">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" valign="top" class="col_name">
                                                                        技&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;能
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight180">
                                                                        Oracle
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        使用时间
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight120">
                                                                        6月
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        掌握程度
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        熟练
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <p>
                                                            <img onclick="editinfo('IT','14750766',7);" style="cursor: pointer;" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                                                        </p>
                                                        <p style="clear: both;">
                                                        </p>
                                                    </div>
                                                    <div id="IT_edit_14750473">
                                                        <table cellspacing="0" cellpadding="0" border="0" style="float: left;" class="weight780 weight780_mdf weight670">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" valign="top" class="col_name">
                                                                        技&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;能
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight180">
                                                                        JavaScript
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        使用时间
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight120">
                                                                        30月
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        掌握程度
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        熟练
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <p>
                                                            <img onclick="editinfo('IT','14750473',8);" style="cursor: pointer;" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                                                        </p>
                                                        <p style="clear: both;">
                                                        </p>
                                                    </div>
                                                    <div id="IT_edit_14750494">
                                                        <table cellspacing="0" cellpadding="0" border="0" style="float: left;" class="weight780 weight780_mdf weight670">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" valign="top" class="col_name">
                                                                        技&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;能
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight180">
                                                                        PERL
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        使用时间
                                                                    </td>
                                                                    <td align="left" valign="top" class="weight120">
                                                                        6月
                                                                    </td>
                                                                    <td align="left" valign="top" class="col_name weight60">
                                                                        掌握程度
                                                                    </td>
                                                                    <td align="left" valign="top">
                                                                        一般
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <p>
                                                            <img onclick="editinfo('IT','14750494',9);" style="cursor: pointer;" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                                                        </p>
                                                        <p style="clear: both;">
                                                        </p>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" border="0" style="float: left; margin-right: 20px;"
                    class="weight780 weight780_mdf weight670">
                    <tbody>
                        <tr>
                            <td width="3%">
                            </td>
                            <td valign="top">
                                <img hspace="5" vspace="10" id="IT_add" style="cursor: pointer;" onclick="addinfo('IT');"
                                    src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_addcontinue.gif">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="line02 line02_mdf">
                    &nbsp;</div>
                <table cellspacing="0" cellpadding="0" border="0" class="rew_con_paragraph">
                    <tbody>
                        <tr>
                            <td valign="top">
                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                                    <tbody>
                                        <tr>
                                            <td align="left" class="subtitle title_blue">
                                                <strong style="padding-left: 35px;">·项目经验</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <div id="Prj_edit">
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" border="0" class="weight780 weight780_mdf">
                    <tbody>
                        <tr>
                            <td width="3%">
                            </td>
                            <td valign="top">
                                <img hspace="5" vspace="10" id="Prj_add" style="cursor: pointer;" onclick="addinfo('Prj');"
                                    src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_addcontinue.gif">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="line02 line02_mdf">
                    &nbsp;</div>
                <table cellspacing="0" cellpadding="0" border="0" class="rew_con_paragraph">
                    <tbody>
                        <tr>
                            <td valign="top">
                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                                    <tbody>
                                        <tr>
                                            <td align="left" class="title_blue subtitle">
                                                <strong style="padding-left: 35px;">·证书</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <div id="Cert_edit">
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" border="0" class="weight780 weight780_mdf">
                    <tbody>
                        <tr>
                            <td width="3%">
                            </td>
                            <td valign="top">
                                <img hspace="5" vspace="10" id="Cert_add" style="cursor: pointer;" onclick="addinfo('Cert');"
                                    src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_addcontinue.gif">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="line02 line02_mdf">
                    &nbsp;</div>
                <table cellspacing="0" cellpadding="0" border="0" class="rew_con_paragraph">
                    <tbody>
                        <tr>
                            <td valign="top">
                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                                    <tbody>
                                        <tr>
                                            <td align="left" class="title_blue subtitle">
                                                <strong style="padding-left: 35px;">·附件</strong> <span>（所有附件总量为2M）</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <div id="Attach_edit">
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" border="0" class="weight780 weight780_mdf">
                    <tbody>
                        <tr>
                            <td width="3%">
                            </td>
                            <td valign="top">
                                <img hspace="5" vspace="10" id="Attach_add" style="cursor: pointer;" onclick="addinfo('Attach');"
                                    src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_addcontinue.gif">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="line02 line02_mdf">
                    &nbsp;</div>
                <table cellspacing="0" cellpadding="0" border="0" class="rew_con_paragraph">
                    <tbody>
                        <tr>
                            <td valign="top">
                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                                    <tbody>
                                        <tr>
                                            <td align="left" class="title_blue subtitle">
                                                <strong style="padding-left: 35px;">·高级人才附加信息</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <div id="Api_edit">
                                                    <table cellspacing="0" cellpadding="0" border="0" align="center" style="float: left;"
                                                        class="weight780 weight780_mdf weight670">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left" valign="top" class="col_name weight100">
                                                                    基本工资(税前)
                                                                </td>
                                                                <td align="left" valign="top" class="weight250">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top" class="col_name">
                                                                    年度奖金/佣金
                                                                </td>
                                                                <td align="left" valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" valign="top" class="col_name weight100">
                                                                    补贴/津贴
                                                                </td>
                                                                <td valign="top">
                                                                    &nbsp;
                                                                </td>
                                                                <td align="left" valign="top" class="col_name">
                                                                    股&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;票
                                                                </td>
                                                                <td valign="top">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <div>
                                                        <img style="cursor: pointer;" onclick="Api_edit();" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif">
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="line02 line02_mdf">
                    &nbsp;</div>
                <table cellspacing="0" cellpadding="0" border="0" class="rew_con_paragraph">
                    <tbody>
                        <tr>
                            <td valign="top">
                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%;">
                                    <tbody>
                                        <tr>
                                            <td align="left" class="title_blue subtitle">
                                                <strong style="padding-left: 35px;">·其他</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <div id="Misc_edit">
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" border="0" class="weight780 weight780_mdf">
                    <tbody>
                        <tr>
                            <td width="3%">
                            </td>
                            <td valign="top">
                                <img hspace="5" vspace="10" id="Misc_add" style="cursor: pointer;" onclick="addinfo('Misc');"
                                    src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_addcontinue.gif">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table cellspacing="0" cellpadding="0" border="0" class="rew_con_paragraph">
                    <tbody>
                        <tr>
                            <td class="height15">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <table cellspacing="0" cellpadding="0" border="0" class="rew_con_paragraph">
                <tbody>
                    <tr>
                        <td align="center">
                            <img hspace="5" align="absmiddle" vspace="15" style="cursor: pointer;" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_submit_2.gif"
                                onclick="All_check();">
                            <a target="_blank" class="orange" href="/sc/applyjob/preview_resume.php?ReSumeID=69897533&amp;AccountID=48107746">
                                <strong>[预览]</strong> </a>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</body>
</html>
