﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Inner.master" AutoEventWireup="true"
    CodeFile="copyright.aspx.cs" Inherits="copyright" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="ConBox detailTopBg column">
        <div class="DetTop">
            <h1>
                版权声明
            </h1>
            <p class="subMark">
                [ 字体：<a href="javascript:void(0);" onclick="changeFontSize(this,'f14');">大</a> <a
                    href="javascript:void(0);" onclick="changeFontSize(this,'f13');">中</a> <a href="javascript:void(0);"
                        onclick="changeFontSize(this,'f12');" class="cur">小</a> ] [ <a href="javascript:window.print();">
                            打印</a> ] [ <a href="javascript:window.close();">关闭</a> ]
            </p>
        </div>
        <div class="DetCon" id="ConDetail">
            <p>
                1、本网所有内容，版权均属广州天河区沙河供销社所有，任何媒体、网站或个人未经本网协议授权不得转载、链接、转贴或以其他方式复制发布/发表。已经本网协议授权的媒体、网站，在下载使用时必须注明"稿件来源：广州天河区沙河供销社"，违者本网将依法追究责任。凡本网注明"来源：XXX
                "的文/图等稿件，本网转载出于传递更多信息之目的，并不意味着赞同其观点或证实其内容的真实性。</p>
            <p>
                2、除注明"来源：广州天河区沙河供销社"的内容外，本网以下内容亦不可任意转载：<br />
                a.本网所指向的非本网内容的相关链接内容；
                <br />
                b.已作出不得转载或未经许可不得转载声明的内容；
                <br />
                c.未由本网署名或本网引用、转载的他人作品等非本网版权内容；
                <br />
                d.本网中特有的图形、标志、页面风格、编排方式、程序等；
                <br />
                e.本网中必须具有特别授权或具有注册用户资格方可知晓的内容；
                <br />
                f.其他法律不允许或本网认为不适合转载的内容。
            </p>
            <p>
                3、转载或引用本网内容必须是以新闻性或资料性公共免费信息为使用目的的合理、善意引用，不得对本网内容原意进行曲解、修改，同时必须保留本网注明的"稿件来源"，并自负版权等法律责任。</p>
            <p>
                4、转载或引用本网内容不得进行如下活动：<br />
                a. 损害本网或他人利益；<br />
                b. 任何违法行为；
                <br />
                c. 任何可能破坏公秩良俗的行为；
                <br />
                d. 擅自同意他人继续转载、引用本网内容；
            </p>
            <p>
                5、转载或引用本网版权所有之内容须注明“转自（或引自）广州天河区沙河供销社”字样，并标明本网网址。</p>
            <p>
                6、对于不当转载或引用本网内容而引起的民事纷争、行政处理或其他损失，本网不承担责任。</p>
            <p>
                7、对不遵守本声明或其他违法、恶意使用本网内容者，本网保留追究其法律责任的权利。</p>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function() { selMenu("SY"); });
    </script>
</asp:Content>
