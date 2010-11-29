<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResuView.aspx.cs" Inherits="Admin_ResuView" %>

<%@ Register Src="~/Admin/Control/ResumeView.ascx" TagName="ResumeView" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看简历</title>
</head>
<body>
    <uc1:ResumeView ID="ResumeView1" runat="server" />
</body>
</html>
