<%@ Page language="c#" %>
<HTML>
	<HEAD>
		<title>可运行代码加入器 Flyangel 0506</title>
		<link rel="stylesheet" type="text/css" href="editor_dialog.css">
		<script language="javascript">
		function mysubmit(theform)
{
    if(theform.quotecontent.value=="")
    {
    alert("请输入代码!")
    theform.quotecontent.focus;
    return (false);
    }
    else
    {
	Form1.submit
   	}
    return (true);
}

function onButtoninsert()
{		
arr ="<table cellpadding=0 cellspacing=0 border=0 WIDTH=96% align=center><tr><td>可运行的 HTML 代码片段如下：</td></tr><tr><td align=center><TEXTAREA name=textfield style=\"width:96%\" rows=7>" + document.Form1.quotecontent.value + "</TEXTAREA><INPUT class=\"unnamed5\"  onclick=runEx() type=button value=运行此段HTML代码 name=Button1> <INPUT class=\"unnamed5\" onclick=copy() type=button value=复制到剪贴板 name=Button2></td></tr></table>";
window.returnValue=arr;	
window.close ();
}

function onButtoncancel()
{		
	window.returnValue ='';
	window.close ();
}
		</script>
	</HEAD>
	<BODY bgColor=menu topmargin=15 leftmargin=15 >

		<form id="Form1" name="Form1" onsubmit="return mysubmit(this)" method="post">

<table width=100% border="0" align="center" cellpadding="0" cellspacing="2">
  <tr><td>
<FIELDSET align=left>
<LEGEND align=left>可运行代码加入器</LEGEND>
<table border="0" align=center cellpadding="0" cellspacing="3" style="TABLE-LAYOUT: fixed">
				<tr>
					<td align="center" height="25"><STRONG>要显示的HTML代码</STRONG></td>
				</tr>
				<TR align="center">
					<TD align="center" style="WORD-WRAP: break-word">
						<textarea name="quotecontent" style="width:100%" rows="6" id="quotecontent"></textarea>
					</TD>
				</TR>
				<TR align="center">
					<TD align="center" height="25">
						<INPUT class="unnamed5" onclick="onButtoninsert();" type="button" value="插入可运行的HTML">&nbsp;&nbsp; 
<INPUT class="unnamed5" type="reset" value="重执" name="Submit2">&nbsp;&nbsp; <INPUT class="unnamed5" onclick="onButtoncancel();" type="button" value="取消">
					</asp:Panel></td></tr>
</table>
					</TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
