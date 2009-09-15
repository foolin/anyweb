<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImagesCtl.ascx.cs" Inherits="Controls_ImagesCtl" %>
<div class="box-title">
    焦点图片</div>
<div class="box-content">
    <div class="focuspic" style="text-align: center; padding-top: 5px; padding-bottom: 5px;">
    <%--<asp:Repeater ID="repImage" runat="server">
        <ItemTemplate>
            imgUrl[<%#Container.ItemIndex+1 %>]='<%Eval("PhotPath") %>';
            imgLink[<%#Container.ItemIndex+1 %>]='<%Eval("PhotPath") %>';
            imgText[1]='二届四次教职工(工会会员)代表大会召开';
        </ItemTemplate>
    </asp:Repeater>--%>
        <script type="text/javascript">
            <!--
            var focus_width=290;
            var focus_height=231;
            var text_height=30;
			//如果是IE浏览器
			if (navigator.userAgent.indexOf("MSIE")>= 0) {
			  focus_width=290;
			  focus_height=210;
			  text_height=20;
			}
            var swf_height = focus_height+text_height
            var order=new Array('','1','2','3','4','5');var xb;
            var pics="";
            var links="";
            var texts="";
            var imgUrl=new Array();
            var imgLink=new Array();
            var imgText=new Array();
            
            imgUrl[1]='http://news.gzhu.edu.cn/upload/info/null2009526306.jpg';
            imgLink[1]='http://news.gzhu.edu.cn/newsxp/index.jsp?id=8232';
            imgText[1]='二届四次教职工(工会会员)代表大会召开';
            imgUrl[2]='http://news.gzhu.edu.cn/upload/info/null200952393131.JPG';
            imgLink[2]='http://news.gzhu.edu.cn/newsxp/index.jsp?id=8219';
            imgText[2]='广州大学校友座谈联谊会召开';
            imgUrl[3]='http://news.gzhu.edu.cn/upload/info/null200952242143.jpg';
            imgLink[3]='http://news.gzhu.edu.cn/newsxp/index.jsp?id=8216';
            imgText[3]='我校在市政务服务中心建立“精神文明共建基地”';
            imgUrl[4]='http://news.gzhu.edu.cn/upload/info/null200951493535.jpg';
            imgLink[4]='http://news.gzhu.edu.cn/newsxp/index.jsp?id=8178';
            imgText[4]='“广东中南声像灯光设计研究院”揭牌仪式昨日举行';
            imgUrl[5]='http://news.gzhu.edu.cn/upload/info/null200951292935.jpg';
            imgLink[5]='http://news.gzhu.edu.cn/newsxp/index.jsp?id=8169';
            imgText[5]='众志成城力争灾后重建早日胜利完成';
            var j=0;
                for (i=1;i<=5;i++) {
                        xb=order[i];
                    if( (imgUrl[xb]!='') && (imgLink[xb]!='') ) {
                                     if(j !=0){
                             pics=pics+'|';
                             links=links+'|';
                             texts=texts+'|';
                          }
              pics=pics+imgUrl[xb];
                                     links=links+imgLink[xb];
                                      texts=texts+imgText[xb];
                          j++;
                    } 
                }	
             document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');
             document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="images/focuspic.swf"><param name="quality" value="high"><param name="bgcolor" value="#ffffff">');
            document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
            document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');
            document.write('<embed src="images/focuspic.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false" bgcolor="#ffffff" quality="high" width="'+ focus_width +'" height="'+ focus_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');		document.write('</object>');
            //-->
        </script>

    </div>
</div>
