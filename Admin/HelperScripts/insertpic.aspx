<%@ Page language="c#" %>
<HTML>
<HEAD>
<TITLE>����ͼƬ�ļ�</TITLE>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<meta http-equiv="Pragma" content="no-cache">
<link rel="stylesheet" type="text/css" href="editor_dialog.css">
<script language="JavaScript">
var checkimg = false;

function OK(){
  var str1="";
  var strurl=document.form1.url.value;
  if (strurl==""||strurl=="http://")
  {
  	alert("��������ͼƬ��ַ�������ϴ�ͼƬ��");
	document.form1.url.focus();
	return false;
  }
  else
  {
    str1="<img src='"+document.form1.url.value+"' alt='"+document.form1.alttext.value+"' ";
    if(document.form1.width.value!=''&&document.form1.width.value!='0') str1=str1+"width='"+document.form1.width.value+"' ";
    if(document.form1.height.value!=''&&document.form1.height.value!='0') str1=str1+"height='"+document.form1.height.value+"' ";
    str1=str1+"border="+document.form1.border.value+" align='"+document.form1.aligntype.value+"' ";
	if(document.form1.vspace.value!=''&&document.form1.vspace.value!='0') str1=str1+"vspace='"+document.form1.vspace.value+"' ";
	if(document.form1.hspace.value!=''&&document.form1.hspace.value!='0') str1=str1+"hspace='"+document.form1.hspace.value+"' ";
	if(document.form1.styletype.value!='')	str1=str1+"style='"+document.form1.styletype.value+"'";
    str1=str1+" onload=\"javascript:if(this.width>400)this.width=400\" onclick=\"window.open('" + document.form1.url.value + "','_blank');\" >";

if (checkimg) //If image is selected 
{
var Width = document.form1.width.value;
var Height = document.form1.height.value;
var AltText = document.form1.alttext.value;
var src = document.form1.url.value;
var HSpace = document.form1.hspace.value;
var Align = document.form1.aligntype.value;
var VSpace = document.form1.vspace.value;
var Border = document.form1.border.value;
var StyleType = document.form1.styletype.value.replace("filter:","");
var xx = window.dialogArguments[1];
xx.UpdateImage(src,AltText,Align,Border,Width,Height,HSpace,VSpace,StyleType,window.dialogArguments[0]);
}
else
{
    window.returnValue = str1;
    }
    window.close();
  }
}
function IsDigit()
{
  return ((event.keyCode >= 48) && (event.keyCode <= 57));
}
function getpic() {
var retCol
  bascol = showModalDialog("SelectUpFile.aspx",window,"center:yes;dialogHeight:400px;dialogWidth:450px;help:no;status:no");
  if(bascol!=null){
  form1.url.value =bascol;}
}

</script>
</head>
<BODY onload="checkImage()" bgColor=menu topmargin=15 leftmargin=15 >
<form name="form1" method="post" action="">
<table width=100% border="0" align="center" cellpadding="0" cellspacing="2">
  <tr><td>
<FIELDSET align=left>
<LEGEND align=left>����ͼƬ����</LEGEND>
<table border="0" align=center cellpadding="0" cellspacing="3">
<tr>
  <td colspan="2">ͼƬ��ַ��
    <input name="url" id="url" value='http://' size=38 maxlength="200">

    <input type="button" name="Submit" value="..." title="�����ϴ��ļ���ѡ��" onClick="getpic()">
