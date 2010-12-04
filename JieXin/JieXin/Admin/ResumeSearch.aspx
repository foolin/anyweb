<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ResumeSearch.aspx.cs" Inherits="Admin_ResumeSearch" %>

<%@ Register Src="Control/Area2.ascx" TagName="Area2" TagPrefix="uc1" %>
<%@ Register Src="Control/Industry2.ascx" TagName="Industry2" TagPrefix="uc1" %>
<%@ Register Src="Control/Major.ascx" TagName="Major" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

    <script type="text/javascript" src="js/area.js"></script>

    <script type="text/javascript" src="js/major.js"></script>

    <script type="text/javascript" src="js/function.js"></script>

    <script type="text/javascript">
        function SelectAll(v) {
            var list = document.getElementsByTagName("input");
            for (var i = 0; i < list.length; i++) {
                if (list[i].name == "ids" && list[i].type == "checkbox") {
                    list[i].checked = v;
                }
            }
        }
    </script>

    <div class="Mod DataList">
        <div class="mhd">
            <h3>
                人才搜索</h3>
        </div>
        <div class="fi filter">
            简历编号：
            <input type="text" id="no" class="text" style="width: 80px" value="<%=no==0?"":no.ToString() %>" />
            <span id="Error_no" class="invalid" style="display: none">编号格式错误！</span> 搜索类别：
            <select id="type">
                <option value="1" <%=type==1?"selected=\"selected\"":"" %>>全文</option>
                <option value="2" <%=type==2?"selected=\"selected\"":"" %>>职务名</option>
                <option value="3" <%=type==3?"selected=\"selected\"":"" %>>公司名</option>
                <option value="4" <%=type==4?"selected=\"selected\"":"" %>>学校名</option>
                <option value="5" <%=type==5?"selected=\"selected\"":"" %>>证书</option>
                <option value="6" <%=type==6?"selected=\"selected\"":"" %>>工作经历</option>
            </select>
            关键字：
            <input type="text" id="key" name="key" class="text" value="<%=QS("key")==""?"多关键字用空格隔开":QS("key") %>" <%=QS("key")==""||QS("key")=="多关键字用空格隔开"?"style=\"color: DarkGray;\"":"" %>
                onfocus="if(this.value=='多关键字用空格隔开'){this.value='';this.style.color='black';}"
                onblur="if(this.value==''){this.value='多关键字用空格隔开';this.style.color='DarkGray';}" />
            工作年限：
            <select id="workfrom">
                <option value="0" <%=workfrom==0?"selected=\"selected\"":"" %>>不限</option>
                <option value="1" <%=workfrom==1?"selected=\"selected\"":"" %>>1年以下</option>
                <option value="2" <%=workfrom==2?"selected=\"selected\"":"" %>>1-2年</option>
                <option value="3" <%=workfrom==3?"selected=\"selected\"":"" %>>2-5年</option>
                <option value="4" <%=workfrom==4?"selected=\"selected\"":"" %>>5-10年</option>
                <option value="5" <%=workfrom==5?"selected=\"selected\"":"" %>>10年以上</option>
            </select>
            到
            <select id="workto">
                <option value="0" <%=workto==0?"selected=\"selected\"":"" %>>不限</option>
                <option value="1" <%=workto==1?"selected=\"selected\"":"" %>>1年以下</option>
                <option value="2" <%=workto==2?"selected=\"selected\"":"" %>>1-2年</option>
                <option value="3" <%=workto==3?"selected=\"selected\"":"" %>>2-5年</option>
                <option value="4" <%=workto==4?"selected=\"selected\"":"" %>>5-10年</option>
                <option value="5" <%=workto==5?"selected=\"selected\"":"" %>>10年以上</option>
            </select>
            学历：
            <select id="edufrom">
                <option value="0" <%=edufrom==0?"selected=\"selected\"":"" %>>不限</option>
                <option value="1" <%=edufrom==1?"selected=\"selected\"":"" %>>初中</option>
                <option value="2" <%=edufrom==2?"selected=\"selected\"":"" %>>高中</option>
                <option value="3" <%=edufrom==3?"selected=\"selected\"":"" %>>中技</option>
                <option value="4" <%=edufrom==4?"selected=\"selected\"":"" %>>中专</option>
                <option value="5" <%=edufrom==5?"selected=\"selected\"":"" %>>大专</option>
                <option value="6" <%=edufrom==6?"selected=\"selected\"":"" %>>本科</option>
                <option value="7" <%=edufrom==7?"selected=\"selected\"":"" %>>MBA</option>
                <option value="8" <%=edufrom==8?"selected=\"selected\"":"" %>>硕士</option>
                <option value="9" <%=edufrom==9?"selected=\"selected\"":"" %>>博士</option>
                <option value="10" <%=edufrom==10?"selected=\"selected\"":"" %>>其他</option>
            </select>
            到
            <select id="eduto">
                <option value="0" <%=eduto==0?"selected=\"selected\"":"" %>>不限</option>
                <option value="1" <%=eduto==1?"selected=\"selected\"":"" %>>初中</option>
                <option value="2" <%=eduto==2?"selected=\"selected\"":"" %>>高中</option>
                <option value="3" <%=eduto==3?"selected=\"selected\"":"" %>>中技</option>
                <option value="4" <%=eduto==4?"selected=\"selected\"":"" %>>中专</option>
                <option value="5" <%=eduto==5?"selected=\"selected\"":"" %>>大专</option>
                <option value="6" <%=eduto==6?"selected=\"selected\"":"" %>>本科</option>
                <option value="7" <%=eduto==7?"selected=\"selected\"":"" %>>MBA</option>
                <option value="8" <%=eduto==8?"selected=\"selected\"":"" %>>硕士</option>
                <option value="9" <%=eduto==9?"selected=\"selected\"":"" %>>博士</option>
                <option value="10" <%=eduto==10?"selected=\"selected\"":"" %>>其他</option>
            </select>
            年龄：
            <input type="text" id="agefrom" class="text" style="width: 40px;" value="<%=agefrom==0?"":agefrom.ToString() %>" />
            到
            <input type="text" id="ageto" class="text" style="width: 40px;" value="<%=ageto==0?"":ageto.ToString() %>" />
            <span id="Error_age" class="invalid" style="display: none">请输入数字！</span> 性别：
            <select id="sex">
                <option value="-1" <%=sex==-1?"selected=\"selected\"":"" %>>不限</option>
                <option value="0" <%=sex==0?"selected=\"selected\"":"" %>>男</option>
                <option value="1" <%=sex==1?"selected=\"selected\"":"" %>>女</option>
            </select>
            目前月薪：
            <select id="saleryfrom">
                <option value="0" <%=saleryfrom==0?"selected=\"selected\"":"" %>>不限</option>
                <option value="2" <%=saleryfrom==2?"selected=\"selected\"":"" %>>1500</option>
                <option value="3" <%=saleryfrom==3?"selected=\"selected\"":"" %>>2000</option>
                <option value="4" <%=saleryfrom==4?"selected=\"selected\"":"" %>>3000</option>
                <option value="5" <%=saleryfrom==5?"selected=\"selected\"":"" %>>4500</option>
                <option value="6" <%=saleryfrom==6?"selected=\"selected\"":"" %>>6000</option>
                <option value="7" <%=saleryfrom==7?"selected=\"selected\"":"" %>>8000</option>
                <option value="8" <%=saleryfrom==8?"selected=\"selected\"":"" %>>10000</option>
                <option value="9" <%=saleryfrom==9?"selected=\"selected\"":"" %>>15000</option>
                <option value="10" <%=saleryfrom==10?"selected=\"selected\"":"" %>>20000</option>
                <option value="11" <%=saleryfrom==11?"selected=\"selected\"":"" %>>30000</option>
                <option value="12" <%=saleryfrom==12?"selected=\"selected\"":"" %>>50000</option>
            </select>
            到
            <select id="saleryto">
                <option value="0" <%=saleryto==0?"selected=\"selected\"":"" %>>不限</option>
                <option value="1" <%=saleryto==1?"selected=\"selected\"":"" %>>1499</option>
                <option value="2" <%=saleryto==2?"selected=\"selected\"":"" %>>1999</option>
                <option value="3" <%=saleryto==3?"selected=\"selected\"":"" %>>2999</option>
                <option value="4" <%=saleryto==4?"selected=\"selected\"":"" %>>4499</option>
                <option value="5" <%=saleryto==5?"selected=\"selected\"":"" %>>5999</option>
                <option value="6" <%=saleryto==6?"selected=\"selected\"":"" %>>7999</option>
                <option value="7" <%=saleryto==7?"selected=\"selected\"":"" %>>9999</option>
                <option value="8" <%=saleryto==8?"selected=\"selected\"":"" %>>14999</option>
                <option value="9" <%=saleryto==9?"selected=\"selected\"":"" %>>19999</option>
                <option value="10" <%=saleryto==10?"selected=\"selected\"":"" %>>29999</option>
                <option value="11" <%=saleryto==11?"selected=\"selected\"":"" %>>49999</option>
            </select>
            专业： <a href="javascript:void(0);" onclick="ChooseMajor(this,'ChooseMajor','majorid','major');"
                class="choAreabtn" title="<%=getMajorStr("+","选择/修改")%>">
                <%=getMajorSubStr("+","选择/修改")%></a>
            <input type="hidden" id="majorid" value="<%=getMajoridStr(";","") %>" />
            <input type="hidden" id="major" value="<%=getMajorStr(";","") %>" />
            目前居住地： <a href="javascript:void(0);" onclick="ChooseArea2(this,'ChooseArea2','addressid','address');"
                class="choAreabtn" title="<%=getAddressStr( "+", "选择/修改" )%>">
                <%=getAddressSubStr( "+", "选择/修改" )%></a>
            <input type="hidden" id="addressid" value="<%=getAddressidStr(";","")%>" />
            <input type="hidden" id="address" value="<%=getAddressStr(";","")%>" />
            行业： <a href="javascript:void(0);" onclick="ChooseIndustry2(this,'ChooseIndustry2','industryid','industry');"
                class="choAreabtn" title="<%=getIndustryStr( "+", "选择/修改" )%>">
                <%=getIndustrySubStr( "+", "选择/修改" )%></a>
            <input type="hidden" id="industryid" name="industryid" value="<%=getIndustryidStr( ";", "" )%>" />
            <input type="hidden" id="industry" name="industry" value="<%=getIndustryStr( ";", "" )%>" />
            简历更新：
            <select id="update">
                <option value="1" <%=update==1?"selected=\"selected\"":"" %>>一周内</option>
                <option value="2" <%=update==2?"selected=\"selected\"":"" %>>两周内</option>
                <option value="3" <%=update==3?"selected=\"selected\"":"" %>>一个月内</option>
                <option value="4" <%=update==4?"selected=\"selected\"":"" %>>两个月内</option>
                <option value="5" <%=update==5?"selected=\"selected\"":"" %>>六个月内</option>
                <option value="6" <%=update==6?"selected=\"selected\"":"" %>>
                    <%=DateTime.Now.Year-1 %>年</option>
                <option value="7" <%=update==7?"selected=\"selected\"":"" %>>
                    <%=DateTime.Now.Year-2 %>年</option>
                <option value="8" <%=update==8?"selected=\"selected\"":"" %>>
                    <%=DateTime.Now.Year-3 %>年</option>
            </select>
            <input type="button" value="搜索" onclick="resumesearch()" />
        </div>
        <div class="mbd">
            <table id="datas">
                <thead>
                    <tr>
                        <th style="width: 30px;">
                            <input type="checkbox" class="checkbox" onclick="SelectAll(this.checked)" title="全选" />
                        </th>
                        <th>
                            ID
                        </th>
                        <th>
                            年龄
                        </th>
                        <th>
                            工作年限
                        </th>
                        <th>
                            性别
                        </th>
                        <th>
                            目前居住地
                        </th>
                        <th>
                            专业
                        </th>
                        <th>
                            学历
                        </th>
                        <th>
                            简历更新时间
                        </th>
                    </tr>
                </thead>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr align="center" class="editalt" id="row_<%# Eval("fdResuID")%>">
                            <td style="width: 30px;">
                                <input type="checkbox" name="ids" value="<%# Eval("fdResuID")%>" />
                            </td>
                            <td>
                                <a href="ResuView.aspx?id=<%#Eval("fdResuID") %>" target="_blank" title="查看简历">
                                    <%#Eval("fdResuID") %></a>
                            </td>
                            <td>
                                <%#( ( DateTime ) Eval( "fdResuBirthday" ) ).Year == 1900 ? "" : ( DateTime.Now.Year - ( ( DateTime ) Eval( "fdResuBirthday" ) ).Year ).ToString()%>
                            </td>
                            <td>
                                <%#getExpString( ( int ) Eval( "fdResuExperience" ) )%>
                            </td>
                            <td>
                                <%#( int ) Eval( "fdResuSex" ) == 0 ? "男" : "女"%>
                            </td>
                            <td>
                                <%#Eval( "fdResuAddress" )%>
                            </td>
                            <td>
                                <%#Eval( "Education" ) == null ? "" : Eval( "Education.fdEducSpeciality" ) == "" ? Eval( "Education.fdEducOtherSpecialty" ) : Eval( "Education.fdEducSpeciality" )%>
                            </td>
                            <td>
                                <%#Eval( "Education" ) == null ? "" : getDegreeString( ( int ) Eval( "Education.fdEducDegree" ) )%>
                            </td>
                            <td>
                                <%#Eval( "fdResuUpdateAt","{0:yyyy-MM-dd HH:mm}" )%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div class="smtPager">
                <sw:PageNaver ID="PN1" runat="server" StyleID="2" PageSize="20">
                </sw:PageNaver>
            </div>
        </div>
        <div class="mft">
        </div>
        <button onclick="ResumeExport()" style="height: 28px;" type="button">
            批量导出</button>
    </div>
    <div>
        <ul class="Help">
        </ul>
    </div>
    <uc1:Area2 ID="Area1" runat="server" />
    <uc1:Industry2 ID="Industry1" runat="server" />
    <uc1:Major ID="Major1" runat="server" />
    <div class="choArea" id="divExport">
        <div class="top">
            <i class="iTit">正在导出简历</i>
        </div>
        <div class="con gray">
            数据下载中，请稍候...
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function() {
            myfun("industry2_ul", "li");
        });
    </script>

</asp:Content>
