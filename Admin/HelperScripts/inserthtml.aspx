<%@ Page language="c#" %>
<HTML>
	<HEAD>
		<title>�����д�������� Flyangel 0506</title>
		<link rel="stylesheet" type="text/css" href="editor_dialog.css">
		<script language="javascript">
		function mysubmit(theform)
{
    if(theform.quotecontent.value=="")
    {
    alert("���������!")
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
arr ="<table cellpadding=0 cellspacing=0 border=0 WIDTH=96% align=center><tr><td>�����е� HTML ����Ƭ�����£�</td></tr><tr><td align=center><TEXTAREA name=textfield style=\"width:96%\" rows=7>" + document.Form1.quotecontent.value + "</TEXTAREA><INPUT class=\"unnamed5\"  onclick=runEx() type=button value=���д˶�HTML���� name=Button1> <INPUT class=\"unnamed5\" onclick=copy() type=button value=���Ƶ������� name=Button2></td></tr></table>";
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
<LEGEND align=left>�����д��������</LEGEND>
<table border="0" align=center cellpadding="0" cellspacing="3" style="TABLE-LAYOUT: fixed">
				<tr>
					<td align="center" height="25"><STRONG>Ҫ��ʾ��HTML����</STRONG></td>
				</tr>
				<TR align="center">
					<TD align="center" style="WORD-WRAP: break-word">
						<textarea name="quotecontent" style="width:100%" rows="6" id="quotecontent"></textarea>
					</TD>
				</TR>
				<TR align="center">
					<TD align="center" height="25">
						<INPUT class="unnamed5" onclick="onButtoninsert();" type="button" value="��������е�HTML">&nbsp;&nbsp; 
<INPUT class="unnamed5" type="reset" value="��ִ" name="Submit2">&nbsp;&nbsp; <INPUT class="unnamed5" onclick="onButtoncancel();" type="button" value="ȡ��">
					</asp:Panel></td></tr>
</table>
					</TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
