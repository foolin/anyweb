<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="ApplyList.aspx.cs" Inherits="Admin_ApplyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
    <ul class="Opr">
        <li><a href="<%=back %>">返回招聘列表</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">

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
                简历列表</h3>
        </div>
        <div class="fi filter">
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
                                <%#DateTime.Now.Year - (( DateTime ) Eval( "fdResuBirthday" )).Year%>
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
    <div class="choArea" id="divExport">
        <div class="top">
            <i class="iTit">正在导出简历</i>
        </div>
        <div class="con gray">
            数据下载中，请稍候...
        </div>
    </div>
</asp:Content>
