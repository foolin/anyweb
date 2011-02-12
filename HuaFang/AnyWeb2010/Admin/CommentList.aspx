<%@ Page Language="C#" MasterPageFile="~/Admin/AdminPage.master" AutoEventWireup="true"
    CodeFile="CommentList.aspx.cs" Inherits="Admin_CommentList" Title="产品评论管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="Server">
    <div class="Mod SummaryList" id="leaveList">
        <div class="Mod Form Search">
            <div class="mbd">
                <div class="fi filter">
                    产品名：<asp:TextBox ID="compGoodsName" ToolTip="请输入产品名称" CssClass="text" Width="80px"
                        runat="server"></asp:TextBox>
                    用户名：<asp:TextBox ID="compUserName" runat="server" CssClass="text" Width="80px"></asp:TextBox>
                    IP地址：<asp:TextBox ID="compIp" runat="server" CssClass="text" Width="80px"></asp:TextBox>
                    回复：<asp:DropDownList ID="compReply" runat="server">
                        <asp:ListItem Value="">--所有--</asp:ListItem>
                        <asp:ListItem Value="0">未回复的</asp:ListItem>
                        <asp:ListItem Value="1">已回复的</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <button onclick="search()">
                        检索</button>
                </div>
            </div>
            <div class="mft">
            </div>
        </div>
        <div class="mbd" style="padding-right: 3px;">
            <div class="selectAll">
                <label class="checkbox">
                    <input type="checkbox" class="checkbox" onclick="SelectAll(this.checked)" />全选</label></div>
            <ul>
                <asp:Repeater ID="compRep" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <li class="item">
                            <h4>
                                <label>
                                    <input type="checkbox" name="ids" value="<%#Eval("fdCommID")%>" />
                                    Re:<a href="javascript:;"><%#Eval("Goods.fdGoodName")%></a> <a href="javascript:;"
                                        onclick="this.parentNode.parentNode.nextSibling.nextSibling.style.display='block';">
                                        回复</a>
                                </label>
                            </h4>
                            <div class="txt">
                                <p class="cont">
                                    <%#Eval("fdCommContent")%></p>
                                <div class='reply' style="display: <%#Eval("fdCommReply").ToString().Trim() == "" ? "none" : "block" %>"
                                    title='回复于：<%# Eval("fdCommReplyAt", "{0:yyyy-MM-dd hh:mm}")%>'>
                                    <strong>回复：</strong>:<span><%#Eval("fdCommReply")%></span></div>
                            </div>
                            <div style="display: none">
                                <textarea rows="3" cols="30"><%#Eval("fdCommReply")%></textarea><input type="button"
                                    onclick="reply(this,<%#Eval("fdCommID") %>)" value="回复" />
                                <input type='button' value='取消' onclick="this.parentNode.style.display='none';" /></div>
                            <ul class="info">
                                <li>时间：<%#Eval("fdCommCreateAt","{0:yyyy-MM-dd HH:mm:ss}")%></li>
                                <li>IP地址：<%#Eval("fdCommIP")%></li>
                                <li>评论人：<%#Eval("fdCommUserName")%></li>
                            </ul>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="smtPager">
                <sw:PageNaver ID="PN1" runat="server" StyleID="2" PageSize="20">
                </sw:PageNaver>
            </div>
        </div>
        <div class="mft">
        </div>
        <input type="button" onclick="dels()" value="批量删除"/>
    </div>
    <div>
        <ul class="Help">
            <li>该功能实现产品评论管理</li>
        </ul>
    </div>

    <script type="text/javascript">
        var currReply = null;
        function reply(target,id)
        {
            var reply = target.previousSibling.value;
            currReply = target.previousSibling;
            var url = "/Ajax/CommentReply.aspx?id="+id;
            $.post(url,"reply="+escape(reply),function (data){
                if(data>0 && currReply!=null)
                {
                    var reply = currReply.value;
                    var html = "<div class='reply' title='回复于："+new Date().toUTCString()+"'><strong>回复：</strong>:<span>"+reply+"</span></div>";
                    $(currReply.parentNode).prev(".txt").children(".reply").replaceWith( html );
                    currReply.parentNode.style.display = "none";
                }
            });
        }
        function SelectAll(v) {
            var list = document.getElementsByTagName("input");
            for (var i = 0; i < list.length; i++) {
                if (list[i].name == "ids" && list[i].type == "checkbox") {
                    list[i].checked = v;
                }
            }
        }
        function dels()
        {
            var list = document.getElementsByTagName("input");
            var selected = false;
            var form0;
            form0 = document.createElement("form");
            form0.method = "POST";
            form0.action = "CommentDel.aspx?action=del";
            for (var i = 0; i < list.length; i++) 
            {
                if (list[i].name == "ids" && list[i].type == "checkbox" && list[i].checked) 
                {
                    input1 = document.createElement("input");
                    input1.type = "hidden";
                    input1.name = "ids";
                    input1.value = list[i].value;
                    form0.appendChild(input1);
                    selected = true;
                }
            }
            if (selected == false) {
                alert("请选择评论");
                return;
            }
            if (confirm("你确定删除选定的评论吗?")) {
                document.body.appendChild(form0);
                form0.submit();
            }
        }
        function search()
        {
            var url = "CommentList.aspx?gname=" + document.getElementById("<%=compGoodsName.ClientID%>").value;
            url += "&uname=" + document.getElementById("<%=compUserName.ClientID%>").value;
            url += "&ip=" + document.getElementById("<%=compIp.ClientID%>").value;
            url += "&reply=" + document.getElementById("<%=compReply.ClientID%>").value;
            window.location = url;
        }
    </script>

</asp:Content>
