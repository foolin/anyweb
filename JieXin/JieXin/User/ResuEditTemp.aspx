<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResuEditTemp.aspx.cs" Inherits="User_ResuEditTemp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" src="../js/jquery.js"></script>

    <script type="text/javascript" src="../js/form.js"></script>

    <script type="text/javascript" src="../js/jsBase.js"></script>

    <script type="text/javascript" src="../js/resume.js"></script>

</head>
<body>
    <div id="Edu">
        <asp:Repeater ID="rep1" runat="server">
            <ItemTemplate>
                <div id="Edu_<%#Eval("fdEducID") %>">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    时间
                                </td>
                                <td>
                                    <%#Eval("fdEducBegin","{0:yyyy年M月}")%>
                                    到
                                    <%#Eval("fdEducEnd", "{0:yyyy}") == "2099" ? "至今" : Eval("fdEducEnd", "{0:yyyy年M月}")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    学校
                                </td>
                                <td>
                                    <%#Eval("fdEducSchool") %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    专业
                                </td>
                                <td>
                                    <%#(int)Eval("fdEducSpeciality")==0?Eval("fdEducOtherSpecialty"):""%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    学历
                                </td>
                                <td>
                                    <%#Eval("fdEducDegree")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    专业描述
                                </td>
                                <td>
                                    <%#Eval("fdEducIntro") %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <img style="cursor: pointer;" onclick="editinfo('Edu',<%#Eval("fdEducID") %>);" src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_modify.gif"
                                        alt="" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div>
        <img hspace="5" vspace="10" id="Edu_add" style="cursor: pointer;" onclick="addinfo('Edu',<%=QS("id") %>);"
            src="http://img01.51jobcdn.com/im/2009/cv/cresume/btn_addcontinue.gif" alt="" /></div>
    <input type="hidden" id="active" name="active" />
</body>
</html>
