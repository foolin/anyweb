<%@ Page Language="C#" AutoEventWireup="true" CodeFile="renderarticle.aspx.cs" Inherits="renderarticle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="width: 810px;">
        <img src="public/images/pdflog.jpg" alt="" style="width: 295px; height: 119px; margin-left: 510px;" />
        <div style="width: 800px;">
            <asp:Repeater ID="rep" runat="server">
                <ItemTemplate>
                    <%#Eval("fdArtiContent") %>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <%--<br />
        <br />
        <br />
        <br />
        <br />
        <table border="0" style="font-size:14px;">
            <tr>
                <td>
                    T
                </td>
                <td align="left" style="width:165px;">
                    ：(852) 2581 0180
                </td>
                <td style="width:500px;">
                    高聞顧問有限公司
                </td>
            </tr>
            <tr>
                <td>
                    F
                </td>
                <td align="left">
                    ：(852) 2545 9202
                </td>
                <td>
                    Gaowen Consultancy Limited
                </td>
            </tr>
            <tr>
                <td>
                    W
                </td>
                <td align="left">
                    ：www.gwsme.com
                </td>
                <td>
                    香港中環德輔道中173號南豐大廈8樓803-5室
                </td>
            </tr>
            <tr>
                <td>
                    E
                </td>
                <td align="left">
                    ：info@gwsme.com
                </td>
                <td>
                    Unit 803-5, 8/F, Nan Fung Tower, 173 Des Voeux Road Central, Hong Kong
                </td>
            </tr>
        </table>--%>
    </div>
</body>
</html>
