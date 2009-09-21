<%@ Page language="c#" %>
<HTML>
<HEAD>
<TITLE>插入图片文件</TITLE>
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
  	alert("请先输入图片地址，或者上传图片！");
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
<LEGEND align=left>输入图片参数</LEGEND>
<table border="0" align=center cellpadding="0" cellspacing="3">
<tr>
  <td colspan="2">图片地址：
    <input name="url" id="url" value='http://' size=38 maxlength="200">

    <input type="button" name="Submit" value="..." title="从已上传文件中选择" onClick="getpic()">
</td>
  </tr><tr>
          <td> 说明文字：
            <input name="alttext" id=alttext size=20 maxlength="100">
            </td>
          <td>图片边框：
            <input name="border" id=border ONKEYPRESS="event.returnValue=IsDigit();"  value="0" size=5 maxlength="2">
            像素          </td>
  </tr><tr><td>
		特殊效果：
		<select name="styletype" id=styletype>
              <option selected>不应用</option>
              <option value="filter:Alpha(Opacity=50)">半透明效果</option>
              <option value="filter:Alpha(Opacity=0, FinishOpacity=100, Style=1, StartX=0, StartY=0, FinishX=100, FinishY=140)">线型透明效果</option>
              <option value="filter:Alpha(Opacity=10, FinishOpacity=100, Style=2, StartX=30, StartY=30, FinishX=200, FinishY=200)">放射透明效果</option>
              <option value="filter:blur(add=1,direction=14,strength=15)">模糊效果</option>
              <option value="filter:blur(add=true,direction=45,strength=30)">风动模糊效果</option>
              <option value="filter:Wave(Add=0, Freq=60, LightStrength=1, Phase=0, Strength=3)">正弦波纹效果</option>
              <option value="filter:gray">黑白照片效果</option>
              <option value="filter:Chroma(Color=#FFFFFF)">白色为透明</option>
              <option value="filter:DropShadow(Color=#999999, OffX=7, OffY=4, Positive=1)">投射阴影效果</option>
              <option value="filter:Shadow(Color=#999999, Direction=45)">阴影效果</option>
              <option value="filter:Glow(Color=#ff9900, Strength=5)">发光效果</option>
              <option value="filter:flipv">垂直翻转显示</option>
              <option value="filter:fliph">左右翻转显示</option>
              <option value="filter:grays">降低彩色度</option>
              <option value="filter:xray">X光照片效果</option>
              <option value="filter:invert">底片效果</option>
            </select>
</td>
              <td>图片位置：
                <select name="aligntype" id=aligntype>
                  <option selected>默认位置
                  <option value="left">居左
                  <option value="right" >居右
                  <option value="top">顶部
                  <option value="middle">中部
                  <option value="bottom">底部
                  <option value="absmiddle">绝对居中
                  <option value="absbottom">绝对底部
                  <option value="baseline">基线
                  <option value="texttop">文本顶部
              </select></td>
            </tr>
  <tr>
    <td>图片宽度：
      <input name="width" id=width2  ONKEYPRESS="event.returnValue=IsDigit();" size=4 maxlength="4">
      像素</td>
    <td>图片高度：
      <input name="height" id="height3" onKeyPress="event.returnValue=IsDigit();" size=4 maxlength="4">
像素</td>
  </tr><tr>
            <td>上下间距： 
              <input name="vspace" id=vspace  ONKEYPRESS="event.returnValue=IsDigit();" value="0" size=4 maxlength="2">
            像素</td>
            <td>左右间距：
            <input name="hspace" id=hspace onKeyPress="event.returnValue=IsDigit();"  value="0" size=4 maxlength="2">
            像素</td>
      </tr></table>
</fieldset>
</td><td width=80 align="center"><input name="cmdOK" type="button" id="cmdOK" value="  确定  " onClick="OK();">
  <br>
  <br>
<input name="cmdCancel" type=button id="cmdCancel" onclick="window.close();" value='  取消  '></td></tr>
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