</td>
  </tr><tr>
          <td> ˵�����֣�
            <input name="alttext" id=alttext size=20 maxlength="100">
            </td>
          <td>ͼƬ�߿�
            <input name="border" id=border ONKEYPRESS="event.returnValue=IsDigit();"  value="0" size=5 maxlength="2">
            ����          </td>
  </tr><tr><td>
		����Ч����
		<select name="styletype" id=styletype>
              <option selected>��Ӧ��</option>
              <option value="filter:Alpha(Opacity=50)">��͸��Ч��</option>
              <option value="filter:Alpha(Opacity=0, FinishOpacity=100, Style=1, StartX=0, StartY=0, FinishX=100, FinishY=140)">����͸��Ч��</option>
              <option value="filter:Alpha(Opacity=10, FinishOpacity=100, Style=2, StartX=30, StartY=30, FinishX=200, FinishY=200)">����͸��Ч��</option>
              <option value="filter:blur(add=1,direction=14,strength=15)">ģ��Ч��</option>
              <option value="filter:blur(add=true,direction=45,strength=30)">�綯ģ��Ч��</option>
              <option value="filter:Wave(Add=0, Freq=60, LightStrength=1, Phase=0, Strength=3)">���Ҳ���Ч��</option>
              <option value="filter:gray">�ڰ���ƬЧ��</option>
              <option value="filter:Chroma(Color=#FFFFFF)">��ɫΪ͸��</option>
              <option value="filter:DropShadow(Color=#999999, OffX=7, OffY=4, Positive=1)">Ͷ����ӰЧ��</option>
              <option value="filter:Shadow(Color=#999999, Direction=45)">��ӰЧ��</option>
              <option value="filter:Glow(Color=#ff9900, Strength=5)">����Ч��</option>
              <option value="filter:flipv">��ֱ��ת��ʾ</option>
              <option value="filter:fliph">���ҷ�ת��ʾ</option>
              <option value="filter:grays">���Ͳ�ɫ��</option>
              <option value="filter:xray">X����ƬЧ��</option>
              <option value="filter:invert">��ƬЧ��</option>
            </select>
</td>
              <td>ͼƬλ�ã�
                <select name="aligntype" id=aligntype>
                  <option selected>Ĭ��λ��
                  <option value="left">����
                  <option value="right" >����
                  <option value="top">����
                  <option value="middle">�в�
                  <option value="bottom">�ײ�
                  <option value="absmiddle">���Ծ���
                  <option value="absbottom">���Եײ�
                  <option value="baseline">����
                  <option value="texttop">�ı�����
              </select></td>
            </tr>
  <tr>
    <td>ͼƬ��ȣ�
      <input name="width" id=width2  ONKEYPRESS="event.returnValue=IsDigit();" size=4 maxlength="4">
      ����</td>
    <td>ͼƬ�߶ȣ�
      <input name="height" id="height3" onKeyPress="event.returnValue=IsDigit();" size=4 maxlength="4">
����</td>
  </tr><tr>
            <td>���¼�ࣺ 
              <input name="vspace" id=vspace  ONKEYPRESS="event.returnValue=IsDigit();" value="0" size=4 maxlength="2">
            ����</td>
            <td>���Ҽ�ࣺ
            <input name="hspace" id=hspace onKeyPress="event.returnValue=IsDigit();"  value="0" size=4 maxlength="2">
            ����</td>
      </tr></table>
</fieldset>
</td><td width=80 align="center"><input name="cmdOK" type="button" id="cmdOK" value="  ȷ��  " onClick="OK();">
  <br>
  <br>
<input name="cmdCancel" type=button id="cmdCancel" onclick="window.close();" value='  ȡ��  '></td></tr>
</table>
</form>
		<SCRIPT  language="javascript">
			function checkImage()
			{
			var xy=window.dialogArguments[0];
			var oSel = xy.document.selection.createRange();
			if ((oSel.item) && (oSel.item(0).tagName=="IMG")) //If image is selected 
				{
				checkimg = true;
				document.all.url.value = oSel.item(0).src
				document.all.alttext.value = oSel.item(0).alt
				document.all.aligntype.value = oSel.item(0).align
				document.all.border.value = oSel.item(0).border
				document.all.width.value = oSel.item(0).width
				document.all.height.value = oSel.item(0).height
				document.all.hspace.value = oSel.item(0).hspace
				document.all.vspace.value = oSel.item(0).vspace
				}
			else
				{
				}		
			}
		</SCRIPT>
</body>
</html>

