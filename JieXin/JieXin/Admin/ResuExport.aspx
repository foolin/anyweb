<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResuExport.aspx.cs" Inherits="Admin_ResuExport" %>

<%@ Register Src="~/Admin/Control/ResumeExport.ascx" TagName="ResumeExport" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>导出简历</title>
</head>
<body>
    <uc1:ResumeExport runat="server" />
</body>
</html>
